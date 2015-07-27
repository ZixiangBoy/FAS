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
using Ultra.Web.Core.Common;
using Ultra.FASControls.Extend;
using Ultra.Common;

namespace Ultra.FASControls.Views
{
    public partial class ExportDataView : DialogViewEx
    {
        public ExportDataView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 以 DataTable结果导出
        /// 导出的列为DataTable列名
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="prms"></param>
        public virtual void ExportDataTable(string sql, params SqlParameter[] prms)
        {
            gc.DataSource = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text, sql, prms);
            gc.RefreshDataSource();

            gc.GridExportXls();
        }

        /// <summary>
        /// 以实体导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ojs"></param>
        public virtual void Export<T>(List<T> ojs, Dictionary<string, string> dicKC = null)
        {
            if (null == ojs) return;
            var pis = Ultra.Web.Core.Common.ObjectHelper.GetProPerty<T>();
            gv.Columns.Clear();
            if (null == dicKC)
            {
                foreach (var pi in pis)
                {
                    if (pi.Name.StartsWith("meta_", StringComparison.OrdinalIgnoreCase) ||
                        pi.Name.EqualIgnorCase("UISelected") ||
                        pi.Name.EqualIgnorCase("IsDynamicAdd")) continue;

                    var col = new DevExpress.XtraGrid.Columns.GridColumn
                    {
                        FieldName = pi.Name,
                        Caption = pi.Name //null != dicKC && dicKC.ContainsKey(pi.Name) ? dicKC[pi.Name] : pi.Name
                    };
                    col.Visible = true;
                    gv.Columns.Add(col);
                }
            }
            else
            {
                var pist = pis.ToList();
                foreach (KeyValuePair<string, string> kvp in dicKC)
                {
                    var mch =pist.Where(j => j.Name.EqualIgnorCase(kvp.Key)).FirstOrDefault();
                    if (null == mch) continue;
                    var col = new DevExpress.XtraGrid.Columns.GridColumn
                    {
                        FieldName = mch.Name,
                        Caption = dicKC[mch.Name]
                    };
                    col.Visible = true;
                    gv.Columns.Add(col);
                }
            }
            gc.DataSource = ojs;
            gc.RefreshDataSource();
            gc.GridExportXls();
        }
    }
}
