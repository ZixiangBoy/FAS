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

namespace Ultra.FAS.Procedure
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_Procedure Entity { get; set; }

        private void EdtView_Load(object sender, EventArgs e)
        {
            if (Entity != null && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                this.txtName.Text = Entity.ProcedureName;
                this.spnOrder.EditValue = Entity.OrderNo;
                this.spnBatch.EditValue = Entity.BatchNo;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            if (spnOrder.EditValue != null) {
                using (var db = new Database(this.ConnString))
                {
                    var count = db.ExecuteScalar<int>(" select count(1) from T_ERP_Procedure where OrderNo = @0 and Guid <> @1 ", Convert.ToInt32(spnOrder.EditValue), Entity==null?Guid.Empty:Entity.Guid);
                    if (count > 0) {
                        MsgBox.ShowMessage("当前序号已经存在");
                        return;
                    }
                }
            }

            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var r = new UltraDbEntity.T_ERP_Procedure
                {
                    Guid = Guid.NewGuid(),
                    Creator = CurUser,
                    Updator = CurUser,
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    ProcedureName = txtName.Text,
                    LabourCost = 0,
                    OrderNo = Convert.ToInt32(spnOrder.EditValue),
                    BatchNo = Convert.ToInt32(spnBatch.EditValue),
                    IsUsing = chkusing.Checked
                };
                using (var db = new Database(this.ConnString))
                {
                    db.Insert(r);
                    Entity = r;
                    DialogResult = System.Windows.Forms.DialogResult.OK; Close();
                }
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                
                Entity.IsUsing = chkusing.Checked;
                Entity.Updator = CurUser;
                Entity.ProcedureName = txtName.Text;
                Entity.LabourCost = 0;
                Entity.OrderNo = Convert.ToInt32(spnOrder.EditValue);
                Entity.BatchNo = Convert.ToInt32(spnBatch.EditValue);

                using (var db = new Database(this.ConnString))
                {
                    db.Update(Entity);
                    DialogResult = System.Windows.Forms.DialogResult.OK; Close();
                }
            }
        }


    }
}
