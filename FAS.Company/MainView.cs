using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Surface.Lanuch;
using Ultra.FASControls;
using Ultra.FASControls.Extend;

namespace FAS.Company {
    public partial class MainView : MainSurface, ISurfacePermission {
        public MainView() {
            InitializeComponent();
        }


        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                    this.barBtnNew,this.barBtnEdt
                };
            }
        }

        public List<Control> ButtonItems {
            get { return null; }
        }

        public List<Control> MenuItems {
            get { return null; }
        }

        public List<PermitGridView> Grids {
            get {
                return new List<PermitGridView> { 
                new PermitGridView(this.gridView1,"公司信息")
            };
            }
        }

        public List<Ultra.Surface.Form.BaseSurface> DialogForms {
            get { return null; }
        }

        private void MainView_Load(object sender, EventArgs e) {
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            CompanyPager1.Caller = SerNoCaller.Calr_Company;
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_Company>();
            if (null == et) return;
            var vw = new EdtView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            vw.Entity = et;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                gridControlEx1.RefreshDataSource();
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            CompanyPager1.CurrentPage = 1;
            CompanyPager1.PrefixWhr = "select * from T_ERP_Company";
            CompanyPager1.Whrs.Clear(); CompanyPager1.PrmsData.Clear();
            CompanyPager1.OrderBy = " order by id desc";
            CompanyPager1.BindPageData();
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new EdtView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                barBtnRefresh_ItemClick(null, null);
            }
        }
    }
}
