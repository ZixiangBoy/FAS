﻿using System;
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
using Ultra.Win.Core.Common;

namespace FAS.InStockItem {
    public partial class InStockView : MainSurface, ISurfacePermission {

        public InStockView() {
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
                    new PermitGridView(this.gvUnAudit,"未入库"),
                    new PermitGridView(this.gvAudit,"已入库"),
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
                    this.barBtnNew,barBtnAudit,
                    barBtnInvalid
                };
            }
        }

        private void ProdInStockView_Load(object sender, EventArgs e) {
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            barBtnNew.ItemClick += barBtnNew_ItemClick;

            gvAudit.FocusedRowChanged += gv_FocusedRowChanged;
            gvUnAudit.FocusedRowChanged += gv_FocusedRowChanged;
            gvInvalid.FocusedRowChanged += gv_FocusedRowChanged;

            pgrUnAudit.Caller = pgrAudit.Caller = pgrInvalid.Caller = SerNoCaller.Calr_InStockEx;
        }

        void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gv == null) return;
            var et = gv.GetFocusedDataSource<T_ERP_InStockEx>();
            if (et == null) {
                gcOrder.DataSource = null;
                return;
            }
            gcOrder.DataSource = SerNoCaller.Calr_ItemInStock.Get(" where instockno=@0", et.InStockNo);
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new NewInStockView();
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnAudit.GetFocusedDataSource<T_ERP_InStockEx>();
            if (et == null) return;

            var vw = new InvRemarkView();
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                et.IsInvalid = true;
                et.InvalidUser = this.CurUser;
                et.InvalidTime = TimeSync.Default.CurrentSyncTime;
                et.Reserved2 = vw.InvRmrk;

                if (SerNoCaller.Calr_InStockEx.Edt(et).IsOK) {
                    var trds = gcInvalid.GetDataSource<T_ERP_InStockEx>();
                    trds = trds ?? new List<T_ERP_InStockEx>();
                    trds.Insert(0, et);

                    gcUnAudit.RemoveSelected();
                }
            }
        }

        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcUnAudit.GetFocusedDataSource<T_ERP_InStockEx>();
            if (et == null) return;

            if (SerNoCaller.Calr_InStockEx.ExecSql("exec P_FAS_AuditInStockEx @0,@1", et.InStockNo, this.CurUser).IsOK) {
                var autrds = gcAudit.GetDataSource<T_ERP_InStockEx>();
                autrds = autrds ?? new List<T_ERP_InStockEx>();
                autrds.Insert(0, et);

                gcUnAudit.RemoveSelected();
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (tabMain.SelectedTabPage.Text) {
                case "未入库":
                    UnInStock();
                    break;
                case "已入库":
                    InStock();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
        }

        private void Invalid() {
            pgrInvalid.CurrentPage = 1;
            pgrInvalid.PrefixWhr = "select * from V_ERP_InvalidInStockEx";
            pgrInvalid.Whrs.Clear(); 
            pgrInvalid.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtInStockNo.Text.Trim())) {
                pgrInvalid.Whrs.Add("InStockNo=@" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(txtInStockNo.Text.Trim());
            }

            pgrInvalid.OrderBy = "Order By Id Desc";
            pgrInvalid.BindPageData();
            gv_FocusedRowChanged(gvInvalid, null);
        }

        private void InStock() {
            pgrAudit.CurrentPage = 1;
            pgrAudit.PrefixWhr = "select * from V_ERP_AuditInStockEx";
            pgrAudit.Whrs.Clear(); pgrAudit.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtInStockNo.Text.Trim())) {
                pgrAudit.Whrs.Add("InStockNo=@" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtInStockNo.Text.Trim());
            }

            pgrAudit.OrderBy = "Order By Id Desc";
            pgrAudit.BindPageData();
            gv_FocusedRowChanged(gvAudit, null);
        }

        private void UnInStock() {
            pgrUnAudit.CurrentPage = 1;
            pgrUnAudit.PrefixWhr = "select * from V_ERP_UnAuditInStockEx";
            pgrUnAudit.Whrs.Clear(); pgrUnAudit.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(txtInStockNo.Text.Trim())) {
                pgrUnAudit.Whrs.Add("InStockNo=@" + (idx++).ToString());
                pgrUnAudit.PrmsData.Add(txtInStockNo.Text.Trim());
            }

            pgrUnAudit.OrderBy = "Order By Id Desc";
            pgrUnAudit.BindPageData();
            gv_FocusedRowChanged(gvUnAudit, null);
        }

    }
}
