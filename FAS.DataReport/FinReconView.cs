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
    public partial class FinReconView : MainSurface, ISurfacePermission {

        public FinReconView() {
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

        private void FinReconView_Load(object sender, EventArgs e) {
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var whr = string.Empty;
            if (!string.IsNullOrEmpty(txtRecvOprUser.Text)) {
                whr = BuildSqlWhere(whr, string.Format(" RecvOprUser='{0}'", txtRecvOprUser.Text));
            }
            gc.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                string.Format("select * from V_ERP_FinStatement {0}", whr));
        }

        private void barBtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                gc.ExportToXls(dlg.FileName);
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

        private void FinReconView_AfterLoad(object sender, EventArgs e) {
            barBtnExport.Visibility = barBtnExportXls.Visibility;
        }
    }
}
