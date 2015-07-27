namespace FAS.ProduceMater {
    partial class NewProduceMater {
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProduceMater));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtProduceNo = new Ultra.FASControls.LabelTextBox();
            this.txtNum = new Ultra.FASControls.LblSpnEdt();
            this.materEdt = new Ultra.FASControls.BusControls.MaterialGridEdt();
            this.materialGridEdt1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtUseQty = new Ultra.FASControls.LblSpnEdt();
            this.prodEdt = new Ultra.FASControls.BusControls.ProcedureGridEdit();
            this.procedureGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.itemEdt = new Ultra.FASControls.BusControls.ItemGridEdit();
            this.itemGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSkuName = new Ultra.FASControls.LabelTextBox();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProduceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materEdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGridEdt1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodEdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedureGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemEdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(497, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(412, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(347, 256);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.txtSkuName);
            this.pnlFill.Controls.Add(this.itemEdt);
            this.pnlFill.Controls.Add(this.prodEdt);
            this.pnlFill.Controls.Add(this.txtUseQty);
            this.pnlFill.Controls.Add(this.materEdt);
            this.pnlFill.Controls.Add(this.txtNum);
            this.pnlFill.Controls.Add(this.txtProduceNo);
            this.pnlFill.Size = new System.Drawing.Size(347, 210);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 210);
            this.pnlBottom.Size = new System.Drawing.Size(347, 46);
            // 
            // txtProduceNo
            // 
            this.txtProduceNo.LabelText = "生产单号";
            this.txtProduceNo.Location = new System.Drawing.Point(12, 12);
            this.txtProduceNo.Name = "txtProduceNo";
            serializableAppearanceObject10.Options.UseTextOptions = true;
            serializableAppearanceObject10.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtProduceNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "生产单号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "", null, null, true)});
            this.txtProduceNo.Size = new System.Drawing.Size(329, 21);
            this.txtProduceNo.TabIndex = 0;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "必填";
            this.dxValidationProvider1.SetValidationRule(this.txtProduceNo, conditionValidationRule3);
            // 
            // txtNum
            // 
            this.txtNum.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNum.LabelText = "商品数量";
            this.txtNum.Location = new System.Drawing.Point(12, 93);
            this.txtNum.Name = "txtNum";
            serializableAppearanceObject9.Options.UseTextOptions = true;
            serializableAppearanceObject9.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "商品数量", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "", null, null, true)});
            this.txtNum.Size = new System.Drawing.Size(329, 21);
            this.txtNum.TabIndex = 1;
            // 
            // materEdt
            // 
            this.materEdt.ClearButtonText = "清除所选";
            this.materEdt.ColumnCaption = "物料";
            this.materEdt.ColumnItemsEx2 = ((Ultra.FASControls.GridEditColItemExCollection)(resources.GetObject("materEdt.ColumnItemsEx2")));
            this.materEdt.DisplayMember = "MaterialName";
            this.materEdt.EditValue = "";
            this.materEdt.LabelText = "物料";
            this.materEdt.Location = new System.Drawing.Point(12, 147);
            this.materEdt.Name = "materEdt";
            serializableAppearanceObject7.Options.UseTextOptions = true;
            serializableAppearanceObject7.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.materEdt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "物料", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "清除所选", null, null, true)});
            this.materEdt.Properties.DisplayMember = "MaterialName";
            this.materEdt.Properties.ImmediatePopup = true;
            this.materEdt.Properties.NullText = "";
            this.materEdt.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.materEdt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.materEdt.Properties.ValueMember = "Guid";
            this.materEdt.Properties.View = this.materialGridEdt1View;
            this.materEdt.SelectedValue = null;
            this.materEdt.ShowClearButton = true;
            this.materEdt.Size = new System.Drawing.Size(329, 21);
            this.materEdt.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "必填";
            this.dxValidationProvider1.SetValidationRule(this.materEdt, conditionValidationRule2);
            this.materEdt.ValueMember = "Guid";
            // 
            // materialGridEdt1View
            // 
            this.materialGridEdt1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.materialGridEdt1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.materialGridEdt1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.materialGridEdt1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.materialGridEdt1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.materialGridEdt1View.Name = "materialGridEdt1View";
            this.materialGridEdt1View.OptionsBehavior.AutoPopulateColumns = false;
            this.materialGridEdt1View.OptionsBehavior.Editable = false;
            this.materialGridEdt1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.materialGridEdt1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtUseQty
            // 
            this.txtUseQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUseQty.LabelText = "用量";
            this.txtUseQty.Location = new System.Drawing.Point(12, 174);
            this.txtUseQty.Name = "txtUseQty";
            serializableAppearanceObject6.Options.UseTextOptions = true;
            serializableAppearanceObject6.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUseQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "用量", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtUseQty.Size = new System.Drawing.Size(329, 21);
            this.txtUseQty.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必填";
            this.dxValidationProvider1.SetValidationRule(this.txtUseQty, conditionValidationRule1);
            // 
            // prodEdt
            // 
            this.prodEdt.ClearButtonText = "清除所选";
            this.prodEdt.ColumnCaption = "工序";
            this.prodEdt.ColumnItemsEx2 = ((Ultra.FASControls.GridEditColItemExCollection)(resources.GetObject("prodEdt.ColumnItemsEx2")));
            this.prodEdt.DisplayMember = "ProcedureName";
            this.prodEdt.EditValue = "";
            this.prodEdt.LabelText = "工序";
            this.prodEdt.Location = new System.Drawing.Point(12, 120);
            this.prodEdt.Name = "prodEdt";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.prodEdt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "工序", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "清除所选", null, null, true)});
            this.prodEdt.Properties.DisplayMember = "ProcedureName";
            this.prodEdt.Properties.ImmediatePopup = true;
            this.prodEdt.Properties.NullText = "";
            this.prodEdt.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.prodEdt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.prodEdt.Properties.ValueMember = "Guid";
            this.prodEdt.Properties.View = this.procedureGridEdit1View;
            this.prodEdt.SelectedValue = null;
            this.prodEdt.ShowClearButton = true;
            this.prodEdt.Size = new System.Drawing.Size(329, 21);
            this.prodEdt.TabIndex = 4;
            this.prodEdt.ValueMember = "Guid";
            // 
            // procedureGridEdit1View
            // 
            this.procedureGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.procedureGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.procedureGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.procedureGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.procedureGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.procedureGridEdit1View.Name = "procedureGridEdit1View";
            this.procedureGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.procedureGridEdit1View.OptionsBehavior.Editable = false;
            this.procedureGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.procedureGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // itemEdt
            // 
            this.itemEdt.ClearButtonText = "清除所选";
            this.itemEdt.ColumnCaption = null;
            this.itemEdt.ColumnItemsEx2 = ((Ultra.FASControls.GridEditColItemExCollection)(resources.GetObject("itemEdt.ColumnItemsEx2")));
            this.itemEdt.DisplayMember = "OuterIid";
            this.itemEdt.EditValue = "";
            this.itemEdt.LabelText = "商品";
            this.itemEdt.Location = new System.Drawing.Point(12, 39);
            this.itemEdt.Name = "itemEdt";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.itemEdt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "商品", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "清除所选", null, null, true)});
            this.itemEdt.Properties.DisplayMember = "OuterIid";
            this.itemEdt.Properties.ImmediatePopup = true;
            this.itemEdt.Properties.NullText = "";
            this.itemEdt.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.itemEdt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.itemEdt.Properties.ValueMember = "Guid";
            this.itemEdt.Properties.View = this.itemGridEdit1View;
            this.itemEdt.SelectedValue = null;
            this.itemEdt.ShowClearButton = true;
            this.itemEdt.Size = new System.Drawing.Size(329, 21);
            this.itemEdt.TabIndex = 5;
            this.itemEdt.ValueMember = "Guid";
            this.itemEdt.EditValueChanged += new System.EventHandler(this.itemEdt_EditValueChanged);
            // 
            // itemGridEdit1View
            // 
            this.itemGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.itemGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.itemGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.itemGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.itemGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.itemGridEdit1View.Name = "itemGridEdit1View";
            this.itemGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.itemGridEdit1View.OptionsBehavior.Editable = false;
            this.itemGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.itemGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtSkuName
            // 
            this.txtSkuName.LabelText = "规格";
            this.txtSkuName.Location = new System.Drawing.Point(12, 66);
            this.txtSkuName.Name = "txtSkuName";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSkuName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "规格", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtSkuName.Properties.ReadOnly = true;
            this.txtSkuName.Size = new System.Drawing.Size(329, 21);
            this.txtSkuName.TabIndex = 6;
            // 
            // NewProduceMater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 256);
            this.Name = "NewProduceMater";
            this.Text = "新增";
            this.Load += new System.EventHandler(this.NewProduceMater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProduceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materEdt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGridEdt1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodEdt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedureGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemEdt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ultra.FASControls.LabelTextBox txtProduceNo;
        private Ultra.FASControls.BusControls.MaterialGridEdt materEdt;
        private DevExpress.XtraGrid.Views.Grid.GridView materialGridEdt1View;
        private Ultra.FASControls.LblSpnEdt txtNum;
        private Ultra.FASControls.BusControls.ProcedureGridEdit prodEdt;
        private DevExpress.XtraGrid.Views.Grid.GridView procedureGridEdit1View;
        private Ultra.FASControls.LblSpnEdt txtUseQty;
        private Ultra.FASControls.LabelTextBox txtSkuName;
        private Ultra.FASControls.BusControls.ItemGridEdit itemEdt;
        private DevExpress.XtraGrid.Views.Grid.GridView itemGridEdit1View;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}