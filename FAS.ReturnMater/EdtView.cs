using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using UltraDbEntity;
using Ultra.Common;
using Ultra.FASControls.Extend;
using DevExpress.XtraEditors;
using Ultra.FASControls;

namespace FAS.ReturnMater {
    public partial class EdtView : DialogViewEx {

        public List<T_ERP_ProduceMater> ProMaters;

        public EdtView() {
            InitializeComponent();
        }

        private void EdtView_Load(object sender, EventArgs e) {
            gvProduce.OptionsView.ShowAutoFilterRow = false;

            var users=userEdt.LoadData();
            rspRecvMaterUser.Items.AddRange(users.Select(k => k.UserName).ToArray());
            gcProduce.DataSource = ProMaters.MapTo<List<T_ERP_ProduceMater>, List<T_ERP_RecvMater>>();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var rms = gcProduce.GetDataSource<T_ERP_RecvMater>();
            if (rms.Any(k => string.IsNullOrEmpty(k.UserName) || k.ActQty <= 0)) {
                MsgBox.ShowMessage("领料人和实际领料数量必填");
                return;
            }
            SerNoCaller.Calr_RecvMater.Add(rms);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void userEdt_EditValueChanged(object sender, EventArgs e) {
            if (userEdt.GetSelectedValue() == null) return;

            if (MsgBox.ShowYesNoMessage("确定要批量修改领料人?") == System.Windows.Forms.DialogResult.OK) {
                var rms = gcProduce.GetDataSource<T_ERP_RecvMater>();
                rms.ForEach(k => k.UserName = userEdt.GetSelectedValue().UserName);
            }
        }

        private void rspRecvMaterQty_EditValueChanged(object sender, EventArgs e) {
            var rsp = sender as SpinEdit;
            var rm = gcProduce.GetFocusedDataSource<T_ERP_RecvMater>();
            rm.ActQty = rsp.Value;
            gcProduce.RefreshDataSource();
        }

        private void rspRecvMaterUser_EditValueChanged(object sender, EventArgs e) {
            var rsp = sender as ComboBoxEdit;
            var rm = gcProduce.GetFocusedDataSource<T_ERP_RecvMater>();
            rm.UserName = rsp.SelectedItem.ToString();
            gcProduce.RefreshDataSource();
        }
    }
}
