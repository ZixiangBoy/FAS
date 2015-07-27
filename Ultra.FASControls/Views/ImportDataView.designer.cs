namespace Ultra.FASControls.Views
{
    partial class ImportDataView
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCtl1 = new FAC.Login.Controls.BtnCtl();
            this.btnChk = new FAC.Login.Controls.BtnCtl();
            this.btnExp = new FAC.Login.Controls.BtnCtl();
            this.btnImp = new FAC.Login.Controls.BtnCtl();
            this.fileBrowser1 = new Ultra.FASControls.FileBrowser();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barBtnDelFocus = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3072, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2987, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(844, 423);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(844, 377);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 377);
            this.pnlBottom.Size = new System.Drawing.Size(844, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCtl1);
            this.panelControl1.Controls.Add(this.btnChk);
            this.panelControl1.Controls.Add(this.btnExp);
            this.panelControl1.Controls.Add(this.btnImp);
            this.panelControl1.Controls.Add(this.fileBrowser1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(840, 39);
            this.panelControl1.TabIndex = 1;
            // 
            // btnCtl1
            // 
            this.btnCtl1.Location = new System.Drawing.Point(665, 9);
            this.btnCtl1.Name = "btnCtl1";
            this.btnCtl1.Size = new System.Drawing.Size(110, 23);
            this.btnCtl1.TabIndex = 4;
            this.btnCtl1.Text = "生成模板文件";
            this.btnCtl1.Click += new System.EventHandler(this.btnCtl1_Click);
            // 
            // btnChk
            // 
            this.btnChk.Location = new System.Drawing.Point(404, 9);
            this.btnChk.Name = "btnChk";
            this.btnChk.Size = new System.Drawing.Size(75, 23);
            this.btnChk.TabIndex = 3;
            this.btnChk.Text = "验证数据";
            this.btnChk.Click += new System.EventHandler(this.btnChk_Click);
            // 
            // btnExp
            // 
            this.btnExp.Location = new System.Drawing.Point(485, 9);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(93, 23);
            this.btnExp.TabIndex = 2;
            this.btnExp.Text = "导出当前数据";
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnImp
            // 
            this.btnImp.Enabled = false;
            this.btnImp.Location = new System.Drawing.Point(584, 9);
            this.btnImp.Name = "btnImp";
            this.btnImp.Size = new System.Drawing.Size(75, 23);
            this.btnImp.TabIndex = 1;
            this.btnImp.Text = "导入";
            this.btnImp.Click += new System.EventHandler(this.btnImp_Click);
            // 
            // fileBrowser1
            // 
            this.fileBrowser1.AllowDrop = true;
            this.fileBrowser1.LabelText = "文件";
            this.fileBrowser1.Location = new System.Drawing.Point(10, 10);
            this.fileBrowser1.Name = "fileBrowser1";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fileBrowser1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "文件", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "浏览...", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.fileBrowser1.Properties.ReadOnly = true;
            this.fileBrowser1.Size = new System.Drawing.Size(388, 21);
            this.fileBrowser1.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnDelFocus});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(844, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 423);
            this.barDockControlBottom.Size = new System.Drawing.Size(844, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 423);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(844, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 423);
            // 
            // barBtnDelFocus
            // 
            this.barBtnDelFocus.Caption = "排除所选行";
            this.barBtnDelFocus.Id = 0;
            this.barBtnDelFocus.Name = "barBtnDelFocus";
            this.barBtnDelFocus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDelFocus_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDelFocus)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // ImportDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 423);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ImportDataView";
            this.Text = "数据导入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public FAC.Login.Controls.BtnCtl btnCtl1;
        public FAC.Login.Controls.BtnCtl btnChk;
        public FAC.Login.Controls.BtnCtl btnExp;
        public FAC.Login.Controls.BtnCtl btnImp;
        public FileBrowser fileBrowser1;
        public DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarButtonItem barBtnDelFocus;
        public DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
    }
}