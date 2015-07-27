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
    public partial class MainView : MainSurface, ISurfacePermission {

        public MainView() {
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
                    new PermitGridView(this.gvUnAudit,"未处理"),
                    new PermitGridView(this.gvAudit,"已审核"),
                    new PermitGridView(this.gvInvalid,"已作废"),
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
                    this.barBtnNew,this.barBtnEdt,barBtnAudit,
                    barBtnInvalid
                };
            }
        }

        private void MainView_Load(object sender, EventArgs e) {
            barBtnNew.ItemClick += barBtnNew_ItemClick;
            barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;

            gvAudit.FocusedRowChanged += gv_FocusedRowChanged;
            gvUnAudit.FocusedRowChanged += gv_FocusedRowChanged;
            gvInvalid.FocusedRowChanged += gv_FocusedRowChanged;
            pgrUnAudit.Caller = pgrAudit.Caller = pgrInvalid.Caller = SerNoCaller.Calr_Trade;
        }

        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnAudit.GetFocusedDataSource<T_ERP_Trade>();
            if (et == null) return;

            var vw = new InvRemarkView();

            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                et.IsInvalid = true;
                et.InvalidUser = this.CurUser;
                et.InvalidTime = TimeSync.Default.CurrentSyncTime;
                et.Reserved2 = vw.InvRmrk;

                if (SerNoCaller.Calr_Trade.Edt(et).IsOK) {
                    var trds = gcInvalid.GetDataSource<T_ERP_Trade>();
                    trds = trds ?? new List<T_ERP_Trade>();
                    trds.Insert(0, et);

                    gcUnAudit.RemoveSelected();
                }
            }
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
            switch (tabMain.SelectedTabPage.Text) {
                case "未处理":
                    UnAudit();
                    break;
                case "已审核":
                    Audit();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
        }

        private void Audit() {
            pgrAudit.CurrentPage = 1;
            pgrAudit.PrefixWhr = "select * from V_ERP_AuditTrade";
            pgrAudit.Whrs.Clear(); pgrAudit.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrAudit.Whrs.Add("ReceiverName=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtReceiverName.Text.Trim());
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
                pgrAudit.Whrs.Add("IsUrgent=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(isgr);
            }

            pgrAudit.OrderBy = "Order By Id Desc";
            pgrAudit.BindPageData();
            gv_FocusedRowChanged(gvAudit, null);
        }

        private void UnAudit() {
            pgrUnAudit.CurrentPage = 1;
            pgrUnAudit.PrefixWhr = "select * from V_ERP_UnAuditTrade";
            pgrUnAudit.Whrs.Clear(); pgrUnAudit.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrUnAudit.Whrs.Add("ReceiverName=@" + (idx++).ToString());
                pgrUnAudit.PrmsData.Add(txtReceiverName.Text.Trim());
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
                pgrUnAudit.Whrs.Add("IsUrgent=@" + (idx++).ToString());
                pgrUnAudit.PrmsData.Add(isgr);
            }
            pgrUnAudit.OrderBy = "Order By Id Desc";
            pgrUnAudit.BindPageData();
            gv_FocusedRowChanged(gvUnAudit, null);
        }

        private void Invalid() {
            pgrInvalid.CurrentPage = 1;
            pgrInvalid.PrefixWhr = "select * from V_ERP_InvalidTrade";
            pgrInvalid.Whrs.Clear(); pgrInvalid.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrInvalid.Whrs.Add("ReceiverName=@" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(txtReceiverName.Text.Trim());
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
                pgrInvalid.Whrs.Add("IsUrgent=@" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(isgr);
            }
            pgrInvalid.OrderBy = "Order By Id Desc";
            pgrInvalid.BindPageData();
            gv_FocusedRowChanged(gvInvalid, null);
        }

        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnAudit.GetFocusedDataSource<T_ERP_Trade>();
            if (et == null) return;

            et.IsAudit = true;
            et.AuditUser = this.CurUser;
            et.AuditTime = TimeSync.Default.CurrentSyncTime;

            if (SerNoCaller.Calr_Trade.Edt(et).IsOK) {
                var autrds = gcAudit.GetDataSource<T_ERP_Trade>();
                autrds = autrds ?? new List<T_ERP_Trade>();
                autrds.Insert(0, et);

                gcUnAudit.RemoveSelected();
            }

        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (tabMain.SelectedTabPage.Text) {
                case "未处理":
                    var et = gcUnAudit.GetFocusedDataSource<T_ERP_Trade>();
                    if (et == null) return;
                    var vw = new TrdEdtView();
                    vw.Trade = et;
                    vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
                    if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        barBtnRefresh_ItemClick(null, null);
                    }
                    break;
                case "已审核":
                    if (MsgBox.ShowYesNoMessage("订单已生产,确定要修改商品信息?") == System.Windows.Forms.DialogResult.Yes) {
                        var scet = gcAudit.GetFocusedDataSource<T_ERP_Trade>();
                        if (scet == null) return;
                        var scvw = new SCTrdEdtView();
                        scvw.Trade = scet;
                        scvw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
                        if (scvw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            barBtnRefresh_ItemClick(null, null);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new TrdEdtView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            this.barBtnNew.Enabled
                    = this.barBtnEdt.Enabled
                    = this.barBtnAudit.Enabled
                    = this.barBtnInvalid.Enabled
                    = true;
            switch (tabMain.SelectedTabPage.Text) {
                case "未处理":
                    gv_FocusedRowChanged(gvUnAudit, null);
                    break;
                case "已审核":
                    this.barBtnNew.Enabled
                    //= this.barBtnEdt.Enabled
                    = this.barBtnAudit.Enabled
                    = barBtnInvalid.Enabled
                    = false;
                    gv_FocusedRowChanged(gvAudit, null);
                    break;
                case "已作废":
                    this.barBtnNew.Enabled
                    = this.barBtnEdt.Enabled
                    = this.barBtnAudit.Enabled
                    = barBtnInvalid.Enabled
                    = false;
                    gv_FocusedRowChanged(gvAudit, null);
                    break;
            }
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
