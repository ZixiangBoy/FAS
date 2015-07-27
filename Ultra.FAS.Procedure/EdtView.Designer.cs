namespace Ultra.FAS.Procedure
{
    partial class EdtView
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.chkusing = new FAC.Login.Controls.CheckCtl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.txtName = new Ultra.FASControls.LabelTextBox();
            this.spnOrder = new Ultra.FASControls.LblSpnEdt();
            this.spnBatch = new Ultra.FASControls.LblSpnEdt();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkusing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnBatch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(455, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(370, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(406, 139);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.spnBatch);
            this.pnlFill.Controls.Add(this.spnOrder);
            this.pnlFill.Controls.Add(this.txtName);
            this.pnlFill.Controls.Add(this.chkusing);
            this.pnlFill.Size = new System.Drawing.Size(406, 93);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 93);
            this.pnlBottom.Size = new System.Drawing.Size(406, 46);
            // 
            // chkusing
            // 
            this.chkusing.EditValue = true;
            this.chkusing.Location = new System.Drawing.Point(12, 66);
            this.chkusing.Name = "chkusing";
            this.chkusing.Properties.Caption = "启用";
            this.chkusing.Size = new System.Drawing.Size(75, 19);
            this.chkusing.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.LabelText = "工序名称";
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "工序名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtName.Size = new System.Drawing.Size(374, 21);
            this.txtName.TabIndex = 9;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "必须填写";
            this.dxValidationProvider1.SetValidationRule(this.txtName, conditionValidationRule3);
            // 
            // spnOrder
            // 
            this.spnOrder.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnOrder.LabelText = "序号";
            this.spnOrder.Location = new System.Drawing.Point(12, 39);
            this.spnOrder.Name = "spnOrder";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spnOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "序号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.spnOrder.Size = new System.Drawing.Size(186, 21);
            this.spnOrder.TabIndex = 11;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule2.ErrorText = "不能小于0";
            conditionValidationRule2.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.spnOrder, conditionValidationRule2);
            // 
            // spnBatch
            // 
            this.spnBatch.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnBatch.LabelText = "批号";
            this.spnBatch.Location = new System.Drawing.Point(204, 40);
            this.spnBatch.Name = "spnBatch";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spnBatch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "批号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.spnBatch.Size = new System.Drawing.Size(181, 21);
            this.spnBatch.TabIndex = 12;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule1.ErrorText = "不能小于0";
            conditionValidationRule1.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.spnBatch, conditionValidationRule1);
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 139);
            this.Name = "EdtView";
            this.Text = "工序信息";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkusing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnBatch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl chkusing;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private FASControls.LblSpnEdt spnBatch;
        private FASControls.LblSpnEdt spnOrder;
        private FASControls.LabelTextBox txtName;
    }
}