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
using Ultra.Common;
using Ultra.Xls;
using Ultra.CoreCaller;
using Ultra.Surface.Common;
using Ultra.FASControls;


namespace Ultra.FAS.Item
{
    public partial class IptItemView : DialogViewEx
    {
        public IptItemView()
        {
            InitializeComponent();
        }

        public static string[] Exclude = new string[] { 
            "Id","PId","IsDynamicAdd","UISelected",
            //"Guid",,"Reserved2"
            "CreateDate","UpdateDate","Reserved1","Reserved3","Remark",
            "Skus",
            "Orders",
            "PromotDetails",
            "ServiceOrders","ColorValue"
        };

        EFCaller<UltraDbEntity.T_ERP_ItemImports> EFClr { get; set; }

        private void btnExp_Click(object sender, EventArgs e)
        {
            gridControlEx4.GridExportXls();
        }

        /// <summary>
        /// 从文件读取数据并加载至网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChk_Click(object sender, EventArgs e)
        {
            //读取文件数据
            var ipitm = XlsCommon.Read<IptItem>(fileBrowser1.Text, dicKF);
            gridControlEx4.DataSource = ipitm;
            foreach (var item in ipitm)
            {
                var ermsg = string.Empty;
                item.OuterIid = string.IsNullOrEmpty(item.OuterIid) ? string.Empty : item.OuterIid;
                item.OuterSkuId = string.IsNullOrEmpty(item.OuterSkuId) ? string.Empty : item.OuterSkuId;
                ChkData(item, out ermsg);
            }
            if (ipitm.Where(j => !j.Valid).Count() > 0)
            {
                gridControlEx4.RefreshDataSource();
                return;
            }
            //判断是否存在重复编码的
            //var mch = ipitm.GroupBy(j => j.OuterIid + j.OuterSkuId).Where(g => g.Count() > 1)
            //    .Select(j => new { Element = j.Key });
            //ipitm.Where(j => mch.Any(k => k.Element == j.OuterIid + j.OuterSkuId)).ToList().ForEach(j =>
            //{
            //    j.ChkResult = "存在重复的商品编码与规格编码";
            //    j.Valid = false;
            //});
            gridControlEx4.RefreshDataSource();

            btnImp.Enabled = ipitm.Where(j => j.Valid).Count() > 0;
        }

        Dictionary<string, string> dicKF = new Dictionary<string, string>(30);

        private void IptItemView_Load(object sender, EventArgs e)
        {
            EFClr = SerNoCaller_WL.Calr_ItemImports;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView4.Columns)
            {
                if (!dicKF.ContainsKey(col.Caption))
                    dicKF.Add(col.Caption, col.FieldName);
            }
        }

        /// <summary>
        /// 检查数据有效性
        /// </summary>
        /// <param name="itm"></param>
        /// <returns></returns>
        bool ChkData(IptItem itm, out string ermsg)
        {
            ermsg = string.Empty;
            StringBuilder sb = new StringBuilder(20);
            if (string.IsNullOrEmpty(itm.ItemName))
            {
                itm.ChkResult = ermsg = "商品名称不能为空"; itm.Valid = false; return false;
            }
            itm.Valid = true;
            return true;
        }

        /// <summary>
        /// 执行数据导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImp_Click(object sender, EventArgs e)
        {
            var ipitm = gridControlEx4.DataSource as List<IptItem>;
            if (null == ipitm || ipitm.Count < 1) return;
            ipitm = ipitm.Where(j => j.Valid).ToList();
            if (null == ipitm || ipitm.Count < 1) return;
            var session = Guid.NewGuid();
            var ojs = ipitm.MapTo<List<IptItem>, List<UltraDbEntity.T_ERP_ItemImports>>();
            ojs.ForEach(j =>
                {
                    j.Session = session;
                    j.Guid = Guid.NewGuid();
                    j.Creator = j.Updator = CurUser;
                    j.Reserved2 = string.Empty;
                });
            //执行导入
            var rd = EFClr.BatchAdd(new Logic.BatchAddObj<UltraDbEntity.T_ERP_ItemImports>
            {
                TableName = "T_ERP_ItemImports",
                Excludes = Exclude,
                Objs = ojs
            });
            if (!rd.IsOK)
            {
                MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                return;
            }
            //导入成功，调用迁移过程
            rd = EFClr.ExecSql("exec P_ERP_ETL_ItemImports @0", session);
            if (!rd.IsOK)
            {
                MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                return;
            }
            MsgBox.ShowMessage(string.Empty, "导入完成");
            Close();
        }

        private void btnCtl1_Click(object sender, EventArgs e)
        {
            gridColumn22.Visible = gridColumn10.Visible = false;
            this.gridControlEx4.GridExportXls();
            gridColumn22.Visible = gridColumn10.Visible = true;
        }
    }
}

[Serializable]
public class IptItem : UltraDbEntity.T_ERP_Item
{
    public string ChkResult { get; set; }

    public bool Valid { get; set; }
}
