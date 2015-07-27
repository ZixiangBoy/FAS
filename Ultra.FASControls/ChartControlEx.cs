using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts.Printing;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraCharts;
using System.Data;
using DevExpress.Utils;

namespace Ultra.FASControls
{
    /// <summary>
    /// 继承的ChartControl 包装图表显示的操作
    /// </summary>
    public class ChartControlEx : DevExpress.XtraCharts.ChartControl
    {
        #region [ Variables ]

        //private DevExpress.XtraBars.BarManager barManager1= new DevExpress.XtraBars.BarManager();        
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
        //private DevExpress.XtraBars.PopupMenu ctxMnuCommodity = new DevExpress.XtraBars.PopupMenu();

        private ToolTipController tooltipCtl = new ToolTipController();
        private readonly string ExportTitleName = "导出到文件";
        public DevExpress.XtraBars.BarManager barManager1;
        private IContainer components;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarSubItem barBtnItemViewType;
        public DevExpress.XtraBars.PopupMenu ctxMnuCommodity;

        private readonly string ExportFilter =
            "EXCEL 文档(*.xls;*.xlsx)|*.xls;*.xlsx|HTML 文档|*.htm;*.html|图片|*.jpeg;*.jpg";

        #endregion

        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarCheckItem barChkShowRight;

        public XYDiagram ChartDiagram { get { return Diagram as XYDiagram; } }

        #region [ Desinger Properties ]

        [Browsable(true)]
        [Category("Apex")]
        public DevExpress.XtraBars.BarManager BarMgr { get { return this.barManager1; } }

        [Browsable(true)]
        [Category("Apex")]
        public DevExpress.XtraBars.PopupMenu PopMnu { get { return this.ctxMnuCommodity; } }

        private bool _AisXShow = true;

        /// <summary>
        /// 是否显示X轴文字内容
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("是否显示X轴文字内容")]
        [Category("Apex")]
        public bool AxisXVisiable
        {
            get { return _AisXShow; }
            set { _AisXShow = value; }
        }

        private int _AntialiasingValue = 30;
        /// <summary>
        /// X轴斜率值
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("X轴斜率值")]
        [Category("Apex")]
        public int AntialiasingValue
        {
            get { return _AntialiasingValue; }
            set { _AntialiasingValue = value; }
        }

        /// <summary>
        /// 是否开启X轴斜率
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("是否开启X轴斜率")]
        [Category("Apex")]
        public bool Antialiasing
        {
            get;
            set;
        }


        /// <summary>
        /// Y轴说明文字
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Y轴说明文字")]
        [Category("Apex")]
        public string AxisYTitle { get; set; }

        /// <summary>
        /// X轴说明文字
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("X轴说明文字")]
        [Category("Apex")]
        public string AxisXTitle { get; set; }

        /// <summary>
        /// 是否允许滚动
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("是否允许滚动")]
        [Category("Apex")]
        public bool EnableScrolling { get; set; }

        /// <summary>
        /// 是否允许缩放
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("是否允许缩放")]
        [Category("Apex")]
        public bool EnableZooming { get; set; }

        /// <summary>
        /// 是否允许运行时选中Series
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("是否允许运行时选中Series")]
        [Category("Apex")]
        public bool EnalbeRuntimeSelection { get; set; }

        /// <summary>
        /// SeriesSelectionMode
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("SeriesSelectionMode")]
        [Category("Apex")]
        public SeriesSelectionMode SerSelectionMode { get; set; }

        /// <summary>
        /// 当鼠标点击到图表点数据时是否显示提示信息
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("当鼠标点击到图表点数据时是否显示提示信息")]
        [Category("Apex")]
        public bool OnMouseClickShowSeriesInfo { get; set; }

        private string _ShowSeriesInfoFormat = "{0} - {1:N0}";

        /// <summary>
        /// 当鼠标点击到图表点数据时是否显示的提示信息的格式化串
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("当鼠标点击到图表点数据时是否显示的提示信息的格式化串")]
        [Category("Apex")]
        public string ShowSeriesInfoFormat
        {
            get { return _ShowSeriesInfoFormat; }
            set { _ShowSeriesInfoFormat = value; }
        }

        /// <summary>
        /// 是否开启3D旋转
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("是否开启3D旋转")]
        [Category("Apex")]
        public bool Enable3DRoation { get; set; }

        /// <summary>
        /// 图表类型:饼图,直方图,....
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("图表类型:饼图,直方图,....")]
        public ViewType ChartViewType { get; set; }

        /// <summary>
        /// 轴的数字显示样式,百分比或数字
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("Y轴的数字显示样式,百分比或数字")]
        public NumericFormat AxisY
        {
            get;
            set;
        }

        /// <summary>
        /// 用于图表计算单元的数据源中的列名
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("用于图表计算单元的数据源中的列名")]
        [DefaultValue("")]
        public string FieldOfSeriesName { get; set; }

        private string _strNoData = "无数据";

        /// <summary>
        /// 当图表无数据时显示的提示文字
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("当图表无数据时显示的提示文字")]
        public string NoDataTipText { get { return _strNoData; } set { _strNoData = value; } }

        /// <summary>
        /// Y轴的数字显示样式,百分比或数字的小数点后位数
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("Y轴的数字显示样式,百分比或数字的小数点后位数")]
        public int AxisYPrecision
        { get; set; }

        /// <summary>
        /// X轴的数据所绑定的数据源的列名
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("X轴的数据所绑定的数据源的列名")]
        public string ArgumentDataMember { get; set; }

        /// <summary>
        /// Y轴的数据所绑定的数据源的列名
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("Y轴的数据所绑定的数据源的列名")]
        public string ValueDataMembers { get; set; }

        /// <summary>
        /// 图表显示数据数据源
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("图表显示数据数据源")]
        public object SeriesDataSource { get; set; }

        /// <summary>
        /// 图表点数据显示样式
        /// </summary>
        [DefaultValue("{A}:{V}")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        [Description("图表点数据显示样式")]
        public string PointParttern { get; set; }

        /// <summary>
        /// 当鼠标点击在图表上的某一点数据呈现点上时触发
        /// </summary>
        [Description("当鼠标点击在图表上的某一点数据呈现点上时触发")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Apex")]
        public event EventHandler<CharHitInfoArg> OnChartHit;    

        #endregion

        #region [ Properties ]

        private string _exportName = string.Empty;

        /// <summary>
        /// 默认的导出文件名称(不含扩展名)
        /// </summary>
        public string ExportName
        {
            get
            {
                if (!string.IsNullOrEmpty(_exportName))
                    return _exportName;
                if (base.Titles != null)
                {
                    if (base.Titles.Count > 0)
                        return base.Titles[0].Text;
                    else
                        return string.Empty;
                }
                return _exportName;
            }
            set { _exportName = value; }
        }

        /// <summary>
        /// 承载控件的窗口
        /// </summary>
        public Form ContainerForm { get; set; }

        #endregion

        #region [ Methods ]

        #region [ Control Properties Init ]

        private void Init()
        {
            //this.ctxMnuCommodity.Manager = barManager1;
            //InitBarManage();
            //InitContextMenu();
            //InitExportMenuItem();
            //InitPrintMenuItem();

            this.barBtnItemViewType = new DevExpress.XtraBars.BarSubItem();
            this.barBtnItemViewType.Caption = "图表样式";
            this.ctxMnuCommodity.AddItem(this.barBtnItemViewType);
            this.barBtnItemViewType.AddItems(ChartViewTypeItem());
        }

        private void InitBarManage()
        {
            //try
            //{
            //    this.barManager1.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            //new DevExpress.XtraBars.BarManagerCategory("CtxMnu", new System.Guid("3D3A09CA-A09D-4e60-A298-72D4C1D71B6B"))});
            //    //this.barManager1.DockControls.Add(this.barDockControlTop);
            //    //this.barManager1.DockControls.Add(this.barDockControlBottom);
            //    //this.barManager1.DockControls.Add(this.barDockControlLeft);
            //    //this.barManager1.DockControls.Add(this.barDockControlRight);                
            //    this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            //this.barButtonItem1,
            //this.barButtonItem2});
            //    this.barManager1.MaxItemId = 9;
            //    this.barManager1.SetPopupContextMenu(barManager1.Form, this.ctxMnuCommodity);
            //}
            //catch (System.Exception ex)
            //{

            //}
        }

        private void InitExportMenuItem()
        {
            //this.barButtonItem1.Caption = "导出";
            //this.barButtonItem1.Id = 7;
            //this.barButtonItem1.Name = "barButtonItem1";
            //this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
        }

        private void InitPrintMenuItem()
        {
            //this.barButtonItem2.Caption = "打印";
            //this.barButtonItem2.Id = 8;
            //this.barButtonItem2.Name = "barButtonItem2";
            //this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
        }

        private void InitContextMenu()
        {
            //this.ctxMnuCommodity.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            //new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            //new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            //this.ctxMnuCommodity.Manager = this.barManager1;
            //this.ctxMnuCommodity.Name = "ctxMnuCommodity";
        }

        #endregion

        #region [ Event Handler ]

        /// <summary>
        /// 显示导出文件对话框
        /// </summary>
        /// <returns></returns>
        string ShowSaveFileDialog()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Title = ExportTitleName;
            dlg.FileName = ExportName;
            dlg.Filter = ExportFilter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            else
                return string.Empty;
        }

        /// <summary>
        /// 打印,打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.OptionsPrint.SizeMode = PrintSizeMode.Zoom;
            base.ShowPrintPreview();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = ShowSaveFileDialog();
            if (string.IsNullOrEmpty(fileName))
                return;
            string extName = Path.GetExtension(fileName);
            switch (extName.ToLower())
            {
                case ".html":
                case ".htm":
                    base.ExportToHtml(fileName);
                    break;
                case ".xls":
                case ".xlsx":
                    base.ExportToXls(fileName);
                    break;
                case ".jpeg":
                case ".jpg":
                    base.ExportToImage(fileName, ImageFormat.Jpeg);
                    break;
                case ".pdf":
                    base.ExportToPdf(fileName);
                    break;
                default:
                    break;
            }
            XtraMessageBox.Show("导出完成", "导出完成", MessageBoxButtons.OK);
        }

        #endregion

        #endregion

        public ChartControlEx()
            : base()
        {
            InitializeComponent();
            Init();

            this.tooltipCtl.ToolTipType = ToolTipType.SuperTip;
            this.MouseClick += chartControlEx1_MouseClick;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(ChartControl_MouseUp);
        }

        DevExpress.XtraBars.BarItem[] ChartViewTypeItem()
        {
            var lst = new List<DevExpress.XtraBars.BarItem>(10);
            var btn = new DevExpress.XtraBars.BarButtonItem();
            btn.Caption = "曲线图"; btn.Tag = ViewType.Spline;
            btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btn_ItemClick);
            lst.Add(btn);
            btn = new DevExpress.XtraBars.BarButtonItem();
            btn.Caption = "直方图"; btn.Tag = ViewType.Bar;
            btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btn_ItemClick);
            lst.Add(btn);
            //btn = new DevExpress.XtraBars.BarButtonItem();
            //btn.Caption = "区间图"; btn.Tag = ViewType.RangeArea;
            //btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btn_ItemClick);
            //lst.Add(btn);
            return lst.ToArray();

        }

        void btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var btn = e.Item;
            if (null == btn || btn.Tag == null) return;
            ViewType vty = (ViewType)btn.Tag;
            this.ChartViewType = vty;
            this.Reflush();
        }

        void ChartControl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ctxMnuCommodity.ShowPopup(Control.MousePosition);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();


            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barChkShowRight = new DevExpress.XtraBars.BarCheckItem();
            this.ctxMnuCommodity = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctxMnuCommodity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("CtxMnu", new System.Guid("b4fade50-dc87-48f8-aea7-a64f19117308"))});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barCheckItem1,
            this.barChkShowRight});
            this.barManager1.MaxItemId = 11;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "导出";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "打印";
            this.barButtonItem2.Id = 8;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);

           
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 9;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barChkShowRight
            // 
            this.barChkShowRight.Caption = "显示汇总面板";
            this.barChkShowRight.Checked = true;
            this.barChkShowRight.Id = 10;
            this.barChkShowRight.Name = "barChkShowRight";
            this.barChkShowRight.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barChkShowRight_CheckedChanged);
            // 
            // ctxMnuCommodity
            // 
            this.ctxMnuCommodity.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {

            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barChkShowRight)});
            this.ctxMnuCommodity.Manager = this.barManager1;
            this.ctxMnuCommodity.Name = "ctxMnuCommodity";
            // 
            // ChartControlEx
            // 
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel2.LineVisible = true;
            //sideBySideBarSeriesLabel2.OverlappingOptionsTypeName = "OverlappingOptions";
            this.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctxMnuCommodity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 纵坐标标刻调整
        /// </summary>
        private void AdjustAxisY()
        {
            DevExpress.XtraCharts.XYDiagram dgm = this.Diagram as DevExpress.XtraCharts.XYDiagram;
            if (null != dgm)
            {
                dgm.AxisY.NumericOptions.Precision = AxisYPrecision;//纵坐标小数点后的倍数
                dgm.AxisY.NumericOptions.Format = AxisY;
            }
        }

        /// <summary>
        /// 是否开启3D旋转
        /// </summary>
        private void Adjust3DRoation()
        {
            SimpleDiagram3D dgm3d = this.Diagram as SimpleDiagram3D;
            if (null != dgm3d)
                dgm3d.RuntimeRotation = dgm3d.RuntimeScrolling = dgm3d.RuntimeZooming = Enable3DRoation;
        }

        /// <summary>
        /// 调整当图表类型为3D饼图时的相关设置
        /// </summary>
        /// <param name="sers"></param>
        private void AdjustPie3D(Series sers)
        {
            if (this.ChartViewType != ViewType.Pie3D) return;
            if (null == sers || sers.PointOptions == null) return;
            PiePointOptions options = sers.PointOptions as PiePointOptions;
            if (null != options)
                options.PercentOptions.ValueAsPercent = AxisY == NumericFormat.Percent;
            //值坐标(Y轴)显示数据的格式,百分比或数字
            sers.PointOptions.ValueNumericOptions.Format = AxisY;
            //值坐标(Y轴)显示数据的小数点后保留倍数
            sers.PointOptions.ValueNumericOptions.Precision = AxisYPrecision;
        }

        private double _MinBarWidth = 0.1;
        public double MinBarWidth { get { return _MinBarWidth; } set { _MinBarWidth = value; } }

        /// <summary>
        /// 刷新图表显示
        /// </summary>
        public virtual void Reflush()
        {
            this.Titles.Clear();
            this.Series.Clear();//清除数据
            this.RuntimeSeriesSelectionMode = this.SerSelectionMode;
            this.RuntimeSelection = EnalbeRuntimeSelection;

            if (null == (this.SeriesDataSource as DataTable) ||
                (this.SeriesDataSource as DataTable).Rows.Count < 1)
            {
                //定义chart标题            
                ChartTitle cht = new ChartTitle();
                cht.Text = ExportName ?? string.Empty;
                this.Titles.Add(cht);

                ChartTitle ct2 = new ChartTitle();
                ct2.Text = NoDataTipText;
                ct2.Dock = ChartTitleDockStyle.Bottom;
                this.Titles.Add(ct2);
                return;
            }
            ////创建相应类型的图表类型
            //Series S1 = new Series(ExportName ?? string.Empty, this.ChartViewType);
            //S1.DataSource = this.SeriesDataSource;
            ////S1的X轴数据源字段
            //S1.ArgumentDataMember = this.ArgumentDataMember;
            ////S1的Y轴数据源字段
            //S1.ValueDataMembers[0] = this.ValueDataMembers;

            Series[] sers = CreateSeriesByFieldName(FieldOfSeriesName, this.SeriesDataSource as DataTable);
            if (null == sers || sers.Length < 1) return;
            foreach (Series S1 in sers)
            {
                PointOptions ptopt = S1.PointOptions;
                ptopt.PointView = PointView.Values;
                ptopt.Pattern = PointParttern;//图表点数据显示样式
                ptopt.ValueNumericOptions.Format = AxisY;
                ptopt.ValueNumericOptions.Precision = AxisYPrecision;
                if (null != S1.Label as PointSeriesLabel)
                    (S1.Label as PointSeriesLabel).LineVisible = true;
                this.Series.Add(S1);
                //((BarSeriesView)series1.View).BarWidth = 0.07;
                //保证在显示柱状图的时候当数据项少的时候 不会柱子太宽
                BarSeriesView bsv = S1.View as BarSeriesView;
                if (null != bsv) bsv.BarWidth = MinBarWidth;
                AdjustPie3D(S1);
            }

            //定义chart标题            
            ChartTitle ct1 = new ChartTitle();
            ct1.Text = ExportName ?? string.Empty;
            this.Titles.Add(ct1);

            if (null != ChartDiagram)
            {
                ChartDiagram.AxisY.Title.Text = AxisYTitle;//设置Y轴说明文字
                ChartDiagram.AxisX.Title.Text = AxisXTitle;//设置X轴说明文字
                ChartDiagram.AxisY.Title.Visible = !string.IsNullOrEmpty(AxisYTitle);
                ChartDiagram.AxisX.Title.Visible = !string.IsNullOrEmpty(AxisXTitle);
                ChartDiagram.AxisX.Label.Visible = AxisXVisiable;
                ChartDiagram.EnableScrolling = EnableScrolling;
                ChartDiagram.EnableZooming = EnableZooming;

                ChartDiagram.AxisX.Label.Angle = AntialiasingValue;//设置X轴斜率
                ChartDiagram.AxisX.Label.Antialiasing = Antialiasing;//开启X轴斜率

                //ChartDiagram.AxisY.MinorCount = 10;   //设置Y轴的间隔
                //ChartDiagram.AxisY.Range.Auto = false;    //不允许自动设定间隔值

                if (null != ChartDiagram.AxisX && null != ChartDiagram.AxisX.Label)
                    ChartDiagram.AxisX.Label.Antialiasing = true;
            }
            Adjust3DRoation();
            AdjustAxisY();
        }

        private void barChkShowRight_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Legend.Visible = barChkShowRight.Checked;
        }

        /// <summary>
        /// 创建图表计算单元
        /// </summary>
        /// <param name="strFieldName">用于区别各个单元的字段的名称(单元的名称为此字段的值)</param>
        /// <param name="dtSrc">图表数据源</param>
        /// <returns></returns>
        private Series[] CreateSeriesByFieldName(string strFieldName, DataTable dtSrc)
        {
            if (null == dtSrc) return null;
            if (string.IsNullOrEmpty(strFieldName) || !dtSrc.Columns.Contains(strFieldName))
            {
                Series S1 = new Series(ExportName ?? string.Empty, this.ChartViewType);
                S1.DataSource = dtSrc;
                //S1的X轴数据源字段
                S1.ArgumentDataMember = this.ArgumentDataMember;
                //S1的Y轴数据源字段
                S1.ValueDataMembers[0] = this.ValueDataMembers;
                return new Series[] { S1 };
            }

            //根据strFieldName查出此字段数据不相同的数据
            var queryResult =
                (from itm in dtSrc.AsEnumerable() select itm[strFieldName].ToString()).Distinct();
            Series[] sers = new Series[queryResult.Count()];
            Series ser = null;
            DataView dv = null; int idx = 0;
            foreach (var item in queryResult)
            {
                (dv = new DataView(dtSrc)).RowFilter =
                    string.Format("{0}='{1}'", strFieldName, FilterStringReplace(item));
                //创建Series
                (ser = sers[idx++] = new Series(item, ChartViewType)).DataSource = dv.ToTable();
                //S1的X轴数据源字段
                ser.ArgumentDataMember = this.ArgumentDataMember;
                //S1的Y轴数据源字段
                ser.ValueDataMembers[0] = this.ValueDataMembers;
            }
            return sers;
        }

        private void chartControlEx1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!OnMouseClickShowSeriesInfo) return;
            ChartHitInfo hi = CalcHitInfo(
                new System.Drawing.Point(e.X, e.Y));
            if (hi.Diagram != null)
            {
                if (hi.InDiagram && hi.InSeries && null != hi.SeriesPoint)
                {
                    this.tooltipCtl.ShowHint(
                        string.Format(ShowSeriesInfoFormat,
                        hi.SeriesPoint.Argument,
                        hi.SeriesPoint.Values[0]),
                        this.PointToScreen(e.Location));
                    if (((hi.HitObject as DevExpress.XtraCharts.Series)!=null)//增加处理,会发现点到的不是图表点上 
                        && null != OnChartHit)
                        this.OnChartHit(this, new CharHitInfoArg {HitInfo=hi });
                }
            }
        }

        /// <summary>
        /// 特殊查询字符串过滤
        /// </summary>
        /// <param name="src">查询字符串</param>
        /// <returns></returns>
        private static string FilterStringReplace(string src)
        {
            return src.Replace("[", "[[ ")
                .Replace("]", " ]]")
                .Replace("*", "[*]")
                .Replace("%", "[%]")
                .Replace("[[ ", "[[]")
                .Replace(" ]]", "[]]")
                .Replace("\"", "\"\"");
        }
    }

    public class CharHitInfoArg : EventArgs
    {
        /// <summary>
        /// 鼠标点击的图表数据点元素
        /// </summary>
        public ChartHitInfo HitInfo { get; set; }
    }
}
