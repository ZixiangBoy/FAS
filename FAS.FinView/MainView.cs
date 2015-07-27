using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.CoreCaller;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.FASControls.Extend;
using Ultra.FASControls.Controllers;
using Ultra.FASControls.Caller;
using Ultra.Common;

namespace FAS.FinView
{
    public partial class MainView : MainSurface,ISurfacePermission
    {
        public MainView()
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
                    new PermitGridView(this.gv,"账务流水")
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
                this.barBtnNew,this.barBtnEdt,this.barBtnExportXls
            };
            }
        }
        //EFCaller<UltraDbEntity.T_ERP_FinRec> Calr { get; set; }
        private void MainView_Load(object sender, EventArgs e)
        {
            FiName1.LoadData();
            //Calr = new EFCaller<UltraDbEntity.T_ERP_FinRec>(new CtlFinRecController());
            finPager1.Caller = SerNoCaller_GC.Calr_FinRec;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
        }

        void barBtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gc.GridExportXls();
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            finPager1.CurrentPage = 1;
            finPager1.PrefixWhr = "select * from V_ERP_GetFinName";
            finPager1.Whrs.Clear(); finPager1.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(TxtCustor.Text.Trim()))
            {
                finPager1.Whrs.Add("Customer=@" + (idx++).ToString());
                finPager1.PrmsData.Add(TxtCustor.Text.Trim());
            }
            if (!string.IsNullOrEmpty(FiName1.Text.Trim()))
            {
                finPager1.Whrs.Add("FinName=@" + (idx++).ToString());
                finPager1.PrmsData.Add(FiName1.Text.Trim());
            }
            if (dateEdit1.EditValue != null)
            {
                finPager1.Whrs.Add("FinTime >=@" + (idx++).ToString());
                finPager1.PrmsData.Add(dateEdit1.DateTime);
            }
            if (dateEdit2.EditValue != null)
            {
                finPager1.Whrs.Add("FinTime <=@" + (idx++).ToString());
                finPager1.PrmsData.Add(dateEdit2.DateTime);
            }
            finPager1.OrderBy = "Order By Id Desc";
            finPager1.BindPageData();
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gv.GetFocusedDataSource<UltraDbEntity.T_ERP_FinRec>();
            if (null == et) return;
            var vw = new EditView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            vw.Entity = et;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new EditView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
        }

    }
}
