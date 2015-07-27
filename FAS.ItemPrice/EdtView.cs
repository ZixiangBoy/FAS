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

namespace FAS.ItemPrice {
    public partial class EdtView : DialogViewEx {

        public T_ERP_ItemPrice Entity { get; set; }

        public EdtView() {
            InitializeComponent();
        }

        private void EdtView_Load(object sender, EventArgs e) {
            var items = itemGridEdit1.LoadFromCache();
            var trdmarks = tradeMarkGridEdt1.LoadFromCache();
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                var item = items.FirstOrDefault(k => k.OuterIid == Entity.OuterIid && k.OuterSkuId==Entity.OuterSkuId);
                itemGridEdit1.SetSelectedValue(item);
                txtOuterSkuId.Text =item==null ? "" : item.OuterSkuId;
                var mark = trdmarks.FirstOrDefault(k => k.TradeMark == Entity.TradeMark);
                tradeMarkGridEdt1.SetSelectedValue(mark);
                txtSurfacePrice.Value = Entity.SurfacePrice;
                txtGenSurfacePrice.Value = Entity.GenSurfacePrice;
                txtEnvSurfacePrice.Value = Entity.EnvSurfacePrice;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate()) return;

            if (Entity == null)
                Entity = new T_ERP_ItemPrice { Guid = Guid.NewGuid() };

            var item = itemGridEdit1.GetSelectedValue();
            var mark = tradeMarkGridEdt1.GetSelectedValue();

            Entity.OuterIid = item.OuterIid;
            Entity.OuterSkuId = item.OuterSkuId;
            Entity.TradeMark = mark.TradeMark;
            Entity.SurfacePrice = txtSurfacePrice.Value;
            Entity.GenSurfacePrice = txtGenSurfacePrice.Value;
            Entity.EnvSurfacePrice = txtEnvSurfacePrice.Value;

            Entity.Creator = Entity.Updator = this.CurUser;
            Entity.Reserved2 = Entity.Remark = string.Empty;

            var m=SerNoCaller.Calr_ItemPrice.Get(" where OuterIid=@0 and OuterSkuId=@1 and trademark=@2 and guid<>@3",Entity.OuterIid,Entity.OuterSkuId,Entity.TradeMark,Entity.Guid);

            if (m.Count > 0) {
                MsgBox.ShowErrMsg("物料名称或编码有重复");
                return;
            }

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit) {
                SerNoCaller.Calr_ItemPrice.Edt(Entity);
            } else {
                SerNoCaller.Calr_ItemPrice.Add(Entity);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void txtSafeQty_Validating(object sender, CancelEventArgs e) {
            if (txtSurfacePrice.Value < 0) {
                e.Cancel = true;
            }
        }

        private void itemGridEdit1_EditValueChanged(object sender, EventArgs e) {
            var item = itemGridEdit1.GetSelectedValue();
            if (item != null) txtOuterSkuId.Text = item.OuterSkuId;
        }
    }
}
