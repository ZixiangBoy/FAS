using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.FASControls;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using Ultra.FASControls;
using Ultra.Win.Core.Common;
using FAS.Report;
using Ultra.Surface.Common;
using MoreLinq;

namespace FAS.Trade {
    public partial class ProdProceView : MainSurface, ISurfacePermission {
        public ProdProceView() {
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
                    new PermitGridView(this.gvUnFinish,"未完成"),
                    new PermitGridView(this.gvFinish,"已完成"),
                    new PermitGridView(this.gvInvalid,"已作废")
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
                    this.barBtnDone,barBtnInvalid,barBtnEdt
                };
            }
        }

        private void ProdProceView_Load(object sender, EventArgs e) {
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            //barBtnPrint.ItemClick += barBtnPrint_ItemClick;
            barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            barBtnDone.ItemClick += barBtnDone_ItemClick;
            pgrFinish.Caller = pgrInvalid.Caller = pgrUnFinish.Caller = SerNoCaller.Calr_OrderProced;
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnFinish.GetFocusedDataSource<T_ERP_OrderProced>();
            if (et == null) return;
            var vw = new FinishProceView();
            vw.OrderProced = et;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                gcUnFinish.RemoveSelected();
            }
        }

        void barBtnDone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var ets = gcUnFinish.GetSelectedDataSource<T_ERP_OrderProced>();
            if (ets == null || ets.Count < 1) return;

            if (MsgBox.ShowYesNoMessage("确定要完成工序单?") == System.Windows.Forms.DialogResult.No) {
                return;
            }
            ets.ForEach(et => {
                et.IsFinish = true;
                et.FinishTime = TimeSync.Default.CurrentSyncTime;
                et.Updator = this.CurUser;
                SerNoCaller.Calr_OrderProced.Edt(et);
            });
            gcUnFinish.RemoveSelected();
            //var vw = new FinishProceView();
            //vw.OrderProced = et;
            //if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            //    gcUnFinish.RemoveSelected();
            //}
        }

        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnFinish.GetFocusedDataSource<T_ERP_OrderProced>();
            if (et == null) return;

            var vw = new InvRemarkView();

            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                et.IsInvalid = true;
                et.InvalidUser = this.CurUser;
                et.InvalidTime = TimeSync.Default.CurrentSyncTime;
                et.Reserved2 = vw.InvRmrk;

                if (SerNoCaller.Calr_OrderProced.Edt(et).IsOK) {
                    var trds = gcInvalid.GetDataSource<T_ERP_OrderProced>();
                    trds = trds ?? new List<T_ERP_OrderProced>();
                    trds.Insert(0, et);

                    gcUnFinish.RemoveSelected();
                }
            }
        }

        //void barBtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
        //    var odrs = gcUnFinish.GetSelectedDataSource<T_ERP_OrderProced>();
        //    if (odrs == null || odrs.Count < 1) return;

        //    if (MsgBox.ShowYesNoMessage("确定要打印工序单?") == System.Windows.Forms.DialogResult.Yes) {

        //        //DoPrint(odrs);
        //    }
        //}

        //private void DoPrint(List<T_ERP_OrderProced> odrs) {
        //    var prts = odrs.Where(k => k.PrintNum > 0).Select(k => new PrintInfo {
        //        Created = k.Created ?? k.CreateDate,
        //        Creator = this.CurUser,
        //        ProceName = k.ProceName,
        //        ProDelDate = (k.ProDelDate ?? k.CreateDate).ToString("yyyy-MM-dd"),
        //        ProdNo = k.OrderProdNo,
        //        ReceiverName = k.ReceiverName,
        //        Detail = new List<T_ERP_ProdOrder>()
        //    }).DistinctBy(k => k.ProceName).ToList();

        //    prts.ForEach(k => {
        //        var num = 1;
        //        k.Detail.AddRange(odrs.Where(j => j.ProceName == k.ProceName)
        //            .Select(p => new T_ERP_ProdOrder {
        //                Num = p.PrintNum,
        //                OuterIid = p.OuterIid,
        //                OuterSkuId = p.OuterSkuId,
        //                Remark = p.Remark,
        //                RNo = 0,
        //            }).ToList());
        //        k.Detail.ForEach(p => p.RNo = num++);
        //        k.SumNum = k.Detail.Sum(p => p.Num);
        //    });

        //    var rpt = new NewRptSub(prts);
        //    rpt.BindData();
        //    rpt.CreateDocument();
        //    rpt.Print();
        //}


        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (tabMain.SelectedTabPage.Text) {
                case "未完成":
                    UnFinish();
                    break;
                case "已完成":
                    Finish();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
        }

        private void Invalid() {
            pgrInvalid.CurrentPage = 1;
            pgrInvalid.PrefixWhr = "select * from V_ERP_InvalidOrderProced";
            pgrInvalid.Whrs.Clear();
            pgrInvalid.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtPrdNo.Text.Trim())) {
                pgrInvalid.Whrs.Add("prdno=@" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(txtPrdNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtOrderProNo.Text.Trim())) {
                pgrInvalid.Whrs.Add("OrderProdNo=@" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(txtOrderProNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtReceiver.Text.Trim())) {
                pgrInvalid.Whrs.Add(" ReceiverName = @" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(txtReceiver.Text.Trim());
            }
            pgrInvalid.OrderBy = "Order By Id Desc";
            pgrInvalid.BindPageData();
        }

        private void Finish() {
            pgrFinish.CurrentPage = 1;
            pgrFinish.PrefixWhr = "select * from V_ERP_FinishOrderProced";
            pgrFinish.Whrs.Clear();
            pgrFinish.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtPrdNo.Text.Trim())) {
                pgrFinish.Whrs.Add("prdno=@" + (idx++).ToString());
                pgrFinish.PrmsData.Add(txtPrdNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtOrderProNo.Text.Trim())) {
                pgrFinish.Whrs.Add("OrderProdNo=@" + (idx++).ToString());
                pgrFinish.PrmsData.Add(txtOrderProNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtReceiver.Text.Trim())) {
                pgrFinish.Whrs.Add(" ReceiverName = @" + (idx++).ToString());
                pgrFinish.PrmsData.Add(txtReceiver.Text.Trim());
            }
            pgrFinish.OrderBy = "Order By Id Desc";
            pgrFinish.BindPageData();
        }

        private void UnFinish() {
            pgrUnFinish.CurrentPage = 1;
            pgrUnFinish.PrefixWhr = "select * from V_ERP_UnFinishOrderProced";
            pgrUnFinish.Whrs.Clear();
            pgrUnFinish.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtPrdNo.Text.Trim())) {
                pgrUnFinish.Whrs.Add("prdno=@" + (idx++).ToString());
                pgrUnFinish.PrmsData.Add(txtPrdNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtOrderProNo.Text.Trim())) {
                pgrUnFinish.Whrs.Add("OrderProdNo=@" + (idx++).ToString());
                pgrUnFinish.PrmsData.Add(txtOrderProNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtReceiver.Text.Trim())) {
                pgrUnFinish.Whrs.Add(" ReceiverName = @" + (idx++).ToString());
                pgrUnFinish.PrmsData.Add(txtReceiver.Text.Trim());
            }
            pgrUnFinish.OrderBy = "Order By Id Desc";
            pgrUnFinish.BindPageData();
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            this.barBtnDone.Enabled
            = this.barBtnPrint.Enabled
            = this.barBtnInvalid.Enabled
            = this.barBtnEdt.Enabled
            = true;
            switch (tabMain.SelectedTabPage.Text) {
                case "未完成":
                    break;
                case "已完成":
                    this.barBtnDone.Enabled
                     = this.barBtnPrint.Enabled
                     = this.barBtnInvalid.Enabled
                     = barBtnEdt.Enabled
                     = false;
                    break;
                case "已作废":
                    this.barBtnDone.Enabled
                      = this.barBtnPrint.Enabled
                      = this.barBtnInvalid.Enabled
                      = barBtnEdt.Enabled
                      = false;
                    break;
            }
        }
    }
}
