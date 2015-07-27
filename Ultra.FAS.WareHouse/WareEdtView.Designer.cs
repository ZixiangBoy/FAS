namespace Ultra.FAS.WareHouse
{
    partial class WareEdtView
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtcode = new Ultra.FASControls.LabelTextBox();
            this.txtname = new Ultra.FASControls.LabelTextBox();
            this.txtcontact = new Ultra.FASControls.LabelTextBox();
            this.txtmobile = new Ultra.FASControls.LabelTextBox();
            this.txtphone = new Ultra.FASControls.LabelTextBox();
            this.chk = new FAC.Login.Controls.CheckCtl();
            this.txtsquare = new DevExpress.XtraEditors.SpinEdit();
            this.txtvolume = new DevExpress.XtraEditors.SpinEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.chkVirtual = new FAC.Login.Controls.CheckCtl();
            this.chkOutWare = new FAC.Login.Controls.CheckCtl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsquare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvolume.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVirtual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOutWare.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(231, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(146, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(376, 309);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.chkOutWare);
            this.pnlFill.Controls.Add(this.chkVirtual);
            this.pnlFill.Controls.Add(this.txtvolume);
            this.pnlFill.Controls.Add(this.txtsquare);
            this.pnlFill.Controls.Add(this.chk);
            this.pnlFill.Controls.Add(this.txtphone);
            this.pnlFill.Controls.Add(this.txtmobile);
            this.pnlFill.Controls.Add(this.txtcontact);
            this.pnlFill.Controls.Add(this.txtname);
            this.pnlFill.Controls.Add(this.txtcode);
            this.pnlFill.Size = new System.Drawing.Size(376, 263);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 263);
            this.pnlBottom.Size = new System.Drawing.Size(376, 46);
            // 
            // txtcode
            // 
            this.txtcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcode.LabelText = "仓库编码";
            this.txtcode.Location = new System.Drawing.Point(12, 12);
            this.txtcode.Name = "txtcode";
            serializableAppearanceObject7.Options.UseTextOptions = true;
            serializableAppearanceObject7.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "仓库编码", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.txtcode.Size = new System.Drawing.Size(354, 21);
            this.txtcode.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "必须输入";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtcode, conditionValidationRule2);
            // 
            // txtname
            // 
            this.txtname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtname.LabelText = "仓库名称";
            this.txtname.Location = new System.Drawing.Point(12, 39);
            this.txtname.Name = "txtname";
            serializableAppearanceObject6.Options.UseTextOptions = true;
            serializableAppearanceObject6.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "仓库名称", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtname.Size = new System.Drawing.Size(354, 21);
            this.txtname.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "必须输入";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtname, conditionValidationRule1);
            // 
            // txtcontact
            // 
            this.txtcontact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcontact.LabelText = "联系人";
            this.txtcontact.Location = new System.Drawing.Point(12, 66);
            this.txtcontact.Name = "txtcontact";
            serializableAppearanceObject5.Options.UseTextOptions = true;
            serializableAppearanceObject5.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtcontact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "联系人", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.txtcontact.Size = new System.Drawing.Size(354, 21);
            this.txtcontact.TabIndex = 2;
            // 
            // txtmobile
            // 
            this.txtmobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmobile.LabelText = "手机";
            this.txtmobile.Location = new System.Drawing.Point(12, 93);
            this.txtmobile.Name = "txtmobile";
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtmobile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "手机", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtmobile.Size = new System.Drawing.Size(354, 21);
            this.txtmobile.TabIndex = 3;
            // 
            // txtphone
            // 
            this.txtphone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtphone.LabelText = "电话";
            this.txtphone.Location = new System.Drawing.Point(12, 120);
            this.txtphone.Name = "txtphone";
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtphone.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "电话", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtphone.Size = new System.Drawing.Size(354, 21);
            this.txtphone.TabIndex = 4;
            // 
            // chk
            // 
            this.chk.EditValue = true;
            this.chk.Location = new System.Drawing.Point(12, 201);
            this.chk.Name = "chk";
            this.chk.Properties.Caption = "启用";
            this.chk.Size = new System.Drawing.Size(75, 19);
            this.chk.TabIndex = 7;
            // 
            // txtsquare
            // 
            this.txtsquare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsquare.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtsquare.Location = new System.Drawing.Point(12, 147);
            this.txtsquare.Name = "txtsquare";
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtsquare.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "面积", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtsquare.Size = new System.Drawing.Size(354, 21);
            this.txtsquare.TabIndex = 8;
            // 
            // txtvolume
            // 
            this.txtvolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtvolume.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtvolume.Location = new System.Drawing.Point(12, 174);
            this.txtvolume.Name = "txtvolume";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtvolume.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "体积", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtvolume.Size = new System.Drawing.Size(354, 21);
            this.txtvolume.TabIndex = 8;
            // 
            // chkVirtual
            // 
            this.chkVirtual.Location = new System.Drawing.Point(70, 201);
            this.chkVirtual.Name = "chkVirtual";
            this.chkVirtual.Properties.Caption = "是否虚拟仓库";
            this.chkVirtual.Size = new System.Drawing.Size(102, 19);
            this.chkVirtual.TabIndex = 9;
            // 
            // chkOutWare
            // 
            this.chkOutWare.Location = new System.Drawing.Point(12, 226);
            this.chkOutWare.Name = "chkOutWare";
            this.chkOutWare.Properties.Caption = "是否外发仓库(此种仓库货审时不关心库存情况)";
            this.chkOutWare.Size = new System.Drawing.Size(285, 19);
            this.chkOutWare.TabIndex = 9;
            // 
            // WareEdtView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 309);
            this.Name = "WareEdtView";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.WareEdtView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsquare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvolume.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVirtual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOutWare.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FAC.Login.Controls.CheckCtl chk;
        private FASControls.LabelTextBox txtphone;
        private FASControls.LabelTextBox txtmobile;
        private FASControls.LabelTextBox txtcontact;
        private FASControls.LabelTextBox txtname;
        private FASControls.LabelTextBox txtcode;
        private DevExpress.XtraEditors.SpinEdit txtvolume;
        private DevExpress.XtraEditors.SpinEdit txtsquare;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private FAC.Login.Controls.CheckCtl chkVirtual;
        private FAC.Login.Controls.CheckCtl chkOutWare;
    }
}