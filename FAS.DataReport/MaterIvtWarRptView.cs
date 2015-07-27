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
    public partial class MaterIvtWarRptView : MainSurface, ISurfacePermission {
        public MaterIvtWarRptView() {
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
                    //new PermitGridView(this.gvTrd,"待生产"),
                    //new PermitGridView(this.gvOrder,"商品明细")
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

        private void MaterIvtWarRptView_Load(object sender, EventArgs e) {
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
            materialGridEdt1.LoadFromCache();
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
            if (materialGridEdt1.GetSelectedValue()!=null) {
                whr = BuildSqlWhere(whr, string.Format(" MaterialNo='{0}'", materialGridEdt1.GetSelectedValue().MaterialNo));
            }
            gc.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text,
                string.Format("select * from V_ERP_MaterInventoryWarning {0}", whr));
        }

        string BuildSqlWhere(string whr, string para) {
            if (!whr.Contains("where")) {
                whr += " where " + para;
            } else {
                whr += " and " + para;
            }
            return whr;
        }

        private void MaterIvtWarRptView_AfterLoad(object sender, EventArgs e) {
            barBtnExport.Visibility = barBtnExportXls.Visibility;
        }
    }
}
