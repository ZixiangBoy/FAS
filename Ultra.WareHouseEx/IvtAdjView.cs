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

namespace Ultra.WareHouseEx
{
    public partial class IvtAdjView : MainSurface, ISurfacePermission
    {
        public IvtAdjView()
        {
            InitializeComponent();
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                this.barBtnNew,this.barBtnInvalid,this.barBtnAudit
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
            pgr1.Caller = pgr2.Caller = pgr3.Caller = SerNoCaller.Calr_IvtAdj;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            usredt.LoadFromCache();
            foreach (Control c in pnlquery.Controls)
                c.KeyUp += (s1, e1) =>
                {
                    if (e1.KeyCode == Keys.Enter)
                        barBtnRefresh_ItemClick(null, null);
                };
            tbMain_SelectedPageChanged(null, null);
        }

        //审核
        void barBtnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_IvtAdj>();
            if (null == et) return;
            if (MsgBox.ShowYesNoMessage("确定要审核此调整单吗？") != DialogResult.Yes) return;
            var kt = SerNoCaller.Calr_IvtAdj.GetByProc("exec P_ERP_AuditIvtAdj @0,@1", et.AdjNo, this.CurUser)
                .FirstOrDefault();
            if (kt.IsAudit)
                gcUnAudit.RemoveSelected();

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
            var et = gcUnAudit.GetFocusedDataSource<UltraDbEntity.T_ERP_IvtAdj>();
            if (null == et) return;
            var vw = new InvalidAdjView();
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
            var vw = new IvtAdjEdt();
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void UnAudit()
        {
            //V_ERP_UnAuditIvtAdj
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear(); pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select a.* from [V_ERP_UnAuditIvtAdj] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(usredt.Text.Trim()))
            {
                pgr1.Whrs.Add("a.Creator = @" + (idx++).ToString());
                pgr1.PrmsData.Add(usredt.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtadjno.Text.Trim()))
            {
                pgr1.Whrs.Add("a.AdjNo = @" + (idx++).ToString());
                pgr1.PrmsData.Add(txtadjno.Text.Trim());
            }

            pgr1.OrderBy = "Order By a.Id desc";
            pgr1.BindPageData();
        }

        void Audit()
        {
            //V_ERP_AuditIvtAdj
            pgr2.CurrentPage = 1;
            pgr2.Whrs.Clear(); pgr2.PrmsData.Clear();
            pgr2.PrefixWhr = "select a.* from [V_ERP_AuditIvtAdj] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(usredt.Text.Trim()))
            {
                pgr2.Whrs.Add("a.Creator = @" + (idx++).ToString());
                pgr2.PrmsData.Add(usredt.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtadjno.Text.Trim()))
            {
                pgr2.Whrs.Add("a.AdjNo = @" + (idx++).ToString());
                pgr2.PrmsData.Add(txtadjno.Text.Trim());
            }

            pgr2.OrderBy = "Order By a.Id desc";
            pgr2.BindPageData();
        }

        void Invalid()
        {
            //V_ERP_InvalidIvtAdj
            pgr3.CurrentPage = 1;
            pgr3.Whrs.Clear(); pgr3.PrmsData.Clear();
            pgr3.PrefixWhr = "select a.* from [V_ERP_InvalidIvtAdj] a";
            int idx = 0;
            if (!string.IsNullOrEmpty(usredt.Text.Trim()))
            {
                pgr3.Whrs.Add("a.Creator = @" + (idx++).ToString());
                pgr3.PrmsData.Add(usredt.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtadjno.Text.Trim()))
            {
                pgr3.Whrs.Add("a.AdjNo = @" + (idx++).ToString());
                pgr3.PrmsData.Add(txtadjno.Text.Trim());
            }

            pgr3.OrderBy = "Order By a.Id desc";
            pgr3.BindPageData();
        }

        private void tbMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (tbMain.SelectedTabPage.Text)
            {
                case "未审核":
                    this.barBtnNew.Enabled = true;
                    this.barBtnAudit.Enabled = true;
                    this.barBtnInvalid.Enabled = true;
                    break;
                case "已审核":
                    this.barBtnNew.Enabled = false;
                    this.barBtnAudit.Enabled = false;
                    this.barBtnInvalid.Enabled = false;
                    break;
                case "已作废":
                    this.barBtnNew.Enabled = false;
                    this.barBtnAudit.Enabled = false;
                    this.barBtnInvalid.Enabled = false;
                    break;
            }
        }
    }
}
