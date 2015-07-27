namespace Ultra.WareHouseEx
{
    partial class IvtCheckIptItemEdt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IvtCheckIptItemEdt));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCtl2 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl1 = new FAC.Login.Controls.BtnCtl();
            this.btnChk = new FAC.Login.Controls.BtnCtl();
            this.btnExp = new FAC.Login.Controls.BtnCtl();
            this.btnImp = new FAC.Login.Controls.BtnCtl();
            this.fileBrowser1 = new Ultra.FASControls.FileBrowser();
            this.gcCheck = new Ultra.FASControls.GridControlEx();
            this.gvCheck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12089, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12004, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(943, 473);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gcCheck);
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(943, 427);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 427);
            this.pnlBottom.Size = new System.Drawing.Size(943, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCtl2);
            this.panelControl1.Controls.Add(this.btnCtl1);
            this.panelControl1.Controls.Add(this.btnChk);
            this.panelControl1.Controls.Add(this.btnExp);
            this.panelControl1.Controls.Add(this.btnImp);
            this.panelControl1.Controls.Add(this.fileBrowser1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(939, 39);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCtl2
            // 
            this.btnCtl2.Location = new System.Drawing.Point(781, 9);
            this.btnCtl2.Name = "btnCtl2";
            this.btnCtl2.Size = new System.Drawing.Size(110, 23);
            this.btnCtl2.TabIndex = 5;
            this.btnCtl2.Text = "生成当前库存数据";
            this.btnCtl2.Click += new System.EventHandler(this.btnCtl2_Click);
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
            this.btnExp.Size = new System.Drawing.Size(75, 23);
            this.btnExp.TabIndex = 2;
            this.btnExp.Text = "导出";
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnImp
            // 
            this.btnImp.Enabled = false;
            this.btnImp.Location = new System.Drawing.Point(566, 9);
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
            // gcCheck
            // 
            this.gcCheck.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcCheck.ColorFieldName = null;
            this.gcCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCheck.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcCheck.ImageFields")));
            this.gcCheck.Location = new System.Drawing.Point(2, 41);
            this.gcCheck.MainView = this.gvCheck;
            this.gcCheck.Name = "gcCheck";
            this.gcCheck.PopupMnu = null;
            this.gcCheck.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcCheck.PopupTextFields")));
            this.gcCheck.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcCheck.PopupTextFieldsReadOnly")));
            this.gcCheck.PropName = "PropName";
            this.gcCheck.RightMenu = null;
            this.gcCheck.RowCellColorStyleSource = null;
            this.gcCheck.ShadowDataSource = null;
            this.gcCheck.ShadowDataSourceKey = "Guid";
            this.gcCheck.ShowIndicator = true;
            this.gcCheck.ShowRowNumber = true;
            this.gcCheck.Size = new System.Drawing.Size(939, 384);
            this.gcCheck.TabIndex = 7;
            this.gcCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCheck});
            // 
            // gvCheck
            // 
            this.gvCheck.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvCheck.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvCheck.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvCheck.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn10});
            this.gvCheck.GridControl = this.gcCheck;
            this.gvCheck.IndicatorWidth = 44;
            this.gvCheck.Name = "gvCheck";
            this.gvCheck.OptionsBehavior.Editable = false;
            this.gvCheck.OptionsView.ColumnAutoWidth = false;
            this.gvCheck.OptionsView.ShowAutoFilterRow = true;
            this.gvCheck.OptionsView.ShowFooter = true;
            this.gvCheck.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "仓库";
            this.gridColumn1.FieldName = "WareName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "区域";
            this.gridColumn2.FieldName = "AreaName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "库位";
            this.gridColumn3.FieldName = "LocName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "商品编码";
            this.gridColumn4.FieldName = "OuterIid";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "规格编码";
            this.gridColumn5.FieldName = "OuterSkuId";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "商品";
            this.gridColumn6.FieldName = "ItemName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "规格";
            this.gridColumn7.FieldName = "SkuProperties";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "原库存数";
            this.gridColumn8.FieldName = "Qty";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "盘点数";
            this.gridColumn13.FieldName = "Num";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "验证结果";
            this.gridColumn10.FieldName = "ChkResult";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // IvtCheckIptItemEdt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 473);
            this.Name = "IvtCheckIptItemEdt";
            this.Text = "商品盘点导入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IptItemView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private FASControls.FileBrowser fileBrowser1;
        private FAC.Login.Controls.BtnCtl btnImp;
        private FAC.Login.Controls.BtnCtl btnExp;
        private FAC.Login.Controls.BtnCtl btnChk;
        private FAC.Login.Controls.BtnCtl btnCtl1;
        private FASControls.GridControlEx gcCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private FAC.Login.Controls.BtnCtl btnCtl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}