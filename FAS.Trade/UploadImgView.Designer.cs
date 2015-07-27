namespace FAS.Trade {
    partial class UploadImgView {
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.imageUpload1 = new Ultra.FASControls.ImageUpload();
            ((System.ComponentModel.ISupportInitialize)(this.imageUpload1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageUpload1
            // 
            this.imageUpload1.DataSource = null;
            this.imageUpload1.FileNames = null;
            this.imageUpload1.Location = new System.Drawing.Point(12, 8);
            this.imageUpload1.MaxFileSize = ((long)(4194304));
            this.imageUpload1.Multiselect = true;
            this.imageUpload1.Name = "imageUpload1";
            this.imageUpload1.NoImageText = "无图片";
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.imageUpload1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "图片", 50, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "剪贴板", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "选择文件", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "上传图片", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "查看图片", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.imageUpload1.Properties.ReadOnly = true;
            this.imageUpload1.Session = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.imageUpload1.ShowChose = true;
            this.imageUpload1.ShowUpload = true;
            this.imageUpload1.ShowUpLoadView = true;
            this.imageUpload1.Size = new System.Drawing.Size(407, 21);
            this.imageUpload1.TabIndex = 0;
            this.imageUpload1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.imageUpload1_ButtonClick);
            // 
            // UploadImgView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 38);
            this.Controls.Add(this.imageUpload1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadImgView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上传图片";
            this.Load += new System.EventHandler(this.UploadImgView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageUpload1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ultra.FASControls.ImageUpload imageUpload1;
    }
}