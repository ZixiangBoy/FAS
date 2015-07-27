namespace FAS.Suppliers
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.groupPanel1 = new FAC.Login.Controls.GroupPanel();
            this.ckeIsUsing = new FAC.Login.Controls.CheckCtl();
            this.txtAddress = new Ultra.FASControls.LabelTextBox();
            this.txtFax = new Ultra.FASControls.LabelTextBox();
            this.txtCpyMobile = new Ultra.FASControls.LabelTextBox();
            this.txtCpyPerson = new Ultra.FASControls.LabelTextBox();
            this.txtMobile = new Ultra.FASControls.LabelTextBox();
            this.txtSuppPerson = new Ultra.FASControls.LabelTextBox();
            this.lblsuppcode = new Ultra.FASControls.LabelTextBox();
            this.txtPhone = new Ultra.FASControls.LabelTextBox();
            this.txtSupplierName = new Ultra.FASControls.LabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckeIsUsing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCpyMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCpyPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuppPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblsuppcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3284, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3199, 6);
            this.btnOK.TabIndex = 60;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(377, 238);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.groupPanel1);
            this.pnlFill.Size = new System.Drawing.Size(377, 192);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 192);
            this.pnlBottom.Size = new System.Drawing.Size(377, 46);
            // 
            // groupPanel1
            // 
            this.groupPanel1.Controls.Add(this.ckeIsUsing);
            this.groupPanel1.Controls.Add(this.txtAddress);
            this.groupPanel1.Controls.Add(this.txtFax);
            this.groupPanel1.Controls.Add(this.txtCpyMobile);
            this.groupPanel1.Controls.Add(this.txtCpyPerson);
            this.groupPanel1.Controls.Add(this.txtMobile);
            this.groupPanel1.Controls.Add(this.txtSuppPerson);
            this.groupPanel1.Controls.Add(this.lblsuppcode);
            this.groupPanel1.Controls.Add(this.txtPhone);
            this.groupPanel1.Controls.Add(this.txtSupplierName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(2, 2);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(373, 255);
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "供应商信息";
            // 
            // ckeIsUsing
            // 
            this.ckeIsUsing.EditValue = true;
            this.ckeIsUsing.Location = new System.Drawing.Point(290, 160);
            this.ckeIsUsing.Name = "ckeIsUsing";
            this.ckeIsUsing.Properties.Caption = "启用";
            this.ckeIsUsing.Size = new System.Drawing.Size(75, 19);
            this.ckeIsUsing.TabIndex = 8;
            // 
            // txtAddress
            // 
            this.txtAddress.LabelText = "地址";
            this.txtAddress.Location = new System.Drawing.Point(10, 133);
            this.txtAddress.Name = "txtAddress";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "地址", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtAddress.Size = new System.Drawing.Size(355, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // txtFax
            // 
            this.txtFax.LabelText = "传真";
            this.txtFax.Location = new System.Drawing.Point(197, 106);
            this.txtFax.Name = "txtFax";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtFax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "传真", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtFax.Size = new System.Drawing.Size(168, 20);
            this.txtFax.TabIndex = 8;
            // 
            // txtCpyMobile
            // 
            this.txtCpyMobile.LabelText = "负责人电话";
            this.txtCpyMobile.Location = new System.Drawing.Point(197, 79);
            this.txtCpyMobile.Name = "txtCpyMobile";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCpyMobile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "负责人电话", 60, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtCpyMobile.Size = new System.Drawing.Size(168, 20);
            this.txtCpyMobile.TabIndex = 7;
            // 
            // txtCpyPerson
            // 
            this.txtCpyPerson.LabelText = "公司负责人";
            this.txtCpyPerson.Location = new System.Drawing.Point(10, 79);
            this.txtCpyPerson.Name = "txtCpyPerson";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCpyPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "公司负责人", 60, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtCpyPerson.Size = new System.Drawing.Size(168, 20);
            this.txtCpyPerson.TabIndex = 6;
            // 
            // txtMobile
            // 
            this.txtMobile.LabelText = "负责人电话";
            this.txtMobile.Location = new System.Drawing.Point(197, 52);
            this.txtMobile.Name = "txtMobile";
            serializableAppearanceObject5.Options.UseTextOptions = true;
            serializableAppearanceObject5.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtMobile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "负责人电话", 60, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.txtMobile.Size = new System.Drawing.Size(168, 20);
            this.txtMobile.TabIndex = 4;
            // 
            // txtSuppPerson
            // 
            this.txtSuppPerson.LabelText = "供应商负责人";
            this.txtSuppPerson.Location = new System.Drawing.Point(10, 52);
            this.txtSuppPerson.Name = "txtSuppPerson";
            serializableAppearanceObject6.Options.UseTextOptions = true;
            serializableAppearanceObject6.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSuppPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "供应商负责人", 80, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtSuppPerson.Size = new System.Drawing.Size(168, 20);
            this.txtSuppPerson.TabIndex = 3;
            // 
            // lblsuppcode
            // 
            this.lblsuppcode.LabelText = "供应商编码";
            this.lblsuppcode.Location = new System.Drawing.Point(197, 25);
            this.lblsuppcode.Name = "lblsuppcode";
            serializableAppearanceObject7.Options.UseTextOptions = true;
            serializableAppearanceObject7.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblsuppcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "供应商编码", 80, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.lblsuppcode.Size = new System.Drawing.Size(168, 20);
            this.lblsuppcode.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.LabelText = "电话";
            this.txtPhone.Location = new System.Drawing.Point(10, 106);
            this.txtPhone.Name = "txtPhone";
            serializableAppearanceObject8.Options.UseTextOptions = true;
            serializableAppearanceObject8.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPhone.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "电话", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
            this.txtPhone.Size = new System.Drawing.Size(168, 20);
            this.txtPhone.TabIndex = 2;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.LabelText = "供应商";
            this.txtSupplierName.Location = new System.Drawing.Point(10, 25);
            this.txtSupplierName.Name = "txtSupplierName";
            serializableAppearanceObject9.Options.UseTextOptions = true;
            serializableAppearanceObject9.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSupplierName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "供应商", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "", null, null, true)});
            this.txtSupplierName.Size = new System.Drawing.Size(168, 20);
            this.txtSupplierName.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "不能为空!";
            this.dxValidationProvider1.SetValidationRule(this.txtSupplierName, conditionValidationRule1);
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 238);
            this.Name = "EdtView";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckeIsUsing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCpyMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCpyPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuppPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblsuppcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.GroupPanel groupPanel1;
        private Ultra.FASControls.LabelTextBox txtSupplierName;
        private Ultra.FASControls.LabelTextBox txtPhone;
        private Ultra.FASControls.LabelTextBox txtSuppPerson;
        private Ultra.FASControls.LabelTextBox txtMobile;
        private Ultra.FASControls.LabelTextBox txtCpyPerson;
        private Ultra.FASControls.LabelTextBox txtCpyMobile;
        private Ultra.FASControls.LabelTextBox txtFax;
        private Ultra.FASControls.LabelTextBox txtAddress;
        private FAC.Login.Controls.CheckCtl ckeIsUsing;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private Ultra.FASControls.LabelTextBox lblsuppcode;
    }
}