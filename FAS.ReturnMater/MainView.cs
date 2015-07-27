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
using Ultra.FASControls.Extend;
using UltraDbEntity;
using Ultra.FASControls;

namespace FAS.ReturnMater {
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
                    new PermitGridView(this.gvProduce,"生产用料列表")
                };
            }
        }

        public List<Ultra.Surface.Form.BaseSurface> DialogForms {
            get { return null; }
        }

        private void MainView_Load(object sender, EventArgs e) {
            materialGridEdt1.LoadData();
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;

            vProPager.Caller = SerNoCaller.Calr_V_ERP_ProduceMater;
            recvPager.Caller = SerNoCaller.Calr_RecvMater;
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (tabMain.SelectedTabPage.Text) {
                case "生产用料":
                    ProduceMater();
                    break;
                case "返料记录":
                    ReturnMater();
                    break;
                default:
                    break;
            }
        }

        private void ReturnMater() {
            recvPager.CurrentPage = 1;
            recvPager.PrefixWhr = "select * from T_ERP_RecvMater";
            recvPager.Whrs.Clear();
            recvPager.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(materialGridEdt1.Text)) {
                recvPager.Whrs.Add("MaterialName=@" + (idx++).ToString());
                recvPager.PrmsData.Add(materialGridEdt1.GetSelectedValue().MaterialName);
            }
            if (!string.IsNullOrEmpty(txtProduceNo.Text)) {
                recvPager.Whrs.Add("ProduceNo=@" + (idx++).ToString());
                recvPager.PrmsData.Add(txtProduceNo.Text);
            }
            recvPager.OrderBy = " order by Id desc";
            recvPager.BindPageData();
        }

        private void ProduceMater() {
            vProPager.CurrentPage = 1;
            vProPager.PrefixWhr = "select * from V_ERP_ProduceMater";
            vProPager.Whrs.Clear();
            vProPager.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(materialGridEdt1.Text)) {
                vProPager.Whrs.Add("MaterialName=@" + (idx++).ToString());
                vProPager.PrmsData.Add(materialGridEdt1.GetSelectedValue().MaterialName);
            }
            if (!string.IsNullOrEmpty(txtProduceNo.Text)) {
                vProPager.Whrs.Add("ProduceNo=@" + (idx++).ToString());
                vProPager.PrmsData.Add(txtProduceNo.Text);
            }
            vProPager.OrderBy = " order by Id desc";
            vProPager.BindPageData();
        }

        private void pBtnRecvMater_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var ets = gcProduce.GetSelectedDataSource<T_ERP_ProduceMater>();
            if (ets == null || ets.Count < 1) return;
            var vw = new EdtView();
            vw.ProMaters = ets;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                
            }
        }

        private void gvProduce_MouseUp(object sender, MouseEventArgs e) {
            var hit= gvProduce.CalcHitInfo(e.X, e.Y);
            if (hit.RowHandle < 0)
                return;
            popupMenu1.ShowPopup(new Point() {X=e.X,Y=e.Y });
        }
    }
}
