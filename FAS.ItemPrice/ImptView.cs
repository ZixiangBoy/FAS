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

namespace FAS.ItemPrice {
    public partial class ImptView : ImportDataView {
        public ImptView() {
            InitializeComponent();
        }

        private void fileBrowser1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var dc = DicKF;
            if (null == DicKF) return;
            //读取文件数据
            var dlg = new DevExpress.Utils.WaitDialogForm("正在加载数据,请稍候...", "导入");
            try {
                var ipitm = XlsCommon.Read<UltraDbEntity.T_ERP_ItemPrice_Impt>(fileBrowser1.Text, DicKF);
                this.GridControl.DataSource = ipitm;
            } catch (Exception) {

                throw;
            } finally {
                dlg.Close();
            }
        }

        private bool ChkData(List<UltraDbEntity.T_ERP_ItemPrice_Impt> ds) {
            var bok = true;
            ds.ForEach(j => {
                j.Updator = j.Creator = this.CurUser;
                j.Reserved2 = j.Remark = string.Empty;
            });
            ds.Where(j => string.IsNullOrEmpty(j.OuterIid)).ToList().ForEach(j => {
                j.Remark = "商品编码不能为空";
                bok = false;
            });
            ds.Where(j => string.IsNullOrEmpty(j.OuterSkuId)).ToList().ForEach(j => {
                j.Remark += " 规格编码不能为空";
                bok = false;
            });
            if (bok) ds.ForEach(j => j.Remark = string.Empty);
            GridControl.RefreshDataSource();
            btnImp.Enabled = bok;
            return bok;
        }

        private void btnChk_Click(object sender, EventArgs e) {
            var ipitm = GridControl.GetDataSource<T_ERP_ItemPrice_Impt>();
            var bok = ChkData(ipitm);
            if (!bok) {
                MsgBox.ShowErrMsg("存在无效数据！");
                return;
            }
        }

        private void btnImp_Click(object sender, EventArgs e) {
            if (MsgBox.ShowYesNoMessage("确定要导入吗?") == System.Windows.Forms.DialogResult.No) return;
            var dlg = new DevExpress.Utils.WaitDialogForm("正在导入,请稍候...","导入");
            try {
                var ds = GridControl.GetDataSource<UltraDbEntity.T_ERP_ItemPrice_Impt>();
                if (null == ds || ds.Count < 1) return;
                //var gid = Guid.NewGuid();
                ds.ForEach(j => {
                    j.Guid = Guid.NewGuid();
                    j.Updator = j.Creator = CurUser;

                    j.Reserved1 = 0; j.Reserved2 = string.Empty; j.Remark = string.Empty; j.Reserved3 = false;
                });
                var rd = SerNoCaller.Calr_ItemPrice_Impt.Add(ds);
                if (!rd.IsOK) {
                    MsgBox.ShowErrMsg(rd.ErrMsg); return;
                }

                //执行同步
                SerNoCaller.Calr_ItemPrice_Impt.ExecSql("exec P_FAS_SyncItemPriceImpt");

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
}
