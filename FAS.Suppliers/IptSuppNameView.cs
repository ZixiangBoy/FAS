using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Xls;
using Ultra.Common;
using Ultra.FASControls.Extend;
using Ultra.FASControls.Caller;
using Ultra.FASControls;

namespace FAS.Suppliers
{
    public partial class IptSuppNameView : Ultra.FASControls.Views.ImportDataView
    {
        public IptSuppNameView()
        {
            InitializeComponent();
            this.AfterRemoveFocusRow += IptSuppNameView_AfterRemoveFocusRow;
        }

        void IptSuppNameView_AfterRemoveFocusRow(object sender, EventArgs e)
        {
            ChkData(GridControl.GetDataSource<UltraDbEntity.T_ERP_Suppliers_Imp>());
        }


        /// <summary>
        /// 导入、验证数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChk_Click(object sender, EventArgs e)
        {
            var dc = DicKF;
            if (null == DicKF) return;
            //读取文件数据
            var ipitm = XlsCommon.Read<UltraDbEntity.T_ERP_Suppliers_Imp>(fileBrowser1.Text, DicKF);
            ipitm.ForEach(j => j.SuppName = string.IsNullOrEmpty(j.SuppName) ? string.Empty : j.SuppName.Trim());
            this.GridControl.DataSource = ipitm;
            var bok = ChkData(ipitm);
            if (!bok)
            {
                MsgBox.ShowErrMsg("存在无效数据！");
                return;
            }
        }

        private bool ChkData(List<UltraDbEntity.T_ERP_Suppliers_Imp> ds)
        {
            //检测是否存在同名供应商
            var mch = ds.GroupBy(j => j.SuppName.Trim()).Where(g => g.Count() > 1)
                .Select(j => new { Element = j.Key });
            bool bok = true;
            ds.Where(j => mch.Any(k => k.Element.Equals(j.SuppName.Trim()))).ToList().ForEach(j =>
            {
                j.Remark = "存在同名供应商";
                bok = false;
            });
            if (bok) ds.ForEach(j => j.Remark = string.Empty);
            GridControl.RefreshDataSource();
            btnImp.Enabled = bok;
            return bok;
        }

        /// <summary>
        /// 数据导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImp_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowYesNoMessage("确定要导入吗?") == System.Windows.Forms.DialogResult.No) return;
            var ds = GridControl.GetDataSource<UltraDbEntity.T_ERP_Suppliers_Imp>();
            if (null == ds || ds.Count < 1) return;
            var gid =Guid.NewGuid();
            ds.ForEach(j => {
                j.Guid = gid;
                j.Updator = j.Creator = CurUser;
                j.Address = string.IsNullOrEmpty(j.Address) ? string.Empty : j.Address;
                j.Reserved1 = 0; j.Reserved2 = string.Empty; j.Remark = string.Empty; j.Reserved3 = false;
            });
           var rd = SerNoCaller.Calr_Suppliers_Imp.Add(ds);
           if (!rd.IsOK)
           {
               MsgBox.ShowErrMsg(rd.ErrMsg); return;
           }
            //执行同步
           SerNoCaller.Calr_Suppliers.ExecSql("exec P_ERP_SyncSuppImp @0", gid);

           MsgBox.ShowMessage("导入已完成!");
           DialogResult = System.Windows.Forms.DialogResult.OK;
           Close();
        }

    }
}
