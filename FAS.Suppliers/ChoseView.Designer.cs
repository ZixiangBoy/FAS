namespace FAS.Suppliers
{
    partial class ChoseView
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
            this.rdbsupp = new DevExpress.XtraEditors.CheckEdit();
            this.btnCtl1 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl2 = new FAC.Login.Controls.BtnCtl();
            ((System.ComponentModel.ISupportInitialize)(this.rdbsupp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbsupp
            // 
            this.rdbsupp.EditValue = true;
            this.rdbsupp.Location = new System.Drawing.Point(34, 12);
            this.rdbsupp.Name = "rdbsupp";
            this.rdbsupp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.rdbsupp.Properties.Caption = "供应商导入";
            this.rdbsupp.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdbsupp.Properties.RadioGroupIndex = 1;
            this.rdbsupp.Size = new System.Drawing.Size(176, 19);
            this.rdbsupp.TabIndex = 0;
            // 
            // btnCtl1
            // 
            this.btnCtl1.Location = new System.Drawing.Point(36, 78);
            this.btnCtl1.Name = "btnCtl1";
            this.btnCtl1.Size = new System.Drawing.Size(75, 32);
            this.btnCtl1.TabIndex = 1;
            this.btnCtl1.Text = "确定";
            this.btnCtl1.Click += new System.EventHandler(this.btnCtl1_Click);
            // 
            // btnCtl2
            // 
            this.btnCtl2.Location = new System.Drawing.Point(135, 78);
            this.btnCtl2.Name = "btnCtl2";
            this.btnCtl2.Size = new System.Drawing.Size(75, 32);
            this.btnCtl2.TabIndex = 1;
            this.btnCtl2.Text = "关闭";
            this.btnCtl2.Click += new System.EventHandler(this.btnCtl2_Click);
            // 
            // ChoseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 115);
            this.Controls.Add(this.btnCtl2);
            this.Controls.Add(this.btnCtl1);
            this.Controls.Add(this.rdbsupp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoseView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择";
            ((System.ComponentModel.ISupportInitialize)(this.rdbsupp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit rdbsupp;
        private FAC.Login.Controls.BtnCtl btnCtl1;
        private FAC.Login.Controls.BtnCtl btnCtl2;
    }
}