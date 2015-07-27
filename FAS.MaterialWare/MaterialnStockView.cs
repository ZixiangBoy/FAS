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
using Ultra.Surface.Common;
using Ultra.FASControls;
using Ultra.FASControls.Caller;
using Ultra.FASControls.Extend;


namespace FAS.MaterialWare
{
    public partial class MaterialnStockView : MainSurface, ISurfacePermission
    {
        public MaterialnStockView()
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
                return new List<PermitGridView> {
                new PermitGridView(gvUnAudit,"未审核"),                
                new PermitGridView(gvAudit,"已审核"),
                new PermitGridView(gvDel,"已作废"),
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
                this.barBtnNew,this.barBtnRefresh,this.barBtnInvalid                
                ,this.barBtnAudit,this.barBtnEdt
            };
            }
        }

        private void MaterialnStockView_Load(object sender, EventArgs e)
        {
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;            
            this.barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            pgr1.Caller = pgr2.Caller = pgr3.Caller =SerNoCaller_GC.Calr_InStockMatMaster;
            tbMain_SelectedPageChanged(null, null);
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMatMaster>();
            if (null == et) return;
            var vw = new MaterialInStockAdd();
            vw.Ent = et;
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMatMaster>();
            if (null == et) return;
            var rd = SerNoCaller_GC.Calr_InStockMatMaster.GetByProc("exec P_ERP_NAuditMaterialInStock @0,@1,@2", et.InStockNo, this.CurUser,Guid.NewGuid()).FirstOrDefault();
            if (rd != null && rd.IsAudit)
            {
                gcUnAudit.RemoveSelected();
            }

            barBtnRefresh_ItemClick(null, null);
        }

        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMatMaster>();
            if (null == et) return;
            var vw = new Ultra.FASControls.Views.InvalidReasonView();
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                et.InvalidRemark = vw.Reason;
                et.Invalider = CurUser;
                //作废操作
                var rd = SerNoCaller.Calr_PackInStock.ExecSql("exec P_ERP_InvalidMateriaInStock @0,@1,@2",
                      et.InStockNo, CurUser, et.InvalidRemark);
                if (!rd.IsOK)
                {
                    MsgBox.ShowErrMsg(rd.ErrMsg);
                    return;
                }
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    UnAudit();
                    break;
                case "已审核":
                    Audit();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
            gvUnAudit_FocusedRowChanged(null, null);
        }

        void UnAudit()
        {
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear(); pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select a.* from V_ERP_UNInStockMaterial a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtinstckno.Text.Trim()))
            {
                pgr1.Whrs.Add("a.InStockNo = @" + (idx++).ToString());
                pgr1.PrmsData.Add(txtinstckno.Text.Trim());
            }
            pgr1.OrderBy = "Order By a.Id desc";
            pgr1.BindPageData();
        }

        void Audit()
        {
            pgr2.CurrentPage = 1;
            pgr2.Whrs.Clear(); pgr2.PrmsData.Clear();
            pgr2.PrefixWhr = "select a.* from V_ERP_InStockMaterial a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtinstckno.Text.Trim()))
            {
                pgr2.Whrs.Add("a.InStockNo = @" + (idx++).ToString());
                pgr2.PrmsData.Add(txtinstckno.Text.Trim());
            }
            pgr2.OrderBy = "Order By a.Id desc";
            pgr2.BindPageData();
        }

        void Invalid()
        {
            pgr3.CurrentPage = 1;
            pgr3.Whrs.Clear(); pgr3.PrmsData.Clear();
            pgr3.PrefixWhr = "select a.* from V_ERP_InStockDelMaterial a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtinstckno.Text.Trim()))
            {
                pgr3.Whrs.Add("a.InStockNo = @" + (idx++).ToString());
                pgr3.PrmsData.Add(txtinstckno.Text.Trim());
            }
            pgr3.OrderBy = "Order By a.Id desc";
            pgr3.BindPageData();
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new MaterialInStockAdd();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }
        private void gvUnAudit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UltraDbEntity.T_ERP_InStockMatMaster et = null;
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMatMaster>();
                    break;
                case "已审核":
                    et = gcAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMatMaster>();
                    break;
                case "已作废":
                    et = gcDel.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockMatMaster>();
                    break;
                default:
                    break;
            }
            GetDetail(et);
        }

        private void GetDetail(UltraDbEntity.T_ERP_InStockMatMaster et)
        {
            if (null == et)
            {
                gcLog.DataSource = null;
                gcItem.DataSource = null;
                return;
            }
            gcItem.DataSource = SerNoCaller_GC.Calr_InStockMaterial.Get("where InStockNo=@0", et.InStockNo);
            gcLog.DataSource = SerNoCaller.Calr_Log.Get("where TradeNo=@0 order by id", et.InStockNo);
        }

        private void tbMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    this.barBtnNew.Enabled = true;
                    this.barBtnAudit.Enabled = true;
                    this.barBtnInvalid.Enabled = true;
                    this.barBtnEdt.Enabled = true;
                    break;
                case "已审核":
                    this.barBtnNew.Enabled = false;
                    this.barBtnAudit.Enabled = false;
                    this.barBtnInvalid.Enabled = false;
                    this.barBtnEdt.Enabled = false;
                    break;
                case "已作废":
                    this.barBtnNew.Enabled = false;
                    this.barBtnAudit.Enabled = false;
                    this.barBtnInvalid.Enabled = false;
                    this.barBtnEdt.Enabled = false;
                    break;
            }
        }
    }
}
