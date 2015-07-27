using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using Ultra.FASControls;

namespace FAS.Trade {
    public partial class SelectProdTrdView : DialogViewEx {

        public T_ERP_TradePrd TradePrd { get; set; }

        public SelectProdTrdView() {
            InitializeComponent();
        }

        private void btnRefreash_Click(object sender, EventArgs e) {
            var whr = string.Empty;
            if (!string.IsNullOrEmpty(txtPrdNo.Text)) {
                whr += string.Format(" and PrdNo='{0}'",txtPrdNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtReceiver.Text)) {
                whr += string.Format(" and FromReceivers like '%{0}%'", txtReceiver.Text.Trim());
            }

            gcAuditPrd.DataSource = SerNoCaller.Calr_TradePrd.Get(" select * from V_ERP_FinishTradePrd where exists(select 1 from V_ERP_FinishOrderPrd where prdno=V_ERP_FinishTradePrd.prdno and caninstocknum>0)" + whr);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var et = gcAuditPrd.GetFocusedDataSource<T_ERP_TradePrd>();
            if (et == null) return;
            TradePrd = et;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
