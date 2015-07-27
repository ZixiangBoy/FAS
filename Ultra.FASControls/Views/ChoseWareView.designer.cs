namespace Ultra.FASControls.Views
{
    partial class ChoseWareView
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.wareNotVirtualEdt1 = new Ultra.FASControls.BusControls.WareHouseGridEdit();
            this.wareNotVirtualEdt1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wareNotVirtualEdt1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareNotVirtualEdt1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(126, 5);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(41, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(301, 90);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.wareNotVirtualEdt1);
            this.pnlFill.Size = new System.Drawing.Size(301, 44);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 44);
            this.pnlBottom.Size = new System.Drawing.Size(301, 46);
            // 
            // wareNotVirtualEdt1
            // 
            this.wareNotVirtualEdt1.ClearButtonText = "清除所选";
            this.wareNotVirtualEdt1.ColumnCaption = "仓库";
            this.wareNotVirtualEdt1.ColumnItemsEx2 = null;
            this.wareNotVirtualEdt1.DisplayMember = "WareName";
            this.wareNotVirtualEdt1.EditValue = "";
            this.wareNotVirtualEdt1.LabelText = "仓库";
            this.wareNotVirtualEdt1.Location = new System.Drawing.Point(12, 12);
            this.wareNotVirtualEdt1.Name = "wareNotVirtualEdt1";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.wareNotVirtualEdt1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "仓库", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "清除所选", null, null, true)});
            this.wareNotVirtualEdt1.Properties.DisplayMember = "WareName";
            this.wareNotVirtualEdt1.Properties.NullText = "";
            this.wareNotVirtualEdt1.Properties.ValueMember = "WareName";
            this.wareNotVirtualEdt1.Properties.View = this.wareNotVirtualEdt1View;
            this.wareNotVirtualEdt1.SelectedValue = null;
            this.wareNotVirtualEdt1.Size = new System.Drawing.Size(250, 21);
            this.wareNotVirtualEdt1.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须填写";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.wareNotVirtualEdt1, conditionValidationRule1);
            this.wareNotVirtualEdt1.ValueMember = "WareName";
            // 
            // wareNotVirtualEdt1View
            // 
            this.wareNotVirtualEdt1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.wareNotVirtualEdt1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.wareNotVirtualEdt1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.wareNotVirtualEdt1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.wareNotVirtualEdt1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wareNotVirtualEdt1View.Name = "wareNotVirtualEdt1View";
            this.wareNotVirtualEdt1View.OptionsBehavior.AutoPopulateColumns = false;
            this.wareNotVirtualEdt1View.OptionsBehavior.Editable = false;
            this.wareNotVirtualEdt1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wareNotVirtualEdt1View.OptionsView.ShowGroupPanel = false;
            // 
            // ChoseWareView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 90);
            this.Name = "ChoseWareView";
            this.Text = "选择仓库";
            this.Load += new System.EventHandler(this.ChoseWareView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wareNotVirtualEdt1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareNotVirtualEdt1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BusControls.WareHouseGridEdit wareNotVirtualEdt1;
        private DevExpress.XtraGrid.Views.Grid.GridView wareNotVirtualEdt1View;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}