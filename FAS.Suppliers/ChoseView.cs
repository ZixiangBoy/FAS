using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;

namespace FAS.Suppliers
{
    public partial class ChoseView : BaseSurface
    {
        public ChoseView()
        {
            InitializeComponent();
        }

        public bool IsImportSuppName { get; set; }

        private void btnCtl2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnCtl1_Click(object sender, EventArgs e)
        {
            IsImportSuppName = rdbsupp.Checked;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
