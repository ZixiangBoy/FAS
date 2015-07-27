namespace FAS.Role
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.memdesc = new DevExpress.XtraEditors.MemoEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.chkUsing = new FAC.Login.Controls.CheckCtl();
            this.txtname = new Ultra.FASControls.LabelTextBox();
            this.labelTextBox2 = new Ultra.FASControls.LabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTextBox2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(344, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(259, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(441, 251);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.memdesc);
            this.pnlFill.Controls.Add(this.chkUsing);
            this.pnlFill.Controls.Add(this.txtname);
            this.pnlFill.Controls.Add(this.labelTextBox2);
            this.pnlFill.Size = new System.Drawing.Size(441, 205);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 205);
            this.pnlBottom.Size = new System.Drawing.Size(441, 46);
            // 
            // memdesc
            // 
            this.memdesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memdesc.Location = new System.Drawing.Point(66, 64);
            this.memdesc.Name = "memdesc";
            this.memdesc.Size = new System.Drawing.Size(368, 135);
            this.memdesc.TabIndex = 3;
            // 
            // chkUsing
            // 
            this.chkUsing.EditValue = true;
            this.chkUsing.Location = new System.Drawing.Point(12, 39);
            this.chkUsing.Name = "chkUsing";
            this.chkUsing.Properties.Caption = "启用";
            this.chkUsing.Size = new System.Drawing.Size(75, 19);
            this.chkUsing.TabIndex = 1;
            // 
            // txtname
            // 
            this.txtname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtname.LabelText = "角色名称";
            this.txtname.Location = new System.Drawing.Point(12, 12);
            this.txtname.Name = "txtname";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "角色名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtname.Size = new System.Drawing.Size(422, 21);
            this.txtname.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须填写";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtname, conditionValidationRule1);
            // 
            // labelTextBox2
            // 
            this.labelTextBox2.LabelText = "描述";
            this.labelTextBox2.Location = new System.Drawing.Point(14, 64);
            this.labelTextBox2.Name = "labelTextBox2";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelTextBox2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "描述", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.labelTextBox2.Size = new System.Drawing.Size(89, 21);
            this.labelTextBox2.TabIndex = 2;
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 251);
            this.Name = "EdtView";
            this.Text = "角色名称编辑";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTextBox2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memdesc;
        private FAC.Login.Controls.CheckCtl chkUsing;
        private Ultra.FASControls.LabelTextBox txtname;
        private Ultra.FASControls.LabelTextBox labelTextBox2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}