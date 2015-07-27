namespace Ultra.WareHouseEx
{
    partial class PrintView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPrint = new FAC.Login.Controls.BtnCtl();
            this.cmbPrinter = new Ultra.FASControls.BusControls.CmbPrinter();
            this.labelSpinEdit1 = new Ultra.FASControls.LabelSpinEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcUnAudit = new Ultra.FASControls.GridControlEx();
            this.gvUnAudit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcItem = new Ultra.FASControls.GridControlEx();
            this.gvItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn65 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrinter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelSpinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUnAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.cmbPrinter);
            this.panelControl1.Controls.Add(this.labelSpinEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(846, 36);
            this.panelControl1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(776, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(58, 24);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.Location = new System.Drawing.Point(188, 9);
            this.cmbPrinter.Name = "cmbPrinter";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.cmbPrinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "打印机", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cmbPrinter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPrinter.Size = new System.Drawing.Size(170, 21);
            this.cmbPrinter.TabIndex = 1;
            // 
            // labelSpinEdit1
            // 
            this.labelSpinEdit1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.labelSpinEdit1.Location = new System.Drawing.Point(12, 9);
            this.labelSpinEdit1.Name = "labelSpinEdit1";
            this.labelSpinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "打印份数", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.labelSpinEdit1.Size = new System.Drawing.Size(170, 21);
            this.labelSpinEdit1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 36);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(846, 337);
            this.panelControl2.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcUnAudit);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(842, 126);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "单据信息";
            // 
            // gcUnAudit
            // 
            this.gcUnAudit.AutoCallWW = true;
            this.gcUnAudit.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcUnAudit.ColorFieldName = null;
            this.gcUnAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUnAudit.Editable = true;
            this.gcUnAudit.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcUnAudit.ImageFields")));
            this.gcUnAudit.Location = new System.Drawing.Point(2, 22);
            this.gcUnAudit.MainView = this.gvUnAudit;
            this.gcUnAudit.Name = "gcUnAudit";
            this.gcUnAudit.PopupMnu = null;
            this.gcUnAudit.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcUnAudit.PopupTextFields")));
            this.gcUnAudit.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcUnAudit.PopupTextFieldsReadOnly")));
            this.gcUnAudit.PropName = "PropName";
            this.gcUnAudit.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gcUnAudit.PrvCityDistrict")));
            this.gcUnAudit.RightMenu = null;
            this.gcUnAudit.RowCellColorStyleSource = null;
            this.gcUnAudit.ShadowDataSource = null;
            this.gcUnAudit.ShadowDataSourceKey = "Guid";
            this.gcUnAudit.ShowIndicator = true;
            this.gcUnAudit.ShowRowNumber = true;
            this.gcUnAudit.Size = new System.Drawing.Size(838, 102);
            this.gcUnAudit.TabIndex = 2;
            this.gcUnAudit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUnAudit});
            // 
            // gvUnAudit
            // 
            this.gvUnAudit.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvUnAudit.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvUnAudit.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvUnAudit.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvUnAudit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn3,
            this.gridColumn53,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn58});
            this.gvUnAudit.GridControl = this.gcUnAudit;
            this.gvUnAudit.IndicatorWidth = 44;
            this.gvUnAudit.Name = "gvUnAudit";
            this.gvUnAudit.OptionsView.ColumnAutoWidth = false;
            this.gvUnAudit.OptionsView.ShowAutoFilterRow = true;
            this.gvUnAudit.OptionsView.ShowGroupPanel = false;
            this.gvUnAudit.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUnAudit_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "发货单号";
            this.gridColumn1.FieldName = "SendNo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "收货方";
            this.gridColumn2.FieldName = "ReceiverName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "发货时间";
            this.gridColumn3.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "SendDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn53
            // 
            this.gridColumn53.Caption = "商品数量";
            this.gridColumn53.FieldName = "ItemCount";
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.OptionsColumn.AllowEdit = false;
            this.gridColumn53.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "物流公司";
            this.gridColumn4.FieldName = "LogisName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "物流单号";
            this.gridColumn5.FieldName = "LogisNo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "联系电话";
            this.gridColumn6.FieldName = "ReceiverPhone";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "运费";
            this.gridColumn7.FieldName = "LogisFee";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "司机";
            this.gridColumn8.FieldName = "Driver";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            // 
            // gridColumn58
            // 
            this.gridColumn58.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(185)))), ((int)(((byte)(183)))));
            this.gridColumn58.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn58.Caption = "备注";
            this.gridColumn58.FieldName = "Remark";
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 10;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcItem);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 128);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(842, 207);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "商品信息";
            // 
            // gcItem
            // 
            this.gcItem.AutoCallWW = true;
            this.gcItem.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcItem.ColorFieldName = null;
            this.gcItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItem.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcItem.ImageFields")));
            this.gcItem.Location = new System.Drawing.Point(2, 22);
            this.gcItem.MainView = this.gvItem;
            this.gcItem.Name = "gcItem";
            this.gcItem.PopupMnu = null;
            this.gcItem.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcItem.PopupTextFields")));
            this.gcItem.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcItem.PopupTextFieldsReadOnly")));
            this.gcItem.PropName = "PropName";
            this.gcItem.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gcItem.PrvCityDistrict")));
            this.gcItem.RightMenu = null;
            this.gcItem.RowCellColorStyleSource = null;
            this.gcItem.ShadowDataSource = null;
            this.gcItem.ShadowDataSourceKey = "Guid";
            this.gcItem.ShowIndicator = true;
            this.gcItem.ShowRowNumber = true;
            this.gcItem.Size = new System.Drawing.Size(838, 183);
            this.gcItem.TabIndex = 2;
            this.gcItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItem});
            // 
            // gvItem
            // 
            this.gvItem.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvItem.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvItem.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvItem.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvItem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn62,
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn63,
            this.gridColumn64,
            this.gridColumn65,
            this.gridColumn41,
            this.gridColumn42});
            this.gvItem.GridControl = this.gcItem;
            this.gvItem.IndicatorWidth = 44;
            this.gvItem.Name = "gvItem";
            this.gvItem.OptionsBehavior.Editable = false;
            this.gvItem.OptionsView.ColumnAutoWidth = false;
            this.gvItem.OptionsView.ShowAutoFilterRow = true;
            this.gvItem.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "仓库";
            this.gridColumn35.FieldName = "WareName";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 7;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "区域";
            this.gridColumn36.FieldName = "AreaName";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 8;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "库位";
            this.gridColumn37.FieldName = "LocName";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 9;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "收货方";
            this.gridColumn38.FieldName = "SuppName";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 0;
            // 
            // gridColumn62
            // 
            this.gridColumn62.Caption = "生产单号";
            this.gridColumn62.FieldName = "PurchNo";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 1;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "商品编码";
            this.gridColumn39.FieldName = "OuterIid";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 2;
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "规格编码";
            this.gridColumn40.FieldName = "OuterSkuId";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 3;
            // 
            // gridColumn63
            // 
            this.gridColumn63.Caption = "仿真皮料";
            this.gridColumn63.FieldName = "GenuineSurface";
            this.gridColumn63.Name = "gridColumn63";
            this.gridColumn63.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn63.Visible = true;
            this.gridColumn63.VisibleIndex = 4;
            // 
            // gridColumn64
            // 
            this.gridColumn64.Caption = "仿皮料";
            this.gridColumn64.FieldName = "ImitSurface";
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn64.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn64.Visible = true;
            this.gridColumn64.VisibleIndex = 5;
            // 
            // gridColumn65
            // 
            this.gridColumn65.Caption = "皮料";
            this.gridColumn65.FieldName = "Surface";
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn65.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn65.Visible = true;
            this.gridColumn65.VisibleIndex = 6;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "出库数";
            this.gridColumn41.FieldName = "SendNum";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.AllowEdit = false;
            this.gridColumn41.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 10;
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "备注";
            this.gridColumn42.FieldName = "Remark";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.AllowEdit = false;
            this.gridColumn42.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 11;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "购方经手人";
            this.gridColumn9.FieldName = "RecvOprUser";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // PrintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 373);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "PrintView";
            this.Text = "出库单打印";
            this.Load += new System.EventHandler(this.PrintView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrinter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelSpinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUnAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private FAC.Login.Controls.BtnCtl btnPrint;
        private FASControls.BusControls.CmbPrinter cmbPrinter;
        private FASControls.LabelSpinEdit labelSpinEdit1;
        private FASControls.GridControlEx gcUnAudit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUnAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn58;
        private FASControls.GridControlEx gcItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn63;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn64;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn65;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}