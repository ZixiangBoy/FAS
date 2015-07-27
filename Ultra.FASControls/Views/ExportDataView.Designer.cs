namespace Ultra.FASControls.Views
{
    partial class ExportDataView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDataView));
            this.gc = new Ultra.FASControls.GridControlEx();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(433, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(348, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(530, 353);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gc);
            this.pnlFill.Size = new System.Drawing.Size(530, 307);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 307);
            this.pnlBottom.Size = new System.Drawing.Size(530, 46);
            // 
            // gc
            // 
            this.gc.ColorFieldName = null;
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(2, 2);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.PopupMnu = null;
            this.gc.PopupTextFields = ((System.Collections.Generic.List<string>)(resources.GetObject("gc.PopupTextFields")));
            this.gc.PopupTextFieldsReadOnly = ((System.Collections.Generic.List<string>)(resources.GetObject("gc.PopupTextFieldsReadOnly")));
            this.gc.RightMenu = null;
            this.gc.ShowIndicator = true;
            this.gc.ShowRowNumber = true;
            this.gc.Size = new System.Drawing.Size(526, 303);
            this.gc.TabIndex = 0;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gv.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gv.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv.GridControl = this.gc;
            this.gv.IndicatorWidth = 44;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // ExportDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 353);
            this.Name = "ExportDataView";
            this.Text = "数据导出";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public GridControlEx gc;
        public DevExpress.XtraGrid.Views.Grid.GridView gv;
    }
}