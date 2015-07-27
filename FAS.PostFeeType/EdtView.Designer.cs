namespace FAS.PostFeeType
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
            this.txtusefor = new Ultra.FASControls.LabelTextBox();
            this.chkreq = new FAC.Login.Controls.CheckCtl();
            this.chkuseing = new FAC.Login.Controls.CheckCtl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtusefor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkreq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkuseing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(207, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(122, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(354, 147);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.chkuseing);
            this.pnlFill.Controls.Add(this.chkreq);
            this.pnlFill.Controls.Add(this.txtusefor);
            this.pnlFill.Size = new System.Drawing.Size(354, 101);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 101);
            this.pnlBottom.Size = new System.Drawing.Size(354, 46);
            // 
            // txtusefor
            // 
            this.txtusefor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtusefor.LabelText = "运费类型";
            this.txtusefor.Location = new System.Drawing.Point(12, 12);
            this.txtusefor.Name = "txtusefor";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtusefor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "运费类型", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtusefor.Size = new System.Drawing.Size(332, 21);
            this.txtusefor.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须输入";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtusefor, conditionValidationRule1);
            // 
            // chkreq
            // 
            this.chkreq.Location = new System.Drawing.Point(12, 39);
            this.chkreq.Name = "chkreq";
            this.chkreq.Properties.Caption = "是否必须输入";
            this.chkreq.Size = new System.Drawing.Size(117, 19);
            this.chkreq.TabIndex = 1;
            // 
            // chkuseing
            // 
            this.chkuseing.EditValue = true;
            this.chkuseing.Location = new System.Drawing.Point(12, 64);
            this.chkuseing.Name = "chkuseing";
            this.chkuseing.Properties.Caption = "启用";
            this.chkuseing.Size = new System.Drawing.Size(75, 19);
            this.chkuseing.TabIndex = 1;
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 147);
            this.Name = "EdtView";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtusefor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkreq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkuseing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl chkuseing;
        private FAC.Login.Controls.CheckCtl chkreq;
        private Ultra.FASControls.LabelTextBox txtusefor;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}