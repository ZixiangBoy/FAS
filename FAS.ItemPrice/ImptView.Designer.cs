namespace FAS.ItemPrice {
    partial class ImptView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImptView));
            this.gridControlEx1 = new Ultra.FASControls.GridControlEx();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChk
            // 
            this.btnChk.Click += new System.EventHandler(this.btnChk_Click);
            // 
            // btnImp
            // 
            this.btnImp.Click += new System.EventHandler(this.btnImp_Click);
            // 
            // fileBrowser1
            // 
            this.fileBrowser1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.fileBrowser1_ButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(683, 39);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(-352, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-437, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(687, 401);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gridControlEx1);
            this.pnlFill.Size = new System.Drawing.Size(687, 355);
            this.pnlFill.Controls.SetChildIndex(this.panelControl1, 0);
            this.pnlFill.Controls.SetChildIndex(this.gridControlEx1, 0);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 355);
            this.pnlBottom.Size = new System.Drawing.Size(687, 46);
            // 
            // gridControlEx1
            // 
            this.gridControlEx1.AutoCallWW = true;
            this.gridControlEx1.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gridControlEx1.ColorFieldName = null;
            this.gridControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEx1.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.ImageFields")));
            this.gridControlEx1.Location = new System.Drawing.Point(2, 41);
            this.gridControlEx1.MainView = this.gridView1;
            this.gridControlEx1.Name = "gridControlEx1";
            this.gridControlEx1.PopupMnu = null;
            this.gridControlEx1.PopupTextFields = null;
            this.gridControlEx1.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.PopupTextFieldsReadOnly")));
            this.gridControlEx1.PropName = "PropName";
            this.gridControlEx1.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.PrvCityDistrict")));
            this.gridControlEx1.RightMenu = null;
            this.gridControlEx1.RowCellColorStyleSource = null;
            this.gridControlEx1.ShadowDataSource = null;
            this.gridControlEx1.ShadowDataSourceKey = "Guid";
            this.gridControlEx1.ShowIndicator = true;
            this.gridControlEx1.ShowRowNumber = true;
            this.gridControlEx1.Size = new System.Drawing.Size(683, 312);
            this.gridControlEx1.TabIndex = 2;
            this.gridControlEx1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControlEx1;
            this.gridView1.IndicatorWidth = 44;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "商品编码";
            this.gridColumn1.FieldName = "OuterIid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "规格编码";
            this.gridColumn2.FieldName = "OuterSkuId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "商标";
            this.gridColumn5.FieldName = "TradeMark";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "真皮价格";
            this.gridColumn7.FieldName = "SurfacePrice";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "验证结果";
            this.gridColumn3.FieldName = "Remark";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "环保皮价格";
            this.gridColumn4.FieldName = "EnvSurfacePrice";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "仿真皮价格";
            this.gridColumn6.FieldName = "GenSurfacePrice";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // ImptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 401);
            this.GridControl = this.gridControlEx1;
            this.Name = "ImptView";
            this.Text = "商品售价";
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ultra.FASControls.GridControlEx gridControlEx1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;



    }
}