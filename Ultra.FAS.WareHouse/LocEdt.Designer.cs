namespace Ultra.FAS.WareHouse
{
    partial class LocEdt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.checkCtl2 = new FAC.Login.Controls.CheckCtl();
            this.checkCtl1 = new FAC.Login.Controls.CheckCtl();
            this.textName = new Ultra.FASControls.LabelTextBox();
            this.textCode = new Ultra.FASControls.LabelTextBox();
            this.areaEdtGridEdit1 = new Ultra.FASControls.BusControls.AreaEdtGridEdit();
            this.areaEdtGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelGridEditColItemEx1 = new Ultra.FASControls.LabelGridEditColItemEx();
            this.labelGridEditColItemEx2 = new Ultra.FASControls.LabelGridEditColItemEx();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaEdtGridEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaEdtGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(217, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(132, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(366, 200);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.areaEdtGridEdit1);
            this.pnlFill.Controls.Add(this.checkCtl2);
            this.pnlFill.Controls.Add(this.checkCtl1);
            this.pnlFill.Controls.Add(this.textName);
            this.pnlFill.Controls.Add(this.textCode);
            this.pnlFill.Size = new System.Drawing.Size(366, 154);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 154);
            this.pnlBottom.Size = new System.Drawing.Size(366, 46);
            // 
            // checkCtl2
            // 
            this.checkCtl2.EditValue = true;
            this.checkCtl2.Location = new System.Drawing.Point(12, 118);
            this.checkCtl2.Name = "checkCtl2";
            this.checkCtl2.Properties.Caption = "启用";
            this.checkCtl2.Size = new System.Drawing.Size(75, 19);
            this.checkCtl2.TabIndex = 3;
            // 
            // checkCtl1
            // 
            this.checkCtl1.Location = new System.Drawing.Point(12, 93);
            this.checkCtl1.Name = "checkCtl1";
            this.checkCtl1.Properties.Caption = "默认";
            this.checkCtl1.Size = new System.Drawing.Size(75, 19);
            this.checkCtl1.TabIndex = 3;
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.LabelText = "库位名称";
            this.textName.Location = new System.Drawing.Point(12, 39);
            this.textName.Name = "textName";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "库位名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.textName.Size = new System.Drawing.Size(345, 21);
            this.textName.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "必需输入";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.textName, conditionValidationRule2);
            // 
            // textCode
            // 
            this.textCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCode.LabelText = "库位代码";
            this.textCode.Location = new System.Drawing.Point(12, 12);
            this.textCode.Name = "textCode";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "库位代码", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.textCode.Size = new System.Drawing.Size(345, 21);
            this.textCode.TabIndex = 0;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "必须输入";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.textCode, conditionValidationRule3);
            // 
            // areaEdtGridEdit1
            // 
            this.areaEdtGridEdit1.ClearButtonText = "清除所选";
            this.areaEdtGridEdit1.ColumnCaption = "区域";
            this.areaEdtGridEdit1.ColumnItemsEx.Add(this.labelGridEditColItemEx1);
            this.areaEdtGridEdit1.ColumnItemsEx.Add(this.labelGridEditColItemEx2);
            this.areaEdtGridEdit1.DisplayMember = "AreaName";
            this.areaEdtGridEdit1.EditValue = "";
            this.areaEdtGridEdit1.LabelText = "所属区域";
            this.areaEdtGridEdit1.Location = new System.Drawing.Point(14, 67);
            this.areaEdtGridEdit1.Name = "areaEdtGridEdit1";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.areaEdtGridEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "所属区域", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "清除所选", null, null, true)});
            this.areaEdtGridEdit1.Properties.DisplayMember = "AreaName";
            this.areaEdtGridEdit1.Properties.NullText = "";
            this.areaEdtGridEdit1.Properties.ValueMember = "Guid";
            this.areaEdtGridEdit1.Properties.View = this.areaEdtGridEdit1View;
            this.areaEdtGridEdit1.SelectedValue = null;
            this.areaEdtGridEdit1.Size = new System.Drawing.Size(343, 21);
            this.areaEdtGridEdit1.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必需选择";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.areaEdtGridEdit1, conditionValidationRule1);
            this.areaEdtGridEdit1.ValueMember = "Guid";
            // 
            // areaEdtGridEdit1View
            // 
            this.areaEdtGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.areaEdtGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.areaEdtGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.areaEdtGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.areaEdtGridEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.areaEdtGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.areaEdtGridEdit1View.Name = "areaEdtGridEdit1View";
            this.areaEdtGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.areaEdtGridEdit1View.OptionsBehavior.Editable = false;
            this.areaEdtGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.areaEdtGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "区域";
            this.gridColumn1.FieldName = "AreaName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "仓库";
            this.gridColumn2.FieldName = "WareName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // labelGridEditColItemEx1
            // 
            this.labelGridEditColItemEx1.Caption = "区域";
            this.labelGridEditColItemEx1.FieldName = "AreaName";
            // 
            // labelGridEditColItemEx2
            // 
            this.labelGridEditColItemEx2.Caption = "仓库";
            this.labelGridEditColItemEx2.FieldName = "WareName";
            // 
            // LocEdt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 200);
            this.Name = "LocEdt";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.LocEdt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaEdtGridEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaEdtGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl checkCtl2;
        private FAC.Login.Controls.CheckCtl checkCtl1;
        private FASControls.LabelTextBox textName;
        private FASControls.LabelTextBox textCode;
        private FASControls.BusControls.AreaEdtGridEdit areaEdtGridEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView areaEdtGridEdit1View;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private FASControls.LabelGridEditColItemEx labelGridEditColItemEx1;
        private FASControls.LabelGridEditColItemEx labelGridEditColItemEx2;
    }
}