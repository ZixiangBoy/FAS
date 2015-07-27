namespace Ultra.FAS.Login
{
    partial class MenuView
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.treeCtl1 = new FAC.Login.Controls.TreeCtl();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.collapsibleSplitter1 = new Ultra.FASControls.CollapsibleSplitter();
            this.groupPanel1 = new FAC.Login.Controls.GroupPanel();
            this.btnCtl8 = new FAC.Login.Controls.BtnCtl();
            this.txtmnuAsm = new Ultra.FASControls.LabelTextBox();
            this.btnCtl7 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl6 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl5 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl4 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl3 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl2 = new FAC.Login.Controls.BtnCtl();
            this.btnCtl1 = new FAC.Login.Controls.BtnCtl();
            this.checkCtl1 = new FAC.Login.Controls.CheckCtl();
            this.txtModName = new Ultra.FASControls.LabelTextBox();
            this.txtmnugrpname = new Ultra.FASControls.LabelTextBox();
            this.txtMenuName = new Ultra.FASControls.LabelTextBox();
            this.fdlg = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuAsm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnugrpname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeCtl1
            // 
            this.treeCtl1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeCtl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeCtl1.Location = new System.Drawing.Point(0, 0);
            this.treeCtl1.Name = "treeCtl1";
            this.treeCtl1.OptionsBehavior.DragNodes = true;
            this.treeCtl1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeCtl1.OptionsView.ShowColumns = false;
            this.treeCtl1.OptionsView.ShowIndicator = false;
            this.treeCtl1.Size = new System.Drawing.Size(258, 438);
            this.treeCtl1.TabIndex = 0;
            this.treeCtl1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeCtl1_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.FieldName = "MenuName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.collapsibleSplitter1.ControlToHide = this.treeCtl1;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(258, 0);
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.TabIndex = 1;
            this.collapsibleSplitter1.TabStop = false;
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = Ultra.FASControls.VisualStyles.Mozilla;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Controls.Add(this.btnCtl8);
            this.groupPanel1.Controls.Add(this.txtmnuAsm);
            this.groupPanel1.Controls.Add(this.btnCtl7);
            this.groupPanel1.Controls.Add(this.btnCtl6);
            this.groupPanel1.Controls.Add(this.btnCtl5);
            this.groupPanel1.Controls.Add(this.btnCtl4);
            this.groupPanel1.Controls.Add(this.btnCtl3);
            this.groupPanel1.Controls.Add(this.btnCtl2);
            this.groupPanel1.Controls.Add(this.btnCtl1);
            this.groupPanel1.Controls.Add(this.checkCtl1);
            this.groupPanel1.Controls.Add(this.txtModName);
            this.groupPanel1.Controls.Add(this.txtmnugrpname);
            this.groupPanel1.Controls.Add(this.txtMenuName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(266, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(483, 438);
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "系统菜单编辑";
            // 
            // btnCtl8
            // 
            this.btnCtl8.Location = new System.Drawing.Point(15, 61);
            this.btnCtl8.Name = "btnCtl8";
            this.btnCtl8.Size = new System.Drawing.Size(109, 23);
            this.btnCtl8.TabIndex = 9;
            this.btnCtl8.Text = "保存菜单组名";
            this.btnCtl8.Click += new System.EventHandler(this.btnCtl8_Click);
            // 
            // txtmnuAsm
            // 
            this.txtmnuAsm.EditValue = "";
            this.txtmnuAsm.LabelText = "AsmName";
            this.txtmnuAsm.Location = new System.Drawing.Point(15, 159);
            this.txtmnuAsm.Name = "txtmnuAsm";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtmnuAsm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "AsmName", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtmnuAsm.Size = new System.Drawing.Size(464, 21);
            this.txtmnuAsm.TabIndex = 8;
            // 
            // btnCtl7
            // 
            this.btnCtl7.Location = new System.Drawing.Point(15, 236);
            this.btnCtl7.Name = "btnCtl7";
            this.btnCtl7.Size = new System.Drawing.Size(359, 23);
            this.btnCtl7.TabIndex = 7;
            this.btnCtl7.Text = "保存";
            this.btnCtl7.Click += new System.EventHandler(this.btnCtl7_Click);
            // 
            // btnCtl6
            // 
            this.btnCtl6.Location = new System.Drawing.Point(276, 329);
            this.btnCtl6.Name = "btnCtl6";
            this.btnCtl6.Size = new System.Drawing.Size(98, 23);
            this.btnCtl6.TabIndex = 6;
            this.btnCtl6.Text = "导出菜单";
            this.btnCtl6.Click += new System.EventHandler(this.btnCtl6_Click);
            // 
            // btnCtl5
            // 
            this.btnCtl5.Location = new System.Drawing.Point(276, 281);
            this.btnCtl5.Name = "btnCtl5";
            this.btnCtl5.Size = new System.Drawing.Size(98, 23);
            this.btnCtl5.TabIndex = 5;
            this.btnCtl5.Text = "删除所选";
            this.btnCtl5.Click += new System.EventHandler(this.btnCtl5_Click);
            // 
            // btnCtl4
            // 
            this.btnCtl4.Location = new System.Drawing.Point(143, 329);
            this.btnCtl4.Name = "btnCtl4";
            this.btnCtl4.Size = new System.Drawing.Size(109, 23);
            this.btnCtl4.TabIndex = 4;
            this.btnCtl4.Text = "保存菜单";
            this.btnCtl4.Click += new System.EventHandler(this.btnCtl4_Click);
            // 
            // btnCtl3
            // 
            this.btnCtl3.Location = new System.Drawing.Point(15, 329);
            this.btnCtl3.Name = "btnCtl3";
            this.btnCtl3.Size = new System.Drawing.Size(109, 23);
            this.btnCtl3.TabIndex = 4;
            this.btnCtl3.Text = "加载最新菜单";
            this.btnCtl3.Click += new System.EventHandler(this.btnCtl3_Click);
            // 
            // btnCtl2
            // 
            this.btnCtl2.Location = new System.Drawing.Point(143, 281);
            this.btnCtl2.Name = "btnCtl2";
            this.btnCtl2.Size = new System.Drawing.Size(109, 23);
            this.btnCtl2.TabIndex = 3;
            this.btnCtl2.Text = "添加子菜单";
            this.btnCtl2.Click += new System.EventHandler(this.btnCtl2_Click);
            // 
            // btnCtl1
            // 
            this.btnCtl1.Location = new System.Drawing.Point(15, 281);
            this.btnCtl1.Name = "btnCtl1";
            this.btnCtl1.Size = new System.Drawing.Size(109, 23);
            this.btnCtl1.TabIndex = 3;
            this.btnCtl1.Text = "添加顶级菜单";
            this.btnCtl1.Click += new System.EventHandler(this.btnCtl1_Click);
            // 
            // checkCtl1
            // 
            this.checkCtl1.EditValue = true;
            this.checkCtl1.Location = new System.Drawing.Point(13, 192);
            this.checkCtl1.Name = "checkCtl1";
            this.checkCtl1.Properties.Caption = "是否启用";
            this.checkCtl1.Size = new System.Drawing.Size(97, 19);
            this.checkCtl1.TabIndex = 2;
            // 
            // txtModName
            // 
            this.txtModName.LabelText = "模块类名";
            this.txtModName.Location = new System.Drawing.Point(15, 132);
            this.txtModName.Name = "txtModName";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtModName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "模块类名", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtModName.Size = new System.Drawing.Size(464, 21);
            this.txtModName.TabIndex = 1;
            // 
            // txtmnugrpname
            // 
            this.txtmnugrpname.LabelText = "菜单组名";
            this.txtmnugrpname.Location = new System.Drawing.Point(15, 34);
            this.txtmnugrpname.Name = "txtmnugrpname";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtmnugrpname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "菜单组名", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtmnugrpname.Size = new System.Drawing.Size(464, 21);
            this.txtmnugrpname.TabIndex = 0;
            // 
            // txtMenuName
            // 
            this.txtMenuName.LabelText = "菜单名称";
            this.txtMenuName.Location = new System.Drawing.Point(15, 105);
            this.txtMenuName.Name = "txtMenuName";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtMenuName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "菜单名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtMenuName.Size = new System.Drawing.Size(464, 21);
            this.txtMenuName.TabIndex = 0;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 438);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.collapsibleSplitter1);
            this.Controls.Add(this.treeCtl1);
            this.Name = "MenuView";
            this.Text = "系统菜单编辑";
            this.Load += new System.EventHandler(this.MenuView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuAsm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCtl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnugrpname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.TreeCtl treeCtl1;
        private Ultra.FASControls.CollapsibleSplitter collapsibleSplitter1;
        private FAC.Login.Controls.GroupPanel groupPanel1;
        private FAC.Login.Controls.BtnCtl btnCtl2;
        private FAC.Login.Controls.BtnCtl btnCtl1;
        private FAC.Login.Controls.CheckCtl checkCtl1;
        private Ultra.FASControls.LabelTextBox txtModName;
        private Ultra.FASControls.LabelTextBox txtMenuName;
        private FAC.Login.Controls.BtnCtl btnCtl3;
        private FAC.Login.Controls.BtnCtl btnCtl4;
        private FAC.Login.Controls.BtnCtl btnCtl5;
        private FAC.Login.Controls.BtnCtl btnCtl6;
        private System.Windows.Forms.SaveFileDialog fdlg;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private FAC.Login.Controls.BtnCtl btnCtl7;
        private Ultra.FASControls.LabelTextBox txtmnuAsm;
        private FAC.Login.Controls.BtnCtl btnCtl8;
        private Ultra.FASControls.LabelTextBox txtmnugrpname;
    }
}