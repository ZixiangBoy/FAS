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
using Ultra.FASControls.Extend;
using Ultra.Common;
using Ultra.Surface.Common;
using System.IO;
using Ultra.Surface.Lanuch;
using MoreLinq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using Ultra.FASControls;

namespace Ultra.WareHouseEx
{
    public partial class InStockAdd : DialogViewEx
    {
        public InStockAdd()
        {
            InitializeComponent();
        }

        List<UltraDbEntity.T_ERP_WareLoc> CacheLoc;
        public UltraDbEntity.T_ERP_InStock Ent { get; set; }

        void ShowViewMode()
        {
            this.gridColumn8.ColumnEdit = null;
            pgr.Visible = pgr.Enabled = false;
            btnDelItem.Visible = false;

            btnCtl1.Visible = false;
            txtItem.Enabled = txtSku.Enabled = false;
            btnOK.Visible = btnOK.Enabled = false;
            gvStckItem.OptionsBehavior.Editable = false;
            if (null == Ent) return;
            gcStckItem.DataSource = SerNoCaller.Calr_InStockItem.Get("where Session=@0", Ent.ItemSession);

        }

        private void StockAddView_Load(object sender, EventArgs e)
        {
            //rspSuppName.DataSource = SerNoCaller.Calr_Supplier.Get(" where IsDel=0 and IsUsing=1 ");//供应商
            gvStckItem.OptionsView.ShowAutoFilterRow = false;
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

            if (EditMode == Business.Core.Define.EnViewEditMode.View)
            {
                ShowViewMode();
                return;
            }
            pgr.Caller = SerNoCaller.Calr_Item;
            if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                ShowViewEdtMode();
            }
            tbMain_SelectedPageChanged(null, null);
        }

        void ShowViewEdtMode()
        {
            if (null == Ent) return;
            gcStckItem.DataSource = SerNoCaller.Calr_InStockItem.Get("where Session=@0", Ent.ItemSession);
        }

        private void btnCtl1_Click(object sender, EventArgs e)
        {
            pgr.CurrentPage = 1;
            pgr.Whrs.Clear(); pgr.PrmsData.Clear();
            pgr.PrefixWhr = "select a.* from [V_ERP_InStockSuppItem] a";
            int idx = 0;

            if (!string.IsNullOrEmpty(txtItem.Text.Trim()))
            {
                if (txtItem.IsContainChinese)//包含中文
                {
                    pgr.Whrs.Add("ItemName like @" + (idx++).ToString());
                    pgr.PrmsData.Add("%" + txtItem.Text.Trim() + "%");
                }
                else
                {
                    var fc = txtItem.GetFullCode();
                    if (null == fc)
                    {
                        pgr.Whrs.Add("ItemName like @" + (idx++).ToString());
                        pgr.PrmsData.Add("%" + txtItem.Text.Trim() + "%");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(fc.OuterIid))
                        {
                            pgr.Whrs.Add("OuterIid=@" + (idx++).ToString());
                            pgr.PrmsData.Add(fc.OuterIid);
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtSku.Text))
            {
                var idv = (idx++);
                pgr.Whrs.Add("(SkuProperties like @" + (idv).ToString() +
                    " or OuterSkuId like @" + idv.ToString() + ")");
                pgr.PrmsData.Add("%" + txtSku.Text.Trim() + "%");

            }
            pgr.OrderBy = "Order By ItemName,SkuProperties";
            pgr.BindPageData();
        }

        private void gcItem_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var ett = gcItem.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            var et = ett.MapTo<UltraDbEntity.T_ERP_Item, UltraDbEntity.T_ERP_InStockItem>();
            if (null == et) return;
            var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockItem>(); //T_ERP_Item
            ds = ds ?? new List<UltraDbEntity.T_ERP_InStockItem>();
            var mch = ds.Where(j => j.OuterIid == et.OuterIid && j.OuterSkuId == et.OuterSkuId).FirstOrDefault();
            if (null != mch) mch.Num += 1;
            else
            {
                ds.Insert(0, et);
            }

            gcStckItem.DataSource = ds;
            gcStckItem.RefreshDataSource();


            //var et = gcItem.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            //if (null == et) return;
            //var jt = et.MapTo<UltraDbEntity.T_ERP_Item, UltraDbEntity.T_ERP_InStockItem>();
            //jt.SuppName = jt.SuppName; //jt.Reserved2;
            //jt.Num = 1;
            //jt.Reserved3 = true;
            //var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockItem>();
            //ds = ds ?? new List<UltraDbEntity.T_ERP_InStockItem>();
            //ds.Insert(0, jt);
            //gcStckItem.DataSource = ds;
            //gcStckItem.RefreshDataSource();
        }



        private void btnDelItem_Click(object sender, EventArgs e)
        {
            var et = gcStckItem.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockItem>();
            if (null == et) return;
            gcStckItem.RemoveSelected();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var dt = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockItem>();
            if (null == dt || dt.Count < 1)
            {
                MsgBox.ShowErrMsg("必须包含入库商品!");
                return;
            }
            var c = dt.Where(j => string.IsNullOrEmpty(j.WareName) || string.IsNullOrEmpty(j.AreaName) ||
                 string.IsNullOrEmpty(j.LocName)).Count();
            if (c > 0)
            {
                MsgBox.ShowErrMsg("必须为所有商品都分配上库位,请检查商品库位!");
                return;
            }
            var cot = dt.Where(j => j.Reserved3 == true && j.Num > 0).ToList().Count;
            if (cot < 1)
            {
                MsgBox.ShowErrMsg("必须勾选要入库的商品且入库数量不能小于1!");
                return;
            }
            dt = dt.Where(j => j.Num > 0).ToList();
            var itmSession = Guid.NewGuid();
            var sumPck = 0; var sumVol = (decimal)0.00; var sumNum = 0L;

            //创建商品集合
            dt.ForEach(j =>
            {
                j.Creator = this.CurUser; j.Updator = this.CurUser;
                j.Reserved1 = 0; j.Reserved2 = string.Empty;
                j.Guid = Guid.NewGuid();
                j.Session = itmSession;
                sumPck += j.PackageCount == null ? 0 : j.PackageCount.Value;
                sumVol += j.Volume == null ? 0 : j.Volume.Value;
                sumNum += j.Num;
                j.Remark = j.Remark == null ? "" : j.Remark;
            });

            var rd = SerNoCaller.Calr_InStockItem.Add(dt);
            if (!rd.IsOK)
            {
                MsgBox.ShowErrMsg(rd.ErrMsg); return;
            }
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {

                Ent = SerNoCaller.Calr_InStock.GetByProc("exec P_ERP_NewInStock @0,@1,@2,@3,@4,@5,@6"
                    , this.CurUser, itmSession, dt.FirstOrDefault().OuterNo, sumPck, sumVol, sumNum, dt.FirstOrDefault().PurchNo)
                    .FirstOrDefault();

                if (Ent == null)
                {
                    MsgBox.ShowErrMsg("创建入库单失败!"); return;
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

        private void gvStckItem_ShownEditor(object sender, EventArgs e)
        {

        }
        private void gcStckItem_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            btnDelItem_Click(null, null);
        }

        private void tbMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
                    btnDelItem.Visible = true;
                    gridColumn19.Visible = false;
                    lab2.Visible = true;
                    panelControl1.Visible = true;
                    gcStckItem.DataSource = null;
        }

        private void gvStckItem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "OuterNo")
            {
                var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockItem>();
                ds.ForEach(j => j.OuterNo = e.Value.ToString());
                gcStckItem.DataSource = ds;
                gcStckItem.RefreshDataSource();
            }
            if (e.Column.FieldName == "BuyerNick")
            {
                var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockItem>();
                ds.ForEach(j => j.BuyerNick = e.Value.ToString());
                gcStckItem.DataSource = ds;
                gcStckItem.RefreshDataSource();
            }
        }

        private void gvStckItem_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var ds = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockItem>();
            if (null == ds || ds.Count < 1) return;
            if (e.Column.FieldName == "LocName")
            {
                var et = CacheLoc.FirstOrDefault(j => j.LocName == e.Value.ToString());
                var nt = gvStckItem.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockItem>();
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
    }
}
