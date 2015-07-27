namespace FAS.Material {
    partial class EdtView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdtView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txtMaterialNo = new Ultra.FASControls.LabelTextBox();
            this.txtMaterialName = new Ultra.FASControls.LabelTextBox();
            this.txtUnit = new Ultra.FASControls.LabelTextBox();
            this.txtSuppName = new Ultra.FASControls.BusControls.SuppliersGridEdt();
            this.suppliersGridEdt1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.txtSafeQty = new Ultra.FASControls.LblSpnEdt();
            this.chkUsing = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuppName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersGridEdt1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSafeQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(-433, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-518, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(257, 226);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.txtSafeQty);
            this.pnlFill.Controls.Add(this.chkUsing);
            this.pnlFill.Controls.Add(this.txtSuppName);
            this.pnlFill.Controls.Add(this.txtUnit);
            this.pnlFill.Controls.Add(this.txtMaterialName);
            this.pnlFill.Controls.Add(this.txtMaterialNo);
            this.pnlFill.Size = new System.Drawing.Size(257, 180);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 180);
            this.pnlBottom.Size = new System.Drawing.Size(257, 46);
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.LabelText = "物料编码";
            this.txtMaterialNo.Location = new System.Drawing.Point(12, 12);
            this.txtMaterialNo.Name = "txtMaterialNo";
            serializableAppearanceObject6.Options.UseTextOptions = true;
            serializableAppearanceObject6.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtMaterialNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "物料编码", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtMaterialNo.Size = new System.Drawing.Size(236, 21);
            this.txtMaterialNo.TabIndex = 0;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "必填";
            this.dxValidationProvider1.SetValidationRule(this.txtMaterialNo, conditionValidationRule3);
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.LabelText = "物料名称";
            this.txtMaterialName.Location = new System.Drawing.Point(12, 39);
            this.txtMaterialName.Name = "txtMaterialName";
            serializableAppearanceObject5.Options.UseTextOptions = true;
            serializableAppearanceObject5.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtMaterialName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "物料名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.txtMaterialName.Size = new System.Drawing.Size(236, 21);
            this.txtMaterialName.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "必填";
            this.dxValidationProvider1.SetValidationRule(this.txtMaterialName, conditionValidationRule2);
            // 
            // txtUnit
            // 
            this.txtUnit.LabelText = "单位";
            this.txtUnit.Location = new System.Drawing.Point(12, 67);
            this.txtUnit.Name = "txtUnit";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "单位", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtUnit.Size = new System.Drawing.Size(236, 21);
            this.txtUnit.TabIndex = 2;
            // 
            // txtSuppName
            // 
            this.txtSuppName.ClearButtonText = "清除所选";
            this.txtSuppName.ColumnCaption = "供应商";
            this.txtSuppName.ColumnItemsEx2 = ((Ultra.FASControls.GridEditColItemExCollection)(resources.GetObject("txtSuppName.ColumnItemsEx2")));
            this.txtSuppName.DisplayMember = "SuppName";
            this.txtSuppName.EditValue = "";
            this.txtSuppName.LabelText = "供应商";
            this.txtSuppName.Location = new System.Drawing.Point(12, 94);
            this.txtSuppName.Name = "txtSuppName";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSuppName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "供应商", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "清除所选", null, null, true)});
            this.txtSuppName.Properties.DisplayMember = "SuppName";
            this.txtSuppName.Properties.ImmediatePopup = true;
            this.txtSuppName.Properties.NullText = "";
            this.txtSuppName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtSuppName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtSuppName.Properties.ValueMember = "Guid";
            this.txtSuppName.Properties.View = this.suppliersGridEdt1View;
            this.txtSuppName.SelectedValue = null;
            this.txtSuppName.Size = new System.Drawing.Size(236, 21);
            this.txtSuppName.TabIndex = 5;
            this.txtSuppName.ValueMember = "Guid";
            // 
            // suppliersGridEdt1View
            // 
            this.suppliersGridEdt1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.suppliersGridEdt1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.suppliersGridEdt1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.suppliersGridEdt1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.suppliersGridEdt1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.suppliersGridEdt1View.Name = "suppliersGridEdt1View";
            this.suppliersGridEdt1View.OptionsBehavior.AutoPopulateColumns = false;
            this.suppliersGridEdt1View.OptionsBehavior.Editable = false;
            this.suppliersGridEdt1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.suppliersGridEdt1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtSafeQty
            // 
            this.txtSafeQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSafeQty.LabelText = "安全库存";
            this.txtSafeQty.Location = new System.Drawing.Point(12, 121);
            this.txtSafeQty.Name = "txtSafeQty";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSafeQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "安全库存", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtSafeQty.Size = new System.Drawing.Size(236, 21);
            this.txtSafeQty.TabIndex = 7;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule1.ErrorText = "不能小于0";
            conditionValidationRule1.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.txtSafeQty, conditionValidationRule1);
            this.txtSafeQty.Validating += new System.ComponentModel.CancelEventHandler(this.txtSafeQty_Validating);
            // 
            // chkUsing
            // 
            this.chkUsing.EditValue = true;
            this.chkUsing.Location = new System.Drawing.Point(201, 148);
            this.chkUsing.Name = "chkUsing";
            this.chkUsing.Properties.Caption = "启用";
            this.chkUsing.Size = new System.Drawing.Size(47, 19);
            this.chkUsing.TabIndex = 6;
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 226);
            this.Name = "EdtView";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuppName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersGridEdt1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSafeQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ultra.FASControls.LabelTextBox txtUnit;
        private Ultra.FASControls.LabelTextBox txtMaterialName;
        private Ultra.FASControls.LabelTextBox txtMaterialNo;
        private Ultra.FASControls.BusControls.SuppliersGridEdt txtSuppName;
        private DevExpress.XtraGrid.Views.Grid.GridView suppliersGridEdt1View;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.CheckEdit chkUsing;
        private Ultra.FASControls.LblSpnEdt txtSafeQty;
    }
}