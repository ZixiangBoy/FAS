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

namespace FAS.Material {
    public partial class EdtView : DialogViewEx {

        public T_ERP_Material Entity { get; set; }

        public EdtView() {
            InitializeComponent();
        }

        private void EdtView_Load(object sender, EventArgs e) {
            var supps=txtSuppName.LoadData();

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                txtMaterialNo.Properties.ReadOnly =txtMaterialName.Properties.ReadOnly= true;

                txtMaterialNo.Text = Entity.MaterialNo;
                txtMaterialName.Text = Entity.MaterialName;
                //txtCostPrice.Value = Entity.CostPrice ?? 0;
                txtUnit.Text = Entity.Unit;
                var supp=supps.FirstOrDefault(k=>k.SuppName==Entity.SuppName);
                txtSuppName.EditValue =supp==null ? Guid.Empty : supp.Guid ;
                chkUsing.Checked = Entity.IsUsing;
                txtSafeQty.Value = Entity.SafeQty;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate()) return;

            if (Entity == null)
                Entity = new T_ERP_Material { Guid = Guid.NewGuid() };

            Entity.MaterialNo = txtMaterialNo.Text;
            Entity.MaterialName = txtMaterialName.Text;
            Entity.Unit = txtUnit.Text;
            Entity.CostPrice = 0;
            var s=txtSuppName.GetSelectedValue();
            Entity.SuppName = s==null ? string.Empty : s.SuppName;
            Entity.IsUsing = chkUsing.Checked;
            Entity.SafeQty = (int)txtSafeQty.Value;

            Entity.Creator = Entity.Updator = this.CurUser;
            Entity.Reserved2 = Entity.Remark = string.Empty;

            var m=SerNoCaller.Calr_Material.Get(" where (MaterialNo=@0 or MaterialName=@1) and guid<>@2",Entity.MaterialNo,Entity.MaterialName,Entity.Guid);

            if (m.Count > 0) {
                MsgBox.ShowErrMsg("物料名称或编码有重复");
                return;
            }

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                SerNoCaller.Calr_Material.Edt(Entity);
            } else {
                SerNoCaller.Calr_Material.Add(Entity);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void txtSafeQty_Validating(object sender, CancelEventArgs e) {
            if (txtSafeQty.Value < 0) {
                e.Cancel = true;
            }
        }
    }
}
