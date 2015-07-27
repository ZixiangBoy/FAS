namespace Ultra.FAS.Login
{
    partial class ChgPwdView
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtcur = new Ultra.FASControls.LabelTextBox();
            this.txtoldpwd = new Ultra.FASControls.LabelTextBox();
            this.txtnewpwd = new Ultra.FASControls.LabelTextBox();
            this.txtrenewpwd = new Ultra.FASControls.LabelTextBox();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtoldpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnewpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrenewpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(211, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(112, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(239, 160);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.txtrenewpwd);
            this.pnlFill.Controls.Add(this.txtnewpwd);
            this.pnlFill.Controls.Add(this.txtoldpwd);
            this.pnlFill.Controls.Add(this.txtcur);
            this.pnlFill.Size = new System.Drawing.Size(239, 114);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 114);
            this.pnlBottom.Size = new System.Drawing.Size(239, 46);
            // 
            // txtcur
            // 
            this.txtcur.LabelText = "当前用户";
            this.txtcur.Location = new System.Drawing.Point(12, 5);
            this.txtcur.Name = "txtcur";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtcur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "当前用户", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtcur.Properties.ReadOnly = true;
            this.txtcur.Size = new System.Drawing.Size(214, 21);
            this.txtcur.TabIndex = 0;
            // 
            // txtoldpwd
            // 
            this.txtoldpwd.LabelText = "当前密码";
            this.txtoldpwd.Location = new System.Drawing.Point(12, 32);
            this.txtoldpwd.Name = "txtoldpwd";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtoldpwd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "当前密码", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtoldpwd.Size = new System.Drawing.Size(214, 21);
            this.txtoldpwd.TabIndex = 1;
            // 
            // txtnewpwd
            // 
            this.txtnewpwd.LabelText = "新密码";
            this.txtnewpwd.Location = new System.Drawing.Point(12, 59);
            this.txtnewpwd.Name = "txtnewpwd";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtnewpwd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "新密码", 60, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtnewpwd.Size = new System.Drawing.Size(214, 21);
            this.txtnewpwd.TabIndex = 2;
            compareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Equals;
            compareAgainstControlValidationRule1.Control = this.txtrenewpwd;
            compareAgainstControlValidationRule1.ErrorText = "两次输入的密码不一致";
            compareAgainstControlValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtnewpwd, compareAgainstControlValidationRule1);
            // 
            // txtrenewpwd
            // 
            this.txtrenewpwd.LabelText = "重复新密码";
            this.txtrenewpwd.Location = new System.Drawing.Point(12, 85);
            this.txtrenewpwd.Name = "txtrenewpwd";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtrenewpwd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "重复新密码", 60, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtrenewpwd.Size = new System.Drawing.Size(214, 21);
            this.txtrenewpwd.TabIndex = 3;
            // 
            // ChgPwdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 160);
            this.Name = "ChgPwdView";
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.ChgPwdView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtcur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtoldpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnewpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrenewpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ultra.FASControls.LabelTextBox txtrenewpwd;
        private Ultra.FASControls.LabelTextBox txtnewpwd;
        private Ultra.FASControls.LabelTextBox txtoldpwd;
        private Ultra.FASControls.LabelTextBox txtcur;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}