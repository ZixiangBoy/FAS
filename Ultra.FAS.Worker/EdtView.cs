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

namespace Ultra.FAS.Worker
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_Worker Entity { get; set; }

        private void EdtView_Load(object sender, EventArgs e)
        {
            edtProduce.Properties.DataSource = FASControls.SerNoCaller.Calr_Procedure.Get(" where isnull(IsUsing,0) = 1 ");
            
            if (Entity != null && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                txtrealname.Text = Entity.RealName;
                txtmobile.Text = Entity.Moblie;
                txtjobnum.Text = Entity.JobNumber;
                edtProduce.Text = Entity.DeptName;
                chkusing.Checked = Entity.IsUsing;
                txtrealname.Properties.ReadOnly = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var r = new UltraDbEntity.T_ERP_Worker
                {
                    Guid = Guid.NewGuid(),
                    DepGuid = Guid.Empty,
                    Creator = CurUser,
                    Updator = CurUser,
                    Email = string.Empty,
                    GroupName = string.Empty,
                    RealName = txtrealname.Text,
                    Moblie = txtmobile.Text,
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    JobNumber = txtjobnum.Text,
                    DeptName = edtProduce.Text,
                    IsUsing = chkusing.Checked
                };

                FASControls.SerNoCaller_WL.Calr_Worker.Add(r);
                Entity = r;
                DialogResult = System.Windows.Forms.DialogResult.OK; Close();
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.RealName = txtrealname.Text;
                Entity.IsUsing = chkusing.Checked;
                Entity.JobNumber = txtjobnum.Text;
                Entity.Moblie = txtmobile.Text;
                Entity.Updator = CurUser;
                Entity.DeptName = edtProduce.Text;

                FASControls.SerNoCaller_WL.Calr_Worker.Edt(Entity);
                DialogResult = System.Windows.Forms.DialogResult.OK; Close();
            }
        }

    }
}
