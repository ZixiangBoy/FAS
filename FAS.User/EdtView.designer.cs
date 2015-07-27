namespace FAS.User
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.chkusing = new FAC.Login.Controls.CheckCtl();
            this.txtWorkAccount = new Ultra.FASControls.LabelTextBox();
            this.txtjobnum = new Ultra.FASControls.LabelTextBox();
            this.txtrealname = new Ultra.FASControls.LabelTextBox();
            this.txtrepwd = new Ultra.FASControls.LabelTextBox();
            this.txtpwd = new Ultra.FASControls.LabelTextBox();
            this.txtusername = new Ultra.FASControls.LabelTextBox();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.txtmobile = new Ultra.FASControls.LabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkusing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtjobnum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrealname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrepwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmobile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(323, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(238, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(401, 269);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.txtmobile);
            this.pnlFill.Controls.Add(this.chkusing);
            this.pnlFill.Controls.Add(this.txtWorkAccount);
            this.pnlFill.Controls.Add(this.txtjobnum);
            this.pnlFill.Controls.Add(this.txtrealname);
            this.pnlFill.Controls.Add(this.txtrepwd);
            this.pnlFill.Controls.Add(this.txtpwd);
            this.pnlFill.Controls.Add(this.txtusername);
            this.pnlFill.Size = new System.Drawing.Size(401, 223);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 223);
            this.pnlBottom.Size = new System.Drawing.Size(401, 46);
            // 
            // chkusing
            // 
            this.chkusing.EditValue = true;
            this.chkusing.Location = new System.Drawing.Point(12, 202);
            this.chkusing.Name = "chkusing";
            this.chkusing.Properties.Caption = "启用";
            this.chkusing.Size = new System.Drawing.Size(75, 19);
            this.chkusing.TabIndex = 8;
            // 
            // txtWorkAccount
            // 
            this.txtWorkAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkAccount.LabelText = "昵称";
            this.txtWorkAccount.Location = new System.Drawing.Point(12, 147);
            this.txtWorkAccount.Name = "txtWorkAccount";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtWorkAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "昵称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtWorkAccount.Size = new System.Drawing.Size(380, 21);
            this.txtWorkAccount.TabIndex = 5;
            // 
            // txtjobnum
            // 
            this.txtjobnum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtjobnum.LabelText = "工号";
            this.txtjobnum.Location = new System.Drawing.Point(12, 120);
            this.txtjobnum.Name = "txtjobnum";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtjobnum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "工号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtjobnum.Size = new System.Drawing.Size(380, 21);
            this.txtjobnum.TabIndex = 4;
            // 
            // txtrealname
            // 
            this.txtrealname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrealname.LabelText = "姓名";
            this.txtrealname.Location = new System.Drawing.Point(12, 93);
            this.txtrealname.Name = "txtrealname";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtrealname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "姓名", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtrealname.Size = new System.Drawing.Size(380, 21);
            this.txtrealname.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须填写";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtrealname, conditionValidationRule1);
            // 
            // txtrepwd
            // 
            this.txtrepwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrepwd.LabelText = "确认密码";
            this.txtrepwd.Location = new System.Drawing.Point(12, 66);
            this.txtrepwd.Name = "txtrepwd";
            serializableAppearanceObject5.Options.UseTextOptions = true;
            serializableAppearanceObject5.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtrepwd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "确认密码", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.txtrepwd.Properties.PasswordChar = '*';
            this.txtrepwd.Size = new System.Drawing.Size(380, 21);
            this.txtrepwd.TabIndex = 2;
            // 
            // txtpwd
            // 
            this.txtpwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpwd.LabelText = "密码";
            this.txtpwd.Location = new System.Drawing.Point(12, 39);
            this.txtpwd.Name = "txtpwd";
            serializableAppearanceObject6.Options.UseTextOptions = true;
            serializableAppearanceObject6.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtpwd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "密码", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtpwd.Properties.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(380, 21);
            this.txtpwd.TabIndex = 1;
            // 
            // txtusername
            // 
            this.txtusername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtusername.LabelText = "账号";
            this.txtusername.Location = new System.Drawing.Point(12, 12);
            this.txtusername.Name = "txtusername";
            serializableAppearanceObject7.Options.UseTextOptions = true;
            serializableAppearanceObject7.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtusername.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "账号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.txtusername.Size = new System.Drawing.Size(380, 21);
            this.txtusername.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "必须填写";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtusername, conditionValidationRule2);
            // 
            // txtmobile
            // 
            this.txtmobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmobile.LabelText = "手机";
            this.txtmobile.Location = new System.Drawing.Point(12, 175);
            this.txtmobile.Name = "txtmobile";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtmobile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "手机", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtmobile.Size = new System.Drawing.Size(380, 21);
            this.txtmobile.TabIndex = 9;
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 269);
            this.Name = "EdtView";
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkusing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtjobnum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrealname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrepwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmobile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl chkusing;
        private Ultra.FASControls.LabelTextBox txtWorkAccount;
        private Ultra.FASControls.LabelTextBox txtjobnum;
        private Ultra.FASControls.LabelTextBox txtrealname;
        private Ultra.FASControls.LabelTextBox txtrepwd;
        private Ultra.FASControls.LabelTextBox txtpwd;
        private Ultra.FASControls.LabelTextBox txtusername;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private Ultra.FASControls.LabelTextBox txtmobile;
    }
}