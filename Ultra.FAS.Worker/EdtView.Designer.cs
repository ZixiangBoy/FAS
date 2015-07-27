namespace Ultra.FAS.Worker
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.chkusing = new FAC.Login.Controls.CheckCtl();
            this.txtjobnum = new Ultra.FASControls.LabelTextBox();
            this.txtrealname = new Ultra.FASControls.LabelTextBox();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.txtmobile = new Ultra.FASControls.LabelTextBox();
            this.edtProduce = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkusing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtjobnum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrealname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProduce.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(331, 7);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(246, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(392, 198);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.edtProduce);
            this.pnlFill.Controls.Add(this.txtmobile);
            this.pnlFill.Controls.Add(this.chkusing);
            this.pnlFill.Controls.Add(this.txtjobnum);
            this.pnlFill.Controls.Add(this.txtrealname);
            this.pnlFill.Size = new System.Drawing.Size(392, 152);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 152);
            this.pnlBottom.Size = new System.Drawing.Size(392, 46);
            // 
            // chkusing
            // 
            this.chkusing.EditValue = true;
            this.chkusing.Location = new System.Drawing.Point(9, 121);
            this.chkusing.Name = "chkusing";
            this.chkusing.Properties.Caption = "启用";
            this.chkusing.Size = new System.Drawing.Size(75, 19);
            this.chkusing.TabIndex = 8;
            // 
            // txtjobnum
            // 
            this.txtjobnum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtjobnum.LabelText = "工号";
            this.txtjobnum.Location = new System.Drawing.Point(9, 39);
            this.txtjobnum.Name = "txtjobnum";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtjobnum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "工号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtjobnum.Size = new System.Drawing.Size(371, 21);
            this.txtjobnum.TabIndex = 4;
            // 
            // txtrealname
            // 
            this.txtrealname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrealname.LabelText = "姓名";
            this.txtrealname.Location = new System.Drawing.Point(9, 12);
            this.txtrealname.Name = "txtrealname";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtrealname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "姓名", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtrealname.Size = new System.Drawing.Size(371, 21);
            this.txtrealname.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须填写";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtrealname, conditionValidationRule1);
            // 
            // txtmobile
            // 
            this.txtmobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmobile.LabelText = "手机";
            this.txtmobile.Location = new System.Drawing.Point(9, 94);
            this.txtmobile.Name = "txtmobile";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtmobile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "手机", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtmobile.Size = new System.Drawing.Size(371, 21);
            this.txtmobile.TabIndex = 9;
            // 
            // edtProduce
            // 
            this.edtProduce.Location = new System.Drawing.Point(9, 66);
            this.edtProduce.Name = "edtProduce";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtProduce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "部门", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.edtProduce.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProcedureName", "部门")});
            this.edtProduce.Properties.DisplayMember = "ProcedureName";
            this.edtProduce.Properties.NullText = "";
            this.edtProduce.Properties.ValueMember = "ProcedureName";
            this.edtProduce.Size = new System.Drawing.Size(371, 21);
            this.edtProduce.TabIndex = 10;
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 198);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtjobnum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrealname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProduce.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl chkusing;
        private FASControls.LabelTextBox txtjobnum;
        private FASControls.LabelTextBox txtrealname;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private FASControls.LabelTextBox txtmobile;
        private DevExpress.XtraEditors.LookUpEdit edtProduce;
    }
}