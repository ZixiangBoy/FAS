using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;

namespace Ultra.WareHouseEx
{
    public partial class PostTypeEdt : DialogViewEx
    {
        public PostTypeEdt()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_PostFeeType Entity { get; set; }

        public CoreCaller.EFCaller<UltraDbEntity.T_ERP_PostFeeType> Calr { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var rd = Calr.Add(new UltraDbEntity.T_ERP_PostFeeType
                {
                    Guid = Guid.NewGuid(),
                    Creator = CurUser,
                    Updator = CurUser,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    Remark = string.Empty,
                    TypeName = labelTextBox1.Text,
                    IsUsing = checkCtl1.Checked,
                });
                if (rd.IsOK)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                    return;
                }
                else
                {
                    Ultra.Surface.Common.MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                    return;
                }
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.IsUsing = checkCtl1.Checked;
                Entity.Updator = CurUser;
                var rd = Calr.Edt(Entity);
                if (rd.IsOK)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                    return;
                }
                else
                {
                    Ultra.Surface.Common.MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                    return;
                }
            }
        }

        private void EdtView_Load(object sender, EventArgs e)
        {
            if (null != Entity && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                checkCtl1.Checked = Entity.IsUsing;
                labelTextBox1.Text = Entity.TypeName;
                labelTextBox1.Properties.ReadOnly = true;
            }
        }



    }
}
