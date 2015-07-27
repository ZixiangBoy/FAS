namespace Ultra.FAS.WareHouse
{
    partial class AreaEdt
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txtcode = new Ultra.FASControls.LabelTextBox();
            this.txtname = new Ultra.FASControls.LabelTextBox();
            this.checkCtl1 = new FAC.Login.Controls.CheckCtl();
            this.chkUsing = new FAC.Login.Controls.CheckCtl();
            this.wareHouseGridEdit1 = new Ultra.FASControls.BusControls.WareHouseGridEdit();
            this.wareHouseGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareHouseGridEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareHouseGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(201, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(116, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(370, 198);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.wareHouseGridEdit1);
            this.pnlFill.Controls.Add(this.chkUsing);
            this.pnlFill.Controls.Add(this.checkCtl1);
            this.pnlFill.Controls.Add(this.txtname);
            this.pnlFill.Controls.Add(this.txtcode);
            this.pnlFill.Size = new System.Drawing.Size(370, 152);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 152);
            this.pnlBottom.Size = new System.Drawing.Size(370, 46);
            // 
            // txtcode
            // 
            this.txtcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcode.LabelText = "区域代码";
            this.txtcode.Location = new System.Drawing.Point(12, 12);
            this.txtcode.Name = "txtcode";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "区域代码", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtcode.Size = new System.Drawing.Size(345, 21);
            this.txtcode.TabIndex = 0;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "必须输入";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtcode, conditionValidationRule3);
            // 
            // txtname
            // 
            this.txtname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtname.LabelText = "区域名称";
            this.txtname.Location = new System.Drawing.Point(12, 39);
            this.txtname.Name = "txtname";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "区域名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtname.Size = new System.Drawing.Size(345, 21);
            this.txtname.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "必须输入";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtname, conditionValidationRule2);
            // 
            // checkCtl1
            // 
            this.checkCtl1.Location = new System.Drawing.Point(12, 93);
            this.checkCtl1.Name = "checkCtl1";
            this.checkCtl1.Properties.Caption = "默认";
            this.checkCtl1.Size = new System.Drawing.Size(75, 19);
            this.checkCtl1.TabIndex = 3;
           
            // 
            // chkUsing
            // 
            this.chkUsing.EditValue = true;
            this.chkUsing.Location = new System.Drawing.Point(12, 118);
            this.chkUsing.Name = "chkUsing";
            this.chkUsing.Properties.Caption = "是否启用";
            this.chkUsing.Size = new System.Drawing.Size(75, 19);
            this.chkUsing.TabIndex = 3;
            // 
            // wareHouseGridEdit1
            // 
            this.wareHouseGridEdit1.ClearButtonText = "清除所选";
            this.wareHouseGridEdit1.ColumnCaption = "仓库";
            this.wareHouseGridEdit1.DisplayMember = "WareName";
            this.wareHouseGridEdit1.EditValue = "";
            this.wareHouseGridEdit1.LabelText = "仓库";
            this.wareHouseGridEdit1.Location = new System.Drawing.Point(14, 67);
            this.wareHouseGridEdit1.Name = "wareHouseGridEdit1";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.wareHouseGridEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "仓库", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "清除所选", null, null, true)});
            this.wareHouseGridEdit1.Properties.DisplayMember = "WareName";
            this.wareHouseGridEdit1.Properties.NullText = "";
            this.wareHouseGridEdit1.Properties.ValueMember = "Guid";
            this.wareHouseGridEdit1.Properties.View = this.wareHouseGridEdit1View;
            this.wareHouseGridEdit1.SelectedValue = null;
            this.wareHouseGridEdit1.Size = new System.Drawing.Size(343, 21);
            this.wareHouseGridEdit1.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须输入";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.wareHouseGridEdit1, conditionValidationRule1);
            this.wareHouseGridEdit1.ValueMember = "Guid";
            // 
            // wareHouseGridEdit1View
            // 
            this.wareHouseGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.wareHouseGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.wareHouseGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.wareHouseGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.wareHouseGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wareHouseGridEdit1View.Name = "wareHouseGridEdit1View";
            this.wareHouseGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.wareHouseGridEdit1View.OptionsBehavior.Editable = false;
            this.wareHouseGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wareHouseGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // AreaEdt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 198);
            this.Name = "AreaEdt";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.AreaEdt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareHouseGridEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareHouseGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl chkUsing;
        private FAC.Login.Controls.CheckCtl checkCtl1;
        private FASControls.LabelTextBox txtname;
        private FASControls.LabelTextBox txtcode;
        private FASControls.BusControls.WareHouseGridEdit wareHouseGridEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView wareHouseGridEdit1View;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}