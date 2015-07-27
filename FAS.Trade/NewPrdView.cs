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
    public partial class NewPrdView : DialogViewEx {
        public List<T_ERP_Trade> Trades { get; set; }
        
        public NewPrdView() {
            InitializeComponent();
        }

        private void EdtPrdView_Load(object sender, EventArgs e) {
            gvTrd.OptionsView.ShowAutoFilterRow = false;
            gvOrder.OptionsView.ShowAutoFilterRow = false;

            LoadData();
        }

        private void LoadData() {
            gcTrd.DataSource = Trades;
            var whr = Trades.Select(k => k.TradeNo).Aggregate((s1,s2)=>s1+"','"+s2);
            var odrs= SerNoCaller.Calr_Order.Get(string.Format(" where IsProd=0 and tradeno in ('{0}')",whr));
            odrs.ForEach(k=>k.IsProd=true);

            gcOrder.DataSource=odrs;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var odrs = gcOrder.GetDataSource<T_ERP_Order>();
            if (odrs == null) return;

            if (odrs.All(k => !k.IsProd)) {
                MsgBox.ShowErrMsg("没有选择需要生产的商品!");
                return;
            }

            Guid grpGuid = Guid.NewGuid();

            var podrs = odrs.Where(k=>k.IsProd).ToList();
            podrs.ForEach(k=>{
                k.ProdSession = grpGuid;
            });

            var rd=SerNoCaller.Calr_Order.BatchEdt(podrs);
            if (rd.IsOK) {
                rd=SerNoCaller.Calr_TradePrd.ExecSql("exec P_FAS_GenTradeProd @0,@1", grpGuid,this.CurUser);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void rspUISelected_EditValueChanged(object sender, EventArgs e) {
            var chk = sender as DevExpress.XtraEditors.CheckEdit;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            odr.UISelected = chk.Checked;

            gcOrder.RefreshDataSource();
        }
    }
}
