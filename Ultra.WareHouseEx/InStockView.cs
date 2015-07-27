using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.FASControls.Extend;
using Ultra.FASControls;

namespace Ultra.WareHouseEx
{
    public partial class InStockView : MainSurface, ISurfacePermission
    {
        public InStockView()
        {
            InitializeComponent();
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                this.barBtnNew,this.barBtnRefresh,this.barBtnInvalid
                ,this.barBtnAudit
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
                new PermitGridView(gvAllAudit,"已审核"),
                new PermitGridView(gvInvalid,"已作废"),
            };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        private void PackInStockView_Load(object sender, EventArgs e)
        {
            Ultra.FASControls.MainReportEx.SetFormXtraTab(tbMain);
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            this.barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            pgr1.Caller = pgr2.Caller = pgr3.Caller = pgr4.Caller = SerNoCaller.Calr_InStock;

            tbMain_SelectedPageChanged(null, null);
        }

        /// <summary>
        /// 入库审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStock>();
            if (null == et) return;
            var rd = SerNoCaller.Calr_InStock.GetByProc("exec P_ERP_NAuditInStock @0,@1", et.StockNo, this.CurUser)//P_ERP_NAuditInStock
                .FirstOrDefault();
            if (rd != null && rd.IsAudit)
            {
                gcUnAudit.RemoveSelected();
            }

            gvUnAudit_FocusedRowChanged(null, null);
        }

        void barBtnInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStock>();
            if (null == et) return;
            var vw = new Ultra.FASControls.Views.InvalidReasonView();
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                et.InvalidRemark = vw.Reason;
                et.Invalider = CurUser;
                //作废操作
                var rd = SerNoCaller.Calr_PackInStock.ExecSql("exec P_ERP_InvalidInStock @0,@1,@2",
                      et.StockNo, CurUser, et.InvalidRemark);
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
                    UnSubmit();
                    break;
                case "已审核":
                    AllAudit();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
            gvUnAudit_FocusedRowChanged(null, null);
        }


        void UnSubmit()
        {
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear(); pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select a.* from [V_ERP_NUnAuditInStock] a";//V_ERP_NUnSubmitInStock
            int idx = 0;
            if (!string.IsNullOrEmpty(txtouterno.Text.Trim()))
            {
                pgr1.Whrs.Add("a.OuterNo like @" + (idx++).ToString());
                pgr1.PrmsData.Add("%" + txtouterno.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtinstckno.Text.Trim()))
            {
                pgr1.Whrs.Add("a.StockNo = @" + (idx++).ToString());
                pgr1.PrmsData.Add(txtinstckno.Text.Trim());
            }
            pgr1.OrderBy = "Order By a.Id desc";
            pgr1.BindPageData();
        }

        void Submit()
        {
            //V_ERP_AuditInStock
            pgr2.CurrentPage = 1;
            pgr2.Whrs.Clear(); pgr2.PrmsData.Clear();
            pgr2.PrefixWhr = "select a.* from [ V_ERP_NSubmitInStock] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtouterno.Text.Trim()))
            {
                pgr2.Whrs.Add("a.OuterNo like @" + (idx++).ToString());
                pgr2.PrmsData.Add("%" + txtouterno.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtinstckno.Text.Trim()))
            {
                pgr2.Whrs.Add("a.StockNo = @" + (idx++).ToString());
                pgr2.PrmsData.Add(txtinstckno.Text.Trim());
            }
            pgr2.OrderBy = "Order By a.Id desc";
            pgr2.BindPageData();
        }

        void AllAudit()
        {
            pgr3.CurrentPage = 1;
            pgr3.Whrs.Clear(); pgr3.PrmsData.Clear();
            pgr3.PrefixWhr = "select a.* from [V_ERP_NAuditInStock] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtouterno.Text.Trim()))
            {
                pgr3.Whrs.Add("a.OuterNo like @" + (idx++).ToString());
                pgr3.PrmsData.Add("%" + txtouterno.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtinstckno.Text.Trim()))
            {
                pgr3.Whrs.Add("a.StockNo = @" + (idx++).ToString());
                pgr3.PrmsData.Add(txtinstckno.Text.Trim());
            }
            pgr3.OrderBy = "Order By a.Id desc";
            pgr3.BindPageData();
        }



        void Invalid()
        {
            //V_ERP_InvalidInStock
            pgr4.CurrentPage = 1;
            pgr4.Whrs.Clear(); pgr4.PrmsData.Clear();
            pgr4.PrefixWhr = "select a.* from [V_ERP_InvalidInStock] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(txtouterno.Text.Trim()))
            {
                pgr4.Whrs.Add("a.OuterNo like @" + (idx++).ToString());
                pgr4.PrmsData.Add("%" + txtouterno.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtinstckno.Text.Trim()))
            {
                pgr4.Whrs.Add("a.StockNo = @" + (idx++).ToString());
                pgr4.PrmsData.Add(txtinstckno.Text.Trim());
            }
            pgr4.OrderBy = "Order By a.Id desc";
            pgr4.BindPageData();
        }

        /// <summary>
        /// 新增包件入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new InStockAdd();
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        private void gvUnAudit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            UltraDbEntity.T_ERP_InStock et = null;
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStock>();
                    break;
                case "部分入库":
                    et = gvAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStock>();
                    break;
                case "已审核":
                    et = gvAllAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_InStock>();
                    break;
                case "已作废":
                    et = gcInvalid.GetFocusedDataSource<UltraDbEntity.T_ERP_InStock>();
                    break;
                default:
                    break;
            }
            GetDetail(et);
        }

        private void GetDetail(UltraDbEntity.T_ERP_InStock et)
        {
            if (null == et)
            {
                gcLog.DataSource = null;
                gcNeedItem.DataSource = null;
                return;
            }
            gcNeedItem.DataSource = SerNoCaller.Calr_InStockItem.Get("where StockNo=@0", et.StockNo);
            gcLog.DataSource = SerNoCaller.Calr_Log.Get("where TradeNo=@0 order by id", et.StockNo);
        }

        private void tbMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    barBtnNew.Enabled = barBtnInStock.Enabled = barBtnInvalid.Enabled = true;
                    tbDetail.SelectedTabPage = this.xtbItem;
                    barBtnAudit.Enabled = true;
                    break;
                //case "部分入库":
                //    barBtnInStock.Enabled = barBtnNew.Enabled  = barBtnInvalid.Enabled = true;
                //    tbDetail.SelectedTabPage = this.xtbInStork;
                //    barBtnAudit.Enabled = true;
                //break;
                case "已审核":
                    barBtnInStock.Enabled = barBtnNew.Enabled = barBtnInvalid.Enabled = false;
                    tbDetail.SelectedTabPage = this.xtbInStork; barBtnAudit.Enabled = false;
                    break;
                case "已作废":
                    barBtnInStock.Enabled = barBtnNew.Enabled = barBtnInvalid.Enabled = false;
                    tbDetail.SelectedTabPage = this.xtbItem; barBtnAudit.Enabled = false;
                    break;
            }
            gvUnAudit_FocusedRowChanged(null, null);
        }
    }
}
