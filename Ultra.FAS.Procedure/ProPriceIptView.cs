using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.FASControls.Extend;
using Ultra.Common;
using Ultra.Xls;
using Ultra.FASControls;
using Ultra.Surface.Common;
using Ultra.Web.Core.Common;
using PetaPoco;
using UltraDbEntity;
using System.Data.SqlClient;

namespace Ultra.FAS.Procedure
{
    public partial class ProPriceIptView : DialogViewEx
    {
        public ProPriceIptView()
        {
            InitializeComponent();
            btnOK.Visible = btnOK.Enabled = false;
        }

        private void btnCtl2_Click(object sender, EventArgs e)
        {
            var col = gridView1.Columns.ColumnByFieldName("错误信息");
            col.Visible = false;
            gridControlEx1.GridExportXls();
            col.Visible = true;
        }

        //验证数据
        private void btnCtl3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileBrowser1.Text)) {
                MsgBox.ShowErrMsg("请先选择导入文件");
                return;
            }
            //读取文件数据
            var dt = XlsCommon.Read(fileBrowser1.Text);
            dt.Columns.Add("错误信息", typeof(System.String));
            gridControlEx1.DataSource = dt;
            var cnt = 0;
            List<T_ERP_Item> items = null;
            using (var db = new Database(this.ConnString))
            {
                items = db.Fetch<UltraDbEntity.T_ERP_Item>(" select * from T_ERP_Item ");
            }
            foreach (DataRow dr in dt.Rows)
            {
                if (!ChkData(dr, items))
                    cnt++;
            }
            if (cnt > 0)
            {
                gridControlEx1.RefreshDataSource();
                return;
            }

            //判断是否存在重复编码的
            var query = from t in dt.AsEnumerable()
                        group t by new { t1 = t.Field<string>("商品编码"), t2 = t.Field<string>("规格编码") } into m
                        select new
                        {
                            OuterIid = m.Key.t1,
                            OuterSkuId = m.Key.t2,
                            Cnt = m.Count()
                        };
            if (query.ToList().Count > 0)
            {
                query.ToList().ForEach(q =>
                {
                    if (q.Cnt > 1) {
                        
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["商品编码"].ToString().Equals(q.OuterIid) && dr["规格编码"].ToString().Equals(q.OuterSkuId))
                                dr["错误信息"] = ("存在重复的商品编码与规格编码");
                        }
                        cnt++;
                    }
                });
            } 

            gridControlEx1.RefreshDataSource();
            btnImp.Enabled = cnt < 1;

        }

        bool ChkData(DataRow dr, List<T_ERP_Item> items)
        {
            var ermsg = string.Empty;
            StringBuilder sb = new StringBuilder(20);
            var ber = false;
            ber = (string.IsNullOrEmpty(dr["商品编码"].ToString()) || string.IsNullOrEmpty(dr["规格编码"].ToString()));
            if (ber){
                dr["错误信息"] = ermsg = ("商品编码或规格编码不能为空");
                return false;
            }
            else if (items.Where(j => j.OuterIid == dr["商品编码"].ToString() 
                                   && j.OuterSkuId == dr["规格编码"].ToString()).Count() < 1){
                dr["错误信息"] = ermsg = ("系统商品资料不存在该规格商品");
                return false;
            }
            else{
                dr["错误信息"] = string.Empty;
                return true;
            }
        }

        private void ShopItemIptView_Load(object sender, EventArgs e)
        {
            var dt = SqlHelper.ExecuteDataTable(this.ConnString, CommandType.StoredProcedure, "P_ERP_IptProPriceTpl");
            dt.Columns.Add("错误信息", typeof(System.String));
            gridControlEx1.DataSource = dt;
        }

        private void btnImp_Click(object sender, EventArgs e)
        {

            var dt = gridControlEx1.DataSource as DataTable;
            List<T_ERP_IptPriceTemp> ipts = new List<T_ERP_IptPriceTemp>();
            var session = Guid.NewGuid();
            using (var db = new Database(this.ConnString))
            {
                try{

                    var pros = db.Fetch<UltraDbEntity.T_ERP_Procedure>(" where isnull(IsUsing,0) = 1 ");
                    foreach (DataRow dr in dt.Rows)
                    {
                        pros.ForEach(j => {
                            var ipt = new T_ERP_IptPriceTemp
                            {
                                //Guid = Guid.NewGuid(),
                                //Creator = CurUser,
                                //Updator = CurUser,
                                //Remark = string.Empty,
                                //Reserved1 = 0,
                                //Reserved2 = string.Empty,
                                //Reserved3 = false,

                                Session = session,
                                OuterIid = dr["商品编码"].ToString(),
                                OuterSkuId = dr["规格编码"].ToString(),
                                ProcedureName = j.ProcedureName,
                                ProcedureGuid = j.Guid,
                                CostPrice = string.IsNullOrEmpty(dr[j.ProcedureName] == null 
                                            ? "" : dr[j.ProcedureName].ToString()) 
                                            ? 0 : Convert.ToDecimal(dr[j.ProcedureName])
                            };
                            if (ipt.CostPrice!=0)
                                ipts.Add(ipt);
                        });
                    }
                }catch (Exception ex){
                    MsgBox.ShowErrMsg("导入失败;错误信息：" + ex.Message);
                    return;
                }
            }
            //var excludes = new string[] { "Id", "Guid", "CreateDate", "UpdateDate", "IsDel", "UISelected", "IsDynamicAdd", "TimeStamp" };
            using (SqlConnection destinationConnection = new SqlConnection(this.ConnString))
            {
                
                destinationConnection.Open();
                using (SqlBulkCopy bulkCopy =
                           new SqlBulkCopy(destinationConnection))
                {
                    bulkCopy.DestinationTableName = "T_ERP_IptPrice";
                    try
                    {
                        bulkCopy.WriteToServerAdv(ipts);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowErrMsg("导入失败;错误信息：" + ex.Message);
                        return;
                    }
                }
            }

            //导入成功，调用迁移过程
            var prms = new SqlParameter[]{           
                            new SqlParameter("@session ", session)
                        };
            SqlHelper.ExecuteNonQuery(this.ConnString, CommandType.StoredProcedure, "P_ERP_ProPriceImport", prms);  
            MsgBox.ShowMessage("导入完成");
            fileBrowser1.Text = string.Empty;
            gridControlEx1.DataSource = null;
            btnImp.Enabled = false;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();


        }

        public class T_ERP_IptPriceTemp
        {
            public string OuterIid { get; set; }
            public string OuterSkuId { get; set; }
            public string ProcedureName { get; set; }
            public Guid Session { get; set; }
            public Guid ProcedureGuid { get; set; }
            public decimal CostPrice { get; set; }
        }  
    }


}
