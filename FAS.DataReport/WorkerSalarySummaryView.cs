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
    public partial class WorkerSalarySummaryView : MainSurface, ISurfacePermission {
        public WorkerSalarySummaryView() {
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
                    new PermitGridView(this.gv,"月工资表")
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

        private void WorkerSalarySummaryView_Load(object sender, EventArgs e) {
            workeredt.LoadFromCache();
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
        }

        void barBtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                gc.ExportToXls(dlg.FileName);
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var whr = string.Empty;
            if (!string.IsNullOrEmpty(dateedt.Text)) {
                whr = BuildSqlWhere(whr, string.Format(" [月份]='{0}'", dateedt.DateTime));
            }
            if (workeredt.GetSelectedValue() != null) {
                whr = BuildSqlWhere(whr, string.Format(" [姓名]='{0}'", workeredt.GetSelectedValue().RealName));
            }
            gc.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                string.Format("select * from V_ERP_WorkerSalarySummary {0}", whr));
        }

        private void WorkerSalarySummaryView_AfterLoad(object sender, EventArgs e) {
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
