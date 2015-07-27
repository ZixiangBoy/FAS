namespace FAS.PermitRole
{
    partial class RoleUser
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gtRole = new Ultra.FASControls.LabelGridEdit();
            this.labelGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnrightall = new FAC.Login.Controls.BtnCtl();
            this.btnRight = new FAC.Login.Controls.BtnCtl();
            this.btnLeftAll = new FAC.Login.Controls.BtnCtl();
            this.btnleft = new FAC.Login.Controls.BtnCtl();
            this.gcRight = new Ultra.FASControls.GridControlEx();
            this.gvRight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLeft = new Ultra.FASControls.GridControlEx();
            this.gvLeft = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gcRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(590, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(505, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(496, 424);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.panelControl2);
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(496, 378);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 378);
            this.pnlBottom.Size = new System.Drawing.Size(496, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gtRole);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(492, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // gtRole
            // 
            this.gtRole.ClearButtonText = "清除所选";
            this.gtRole.ColumnCaption = "角色";
            this.gtRole.DisplayMember = "Name";
            this.gtRole.EditValue = "";
            this.gtRole.LabelText = "角色";
            this.gtRole.Location = new System.Drawing.Point(10, 5);
            this.gtRole.Name = "gtRole";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gtRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "角色", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "清除所选", null, null, true)});
            this.gtRole.Properties.DisplayMember = "Name";
            this.gtRole.Properties.NullText = "";
            this.gtRole.Properties.ValueMember = "Guid";
            this.gtRole.Properties.View = this.labelGridEdit1View;
            this.gtRole.ShowClearButton = true;
            this.gtRole.Size = new System.Drawing.Size(429, 21);
            this.gtRole.TabIndex = 0;
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
            this.panelControl2.Controls.Add(this.btnrightall);
            this.panelControl2.Controls.Add(this.btnRight);
            this.panelControl2.Controls.Add(this.btnLeftAll);
            this.panelControl2.Controls.Add(this.btnleft);
            this.panelControl2.Controls.Add(this.gcRight);
            this.panelControl2.Controls.Add(this.gcLeft);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 37);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(492, 339);
            this.panelControl2.TabIndex = 1;
            // 
            // btnrightall
            // 
            this.btnrightall.Location = new System.Drawing.Point(200, 200);
            this.btnrightall.Name = "btnrightall";
            this.btnrightall.Size = new System.Drawing.Size(75, 35);
            this.btnrightall.TabIndex = 1;
            this.btnrightall.Text = ">>";
            this.btnrightall.Click += new System.EventHandler(this.btnrightall_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(200, 142);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 35);
            this.btnRight.TabIndex = 1;
            this.btnRight.Text = ">";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.Location = new System.Drawing.Point(200, 83);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(75, 35);
            this.btnLeftAll.TabIndex = 1;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // btnleft
            // 
            this.btnleft.Location = new System.Drawing.Point(200, 21);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(75, 35);
            this.btnleft.TabIndex = 1;
            this.btnleft.Text = "<";
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click);
            // 
            // gcRight
            // 
            this.gcRight.ColorFieldName = null;
            this.gcRight.Location = new System.Drawing.Point(296, 6);
            this.gcRight.MainView = this.gvRight;
            this.gcRight.Name = "gcRight";
            this.gcRight.ShowIndicator = true;
            this.gcRight.ShowRowNumber = true;
            this.gcRight.Size = new System.Drawing.Size(186, 328);
            this.gcRight.TabIndex = 0;
            this.gcRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRight});
            // 
            // gvRight
            // 
            this.gvRight.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvRight.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvRight.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvRight.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvRight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.gvRight.GridControl = this.gcRight;
            this.gvRight.Name = "gvRight";
            this.gvRight.OptionsBehavior.Editable = false;
            this.gvRight.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvRight.OptionsView.ShowAutoFilterRow = true;
            this.gvRight.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "用户";
            this.gridColumn2.FieldName = "UserName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gcLeft
            // 
            this.gcLeft.ColorFieldName = null;
            this.gcLeft.Location = new System.Drawing.Point(5, 6);
            this.gcLeft.MainView = this.gvLeft;
            this.gcLeft.Name = "gcLeft";
            this.gcLeft.ShowIndicator = true;
            this.gcLeft.ShowRowNumber = true;
            this.gcLeft.Size = new System.Drawing.Size(172, 328);
            this.gcLeft.TabIndex = 0;
            this.gcLeft.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLeft});
            // 
            // gvLeft
            // 
            this.gvLeft.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvLeft.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvLeft.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gvLeft.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvLeft.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvLeft.GridControl = this.gcLeft;
            this.gvLeft.Name = "gvLeft";
            this.gvLeft.OptionsBehavior.Editable = false;
            this.gvLeft.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvLeft.OptionsView.ShowAutoFilterRow = true;
            this.gvLeft.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "用户";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // RoleUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 424);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RoleUser";
            this.Text = "角色用户";
            this.Load += new System.EventHandler(this.RoleUser_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gcRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private FAC.Login.Controls.BtnCtl btnrightall;
        private FAC.Login.Controls.BtnCtl btnRight;
        private FAC.Login.Controls.BtnCtl btnLeftAll;
        private FAC.Login.Controls.BtnCtl btnleft;
        private Ultra.FASControls.GridControlEx gcRight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Ultra.FASControls.GridControlEx gcLeft;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLeft;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Ultra.FASControls.LabelGridEdit gtRole;
        private DevExpress.XtraGrid.Views.Grid.GridView labelGridEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}