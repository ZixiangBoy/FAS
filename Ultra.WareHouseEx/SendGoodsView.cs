using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.FASControls.Extend;
using Ultra.FASControls;
using UltraDbEntity;
using Ultra.Win.Core.Common;

namespace Ultra.WareHouseEx
{
    public partial class SendGoodsView : MainSurface, ISurfacePermission
    {
        public SendGoodsView()
        {
            InitializeComponent();
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                this.barBtnNew,this.barBtnInvalid,this.barBtnAudit
                ,this.barBtnEdt,this.barBtnPrint,this.barBtnRePrint
            };
            }
        }

        public List<Control> ButtonItems
        {
            get { return null; }
        }

        public List<Control> MenuItems
        {
            get { return null; }
        }

        public List<PermitGridView> Grids
        {
            get
            {
                return new List<PermitGridView> { 
                new PermitGridView(gvUnAudit,"未审核"),
                new PermitGridView(gvPrint,"已打印"),
                new PermitGridView(gvAudit,"已审核"),
                new PermitGridView(gvInvalid,"已作废"),
            };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        private void IvtAdjView_Load(object sender, EventArgs e)
        {
            pgrUnAudit.Caller = pgrAudit.Caller = pgrInvalid.Caller = pgrPrint.Caller = SerNoCaller_WL.Calr_Delivery;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnPrint.ItemClick += barBtnPrint_ItemClick;
            this.barBtnRePrint.ItemClick += barBtnRePrint_ItemClick;
            foreach (Control c in pnlquery.Controls)
                c.KeyUp += (s1, e1) =>
                {
                    if (e1.KeyCode == Keys.Enter)
                        barBtnRefresh_ItemClick(null, null);
                };

            gcUnAudit.PopupTextFields.Add("Remark");
            gcPrint.PopupTextFields.Add("Remark");
            gcAudit.PopupTextFields.Add("Remark");
            gcInvalid.PopupTextFields.Add("Remark");
            gcInvalid.PopupTextFields.Add("InvalidRemark");
            tbMain_SelectedPageChanged(null, null);
        }

        void barBtnRePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ets = gcPrint.GetSelectedDataSource<UltraDbEntity.T_ERP_Delivery>();
            var vw = new PrintView();
            vw.Deliverys = ets;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MsgBox.ShowMessage("打印成功");
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ets = gcUnAudit.GetSelectedDataSource<UltraDbEntity.T_ERP_Delivery>();
            var vw = new PrintView();
            vw.Deliverys = ets;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ets.ForEach(j =>
                {
                    j.IsPrinted = true;
                    j.PrintTime = TimeSync.Default.CurrentSyncTime;
                    j.PrintUser = this.CurUser;
                });
                FASControls.SerNoCaller_WL.Calr_Delivery.BatchEdt(ets);
                MsgBox.ShowMessage("打印成功");
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new SendGoodsEdt();
            UltraDbEntity.T_ERP_Delivery et = null;
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Delivery>();
                    vw.isAudit = false;
                    break;
                case "已打印":
                    et = gcPrint.GetFocusedDataSource<UltraDbEntity.T_ERP_Delivery>();
                    vw.isAudit = false;
                    break;
                case "已审核":
                    et = gcAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Delivery>();
                    vw.isAudit = true;
                    break;
            }
            if (null == et) return;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            vw.Delivery = et;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        //审核
        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcPrint.GetFocusedDataSource<UltraDbEntity.T_ERP_Delivery>();
            if (null == et) return;
            if (MsgBox.ShowYesNoMessage("确定要审核此出库单吗？") != DialogResult.Yes) return;
            var kt = SerNoCaller_WL.Calr_Delivery.GetByProc("exec P_ERP_AuditDelivery @0,@1", et.SendNo, this.CurUser)
                .FirstOrDefault();
            if (kt.IsAudit)
                gcUnAudit.RemoveSelected();
            else
                MsgBox.ShowErrMsg(kt.Remark);

            gcUnAudit.RefreshDataSource();
        }

        //刷新
        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    UnAudit();
                    break;
                case "已打印":
                    Print();
                    break;
                case "已审核":
                    Audit();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
        }

        //作废
        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            T_ERP_Delivery et = null;
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_Delivery>();
                    break;
                case "已打印":
                    et = gcPrint.GetFocusedDataSource<UltraDbEntity.T_ERP_Delivery>();
                    break;
            }
            if (null == et) return;
            var vw = new InvalidSendGoods();
            vw.Ent = et;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (vw.Ent.IsInvalid)
                    gcUnAudit.RemoveSelected();
            }
            return;
        }

        //新增
        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new SendGoodsEdt();
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void UnAudit()
        {
            pgrUnAudit.CurrentPage = 1;
            pgrUnAudit.Whrs.Clear(); pgrUnAudit.PrmsData.Clear();
            pgrUnAudit.PrefixWhr = "select * from V_ERP_UnAuditDelivery ";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtsendno.Text.Trim()))
            {
                pgrUnAudit.Whrs.Add("SendNo = @" + (idx++).ToString());
                pgrUnAudit.PrmsData.Add(txtsendno.Text.Trim());
            }

            pgrUnAudit.OrderBy = "Order By Id desc";
            pgrUnAudit.BindPageData();
        }

        private void Print()
        {
            pgrPrint.CurrentPage = 1;
            pgrPrint.Whrs.Clear(); pgrPrint.PrmsData.Clear();
            pgrPrint.PrefixWhr = "select * from V_ERP_PrintDelivery ";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtsendno.Text.Trim()))
            {
                pgrPrint.Whrs.Add("SendNo = @" + (idx++).ToString());
                pgrPrint.PrmsData.Add(txtsendno.Text.Trim());
            }

            pgrPrint.OrderBy = "Order By Id desc";
            pgrPrint.BindPageData();
        }

        void Audit()
        {
            pgrAudit.CurrentPage = 1;
            pgrAudit.Whrs.Clear(); pgrAudit.PrmsData.Clear();
            pgrAudit.PrefixWhr = "select * from V_ERP_AuditDelivery ";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtsendno.Text.Trim()))
            {
                pgrAudit.Whrs.Add("SendNo = @" + (idx++).ToString());
                pgrAudit.PrmsData.Add(txtsendno.Text.Trim());
            }

            pgrAudit.OrderBy = "Order By Id desc";
            pgrAudit.BindPageData();
        }

        void Invalid()
        {
            pgrInvalid.CurrentPage = 1;
            pgrInvalid.Whrs.Clear(); pgrInvalid.PrmsData.Clear();
            pgrInvalid.PrefixWhr = "select * from V_ERP_InvalidDelivery ";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtsendno.Text.Trim()))
            {
                pgrInvalid.Whrs.Add("SendNo = @" + (idx++).ToString());
                pgrInvalid.PrmsData.Add(txtsendno.Text.Trim());
            }

            pgrInvalid.OrderBy = "Order By Id desc";
            pgrInvalid.BindPageData();
        }

        private void tbMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    this.barBtnNew.Enabled = true;
                    this.barBtnPrint.Enabled = true;
                    this.barBtnRePrint.Enabled = false;
                    this.barBtnAudit.Enabled = false;
                    this.barBtnEdt.Enabled = true;
                    this.barBtnInvalid.Enabled = true;
                    break;
                case "已打印":
                    this.barBtnNew.Enabled = false;
                    this.barBtnPrint.Enabled = false;
                    this.barBtnAudit.Enabled = true;
                    this.barBtnRePrint.Enabled =true;
                    this.barBtnEdt.Enabled = true;
                    this.barBtnInvalid.Enabled = true;
                    break;
                case "已审核":
                    this.barBtnNew.Enabled = false;
                    this.barBtnPrint.Enabled = false;
                    this.barBtnAudit.Enabled = false;
                    this.barBtnRePrint.Enabled =false;
                    this.barBtnEdt.Enabled = true;
                    this.barBtnInvalid.Enabled = false;
                    break;
                case "已作废":
                    this.barBtnNew.Enabled = false;
                    this.barBtnPrint.Enabled = false;
                    this.barBtnAudit.Enabled = false;
                    this.barBtnRePrint.Enabled =false;
                    this.barBtnEdt.Enabled = false;
                    this.barBtnInvalid.Enabled = false;
                    break;
            }
        }

        private void gvUnAudit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            T_ERP_Delivery et = null;
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    et = gcUnAudit.GetFocusedDataSource<T_ERP_Delivery>();
                    break;
                case "已打印":
                    et = gcPrint.GetFocusedDataSource<T_ERP_Delivery>();
                    break;
                case "已审核":
                    et = gcAudit.GetFocusedDataSource<T_ERP_Delivery>();
                    break;
                case "已作废":
                    et = gcInvalid.GetFocusedDataSource<T_ERP_Delivery>();
                    break;
            }
            if (et == null)
            {
                gcItem.DataSource = null;
                gcAddr.DataSource = null;
            }
            else
            {
                gcItem.DataSource = FASControls.SerNoCaller_WL.Calr_DeliveryItem.Get(" where SendNo = @0 ",et.SendNo);
                gcAddr.DataSource = FASControls.SerNoCaller_WL.Calr_DeliveryAddr.Get(" where SendNo = @0 ", et.SendNo);
            }
        }
    }
}
