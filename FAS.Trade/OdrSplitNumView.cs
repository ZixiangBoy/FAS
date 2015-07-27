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

namespace FAS.Trade {
    public partial class OdrSplitNumView : DialogViewEx {
        public int OrderNum { get; set; }

        public int OldOrderNum { get; set; }

        public OdrSplitNumView() {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if ((int)spinEdit1.Value < 1 || (int)spinEdit1.Value >= OldOrderNum) {
                MsgBox.ShowMessage("数量不能小于1或者大于要拆分的商品数量");
                return;
            }

            OrderNum = (int)spinEdit1.Value;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
