namespace Ultra.FAS.Procedure
{
    partial class EdtMaterials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdtMaterials));
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.gcMaterial = new Ultra.FASControls.GridControlEx();
            this.gvMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpEdtProduce = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.lookUpEdtProduceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpEdtMaterial = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.lookUpEdtMaterialView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new FAC.Login.Controls.BtnCtl();
            this.btnAdd = new FAC.Login.Controls.BtnCtl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtProduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtProduceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtMaterialView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1337, 4);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1252, 5);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(640, 246);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gcMaterial);
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(640, 200);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 200);
            this.pnlBottom.Size = new System.Drawing.Size(640, 46);
            // 
            // gcMaterial
            // 
            this.gcMaterial.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gcMaterial.ColorFieldName = null;
            this.gcMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMaterial.Editable = true;
            this.gcMaterial.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcMaterial.ImageFields")));
            this.gcMaterial.Location = new System.Drawing.Point(2, 2);
            this.gcMaterial.MainView = this.gvMaterial;
            this.gcMaterial.Name = "gcMaterial";
            this.gcMaterial.PopupMnu = null;
            this.gcMaterial.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gcMaterial.PopupTextFields")));
            this.gcMaterial.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gcMaterial.PopupTextFieldsReadOnly")));
            this.gcMaterial.PropName = "PropName";
            this.gcMaterial.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.lookUpEdtProduce,
            this.lookUpEdtMaterial});
            this.gcMaterial.RightMenu = null;
            this.gcMaterial.RowCellColorStyleSource = null;
            this.gcMaterial.ShadowDataSource = null;
            this.gcMaterial.ShadowDataSourceKey = "Guid";
            this.gcMaterial.ShowIndicator = true;
            this.gcMaterial.ShowRowNumber = true;
            this.gcMaterial.Size = new System.Drawing.Size(636, 166);
            this.gcMaterial.TabIndex = 0;
            this.gcMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaterial});
            // 
            // gvMaterial
            // 
            this.gvMaterial.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvMaterial.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvMaterial.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvMaterial.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvMaterial.GridControl = this.gcMaterial;
            this.gvMaterial.IndicatorWidth = 44;
            this.gvMaterial.Name = "gvMaterial";
            this.gvMaterial.OptionsView.ColumnAutoWidth = false;
            this.gvMaterial.OptionsView.ShowAutoFilterRow = true;
            this.gvMaterial.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "商品编码";
            this.gridColumn1.FieldName = "OuterIid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "规格编码";
            this.gridColumn2.FieldName = "OuterSkuId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "工序";
            this.gridColumn3.ColumnEdit = this.lookUpEdtProduce;
            this.gridColumn3.FieldName = "ProcedureName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // lookUpEdtProduce
            // 
            this.lookUpEdtProduce.AutoHeight = false;
            this.lookUpEdtProduce.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdtProduce.DisplayMember = "ProcedureName";
            this.lookUpEdtProduce.Name = "lookUpEdtProduce";
            this.lookUpEdtProduce.NullText = "[请选择]";
            this.lookUpEdtProduce.ValueMember = "ProcedureName";
            this.lookUpEdtProduce.View = this.lookUpEdtProduceView;
            this.lookUpEdtProduce.EditValueChanged += new System.EventHandler(this.lookUpEdtProduce_EditValueChanged);
            // 
            // lookUpEdtProduceView
            // 
            this.lookUpEdtProduceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8});
            this.lookUpEdtProduceView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.lookUpEdtProduceView.Name = "lookUpEdtProduceView";
            this.lookUpEdtProduceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.lookUpEdtProduceView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "工序";
            this.gridColumn8.FieldName = "ProcedureName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "原材料编码";
            this.gridColumn4.ColumnEdit = this.lookUpEdtMaterial;
            this.gridColumn4.FieldName = "MaterialNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // lookUpEdtMaterial
            // 
            this.lookUpEdtMaterial.AutoHeight = false;
            this.lookUpEdtMaterial.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdtMaterial.DisplayMember = "MaterialNo";
            this.lookUpEdtMaterial.Name = "lookUpEdtMaterial";
            this.lookUpEdtMaterial.NullText = "[请选择]";
            this.lookUpEdtMaterial.ValueMember = "MaterialNo";
            this.lookUpEdtMaterial.View = this.lookUpEdtMaterialView;
            this.lookUpEdtMaterial.EditValueChanged += new System.EventHandler(this.lookUpEdtMaterial_EditValueChanged);
            // 
            // lookUpEdtMaterialView
            // 
            this.lookUpEdtMaterialView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.lookUpEdtMaterialView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.lookUpEdtMaterialView.Name = "lookUpEdtMaterialView";
            this.lookUpEdtMaterialView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.lookUpEdtMaterialView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "原材料编码";
            this.gridColumn9.FieldName = "MaterialNo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "原材料名称";
            this.gridColumn10.FieldName = "MaterialName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "单位";
            this.gridColumn11.FieldName = "Unit";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "原材料名称";
            this.gridColumn5.FieldName = "MaterialName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "用量";
            this.gridColumn6.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn6.FieldName = "Dosage";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "单位";
            this.gridColumn7.FieldName = "Unit";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDel);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 168);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(636, 30);
            this.panelControl1.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(76, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(60, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除行";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加行";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // EdtMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 246);
            this.Name = "EdtMaterials";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.EdtMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtProduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtProduceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdtMaterialView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private FASControls.GridControlEx gcMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private FAC.Login.Controls.BtnCtl btnDel;
        private FAC.Login.Controls.BtnCtl btnAdd;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit lookUpEdtProduce;
        private DevExpress.XtraGrid.Views.Grid.GridView lookUpEdtProduceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit lookUpEdtMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView lookUpEdtMaterialView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}