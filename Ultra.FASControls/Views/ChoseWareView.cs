using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;

namespace Ultra.FASControls.Views
{
    public partial class ChoseWareView : DialogViewEx
    {
        public ChoseWareView()
        {
            InitializeComponent();
        }

        public string WareName { get; set; }

        private void ChoseWareView_Load(object sender, EventArgs e)
        {
            wareNotVirtualEdt1.LoadFromCache();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            WareName = wareNotVirtualEdt1.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
