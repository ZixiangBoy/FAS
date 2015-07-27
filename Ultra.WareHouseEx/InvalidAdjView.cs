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

namespace Ultra.WareHouseEx
{
    public partial class InvalidAdjView : DialogViewEx
    {
        public InvalidAdjView()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_IvtAdj Ent { get; set; }

        private void InvalidAdjView_Load(object sender, EventArgs e)
        {
            if (null != Ent)
            {
                labelTextBox1.Text = Ent.AdjNo;

            }
            memoEdit1.SelectAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            Ent = SerNoCaller.Calr_IvtAdj.GetByProc("exec P_ERP_InvalidIvtAdj @0,@1,@2",
                Ent.AdjNo, this.CurUser, memoEdit1.Text).FirstOrDefault();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
            return;
        }
    }
}
