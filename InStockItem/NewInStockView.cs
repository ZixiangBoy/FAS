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

namespace FAS.InStockItem {
    public partial class NewInStockView : DialogViewEx {

        public string InStockNo { get; set; }
        public NewInStockView() {
            InitializeComponent();
        }

        private void LoadData() {
            InStockNo = SerNoCaller.GetSerNo("入库单").SerialNo;
            rspItem.DataSource = SerNoCaller.Calr_Item.Get(" where isdel=0 and isusing=1");
            var maters = SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%皮%' ");
            rspItem.DataSource = new Ultra.FASControls.BusControls.ItemGridEdit().LoadFromCache();// SerNoCaller.Calr_Item.Get(" where isdel=0 and isusing=1");
            rspSurface.DataSource = maters.Where(k => k.MaterialName.Contains("真皮") && !k.MaterialName.Contains("仿真")).ToList();
            //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache("where isusing=1 and MaterialName like '%真皮%' and MaterialName not like '%仿真%'"); //SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%真皮%' and MaterialName not like '%仿真%' ");
            rspImitSurface.DataSource = maters.Where(k => k.MaterialName.Contains("仿皮")).ToList();
            //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache("where isusing=1 and MaterialName like '%仿皮%'");// SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%仿皮%' ");
            rspGenSurface.DataSource = maters.Where(k => k.MaterialName.Contains("仿真")).ToList();
            //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache(" where isusing=1 and MaterialName like '%仿真%' ");// SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%仿真%' ");
            rspEnvSurface.DataSource = maters.Where(k => k.MaterialName.Contains("环保")).ToList();
            //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache(" where isusing=1 and MaterialName like '%环保%'");// SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%环保%' ");
            rspTradeMark.DataSource = new Ultra.FASControls.BusControls.TradeMarkGridEdt().LoadFromCache();// SerNoCaller.Calr_TradeMark.Get(" where isusing=1 ");
        }

        void rspNum_Validating(object sender, CancelEventArgs e) {
            var rsp = sender as SpinEdit;
            if (rsp.Value < 1) {
                e.Cancel = true;
            }
        }

        void rspItem_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var item = view.GetFocusedDataSource<T_ERP_Item>();
            if (item == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;
            odr.ItemName = item.ItemName;
            odr.SkuName = item.SkuName;
            odr.OuterIid = item.OuterIid;
            odr.OuterSkuId = item.OuterSkuId;
            odr.Num = 1;
            odr.Color = item.Color;
            odr.Material = item.Material;
            odr.Surface = item.Surface;
            odr.SurfaceNums = item.SurfaceNums;
            odr.IsDynamicAdd = true;
            gcOrder.RefreshDataSource();
        }

        private void btnAddItem_Click(object sender, EventArgs e) {
            var odr = new T_ERP_ItemInStock();
            odr.Guid = Guid.NewGuid();
            odr.InStockNo = InStockNo;
            odr.Creator = odr.Updator = this.CurUser;
            odr.Reserved2 = odr.Remark = string.Empty;

            var odrs = gcOrder.GetDataSource<T_ERP_ItemInStock>();
            odrs = odrs ?? new List<T_ERP_ItemInStock>();

            odrs.Add(odr);

            gcOrder.RefreshDataSource();
        }

        private void btnDelItem_Click(object sender, EventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;

            var odrs = gcOrder.GetDataSource<T_ERP_ItemInStock>();
            odrs = odrs ?? new List<T_ERP_ItemInStock>();

            odrs.Remove(odr);
            gcOrder.RefreshDataSource();
        }



        private void btnOK_Click(object sender, EventArgs e) {
            var odrs = gcOrder.GetDataSource<T_ERP_ItemInStock>();
            odrs = odrs ?? new List<T_ERP_ItemInStock>();


            var inodrs = odrs.Where(k => k.Num > 0).ToList();

            if (inodrs == null || inodrs.Count < 1) return;

            if (inodrs.Any(k => string.IsNullOrEmpty(k.LocName))) {
                MsgBox.ShowErrMsg("必须选择入库库位!");
                return;
            }

            var instock = new T_ERP_InStockEx {
                InStockNo = this.InStockNo,
                Creator = this.CurUser,
                Updator = this.CurUser,
                Remark = txtRemark.Text,
                Reserved2 = string.Empty,
                TotalNum = inodrs.Sum(k => k.Num),
                Guid = Guid.NewGuid()
            };
            inodrs.ForEach(k => {
                k.InStockNo = instock.InStockNo;
                k.Guid = Guid.NewGuid();
            });
            var rd = SerNoCaller.Calr_ItemInStock.Add(inodrs);
            if (rd.IsOK) {
                rd = SerNoCaller.Calr_InStockEx.Add(instock);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void rspInStockNum_Validating(object sender, CancelEventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;

            var rsp = sender as SpinEdit;
            if (odr.Num < rsp.Value) {
                e.Cancel = true;
            }
        }

        private void NewInStockView_Load(object sender, EventArgs e) {
            gcOrder.DataSource = new List<T_ERP_ItemInStock>();
            rspLoc.DataSource = SerNoCaller.Calr_WareLoc.Get();
            LoadData();
        }

        private void rspLoc_EditValueChanged(object sender, EventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;

            var rsp = sender as GridLookUpEdit;
            var view = rsp.Properties.View;

            var loc = view.GetFocusedDataSource<T_ERP_WareLoc>();
            if (loc == null) return;


            odr.WareName = loc.WareName;
            odr.LocName = loc.LocName;
            odr.AreaName = loc.AreaName;

            gcOrder.RefreshDataSource();
        }

        private void rspSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;
            odr.Surface = mater.MaterialName;
            odr.SurfaceNums = mater.MaterialNo;
            gcOrder.RefreshDataSource();
        }

        private void rspImitSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;
            odr.ImitSurface = mater.MaterialName;
            odr.ImitSurfaceNums = mater.MaterialNo;
            gcOrder.RefreshDataSource();
        }

        private void rspGenSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;
            odr.GenuineSurface = mater.MaterialName;
            odr.GenuineSurfaceNums = mater.MaterialNo;
            gcOrder.RefreshDataSource();
        }


        private void rspEnvSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;
            odr.EnvSurface = mater.MaterialName;
            odr.EnvSurfaceNums = mater.MaterialNo;
            gcOrder.RefreshDataSource();
        }

        private void rspTradeMark_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var tm = view.GetFocusedDataSource<T_ERP_TradeMark>();
            if (tm == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_ItemInStock>();
            if (odr == null) return;
            odr.TradeMark = tm.TradeMark;
            gcOrder.RefreshDataSource();
        }
    }
}
