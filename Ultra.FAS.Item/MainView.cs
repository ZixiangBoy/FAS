using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.CoreCaller;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Web.Core.Common;
using Ultra.FASControls.Extend;
using Ultra.Xls;
using UltraDbEntity;
using Ultra.Plugins;
using DevExpress.XtraEditors;
using Ultra.FASControls;

namespace Ultra.FAS.Item
{
    public partial class MainView : MainStdView, ISurfacePermission {
        public MainView() {
            InitializeComponent();
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem> {
                this.barBtnNew,this.barBtnEdt,this.barBtnImport,
                //this.barBtnAudit,
                this.barBtnEnable,this.barBtnDisable,this.barBtnInvalid,barBtnExportXls
            };
            }
        }

        public List<Control> ButtonItems {
            get { 
                return new List<Control> { 
                    this.btnAdd,this.btnEdt,this.btnDel,this.btnImp
                }; 
            }
        }

        public List<Control> MenuItems {
            get { return null; }
        }

        public List<PermitGridView> Grids {
            get
            {
                return new List<PermitGridView>
                {
                    new PermitGridView(this.gvaudit,"系统商品")
                    ,new PermitGridView(this.gvInvalid,"作废商品")
                    ,new PermitGridView(this.gvauditprop,"商品属性")
                    ,new PermitGridView(this.gvprice,"成本折损")
                };
            }
        }

        public List<BaseSurface> DialogForms {
            get { return null; }
        }

        EFCaller<UltraDbEntity.T_ERP_Item> Calr { get; set; }
        EFCaller<UltraDbEntity.T_ERP_ItemCombo> ItemCmbCalr { get; set; }
        EFCaller<UltraDbEntity.T_ERP_ItemImports_FullBak> ItemImportsFullBakCalr { get; set; }


        private void MainView_Load(object sender, EventArgs e) {
            Calr = SerNoCaller_WL.Calr_Item;
            ItemCmbCalr = SerNoCaller_WL.Calr_ItemCombo;
            ItemImportsFullBakCalr = SerNoCaller_WL.Calr_ItemImports_FullBak;
            this.barBtnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnImport.ItemClick += barBtnImport_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnEnable.ItemClick += barBtnEnable_ItemClick;
            this.barBtnDisable.ItemClick += barBtnDisable_ItemClick;
            this.barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            this.barBtnAudit.ItemClick += barBtnAudit_ItemClick;

            this.itmpgr1.Caller = this.pgr.Caller =
            this.itemPager1.Caller = Calr;
            tbMain_SelectedPageChanged(null, null);
            txtitmname.KeyUp += (s1, e1) => {
                if (e1.KeyCode == Keys.Enter)
                    barBtnRefresh_ItemClick(null, null);
            };
        }

        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UltraDbEntity.T_ERP_Item et = null;
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    et = gc.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
                case "已审核":
                case "系统商品":
                    et = gvaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
            }
            if (null == et) return;
            if (et.IsAudit) return;
            et.IsAudit = true; et.Updator = this.CurUser;
            var rd = Calr.EdtPart(et, "IsAudit", "Updator");
            if (!rd.IsOK) { MsgBox.ShowErrMsg(rd.ErrMsg); return; }
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    gc.RemoveSelected();
                    gc.RefreshDataSource();
                    break;
                case "已审核":
                case "系统商品":
                    gcaudit.RemoveSelected();
                    gcaudit.RefreshDataSource();
                    break;
            }
            
        }

        void barBtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new ExpSysItemView();
            vw.Visible = false;
            vw.DoExport();
        }

        //作废
        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UltraDbEntity.T_ERP_Item et = null;
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    et = gc.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
                case "已审核":
                case "系统商品":
                    et = gvaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
            }
            if (null == et) return;
            if (et.IsInvalid) return;
            if (MsgBox.ShowYesNoMessage("确定要作废此商品吗?") == System.Windows.Forms.DialogResult.No)
                return;
            et.IsInvalid = true; et.Updator = this.CurUser;
            var rd = Calr.EdtPart(et, "IsInvalid", "Updator");
            if (!rd.IsOK) { MsgBox.ShowErrMsg(rd.ErrMsg); return; }
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    gc.RemoveSelected();
                    gc.RefreshDataSource();
                    break;
                case "已审核":
                case "系统商品":
                    gcaudit.RemoveSelected();
                    gcaudit.RefreshDataSource();
                    break;
            }
        }

        //禁用
        void barBtnDisable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            if (null == et) return;
            if (!et.IsUsing) return;
            if (MsgBox.ShowYesNoMessage("确定要禁用此商品吗?") == System.Windows.Forms.DialogResult.No)
                return;
            et.IsUsing = false; et.Updator = this.CurUser;
            var rd = Calr.EdtPart(et, "IsUsing", "Updator");
            if (!rd.IsOK) { MsgBox.ShowErrMsg(rd.ErrMsg); return; }
            gcaudit.RefreshDataSource();
        }

        //启用
        void barBtnEnable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            if (null == et) return;
            if (et.IsUsing) return;
            et.IsUsing = true; et.Updator = this.CurUser;
            var rd = Calr.EdtPart(et, "IsUsing", "Updator");
            if (!rd.IsOK) { MsgBox.ShowErrMsg(rd.ErrMsg); return; }
            gcaudit.RefreshDataSource();
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UltraDbEntity.T_ERP_Item et = null;
            switch (tbMain.SelectedTabPage.Text) {
                case "未审核":
                    et = gc.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
                case "已审核":
                case "系统商品":
                    et = gvaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
            }
            if (null == et) return;
            var vw = new ItemEdt();
            vw.Calr = this.Calr;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            vw.Ent = et;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                gcaudit.RefreshDataSource();
        }

        void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var iv = new IptItemView();
            InitView(iv); iv.btnOK.Visible = iv.btnOK.Enabled = false;
            iv.ShowDialog();
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new ItemEdt();
            InitView(vw);
            vw.Calr = this.Calr;
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            vw.ShowDialog();
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (tbMain.SelectedTabPage.Text) {
                case "未审核":
                    UnAudit();
                    break;
                case "已审核":
                case "系统商品":
                    Audit();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
        }

        void UnAudit() {
            itmpgr1.CurrentPage = 1;
            itmpgr1.Whrs.Clear(); itmpgr1.PrmsData.Clear();
            itmpgr1.PrefixWhr = "select a.* from [V_ERP_UnAuditItem] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtitmname.Text.Trim())) {
                itmpgr1.Whrs.Add("a.ItemName like @" + (idx++).ToString());
                itmpgr1.PrmsData.Add("%" + txtitmname.Text.Trim() + "%");
            }

            itmpgr1.OrderBy = "Order By a.ItemName";
            itmpgr1.BindPageData();
        }

        void Audit() {
            itemPager1.CurrentPage = 1;
            itemPager1.Whrs.Clear(); itemPager1.PrmsData.Clear();
            itemPager1.PrefixWhr = "select a.* from [V_ERP_AuditItem] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtitmname.Text.Trim())) {
                itemPager1.Whrs.Add("a.ItemName like @" + (idx++).ToString());
                itemPager1.PrmsData.Add("%" + txtitmname.Text.Trim() + "%");
            }

            itemPager1.OrderBy = "Order By a.ItemName";
            itemPager1.BindPageData();
        }

        void Invalid() {
            pgr.CurrentPage = 1;
            pgr.Whrs.Clear(); pgr.PrmsData.Clear();
            pgr.PrefixWhr = "select a.* from [V_ERP_InvalidItem] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtitmname.Text.Trim())) {
                pgr.Whrs.Add("a.ItemName like @" + (idx++).ToString());
                pgr.PrmsData.Add("%" + txtitmname.Text.Trim() + "%");
            }

            pgr.OrderBy = "Order By a.ItemName";
            pgr.BindPageData();
        }

       

        private void txtitmname_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                barBtnRefresh_ItemClick(sender, null);
        }

        private void gvaudit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            
            UltraDbEntity.T_ERP_Item et = null;
            switch (tbMain.SelectedTabPage.Text) {
                case "未审核":
                    et = gc.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
                case "已审核":
                case "系统商品":
                    et = gvaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
                case "已作废":
                    et = gcInvalid.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
                    break;
            }
            ShowInfo(et);
        }

        void ShowInfo(UltraDbEntity.T_ERP_Item et) {
            if (null == et) return;
            gcauditprop.DataSource = new List<T_ERP_ItemStyleProp> { T_ERP_ItemStyleProp.GetProps(et) };
            spframepackpostfee.SetValue(et.FramePackagePostFee);
            spframeprice.SetValue(et.FramePrice);
            spframevolume.SetValue(et.FrameVolume);
            sphei.SetValue(et.Height);
            splen.SetValue(et.Length);
            sppackpostfee.SetValue(et.PackagePostFee);
            spvolume.SetValue(et.Volume);
            spwid.SetValue(et.Width);
            gcprice.DataSource = FASControls.SerNoCaller_WL.Calr_WreckPrice.Get(" where ItemGuid=@0 and isnull(IsDel,0) = 0 ", et.Guid);
        }

        private void tbMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            switch (tbMain.SelectedTabPage.Text) {
                case "未审核":
                    this.barBtnNew.Enabled = true;
                    this.barBtnEdt.Enabled = true;
                    //this.barBtnAudit.Enabled = true;
                    this.barBtnEnable.Enabled = false;
                    this.barBtnDisable.Enabled = false;
                    this.barBtnInvalid.Enabled = true;
                    //this.barBtnImport.Enabled = true;
                    break;
                case "已审核":
                case "系统商品":
                    this.barBtnNew.Enabled = true;
                    this.barBtnEdt.Enabled = true;
                    //this.barBtnAudit.Enabled = false;
                    this.barBtnEnable.Enabled = true;
                    this.barBtnDisable.Enabled = true;
                    this.barBtnInvalid.Enabled = true;
                    this.barBtnImport.Enabled = true;
                    break;
                case "已作废":
                    this.barBtnNew.Enabled = false;
                    this.barBtnEdt.Enabled = false;
                    //this.barBtnAudit.Enabled = false;
                    this.barBtnEnable.Enabled = false;
                    this.barBtnDisable.Enabled = false;
                    this.barBtnInvalid.Enabled = false;
                    this.barBtnImport.Enabled = false;
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var et = gvaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            if (null == et) return;
            var vw = new EdtPrice();
            InitView(vw);
            vw.Item = et;
            vw.ExistsRng = gcprice.GetDataSource<UltraDbEntity.T_ERP_WreckPrice>();
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gvaudit_FocusedRowChanged(null, null);
            }
        }

        private void btnEdt_Click(object sender, EventArgs e)
        {
            var et = gvaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            var dt = gvprice.GetFocusedDataSource<UltraDbEntity.T_ERP_WreckPrice>();
            if (null == dt) return;
            if (null == et) return;
            var vw = new EdtPrice();
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            InitView(vw);
            vw.Item = et;
            vw.Ent = dt.Copy();
            vw.ExistsRng = gcprice.GetDataSource<UltraDbEntity.T_ERP_WreckPrice>().ToList();
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dt = vw.Ent;
                gvaudit_FocusedRowChanged(null, null);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var et = gvaudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            var dt = gvprice.GetFocusedDataSource<UltraDbEntity.T_ERP_WreckPrice>();
            if (null == dt) return;
            if (null == et) return;
            if (MsgBox.ShowYesNoMessage(string.Empty, "确定要删除?") == System.Windows.Forms.DialogResult.No)
                return;
            dt.IsDel = true;
            FASControls.SerNoCaller_WL.Calr_WreckPrice.Del(dt);
            gvaudit_FocusedRowChanged(null, null);
        }

        private void btnImp_Click(object sender, EventArgs e)
        {
            var vw = new WreckPriceIptView();
            vw.WindowState = FormWindowState.Maximized;
            vw.ShowDialog();
        }

    }

}
