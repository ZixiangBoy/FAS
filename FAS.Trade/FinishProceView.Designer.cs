namespace FAS.Trade {
    partial class FinishProceView {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishProceView));
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridControlEx2 = new Ultra.FASControls.GridControlEx();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlEx1 = new Ultra.FASControls.GridControlEx();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(290, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(205, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(516, 386);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.btnDel);
            this.pnlFill.Controls.Add(this.btnAdd);
            this.pnlFill.Controls.Add(this.groupBox2);
            this.pnlFill.Controls.Add(this.groupBox1);
            this.pnlFill.Size = new System.Drawing.Size(516, 340);
            this.pnlFill.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFill_Paint);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 340);
            this.pnlBottom.Size = new System.Drawing.Size(516, 46);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControlEx1);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 322);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加工工人";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridControlEx2);
            this.groupBox2.Location = new System.Drawing.Point(311, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 322);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工人信息";
            // 
            // gridControlEx2
            // 
            this.gridControlEx2.AutoCallWW = true;
            this.gridControlEx2.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gridControlEx2.ColorFieldName = null;
            this.gridControlEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEx2.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx2.ImageFields")));
            this.gridControlEx2.Location = new System.Drawing.Point(3, 18);
            this.gridControlEx2.MainView = this.gridView2;
            this.gridControlEx2.Name = "gridControlEx2";
            this.gridControlEx2.PopupMnu = null;
            this.gridControlEx2.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx2.PopupTextFields")));
            this.gridControlEx2.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx2.PopupTextFieldsReadOnly")));
            this.gridControlEx2.PropName = "PropName";
            this.gridControlEx2.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx2.PrvCityDistrict")));
            this.gridControlEx2.RightMenu = null;
            this.gridControlEx2.RowCellColorStyleSource = null;
            this.gridControlEx2.ShadowDataSource = null;
            this.gridControlEx2.ShadowDataSourceKey = "Guid";
            this.gridControlEx2.ShowIndicator = true;
            this.gridControlEx2.ShowRowNumber = true;
            this.gridControlEx2.Size = new System.Drawing.Size(194, 301);
            this.gridControlEx2.TabIndex = 0;
            this.gridControlEx2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView2.GridControl = this.gridControlEx2;
            this.gridView2.IndicatorWidth = 44;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(223, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "<<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(223, 187);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 35);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = ">>";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "姓名";
            this.gridColumn1.FieldName = "RealName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "部门";
            this.gridColumn2.FieldName = "DeptName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridControlEx1
            // 
            this.gridControlEx1.AutoCallWW = true;
            this.gridControlEx1.CellStyleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gridControlEx1.ColorFieldName = null;
            this.gridControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEx1.ImageFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.ImageFields")));
            this.gridControlEx1.Location = new System.Drawing.Point(3, 18);
            this.gridControlEx1.MainView = this.gridView1;
            this.gridControlEx1.Name = "gridControlEx1";
            this.gridControlEx1.PopupMnu = null;
            this.gridControlEx1.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.PopupTextFields")));
            this.gridControlEx1.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.PopupTextFieldsReadOnly")));
            this.gridControlEx1.PropName = "PropName";
            this.gridControlEx1.PrvCityDistrict = ((System.Collections.Generic.List<string>)(resources.GetObject("gridControlEx1.PrvCityDistrict")));
            this.gridControlEx1.RightMenu = null;
            this.gridControlEx1.RowCellColorStyleSource = null;
            this.gridControlEx1.ShadowDataSource = null;
            this.gridControlEx1.ShadowDataSourceKey = "Guid";
            this.gridControlEx1.ShowIndicator = true;
            this.gridControlEx1.ShowRowNumber = true;
            this.gridControlEx1.Size = new System.Drawing.Size(194, 301);
            this.gridControlEx1.TabIndex = 1;
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
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControlEx1;
            this.gridView1.IndicatorWidth = 44;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "姓名";
            this.gridColumn3.FieldName = "RealName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "部门";
            this.gridColumn4.FieldName = "DeptName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // FinishProceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 386);
            this.Name = "FinishProceView";
            this.Text = "完结";
            this.Load += new System.EventHandler(this.FinishProceView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ultra.FASControls.GridControlEx gridControlEx2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Ultra.FASControls.GridControlEx gridControlEx1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}