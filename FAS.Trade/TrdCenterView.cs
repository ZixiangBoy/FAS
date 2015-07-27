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
using DevExpress.XtraGrid.Views.Grid;
using Ultra.FASControls;
using Ultra.Win.Core.Common;
using Ultra.Surface.Common;

namespace FAS.Trade {
    public partial class TrdCenterView : MainSurface, ISurfacePermission {

        public TrdCenterView() {
            InitializeComponent();
        }

        public List<Control> ButtonItems {
            get;
            set;
        }

        public List<BaseSurface> DialogForms {
            get;
            set;
        }

        public List<PermitGridView> Grids {
            get {
                return new List<PermitGridView> { 
                    new PermitGridView(this.gvTrd,"订单信息"),
                    new PermitGridView(this.gvOrder,"商品明细")
                };
            }
        }

        public List<Control> MenuItems {
            get;
            set;
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem>{
                    this.barBtnRefresh
                };
            }
        }

        private void TrdCenterView_Load(object sender, EventArgs e) {
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;

            gvTrd.FocusedRowChanged += gv_FocusedRowChanged;
            pgrTrd.Caller = SerNoCaller.Calr_Trade;
        }


        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var gv = sender as GridView;
            if (gv == null) return;
            var et = gv.GetFocusedDataSource<T_ERP_Trade>();
            if (et == null) {
                gcOrder.DataSource = null;
                return;
            }
            gcOrder.DataSource = SerNoCaller.Calr_Order.Get("SELECT * FROM V_ERP_Order where tradeno=@0", et.TradeNo);
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            pgrTrd.CurrentPage = 1;
            pgrTrd.PrefixWhr = "select * from V_ERP_AuditTrade";
            pgrTrd.Whrs.Clear(); pgrTrd.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrTrd.Whrs.Add("ReceiverName=@" + (idx++).ToString());
                pgrTrd.PrmsData.Add(txtReceiverName.Text.Trim());
            }
            bool? isgr = null;
            switch (chk.CheckState) {
                case CheckState.Checked:
                    isgr = true;
                    break;
                case CheckState.Unchecked:
                    isgr = false;
                    break;
            }
            if (isgr != null) {
                pgrTrd.Whrs.Add("IsUrgent=@" + (idx++).ToString());
                pgrTrd.PrmsData.Add(isgr);
            }

            pgrTrd.OrderBy = "Order By Id Desc";
            pgrTrd.BindPageData();
            gv_FocusedRowChanged(gvTrd, null); ;
        }

        private void rspLookImg_Click(object sender, EventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;

            var vw = new UploadImgView();
            vw.Order = odr;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) { }
        }
    }
}
