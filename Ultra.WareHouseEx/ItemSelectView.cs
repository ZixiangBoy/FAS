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
using Ultra.FASControls.Views;
using Ultra.Common;
using Ultra.Surface.Common;
using System.IO;
using Ultra.Surface.Lanuch;
using System.Threading;
using Ultra.FASControls;
using UltraDbEntity;

namespace Ultra.WareHouseEx
{
    public partial class ItemSelectView : DialogViewEx
    {
        public ItemSelectView()
        {
            InitializeComponent();
        }

        public List<T_ERP_DeliveryItem> Items;

        private void AlarmItemView_Load(object sender, EventArgs e)
        {
            gvSt.OptionsView.ShowAutoFilterRow = false;
            pgr1.Caller = SerNoCaller_WL.Calr_V_ERP_InventSelect;
            foreach (Control c in panelControl2.Controls)
            {
                c.KeyUp += (s1, e1) =>
                {
                    if (e1.KeyCode == Keys.Enter)
                        btnCtl1_Click(s1, null);
                };
            }
        }

        private void btnCtl1_Click(object sender, EventArgs e)
        {
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear(); pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select a.* from V_ERP_InventSelect a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtSupp.Text.Trim()))
            {
                pgr1.Whrs.Add("a.SuppName = @" + (idx++).ToString());
                pgr1.PrmsData.Add(txtSupp.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtitem.Text.Trim()))
            {
                pgr1.Whrs.Add("a.OuterIid like @" + (idx++).ToString());
                pgr1.PrmsData.Add("%" + txtitem.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtsku.Text.Trim()))
            {
                pgr1.Whrs.Add("a.OuterSkuId like @" + (idx++).ToString());
                pgr1.PrmsData.Add("%" + txtsku.Text.Trim() + "%");
            }

            pgr1.OrderBy = "Order By a.Qty desc";
            pgr1.BindPageData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var ds = gcSt.GetDataSource<UltraDbEntity.T_ERP_DeliveryItem>();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("没有选择任何行数据！保存无效！"); return; }
            var dss = ds.Where(j => j.SendNum < 0 || j.SendNum>j.Qty).ToList();
            if (dss != null && dss.Count > 0)
            {
                MsgBox.ShowErrMsg("出库数不能小于0或大于当前库存数");
                return;
            }
            Items = ds.Where(j=>j.SendNum>0).ToList();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void gcStock_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var ett = gcStock.GetFocusedDataSource<UltraDbEntity.V_ERP_InventSelect>();
            var et = ett.MapTo<UltraDbEntity.V_ERP_InventSelect, UltraDbEntity.T_ERP_DeliveryItem>();
            if (et == null) return;

            var ds = gcSt.GetDataSource<UltraDbEntity.T_ERP_DeliveryItem>();
            ds = ds ?? new List<UltraDbEntity.T_ERP_DeliveryItem>();
            var mch = ds.Where(j => j.OuterIid == et.OuterIid
                && j.OuterSkuId == et.OuterSkuId && j.SuppName == et.SuppName).FirstOrDefault();
            if (mch != null) mch.SendNum += 1;
            else { ds.Insert(0, et); }
            gcSt.DataSource = ds;
            gcSt.RefreshDataSource();

        }

        private void gcSt_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            gcSt.RemoveSelected();
        }

    }
}
