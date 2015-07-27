using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Common;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using Ultra.FASControls.Caller;

namespace Ultra.FAS.Item
{
    public partial class EdtWreck : DialogViewEx
    {
        public EdtWreck()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_WreckType Entity { get; set; }

        private void EdtView_Load(object sender, EventArgs e)
        {
            if (Entity != null && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                this.txtName.Text = Entity.TypeName;
                this.txtName.Properties.ReadOnly = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                Entity = new UltraDbEntity.T_ERP_WreckType();
            }
            var type = FASControls.SerNoCaller_WL.Calr_WreckType.Get(" where TypeName = @0 and Guid <> @1 ", txtName.Text, Entity.Guid==null?Guid.NewGuid():Entity.Guid);
            if (type !=null && type.Count>0)
            {
                MsgBox.ShowMessage("当前类型已经存在");
                return;
            }

            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var r = new UltraDbEntity.T_ERP_WreckType
                {
                    Guid = Guid.NewGuid(),
                    Creator = CurUser,
                    Updator = CurUser,
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    TypeName = txtName.Text,
                    IsUsing = chkusing.Checked
                };

                FASControls.SerNoCaller_WL.Calr_WreckType.Add(r);
                Entity = r;
                DialogResult = System.Windows.Forms.DialogResult.OK; Close();
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {

                Entity.IsUsing = chkusing.Checked;
                Entity.Updator = CurUser;
                Entity.TypeName = txtName.Text;

                FASControls.SerNoCaller_WL.Calr_WreckType.Edt(Entity);
                DialogResult = System.Windows.Forms.DialogResult.OK; Close();
            }
        }

    }
}
