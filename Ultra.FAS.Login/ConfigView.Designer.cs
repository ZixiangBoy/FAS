namespace Ultra.FAS.Login
{
    partial class ConfigView
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.imgServer = new Ultra.FASControls.LabelTextBox();
            this.rdbWeb = new DevExpress.XtraEditors.CheckEdit();
            this.rdbDB = new DevExpress.XtraEditors.CheckEdit();
            this.gpweb = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtsvr = new Ultra.FASControls.LabelTextBox();
            this.gpdb = new DevExpress.XtraEditors.GroupControl();
            this.dbcfgold = new Ultra.DataAccess.Gui.DataBaseConfigWizard();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbWeb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpweb)).BeginInit();
            this.gpweb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsvr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpdb)).BeginInit();
            this.gpdb.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1126, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1041, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(541, 418);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gpdb);
            this.pnlFill.Controls.Add(this.gpweb);
            this.pnlFill.Controls.Add(this.groupControl1);
            this.pnlFill.Size = new System.Drawing.Size(541, 372);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 372);
            this.pnlBottom.Size = new System.Drawing.Size(541, 46);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.imgServer);
            this.groupControl1.Controls.Add(this.rdbWeb);
            this.groupControl1.Controls.Add(this.rdbDB);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(537, 51);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "访问模式";
            // 
            // imgServer
            // 
            this.imgServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgServer.EditValue = "";
            this.imgServer.LabelText = "图片服务器";
            this.imgServer.Location = new System.Drawing.Point(198, 26);
            this.imgServer.Name = "imgServer";
            serializableAppearanceObject6.Options.UseTextOptions = true;
            serializableAppearanceObject6.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.imgServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "图片服务器", 80, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "测试连接", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "保存配置", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
            this.imgServer.Size = new System.Drawing.Size(320, 21);
            this.imgServer.TabIndex = 1;
            this.imgServer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.imgServer_ButtonClick);
            // 
            // rdbWeb
            // 
            this.rdbWeb.Location = new System.Drawing.Point(107, 25);
            this.rdbWeb.Name = "rdbWeb";
            this.rdbWeb.Properties.Caption = "Web模式";
            this.rdbWeb.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdbWeb.Size = new System.Drawing.Size(85, 19);
            this.rdbWeb.TabIndex = 0;
            this.rdbWeb.CheckedChanged += new System.EventHandler(this.rdbWeb_CheckedChanged);
            // 
            // rdbDB
            // 
            this.rdbDB.EditValue = true;
            this.rdbDB.Location = new System.Drawing.Point(10, 26);
            this.rdbDB.Name = "rdbDB";
            this.rdbDB.Properties.Caption = "直连模式";
            this.rdbDB.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdbDB.Size = new System.Drawing.Size(91, 19);
            this.rdbDB.TabIndex = 0;
            this.rdbDB.CheckedChanged += new System.EventHandler(this.rdbDB_CheckedChanged);
            // 
            // gpweb
            // 
            this.gpweb.Controls.Add(this.labelControl1);
            this.gpweb.Controls.Add(this.txtsvr);
            this.gpweb.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpweb.Location = new System.Drawing.Point(2, 53);
            this.gpweb.Name = "gpweb";
            this.gpweb.Size = new System.Drawing.Size(537, 77);
            this.gpweb.TabIndex = 1;
            this.gpweb.Text = "Web模式配置";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Location = new System.Drawing.Point(30, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(207, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "例如:　http://服务器ＩＰ地址:端口号/";
            // 
            // txtsvr
            // 
            this.txtsvr.LabelText = "Server地址";
            this.txtsvr.Location = new System.Drawing.Point(30, 30);
            this.txtsvr.Name = "txtsvr";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtsvr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Server地址", 80, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "测试连接", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtsvr.Size = new System.Drawing.Size(488, 21);
            this.txtsvr.TabIndex = 0;
            this.txtsvr.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtsvr_ButtonClick);
            // 
            // gpdb
            // 
            this.gpdb.Controls.Add(this.dbcfgold);
            this.gpdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpdb.Location = new System.Drawing.Point(2, 130);
            this.gpdb.Name = "gpdb";
            this.gpdb.Size = new System.Drawing.Size(537, 240);
            this.gpdb.TabIndex = 2;
            this.gpdb.Text = "直连模式";
            // 
            // dbcfgold
            // 
            this.dbcfgold.AutoEnumServer = false;
            this.dbcfgold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbcfgold.Location = new System.Drawing.Point(2, 22);
            this.dbcfgold.Name = "dbcfgold";
            this.dbcfgold.Size = new System.Drawing.Size(533, 216);
            this.dbcfgold.TabIndex = 1;
            // 
            // ConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 418);
            this.Name = "ConfigView";
            this.Text = "配置信息";
            this.Load += new System.EventHandler(this.ConfigView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbWeb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpweb)).EndInit();
            this.gpweb.ResumeLayout(false);
            this.gpweb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsvr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpdb)).EndInit();
            this.gpdb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpdb;
        private DevExpress.XtraEditors.GroupControl gpweb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Ultra.FASControls.LabelTextBox txtsvr;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit rdbWeb;
        private DevExpress.XtraEditors.CheckEdit rdbDB;
        private Ultra.FASControls.LabelTextBox imgServer;
        private DataAccess.Gui.DataBaseConfigWizard dbcfgold;
    }
}