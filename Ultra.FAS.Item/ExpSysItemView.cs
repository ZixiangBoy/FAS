using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using Ultra.Common;
namespace Ultra.FAS.Item
{
    public partial class ExpSysItemView : DialogViewEx
    {
        public ExpSysItemView()
        {
            InitializeComponent();
            gc.ColorFieldName = "ColorFieldName";
            this.btnOK.Click += (s1, s2) =>
            {
                gc.GridExportXls();
            };
        }

        public bool ImedyExport = true;

        /// <summary>
        /// 导出系统商品
        /// </summary>
        public void DoExport()
        {
            var sql = "select * from V_ERP_ItemExportSys order by 商品编码,规格编码";
            var dt = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text, sql, null);
            foreach (System.Data.DataColumn col in dt.Columns)
            {
                if (col.Caption.EqualIgnorCase(gc.ColorFieldName)) continue;
                gv.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    Caption = col.Caption
                    ,
                    FieldName = col.Caption,
                    Visible = true,
                });
            }
            gc.DataSource = dt;
            gc.RefreshDataSource();
            var lst = new List<DevExpress.XtraGrid.Columns.GridColumn>();
            gv.OptionsPrint.UsePrintStyles = !gv.OptionsPrint.UsePrintStyles;
            if (ImedyExport)
                gc.GridExportXls();
        }

        public void DoExport(string sql)
        {
            var dt = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text, sql, null);
            gc.DataSource = dt;
            if (ImedyExport)
                gc.GridExportXls();
        }

        public void LoadDataShow(DataTable dt)
        {
            this.gc.DataSource = dt;
        }
    }
}
