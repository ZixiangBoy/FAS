namespace Ultra.FASControls
{
    partial class EFPager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtpgNum = new DevExpress.XtraEditors.TextEdit();
            this.labResult = new DevExpress.XtraEditors.LabelControl();
            this.cmbPgSize = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labEnd = new DevExpress.XtraEditors.LabelControl();
            this.labNext = new DevExpress.XtraEditors.LabelControl();
            this.labPre = new DevExpress.XtraEditors.LabelControl();
            this.labFirst = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpgNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPgSize.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtpgNum);
            this.panelControl1.Controls.Add(this.labResult);
            this.panelControl1.Controls.Add(this.cmbPgSize);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labEnd);
            this.panelControl1.Controls.Add(this.labNext);
            this.panelControl1.Controls.Add(this.labPre);
            this.panelControl1.Controls.Add(this.labFirst);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(596, 28);
            this.panelControl1.TabIndex = 1;
            // 
            // txtpgNum
            // 
            this.txtpgNum.Location = new System.Drawing.Point(362, 4);
            this.txtpgNum.Name = "txtpgNum";
            this.txtpgNum.Size = new System.Drawing.Size(56, 20);
            this.txtpgNum.TabIndex = 6;
            this.txtpgNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtpgNum_KeyUp);
            // 
            // labResult
            // 
            this.labResult.Location = new System.Drawing.Point(431, 7);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(154, 14);
            this.labResult.TabIndex = 5;
            this.labResult.Text = "当前页数：0/0页  总数：0条";
            // 
            // cmbPgSize
            // 
            this.cmbPgSize.EditValue = "10";
            this.cmbPgSize.Location = new System.Drawing.Point(240, 4);
            this.cmbPgSize.Name = "cmbPgSize";
            this.cmbPgSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPgSize.Properties.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "500",
            "1000",
            "5000",
            "10000",
            "全部"});
            this.cmbPgSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPgSize.Size = new System.Drawing.Size(69, 20);
            this.cmbPgSize.TabIndex = 4;
            this.cmbPgSize.SelectedIndexChanged += new System.EventHandler(this.cmbPgSize_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(332, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "转到";
            // 
            // labEnd
            // 
            this.labEnd.Location = new System.Drawing.Point(179, 7);
            this.labEnd.Name = "labEnd";
            this.labEnd.Size = new System.Drawing.Size(24, 14);
            this.labEnd.TabIndex = 3;
            this.labEnd.Text = "尾页";
            this.labEnd.Click += new System.EventHandler(this.labEnd_Click);
            this.labEnd.MouseLeave += new System.EventHandler(this.labFirst_MouseLeave);
            this.labEnd.MouseHover += new System.EventHandler(this.labFirst_MouseHover);
            // 
            // labNext
            // 
            this.labNext.Location = new System.Drawing.Point(120, 7);
            this.labNext.Name = "labNext";
            this.labNext.Size = new System.Drawing.Size(36, 14);
            this.labNext.TabIndex = 2;
            this.labNext.Text = "下一页";
            this.labNext.Click += new System.EventHandler(this.labNext_Click);
            this.labNext.MouseLeave += new System.EventHandler(this.labFirst_MouseLeave);
            this.labNext.MouseHover += new System.EventHandler(this.labFirst_MouseHover);
            // 
            // labPre
            // 
            this.labPre.Location = new System.Drawing.Point(58, 7);
            this.labPre.Name = "labPre";
            this.labPre.Size = new System.Drawing.Size(36, 14);
            this.labPre.TabIndex = 1;
            this.labPre.Text = "上一页";
            this.labPre.Click += new System.EventHandler(this.labPre_Click);
            this.labPre.MouseLeave += new System.EventHandler(this.labFirst_MouseLeave);
            this.labPre.MouseHover += new System.EventHandler(this.labFirst_MouseHover);
            // 
            // labFirst
            // 
            this.labFirst.Location = new System.Drawing.Point(12, 7);
            this.labFirst.Name = "labFirst";
            this.labFirst.Size = new System.Drawing.Size(24, 14);
            this.labFirst.TabIndex = 0;
            this.labFirst.Text = "首页";
            this.labFirst.Click += new System.EventHandler(this.labFirst_Click);
            this.labFirst.MouseLeave += new System.EventHandler(this.labFirst_MouseLeave);
            this.labFirst.MouseHover += new System.EventHandler(this.labFirst_MouseHover);
            // 
            // EFPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "EFPager";
            this.Size = new System.Drawing.Size(596, 28);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpgNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPgSize.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.TextEdit txtpgNum;
        protected DevExpress.XtraEditors.LabelControl labResult;
        protected DevExpress.XtraEditors.ComboBoxEdit cmbPgSize;
        protected DevExpress.XtraEditors.LabelControl labelControl1;
        protected DevExpress.XtraEditors.LabelControl labEnd;
        protected DevExpress.XtraEditors.LabelControl labNext;
        protected DevExpress.XtraEditors.LabelControl labPre;
        protected DevExpress.XtraEditors.LabelControl labFirst;
        public DevExpress.XtraEditors.PanelControl panelControl1;

    }
}
