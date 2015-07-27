namespace FAS.Trade {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectProdTrdView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefreash = new DevExpress.XtraEditors.SimpleButton();
            this.gcAuditPrd = new Ultra.FASControls.GridControlEx();
            this.gvAuditPrd = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPrdNo = new Ultra.FASControls.LabelTextBox();
            this.txtReceiver = new Ultra.FASControls.LabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAuditPrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuditPrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiver.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(796, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(711, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(637, 389);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gcAuditPrd);
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
            this.panelControl1.Controls.Add(this.txtReceiver);
            this.panelControl1.Controls.Add(this.txtPrdNo);
            this.panelControl1.Controls.Add(this.btnRefreash);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(633, 39);
            this.panelControl1.TabIndex = 0;
            // 
            // btnRefreash
            // 
            this.btnRefreash.Location = new System.Drawing.Point(444, 6);
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Size = new System.Drawing.Size(75, 28);
            this.btnRefreash.TabIndex = 0;
            this.btnRefreash.Text = "刷新";
            this.btnRefreash.Click += new System.EventHandler(this.btnRefreash_Click);
            // 
            // gcAuditPrd
            // 
            this.gcAuditPrd.AutoCallWW = true;
            this.gcAuditPrd.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcAuditPrd.ColorFieldName = null;
            this.gcAuditPrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAuditPrd.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAuditPrd.ImageFields")));
            this.gcAuditPrd.Location = new System.Drawing.Point(2, 41);
            this.gcAuditPrd.MainView = this.gvAuditPrd;
            this.gcAuditPrd.Name = "gcAuditPrd";
            this.gcAuditPrd.PopupMnu = null;
            this.gcAuditPrd.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAuditPrd.PopupTextFields")));
            this.gcAuditPrd.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAuditPrd.PopupTextFieldsReadOnly")));
            this.gcAuditPrd.PropName = "PropName";
            this.gcAuditPrd.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gcAuditPrd.PrvCityDistrict")));
            this.gcAuditPrd.RightMenu = null;
            this.gcAuditPrd.RowCellColorStyleSource = null;
            this.gcAuditPrd.ShadowDataSource = null;
            this.gcAuditPrd.ShadowDataSourceKey = "Guid";
            this.gcAuditPrd.ShowIndicator = true;
            this.gcAuditPrd.ShowRowNumber = true;
            this.gcAuditPrd.Size = new System.Drawing.Size(633, 300);
            this.gcAuditPrd.TabIndex = 7;
            this.gcAuditPrd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAuditPrd});
            // 
            // gvAuditPrd
            // 
            this.gvAuditPrd.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvAuditPrd.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvAuditPrd.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvAuditPrd.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvAuditPrd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn39,
            this.gridColumn38,
            this.gridColumn37,
            this.gridColumn14,
            this.gridColumn20,
            this.gridColumn21});
            this.gvAuditPrd.GridControl = this.gcAuditPrd;
            this.gvAuditPrd.IndicatorWidth = 44;
            this.gvAuditPrd.Name = "gvAuditPrd";
            this.gvAuditPrd.OptionsBehavior.Editable = false;
            this.gvAuditPrd.OptionsSelection.MultiSelect = true;
            this.gvAuditPrd.OptionsView.ColumnAutoWidth = false;
            this.gvAuditPrd.OptionsView.ShowAutoFilterRow = true;
            this.gvAuditPrd.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "生产号";
            this.gridColumn11.FieldName = "PrdNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "制单人";
            this.gridColumn12.FieldName = "Creator";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "制单时间";
            this.gridColumn13.FieldName = "CreateDate";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "来源单号";
            this.gridColumn39.FieldName = "FromTradeNos";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 3;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "收货方";
            this.gridColumn38.FieldName = "FromReceivers";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 4;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "交期";
            this.gridColumn37.FieldName = "FromProDelDate";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 5;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "审核";
            this.gridColumn14.FieldName = "IsAudit";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "审核人";
            this.gridColumn20.FieldName = "AuditUser";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 7;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "审核时间";
            this.gridColumn21.FieldName = "AuditTime";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 8;
            // 
            // txtPrdNo
            // 
            this.txtPrdNo.LabelText = "生产单号";
            this.txtPrdNo.Location = new System.Drawing.Point(10, 10);
            this.txtPrdNo.Name = "txtPrdNo";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPrdNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "生产单号", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtPrdNo.Size = new System.Drawing.Size(211, 21);
            this.txtPrdNo.TabIndex = 1;
            // 
            // txtReceiver
            // 
            this.txtReceiver.LabelText = "收货方";
            this.txtReceiver.Location = new System.Drawing.Point(227, 10);
            this.txtReceiver.Name = "txtReceiver";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtReceiver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "收货方", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtReceiver.Size = new System.Drawing.Size(211, 21);
            this.txtReceiver.TabIndex = 2;
            // 
            // SelectProdTrdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 389);
            this.Name = "SelectProdTrdView";
            this.Text = "选择生产单";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAuditPrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuditPrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiver.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefreash;
        private Ultra.FASControls.GridControlEx gcAuditPrd;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAuditPrd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private Ultra.FASControls.LabelTextBox txtReceiver;
        private Ultra.FASControls.LabelTextBox txtPrdNo;
    }
}