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
using Ultra.FASControls.Extend;
using UltraDbEntity;
using Ultra.FASControls;
using Ultra.FASControls.Caller;
using Ultra.Surface.Common;

namespace FAS.ProduceMater {
    public partial class MainView : MainSurface, ISurfacePermission {
        public MainView() {
            InitializeComponent();
        }


        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                    this.barBtnNew,this.barBtnEdt,this.barBtnAudit
                };
            }
        }

        public List<Control> ButtonItems {
            get { return null; }
        }

        public List<Control> MenuItems {
            get { return null; }
        }

        public List<PermitGridView> Grids {
            get {
                return new List<PermitGridView> { 
                new PermitGridView(this.gvProduce,"生产用料列表"),
                new PermitGridView(this.gvRecvMater,"领料单")
            };
            }
        }

        public List<Ultra.Surface.Form.BaseSurface> DialogForms {
            get { return null; }
        }

        private void MainView_Load(object sender, EventArgs e) {
            materialGridEdt1.LoadData();
            procedureGridEdit1.LoadData();
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnNew.ItemClick += barBtnNew_ItemClick;
            barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            proPager.Caller = SerNoCaller.Calr_ProduceMater;
            recvPager.Caller = SerNoCaller.Calr_RecvMater;
            recvAudit.Caller = SerNoCaller.Calr_RecvMater;
            tabMain_SelectedPageChanged(null, null);
            recvPager.PrefixWhr = "select * from V_ERP_GetUnAuditRecvMater ";
            proPager.PrefixWhr = "select * from V_ERP_GetProduceMater";
            recvAudit.PrefixWhr = "select * from V_ERP_GetAuditRecvMater";
        }

        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcRecvMater.GetSelectedDataSource<T_ERP_RecvMater>();
            if (et == null || et.Count() < 1) return;
            var grpGuid = Guid.NewGuid();
            et.ForEach(k =>
            {
                k.Session = grpGuid;
            });
            SerNoCaller.Calr_RecvMater.BatchEdt(et);
            var rd = SerNoCaller.Calr_RecvMater.ExecSql("exec P_FAS_AuditedRecvMater @0,@1", grpGuid, CurUser);
            if (!rd.IsOK)
            {
                MsgBox.ShowErrMsg(rd.ErrMsg);
                return;
            }
            MsgBox.ShowMessage("领料成功！");
            barBtnRefresh_ItemClick(null, null);
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ets = gcRecvMater.GetSelectedDataSource<T_ERP_RecvMater>();
            if (ets == null || ets.Count() < 1) return;
            var vw = new NewRecvMaterView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            vw.RecvMater = ets;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var ets = gvProduce.GetSelectedDataSource<T_ERP_ProduceMater>();
            if (ets == null || ets.Count() < 1)
            {
                MsgBox.ShowMessage("没有选择一笔生产单！");
                return;
            }
            var vw = new NewRecvMaterView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            vw.ProMaters = ets;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (tabMain.SelectedTabPage.Text) {
                case "生产用料":
                    ProduceMater();
                    break;
                case "领料单":
                    RecvMater();
                    break;
                case"已审核":
                    AuditMaster();
                    break;
                default:
                    break;
            }
        }

        private void AuditMaster()
        {
            recvAudit.CurrentPage = 1;
            recvAudit.PrefixWhr = "select * from V_ERP_GetAuditRecvMater ";
            recvAudit.Whrs.Clear();
            recvAudit.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(materialGridEdt1.Text))
            {
                recvAudit.Whrs.Add("MaterialNo=@" + (idx++).ToString());
                recvAudit.PrmsData.Add(materialGridEdt1.Text);
            }
            if (!string.IsNullOrEmpty(txtProduceNo.Text))
            {
                recvAudit.Whrs.Add("ProduceNo=@" + (idx++).ToString());
                recvAudit.PrmsData.Add(txtProduceNo.Text);
            }
            if (!string.IsNullOrEmpty(procedureGridEdit1.Text))
            {
                proPager.Whrs.Add("ProcedureName=@" + (idx++).ToString());
                proPager.PrmsData.Add(procedureGridEdit1.Text);
            }
            recvAudit.OrderBy = " order by Id desc";
            recvAudit.BindPageData();
        }

        private void RecvMater() {
            recvPager.CurrentPage = 1;
            recvPager.PrefixWhr = "select * from V_ERP_GetUnAuditRecvMater ";
            recvPager.Whrs.Clear();
            recvPager.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(materialGridEdt1.Text)) {
                recvPager.Whrs.Add("MaterialNo=@" + (idx++).ToString());
                recvPager.PrmsData.Add(materialGridEdt1.Text);
            }
            if (!string.IsNullOrEmpty(txtProduceNo.Text)) {
                recvPager.Whrs.Add("ProduceNo=@" + (idx++).ToString());
                recvPager.PrmsData.Add(txtProduceNo.Text);
            }
            if (!string.IsNullOrEmpty(procedureGridEdit1.Text))
            {
                proPager.Whrs.Add("ProcedureName=@" + (idx++).ToString());
                proPager.PrmsData.Add(procedureGridEdit1.Text);
            }
            recvPager.OrderBy = " order by Id desc";
            recvPager.BindPageData();
        }

        private void ProduceMater() {
            proPager.CurrentPage = 1;
            proPager.PrefixWhr = "select * from V_ERP_GetProduceMater";
            proPager.Whrs.Clear();
            proPager.PrmsData.Clear();
            int idx = 0;
            if (!string.IsNullOrEmpty(materialGridEdt1.Text)) {
                proPager.Whrs.Add("MaterialNo=@" + (idx++).ToString());
                proPager.PrmsData.Add(materialGridEdt1.Text);
            }
            if (!string.IsNullOrEmpty(txtProduceNo.Text)) {
                proPager.Whrs.Add("ProduceNo=@" + (idx++).ToString());
                proPager.PrmsData.Add(txtProduceNo.Text);
            }
            if (!string.IsNullOrEmpty(procedureGridEdit1.Text))
            {
                proPager.Whrs.Add("ProcedureName=@" + (idx++).ToString());
                proPager.PrmsData.Add(procedureGridEdit1.Text);
            }
            proPager.OrderBy = " order by Id desc";
            proPager.BindPageData();
        }

        private void pBtnRecvMater_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var ets = gcProduce.GetSelectedDataSource<T_ERP_ProduceMater>();
            if (ets == null || ets.Count < 1) return;
            var vw = new NewRecvMaterView();
            vw.ProMaters = ets;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                
            }
        }

        private void gvProduce_MouseUp(object sender, MouseEventArgs e) {
            
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (tabMain.SelectedTabPage.Text)
            {
                case "生产用料":
                    barBtnEdt.Enabled = false;
                    barBtnNew.Enabled = true;
                    barBtnAudit.Enabled = false;
                    break;
                case "领料单":
                    barBtnEdt.Enabled = true;
                    barBtnNew.Enabled = false;
                    barBtnAudit.Enabled = true;
                    break;
                case "已审核":
                    barBtnEdt.Enabled = true;
                    barBtnNew.Enabled = false;
                    barBtnAudit.Enabled = false;
                    break;
            }
        }
    }
}
