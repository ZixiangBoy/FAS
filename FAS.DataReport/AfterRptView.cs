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
    public partial class AfterRptView : MainSurface, ISurfacePermission {

        public AfterRptView()
        {
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
                    new PermitGridView(this.gvCnt,"售后单数"),
                    new PermitGridView(this.gvType,"售后类型")
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
                switch (tabMain.SelectedTabPageIndex) {
                    case 0:
                        gcCnt.ExportToXls(dlg.FileName);
                        break;
                    case 1:
                        gcType.ExportToXls(dlg.FileName);
                        break;
                    default:
                        break;
                }
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var whr = string.Empty;
            
            switch (tabMain.SelectedTabPageIndex) {
                case 0: 
                    if (!string.IsNullOrEmpty(dateeSt.Text)) {
                        whr = BuildSqlWhere(whr, string.Format(" date>='{0}'", dateeSt.DateTime));
                    }
                    if (!string.IsNullOrEmpty(dateEnd.Text))
                    {
                        whr = BuildSqlWhere(whr, string.Format(" date<='{0}'", dateEnd.DateTime));
                    }
                    gcCnt.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                        string.Format("select * from V_ERP_AfterSalesCnt {0}", whr));
                    break;
                case 1: 
                    if (!string.IsNullOrEmpty(dateeSt.Text)) {
                        whr = BuildSqlWhere(whr, string.Format(" date>='{0}'", dateeSt.DateTime));
                    }
                    if (!string.IsNullOrEmpty(dateEnd.Text))
                    {
                        whr = BuildSqlWhere(whr, string.Format(" date<='{0}'", dateEnd.DateTime));
                    }
                    gcType.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                        string.Format("select * from V_ERP_AfterExpenses {0}", whr));
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
