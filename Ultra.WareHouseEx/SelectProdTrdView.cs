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

namespace Ultra.WareHouseEx
{
    public partial class SelectProdTrdView : DialogViewEx {

        public T_ERP_Trade Trade { get; set; }

        public SelectProdTrdView() {
            InitializeComponent();
        }

        private void btnRefreash_Click(object sender, EventArgs e) {
            pgrTrd.CurrentPage = 1;
            pgrTrd.Whrs.Clear(); pgrTrd.PrmsData.Clear();
            pgrTrd.PrefixWhr = "select * from V_ERP_NeedSendGoodsTrade ";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtTrdNo.Text.Trim()))
            {
                pgrTrd.Whrs.Add("TradeNo = @" + (idx++).ToString());
                pgrTrd.PrmsData.Add(txtTrdNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtReceivers.Text.Trim()))
            {
                pgrTrd.Whrs.Add("ReceiverName = @" + (idx++).ToString());
                pgrTrd.PrmsData.Add(txtReceivers.Text.Trim());
            }
            pgrTrd.OrderBy = "Order By Id desc";
            pgrTrd.BindPageData();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var et = gcAudit.GetFocusedDataSource<T_ERP_Trade>();
            if (et == null) return;
            Trade = et;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void gcAudit_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            btnOK_Click(null,null);
        }

        private void SelectProdTrdView_Load(object sender, EventArgs e)
        {
            pgrTrd.Caller = FASControls.SerNoCaller.Calr_Trade;
        }
    }
}
