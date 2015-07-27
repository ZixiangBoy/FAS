using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.FASControls;
using Ultra.Surface.Form;
using Ultra.Win.Core.Common;

namespace Ultra.FAS.Refund
{
    public partial class InvalidAfterSale : DialogViewEx
    {
        public InvalidAfterSale()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_AfterSale Ent { get; set; }

        private void InvalidAdjView_Load(object sender, EventArgs e)
        {
            if (null != Ent)
            {
                labelTextBox1.Text = Ent.AfterNo;

            }
            memoEdit1.SelectAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            Ent.Invalider = this.CurUser;
            Ent.IsInvalid = true;
            Ent.InvalidTime = TimeSync.Default.CurrentSyncTime;
            Ent.InvalidRemark = memoEdit1.Text;
            Ultra.FASControls.SerNoCaller_WL.Calr_AfterSale.Edt(Ent);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
