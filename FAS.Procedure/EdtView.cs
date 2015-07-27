using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UltraDbEntity;
using Ultra.FASControls;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
namespace FAS.Procedure {
    public partial class EdtView : DialogViewEx {

        public T_ERP_Procedure Entity { get; set; }

        public EdtView() {
            InitializeComponent();
        }

        private void EdtView_Load(object sender, EventArgs e) {
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                txtProcedureName.Text = Entity.ProcedureName;
                chkUsing.Checked = Entity.IsUsing ?? true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (Entity == null)
                Entity = new T_ERP_Procedure { Guid = Guid.NewGuid() };

            Entity.ProcedureName = txtProcedureName.Text;
            Entity.IsUsing = chkUsing.Checked;

            Entity.Creator = Entity.Updator = this.CurUser;
            Entity.Reserved2 = Entity.Remark = string.Empty;

            var m = SerNoCaller.Calr_Procedure.Get(" where ProcedureName=@0 and guid<>@1", Entity.ProcedureName, Entity.Guid);

            if (m.Count > 0) {
                MsgBox.ShowErrMsg("工序名称重复");
                return;
            }

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                SerNoCaller.Calr_Procedure.Edt(Entity);
            } else {
                SerNoCaller.Calr_Procedure.Add(Entity);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
