namespace Ultra.FAS.Procedure
{
    partial class ProPriceIptView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProPriceIptView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCtl3 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl2 = new FAC.Login.Controls.BtnCtl();
            this.btnImp = new FAC.Login.Controls.BtnCtl();
            this.fileBrowser1 = new Ultra.FASControls.FileBrowser();
            this.gridControlEx1 = new Ultra.FASControls.GridControlEx();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(2277, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2192, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(778, 448);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gridControlEx1);
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(778, 402);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 402);
            this.pnlBottom.Size = new System.Drawing.Size(778, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCtl3);
            this.panelControl1.Controls.Add(this.btnCtl2);
            this.panelControl1.Controls.Add(this.btnImp);
            this.panelControl1.Controls.Add(this.fileBrowser1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(774, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCtl3
            // 
            this.btnCtl3.Location = new System.Drawing.Point(420, 3);
            this.btnCtl3.Name = "btnCtl3";
            this.btnCtl3.Size = new System.Drawing.Size(75, 23);
            this.btnCtl3.TabIndex = 3;
            this.btnCtl3.Text = "验证数据";
            this.btnCtl3.Click += new System.EventHandler(this.btnCtl3_Click);
            // 
            // btnCtl2
            // 
            this.btnCtl2.Location = new System.Drawing.Point(615, 3);
            this.btnCtl2.Name = "btnCtl2";
            this.btnCtl2.Size = new System.Drawing.Size(97, 23);
            this.btnCtl2.TabIndex = 2;
            this.btnCtl2.Text = "生成模板文件";
            this.btnCtl2.Click += new System.EventHandler(this.btnCtl2_Click);
            // 
            // btnImp
            // 
            this.btnImp.Enabled = false;
            this.btnImp.Location = new System.Drawing.Point(534, 3);
            this.btnImp.Name = "btnImp";
            this.btnImp.Size = new System.Drawing.Size(75, 23);
            this.btnImp.TabIndex = 2;
            this.btnImp.Text = "导入";
            this.btnImp.Click += new System.EventHandler(this.btnImp_Click);
            // 
            // fileBrowser1
            // 
            this.fileBrowser1.AllowDrop = true;
            this.fileBrowser1.LabelText = "文件";
            this.fileBrowser1.Location = new System.Drawing.Point(10, 5);
            this.fileBrowser1.Name = "fileBrowser1";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fileBrowser1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "文件", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "浏览...", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.fileBrowser1.Properties.ReadOnly = true;
            this.fileBrowser1.Size = new System.Drawing.Size(388, 21);
            this.fileBrowser1.TabIndex = 1;
            // 
            // gridControlEx1
            // 
            this.gridControlEx1.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gridControlEx1.ColorFieldName = null;
            this.gridControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEx1.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.ImageFields")));
            this.gridControlEx1.Location = new System.Drawing.Point(2, 35);
            this.gridControlEx1.MainView = this.gridView1;
            this.gridControlEx1.Name = "gridControlEx1";
            this.gridControlEx1.PopupMnu = null;
            this.gridControlEx1.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.PopupTextFields")));
            this.gridControlEx1.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.PopupTextFieldsReadOnly")));
            this.gridControlEx1.PropName = "PropName";
            this.gridControlEx1.RightMenu = null;
            this.gridControlEx1.RowCellColorStyleSource = null;
            this.gridControlEx1.ShadowDataSource = null;
            this.gridControlEx1.ShadowDataSourceKey = "Guid";
            this.gridControlEx1.ShowIndicator = true;
            this.gridControlEx1.ShowRowNumber = true;
            this.gridControlEx1.Size = new System.Drawing.Size(774, 365);
            this.gridControlEx1.TabIndex = 1;
            this.gridControlEx1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControlEx1;
            this.gridView1.IndicatorWidth = 44;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ProPriceIptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 448);
            this.Name = "ProPriceIptView";
            this.Text = "工序价目表导入";
            this.Load += new System.EventHandler(this.ShopItemIptView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private FASControls.GridControlEx gridControlEx1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private FAC.Login.Controls.BtnCtl btnCtl2;
        private FAC.Login.Controls.BtnCtl btnImp;
        private FASControls.FileBrowser fileBrowser1;
        private FAC.Login.Controls.BtnCtl btnCtl3;
    }
}