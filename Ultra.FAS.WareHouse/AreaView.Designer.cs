﻿namespace Ultra.FAS.WareHouse
{
    partial class AreaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaView));
            this.gridControlEx1 = new Ultra.FASControls.GridControlEx();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "New_16x16.png");
            this.imageList1.Images.SetKeyName(1, "New_32x32.png");
            this.imageList1.Images.SetKeyName(2, "Edit_16x16.png");
            this.imageList1.Images.SetKeyName(3, "Edit_32x32.png");
            this.imageList1.Images.SetKeyName(4, "Delete_16x16.png");
            this.imageList1.Images.SetKeyName(5, "Delete_32x32.png");
            this.imageList1.Images.SetKeyName(6, "Refresh_16x16.png");
            this.imageList1.Images.SetKeyName(7, "Refresh_32x32.png");
            this.imageList1.Images.SetKeyName(8, "Export_16x16.png");
            this.imageList1.Images.SetKeyName(9, "Export_32x32.png");
            this.imageList1.Images.SetKeyName(10, "GroupsAndItems.Icon.png");
            this.imageList1.Images.SetKeyName(11, "ExportXlsxLarge.png");
            this.imageList1.Images.SetKeyName(12, "ExportToExcel_16x16.png");
            this.imageList1.Images.SetKeyName(13, "ReView.png");
            this.imageList1.Images.SetKeyName(14, "agt_action_success.png");
            this.imageList1.Images.SetKeyName(15, "folder_deny.png");
            this.imageList1.Images.SetKeyName(16, "refuse.png");
            this.imageList1.Images.SetKeyName(17, "old_edit_redo.png");
            this.imageList1.Images.SetKeyName(18, "old_edit_undo.png");
            this.imageList1.Images.SetKeyName(19, "lock.png");
            this.imageList1.Images.SetKeyName(20, "CustomerInfoCards_32x32.png");
            this.imageList1.Images.SetKeyName(21, "UserKey_32x32.png");
            this.imageList1.Images.SetKeyName(22, "unlock_yellow.png");
            this.imageList1.Images.SetKeyName(23, "media_playlist_clear.png");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            this.imageList1.Images.SetKeyName(27, "");
            this.imageList1.Images.SetKeyName(28, "");
            this.imageList1.Images.SetKeyName(29, "");
            this.imageList1.Images.SetKeyName(30, "");
            this.imageList1.Images.SetKeyName(31, "");
            this.imageList1.Images.SetKeyName(32, "");
            this.imageList1.Images.SetKeyName(33, "");
            this.imageList1.Images.SetKeyName(34, "");
            this.imageList1.Images.SetKeyName(35, "");
            this.imageList1.Images.SetKeyName(36, "");
            this.imageList1.Images.SetKeyName(37, "");
            // 
            // gridControlEx1
            // 
            this.gridControlEx1.ColorFieldName = null;
            this.gridControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEx1.Location = new System.Drawing.Point(0, 31);
            this.gridControlEx1.MainView = this.gridView1;
            this.gridControlEx1.MenuManager = this.baseBarMgr;
            this.gridControlEx1.Name = "gridControlEx1";
            this.gridControlEx1.ShowIndicator = true;
            this.gridControlEx1.Size = new System.Drawing.Size(1364, 454);
            this.gridControlEx1.TabIndex = 4;
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
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControlEx1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "仓库名称";
            this.gridColumn1.FieldName = "WareName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "区域代码";
            this.gridColumn2.FieldName = "AreaCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "区域名称";
            this.gridColumn3.FieldName = "AreaName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "默认";
            this.gridColumn4.FieldName = "IsDef";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "是否启用";
            this.gridColumn5.FieldName = "IsUsing";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // AreaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 485);
            this.Controls.Add(this.gridControlEx1);
            this.Name = "AreaView";
            this.Text = "AreaView";
            this.Load += new System.EventHandler(this.AreaView_Load);
            this.Controls.SetChildIndex(this.gridControlEx1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FASControls.GridControlEx gridControlEx1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}