using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.FASControls;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using UltraDbEntity;

namespace FAS.Company {
    public partial class EdtView : DialogViewEx {

        public T_ERP_Company Entity { get; set; }

        public EdtView() {
            InitializeComponent();
        }

        private void EdtView_Load(object sender, EventArgs e) {

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {

                txtCompanyName.Text = Entity.CompanyName;
                txtCompanyMobile.Text = Entity.CompanyMobile;
                txtCompanyAddress.Text = Entity.CompanyAddress;
                chkUsing.Checked = Entity.IsUsing;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate()) return;

            if (Entity == null)
                Entity = new T_ERP_Company { Guid = Guid.NewGuid() };

            Entity.CompanyName = txtCompanyName.Text;
            Entity.CompanyMobile = txtCompanyMobile.Text;
            Entity.CompanyAddress = txtCompanyAddress.Text;
            Entity.IsUsing = chkUsing.Checked;

            Entity.Creator = Entity.Updator = this.CurUser;
            Entity.Reserved2 = Entity.Remark = string.Empty;

            var m=SerNoCaller.Calr_Company.Get(" where CompanyName=@0 and guid<>@1",Entity.CompanyName,Entity.Guid);

            if (m.Count > 0) {
                MsgBox.ShowErrMsg("公司名称有重复");
                return;
            }

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                SerNoCaller.Calr_Company.Edt(Entity);
            } else {
                SerNoCaller.Calr_Company.Add(Entity);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e) {

        }
    }
}
