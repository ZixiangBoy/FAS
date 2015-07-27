namespace FAS.ReturnMater {
    partial class EdtView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdtView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.userEdt = new Ultra.FASControls.BusControls.UserGridEdit();
            this.userGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProduce = new Ultra.FASControls.GridControlEx();
            this.gvProduce = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspRecvMaterUser = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspRecvMaterQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userEdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterQty)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1383, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1298, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(746, 389);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gcProduce);
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
            this.userEdt.DisplayMember = "";
            this.userEdt.EditValue = "";
            this.userEdt.LabelText = "领料人";
            this.userEdt.Location = new System.Drawing.Point(10, 8);
            this.userEdt.Name = "userEdt";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.userEdt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "领料人", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "清除所选", null, null, true)});
            this.userEdt.Properties.ImmediatePopup = true;
            this.userEdt.Properties.NullText = "";
            this.userEdt.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.userEdt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.userEdt.Properties.ValueMember = "Guid";
            this.userEdt.Properties.View = this.userGridEdit1View;
            this.userEdt.SelectedValue = null;
            this.userEdt.ShowClearButton = true;
            this.userEdt.Size = new System.Drawing.Size(191, 21);
            this.userEdt.TabIndex = 1;
            this.userEdt.ValueMember = "Guid";
            this.userEdt.EditValueChanged += new System.EventHandler(this.userEdt_EditValueChanged);
            // 
            // userGridEdit1View
            // 
            this.userGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.userGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.userGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.userGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.userGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.userGridEdit1View.Name = "userGridEdit1View";
            this.userGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.userGridEdit1View.OptionsBehavior.Editable = false;
            this.userGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.userGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcProduce
            // 
            this.gcProduce.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcProduce.ColorFieldName = null;
            this.gcProduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProduce.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcProduce.ImageFields")));
            this.gcProduce.Location = new System.Drawing.Point(2, 40);
            this.gcProduce.MainView = this.gvProduce;
            this.gcProduce.Name = "gcProduce";
            this.gcProduce.PopupMnu = null;
            this.gcProduce.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcProduce.PopupTextFields")));
            this.gcProduce.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcProduce.PopupTextFieldsReadOnly")));
            this.gcProduce.PropName = "PropName";
            this.gcProduce.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rspRecvMaterUser,
            this.rspRecvMaterQty});
            this.gcProduce.RightMenu = null;
            this.gcProduce.RowCellColorStyleSource = null;
            this.gcProduce.ShadowDataSource = null;
            this.gcProduce.ShadowDataSourceKey = "Guid";
            this.gcProduce.ShowIndicator = true;
            this.gcProduce.ShowRowNumber = true;
            this.gcProduce.Size = new System.Drawing.Size(742, 301);
            this.gcProduce.TabIndex = 1;
            this.gcProduce.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProduce});
            // 
            // gvProduce
            // 
            this.gvProduce.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvProduce.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvProduce.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvProduce.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvProduce.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn8});
            this.gvProduce.GridControl = this.gcProduce;
            this.gvProduce.IndicatorWidth = 44;
            this.gvProduce.Name = "gvProduce";
            this.gvProduce.OptionsBehavior.Editable = false;
            this.gvProduce.OptionsView.ShowAutoFilterRow = true;
            this.gvProduce.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "领料单号";
            this.gridColumn10.FieldName = "RecvMaterNo";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "型号";
            this.gridColumn1.FieldName = "OuterIid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "规格";
            this.gridColumn2.FieldName = "OuterSkuId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "工序";
            this.gridColumn3.FieldName = "ProcedureName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "物料编码";
            this.gridColumn4.FieldName = "MaterialNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "物料名称";
            this.gridColumn5.FieldName = "MaterialName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "用量";
            this.gridColumn6.FieldName = "UseQty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "生产单号";
            this.gridColumn7.FieldName = "ProduceNo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.DodgerBlue;
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "领料人";
            this.gridColumn9.ColumnEdit = this.rspRecvMaterUser;
            this.gridColumn9.FieldName = "RecvMaterUser";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
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
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.DodgerBlue;
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.Caption = "实领数量";
            this.gridColumn8.ColumnEdit = this.rspRecvMaterQty;
            this.gridColumn8.FieldName = "RecvMaterQty";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            // 
            // rspRecvMaterQty
            // 
            this.rspRecvMaterQty.AutoHeight = false;
            this.rspRecvMaterQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspRecvMaterQty.Name = "rspRecvMaterQty";
            this.rspRecvMaterQty.EditValueChanged += new System.EventHandler(this.rspRecvMaterQty_EditValueChanged);
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 389);
            this.Name = "EdtView";
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
            ((System.ComponentModel.ISupportInitialize)(this.userGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspRecvMaterQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Ultra.FASControls.BusControls.UserGridEdit userEdt;
        private DevExpress.XtraGrid.Views.Grid.GridView userGridEdit1View;
        private Ultra.FASControls.GridControlEx gcProduce;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProduce;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rspRecvMaterUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspRecvMaterQty;
    }
}