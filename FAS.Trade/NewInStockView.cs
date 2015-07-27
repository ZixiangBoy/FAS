using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.FASControls;
using Ultra.Surface.Form;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using DevExpress.XtraEditors;
using Ultra.Surface.Common;

namespace FAS.Trade {
    public partial class NewInStockView : DialogViewEx {
        public NewInStockView() {
            InitializeComponent();
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var vw = new SelectProdTrdView();
            if (vw.ShowDialog() == DialogResult.OK) {
                btnSelect.Text = vw.TradePrd.PrdNo;

                LoadItems(vw.TradePrd.PrdNo);
            }
        }

        private void LoadItems(string prdno) {
            gcOrder.DataSource = SerNoCaller.Calr_OrderInStock.Get("select * from V_ERP_FinishOrderPrd where prdno=@0", prdno);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var odrs=gcOrder.GetDataSource<T_ERP_OrderInStock>();
            odrs=odrs ?? new List<T_ERP_OrderInStock>();


            var inodrs = odrs.Where(k=>k.InStockNum>0).ToList();

            if (inodrs == null || inodrs.Count < 1) return;

            if (inodrs.Any(k=>string.IsNullOrEmpty(k.LocName))) {
                MsgBox.ShowErrMsg("必须选择入库库位!");
                return;
            }

            var instock = new T_ERP_InStock {
                InStockNo=SerNoCaller.GetSerNo("入库单").SerialNo,
                Creator=this.CurUser,
                Updator=this.CurUser,
                Remark=txtRemark.Text,
                Reserved2=string.Empty,
                TotalNum = inodrs.Sum(k=>k.InStockNum),
                PrdNo=btnSelect.Text,
                Guid=Guid.NewGuid()
            };
            inodrs.ForEach(k => {
                k.InStockNo = instock.InStockNo;
                k.Guid = Guid.NewGuid();
            });
            var rd = SerNoCaller.Calr_OrderInStock.Add(inodrs);
            if (rd.IsOK) {
                rd = SerNoCaller.Calr_InStock.Add(instock);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void rspInStockNum_Validating(object sender, CancelEventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_OrderInStock>();
            if (odr == null) return;

            var rsp = sender as SpinEdit;
            if (odr.CanInStockNum < rsp.Value) {
                e.Cancel = true;
            }
        }

        private void NewInStockView_Load(object sender, EventArgs e) {
            rspLoc.DataSource = SerNoCaller.Calr_WareLoc.Get();
        }

        private void rspLoc_EditValueChanged(object sender, EventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_OrderInStock>();
            if (odr == null) return;

            var rsp = sender as GridLookUpEdit;
            var view = rsp.Properties.View;

            var loc=view.GetFocusedDataSource<T_ERP_WareLoc>();
            if (loc == null) return;


            odr.WareName = loc.WareName;
            odr.LocName = loc.LocName;
            odr.AreaName = loc.AreaName;

            gcOrder.RefreshDataSource();
        }
    }
}
