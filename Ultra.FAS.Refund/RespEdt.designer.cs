namespace Ultra.FAS.Refund
{
    partial class RespEdt
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.labelTextBox1 = new Ultra.FASControls.LabelTextBox();
            this.checkCtl1 = new FAC.Login.Controls.CheckCtl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(-93, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-182, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(289, 127);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.checkCtl1);
            this.pnlFill.Controls.Add(this.labelTextBox1);
            this.pnlFill.Size = new System.Drawing.Size(289, 81);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 81);
            this.pnlBottom.Size = new System.Drawing.Size(289, 46);
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.LabelText = "责任方";
            this.labelTextBox1.Location = new System.Drawing.Point(12, 12);
            this.labelTextBox1.Name = "labelTextBox1";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelTextBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "责任方", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.labelTextBox1.Size = new System.Drawing.Size(268, 21);
            this.labelTextBox1.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须输入值";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.labelTextBox1, conditionValidationRule1);
            // 
            // checkCtl1
            // 
            this.checkCtl1.EditValue = true;
            this.checkCtl1.Location = new System.Drawing.Point(12, 39);
            this.checkCtl1.Name = "checkCtl1";
            this.checkCtl1.Properties.Caption = "是否启用";
            this.checkCtl1.Size = new System.Drawing.Size(75, 19);
            this.checkCtl1.TabIndex = 1;
            // 
            // RespEdt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(289, 127);
            this.Name = "RespEdt";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.labelTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FAC.Login.Controls.CheckCtl checkCtl1;
        private FASControls.LabelTextBox labelTextBox1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}