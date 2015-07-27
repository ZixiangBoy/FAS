namespace FAS.TradeMark {
    partial class EditView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtTradeMark = new Ultra.FASControls.LabelTextBox();
            this.chkIsUsing = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTradeMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsUsing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(162, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(77, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(259, 102);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.chkIsUsing);
            this.pnlFill.Controls.Add(this.txtTradeMark);
            this.pnlFill.Size = new System.Drawing.Size(259, 56);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 56);
            this.pnlBottom.Size = new System.Drawing.Size(259, 46);
            // 
            // txtTradeMark
            // 
            this.txtTradeMark.LabelText = "商标名称";
            this.txtTradeMark.Location = new System.Drawing.Point(12, 5);
            this.txtTradeMark.Name = "txtTradeMark";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtTradeMark.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "商标名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtTradeMark.Size = new System.Drawing.Size(235, 21);
            this.txtTradeMark.TabIndex = 0;
            // 
            // chkIsUsing
            // 
            this.chkIsUsing.EditValue = true;
            this.chkIsUsing.Location = new System.Drawing.Point(13, 33);
            this.chkIsUsing.Name = "chkIsUsing";
            this.chkIsUsing.Properties.Caption = "启用";
            this.chkIsUsing.Size = new System.Drawing.Size(75, 19);
            this.chkIsUsing.TabIndex = 1;
            // 
            // EditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 102);
            this.Name = "EditView";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EditView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTradeMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsUsing.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ultra.FASControls.LabelTextBox txtTradeMark;
        private DevExpress.XtraEditors.CheckEdit chkIsUsing;
    }
}