using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.IO;
using Ultra.Surface.Common;
using Ultra.Surface.Lanuch;
using Ultra.Common;
using Ultra.FASControls.Extend;
using Ultra.FASControls.Controls; 

namespace Ultra.FASControls
{
    public class LabelTextBox : ButtonEdit
    {
        public LabelTextBox()
            : base()
        {
            base.Properties.Buttons.Clear();
            LabelButton = new EditorButton(ButtonPredefines.Glyph);
            LabelButton.IsLeft = true;
            LabelButton.Visible = true;
            LabelButton.Caption = DefText;
            LabelButton.Width = DefWidth;
            LabelButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            base.Properties.Buttons.Add(LabelButton);
            base.Properties.ButtonClick += Properties_ButtonClick;

        }

        protected virtual int DefWidth { get { return 50; } }
        protected virtual string DefText { get { return string.Empty; } }

        protected virtual void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == LabelButton.Caption)
            {
                switch(e.Button.Caption)
                {
                    case "收货人":
                    case "买家":
                    case "买家昵称":
                    case "淘宝单号":
                    case "系统单号":
                    case "合并单号":
                    case "手机号":
                    case "手机":
                        {
                            var clp = MethodExtend.GetClipBoardText(this);
                            if (!string.IsNullOrEmpty(clp) && string.IsNullOrEmpty(Text))
                                Text = clp;
                        }
                        break;
                }
                this.SelectAll();
                if (null != OnLabelClick)
                    OnLabelClick(sender, e);
            }
            else if (e.Button.Kind == ButtonPredefines.Delete)
            {
                this.Text = string.Empty;
                this.SelectAll();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //if (null != LabelButton)
            //{
            //    LabelButton.Caption = string.IsNullOrEmpty(LabelButton.Caption) ? string.Empty :
            //        LabelButton.Caption;
            //    var wh = TextRenderer.MeasureText(LabelButton.Caption, this.Font).Width + 20;
            //    var owh = LabelButton.Width;
            //    if (owh > 0 && owh < wh) owh = wh;
            //}
        }

        /// <summary>
        /// 标签文本
        /// </summary>
        [Description("标签文本"),
        Browsable(true),
        Category("Ultra")]
        public string LabelText
        {
            get { return null == LabelButton ? string.Empty : LabelButton.Caption; }
            set
            {
                if (null != LabelButton)
                {
                    LabelButton.Caption = value;
                    //var wh = TextRenderer.MeasureText(value, this.Font).Width + 20;
                    //var owh = LabelButton.Width;
                    //if (owh > 0 && owh < wh) owh = wh;
                    switch (LabelButton.Caption)
                    {
                        case "淘宝单号":
                        case "淘宝退款单号":
                            base.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            base.Properties.Mask.EditMask = "[0-9]*";
                            break;
                    }
                }
                base.Invalidate();
            }
        }

        /// <summary>
        /// 标签按钮
        /// </summary>
        [Description("标签按钮"),
        Browsable(true),
        Category("Ultra")]
        public EditorButton LabelButton
        {
            get;
            private set;
        }

        /// <summary>
        /// 标签按钮按下时触发事件
        /// </summary>
        [Description("标签按钮按下时触发事件"),
        Browsable(true),
        Category("Ultra")]
        public event EventHandler<ButtonPressedEventArgs> OnLabelClick;

        /// <summary>
        /// 文本是否包含中文
        /// </summary>
        public virtual bool IsContainChinese
        {
            get
            {
                return Ultra.Utility.Common.IsContainChinese(this.Text);
            }
        }

        /// <summary>
        /// 文本是否为商品编码类型
        /// 若为true不完全等同于输入的就是编码，因商品名称亦可为纯数字与字母
        /// </summary>
        public virtual bool IsItemCode
        {
            get
            {
                if (IsContainChinese) return false;
                return true;
            }
        }

        /// <summary>
        /// 获取完整商品代码
        /// </summary>
        /// <returns></returns>
        public virtual FullItemCode GetFullCode()
        {
            if (!IsItemCode) return null;
            var sp = this.Text.Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            FullItemCode fc = new FullItemCode();
            if (null != sp && sp.Length > 0)
            {
                foreach (string s in sp)
                {
                    if (string.IsNullOrEmpty(s)) continue;
                    if (string.IsNullOrEmpty(fc.OuterIid))
                        fc.OuterIid = s;
                    else
                    {
                        fc.OuterSkuId = s;
                        break;
                    }
                }
            }
            //规格码为空
            if (string.IsNullOrEmpty(fc.OuterSkuId))
            {
                if (this.Text.EndsWith(" "))
                    return fc;
                return null;
            }
            return fc;
        }

        /// <summary>
        /// 完整商品编码
        /// </summary>
        public class FullItemCode
        {
            /// <summary>
            /// 商品编码
            /// </summary>
            public string OuterIid { get; set; }
            /// <summary>
            /// 规格编码
            /// </summary>
            public string OuterSkuId { get; set; }
        }
    }

    public class ImageUpload : ButtonEdit
    {
        public ImageUpload()
            : base()
        {
            base.Properties.ReadOnly = true;
            base.Properties.Buttons.Clear();
            var LabelButton = new EditorButton(ButtonPredefines.Glyph);
            LabelButton.IsLeft = true;
            LabelButton.Caption = "图片";
            LabelButton.Visible = true;
            LabelButton.Width = 50;
            LabelButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            base.Properties.Buttons.Add(LabelButton);
            var clpbrd = new EditorButton(ButtonPredefines.Glyph);
            clpbrd.Caption = "剪贴板";
            clpbrd.Visible = true;
            base.Properties.Buttons.Add(clpbrd);
            var chose = new EditorButton(ButtonPredefines.Glyph);
            chose.Caption = "选择文件";
            chose.Visible = true;
            base.Properties.Buttons.Add(chose);
            //chose.Visible = SetButtonVis(chose.Caption,ShowChose);
            var upd = new EditorButton(ButtonPredefines.Glyph);
            upd.Caption = "上传图片";
            upd.Visible = true;
            base.Properties.Buttons.Add(upd);
            //upd.Visible = SetButtonVis(upd.Caption, ShowChose);
            var view = new EditorButton(ButtonPredefines.Glyph);
            view.Caption = "查看图片";
            view.Visible = true;
            base.Properties.Buttons.Add(view);
            base.Properties.ButtonClick += Properties_ButtonClick;
        }


        public virtual void LoadData() { LoadData(this.Session); }

        public virtual void LoadData(Guid Session)
        {
            ImgVwCalr = ImgVwCalr ?? Ultra.FASControls.SerNoCaller_WL.Calr_Image;
            var ets = ImgVwCalr.Get("where Session=@0 and IsDel=0", Session);
            ets = ets.OrderBy(j => j.Id).ToList();
            int idx = 1;
            foreach (var e in ets)
                e.Reserved1 = idx++;
            DataSource = ets;
            Text = null == ets || ets.Count < 1 ? NoImageText :
                string.Format("{0} 张图片", ets.Count);
        }

        public List<UltraDbEntity.T_ERP_Image> DataSource { get; set; }

        private string _noimagetext = "无图片";

        [Description("无图片时显示的文字"),
        Browsable(true),
        Category("Ultra")]
        public string NoImageText { get { return _noimagetext; } set { _noimagetext = value; } }

        Ultra.CoreCaller.EFCaller<UltraDbEntity.T_ERP_Image> ImgVwCalr { get; set; }

        [Description("是否显示选择文件按钮"),
        Browsable(true),
        Category("Ultra")]
        public bool ShowChose
        {
            get { return SetButtonVis("选择文件", null); }
            set { SetButtonVis("选择文件", value); }
        }

        [Description("是否显示上传图片按钮"),
        Browsable(true),
        Category("Ultra")]
        public bool ShowUpload
        {
            get
            {
                return SetButtonVis("上传图片", null);
            }
            set
            {
                SetButtonVis("上传图片", value);
            }
        }

        protected virtual bool SetButtonVis(string cap, bool? bshow)
        {
            foreach (EditorButton btn in base.Properties.Buttons)
            {
                var lst = btn.Visible;
                if (bshow != null)
                    if (btn.Caption == cap) btn.Visible = bshow.Value;
                return lst;
            }
            return false;
        }

        OpenFileDialog OFDlg { get; set; }

        private Guid _Session = Guid.Empty;

        public Guid Session
        {
            get { return _Session; }
            set { _Session = value; }
        }

        /// <summary>
        /// 待上传的文件
        /// </summary>
        public List<UploadFile> FileNames { get; set; }

        private long _maxFileSize = 1024 * 1024 * 4;//最大4 M
        public long MaxFileSize
        {
            get { return _maxFileSize; }
            set { _maxFileSize = value; }
        }

        protected virtual void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Caption)
            {
                case "剪贴板":
                    ShowUpLoadForm(true);
                    break;
                case "选择文件":
                    OFDlg = OFDlg ?? new OpenFileDialog();
                    OFDlg.Filter = "图片文件|*.jpg;*.jpeg;*.gif;*.png;*.bmp;";
                    OFDlg.Multiselect = Multiselect;
                    bool b = false;
                    if (OFDlg.ShowDialog() == DialogResult.OK)
                    {
                        var fis = OFDlg.FileNames.Select(j => new UploadFile
                        {
                            FilePath = j,
                            Done = false
                        }).ToList();
                        this.FileNames = this.FileNames ?? new List<UploadFile>(8);
                        this.FileNames.AddRange(fis);
                        b = true;
                    }
                    if (b) ShowUpLoadForm();
                    if (null == FileNames || FileNames.Count < 1)
                        Text = string.Empty;
                    else
                        Text = FileNames.Select(j => j.FileName).Aggregate((s1, s2) => s1 + " " + s2)
                            .ToString();
                    break;
                case "上传图片":
                    {
                        ShowUpLoadForm();
                    }
                    break;
                case "查看图片":
                    {
                        ImgVwCalr = ImgVwCalr ?? Ultra.FASControls.SerNoCaller_WL.Calr_Image;
                        var vw = new Ultra.FASControls.Views.ImageViewer();
                        vw.Calr = ImgVwCalr;
                        vw.Session = this.Session;
                        vw.Ent = this.DataSource;
                        vw.ShowDialog();
                    }
                    break;
            }
        }

        void ShowUpLoadForm(bool readclpbrd = false)
        {
            if (!readclpbrd && (null == FileNames || FileNames.Count < 1))
            {
                MsgBox.ShowMessage("无图片需要上传,请先选择图片!");
                return;
            }
            var fis = FileNames ?? new List<UploadFile>();
            var vw = new Ultra.FASControls.Views.ImageUploadView();
            if (Guid.Empty == this.Session)
                this.Session = Guid.NewGuid();
            vw.Session = this.Session;
            vw.MaxFileSize = this.MaxFileSize;
            vw.Files = fis;
            vw.ReadClpBrd = readclpbrd;
            //var v = this.FindForm() as Ultra.Surface.Form.BaseSurface;
            //if (null != v) {
            //    //vw.CurUser = v.CurUser;
            //}
            if (ShowUpLoadView)
            {
                if (vw.ShowDialog() == DialogResult.OK)
                {
                    LoadData(Session);
                    if (null == fis || fis.Count < 1)
                        Text = string.Empty;
                    else
                    {
                        Text = fis.Where(j => j.Done).Select(j => j.FileName).Aggregate((s1, s2) => s1 + " " + s2)
                            .ToString();

                    }
                    if (fis != null)
                        fis.Clear();
                }
            }
        }

        private bool _Multiselect = true;
        private bool _ShowUpLoadView = true;

        [Description("是否显示上传画面"),
        Browsable(true),
        Category("Ultra")]
        public bool ShowUpLoadView
        {
            get { return _ShowUpLoadView; }
            set { _ShowUpLoadView = value; }
        }

        /// <summary>
        /// 是否允许多选文件
        /// </summary>
        [Description("是否允许多选文件"),
        Browsable(true),
        Category("Ultra")]
        public bool Multiselect { get { return _Multiselect; } set { _Multiselect = value; } }
    }

    public class UploadFile
    {
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(FilePath)) return string.Empty;
                return Path.GetFileName(FilePath);
            }
        }
        public string FilePath { get; set; }
        public bool Done { get; set; }
        public string Status
        {
            get
            {
                return Done ? "完成" : "待上传";
            }
        }

        public string ErrMsg { get; set; }

        public string ViewText { get { return "查看图片"; } }

        /// <summary>
        /// 是否临时剪贴板文件
        /// </summary>
        public bool IsClpBrd { get; set; }
    }

    public class FileBrowser : LabelTextBox
    {
        public FileBrowser()
            : base()
        {
            LabelButton.Caption = "文件";
            FileButton = new EditorButton(ButtonPredefines.Glyph);
            FileButton.Caption = "浏览...";
            base.Properties.Buttons.Add(FileButton);
            OFDlg = new OpenFileDialog();
            Properties.ReadOnly = true;
            AllowDrop = true;
            DragEnter += FileBrowser_DragEnter;
            DragDrop += FileBrowser_DragDrop;
        }

        void FileBrowser_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (null != files && files.Length > 0)
                Text = files[0];
        }

        void FileBrowser_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// 文件打开对话框
        /// </summary>
        [Description("文件打开对话框"),
        Browsable(true),
        Category("Ultra")]
        public OpenFileDialog OFDlg { get; set; }

        protected override void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            base.Properties_ButtonClick(sender, e);
            if (e.Button.Caption == FileButton.Caption)
            {
                if (OFDlg.ShowDialog() == DialogResult.OK)
                    Text = OFDlg.FileName;
            }
        }

        protected EditorButton FileButton { get; set; }
    }

    public class LabelSpinEdit : SpinEdit
    {
        public LabelSpinEdit()
            : base()
        {
        }
    }

    public class LblSpnEdt : SpinEdit
    {
        public LblSpnEdt()
            : base()
        {
            base.Properties.Buttons.Clear();
            LabelButton = new EditorButton(ButtonPredefines.Glyph);
            LabelButton.IsLeft = true;
            LabelButton.Visible = true;
            LabelButton.Width = 50;
            LabelButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

            base.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),LabelButton});
        }

        /// <summary>
        /// 标签按钮
        /// </summary>
        [Description("标签按钮"),
        Browsable(true),
        Category("Ultra")]
        public EditorButton LabelButton
        {
            get;
            private set;
        }

        /// <summary>
        /// 标签文本
        /// </summary>
        [Description("标签文本"),
        Browsable(true),
        Category("Ultra")]
        public string LabelText
        {
            get { return null == LabelButton ? string.Empty : LabelButton.Caption; }
            set
            {
                if (null != LabelButton)
                {
                    LabelButton.Caption = value;
                    //var wh = TextRenderer.MeasureText(value, this.Font).Width + 20;
                    //var owh = LabelButton.Width;
                    //if (owh > 0 && owh < wh) owh = wh;
                }
                base.Invalidate();
            }
        }
    }

    public class EntityPopupView : LabelTextBox
    {
        public EntityPopupView()
            : base()
        {
            _showviewbtn = new EditorButton(ButtonPredefines.Ellipsis);
            _clrbtn = new EditorButton(ButtonPredefines.Delete);
            _clrbtn.ToolTip = "清除所选"; _clrbtn.Visible = false;
            base.Properties.Buttons.Add(_showviewbtn);
            base.Properties.Buttons.Add(_clrbtn);
            base.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            base.OnLabelClick += (s1, e1) =>
            {
                try
                {
                    Clipboard.SetDataObject(base.Text);
                }
#if DEBUG
                catch (Exception) { throw; }
#else
                catch{}
#endif
            };
        }

        protected override void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            base.Properties_ButtonClick(sender, e);
            if (e.Button.Caption == _clrbtn.Caption && _clrbtn.Visible && e.Button.Kind != ButtonPredefines.Ellipsis)
            {
                Text = string.Empty; EditValue = null; OnClearBtnClick();
            }
            else if (e.Button.Caption == _showviewbtn.Caption && e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                if (null != this.OnShowViewBtnClick)
                    this.OnShowViewBtnClick(sender, e);
            }
        }

        protected virtual void OnClearBtnClick() { }

        private EditorButton _showviewbtn = null;
        private EditorButton _clrbtn = null;

        protected System.Collections.ObjectModel.Collection<LabelGridEditColItemEx> _ColItems =
            new System.Collections.ObjectModel.Collection<LabelGridEditColItemEx>();

        protected NameFieldCollection _colnamefields = new NameFieldCollection();

        /// <summary>
        /// 绑定用于显示的字段与列名称列表
        /// </summary>
        [
           Description("绑定用于显示的字段与列名称列表")
           , Browsable(true)
           , Category("Ultra")
        , Editor(typeof(CollectionEditor), typeof(UITypeEditor))
        ]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        //public virtual System.Collections.ObjectModel.Collection<LabelGridEditColItemEx> ColumnItems
        //{
        //    get { return _ColItems; }
        //    set { _ColItems = value; }
        //}
        public virtual NameFieldCollection NameFieldItems
        {
            get { return _colnamefields; }
            set { _colnamefields = value; }
        }


        /// <summary>
        /// 是否显示清除所选按钮
        /// </summary>
        [Description("是否显示清除所选按钮"),
        Browsable(true), DefaultValue(false),
        Category("Ultra")]
        public bool ShowClearButton
        {
            get
            {
                if (null != _clrbtn)
                    return _clrbtn.Visible;
                else
                    return false;
            }
            set
            {
                if (null != _clrbtn)
                    _clrbtn.Visible = value;
            }
        }

        /// <summary>
        /// 是否允许多选
        /// </summary>
        [Description("是否允许多选"),
        Browsable(true), DefaultValue(false),
        Category("Ultra")]
        public bool AllowMultiSelect { get; set; }

        /// <summary>
        /// 弹出的选择窗口的标题
        /// </summary>
        [Description("弹出的选择窗口的标题"),
        Browsable(true), DefaultValue(false),
        Category("Ultra")]
        public string PopupViewText { get; set; }

        protected string _SPLT = ",";

        /// <summary>
        /// 文本分隔符
        /// </summary>
        [Description("文本分隔符"),
        Browsable(true), DefaultValue(","),
        Category("Ultra")]
        public string SPLT { get { return _SPLT; } set { _SPLT = value; } }

        /// <summary>
        /// 当显示画面按钮按下时触发事件
        /// </summary>
        [Description("当显示画面按钮按下时触发事件"),
        Browsable(true), DefaultValue(false),
        Category("Ultra")]
        public event EventHandler<ButtonPressedEventArgs> OnShowViewBtnClick;

    }

    public class EntityPopupViewEx<T> : EntityPopupView
    {
        public EntityPopupViewEx()
            : base()
        {
            base.OnShowViewBtnClick += EntityPopupViewEx_OnShowViewBtnClick;

        }

        /// <summary>
        /// 子类重写的用于显示到TEXT上的文字
        /// </summary>
        /// <returns></returns>
        protected virtual string GetShowText(List<T> td) { return string.Empty; }

        /// <summary>
        /// 子类重写的用于加载初始数据的方法
        /// </summary>
        /// <returns></returns>
        protected virtual List<T> GetData() { return null; }

        /// <summary>
        /// 子类重写的用于设置初始数据中已被选中的实体
        /// </summary>
        /// <param name="vlus">已被选中的实体</param>
        protected virtual void SetAlreadyValue(List<T> vlus) { }

        protected virtual List<T> _pData { get; set; }

        protected override void OnClearBtnClick()
        {

            _pData = null;
        }

        void EntityPopupViewEx_OnShowViewBtnClick(object sender, ButtonPressedEventArgs e)
        {
            var vw = PopupView = new BasePopupViewEx<T>();
            Ultra.Surface.Lanuch.Lanucher.InitView(vw);
            vw.OwnerEdit = this;
            vw.DataSource = GetData();
            //SetAlreadyValue(_pData);
            vw.OnSetAlreadySelect += vw_OnSetAlreadySelect;
            vw.OnMultiGetData += vw_OnMultiGetData;

            if (vw.ShowDialog() == DialogResult.OK)
            {
                if (AllowMultiSelect)
                {
                    vw.RaiseMultiGetData();
                    //_pData = vw.DataSource.Where(k =>
                    //    string.Compare(
                    //    k.GetType().GetProperty("UISelected").GetValue(k, null).ToString(), true.ToString(), true) == 0).ToList();
                }
                else
                {
                    _pData = new List<T> { vw.SingleData };
                }
                ToolTip =
                Text = GetShowText(_pData);
            }
        }

        void vw_OnMultiGetData(object sender, ReturnDataEventArg<T> e)
        {
            Process_OnMultiGetData(sender, e);

            _pData = e.OutData;
        }

        void vw_OnSetAlreadySelect(object sender, ReturnDataEventArg<T> e)
        {
            e.InData = _pData;
            Process_SetAlreadySelect(sender, e);
        }

        /// <summary>
        /// 子类重写用于设置已选实体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Process_SetAlreadySelect(object sender, ReturnDataEventArg<T> e)
        { }

        /// <summary>
        /// 子类重写用于返回多选模式下选中的实体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Process_OnMultiGetData(object sender, ReturnDataEventArg<T> e) { }

        protected BasePopupViewEx<T> PopupView { get; set; }

        protected List<T> _selectedvalues = null;

        /// <summary>
        /// 选中的实体
        /// </summary>
        public virtual List<T> SelectedValue
        {
            get { return _pData; }
            set
            {
                _pData = value;
                if (null == value || value.Count < 1)
                {
                    Text = string.Empty; EditValue = null;
                }
            }
        }
    }

    public class ReturnDataEventArg<T> : EventArgs
    {

        /// <summary>
        /// 入参
        /// </summary>
        public virtual List<T> InData { get; set; }

        /// <summary>
        /// 出参
        /// </summary>
        public virtual List<T> OutData { get; set; }
    }

    public class BasePopupViewEx<T> : BasePopupView
    {
        public BasePopupViewEx()
            : base()
        {
            this.btnOK.Click += btnOK_Click;
            //this.Load += (s1, e1) =>
            //{

            //};
        }

        public override void InitUI()
        {
            base.InitUI();
            RaiseSetAlreadySelect();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            var et = this.gridControlEx1.GetFocusedDataSource<T>();
            if (null != OwnerEdit && OwnerEdit.AllowMultiSelect)
            {

            }
            else
            {
                SingleData = et;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        internal List<T> DataSource { get; set; }

        /// <summary>
        /// 单选模式下的选中的实体
        /// </summary>
        internal T SingleData { get; set; }

        public override void Refresh()
        {
            this.gridControlEx1.DataSource = this.DataSource;
            //this.gridControlEx1.RefreshDataSource();
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <returns></returns>
        public ReturnDataEventArg<T> RaiseMultiGetData()
        {
            var arg = new ReturnDataEventArg<T> { };
            if (null != this.OnMultiGetData)
                this.OnMultiGetData(this, arg);
            return arg;
        }

        public ReturnDataEventArg<T> RaiseSetAlreadySelect()
        {
            var arg = new ReturnDataEventArg<T> { }; if (null != this.OnSetAlreadySelect)
                this.OnSetAlreadySelect(this, arg);
            return arg;
        }

        /// <summary>
        /// 允许多选时获取数据回调方法
        /// </summary>
        public event EventHandler<ReturnDataEventArg<T>> OnMultiGetData;

        /// <summary>
        /// 设置已选实体时回调方法
        /// </summary>
        public event EventHandler<ReturnDataEventArg<T>> OnSetAlreadySelect;


        ///// <summary>
        ///// 所选中的实体数据
        ///// </summary>
        //public virtual List<T> SelectedValues { get; set; }

        ///// <summary>
        ///// 已选中的实体数据
        ///// </summary>
        //internal List<T> AlreadySelected { get; set; }
    }

    [Serializable]
    [ToolboxItem(false)]//设置此类在工具箱中不可见
    [DesignTimeVisible(false)]//设置设计时此类不可见
    public class LabelGridEditColItemEx //: Component
    {
        public string Caption { get; set; }
        public string FieldName { get; set; }
    }

    [Serializable]
    [ToolboxItem(false)]//设置此类在工具箱中不可见
    [DesignTimeVisible(false)]//设置设计时此类不可见
    public class GridEditColItemExCollection : System.Collections.CollectionBase
    {
        public LabelGridEditColItemEx this[int index]
        {
            get
            {
                return base.List[index] as LabelGridEditColItemEx;
            }
        }

        public virtual int Add(LabelGridEditColItemEx button)
        {
            int num = this.IndexOf(button);
            if (num == -1)
            {
                num = base.List.Add(button);
            }
            return num;
        }
        public virtual int IndexOf(LabelGridEditColItemEx button)
        {
            return base.List.IndexOf(button);
        }
        public virtual bool Contains(LabelGridEditColItemEx button)
        {
            return base.List.Contains(button);
        }
        public virtual void Insert(int index, LabelGridEditColItemEx button)
        {
            if (this.Contains(button))
            {
                return;
            }
            base.List.Insert(index, button);
        }

        protected override void OnClear()
        {
            if (base.Count == 0)
            {
                return;
            }
            try
            {
                for (int i = base.Count - 1; i >= 0; i--)
                {
                    base.RemoveAt(i);
                }
            }
            finally
            {
            }
        }

        public virtual void AddRange(LabelGridEditColItemEx[] buttons)
        {
            try
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    LabelGridEditColItemEx value = buttons[i];
                    base.List.Add(value);
                }
            }
            finally
            {

            }
        }

        public virtual void Assign(GridEditColItemExCollection collection)
        {
            try
            {
                base.Clear();
                for (int i = 0; i < collection.Count; i++)
                {
                    LabelGridEditColItemEx source = collection[i];
                    LabelGridEditColItemEx editorButton = new LabelGridEditColItemEx();
                    //editorButton.Assign(source);
                    this.Add(editorButton);
                }
            }
            finally
            {
            }
        }
    }

    //[Serializable]
    public class NameFieldCollection : System.Collections.CollectionBase//从集合基类继
    {
        //private List<LabelGridEditColItemEx> _lst = new List<LabelGridEditColItemEx>(10);
        public LabelGridEditColItemEx this[int index]
        {
            get { return List[index] as LabelGridEditColItemEx; }
            set { List[index] = value; }
        }
        public int Add(object value)
        {
            return this.List.Add(value);
        }
    }

    [Serializable]
    public class LabelGridEditColItem
    {
        public string Caption { get; set; }
        public string FieldName { get; set; }
    }

    public class LabelGridEdit : GridLookUpEdit
    {
        public LabelGridEdit()
            : base()
        {
            base.EditValue = null;
            base.Text = string.Empty;
            base.Properties.TextEditStyle =
                DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            base.Properties.View.OptionsBehavior.Editable = false;
            base.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            base.Properties.View.Appearance.SelectedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
            base.Properties.View.Appearance.FocusedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
            //base.Properties.View.Appearance.Row.BackColor = Color.White;
            base.Properties.NullText = string.Empty;
            base.Properties.Buttons.Clear();
            LabelButton = new EditorButton(ButtonPredefines.Glyph);
            LabelButton.IsLeft = true;
            LabelButton.Visible = true;
            LabelButton.Width = DefWidth;
            LabelButton.Caption = DefText;
            LabelButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            base.Properties.Buttons.Add(LabelButton);
            base.Properties.Buttons.Add(new EditorButton
            {
                Kind = ButtonPredefines.Combo
            });

            base.Properties.Buttons.Add(_ClearButton = new DevExpress.XtraEditors.Controls.EditorButton
            {
                Caption = ClearButtonText
                ,
                Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                ,
                ToolTip = ClearButtonText
                ,
                Visible = ShowClearButton
            });

            base.Text = string.Empty;
            base.Properties.ButtonClick += Properties_ButtonClick;
            //允许输入提示选择
            base.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            base.Properties.AutoComplete = true;
            base.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            base.Properties.ImmediatePopup = true;
        }

        protected virtual string DefText { get { return string.Empty; } }
        protected virtual int DefWidth { get { return 50; } }

        void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == LabelButton.Caption)
                this.SelectAll();
            else if (e.Button.Caption == ClearButtonText)
            {
                Text = string.Empty;
                base.EditValue = null;
                base.Properties.View.FocusedRowHandle = -99997;
            }
            else
            {
                base.ShowPopup();
            }
        }

        private string _ClearButtonText = "清除所选";
        private bool _ShowClearButton = false;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit fProperties;
        private DevExpress.XtraGrid.Views.Grid.GridView fPropertiesView;


        /// <summary>
        /// 绑定用于显示的字段
        /// </summary>
        [
        Description("绑定用于显示的字段")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string DisplayMember
        {
            get { return base.Properties.DisplayMember; }
            set { base.Properties.DisplayMember = value; }
        }

        protected List<LabelGridEditColItem> _ColItems = new List<LabelGridEditColItem>();

        /// <summary>
        /// 绑定用于显示的字段与列名称列表
        /// </summary>
        [
           Description("绑定用于显示的字段与列名称列表")
           , Browsable(true)
           , Category("Ultra"), Obsolete("不再建议使用，请换用ColumnItemsEx")
            //, Serializable
        ]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        public virtual List<LabelGridEditColItem> ColumnItems
        {
            get { return _ColItems; }
            set { _ColItems = value; }
        }

        protected System.Collections.ObjectModel.Collection<LabelGridEditColItemEx> _ColItemsEx =
            new System.Collections.ObjectModel.Collection<LabelGridEditColItemEx>();

        protected GridEditColItemExCollection _ColItemsEx2 = new GridEditColItemExCollection();

        /// <summary>
        /// 绑定用于显示的字段与列名称列表
        /// </summary>
        [
           Description("绑定用于显示的字段与列名称列表")
           , Browsable(true)
           , Category("Ultra")
        , Editor(typeof(CollectionEditor), typeof(UITypeEditor))
        , Obsolete("不再建议使用，请换用ColumnItemsEx2")
            //, Serializable
        ]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        public virtual System.Collections.ObjectModel.Collection<LabelGridEditColItemEx> ColumnItemsEx
        {
            get { return _ColItemsEx; }
            set { _ColItemsEx = value; }
        }

        /// <summary>
        /// 绑定用于显示的字段与列名称列表
        /// </summary>
        [
           Description("绑定用于显示的字段与列名称列表")
           , Browsable(true)
           , Category("Ultra")
        , Editor(typeof(CollectionEditor), typeof(UITypeEditor))
        ]
        public virtual GridEditColItemExCollection ColumnItemsEx2
        {
            get { return _ColItemsEx2; }
            set { _ColItemsEx2 = value; }
        }

        ///// <summary>
        ///// 绑定用于显示的字段标题列表
        ///// </summary>
        //[
        //Description("绑定用于显示的字段标题列表")
        //, Browsable(true)
        //, Category("Ultra")
        //]
        //public virtual List<string> ColumnCaptions
        //{
        //    get;
        //    set;
        //}



        /// <summary>
        /// 绑定用于表示值的字段
        /// </summary>
        [
        Description("绑定用于表示值的字段")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string ValueMember
        {
            get { return base.Properties.ValueMember; }
            set { base.Properties.ValueMember = value; }
        }


        /// <summary>
        /// 列显示名称
        /// </summary>
        [
        Description("列显示名称")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string ColumnCaption { get; set; }

        /// <summary>
        /// 清除所选按钮显示的文字
        /// </summary>
        [
        Description("是否显示清除所选按钮")
        , DefaultValue(false)
        , Browsable(true)
        , Category("Ultra")
        ]
        public bool ShowClearButton
        {
            get { return _ShowClearButton; }
            set { _ShowClearButton = value; _ClearButton.Visible = value; }
        }

        /// <summary>
        /// 清除所选按钮显示的文字
        /// </summary>
        [
        Description("清除所选按钮显示的文字")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string ClearButtonText
        {
            get { return _ClearButtonText; }
            set { _ClearButtonText = value; }
        }

        private DevExpress.XtraEditors.Controls.EditorButton _ClearButton = null;

        /// <summary>
        /// 清除所选按钮按下时触发事件
        /// </summary>
        [
        Description("清除所选按钮按下时触发事件")
        , Browsable(true)
        , Category("Ultra")
        ]
        public event EventHandler OnClearButtonClick;

        /// <summary>
        /// 标签按钮
        /// </summary>
        [Description("标签按钮"),
        Browsable(true),
        Category("Ultra")]
        public EditorButton LabelButton
        {
            get;
            private set;
        }

        /// <summary>
        /// 标签文本
        /// </summary>
        [Description("标签文本"),
        Browsable(true),
        Category("Ultra")]
        public string LabelText
        {
            get { return null == LabelButton ? string.Empty : LabelButton.Caption; }
            set
            {
                if (null != LabelButton)
                {
                    LabelButton.Caption = value;
                    //var wh = TextRenderer.MeasureText(value, this.Font).Width + 20;
                    //var owh = LabelButton.Width;
                    //if (owh > 0 && owh < wh) owh = wh;
                }
                base.Invalidate();
            }
        }


    }


    public class EntityGridEditventArg<T> : EventArgs
    {
        public virtual T Value { get; set; }
    }

    public class EntityGridEdit<T> : LabelGridEdit where T : class
    {
        public EntityGridEdit()
            : base()
        {
            base.EditValueChanged += BaseGridLookUpEditAdv_EditValueChanged;


        }

        void BaseGridLookUpEditAdv_EditValueChanged(object sender, EventArgs e)
        {
            RaiseSelectedValueChanged();
        }

        public virtual void RaiseSelectedValueChanged()
        {
            if (null != OnSelectedValueChanged)
                OnSelectedValueChanged(this, new EntityGridEditventArg<T>
                {
                    Value = GetSelectedValue()
                });
        }

        /// <summary>
        /// 当当前选中的项发生改变时触发事件,事件参数Value包含当前选中的项
        /// </summary>
        [
        Description("当当前选中的项发生改变时触发事件,事件参数Value包含当前选中的项")
        , Browsable(true)
        , Category("Ultra")
        ]
        public event EventHandler<EntityGridEditventArg<T>> OnSelectedValueChanged;


        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <returns></returns>
        public virtual T GetSelectedValue() { return default(T); }

        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <param name="vl"></param>
        /// <returns></returns>
        public virtual T SetSelectedValue(T vl)
        {
            if (null == vl)
            {
                base.EditValue = null;
                base.Text = string.Empty;
                base.Properties.View.FocusedRowHandle = -99997;
                return vl;
            }
            return vl;
        }

        #region Design

        /// <summary>
        /// 获取、设置 选中的项
        /// </summary>
        [
        Description("获取、设置 选中的项")
        , Browsable(true)
        , Category("Ultra")
        ]
        public T SelectedValue
        {
            get
            {
                return GetSelectedValue();
            }
            set
            {
                if (null == value)
                {
                    base.EditValue = null; base.Text = string.Empty;
                    base.Properties.View.FocusedRowHandle = -99997;
                    return;
                }
                else
                    SetSelectedValue(value);
            }
        }

        #endregion

        /// <summary>
        /// 子类实现的获取数据的方法
        /// </summary>
        /// <returns></returns>
        protected virtual List<T> GetData()
        {
            return null;
        }

        protected virtual List<T> GetData(string whr, params object[] prms)
        {
            return null;
        }

        public virtual List<T> LoadData(string whr, params object[] prms)
        {
            var ets = GetData(whr, prms);
            base.Properties.DataSource = ets;
            base.Properties.View.FocusedRowHandle = -99997;
           
            AfterLoadData(ets);
            return ets;
        }

        public virtual List<T> SetData(List<T> ets)
        {
            base.Properties.DataSource = ets;
            base.Properties.View.FocusedRowHandle = -99997;
           
            AfterLoadData(ets);
            return ets;
        }

        /// <summary>
        /// 从缓存加载数据，若缓存不命中，则从DB加载
        /// </summary>
        /// <param name="key"></param>
        /// <param name="whr"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public virtual List<T> LoadFromCache(string key = "", Func<T, bool> aftLoad = null, string whr = "", params object[] prms)
        {            
            key = string.IsNullOrEmpty(key) ? CacheKey : key;
            var cdata = Ultra.Surface.Lanuch.Lanucher.Cache.Get<List<T>>(key);
            if (null == cdata || cdata.Count < 1)
            {
                if (string.IsNullOrEmpty(whr))
                    cdata = LoadData();
                else
                    cdata = LoadData(whr, prms);
                Ultra.Surface.Lanuch.Lanucher.Cache.Put<List<T>>(key, cdata);
                if (aftLoad != null)
                {
                    var d = cdata.Where(j => aftLoad(j)).ToList();
                    SetData(d);
                    return d;
                }
                else
                    return cdata;
            }
            else
                if (aftLoad != null)
                {
                    var d = cdata.Where(j => aftLoad(j)).ToList();
                    SetData(d);
                    return d;
                }
                else
                    return SetData(cdata);
        }

        protected string _cachekey = string.Empty;

        public virtual string CacheKey
        {
            get
            {
                if (!string.IsNullOrEmpty(_cachekey)) return _cachekey;
                return _cachekey = string.Format("SYS.Cache.{0}", typeof(T).Name);
            }
        }

        /// <summary>
        /// 加载、绑定数据
        /// </summary>
        /// <returns></returns>
        public virtual List<T> LoadData()
        {
            //            try
            //            {
            //                using (var db = new PetaPoco.Database())
            //                {
            //                    var kts = db.Query<T>("");
            //                    List<T> ets = FilterData(kts);
            //                    base.Properties.DataSource = ets;
            //                    base.Properties.View.FocusedRowHandle = -99997;
            //                    AfterLoadData(ets);
            //                    return ets;
            //                }
            //            }
            //            catch (Exception)
            //            {
            //#if !DEBUG
            //                return null;
            //#else
            //                throw;
            //#endif
            //            }
            var ets = GetData();
            base.Properties.DataSource = ets;
            base.Properties.View.FocusedRowHandle = -99997;
            
            AfterLoadData(ets);
            return ets;
        }

        /// <summary>
        /// 数据源
        /// </summary>
        public virtual List<T> DataSource
        {
            get
            {
                if (null == base.Properties.DataSource) return new List<T>();
                return base.Properties.DataSource as List<T>;
            }
        }

        /// <summary>
        /// 自定义过滤
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public virtual List<T> FilterData(IEnumerable<T> ds)
        {
            return ds.ToList();
        }

        public virtual void AfterLoadData(List<T> ds)
        {
            base.Properties.View.Columns.Clear();
            if (null == ColumnItemsEx || ColumnItemsEx.Count < 1)
            {
                #region 判断 ColumnItemsEx2
                if (null != ColumnItemsEx2 && ColumnItemsEx2.Count > 0)
                {
                    var cols = new DevExpress.XtraGrid.Columns.GridColumn[ColumnItemsEx2.Count];
                    for (int i = 0; i < ColumnItemsEx2.Count; i++)
                    {
                        var gridColumn1 =
                         new DevExpress.XtraGrid.Columns.GridColumn();
                        gridColumn1.Caption = ColumnItemsEx2[i].Caption;
                        gridColumn1.FieldName = ColumnItemsEx2[i].FieldName;

                        gridColumn1.OptionsColumn.AllowEdit = false;
                        gridColumn1.Visible = true;
                        gridColumn1.VisibleIndex = 0;
                        cols[i] = gridColumn1;
                    }
                    base.Properties.View.Columns.AddRange(cols);
                }
                #endregion
                else
                {
                    #region 最老的 ColumnItems　判断

                    if (ColumnItems == null || ColumnItems.Count < 1)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn gridColumn1 =
                            new DevExpress.XtraGrid.Columns.GridColumn();
                        gridColumn1.Caption = base.ColumnCaption;
                        gridColumn1.FieldName = base.DisplayMember;

                        gridColumn1.OptionsColumn.AllowEdit = false;
                        gridColumn1.Visible = true;
                        gridColumn1.VisibleIndex = 0;

                        base.Properties.View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { 
                gridColumn1
            });
                    }
                    else
                    {
                        var cols = new DevExpress.XtraGrid.Columns.GridColumn[ColumnItems.Count];
                        for (int i = 0; i < ColumnItems.Count; i++)
                        {
                            var gridColumn1 =
                             new DevExpress.XtraGrid.Columns.GridColumn();
                            gridColumn1.Caption = ColumnItems[i].Caption;
                            gridColumn1.FieldName = ColumnItems[i].FieldName;

                            gridColumn1.OptionsColumn.AllowEdit = false;
                            gridColumn1.Visible = true;
                            gridColumn1.VisibleIndex = 0;
                            cols[i] = gridColumn1;
                        }
                        base.Properties.View.Columns.AddRange(cols);
                    }
                    #endregion
                }
            }
            else
            {
                var cols = new DevExpress.XtraGrid.Columns.GridColumn[ColumnItemsEx.Count];
                for (int i = 0; i < ColumnItemsEx.Count; i++)
                {
                    var gridColumn1 =
                     new DevExpress.XtraGrid.Columns.GridColumn();
                    gridColumn1.Caption = ColumnItemsEx[i].Caption;
                    gridColumn1.FieldName = ColumnItemsEx[i].FieldName;

                    gridColumn1.OptionsColumn.AllowEdit = false;
                    gridColumn1.Visible = true;
                    gridColumn1.VisibleIndex = 0;
                    cols[i] = gridColumn1;
                }
                base.Properties.View.Columns.AddRange(cols);
            }

            base.Properties.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            base.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            base.Properties.View.OptionsBehavior.Editable = false;
            base.Properties.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            base.Properties.View.OptionsView.ShowGroupPanel = false;
            base.Properties.View.OptionsView.ShowAutoFilterRow = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in base.Properties.View.Columns)
            {
                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            }
        }
    }

    public class EntityGridEditEx<T> : EntityGridEdit<T> where T : class
    {
        public EntityGridEditEx()
            : base()
        {
            base.DisplayMember = string.Empty;
            base.ValueMember = "Guid";
        }
        public override T GetSelectedValue()
        {
            try
            {
                if (base.EditValue == null || string.IsNullOrEmpty(base.EditValue.ToString())
                   ) return null;
                var ds = base.Properties.DataSource as List<T>;
                if (null == ds) return base.GetSelectedValue();
                return ds.Where(k => k.GetType().GetProperty(base.ValueMember).GetValue(k, null).ToString() == (base.EditValue).ToString()).FirstOrDefault();
            }
            catch { return default(T); }
        }

        public override T SetSelectedValue(T vl)
        {
            try
            {
                if (null == vl) return base.SetSelectedValue(vl);
                this.EditValue = vl.GetType().GetProperty(base.ValueMember).GetValue(vl, null);

                var kt = base.SetSelectedValue(vl);
                var ds = base.Properties.DataSource as List<T>;
                //base.Properties.View.RefreshData(); 
                if (null != ds)
                {
                    var mtch = ds.Where(k => k.GetType().GetProperty(base.ValueMember).GetValue(k, null).ToString() ==
                        k.GetType().GetProperty(base.ValueMember).GetValue(kt, null).ToString()).SingleOrDefault();
                    base.EditValue = null == mtch ? null :
                        mtch.GetType().GetProperty(base.ValueMember.ToString()).GetValue(mtch, null);
                    //if (null != mtch)
                    //{
                    //   var mn = mtch.GetType().GetProperty(base.DisplayMember.ToString()).GetValue(mtch, null).ToString();

                    //}
                    //else { base.Text = string.Empty; }
                    return mtch;
                    //if (null == mtch)
                    //    base.Properties.View.FocusedRowHandle = -99997;
                    //else
                    //{
                    //    base.Properties.View.Focus
                    //}
                    ////var gid = vl.GetType().GetProperty("Guid").GetValue(vl, null).ToString();
                    ////for (int i = 0; i < base.Properties.View.RowCount; i++)
                    ////{
                    ////    if (gid == base.Properties.View.GetRowCellValue(i, "Guid").ToString())
                    ////    {
                    ////        base.Properties.View.FocusedRowHandle = i;

                    ////        return (T)(base.Properties.View.GetRow(i));
                    ////    }
                    ////}
                    ////base.Properties.View.FocusedRowHandle = -99997;
                    ////return null;
                }
                return kt;
            }
            catch { return default(T); }
        }
    }
}
