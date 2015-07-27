namespace Ultra.FAS.Login
{
    partial class SysInfoView
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.lblimgsrv = new DevExpress.XtraEditors.LabelControl();
            this.lblcsbsdb = new DevExpress.XtraEditors.LabelControl();
            this.lblshoplist = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mode:";
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(65, 12);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(4, 14);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = " ";
            // 
            // lblimgsrv
            // 
            this.lblimgsrv.Location = new System.Drawing.Point(82, 42);
            this.lblimgsrv.Name = "lblimgsrv";
            this.lblimgsrv.Size = new System.Drawing.Size(4, 14);
            this.lblimgsrv.TabIndex = 0;
            this.lblimgsrv.Text = " ";
            // 
            // lblcsbsdb
            // 
            this.lblcsbsdb.Location = new System.Drawing.Point(12, 70);
            this.lblcsbsdb.Name = "lblcsbsdb";
            this.lblcsbsdb.Size = new System.Drawing.Size(20, 14);
            this.lblcsbsdb.TabIndex = 1;
            this.lblcsbsdb.Text = "     ";
            this.lblcsbsdb.Visible = false;
            // 
            // lblshoplist
            // 
            this.lblshoplist.Location = new System.Drawing.Point(12, 102);
            this.lblshoplist.Name = "lblshoplist";
            this.lblshoplist.Size = new System.Drawing.Size(70, 14);
            this.lblshoplist.TabIndex = 1;
            this.lblshoplist.Text = "labelControl3";
            this.lblshoplist.Visible = false;
            // 
            // SysInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 149);
            this.Controls.Add(this.lblshoplist);
            this.Controls.Add(this.lblcsbsdb);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblimgsrv);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysInfoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统信息";
            this.Load += new System.EventHandler(this.SysInfoView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraEditors.LabelControl lblimgsrv;
        private DevExpress.XtraEditors.LabelControl lblcsbsdb;
        private DevExpress.XtraEditors.LabelControl lblshoplist;
    }
}