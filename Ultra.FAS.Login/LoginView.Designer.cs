namespace Ultra.FAS.Login
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCtl1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCtl2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtUsr = new DevExpress.XtraEditors.TextEdit();
            this.txtpwd = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Location = new System.Drawing.Point(340, 212);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "更改配置";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            this.labelControl1.MouseLeave += new System.EventHandler(this.labelControl1_MouseLeave);
            this.labelControl1.MouseHover += new System.EventHandler(this.labelControl1_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码";
            // 
            // btnCtl1
            // 
            this.btnCtl1.Location = new System.Drawing.Point(185, 169);
            this.btnCtl1.Name = "btnCtl1";
            this.btnCtl1.Size = new System.Drawing.Size(68, 23);
            this.btnCtl1.TabIndex = 7;
            this.btnCtl1.Text = "登录";
            this.btnCtl1.Click += new System.EventHandler(this.btnCtl1_Click);
            // 
            // btnCtl2
            // 
            this.btnCtl2.Location = new System.Drawing.Point(259, 169);
            this.btnCtl2.Name = "btnCtl2";
            this.btnCtl2.Size = new System.Drawing.Size(68, 23);
            this.btnCtl2.TabIndex = 8;
            this.btnCtl2.Text = "退出";
            this.btnCtl2.Click += new System.EventHandler(this.btnCtl2_Click);
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(128, 102);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(199, 20);
            this.txtUsr.TabIndex = 9;
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(128, 133);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Properties.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(199, 20);
            this.txtpwd.TabIndex = 10;
            this.txtpwd.Enter += new System.EventHandler(this.txtpwd_Enter);
            this.txtpwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtpwd_KeyUp);
            // 
            // LoginView
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(428, 240);
            this.ControlBox = false;
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtUsr);
            this.Controls.Add(this.btnCtl2);
            this.Controls.Add(this.btnCtl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnCtl1;
        private DevExpress.XtraEditors.SimpleButton btnCtl2;
        private DevExpress.XtraEditors.TextEdit txtUsr;
        private DevExpress.XtraEditors.TextEdit txtpwd;
    }
}