using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace Ultra.FASControls
{
    public partial class EFPager : UserControl
    {
        public EFPager()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            cmbPgSize.SelectedIndexChanged -= cmbPgSize_SelectedIndexChanged;
            cmbPgSize.Text = "500";
            cmbPgSize.SelectedIndexChanged += cmbPgSize_SelectedIndexChanged;
        }

        ///// <summary>
        ///// 转至第几页事件
        ///// </summary>
        //[Description("转至第几页事件")]
        //[Browsable(true)]
        //[Category("Ultra")]
        //public event EventHandler<PagerEventArg> Direct2Page;

        //[Description("获取分页数据事件,当存在此事件处理程序时调用,否则则应用控件默认实现")]
        //[Browsable(true)]
        //[Category("Ultra")]
        //public event EventHandler<PagerEventArg> GetPageResultData;

        /// <summary>
        /// 分页控件关联的Grid
        /// </summary>
        [Category("Ultra")]
        [Browsable(true)]
        [Description("分页控件关联的Grid")]
        public GridControl Grid { get; set; }

        private void txtpgNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = 0;
                if (!int.TryParse(txtpgNum.Text.Trim(), out idx)) return;
                if (idx < 1) return;
                if (PageCount <= 0) return;
                if (idx > PageCount) return;
                CurrentPage = idx;

                GetResultData();
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            GetResultData();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labPre_Click(object sender, EventArgs e)
        {
            if (CurrentPage - 1 < 1) return;
            CurrentPage = CurrentPage - 1;
            GetResultData();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage + 1 > PageCount) return;
            CurrentPage += 1;
            GetResultData();
        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labEnd_Click(object sender, EventArgs e)
        {
            CurrentPage = PageCount;
            GetResultData();
        }

        /// <summary>
        /// 默认获取分布数据的方法
        /// </summary>
        /// <returns></returns>
        public virtual object GetResultData()
        {
            //using (var db = new PetaPoco.Database(ConnStr))
            //{
            //    //var mi = typeof(PetaPoco.Database).GetMethod("Fetch");
            //    //mi = mi.MakeGenericMethod(DataType);
            //    //var prm = DicWhr.Values.ToList();
            //    //List<object> oj = new List<object>(prm.Count + 1);
            //    //oj.Add(whrPrm); oj.AddRange(prm);
            //    //return mi.Invoke(db, oj.ToArray());
            //    //db.Page<object>(CurrentPage, PageSize, whrPrm, args);
            //}
            return null;
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }


        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize
        {
            get
            {
                var ps = -1;
                if (!Int32.TryParse(cmbPgSize.Text, out ps))
                    return 999999;
                _pgsize = ps;
                return _pgsize;
            }
            set
            {
                _pgsize = value;
                try
                {
                    cmbPgSize.Text = _pgsize.ToString();
                }
                catch (Exception) { }
            }
        }

        private int _pgsize = 10;

        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int Counts { get; set; }

        //protected string whrPrm
        //{
        //    get
        //    {
        //        var idx = 0; string whr = "where 1=1 ";
        //        foreach (KeyValuePair<string, object> kvp in DicWhr)
        //        {
        //            whr += string.Format("and {0}=@{1} ", kvp.Key, idx++);
        //        }
        //        if (whr == "where 1=1 ") return string.Empty;
        //        return whr;
        //    }
        //}

        //public Type DataType { get; set; }

        protected virtual void SetBarStyle()
        {
            #region [启用]
            if (CurrentPage == 1)
            {
                if (PageCount > 1)
                {
                    labFirst.Enabled = false;
                    labPre.Enabled = false;
                    labNext.Enabled = true;
                    labEnd.Enabled = true;
                }
                else
                {
                    labFirst.Enabled = false;
                    labPre.Enabled = false;
                    labNext.Enabled = false;
                    labEnd.Enabled = false;
                }
            }
            else
            {
                if (CurrentPage < PageCount)
                {
                    labFirst.Enabled = true;
                    labPre.Enabled = true;
                    labNext.Enabled = true;
                    labEnd.Enabled = true;
                }
                else
                {
                    labFirst.Enabled = true;
                    labPre.Enabled = true;
                    labNext.Enabled = false;
                    labEnd.Enabled = false;
                }
            }
            #endregion
            labResult.Text = "当前页数：" + CurrentPage.ToString() + "/" + PageCount.ToString() + "页  总数：" + Counts.ToString() + "条";
        }

        protected string _constr;

        public string ConnStr
        {
            get
            {
                if (!string.IsNullOrEmpty(_constr)) return _constr;
                var f = FindForm();
                if (null == f) return string.Empty;
                var v = f as Ultra.Surface.Form.BaseSurface;
                if (null == v) return string.Empty;
                return _constr = v.ConnString;
            }
        }

        private void cmbPgSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = 1;
            GetResultData();
        }

        private void labFirst_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void labFirst_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

    }

    /// <summary>
    /// 泛型控件基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFPgr<T> : EFPager
    {
        public EFPgr()
            : base()
        {
            CurrentPage = 1;
        }

        public Ultra.CoreCaller.EFCaller<T> Caller { get; set; }

        protected List<object> _prmdata = new List<object>();
        protected List<string> _whrs = new List<string>();
        protected List<string> _opr = new List<string>();

        [Category("Ultra")]
        [Description("查询字段集合，如: field1=@0, field2=@1,...")]
        [Browsable(true)]
        public List<string> Whrs
        {
            get { return _whrs; }
        }

        //public List<string> Opr
        //{
        //    get { return _opr; }
        //}

        [Category("Ultra")]
        [Description("查询字段值集合")]
        [Browsable(true)]
        public List<object> PrmsData
        {
            get { return _prmdata; }
        }

        [Category("Ultra")]
        [Description("排序语句，如:order by ....")]
        [Browsable(true)]
        public virtual string OrderBy { get; set; }

        //[Category("Ultra")]
        //[Description("条件语句 查询需要用到的参数")]
        //[Browsable(true)]
        //public virtual object[] Prms { get; set; }

        public virtual List<T> ResultData { get; set; }

        protected virtual PetaPoco.Page<T> GetPageData(params object[] ojprms)
        {
            //using (var db = new PetaPoco.Database(base.ConnStr))
            //{
            //    string whr = string.Empty;
            //    if (Whrs.Count > 0)
            //    {
            //        whr = Whrs.Aggregate((s1, s2) => { return s1 + " and" + s2; }).ToString();
            //        whr = "where " + whr;
            //    }
            //    if (!string.IsNullOrEmpty(OrderBy))
            //        whr += " " + OrderBy;
            //    CurrentPage = CurrentPage < 1 ? 1 : CurrentPage;
            //    var pg = db.Page<T>(CurrentPage, PageSize, whr, prms);
            //    base.Counts = (int)pg.TotalItems;
            //    base.PageCount = (int)pg.TotalPages;
            //    SetBarStyle();
            //    ResultData = pg.Items;
            //    if (base.Grid != null) { base.Grid.DataSource = ResultData; base.Grid.RefreshDataSource(); }
            //    return pg;
            //}
            string whr = string.Empty;
            if (Whrs.Count > 0)
            {
                whr = Whrs.Aggregate((s1, s2) => { return s1 + " and " + s2; }).ToString();
                whr = "where " + whr;
            }
            whr = ProcessWhr(whr);
            //PetaPoco.Sql sl;
            //if (Whrs.Count > 0)
            //{
            //    Whrs.ForEach(k => {
            //        sl = PetaPoco.Sql.Builder.Append(k, PrmsData.ToArray());
            //    });
            //}
            //using (var db = new PetaPoco.Database(_constr))
            //{

            //}

            if (!string.IsNullOrEmpty(OrderBy))
                whr += " " + OrderBy;
            CurrentPage = CurrentPage < 1 ? 1 : CurrentPage;
            //var pd = new Ultra.Common.PageSrchData
            //{
            //    PageIdx = CurrentPage,
            //    PageSize = this.PageSize,
            //    Whr = whr,
            //    prms = ojprms
            //};
            if (null == Caller) return null;
            var pt = Caller.GetPageData(CurrentPage, PageSize, whr, ojprms);
            ResultData = pt.Items;
            base.Counts = (int)pt.TotalItems;
            base.PageCount = (int)pt.TotalPages;
            SetBarStyle();
            if (base.Grid != null) { base.Grid.DataSource = ResultData; base.Grid.RefreshDataSource(); }
            return pt;
        }

        /// <summary>
        /// 获取并加载分页查询的数据至画面
        /// </summary>
        /// <returns></returns>
        public virtual List<T> BindPageData()
        {
            var pg = GetPageData(PrmsData.ToArray());
            return pg.Items;
        }

        public override object GetResultData()
        {
            return BindPageData();
        }

        public string PrefixWhr { get; set; }

        /// <summary>
        /// 交由子类处理whr语句
        /// </summary>
        /// <param name="whr"></param>
        /// <returns></returns>
        public virtual string ProcessWhr(string whr)
        {
            if (!string.IsNullOrEmpty(PrefixWhr))
                return string.Format("{0} {1}", PrefixWhr, whr);
            return whr;
        }
    }

}
