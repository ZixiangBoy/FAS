using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Web.Core.Common;

namespace FAS.DataReport {
    public partial class PrdProcePriceRptView : MainSurface, ISurfacePermission {
        public PrdProcePriceRptView() {
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
                    new PermitGridView(this.gv,"计件工资"),
                    new PermitGridView(this.gv1,"工人工作量")
                };
            }
        }

        public List<Control> MenuItems {
            get;
            set;
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                    barBtnExportXls,barBtnRefresh
                };
            }
        }

        private void PrdProcePriceRptView_Load(object sender, EventArgs e) {
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
            workeredt.LoadFromCache();
        }

        void barBtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                switch (tabMain.SelectedTabPage.Text) {
                    case "日工资报表":
                        gc.ExportToXls(dlg.FileName);
                        break;
                    case "月工资报表":
                        gc1.ExportToXls(dlg.FileName);
                        break;
                }
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var whr = string.Empty;
            if (workeredt.GetSelectedValue() != null) {
                whr = BuildSqlWhere(whr, string.Format(" proceuser='{0}'", workeredt.GetSelectedValue().RealName));
            }
            if (!string.IsNullOrEmpty(txtOuterIid.Text)) {
                whr = BuildSqlWhere(whr, string.Format(" outeriid='{0}'", txtOuterIid.Text));
            }
            switch (tabMain.SelectedTabPage.Text) {
                case "日工资报表":
                    if (!string.IsNullOrEmpty(dateedt.Text)) {
                        whr = BuildSqlWhere(whr, string.Format(" date='{0}'", dateedt.DateTime));
                    }
                    gc.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                        string.Format("select * from V_ERP_WorkloadProceDay {0}", whr));
                    break;
                case "月工资报表":
                    if (!string.IsNullOrEmpty(dateedt.Text)) {
                        whr = BuildSqlWhere(whr, string.Format(" date='{0}'", dateedt.DateTime.AddDays(1 - dateedt.DateTime.Day)));
                    }
                    gc1.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                        string.Format("select * from V_ERP_WorkloadProce {0}", whr));
                    break;
                default:
                    break;
            }
        }

        string BuildSqlWhere(string whr, string para) {
            if (!whr.Contains("where")) {
                whr += " where " + para;
            } else {
                whr += " and " + para;
            }
            return whr;
        }

        private void PrdProcePriceRptView_AfterLoad(object sender, EventArgs e) {
            barBtnExport.Visibility = barBtnExportXls.Visibility;
        }
    }
}
