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
using Ultra.FASControls.Views;

namespace Ultra.FAS.Refund
{
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
                    new PermitGridView(this.gvOrder,"商品明细"),
                    new PermitGridView(this.gvExpenses,"费用明细")
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


        List<UltraDbEntity.T_ERP_Image> ImageDataSource { get; set; }
        private void MainView_Load(object sender, EventArgs e) {
            barBtnNew.ItemClick += barBtnNew_ItemClick;
            barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;

            gvAudit.FocusedRowChanged += gv_FocusedRowChanged;
            gvUnAudit.FocusedRowChanged += gv_FocusedRowChanged;
            gvInvalid.FocusedRowChanged += gv_FocusedRowChanged;
            pgrUnAudit.Caller = pgrAudit.Caller = pgrInvalid.Caller = SerNoCaller_WL.Calr_AfterSale;

            gcUnAudit.PopupTextFields.Add("Remark");
            gcAudit.PopupTextFields.Add("Remark");
            gcInvalid.PopupTextFields.Add("Remark");
            gcInvalid.PopupTextFields.Add("InvalidRemark");
        }

        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_AfterSale>();
            if (null == et) return;
            var vw = new InvalidAfterSale();
            vw.Ent = et;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (vw.Ent.IsInvalid)
                    gcUnAudit.RemoveSelected();
            }
            return;
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var gv = sender as GridView;
            if (gv == null) return;
            var et = gv.GetFocusedDataSource<T_ERP_AfterSale>();
            if (et == null) {
                gcOrder.DataSource = null;
                gcExpenses.DataSource = null;
                return;
            }
            gcOrder.DataSource = SerNoCaller_WL.Calr_AfterSalaItem.Get(" where AfterNo=@0", et.AfterNo);
            gcExpenses.DataSource = SerNoCaller_WL.Calr_Expenses.Get(" where FromNo=@0", et.AfterNo);
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
            pgrAudit.PrefixWhr = "select * from V_ERP_AuditAfterSale";
            pgrAudit.Whrs.Clear(); pgrAudit.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrAudit.Whrs.Add("ReceiverName=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtReceiverName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtAfterNo.Text.Trim()))
            {
                pgrAudit.Whrs.Add("AfterNo=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtAfterNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtTrdNo.Text.Trim()))
            {
                pgrAudit.Whrs.Add("TradeNo=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtTrdNo.Text.Trim());
            }

            pgrAudit.OrderBy = "Order By Id Desc";
            pgrAudit.BindPageData();
            gv_FocusedRowChanged(gvAudit, null);
        }

        private void UnAudit() {
            pgrUnAudit.CurrentPage = 1;
            pgrUnAudit.PrefixWhr = "select * from V_ERP_UnAuditAfterSale";
            pgrUnAudit.Whrs.Clear(); pgrUnAudit.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrUnAudit.Whrs.Add("ReceiverName=@" + (idx++).ToString());
                pgrUnAudit.PrmsData.Add(txtReceiverName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtAfterNo.Text.Trim()))
            {
                pgrAudit.Whrs.Add("AfterNo=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtAfterNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtTrdNo.Text.Trim()))
            {
                pgrAudit.Whrs.Add("TradeNo=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtTrdNo.Text.Trim());
            }
            pgrUnAudit.OrderBy = "Order By Id Desc";
            pgrUnAudit.BindPageData();
            gv_FocusedRowChanged(gvUnAudit, null);
        }

        private void Invalid() {
            pgrInvalid.CurrentPage = 1;
            pgrInvalid.PrefixWhr = "select * from V_ERP_InvalidAfterSale";
            pgrInvalid.Whrs.Clear(); pgrInvalid.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrInvalid.Whrs.Add("ReceiverName=@" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(txtReceiverName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtAfterNo.Text.Trim()))
            {
                pgrAudit.Whrs.Add("AfterNo=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtAfterNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtTrdNo.Text.Trim()))
            {
                pgrAudit.Whrs.Add("TradeNo=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtTrdNo.Text.Trim());
            }
            pgrInvalid.OrderBy = "Order By Id Desc";
            pgrInvalid.BindPageData();
            gv_FocusedRowChanged(gvInvalid, null);
        }

        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnAudit.GetFocusedDataSource<T_ERP_AfterSale>();
            if (et == null) return;

            et.IsAudit = true;
            et.Auditor= this.CurUser;
            et.AuditTime = TimeSync.Default.CurrentSyncTime;

            if (SerNoCaller_WL.Calr_AfterSale.Edt(et).IsOK) {
                var autrds = gcAudit.GetDataSource<T_ERP_AfterSale>();
                autrds = autrds ?? new List<T_ERP_AfterSale>();
                autrds.Insert(0, et);

                gcUnAudit.RemoveSelected();
            }
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new EdtView();
            UltraDbEntity.T_ERP_AfterSale et = null;
            switch (tabMain.SelectedTabPage.Text)
            {
                case "未处理":
                    et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_AfterSale>();
                    break;
                case "已审核":
                    et = gcAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_AfterSale>();
                    vw.isAudit = true;
                    break;
            }
            if (null == et) return;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            vw.AfterSale = et;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new EdtView();
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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
                    = this.barBtnAudit.Enabled
                    = barBtnInvalid.Enabled
                    = false;
                    this.barBtnEdt.Enabled = true;
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

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            UltraDbEntity.T_ERP_AfterSale et = null;
            switch (tabMain.SelectedTabPage.Text)
            {
                case "未处理":
                    et = gvUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_AfterSale>();
                    break;
                case "已审核":
                    et = gvAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_AfterSale>();
                    break;
                case "已作废":
                    et = gvInvalid.GetFocusedDataSource<UltraDbEntity.T_ERP_AfterSale>();
                    break;
            }

            if (et == null) return;

            LoadData(et.ImageSession);
            var vw = new Ultra.FASControls.Views.ImageViewer();
            vw.Calr = FASControls.SerNoCaller_WL.Calr_Image;
            vw.Session = et.ImageSession == null ? Guid.NewGuid() : et.ImageSession.Value;
            vw.Ent = this.ImageDataSource;
            vw.ShowDialog();
        }

        public void LoadData(Guid? Session)
        {
            var ets = FASControls.SerNoCaller_WL.Calr_Image.Get("where Session=@0 and IsDel=0", Session);
            ets = ets.OrderBy(j => j.Id).ToList();
            int idx = 1;
            foreach (var e in ets)
                e.Reserved1 = idx++;
            ImageDataSource = ets;
        }
    }
}
