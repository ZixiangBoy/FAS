namespace Ultra.FAS.Item
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txttypename = new Ultra.FASControls.LabelTextBox();
            this.txtstylename = new Ultra.FASControls.LabelTextBox();
            this.txtstyledata = new Ultra.FASControls.LabelTextBox();
            this.chkusing = new FAC.Login.Controls.CheckCtl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttypename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstylename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstyledata.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkusing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(271, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(368, 169);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.chkusing);
            this.pnlFill.Controls.Add(this.txtstyledata);
            this.pnlFill.Controls.Add(this.txtstylename);
            this.pnlFill.Controls.Add(this.txttypename);
            this.pnlFill.Size = new System.Drawing.Size(368, 123);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 123);
            this.pnlBottom.Size = new System.Drawing.Size(368, 46);
            // 
            // txttypename
            // 
            this.txttypename.EditValue = "";
            this.txttypename.LabelText = "属性分类";
            this.txttypename.Location = new System.Drawing.Point(12, 12);
            this.txttypename.Name = "txttypename";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txttypename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "属性分类", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txttypename.Properties.ReadOnly = true;
            this.txttypename.Size = new System.Drawing.Size(345, 21);
            this.txttypename.TabIndex = 0;
            // 
            // txtstylename
            // 
            this.txtstylename.LabelText = "属性名称";
            this.txtstylename.Location = new System.Drawing.Point(12, 39);
            this.txtstylename.Name = "txtstylename";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtstylename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "属性名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtstylename.Properties.ReadOnly = true;
            this.txtstylename.Size = new System.Drawing.Size(345, 21);
            this.txtstylename.TabIndex = 1;
            // 
            // txtstyledata
            // 
            this.txtstyledata.LabelText = "属性值";
            this.txtstyledata.Location = new System.Drawing.Point(12, 66);
            this.txtstyledata.Name = "txtstyledata";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtstyledata.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "属性值", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtstyledata.Size = new System.Drawing.Size(345, 21);
            this.txtstyledata.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须填写";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtstyledata, conditionValidationRule1);
            // 
            // chkusing
            // 
            this.chkusing.EditValue = true;
            this.chkusing.Location = new System.Drawing.Point(12, 93);
            this.chkusing.Name = "chkusing";
            this.chkusing.Properties.Caption = "是否启用";
            this.chkusing.Size = new System.Drawing.Size(75, 19);
            this.chkusing.TabIndex = 3;
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 169);
            this.Name = "EdtView";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txttypename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstylename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstyledata.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkusing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl chkusing;
        private FASControls.LabelTextBox txtstyledata;
        private FASControls.LabelTextBox txtstylename;
        private FASControls.LabelTextBox txttypename;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}