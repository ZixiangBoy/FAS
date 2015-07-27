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
using Ultra.Web.Core.Common;

namespace FAS.DataReport {
    public partial class TradeRptView : MainSurface, ISurfacePermission {

        public TradeRptView() {
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
                    new PermitGridView(this.gv,"订单报表")
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
                    barBtnRefresh,barBtnExportXls,
                };
            }
        }

        private void TradeRptView_Load(object sender, EventArgs e) {

            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
        }

        void barBtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                switch (tabMain.SelectedTabPage.Text) {
                    case "订单月报表":
                        gc.ExportToXls(dlg.FileName);
                        break;
                    case "订单日报表":
                        gc1.ExportToXls(dlg.FileName);
                        break;
                    default:
                        break;
                }
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var whr = string.Empty;
            
            if (!string.IsNullOrEmpty(txtRecvOprUser.Text)) {
                whr = BuildSqlWhere(whr, string.Format(" RecvOprUser='{0}'", txtRecvOprUser.Text));
            }
            switch (tabMain.SelectedTabPage.Text) {
                case "订单月报表": 
                    if (!string.IsNullOrEmpty(dateedt.Text)) {
                        whr = BuildSqlWhere(whr, string.Format(" date='{0}'", dateedt.DateTime.AddDays(1 - dateedt.DateTime.Day)));
                    }
                    gc.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                        string.Format("select * from V_ERP_TradeReport {0}", whr));
                    break;
                case "订单日报表": 
                    if (!string.IsNullOrEmpty(dateedt.Text)) {
                        whr = BuildSqlWhere(whr, string.Format(" date='{0}'", dateedt.DateTime));
                    }
                    gc1.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                        string.Format("select * from V_ERP_TradeDayReport {0}", whr));
                    break;
                default:
                    break;
            }
        }

        private void TradeRptView_AfterLoad(object sender, EventArgs e) {
            barBtnExport.Visibility = barBtnExportXls.Visibility;
        }

        string BuildSqlWhere(string whr, string para) {
            if (!whr.Contains("where")) {
                whr += " where " + para;
            } else {
                whr += " and " + para;
            }
            return whr;
        }
    }
}
