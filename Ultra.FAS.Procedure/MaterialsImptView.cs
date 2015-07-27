using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.FASControls.Views;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Xls;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using Ultra.FASControls;
using System.Data.SqlClient;
using Ultra.Web.Core.Common;

namespace Ultra.FAS.Procedure
{
    public partial class MaterialsImptView : ImportDataView {
        public MaterialsImptView()
        {
            InitializeComponent();
        }

        private void fileBrowser1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var dc = DicKF;
            if (null == DicKF) return;
            //读取文件数据
            var dlg = new DevExpress.Utils.WaitDialogForm("正在加载数据,请稍候...", "导入");
            try {
                var ipitm = XlsCommon.Read<T_ERP_ProduceDosageIpt>(fileBrowser1.Text, DicKF);
                this.GridControl.DataSource = ipitm;
            } catch (Exception) {

                throw;
            } finally {
                dlg.Close();
            }
        }

        private bool ChkData(List<T_ERP_ProduceDosageIpt> ds)
        {
            List<T_ERP_Item> items = FASControls.SerNoCaller_WL.Calr_Item.Get("where isnull(IsUsing,0) = 1 and isnull(IsAudit,0) = 1");
            List<T_ERP_Procedure> pdes= FASControls.SerNoCaller.Calr_Procedure.Get("where isnull(IsUsing,0) = 1 ");
            List<T_ERP_Material> mats = FASControls.SerNoCaller.Calr_Material.Get("where isnull(IsUsing,0) = 1 ");
            var bok = true;
            ds.ForEach(j => {
                j.Updator = j.Creator = this.CurUser;
                j.Reserved2 = j.Remark = string.Empty;
            });
            ds.Where(j => string.IsNullOrEmpty(j.OuterIid)).ToList().ForEach(j => {
                j.Remark = " 商品编码不能为空";
                bok = false;
            });
            ds.Where(j => string.IsNullOrEmpty(j.OuterSkuId)).ToList().ForEach(j =>
            {
                j.Remark += " 商品名称不能为空";
                bok = false;
            });
            ds.Where(j => j.Dosage==null || j.Dosage<0).ToList().ForEach(j =>
            {
                j.Remark += " 用量不能为空或者小于0";
                bok = false;
            });
            //判断是否存在重复编码的
            var query = from t in ds.AsEnumerable()
                        group t by new { t1 = t.OuterIid, t2 = t.OuterSkuId
                            ,t3=t.ProcedureName,t4 = t.MaterialNo,t5=t.MaterialName } into m
                        select new
                        {
                            OuterIid = m.Key.t1,
                            OuterSkuId = m.Key.t2,
                            ProcedureName = m.Key.t3,
                            MaterialNo = m.Key.t4,
                            MaterialName = m.Key.t5,
                            Cnt = m.Count()
                        };
            if (query.ToList().Count > 0)
            {
                query.ToList().ForEach(q =>
                {
                    if (q.Cnt > 1)
                    {
                        ds.ForEach(j =>
                        {
                            if (j.OuterIid == q.OuterIid && j.OuterSkuId == q.OuterSkuId
                                && j.MaterialNo == q.MaterialNo && j.ProcedureName == q.ProcedureName
                                && j.MaterialName == q.MaterialName) { j.Remark += " 存在同商品同工序同物料的用量"; }
                        });
                        bok = false;
                    }
                });
            } 
            
            if (bok) ds.ForEach(j => j.Remark = string.Empty);
            GridControl.RefreshDataSource();
            btnImp.Enabled = bok;
            return bok;
        }

        private void btnChk_Click(object sender, EventArgs e) {
            var ipitm = GridControl.GetDataSource<T_ERP_ProduceDosageIpt>();
            if (ipitm == null) return;
            var bok = ChkData(ipitm);
            if (!bok)
            {
                MsgBox.ShowErrMsg("存在无效数据！");
                return;
            }
            else
            {
                btnImp.Enabled = true;
            }
        }

        private void btnImp_Click(object sender, EventArgs e) {
            if (MsgBox.ShowYesNoMessage("确定要导入吗?") == System.Windows.Forms.DialogResult.No) return;
            var dlg = new DevExpress.Utils.WaitDialogForm("正在导入,请稍候...","导入");
            try {
                var ds = GridControl.GetDataSource<T_ERP_ProduceDosageIpt>();
                if (null == ds || ds.Count < 1) return;
                var session = Guid.NewGuid();
                List<T_ERP_ProduceDosageIptTemp> ipts = new List<T_ERP_ProduceDosageIptTemp>();
                ds.ForEach(j => {
                    var ipt = new T_ERP_ProduceDosageIptTemp
                    {
                        Session = session,
                        OuterIid = j.OuterIid,
                        OuterSkuId = j.OuterSkuId,
                        ProcedureName = j.ProcedureName,
                        MaterialNo = j.MaterialNo,
                        MaterialName = j.MaterialName,
                        Dosage = j.Dosage,
                        Unit = j.Unit
                    };
                    ipts.Add(ipt);
                });

                using (SqlConnection destinationConnection = new SqlConnection(this.ConnString))
                {
                    destinationConnection.Open();
                    using (SqlBulkCopy bulkCopy =
                               new SqlBulkCopy(destinationConnection))
                    {
                        bulkCopy.DestinationTableName = "T_ERP_ProduceDosageIpt";
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
                            new SqlParameter("@session", session),
                            new SqlParameter("@user", this.CurUser)
                        };
                SqlHelper.ExecuteNonQuery(this.ConnString, CommandType.StoredProcedure, "P_FAS_ProduceDosageImpt", prms); 
            } catch (Exception) {
                throw;
            } finally {
                dlg.Close();
            }
            MsgBox.ShowMessage("导入已完成!");
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }

    public class T_ERP_ProduceDosageIptTemp
    {
        public string OuterIid { get; set; }
        public string OuterSkuId { get; set; }
        public string ProcedureName { get; set; }
        public Guid Session { get; set; }
        public string MaterialNo { get; set; }
        public string MaterialName { get; set; }
        public decimal? Dosage { get; set; }
        public string Unit { get; set; }
    }  

}


