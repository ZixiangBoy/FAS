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
using Ultra.Surface.Lanuch;
using Ultra.Surface.Common;

namespace FAS.Trade {
    public partial class TrdPrdView : MainSurface, ISurfacePermission {
        public TrdPrdView() {
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
                    new PermitGridView(this.gvTrd,"待生产"),
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
                    this.barBtnNew,this.barBtnEdt,barBtnAudit,barBtnInvalid,barBtnPrint
                    ,barBtnGet
                };
            }
        }

        private void MainView_Load(object sender, EventArgs e) {
            barBtnNew.ItemClick += barBtnNew_ItemClick;
            barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            barBtnPrint.ItemClick += barBtnPrint_ItemClick;
            barBtnGet.ItemClick += barBtnGet_ItemClick;

            gvTrd.FocusedRowChanged += gvTrd_FocusedRowChanged;
            gvTrdPrd.FocusedRowChanged += gv_FocusedRowChanged;
            gvAuditPrd.FocusedRowChanged += gv_FocusedRowChanged;
            gvInvalid.FocusedRowChanged += gv_FocusedRowChanged;
            gvFinish.FocusedRowChanged += gv_FocusedRowChanged;

            pgrTrd.Caller = SerNoCaller.Calr_Trade;
            pgrFinish.Caller=pgrTrdprd.Caller = pgrAuditPrd.Caller = pgrPrdInvalid.Caller = SerNoCaller.Calr_TradePrd;

            tabMain_SelectedPageChanged(null, null);
        }

        void barBtnGet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcAuditPrd.GetFocusedDataSource<T_ERP_TradePrd>();
            if (et == null) return;

            var odrs = gcOrder.GetDataSource<T_ERP_OrderPrd>();
            if (odrs.Any(k => k.IsDel)) {
                if (MsgBox.ShowYesNoMessage("订单中存在商品没有用料信息,是否继续获取用料?") == System.Windows.Forms.DialogResult.No) return;
            }

            var trds = SerNoCaller.Calr_TradePrd.GetByProc("exec P_FAS_GenProduceMater @0,@1", et.PrdNo, this.CurUser);
            if (trds.Count < 1) {
                et.IsGetMaterial = true;
                gcAuditPrd.RefreshDataSource();
                MsgBox.ShowMessage("生产用料生成成功!");
            } else {
                if (MsgBox.ShowYesNoMessage("物料库存不足,是否继续获取生产用料?") == System.Windows.Forms.DialogResult.Yes) {
                    SerNoCaller.Calr_TradePrd.GetByProc("exec P_FAS_GenProduceMater @0,@1,@2", et.PrdNo, this.CurUser, 0);
                }
                gv_FocusedRowChanged(gvAuditPrd, null);
            }
        }

        /// <summary>
        /// 打印工序单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcAuditPrd.GetFocusedDataSource<T_ERP_TradePrd>();
            if (et == null) return;
            var vw = new PrintPrdView();
            Lanucher.InitView(vw);
            vw.TradePrd = et;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            }
        }

        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcTrdPrd.GetFocusedDataSource<T_ERP_TradePrd>();
            if (et == null) return;

            var vw = new InvRemarkView();

            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                var rd = SerNoCaller.Calr_TradePrd.ExecSql("exec P_FAS_InvalidTradePrd @0,@1,@2", et.PrdNo, this.CurUser, vw.InvRmrk);
                if (rd.IsOK) {
                    barBtnRefresh_ItemClick(null, null);
                }
            }
        }

        void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var gv = sender as GridView;
            if (gv == null) return;
            var et = gv.GetFocusedDataSource<T_ERP_TradePrd>();
            if (et == null) {
                gcOrder.DataSource = null;
                gcProduce.DataSource = null;
                return;
            }
            gcOrder.DataSource = SerNoCaller.Calr_OrderPrd.Get(" SELECT * FROM V_ERP_OrderPrd  where prdno=@0", et.PrdNo);
            gcProduce.DataSource = SerNoCaller.Calr_ProduceMater.Get(" where ProduceNo=@0", et.PrdNo);
        }

        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcTrdPrd.GetFocusedDataSource<T_ERP_TradePrd>();
            if (et == null) return;

            var noproceodrs = SerNoCaller.Calr_OrderPrd.Get("select * from V_ERP_OrderPrd where prdno=@0 and [Reserved3]=1", et.PrdNo);

            var msg = string.Empty;
            if (noproceodrs!=null && noproceodrs.Count > 0) {
                msg = "生产单中,存在没有工序的商品,可能会影响后续生产流程，";
            }

            if (MsgBox.ShowYesNoMessage(msg+"确定要生产?") == System.Windows.Forms.DialogResult.Yes) {

                if (SerNoCaller.Calr_TradePrd.ExecSql("exec P_FAS_AuditTradePrd @0,@1",et.PrdNo,this.CurUser).IsOK) {
                    var autrds = gcAuditPrd.GetDataSource<T_ERP_TradePrd>();
                    autrds = autrds ?? new List<T_ERP_TradePrd>();
                    autrds.Insert(0, et);

                    gcTrdPrd.RemoveSelected();
                }
            }
        }

        private void gvTrd_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var gv = sender as GridView;
            if (gv == null) return;
            var et = gv.GetFocusedDataSource<T_ERP_Trade>();
            if (et == null) {
                gcOrder.DataSource = null;
                return;
            }
            gcOrder.DataSource = SerNoCaller.Calr_Order.Get(" where tradeno=@0", et.TradeNo);
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (tabMain.SelectedTabPage.Text) {
                case "未处理":
                    UnDeal();
                    break;
                case "待生产":
                    UnProd();
                    break;
                case "生产中":
                    Proded();
                    break;
                case "已完成":
                    Finished();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
        }

        private void UnDeal() {
            pgrTrd.CurrentPage = 1;
            pgrTrd.PrefixWhr = "select * from V_ERP_UnProdTrade";
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
            gvTrd_FocusedRowChanged(gvTrd, null);
        }

        private void Invalid() {
            pgrPrdInvalid.CurrentPage = 1;
            pgrPrdInvalid.PrefixWhr = "select * from V_ERP_InvalidTradePrd";
            pgrPrdInvalid.Whrs.Clear();
            pgrPrdInvalid.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrPrdInvalid.Whrs.Add("FromReceivers like @" + (idx++).ToString());
                pgrPrdInvalid.PrmsData.Add("%" + txtReceiverName.Text.Trim() + "%");
            }

            pgrPrdInvalid.OrderBy = "Order By Id Desc";
            pgrPrdInvalid.BindPageData();
            gv_FocusedRowChanged(gvInvalid, null);
        }

        private void Proded() {
            pgrAuditPrd.CurrentPage = 1;
            pgrAuditPrd.PrefixWhr = "select * from V_ERP_AuditTradePrd";
            pgrAuditPrd.Whrs.Clear();
            pgrAuditPrd.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrAuditPrd.Whrs.Add("FromReceivers like @" + (idx++).ToString());
                pgrAuditPrd.PrmsData.Add("%" + txtReceiverName.Text.Trim() + "%");
            }

            pgrAuditPrd.OrderBy = "Order By Id Desc";
            pgrAuditPrd.BindPageData();
            gv_FocusedRowChanged(gvAuditPrd, null);
        }

        private void Finished() {
            pgrFinish.CurrentPage = 1;
            pgrFinish.PrefixWhr = "select * from V_ERP_FinishedTradePrd";
            pgrFinish.Whrs.Clear();
            pgrFinish.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrFinish.Whrs.Add("FromReceivers like @" + (idx++).ToString());
                pgrFinish.PrmsData.Add("%" + txtReceiverName.Text.Trim() + "%");
            }

            pgrFinish.OrderBy = "Order By Id Desc";
            pgrFinish.BindPageData();
            gv_FocusedRowChanged(gvAuditPrd, null);
        }

        private void UnProd() {
            pgrTrdprd.CurrentPage = 1;
            pgrTrdprd.PrefixWhr = "select * from V_ERP_UnAuditTradePrd";
            pgrTrdprd.Whrs.Clear();
            pgrTrdprd.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtReceiverName.Text.Trim())) {
                pgrTrdprd.Whrs.Add("FromReceivers like @" + (idx++).ToString());
                pgrTrdprd.PrmsData.Add("%" + txtReceiverName.Text.Trim() + "%");
            }

            pgrTrdprd.OrderBy = "Order By Id Desc";
            pgrTrdprd.BindPageData();
            gv_FocusedRowChanged(gvTrdPrd, null);
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcTrdPrd.GetFocusedDataSource<T_ERP_TradePrd>();
            if (et == null) return;
            var vw = new EdtPrdView();
            vw.TradePrd = et;
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var ets = gcTrd.GetSelectedDataSource<T_ERP_Trade>();
            if (ets == null) return;
            var vw = new NewPrdView();
            vw.Trades = ets;
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
                    = barBtnGet.Enabled
                    = barBtnPrint.Enabled
                    = true;
            switch (tabMain.SelectedTabPage.Text) {
                case "未处理":
                    this.barBtnEdt.Enabled
                     = this.barBtnAudit.Enabled
                     = this.barBtnInvalid.Enabled
                    = barBtnPrint.Enabled
                    = barBtnGet.Enabled
                     = false;
                    gvTrd_FocusedRowChanged(gvTrd, null);
                    break;
                case "待生产":
                    this.barBtnNew.Enabled
                    = barBtnPrint.Enabled
                    = barBtnGet.Enabled
                     = false;
                    gv_FocusedRowChanged(gvTrdPrd, null);
                    break;
                case "生产中":
                    this.barBtnNew.Enabled
                    = this.barBtnEdt.Enabled
                    = this.barBtnAudit.Enabled
                    = barBtnInvalid.Enabled
                    = false;
                    gv_FocusedRowChanged(gvAuditPrd, null);
                    break;
                case "已完成":
                    this.barBtnNew.Enabled
                    = this.barBtnEdt.Enabled
                    = this.barBtnAudit.Enabled
                    = barBtnInvalid.Enabled
                    = barBtnPrint.Enabled
                    = barBtnGet.Enabled
                    = false;
                    gv_FocusedRowChanged(gvInvalid, null);
                    break;
                case "已作废":
                    this.barBtnNew.Enabled
                    = this.barBtnEdt.Enabled
                    = this.barBtnAudit.Enabled
                    = barBtnInvalid.Enabled
                    = barBtnPrint.Enabled
                    = barBtnGet.Enabled
                    = false;
                    gv_FocusedRowChanged(gvInvalid, null);
                    break;
            }
        }

        private void rspImg_Click(object sender, EventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_OrderPrd>();
            if (odr == null) return;

            var vw = new UploadImgView();
            vw.Order = new T_ERP_Order { Guid = odr.Guid };
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) { }
        }
        
    }
}
