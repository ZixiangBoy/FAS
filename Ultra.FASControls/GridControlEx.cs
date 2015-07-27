using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Ultra.Utility;
using System.Reflection;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.IO;
using MoreLinq;
using Ultra.FASControls.Extend;

namespace Ultra.FASControls
{
    public class GridControlEx : GridControl
    {
        public GridControlEx()
            : base()
        {
            base.DataSourceChanged += UltraGirdControl_DataSourceChanged;
            ShowRowNumber = true;
            base.MouseDoubleClick += new MouseEventHandler(GridControlEx_MouseDoubleClick);

            ripop.PopupControl = popctl; ripopReadOnly.PopupControl = popctlReadOnly;
            popctl.Controls.Add(medt); popctlReadOnly.Controls.Add(medtReadOnly);
            medt.Properties.BeforeShowMenu += Properties_BeforeShowMenu;
            medt.Dock = DockStyle.Fill; medtReadOnly.Dock = DockStyle.Fill;
            ripop.QueryPopUp += (s1, e1) =>
            {
                var vl = (s1 as DevExpress.XtraEditors.BaseEdit).EditValue;
                medt.Text = vl == null ? string.Empty : vl.ToString();

            };
            ripopReadOnly.QueryPopUp += (s1, e1) =>
            {
                var vl = (s1 as DevExpress.XtraEditors.BaseEdit).EditValue;
                medtReadOnly.Text = vl == null ? string.Empty : vl.ToString();
                medtReadOnly.Properties.ReadOnly = true;
            };
            ripop.QueryResultValue += (s1, e1) =>
            {
                e1.Value = medt.Text;
            };
            ripop.QueryDisplayText += (s1, e1) =>
            {
                e1.DisplayText = medt.Text;
            };
            //ripop.CloseUp += (s1, e1) => {
            //    if (!e1.AcceptValue)
            //    {
            //        PopupContainerEdit pSender = sender as PopupContainerEdit;
            //        RichEditControl rEdit = pSender.Properties.PopupControl.Controls[0] as RichEditControl;
            //        rEdit.Document.RtfText = e.Value.ToString();
            //    }
            //};
        }


        public static T DeSerialize<T>(string jsn)
        {
            //反射泛型方法
            var utildll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Newtonsoft.Json.dll");
            if (!File.Exists(utildll)) { return default(T); }
            var bts = File.ReadAllBytes(utildll);
            var asm = System.Reflection.Assembly.Load(bts); if (null == asm) return default(T);
            var t = asm.GetType("Newtonsoft.Json.JsonConvert"); if (null == t) return default(T);
            var mi = t.GetMethods().First(j => j.Name == "DeserializeObject" && j.IsGenericMethod && j.GetGenericArguments().Length == 1)
                ;
            var mig = mi.MakeGenericMethod(typeof(T)); if (mig == null) return default(T);
            var ojd = mig.Invoke(null, new object[] { jsn });
            return (T)Convert.ChangeType(ojd, typeof(T));
        }

        protected bool _alreadyInsMenu = false;
        //memoedit 右键菜单
        void Properties_BeforeShowMenu(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {
            if (_alreadyInsMenu) return;

            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem
            {
                Caption = "插入快捷短语",
                BeginGroup = true
            });
            _alreadyInsMenu = true;
        }

        DevExpress.XtraEditors.MemoEdit medt = new DevExpress.XtraEditors.MemoEdit();

        DevExpress.XtraEditors.MemoEdit medtReadOnly = new DevExpress.XtraEditors.MemoEdit();
        DevExpress.XtraEditors.PopupContainerControl popctl = new DevExpress.XtraEditors.PopupContainerControl();
        DevExpress.XtraEditors.PopupContainerControl popctlReadOnly = new DevExpress.XtraEditors.PopupContainerControl();

        List<string> _PopupTextFields = new List<string>();
        List<string> _PopupTextFieldsReadOnly = new List<string>();
        List<string> _ImageFields = new List<string>();
        List<string> _PrvCityDistrict = new List<string> { "省", "市", "区" };
        public List<string> PrvCityDistrict { get { return _PrvCityDistrict; } set { _PrvCityDistrict = value; } }
        //RepositoryItemTextEdit tePrv = new RepositoryItemTextEdit();
        //RepositoryItemTextEdit teCity = new RepositoryItemTextEdit();
        //RepositoryItemTextEdit teDistrict = new RepositoryItemTextEdit();
        RepositoryItemComboBox tePrv = new RepositoryItemComboBox();
        RepositoryItemComboBox teCity = new RepositoryItemComboBox();
        RepositoryItemComboBox teDistrict = new RepositoryItemComboBox();
        string prvField; string cityField; string districtField;

        

        /// <summary>
        /// 设置是否开启自动省市区自动完成
        /// </summary>
        /// <param name="bok"></param>
        /// <returns></returns>
        public bool SetAutoPrvCityDistrict(bool bok = true)
        {
            this.AutoPrvCityDistrict = bok;

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in DefGridView.Columns)
            {
                if (PrvCityDistrict[0].Equals(col.Caption, StringComparison.OrdinalIgnoreCase))
                {
                    prvField = col.FieldName;
                    tePrv.AutoComplete = true;
                    col.ColumnEdit = bok ? tePrv : null;
                }
                if (PrvCityDistrict[1].Equals(col.Caption, StringComparison.OrdinalIgnoreCase))
                {
                    cityField = col.FieldName;
                    teCity.AutoComplete = true;
                    col.ColumnEdit = bok ? teCity : null;
                }
                if (PrvCityDistrict[2].Equals(col.Caption, StringComparison.OrdinalIgnoreCase))
                {
                    districtField = col.FieldName;
                    teDistrict.AutoComplete = true;
                    col.ColumnEdit = bok ? teDistrict : null;
                }
            }
            return this.AutoPrvCityDistrict;
        }

        DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit ripop = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();

        DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit ripopReadOnly = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();

        public List<string> PopupTextFields
        {
            get { return _PopupTextFields; }
            set { _PopupTextFields = value; }
        }

        public List<string> PopupTextFieldsReadOnly
        {
            get { return _PopupTextFieldsReadOnly; }
            set { _PopupTextFieldsReadOnly = value; }
        }

        public List<string> ImageFields { get { return _ImageFields; } set { _ImageFields = value; } }

        protected int defaultIndicatorWidth = Int32.MinValue;


        void UltraGirdControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (null == DefGridView) return;
            //foreach (DevExpress.XtraGrid.Columns.GridColumn col in DefGridView.Columns)
            //{
            //    if (col.FieldName.Equals("UISelected")) continue;
            //    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //}
            if (null != base.DataSource)
            {
                IList ListDataSource = base.DataSource as IList;
                if (null != ListDataSource)
                {
                    if (defaultIndicatorWidth == Int32.MinValue) defaultIndicatorWidth = DefGridView.IndicatorWidth;//保存原始的指示器宽度
                    if (this.ShowIndicator && this.ShowRowNumber)
                    {
                        DefGridView.IndicatorWidth = TextRenderer.MeasureText(ListDataSource.Count.ToString(), this.Font).Width + 15;
                    }
                    else
                        DefGridView.IndicatorWidth = defaultIndicatorWidth;

                }
            }
        }

        private bool _rowdbclickdel = false;

        /// <summary>
        /// 是否启用双击行删除所选数据
        /// </summary>
        [
        Description("是否启用双击行删除所选数据"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool RowDoubleClickDeleteRow { get { return _rowdbclickdel; } set { _rowdbclickdel = value; } }

        private bool _edtable = false;

        [
      Description("是否启用双击自动弹出旺旺"),
      DefaultValue(false),
      Browsable(true),
      Category("Ultra")
      ]
        public bool AutoCallWW { get { return _autoCallWW; } set { _autoCallWW = value; } }

        private bool _autoCallWW = true;

        [
      Description("是否启用对可编辑单元格应用自动背景色"),
      DefaultValue(true),
      Browsable(true),
      Category("Ultra")
      ]
        public bool AutoEdtCellBackColor { get { return _autoEdtCellBackColor; } set { _autoEdtCellBackColor = value; } }
        protected Color edtCellBackColor = Color.FromArgb(255, 229, 185, 183);
        private bool _autoEdtCellBackColor = true;

        [
      Description("是否启用省市区自动输入提示完成"),
      DefaultValue(false),
      Browsable(true),
      Category("Ultra")
      ]
        public bool AutoPrvCityDistrict { get { return _autoPrvCityDistrict; } set { _autoPrvCityDistrict = value; } }
        private bool _autoPrvCityDistrict = false;

        /// <summary>
        /// 是否可编辑网格
        /// </summary>
        [
        Description("是否可编辑网格"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool Editable { get { return _edtable; } set { _edtable = value; } }

        private bool _EnableCellStyleColor = false;
        [
        Description("标识是否启用单元格数据改变后变换单元格背景色"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool EnableCellStyleColor { get { return _EnableCellStyleColor; } set { _EnableCellStyleColor = value; } }

        private Color _CellStyleColor = Color.FromArgb(192, 192, 0);
        [
        Description("单元格数据改变后显示的背景色"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public Color CellStyleColor { get { return _CellStyleColor; } set { _CellStyleColor = value; } }

        private object _ShadowDataSource = null;
        [
        Description("用于指定检测单元格数据是否改变的数据源"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public object ShadowDataSource
        {
            get { return _ShadowDataSource; }
            set
            {
                _ShadowDataSource = value;
            }
        }
        private string _ShadowDataSourceKey = "Guid";
        [
        Description("用于指定检测单元格数据是否改变的数据源"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public string ShadowDataSourceKey { get { return _ShadowDataSourceKey; } set { _ShadowDataSourceKey = value; } }

        [
        Description("用于指定单元格数据是否显示为数据已经改变的背景色的数据源"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public object RowCellColorStyleSource { get; set; }
        private string _PropName = "PropName";
        public string PropName { get { return _PropName; } set { _PropName = value; } }

        [
        Description("委托，用于调用者自定义判断单元格内容是否变化的处理，如果变化则返回true"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public Func<RowCellStyleEventArgs, bool> Func_IsCellValueChanged;

        #region Public Methods

        /// <summary>
        /// 不选中任何行
        /// </summary>
        public void ReleaseFocusedRow()
        {
            if (null != DefGridView)
                DefGridView.ReleaseFocusedRow();
        }

        #endregion

        #region Desinger

        /// <summary>
        /// 是否显示分组面板
        /// </summary>
        [
        Description("是否显示分组面板"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool ShowGroupPanel
        {
            get
            {
                if (null == DefGridView) return false;
                return DefGridView.OptionsView.ShowGroupPanel;
            }
            set
            {
                if (null == DefGridView) return;
                DefGridView.OptionsView.ShowGroupPanel = value;
            }
        }

        [
        Description("行背景色自动套用字段名称"),
        DefaultValue(""),
        Browsable(true),
        Category("Ultra")
        ]
        public string ColorFieldName { get; set; }

        /// <summary>
        /// 是否显示行指示器
        /// </summary>
        [
        Description("是否显示行指示器"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool ShowIndicator
        {
            get
            {
                if (null == DefGridView) return false;
                return DefGridView.OptionsView.ShowIndicator;
            }
            set
            {
                if (null == DefGridView) return;
                DefGridView.OptionsView.ShowIndicator = value;
            }
        }

        /// <summary>
        /// 是否显示号,要显示行号首先要求 ShowIndicator为true
        /// </summary>
        [
        Description("是否显示号,要显示行号首先要求 ShowIndicator为true"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool ShowRowNumber { get; set; }


        /// <summary>
        /// 双击单元格时触发事件
        /// </summary>
        [Category("Ultra")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("双击单元格时触发事件")]
        public event EventHandler<MouseEventArgs> RowCellDoubleClick;

        #endregion

        protected DevExpress.XtraGrid.Views.Grid.GridView DefGridView { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            var vw = DefGridView = base.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null != vw)
            {
                vw.OptionsView.ShowGroupPanel = false;// this.ShowGroupPanel;
                //vw.OptionsView.ColumnAutoWidth = false;
                vw.OptionsView.ShowIndicator = this.ShowIndicator;
                vw.PopupMenuShowing -= vw_PopupMenuShowing;
                vw.PopupMenuShowing += vw_PopupMenuShowing;
                vw.CustomDrawRowIndicator -= vw_CustomDrawRowIndicator;
                vw.CustomDrawRowIndicator += vw_CustomDrawRowIndicator;
                vw.RowStyle -= vw_RowStyle; vw.RowStyle += vw_RowStyle;
                vw.OptionsView.ShowAutoFilterRow = true;
                vw.MouseDown += vw_MouseDown;
                vw.KeyDown += vw_KeyDown;
                vw.Appearance.SelectedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
                vw.Appearance.FocusedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
                vw.OptionsBehavior.Editable = Editable;// false;
                vw.CustomRowCellEditForEditing += vw_CustomRowCellEditForEditing;

                vw.CustomUnboundColumnData -= vw_CustomUnboundColumnData;
                vw.CustomUnboundColumnData += vw_CustomUnboundColumnData;
                vw.RowCellStyle -= vw_RowCellStyle;
                vw.RowCellStyle += vw_RowCellStyle;
                vw.CustomDrawColumnHeader -= vw_CustomDrawColumnHeader;
                vw.CustomDrawColumnHeader += vw_CustomDrawColumnHeader;
                vw.Click -= vw_Click;
                vw.Click += vw_Click;
                //vw.RowCountChanged += (s1, e1) =>
                //{
                //    if (this.ShowIndicator && this.ShowRowNumber)
                //    {
                //        vw.IndicatorWidth = TextRenderer.MeasureText(vw.RowCount.ToString(), this.Font).Width + 30;
                //    }
                //    else
                //        vw.IndicatorWidth = defaultIndicatorWidth;
                //};
                if (ShowRowNumber)
                {
                    vw.IndicatorWidth = 44;
                }
                if (!IsDesignMode)
                    LoadLayout();
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in vw.Columns)
                {
                    col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                    //自动应用可编辑单元格背景色为淡绿色
                    if (this.Editable && col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly
                        && col.OptionsColumn.AllowFocus && col.UnboundType != DevExpress.Data.UnboundColumnType.Object
                       && (PopupTextFields != null && PopupTextFields.Count(v => v.Equals(col.FieldName)) < 1)
                       && (PopupTextFieldsReadOnly != null && PopupTextFieldsReadOnly.Count(v => v.Equals(col.FieldName)) < 1)
                        && !EnableCellStyleColor
                        && AutoEdtCellBackColor)
                        col.AppearanceCell.BackColor = this.edtCellBackColor;

                }
            }
        }

        void DoRowCellColorStyleSetting(RowCellStyleEventArgs e)
        {
            var obj = DefGridView.GetRow(e.RowHandle);
            if (null == obj) return;
            //得到key值
            var ojv = obj.GetType().GetProperty(ShadowDataSourceKey).GetValue(obj, null);
            if (ojv == null) return;
            var iq = (RowCellColorStyleSource as IEnumerable<object>);
            if (null == iq) return;
            var fie = e.Column.FieldName;
            if (string.IsNullOrEmpty(fie)) return;
            var ien = iq.GetEnumerator();
            object mtchobj = null;
            while (ien.MoveNext())
            {
                var mthvlu = ien.Current.GetType().GetProperty(ShadowDataSourceKey).GetValue(ien.Current, null);
                if (mthvlu != null && ojv != null && ojv.ToString().Equals(mthvlu.ToString()))
                { mtchobj = ien.Current; break; }
            }
            if (mtchobj == null) return;
            var piv = mtchobj.GetType().GetProperty(PropName);
            if (piv == null) return;
            var shdvlu = piv.GetValue(mtchobj, null);
            if (null == shdvlu) return;
            if (fie.Equals(shdvlu.ToString()))
            {
                e.Appearance.BackColor = CellStyleColor;
                return;
            }
        }

        void vw_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (EnableCellStyleColor && null != Func_IsCellValueChanged)
            {
                var b = Func_IsCellValueChanged(e);
                if (b)
                {
                    e.Appearance.BackColor = CellStyleColor;
                    return;
                }
            }
            else if (EnableCellStyleColor)
            {
                var obj = DefGridView.GetRow(e.RowHandle);
                if (null == obj) return;
                //得到key值
                var vpi = obj.GetType().GetProperty(ShadowDataSourceKey);
                if (vpi == null) return;
                var ojv = vpi.GetValue(obj, null);
                if (ojv == null) return;
                var iq = (ShadowDataSource as IEnumerable<object>);
                if (null == iq) return;
                var fie = e.Column.FieldName;
                if (string.IsNullOrEmpty(fie)) return;
                var ien = iq.GetEnumerator();
                object mtchobj = null;
                while (ien.MoveNext())
                {
                    var mthvlu = ien.Current.GetType().GetProperty(ShadowDataSourceKey).GetValue(ien.Current, null);
                    if (mthvlu != null && ojv != null && ojv.ToString().Equals(mthvlu.ToString()))
                    { mtchobj = ien.Current; break; }
                }
                if (mtchobj == null) return;
                var piv = mtchobj.GetType().GetProperty(fie);
                if (piv == null) return;
                var shdvlu = piv.GetValue(mtchobj, null);
                if (e.CellValue == null && shdvlu != null)
                {
                    e.Appearance.BackColor = CellStyleColor;
                    return;
                }
                if (e.CellValue != null && null != shdvlu && !shdvlu.ToString().Equals(e.CellValue.ToString()))
                {
                    e.Appearance.BackColor = CellStyleColor;
                }
                else
                    e.Appearance.BackColor = Color.Empty;
            }

            if (null != RowCellColorStyleSource)
            {
                DoRowCellColorStyleSetting(e);
            }
        }

        void vw_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (ImageFields == null || ImageFields.Count < 1) return;
            var fie = Ultra.Web.Core.Common.MethodExtend.LeftPart(e.Column.FieldName, "_");
            if (string.IsNullOrEmpty(fie)) return;
            if (e.IsGetData && ImageFields.Exists(j => j.Equals(e.Column.FieldName)))
            {
                object oj = e.Row;
                var opi = oj.GetType().GetProperty(fie);
                if (null == opi) return;
                var ojv = opi.GetValue(oj, null);//得到图片URL
                if (ojv == null) return;
                var url = ojv.ToString(); var urlhsh = Ultra.Web.Core.Common.MethodExtend.Hash(url);
                var lfile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");
                if (!System.IO.Directory.Exists(lfile)) System.IO.Directory.CreateDirectory(lfile);
                lfile = System.IO.Path.Combine(lfile, urlhsh);
                Image img = null;
                if (System.IO.File.Exists(lfile))
                    //img = Image.FromFile(lfile);
                    img = ImgFromFileNoLock(lfile);
                else
                {
                    //网络图片
                    if (url.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                        || url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                    {
                        img = Ultra.Web.Core.Common.MethodExtend.GetImage(url);
                        try { img.Save(lfile); }
                        catch { }
                    }
                    else
                    {
                        if (System.IO.File.Exists(url))
                            img = ImgFromFileNoLock(url);
                    }
                }
                e.Value = img;
            }
        }

        void vw_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (null != PopupTextFields && PopupTextFields.Where(j => j == e.Column.FieldName).Count() > 0)
            {
                e.RepositoryItem = ripop;
                //medt.Properties.ReadOnly = e.Column.ReadOnly;
            }
            else
            {
                if (PopupTextFieldsReadOnly != null && PopupTextFieldsReadOnly.Where(j => j == e.Column.FieldName).Count() > 0)
                {
                    e.RepositoryItem = ripopReadOnly;

                }
            }
        }

        void vw_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (string.IsNullOrEmpty(ColorFieldName)) return;
            if (e.RowHandle < 0) return;
            var ojv = DefGridView.GetRowCellValue(e.RowHandle, ColorFieldName);
            if (null != ojv)
                try
                {
                    e.Appearance.BackColor = ojv.ToString().ToColor();
                }
                catch { }
            else
            {
                try
                {
                    object oj = DefGridView.GetRow(e.RowHandle);
                    ojv = oj.GetType().GetProperty(ColorFieldName).GetValue(oj, null);
                    if (null != ojv)
                        e.Appearance.BackColor = ojv.ToString().ToColor();
                }
                catch { }
            }
        }

        void vw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.Control) & e.KeyCode == Keys.C)
                {
                    GridView gridView = (GridView)sender;
                    string value = gridView.GetFocusedRowCellValue(gridView.FocusedColumn).ToString();
                    Clipboard.SetDataObject(value);
                    e.Handled = true;
                }
                else if ((e.Control) & e.Shift & e.Alt & (e.KeyCode == Keys.K))//ctrl+alt+shift+k
                {
                    Ultra.Common.ExtendCommon.GridExportXls(this);
                }
            }
            catch { }
        }

        DevExpress.Utils.Menu.DXMenuItem LayOutMuItm { get; set; }

        public Image ImgFromFileNoLock(string fi)
        {
            if (!System.IO.File.Exists(fi)) return null;
            using (var ms = new System.IO.MemoryStream())
            {
                var bts = System.IO.File.ReadAllBytes(fi);
                ms.Write(bts, 0, bts.Length);
                return Image.FromStream(ms);
            }
        }

        void SaveLayout()
        {
            var fm = FindForm();
            string xml = this.MainView.Name;

            var fvr = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            if (null != fm)
                xml = string.Format("{0}.{1}.{2}", fm.GetType().FullName, xml, fvr);

            xml = Ultra.Web.Core.Common.ByteStringUtil.ByteArrayToHexStr(
                Ultra.Web.Core.Common.HashDigest.StringDigest(xml));

            var pth = System.IO.Path.Combine(Application.StartupPath, "LayOut");
            if (!System.IO.Directory.Exists(pth))
                System.IO.Directory.CreateDirectory(pth);

            xml = System.IO.Path.Combine(pth, xml + ".lay");
            this.MainView.SaveLayoutToXml(xml);
        }

        void LoadLayout()
        {
            try
            {
                var fm = FindForm();
                string xml = this.MainView.Name;
                var fvr = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                if (null != fm)
                    xml = string.Format("{0}.{1}.{2}", fm.GetType().FullName, xml, fvr);

                xml = Ultra.Web.Core.Common.ByteStringUtil.ByteArrayToHexStr(
                    Ultra.Web.Core.Common.HashDigest.StringDigest(xml));

                var pth = System.IO.Path.Combine(Application.StartupPath, "LayOut");
                xml = System.IO.Path.Combine(pth, xml + ".lay");
                if (!System.IO.File.Exists(xml)) return;
                this.MainView.RestoreLayoutFromXml(xml);
            }
            catch (Exception ex) { }
        }

        void ResetLayout()
        {
            var fm = FindForm();
            string xml = this.MainView.Name;
            var fvr = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            if (null != fm)
                xml = string.Format("{0}.{1}.{2}", fm.GetType().FullName, xml, fvr);

            xml = Ultra.Web.Core.Common.ByteStringUtil.ByteArrayToHexStr(
                Ultra.Web.Core.Common.HashDigest.StringDigest(xml));

            var pth = System.IO.Path.Combine(Application.StartupPath, "LayOut");
            xml = System.IO.Path.Combine(pth, xml + ".lay");
            try
            {
                System.IO.File.Delete(xml);

            }
            catch (Exception ex) { }
            finally
            {

            }
        }

        void vw_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                if (menu != null)
                {
                    foreach (DevExpress.Utils.Menu.DXMenuItem item in menu.Items)
                    {
                        //禁止显示隐藏列
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnColumnCustomization))
                            item.Enabled = false;
                        //禁止GridStringId.MenuColumnGroup=根据此列分组
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnGroup))
                            item.Enabled = false;
                        //禁止GridStringId.MenuColumnGroupBox=分组依据框
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnGroupBox))
                            item.Enabled = false;
                        //禁止GridStringId.MenuColumnRemoveColumn=移除列
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnRemoveColumn))
                            item.Enabled = false;
                        //禁止Show Group By Box
                        if (0 == string.Compare(
                            item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuGroupPanelShow), true
                            ))
                            item.Visible = item.Enabled = false;
                        //Show Auto Filter Row
                        if (0 == string.Compare(item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnAutoFilterRowShow), true))
                            item.Caption = "显示查询行";
                        if (0 == string.Compare(item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnAutoFilterRowHide), true))
                            item.Caption = "隐藏查询行";
                        //禁止Show Find Panel
                        if (0 == string.Compare(item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnFindFilterShow), true))
                            item.Visible = item.Enabled = false;
                    }
                    //if (null == LayOutMuItm)
                    {
                        LayOutMuItm = new DevExpress.Utils.Menu.DXMenuItem("保存布局",
                            (s1, e1) =>
                            {
                                SaveLayout();
                            });
                        menu.Items.Add(LayOutMuItm);
                        var rtl = new DevExpress.Utils.Menu.DXMenuItem("恢复默认布局",
                            (s1, e1) => { ResetLayout(); });
                        menu.Items.Add(rtl);
                    }
                }
            }
        }

        void vw_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!ShowIndicator) return;
            if (!ShowRowNumber) return;
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {

                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        [
        Description("GridView双击事件"),
        Category("Ultra"),
        Browsable(true)
        ]
        public event EventHandler<System.Windows.Forms.MouseEventArgs> ViewMouseDoubleClick;

        [
        Description("GridView鼠标右击事件"),
        Category("Ultra"),
        Browsable(true)
        ]
        public event EventHandler<System.Windows.Forms.MouseEventArgs> ViewMouseRightClick;

        void vw_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo ghi = gv.CalcHitInfo(e.X, e.Y);
            if (AutoCallWW && ghi.InRow && ghi.InRowCell && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var dfv = (DefaultView as GridView);
                if (null != dfv)
                {
                    if (dfv.FocusedColumn.Caption.Equals("买家", StringComparison.OrdinalIgnoreCase) ||
                        dfv.FocusedColumn.Caption.Equals("买家昵称", StringComparison.OrdinalIgnoreCase))
                    {
                        dfv.FocusedColumn.OptionsColumn.AllowEdit = false;
                    }
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                if (ghi.InRow)
                {
                    if (null != ViewMouseDoubleClick)
                        ViewMouseDoubleClick(sender, e);
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (ghi.InRow && RightMenu != null)
                {
                    RightMenu.Show(Cursor.Position);
                }
                if (ghi.InRow && PopupMnu != null)
                {
                    PopupMnu.ShowPopup(Cursor.Position);
                }
            }
        }


        void GridControlEx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = base.MainView.CalcHitInfo(e.X, e.Y) as GridHitInfo;
            if (null == info) return;
            if (((e.Button == MouseButtons.Left) && (e.Clicks == 2)) && info.InRow)
            {
                if (RowDoubleClickDeleteRow)
                    this.RemoveSelected();
                var dfv = (DefaultView as GridView);
                if (AutoCallWW && null != dfv)
                {
                    if (dfv.FocusedColumn.Caption.Equals("买家", StringComparison.OrdinalIgnoreCase) ||
                        dfv.FocusedColumn.Caption.Equals("买家昵称", StringComparison.OrdinalIgnoreCase))
                    {
                        //dfv.FocusedColumn.OptionsColumn.AllowEdit = false;
                        var wwnick = string.Format("cntaobao{0}", dfv.FocusedValue.ToString());
                        Ultra.Web.Core.Common.SystemInvoke.OpenFile(
                      string.Format("aliim:sendmsg?touid={0}&siteid=cntaobao&status=1", wwnick));
                        return;//判断是这样的两个列的话,不需要去触发后面的事件了.
                    }
                }
                if (null != this.RowCellDoubleClick)
                    this.RowCellDoubleClick(sender, e);
            }
        }

        /// <summary>
        /// 根据列值条件设置行颜色
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fieldName"></param>
        /// <param name="matchVlu"></param>
        private void SetRowBackColor(Color color, string fieldName, object matchVlu)
        {
            if (null == DefGridView) return;
            DevExpress.XtraGrid.Columns.GridColumn col = null;
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in DefGridView.Columns)
            {
                if (string.Compare(fieldName, item.FieldName) == 0)
                {
                    col = item;
                    break;
                }
            }
            if (col == null) return;

            DevExpress.XtraGrid.StyleFormatCondition[] formats = new DevExpress.XtraGrid.StyleFormatCondition[1];
            DevExpress.XtraGrid.StyleFormatCondition format = new DevExpress.XtraGrid.StyleFormatCondition();
            format.Appearance.Options.UseBackColor = true;
            format.Appearance.BackColor = color;
            format.ApplyToRow = true;
            format.Column = col;
            format.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            format.Value1 = matchVlu;
            formats[0] = format;
            DefGridView.FormatConditions.AddRange(formats);
        }

        /// <summary>
        /// 为指定的列绑定淘宝旗帜图像列
        /// </summary>
        /// <param name="fieldName"></param>
        public void SetTaoBaoFlag(string fieldName = "SellerFlag")
        {
            RepositoryItemImageComboBox imageCombo = this.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;
            imageCombo.SmallImages = Ultra.Surface.Common.SurfaceUtil.SellerFlags;
            imageCombo.Items.Add(new ImageComboBoxItem("灰", 0, 0));
            imageCombo.Items.Add(new ImageComboBoxItem("红 1", 1, 1));
            imageCombo.Items.Add(new ImageComboBoxItem("黄 2", 2, 2));
            imageCombo.Items.Add(new ImageComboBoxItem("绿 3", 3, 3));
            imageCombo.Items.Add(new ImageComboBoxItem("蓝 4", 4, 4));
            imageCombo.Items.Add(new ImageComboBoxItem("紫 5", 5, 5));
            imageCombo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            if (null != DefGridView)
                DefGridView.Columns[fieldName].ColumnEdit = imageCombo;
        }

        /// <summary>
        /// 行右键菜单
        /// </summary>
        [
        Description("行右键菜单"), Category("Ultra"), Browsable(true)
        ]
        public ContextMenuStrip RightMenu
        {
            get;
            set;
        }

        [
        Description("行右键菜单"), Category("Ultra"), Browsable(true)
        ]
        public DevExpress.XtraBars.PopupMenu PopupMnu
        {
            get;
            set;
        }

        public void CheckAll()
        {
            for (int i = 0; i < DefGridView.DataRowCount; i++)
            {
                DefGridView.SetRowCellValue(i, DefGridView.Columns["UISelected"], true);
            }
        }

        public void UnChekAll()
        {
            for (int i = 0; i < DefGridView.DataRowCount; i++)
            {
                DefGridView.SetRowCellValue(i, DefGridView.Columns["UISelected"], false);
            }
        }

        public int GetCheckedCount()
        {
            int count = 0;
            for (int i = 0; i < DefGridView.DataRowCount; i++)
            {
                if ((bool)DefGridView.GetRowCellValue(i, DefGridView.Columns["UISelected"]) == true)
                    count++;
            }
            return count;
        }

        #region [列选择，行全选]

        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked, RepositoryItemCheckEdit chkedit)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = chkedit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = chkedit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;

            info.Bounds = r;
            info.PaintAppearance.ForeColor = Color.Black;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        RepositoryItemCheckEdit chkedit2 = new RepositoryItemCheckEdit();
        void vw_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (IsDesignMode) return;
            if (e.Column == (sender as GridView).Columns["UISelected"] && e.Column != null)
            {
                e.Column.OptionsColumn.AllowSort = DefaultBoolean.False;
                e.Info.InnerElements.Clear();
                e.Info.Appearance.ForeColor = Color.Blue;
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, GetCheckedCount() == (sender as GridView).DataRowCount, chkedit2);
                e.Handled = true;
            }
        }

        void vw_Click(object sender, EventArgs e)
        {
            GridHitInfo info; var _view = DefGridView; var column = (sender as GridView).Columns["UISelected"];
            Point pt = _view.GridControl.PointToClient(Control.MousePosition);
            info = _view.CalcHitInfo(pt);
            if (info.Column == column)
            {
                if (info.InColumn && info.Column.FieldName == "UISelected")
                {
                    if (GetCheckedCount() == _view.DataRowCount)
                        UnChekAll();
                    else
                        CheckAll();
                }
                //if (info.InRowCell)
                //{
                //    //InvertRowSelection(info.RowHandle);
                //}
            }
        }

        #endregion
    }
}
