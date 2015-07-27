using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Surface.Lanuch;
using Ultra.FASControls;
using Ultra.FASControls.Extend;
using UltraDbEntity;
using Ultra.Common;
using Ultra.Win.Core.Common;
using Ultra.Surface.Common;
using PetaPoco;

namespace Ultra.FAS.Procedure
{
    public partial class ItemMaterials : MainSurface, ISurfacePermission
    {
        public ItemMaterials()
        {
            InitializeComponent();
        }

        public List<Control> ButtonItems
        {
            get { return null; }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        public List<PermitGridView> Grids
        {
            get
            {
                return new List<PermitGridView>
                {
                    new PermitGridView(gvItem,"商品信息"),
                    new PermitGridView(gvMaterial,"用料信息")
                };
            }
        }

        public List<Control> MenuItems
        {
            get { return null; }
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                    this.barBtnRefresh,
                    this.barBtnExportXls
                };
            }
        }

        private void ItemPrice_Load(object sender, EventArgs e)
        {
            this.barBtnExport.Enabled = true;
            this.barBtnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barBtnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barBtnImport.ItemClick += barBtnImport_ItemClick;
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
            itemPager1.Caller = FASControls.SerNoCaller_WL.Calr_Item;
        }

        void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new MaterialsImptView();
            vw.WindowState = FormWindowState.Maximized;
            vw.ShowDialog();
        }

        void barBtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new FASControls.Views.ExportDataView();
            vw.ExportDataTable(@"select OuterIid 商品编码,OuterSkuId 规格编码,ProcedureName 工序,MaterialNo 原材料编码
,MaterialName 原材料名称,Dosage 用量,Unit 单位 from T_ERP_ProduceDosage"); 
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            itemPager1.CurrentPage = 1;
            itemPager1.Whrs.Clear(); itemPager1.PrmsData.Clear();
            itemPager1.PrefixWhr = "select a.* from [V_ERP_AuditItem] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtOuterIid.Text.Trim()))
            {
                itemPager1.Whrs.Add("a.OuterIid like @" + (idx++).ToString());
                itemPager1.PrmsData.Add("%" + txtOuterIid.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtOuterSkuId.Text.Trim()))
            {
                itemPager1.Whrs.Add("a.OuterSkuId like @" + (idx++).ToString());
                itemPager1.PrmsData.Add("%" + txtOuterSkuId.Text.Trim() + "%");
            }

            itemPager1.OrderBy = "Order By a.ItemName";
            itemPager1.BindPageData();
        }

        private void btnEdt_Click(object sender, EventArgs e)
        {
            var et = gvItem.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            var dt = gvMaterial.GetDataSource<UltraDbEntity.T_ERP_ProduceDosage>();
            if (null == et) return;
            var vw = new EdtMaterials();
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            InitView(vw);
            vw.Item = et;
            vw.ExistsRng = dt;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gvItem_FocusedRowChanged(null, null);
            }
        }

        private void gvItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var et = gvItem.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            if (null == et)
            {
                gcMaterial.DataSource = null;
                return;
            }
            
            var dosage = FASControls.SerNoCaller_WL.Calr_ProduceDosage.Get(" where ItemGuid=@0 ", et.Guid);
            dosage.ForEach(j => j.Reserved2 = j.Dosage.ToString()+" "+j.Unit);
            gcMaterial.DataSource = dosage;
        }
    }
}
