using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.FASControls.Caller;
using Ultra.FASControls;

namespace FAS.Role
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
        }
        
        public UltraDbEntity.T_ERP_Role Entity { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                var r = new UltraDbEntity.T_ERP_Role
                {
                    Guid = Guid.NewGuid(),
                    Name = txtname.Text,
                    Descript = memdesc.Text,
                    IsUsing = chkUsing.Checked,
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    Creator = CurUser,
                    Updator = CurUser
                };

                var bok = SerNoCaller_WL.Calr_Role.Add(r);
                if (bok.IsOK)
                {
                    Entity = r;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    MsgBox.ShowErrMsg(bok.ErrMsg);
                }
            }
            else if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.Updator = CurUser; Entity.IsUsing = chkUsing.Checked;
                Entity.Descript = memdesc.Text;
                var bok = SerNoCaller_WL.Calr_Role.Edt(Entity);
                if (bok.IsOK)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    MsgBox.ShowErrMsg(bok.ErrMsg);
                }
            }
        }

        private void EdtView_Load(object sender, EventArgs e)
        {
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit && Entity != null)
            {
                txtname.Text = Entity.Name; txtname.Properties.ReadOnly = true;
                memdesc.Text = Entity.Descript;
                chkUsing.Checked = Entity.IsUsing;
            }
        }
    }
}
