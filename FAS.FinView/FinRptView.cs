using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.FASControls;
using Ultra.FASControls.Caller;
using Ultra.Web.Core.Common;

namespace FAS.FinView
{
    public partial class FinRptView : MainSurface,ISurfacePermission
    {
        public FinRptView()
        {
            InitializeComponent();
        }

        public List<Control> ButtonItems
        {
            get { return null; }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        public List<PermitGridView> Grids
        {
            get
            {
                return new List<PermitGridView>
                {
                    new PermitGridView(this.gv,"账务流水明细")
                };
            }
        }

        public List<Control> MenuItems
        {
            get { return null; }
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> {
                this.barBtnRefresh
            };
            }
        }

        private void FinRptView_Load(object sender, EventArgs e)
        {
            rptMonthDate1.LoadDate();
            var dd = SerNoCaller_GC.Calr_V_ERP_GetAmountByMonth.Get();  
            dd.OrderBy(j=>j.Y).OrderBy(t=>t.M);
            var dt = new DataTable();
            dt = dd.GetDataTable();
            chartControlEx1.SeriesDataSource = dt;
            chartControlEx1.Reflush();
            finPager1.Caller = SerNoCaller_GC.Calr_FinRec;
            finPager1.PrefixWhr = "select * from V_ERP_GetFinName";
            finPager1.Whrs.Add(" Datediff(Month,GetDate(),FinTime)=0 ");
            finPager1.OrderBy = "Order By Id Desc";
            finPager1.BindPageData();
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var de = rptMonthDate1.GetDate();
            finPager1.CurrentPage = 1;
            finPager1.PrefixWhr = "select * from V_ERP_GetFinName";
            finPager1.Whrs.Clear(); finPager1.PrmsData.Clear();
            if (null != de)
            {
                finPager1.Whrs.Add(" Datediff(Month,FinTime,@0)=0 ");
                finPager1.PrmsData.Add(de);
            }
            else
            {
                finPager1.Whrs.Add(" Datediff(Month,GetDate(),FinTime)=0 ");
            }
            finPager1.OrderBy = "Order By Id Desc";
            finPager1.BindPageData();
        }

        private void chartControlEx1_OnChartHit(object sender, CharHitInfoArg e)
        {
            finPager1.CurrentPage = 1;
            finPager1.PrefixWhr = "select * from V_ERP_GetFinName";
            finPager1.Whrs.Clear(); finPager1.PrmsData.Clear();
            finPager1.Whrs.Add(" Datediff(Month,FinTime,@0)=0 ");
            finPager1.PrmsData.Add(DateTime.Parse(e.HitInfo.SeriesPoint.Argument));
            finPager1.OrderBy = "Order By Id Desc";
            finPager1.BindPageData();
        }
    }
}
