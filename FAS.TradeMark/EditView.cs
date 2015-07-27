using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.FASControls;
using Ultra.Surface.Form;
using UltraDbEntity;

namespace FAS.TradeMark {
    public partial class EditView : DialogViewEx {

        public T_ERP_TradeMark TradeMark { get; set; }

        public EditView() {
            InitializeComponent();
        }

        private void EditView_Load(object sender, EventArgs e) {
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                txtTradeMark.Text = TradeMark.TradeMark;
                chkIsUsing.Checked = TradeMark.IsUsing;
            }

        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                TradeMark.TradeMark = txtTradeMark.Text;
                TradeMark.IsUsing = chkIsUsing.Checked;
                SerNoCaller.Calr_TradeMark.Edt(TradeMark);
            } else {
                TradeMark = new T_ERP_TradeMark();
                TradeMark.Guid = Guid.NewGuid();
                TradeMark.Creator = TradeMark.Updator = this.CurUser;
                TradeMark.Reserved2 = TradeMark.Remark = string.Empty;
                TradeMark.TradeMark = txtTradeMark.Text; 
                TradeMark.IsUsing = chkIsUsing.Checked;
                SerNoCaller.Calr_TradeMark.Add(TradeMark);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
