using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.FASControls.Extend;
using UltraDbEntity;
using Ultra.Surface.Common;
using Ultra.FASControls;

namespace FAS.Trade {
    public partial class EdtPrdView : DialogViewEx {
        public T_ERP_TradePrd TradePrd { get; set; }

        public EdtPrdView() {
            InitializeComponent();
        }

        private void EdtPrdView_Load(object sender, EventArgs e) {
            gvOrder.OptionsView.ShowAutoFilterRow = false;
            LoadData();
        }

        private void LoadData() {
            gcOrder.DataSource = SerNoCaller.Calr_OrderPrd.Get(" where prdno=@0",TradePrd.PrdNo);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var odrs = gcOrder.GetDataSource<T_ERP_OrderPrd>();
            if (odrs == null) return;

            if (odrs.All(k => !k.IsProd)) {
                MsgBox.ShowErrMsg("没有选择需要生产的商品!");
                return;
            }

            var podrs = odrs.Where(k=>!k.IsProd).ToList();

            if (podrs.Count < 1) return;

            TradePrd.Updator = this.CurUser;
            SerNoCaller.Calr_TradePrd.Edt(TradePrd);

            var whr = podrs.Select(k=>k.Guid.ToString()).Aggregate((s1,s2)=>s1+"','"+s2);
            var rd = SerNoCaller.Calr_OrderPrd.ExecSql(string.Format(" delete T_ERP_OrderPrd where guid in ('{0}'); update T_ERP_Order set isprod=0 where guid in ('{0}')", whr));

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void rspUISelected_EditValueChanged(object sender, EventArgs e) {
            var chk = sender as DevExpress.XtraEditors.CheckEdit;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_OrderPrd>();
            if (odr == null) return;
            odr.IsProd = chk.Checked;

            gcOrder.RefreshDataSource();
        }
    }
}
