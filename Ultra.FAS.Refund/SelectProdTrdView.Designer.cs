namespace Ultra.FAS.Refund
{
    partial class SelectProdTrdView {
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectProdTrdView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtReceivers = new Ultra.FASControls.LabelTextBox();
            this.txtTrdNo = new Ultra.FASControls.LabelTextBox();
            this.btnRefreash = new DevExpress.XtraEditors.SimpleButton();
            this.gcAudit = new Ultra.FASControls.GridControlEx();
            this.gvAudit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pgrTrd = new Ultra.FASControls.TrdPager();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrdNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1836, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1751, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(637, 389);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gcAudit);
            this.pnlFill.Controls.Add(this.pgrTrd);
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(637, 343);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 343);
            this.pnlBottom.Size = new System.Drawing.Size(637, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtReceivers);
            this.panelControl1.Controls.Add(this.txtTrdNo);
            this.panelControl1.Controls.Add(this.btnRefreash);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(633, 39);
            this.panelControl1.TabIndex = 0;
            // 
            // txtReceivers
            // 
            this.txtReceivers.LabelText = "收货方";
            this.txtReceivers.Location = new System.Drawing.Point(181, 10);
            this.txtReceivers.Name = "txtReceivers";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtReceivers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "收货方", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtReceivers.Size = new System.Drawing.Size(170, 21);
            this.txtReceivers.TabIndex = 2;
            // 
            // txtTrdNo
            // 
            this.txtTrdNo.LabelText = "订单号";
            this.txtTrdNo.Location = new System.Drawing.Point(5, 10);
            this.txtTrdNo.Name = "txtTrdNo";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtTrdNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "订单号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtTrdNo.Size = new System.Drawing.Size(170, 21);
            this.txtTrdNo.TabIndex = 1;
            // 
            // btnRefreash
            // 
            this.btnRefreash.Location = new System.Drawing.Point(548, 6);
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Size = new System.Drawing.Size(75, 28);
            this.btnRefreash.TabIndex = 0;
            this.btnRefreash.Text = "刷新";
            this.btnRefreash.Click += new System.EventHandler(this.btnRefreash_Click);
            // 
            // gcAudit
            // 
            this.gcAudit.AutoCallWW = true;
            this.gcAudit.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcAudit.ColorFieldName = "ColorField";
            this.gcAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAudit.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAudit.ImageFields")));
            this.gcAudit.Location = new System.Drawing.Point(2, 41);
            this.gcAudit.MainView = this.gvAudit;
            this.gcAudit.Name = "gcAudit";
            this.gcAudit.PopupMnu = null;
            this.gcAudit.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAudit.PopupTextFields")));
            this.gcAudit.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAudit.PopupTextFieldsReadOnly")));
            this.gcAudit.PropName = "PropName";
            this.gcAudit.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAudit.PrvCityDistrict")));
            this.gcAudit.RightMenu = null;
            this.gcAudit.RowCellColorStyleSource = null;
            this.gcAudit.ShadowDataSource = null;
            this.gcAudit.ShadowDataSourceKey = "Guid";
            this.gcAudit.ShowIndicator = true;
            this.gcAudit.ShowRowNumber = true;
            this.gcAudit.Size = new System.Drawing.Size(633, 271);
            this.gcAudit.TabIndex = 5;
            this.gcAudit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAudit});
            this.gcAudit.RowCellDoubleClick += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.gcAudit_RowCellDoubleClick);
            // 
            // gvAudit
            // 
            this.gvAudit.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvAudit.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvAudit.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvAudit.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvAudit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28});
            this.gvAudit.GridControl = this.gcAudit;
            this.gvAudit.IndicatorWidth = 44;
            this.gvAudit.Name = "gvAudit";
            this.gvAudit.OptionsBehavior.Editable = false;
            this.gvAudit.OptionsView.ColumnAutoWidth = false;
            this.gvAudit.OptionsView.ShowAutoFilterRow = true;
            this.gvAudit.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "订单号";
            this.gridColumn9.FieldName = "TradeNo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "收货方";
            this.gridColumn18.FieldName = "ReceiverName";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 1;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "下单时间";
            this.gridColumn19.FieldName = "Created";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 2;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "订单交期";
            this.gridColumn20.FieldName = "ProDelDate";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 3;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "备注";
            this.gridColumn21.FieldName = "Remark";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 4;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "制单人";
            this.gridColumn22.FieldName = "Creator";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 5;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "制单时间";
            this.gridColumn23.FieldName = "CreateDate";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 6;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "是否加急";
            this.gridColumn24.FieldName = "IsUrgent";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 7;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "审核";
            this.gridColumn26.FieldName = "IsAudit";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 8;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "审核人";
            this.gridColumn27.FieldName = "AuditUser";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 9;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "审核时间";
            this.gridColumn28.FieldName = "AuditTime";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 10;
            // 
            // pgrTrd
            // 
            this.pgrTrd.Caller = null;
            this.pgrTrd.Counts = 0;
            this.pgrTrd.CurrentPage = 1;
            this.pgrTrd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgrTrd.Grid = this.gcAudit;
            this.pgrTrd.Location = new System.Drawing.Point(2, 312);
            this.pgrTrd.Name = "pgrTrd";
            this.pgrTrd.OrderBy = null;
            this.pgrTrd.PageCount = 0;
            this.pgrTrd.PageSize = 500;
            this.pgrTrd.PrefixWhr = null;
            this.pgrTrd.ResultData = null;
            this.pgrTrd.Size = new System.Drawing.Size(633, 29);
            this.pgrTrd.TabIndex = 7;
            // 
            // SelectProdTrdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 389);
            this.Name = "SelectProdTrdView";
            this.Text = "选择订单";
            this.Load += new System.EventHandler(this.SelectProdTrdView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrdNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAudit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefreash;
        private FASControls.LabelTextBox txtReceivers;
        private FASControls.LabelTextBox txtTrdNo;
        private FASControls.GridControlEx gcAudit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private FASControls.TrdPager pgrTrd;
    }
}