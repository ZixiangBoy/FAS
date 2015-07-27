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
using Ultra.FASControls.Caller;

namespace FAS.MaterialWare
{
    public partial class MaterialIvtAdjEdt : DialogViewEx
    {
        public MaterialIvtAdjEdt()
        {
            InitializeComponent();
        }

        private void AlarmItemView_Load(object sender, EventArgs e)
        {
            gvSt.OptionsView.ShowAutoFilterRow = false;
            pgr1.Caller = SerNoCaller.Calr_InventoryMaterial;
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
            pgr1.PrefixWhr = "select a.* from V_ERP_GetInventoryMaterial a";
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
                pgr1.Whrs.Add("a.MaterialNo = @" + (idx++).ToString());
                pgr1.PrmsData.Add(txtitem.Text.Trim());
            }
            pgr1.OrderBy = "Order By a.Qty desc";
            pgr1.BindPageData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var ds = gcSt.GetDataSource<UltraDbEntity.T_ERP_MaterialIvtRet>();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("没有选择任何行数据！保存无效！"); return; }

            var flt = ds.Where(j => j.Num <= 0 || j.Num > j.Reserved1);
            if (flt != null && flt.Count() > 0)
            {
                MsgBox.ShowErrMsg("退回数不得大于库存数或小于等于0");
                return;
            }
            //添加库存调整数据到数据库
            var session = Guid.NewGuid();
            ds.ForEach(j =>
                {
                    j.Creator = j.Updator = CurUser;
                     j.Reserved2 = string.Empty; j.Reserved3 = false;
                    j.Guid = session; j.CreateDate = j.UpdateDate = Ultra.Win.Core.Common.TimeSync.Default.CurrentSyncTime;
                    j.RetNum = j.Num;
                }
            );
            
            var rd = SerNoCaller_WL.Calr_MaterialIvtRet.Add(ds);
            if (rd==null||!string.IsNullOrEmpty(rd.ErrMsg))
            {
                MsgBox.ShowErrMsg("保存失败！原因："+rd.ErrMsg);
                return;
            }
            //创建入库调整单
            var vt = SerNoCaller_WL.Calr_MaterialIvtRet.ExecSql("exec P_ERP_NMaterialRet @0", session);
            if (!string.IsNullOrEmpty(vt.ErrMsg))
            {
                MsgBox.ShowErrMsg(vt.ErrMsg); return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void gcStock_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var ett = gcStock.GetFocusedDataSource<UltraDbEntity.T_ERP_InventoryMaterial>();
            if (null == ett) return;
            var et = ett.MapTo<UltraDbEntity.T_ERP_InventoryMaterial, UltraDbEntity.T_ERP_MaterialIvtRet>();
            if (et == null) return;
            et.SrcWareName = ett.WareName;
            et.SrcAreaName = ett.AreaName;
            et.SrcLocName = ett.LocName;
            et.Reserved1 = Convert.ToInt32(ett.Qty);

            var ds = gcSt.GetDataSource<UltraDbEntity.T_ERP_MaterialIvtRet>();
            ds = ds ?? new List<UltraDbEntity.T_ERP_MaterialIvtRet>();
            var mch = ds.Where(j => j.Guid == et.Guid).FirstOrDefault();
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
