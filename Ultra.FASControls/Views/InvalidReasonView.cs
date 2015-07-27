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
    public partial class InvalidReasonView : DialogViewEx
    {
        public InvalidReasonView()
        {
            InitializeComponent();
        }

        public string Reason { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            Reason = mem.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
            return;
        }
    }
}
