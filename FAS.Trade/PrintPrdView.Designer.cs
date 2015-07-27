namespace FAS.Trade {
    partial class PrintPrdView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPrdView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbPrtTemp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbProce = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnPrt = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcOrder = new Ultra.FASControls.GridControlEx();
            this.gvOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspPrintNum = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspWorker = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspIsProd = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSplit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrtPreView = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrtTemp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspPrintNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspWorker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspIsProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPrtPreView);
            this.panelControl1.Controls.Add(this.cmbPrtTemp);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cmbProce);
            this.panelControl1.Controls.Add(this.btnPrt);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(846, 38);
            this.panelControl1.TabIndex = 3;
            // 
            // cmbPrtTemp
            // 
            this.cmbPrtTemp.EditValue = "标准模板";
            this.cmbPrtTemp.Location = new System.Drawing.Point(304, 4);
            this.cmbPrtTemp.Name = "cmbPrtTemp";
            this.cmbPrtTemp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "打印模板", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cmbPrtTemp.Properties.Items.AddRange(new object[] {
            "标准模板",
            "床垫模板"});
            this.cmbPrtTemp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPrtTemp.Size = new System.Drawing.Size(190, 21);
            this.cmbPrtTemp.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "选择需要打印的工序";
            // 
            // cmbProce
            // 
            this.cmbProce.Location = new System.Drawing.Point(126, 5);
            this.cmbProce.Name = "cmbProce";
            this.cmbProce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProce.Size = new System.Drawing.Size(156, 20);
            this.cmbProce.TabIndex = 3;
            this.cmbProce.EditValueChanged += new System.EventHandler(this.cmbProce_EditValueChanged);
            // 
            // btnPrt
            // 
            this.btnPrt.Location = new System.Drawing.Point(512, 2);
            this.btnPrt.Name = "btnPrt";
            this.btnPrt.Size = new System.Drawing.Size(75, 23);
            this.btnPrt.TabIndex = 1;
            this.btnPrt.Text = "打印";
            this.btnPrt.Click += new System.EventHandler(this.btnPrt_Click);
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 38);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl2.Size = new System.Drawing.Size(846, 486);
            this.xtraTabControl2.TabIndex = 4;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcOrder);
            this.xtraTabPage2.Controls.Add(this.panelControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(840, 457);
            this.xtraTabPage2.Text = "商品";
            // 
            // gcOrder
            // 
            this.gcOrder.AutoCallWW = true;
            this.gcOrder.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcOrder.ColorFieldName = "Reserved2";
            this.gcOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOrder.Editable = true;
            this.gcOrder.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcOrder.ImageFields")));
            this.gcOrder.Location = new System.Drawing.Point(0, 0);
            this.gcOrder.MainView = this.gvOrder;
            this.gcOrder.Name = "gcOrder";
            this.gcOrder.PopupMnu = null;
            this.gcOrder.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcOrder.PopupTextFields")));
            this.gcOrder.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcOrder.PopupTextFieldsReadOnly")));
            this.gcOrder.PropName = "PropName";
            this.gcOrder.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gcOrder.PrvCityDistrict")));
            this.gcOrder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rspIsProd,
            this.rspPrintNum,
            this.rspWorker});
            this.gcOrder.RightMenu = null;
            this.gcOrder.RowCellColorStyleSource = null;
            this.gcOrder.ShadowDataSource = null;
            this.gcOrder.ShadowDataSourceKey = "Guid";
            this.gcOrder.ShowIndicator = true;
            this.gcOrder.ShowRowNumber = true;
            this.gcOrder.Size = new System.Drawing.Size(840, 425);
            this.gcOrder.TabIndex = 4;
            this.gcOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOrder});
            // 
            // gvOrder
            // 
            this.gvOrder.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvOrder.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvOrder.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvOrder.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn15,
            this.gridColumn25,
            this.gridColumn1,
            this.gridColumn31,
            this.gridColumn5,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn40,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn32,
            this.gridColumn11});
            this.gvOrder.GridControl = this.gcOrder;
            this.gvOrder.IndicatorWidth = 44;
            this.gvOrder.Name = "gvOrder";
            this.gvOrder.OptionsSelection.MultiSelect = true;
            this.gvOrder.OptionsView.ColumnAutoWidth = false;
            this.gvOrder.OptionsView.ShowAutoFilterRow = true;
            this.gvOrder.OptionsView.ShowGroupPanel = false;
            this.gvOrder.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "商品名称";
            this.gridColumn10.FieldName = "ItemName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "规格名称";
            this.gridColumn15.FieldName = "SkuName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "可打印数量";
            this.gridColumn25.FieldName = "CanPrtNum";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "打印数量";
            this.gridColumn1.ColumnEdit = this.rspPrintNum;
            this.gridColumn1.FieldName = "PrintNum";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // rspPrintNum
            // 
            this.rspPrintNum.AutoHeight = false;
            this.rspPrintNum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspPrintNum.Name = "rspPrintNum";
            this.rspPrintNum.EditValueChanged += new System.EventHandler(this.rspPrintNum_EditValueChanged);
            this.rspPrintNum.Validating += new System.ComponentModel.CancelEventHandler(this.rspPrintNum_Validating);
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "工序";
            this.gridColumn31.FieldName = "ProceName";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.Caption = "工人";
            this.gridColumn5.ColumnEdit = this.rspWorker;
            this.gridColumn5.FieldName = "ProceUser";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // rspWorker
            // 
            this.rspWorker.AutoHeight = false;
            this.rspWorker.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspWorker.DisplayMember = "RealName";
            this.rspWorker.Name = "rspWorker";
            this.rspWorker.NullText = "";
            this.rspWorker.ValueMember = "RealName";
            this.rspWorker.View = this.repositoryItemGridLookUpEdit1View;
            this.rspWorker.EditValueChanged += new System.EventHandler(this.rspWorker_EditValueChanged);
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "工人";
            this.gridColumn6.FieldName = "RealName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "真皮";
            this.gridColumn29.FieldName = "Surface";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 6;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "仿皮";
            this.gridColumn30.FieldName = "ImitSurface";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 7;
            // 
            // gridColumn40
            // 
            this.gridColumn40.AppearanceCell.BackColor = System.Drawing.Color.Transparent;
            this.gridColumn40.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn40.Caption = "仿真皮";
            this.gridColumn40.FieldName = "GenuineSurface";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 8;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "环保皮";
            this.gridColumn3.FieldName = "EnvSurface";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "商标";
            this.gridColumn4.FieldName = "TradeMark";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 10;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.Caption = "方向";
            this.gridColumn2.FieldName = "Direction";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "备注";
            this.gridColumn32.FieldName = "Remark";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 12;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.BackColor = System.Drawing.Color.Transparent;
            this.gridColumn11.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn11.Caption = "订单号";
            this.gridColumn11.FieldName = "PrdNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 13;
            // 
            // rspIsProd
            // 
            this.rspIsProd.AutoHeight = false;
            this.rspIsProd.Name = "rspIsProd";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnDel);
            this.panelControl2.Controls.Add(this.btnSplit);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 425);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(840, 32);
            this.panelControl2.TabIndex = 5;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(92, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "移除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(11, 5);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 0;
            this.btnSplit.Text = "拆分";
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnPrtPreView
            // 
            this.btnPrtPreView.Location = new System.Drawing.Point(628, 2);
            this.btnPrtPreView.Name = "btnPrtPreView";
            this.btnPrtPreView.Size = new System.Drawing.Size(75, 23);
            this.btnPrtPreView.TabIndex = 7;
            this.btnPrtPreView.Text = "打印预览";
            this.btnPrtPreView.Click += new System.EventHandler(this.btnPrtPreView_Click);
            // 
            // PrintPrdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 524);
            this.Controls.Add(this.xtraTabControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "PrintPrdView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印工序单";
            this.Load += new System.EventHandler(this.PrintPrdView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrtTemp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspPrintNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspWorker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspIsProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrt;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Ultra.FASControls.GridControlEx gcOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rspIsProd;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspPrintNum;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSplit;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbProce;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rspWorker;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPrtTemp;
        private DevExpress.XtraEditors.SimpleButton btnPrtPreView;
    }
}