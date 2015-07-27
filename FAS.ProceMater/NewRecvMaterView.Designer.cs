namespace FAS.ProduceMater {
    partial class NewRecvMaterView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRecvMaterView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.userEdt = new Ultra.FASControls.BusControls.WorkerGridEdit();
            this.workerGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRecvMater = new Ultra.FASControls.GridControlEx();
            this.gvRecvMater = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspRecvMaterUser = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspRecvMaterQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reploc = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userEdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRecvMater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecvMater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reploc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(5787, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5702, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(746, 389);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gcRecvMater);
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(746, 343);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 343);
            this.pnlBottom.Size = new System.Drawing.Size(746, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.userEdt);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(742, 38);
            this.panelControl1.TabIndex = 0;
            // 
            // userEdt
            // 
            this.userEdt.ClearButtonText = "清除所选";
            this.userEdt.ColumnCaption = "领料人";
            this.userEdt.ColumnItemsEx2 = ((Ultra.FASControls.GridEditColItemExCollection)(resources.GetObject("userEdt.ColumnItemsEx2")));
            this.userEdt.DisplayMember = "RealName";
            this.userEdt.EditValue = "";
            this.userEdt.LabelText = "领料人";
            this.userEdt.Location = new System.Drawing.Point(10, 10);
            this.userEdt.Name = "userEdt";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.userEdt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "领料人", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "清除所选", null, null, true)});
            this.userEdt.Properties.DisplayMember = "RealName";
            this.userEdt.Properties.ImmediatePopup = true;
            this.userEdt.Properties.NullText = "";
            this.userEdt.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.userEdt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.userEdt.Properties.ValueMember = "Guid";
            this.userEdt.Properties.View = this.workerGridEdit1View;
            this.userEdt.SelectedValue = null;
            this.userEdt.Size = new System.Drawing.Size(168, 21);
            this.userEdt.TabIndex = 2;
            this.userEdt.ValueMember = "Guid";
            this.userEdt.EditValueChanged += new System.EventHandler(this.userEdt_EditValueChanged);
            // 
            // workerGridEdit1View
            // 
            this.workerGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.workerGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.workerGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.workerGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.workerGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.workerGridEdit1View.Name = "workerGridEdit1View";
            this.workerGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.workerGridEdit1View.OptionsBehavior.Editable = false;
            this.workerGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.workerGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcRecvMater
            // 
            this.gcRecvMater.AutoCallWW = true;
            this.gcRecvMater.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcRecvMater.ColorFieldName = null;
            this.gcRecvMater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRecvMater.Editable = true;
            this.gcRecvMater.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcRecvMater.ImageFields")));
            this.gcRecvMater.Location = new System.Drawing.Point(2, 40);
            this.gcRecvMater.MainView = this.gvRecvMater;
            this.gcRecvMater.Name = "gcRecvMater";
            this.gcRecvMater.PopupMnu = null;
            this.gcRecvMater.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcRecvMater.PopupTextFields")));
            this.gcRecvMater.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcRecvMater.PopupTextFieldsReadOnly")));
            this.gcRecvMater.PropName = "PropName";
            this.gcRecvMater.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gcRecvMater.PrvCityDistrict")));
            this.gcRecvMater.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rspRecvMaterUser,
            this.rspRecvMaterQty,
            this.reploc});
            this.gcRecvMater.RightMenu = null;
            this.gcRecvMater.RowCellColorStyleSource = null;
            this.gcRecvMater.ShadowDataSource = null;
            this.gcRecvMater.ShadowDataSourceKey = "Guid";
            this.gcRecvMater.ShowIndicator = true;
            this.gcRecvMater.ShowRowNumber = true;
            this.gcRecvMater.Size = new System.Drawing.Size(742, 301);
            this.gcRecvMater.TabIndex = 1;
            this.gcRecvMater.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecvMater});
            // 
            // gvRecvMater
            // 
            this.gvRecvMater.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvRecvMater.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvRecvMater.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvRecvMater.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvRecvMater.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvRecvMater.GridControl = this.gcRecvMater;
            this.gvRecvMater.IndicatorWidth = 44;
            this.gvRecvMater.Name = "gvRecvMater";
            this.gvRecvMater.OptionsView.ColumnAutoWidth = false;
            this.gvRecvMater.OptionsView.ShowAutoFilterRow = true;
            this.gvRecvMater.OptionsView.ShowGroupPanel = false;
            this.gvRecvMater.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvRecvMater_CellValueChanging);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "生产单号";
            this.gridColumn7.FieldName = "ProduceNo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 77;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "物料编码";
            this.gridColumn4.FieldName = "MaterialNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 77;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "物料名称";
            this.gridColumn5.FieldName = "MaterialName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 77;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "用量";
            this.gridColumn6.FieldName = "UseQty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 77;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "领料人";
            this.gridColumn9.ColumnEdit = this.rspRecvMaterUser;
            this.gridColumn9.FieldName = "UserName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 85;
            // 
            // rspRecvMaterUser
            // 
            this.rspRecvMaterUser.AutoHeight = false;
            this.rspRecvMaterUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspRecvMaterUser.Name = "rspRecvMaterUser";
            this.rspRecvMaterUser.EditValueChanged += new System.EventHandler(this.rspRecvMaterUser_EditValueChanged);
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.Caption = "实领数量";
            this.gridColumn8.ColumnEdit = this.rspRecvMaterQty;
            this.gridColumn8.FieldName = "ActQty";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 78;
            // 
            // rspRecvMaterQty
            // 
            this.rspRecvMaterQty.AutoHeight = false;
            this.rspRecvMaterQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspRecvMaterQty.Name = "rspRecvMaterQty";
            this.rspRecvMaterQty.EditValueChanged += new System.EventHandler(this.rspRecvMaterQty_EditValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "仓库";
            this.gridColumn1.FieldName = "WareName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 73;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "区域";
            this.gridColumn2.FieldName = "AreaName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 73;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "库位";
            this.gridColumn3.ColumnEdit = this.reploc;
            this.gridColumn3.FieldName = "LocName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            this.gridColumn3.Width = 79;
            // 
            // reploc
            // 
            this.reploc.AutoHeight = false;
            this.reploc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reploc.DisplayMember = "LocName";
            this.reploc.Name = "reploc";
            this.reploc.NullText = "";
            this.reploc.ValueMember = "LocName";
            this.reploc.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "仓库";
            this.gridColumn10.FieldName = "WareName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "区域";
            this.gridColumn11.FieldName = "AreaName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "库位";
            this.gridColumn12.FieldName = "LocName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            // 
            // NewRecvMaterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 389);
            this.Name = "NewRecvMaterView";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userEdt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRecvMater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecvMater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reploc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Ultra.FASControls.GridControlEx gcRecvMater;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRecvMater;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rspRecvMaterUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspRecvMaterQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit reploc;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private Ultra.FASControls.BusControls.WorkerGridEdit userEdt;
        private DevExpress.XtraGrid.Views.Grid.GridView workerGridEdit1View;
    }
}