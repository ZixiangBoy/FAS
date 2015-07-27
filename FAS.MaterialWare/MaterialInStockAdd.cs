using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.FASControls.Caller;
using Ultra.FASControls.Extend;
using Ultra.Common;
using Ultra.Surface.Common;
using System.IO;
using Ultra.Surface.Lanuch;
using MoreLinq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using Ultra.FASControls;

namespace FAS.MaterialWare
{
    public partial class MaterialInStockAdd : DialogViewEx
    {
        public MaterialInStockAdd()
        {
            InitializeComponent();
        }

        List<UltraDbEntity.T_ERP_WareLoc> CacheLoc;
        public UltraDbEntity.T_ERP_InStockMatMaster Ent { get; set; }

        private void StockAddView_Load(object sender, EventArgs e)
        {
            CacheLoc = this.Cacher.Get<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc");
            if (null == CacheLoc || CacheLoc.Count < 1)
            {
                var fi = Path.Combine(Lanucher.AppDir, "SYS.Cache.V_ERP_NotVirtualLoc.jsn");
                if (File.Exists(fi))
                    CacheLoc = File.ReadAllText(fi).DeSerialize<List<UltraDbEntity.T_ERP_WareLoc>>();
                else
                    CacheLoc = SerNoCaller.Calr_WareLoc.Get("Select * from V_ERP_NotVirtualLoc")
                        .OrderBy(j => j.Distance).ThenBy(j => j.Shelf).ThenBy(j => j.Floor).ToList();

                File.WriteAllText(fi, (CacheLoc).SerializeJson());
                CacheLoc = SerNoCaller.Calr_WareLoc.Get("Select * from V_ERP_NotVirtualLoc")
                        .OrderBy(j => j.Distance).ThenBy(j => j.Shelf).ThenBy(j => j.Floor).ToList();

                this.Cacher.Put<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc", CacheLoc);
            }
            repLoc.DataSource = CacheLoc;
            pgr1.Caller = SerNoCaller.Calr_Material;
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                txtSend.Text = Ent.SendNo;
                txtReceiv.Text = Ent.ReceiverName;
                txtHands.Text = Ent.Handlers;
                comType.Text = Ent.InStockType;
                txtCreatedate.DateTime =(DateTime)Ent.ReceiveTime;
                var et=SerNoCaller_GC.Calr_InStockMaterial.Get("where InStockNo=@0",Ent.InStockNo);
                if (et == null)
                {
                    gcStckItem.DataSource = null;
                }
                else
                {
                    gcStckItem.DataSource = et;
                }
            }
        }


        private void gcItem_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var et = gcItem.GetFocusedDataSource<UltraDbEntity.T_ERP_Material>();
            if (null == et) return;
            var jt = et.MapTo<UltraDbEntity.T_ERP_Material, UltraDbEntity.T_ERP_InStockMaterial>();
            if (null == jt) return;
            jt.Num = 1;
            if (jt.CostPrice > 0)
            {
                jt.AllCostPrice = jt.CostPrice * jt.Num;
            }
            else
            {
                jt.AllCostPrice = 0;
            }
            jt.Reserved3 = true;
            var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockMaterial>();
            ds = ds ?? new List<UltraDbEntity.T_ERP_InStockMaterial>();
            var mch = ds.Where(j => j.Guid == et.Guid).FirstOrDefault();
            if (mch != null) mch.Num += 1;
            else { ds.Insert(0, jt); }        
            gcStckItem.DataSource = ds;
            gcStckItem.RefreshDataSource();
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            var et = gcStckItem.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMaterial>();
            if (null == et) return;
            gcStckItem.RemoveSelected();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            var dt = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockMaterial>();
            if (null == dt || dt.Count < 1)
            {
                MsgBox.ShowErrMsg("必须包含入库商品!");
                return;
            }

            if (dt.Count(k => string.IsNullOrEmpty(k.WareName)) > 0)
            {
                MsgBox.ShowErrMsg("必须所有商品分配库位！");
                return;
            }
            dt = dt.Where(j => j.Num > 0).ToList();
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                var itmSession = Guid.NewGuid();
                decimal sumNum = 0;
                //创建商品集合
                dt.ForEach(j =>
                {
                    j.Creator = this.CurUser; j.Updator = this.CurUser;
                    j.Reserved1 = 0; j.Reserved2 = string.Empty;
                    j.Guid = itmSession;
                    sumNum += j.Num;
                    j.Remark = j.Remark == null ? "" : j.Remark;
                });
                var rd = SerNoCaller_GC.Calr_InStockMaterial.Add(dt);
                if (!rd.IsOK)
                {
                    MsgBox.ShowErrMsg(rd.ErrMsg); return;
                }
                Ent = SerNoCaller_GC.Calr_InStockMatMaster.GetByProc("exec P_ERP_MaterialInStock @0,@1,@2,@3,@4,@5,@6,@7"
                    , this.CurUser, sumNum, itmSession, txtSend.Text, txtHands.Text, txtReceiv.Text, comType.Text, txtCreatedate.DateTime).FirstOrDefault();

                if (Ent == null)
                {
                    MsgBox.ShowErrMsg("创建入库单失败!"); return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                return;
            }
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                var rt = SerNoCaller_GC.Calr_InStockMaterial.ExecSql("exec P_ERP_DelInStockMaterial @0",Ent.InStockNo);
                if (!rt.IsOK)
                {
                    MsgBox.ShowErrMsg(rt.ErrMsg); return;
                }
                decimal sumNum = 0;
                dt.ForEach(j =>
                {
                    j.Creator = this.CurUser; j.Updator = this.CurUser;
                    j.Reserved1 = 0; j.Reserved2 = string.Empty;
                    j.Guid = Ent.Guid;
                    j.InStockNo = Ent.InStockNo;
                    sumNum += j.Num;
                    j.Remark = j.Remark == null ? "" : j.Remark;
                });
                var rd = SerNoCaller_GC.Calr_InStockMaterial.Add(dt);
                if (!rd.IsOK)
                {
                    MsgBox.ShowErrMsg(rd.ErrMsg); return;
                }
                var ett = SerNoCaller_GC.Calr_InStockMatMaster.ExecSql("exec P_ERP_MaterialInStockEdit @0,@1,@2,@3,@4,@5,@6,@7"
                    , this.CurUser, sumNum, Ent.InStockNo, txtSend.Text, txtHands.Text, txtReceiv.Text, comType.Text, txtCreatedate.DateTime);

                if (!ett.IsOK)
                {
                    MsgBox.ShowErrMsg("入库单修改失败!"); return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                return;
            }
        }

        public string[] Lanucer { get; set; }

        private void txtItem_KeyUp(object sender, KeyEventArgs e)
        {
            btnCtl1_Click(null, null);
        }

        private void gcStckItem_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            btnDelItem_Click(null, null);
        }

        private void gvStckItem_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockMaterial>();
            if (null == ds || ds.Count < 1) return;
            if (e.Column.FieldName == "LocName")
            {
                var et = CacheLoc.FirstOrDefault(j => j.LocName == e.Value.ToString());
                var nt = gvStckItem.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMaterial>();
                nt.WareName = et.WareName; nt.AreaName = et.AreaName;
                gvStckItem.MakeRowEditImmediateSave(e.Value);

                if (ds.Where(j => string.IsNullOrEmpty(j.LocName)).Count() > 0)
                {
                    ds.ForEach(j =>
                    {
                        j.LocName = e.Value.ToString();
                        j.WareName = et.WareName;
                        j.AreaName = et.AreaName;
                    });
                }
                gcStckItem.DataSource = ds;
            }
            gcStckItem.RefreshDataSource();
        }

        private void btnCtl1_Click(object sender, EventArgs e)
        {
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear(); pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select a.* from V_ERP_IsUsedMaterial a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtItem.Text.Trim()))
            {
                pgr1.Whrs.Add("a.MaterialNo = @" + (idx++).ToString());
                pgr1.PrmsData.Add(txtItem.Text.Trim());
            }
            pgr1.OrderBy = "Order By a.Id desc";
            pgr1.BindPageData();
        }

        private void gvStckItem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockMaterial>();
            if (null == ds || ds.Count < 1) return;
            if (e.Column.FieldName == "CostPrice" || e.Column.FieldName == "Num")
            {
                var nt = gvStckItem.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMaterial>();
                if (nt.CostPrice <= 0 || nt.Num <= 0)
                {
                    MsgBox.ShowMessage("成本价或者数量的值不能小于0!");
                    return;
                }
                nt.AllCostPrice = nt.CostPrice * nt.Num;
                gcStckItem.DataSource = ds;
                gcStckItem.RefreshDataSource();
            }
        }

    }
}
