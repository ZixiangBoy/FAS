namespace FAS.PermitRole
{
    partial class EdtView
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gtRole = new Ultra.FASControls.LabelGridEdit();
            this.labelGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.treeCtl1 = new FAC.Login.Controls.TreeCtl();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gtRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(657, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(558, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(461, 428);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.panelControl2);
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(461, 382);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 382);
            this.pnlBottom.Size = new System.Drawing.Size(461, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gtRole);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(457, 36);
            this.panelControl1.TabIndex = 0;
            // 
            // gtRole
            // 
            this.gtRole.ClearButtonText = "清除所选";
            this.gtRole.ColumnCaption = "角色";
            this.gtRole.DisplayMember = "Name";
            this.gtRole.EditValue = "";
            this.gtRole.LabelText = "角色";
            this.gtRole.Location = new System.Drawing.Point(10, 7);
            this.gtRole.Name = "gtRole";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gtRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "角色", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "清除所选", null, null, true)});
            this.gtRole.Properties.DisplayMember = "Name";
            this.gtRole.Properties.NullText = "";
            this.gtRole.Properties.ValueMember = "Guid";
            this.gtRole.Properties.View = this.labelGridEdit1View;
            this.gtRole.ShowClearButton = true;
            this.gtRole.Size = new System.Drawing.Size(358, 21);
            this.gtRole.TabIndex = 1;
            this.gtRole.ValueMember = "Guid";
            this.gtRole.EditValueChanged += new System.EventHandler(this.gtRole_EditValueChanged);
            // 
            // labelGridEdit1View
            // 
            this.labelGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.labelGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.labelGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.labelGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.labelGridEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3});
            this.labelGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.labelGridEdit1View.Name = "labelGridEdit1View";
            this.labelGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.labelGridEdit1View.OptionsBehavior.Editable = false;
            this.labelGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.labelGridEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.labelGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "角色";
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.treeCtl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 38);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(457, 342);
            this.panelControl2.TabIndex = 1;
            // 
            // treeCtl1
            // 
            this.treeCtl1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCtl1.Location = new System.Drawing.Point(2, 2);
            this.treeCtl1.Name = "treeCtl1";
            this.treeCtl1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeCtl1.OptionsView.ShowCheckBoxes = true;
            this.treeCtl1.OptionsView.ShowColumns = false;
            this.treeCtl1.OptionsView.ShowIndicator = false;
            this.treeCtl1.Size = new System.Drawing.Size(453, 338);
            this.treeCtl1.TabIndex = 1;
            this.treeCtl1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeCtl1_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.FieldName = "MenuName";
            this.treeListColumn1.MinWidth = 32;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // EdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 428);
            this.Name = "EdtView";
            this.Text = "权限设置";
            this.Load += new System.EventHandler(this.EdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gtRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private Ultra.FASControls.LabelGridEdit gtRole;
        private DevExpress.XtraGrid.Views.Grid.GridView labelGridEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private FAC.Login.Controls.TreeCtl treeCtl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}