namespace FAS.Trade {
    partial class EdtPrdView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdtPrdView));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcOrder = new Ultra.FASControls.GridControlEx();
            this.gvOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspIsProd = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspIsProd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(4910, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4825, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(735, 491);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.panelControl2);
            this.pnlFill.Size = new System.Drawing.Size(735, 445);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 445);
            this.pnlBottom.Size = new System.Drawing.Size(735, 46);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.xtraTabControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(731, 441);
            this.panelControl2.TabIndex = 2;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl2.Size = new System.Drawing.Size(727, 437);
            this.xtraTabControl2.TabIndex = 1;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcOrder);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(721, 408);
            this.xtraTabPage2.Text = "商品";
            // 
            // gcOrder
            // 
            this.gcOrder.AutoCallWW = true;
            this.gcOrder.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcOrder.ColorFieldName = null;
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
            this.rspIsProd});
            this.gcOrder.RightMenu = null;
            this.gcOrder.RowCellColorStyleSource = null;
            this.gcOrder.ShadowDataSource = null;
            this.gcOrder.ShadowDataSourceKey = "Guid";
            this.gcOrder.ShowIndicator = true;
            this.gcOrder.ShowRowNumber = true;
            this.gcOrder.Size = new System.Drawing.Size(721, 408);
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
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn15,
            this.gridColumn25,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn40,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn11});
            this.gvOrder.GridControl = this.gcOrder;
            this.gvOrder.IndicatorWidth = 44;
            this.gvOrder.Name = "gvOrder";
            this.gvOrder.OptionsView.ColumnAutoWidth = false;
            this.gvOrder.OptionsView.ShowAutoFilterRow = true;
            this.gvOrder.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "选择";
            this.gridColumn9.ColumnEdit = this.rspIsProd;
            this.gridColumn9.FieldName = "IsProd";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // rspIsProd
            // 
            this.rspIsProd.AutoHeight = false;
            this.rspIsProd.Name = "rspIsProd";
            this.rspIsProd.EditValueChanged += new System.EventHandler(this.rspUISelected_EditValueChanged);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "商品名称";
            this.gridColumn10.FieldName = "ItemName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "规格名称";
            this.gridColumn15.FieldName = "SkuName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "数量";
            this.gridColumn25.FieldName = "Num";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "颜色";
            this.gridColumn16.FieldName = "Color";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "材质";
            this.gridColumn17.FieldName = "Material";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 5;
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
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "环保皮";
            this.gridColumn1.FieldName = "EnvSurface";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.Caption = "商标";
            this.gridColumn2.FieldName = "TradeMark";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "方向";
            this.gridColumn31.FieldName = "Direction";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 11;
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
            this.gridColumn11.FieldName = "TradeNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 13;
            // 
            // EdtPrdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 491);
            this.Name = "EdtPrdView";
            this.Text = "生产";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EdtPrdView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspIsProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Ultra.FASControls.GridControlEx gcOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rspIsProd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}