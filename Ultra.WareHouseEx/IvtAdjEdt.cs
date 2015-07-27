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

namespace Ultra.WareHouseEx
{
    public partial class IvtAdjEdt : DialogViewEx
    {
        public IvtAdjEdt()
        {
            InitializeComponent();
        }

        private void AlarmItemView_Load(object sender, EventArgs e)
        {
            gvSt.OptionsView.ShowAutoFilterRow = false;
            pgr1.Caller = SerNoCaller.Calr_V_ERP_InventCollect;
            var t = new Thread(() =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    wre.LoadFromCache(); area.LoadFromCache(); loc.LoadFromCache();
                }));
            });
            t.IsBackground = true;
            t.Start();

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
            pgr1.PrefixWhr = "select a.* from [V_ERP_InventCollect] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(wre.Text.Trim()))
            {
                pgr1.Whrs.Add("a.WareName = @" + (idx++).ToString());
                pgr1.PrmsData.Add(wre.Text.Trim());
            }
            if (!string.IsNullOrEmpty(area.Text.Trim()))
            {
                pgr1.Whrs.Add("a.AreaName = @" + (idx++).ToString());
                pgr1.PrmsData.Add(area.Text.Trim());
            }
            if (!string.IsNullOrEmpty(loc.Text.Trim()))
            {
                pgr1.Whrs.Add("a.LocName = @" + (idx++).ToString());
                pgr1.PrmsData.Add(loc.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtitem.Text.Trim()))
            {
                pgr1.Whrs.Add("a.ItemName like @" + (idx++).ToString());
                pgr1.PrmsData.Add("%" + txtitem.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtsku.Text.Trim()))
            {
                pgr1.Whrs.Add("a.SkuProperties like @" + (idx++).ToString());
                pgr1.PrmsData.Add("%" + txtsku.Text.Trim() + "%");
            }

            pgr1.OrderBy = "Order By a.Qty desc";
            pgr1.BindPageData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var ds = gcSt.GetDataSource<UltraDbEntity.T_ERP_IvtAdj>();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("没有选择任何行数据！保存无效！"); return; }
            var dss = ds.Where(j => j.Num < 0).ToList();
            if (dss != null && dss.Count > 0)
            {
                MsgBox.ShowErrMsg("调整数量不能小于0");
                return;
            }
            //添加库存调整数据到数据库
            var session = Guid.NewGuid();
            ds.ForEach(
                j =>
                {
                    var ertNo = SerNoCaller.GetSerNo("库存调整单");
                    j.AdjNo = ertNo.SerialNo;
                    j.AdjNum = j.Num - j.Reserved1;
                    j.Updator = j.Creator = this.CurUser;
                    j.Reserved1 = 0; j.Reserved2 = string.Empty; j.Reserved3 = false;
                    j.Guid = session;
                    if (j.Remark == null) j.Remark = string.Empty;
                }
                );
            var rd = SerNoCaller.Calr_IvtAdj.Add(ds);
            if (rd == null || !string.IsNullOrEmpty(rd.ErrMsg))
            {
                MsgBox.ShowErrMsg("保存失败！原因：" + rd.ErrMsg);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void gcStock_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var ett = gcStock.GetFocusedDataSource<UltraDbEntity.V_ERP_InventCollect>();
            var et = ett.MapTo<UltraDbEntity.V_ERP_InventCollect, UltraDbEntity.T_ERP_IvtAdj>();
            if (et == null) return;
            et.SrcWareName = ett.WareName;
            et.SrcAreaName = ett.AreaName;
            et.SrcLocName = ett.LocName;
            et.Reserved1 = Convert.ToInt32(ett.Qty);

            var ds = gcSt.GetDataSource<UltraDbEntity.T_ERP_IvtAdj>();
            ds = ds ?? new List<UltraDbEntity.T_ERP_IvtAdj>();
            var mch = ds.Where(j => j.OuterIid == et.OuterIid && j.OuterSkuId == et.OuterSkuId).FirstOrDefault();
            if (mch != null) mch.Num += 1;
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
