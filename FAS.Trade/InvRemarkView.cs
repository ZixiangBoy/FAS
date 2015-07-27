using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;

namespace FAS.Trade {
    public partial class InvRemarkView : DialogViewEx {

        public string  InvRmrk { get; set; }

        public InvRemarkView() {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate()) return;
            InvRmrk = memoEdit1.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
