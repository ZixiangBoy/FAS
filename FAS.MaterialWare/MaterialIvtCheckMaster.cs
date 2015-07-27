using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.FASControls.Extend;
using UltraDbEntity;
using Ultra.Common;
using Ultra.Surface.Common;
using Ultra.CoreCaller;
using Ultra.Surface.Interfaces;
using DevExpress.XtraBars;
using Ultra.Business.Core.Define;
using Ultra.Xls;
using Ultra.FASControls;
using Ultra.FASControls.Caller;


namespace FAS.MaterialWare
{
    public partial class MaterialIvtCheckMaster : MainSurface, ISurfacePermission
    {
        public MaterialIvtCheckMaster()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 有权限操作的工具栏按钮集合
        /// </summary>
        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<BarButtonItem>{ this.barBtnNew,this.barBtnEdt,
                this.barBtnSubmit,/*this.barBtnRefuse,*/this.barBtnAudit,this.barBtnInvalid
                ,this.barBtnImport,this.barBtnExportXls
            };
            }
        }

        /// <summary>
        /// 有权限操作的按钮集合
        /// </summary>
        public List<Control> ButtonItems
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 有权限操作的菜单集合
        /// </summary>
        public List<Control> MenuItems { get { return null; } }

        /// <summary>
        /// 有操作权限的GridView
        /// </summary>
        public List<PermitGridView> Grids
        {
            get
            {
                return new List<PermitGridView> { 
                new PermitGridView(gvInStockMarter,"未提交"),
                new PermitGridView(gvSubmit,"已提交"),
                new PermitGridView(gvAudit,"已审核"),
                new PermitGridView(gvInvalid,"已作废"),
            };
            }
        }

        /// <summary>
        /// 画面的内弹出对话框
        /// </summary>
        public List<BaseSurface> DialogForms { get { return null; } }

        EFCaller<T_ERP_MaterialCheckMaster> Calr { get; set; }
        EFCaller<T_ERP_ItemStyle> CalrStyle { get; set; }

        private void IvtCheckMaster_Load(object sender, EventArgs e)
        {
     
            xtraMain_SelectedPageChanged(null, null);
            Calr = SerNoCaller_GC.Calr_MaterialCheckMaster;
            pgr1.Caller = pgr2.Caller = pgr3.Caller = pgr4.Caller = Calr;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnSubmit.ItemClick += barBtnSubmit_ItemClick;//提交
            this.barBtnAudit.ItemClick += barBtnAudit_ItemClick;
            this.barBtnInvalid.ItemClick += barBtnInvalid_ItemClick;
            this.barBtnExportXls.ItemClick += barBtnExportXls_ItemClick;
            this.barBtnImport.ItemClick += barBtnImport_ItemClick;
        }

        void barBtnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var vw = new MaterialIvtCheckIptItemEdt();
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnExportXls_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
   
        
        #region 作废 驳回 审核 提交
        public void ChengIvk(string type, string remark, T_ERP_MaterialCheckMaster et)
        {
            if (et != null)
            {
                var rd = Calr.ExecSql("exec P_ERP_ChangStateIvtCheckMaterial @0,@1,@2,@3", type, this.CurUser, remark, et.CheckNo);
                if (rd.IsOK)
                {
                    switch (xtraMain.SelectedTabPage.Text)
                    {
                        case "未提交":
                            gcInStockMarter.RemoveSelected();
                            break;
                        case "已提交":
                            gcSubmit.RemoveSelected();
                            break;
                        case "已作废":
                            gcInvalid.RemoveSelected();
                            break;
                    }

                }
                else
                {
                    MsgBox.ShowErrMsg(rd.ErrMsg);
                }
            }
        }
     
        /// <summary>
        /// 作废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnInvalid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var et = gcSubmit.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
            if (null == et) return;
            var vw = new Ultra.FASControls.Views.InvalidReasonView();
            if(vw.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            ChengIvk("Invalid", vw.Reason, et);
        }
        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnRefuse_ItemClick(object sender, ItemClickEventArgs e)
        {
            var et = gcSubmit.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
            if (null == et) return;
            
            ChengIvk("Refuse", "", et);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var et = gcSubmit.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
            if (null == et) return;
            var rdJudge = Calr.GetByProc("P_ERP_JudgeStockMaterial @0", et.CheckNo);
            if (rdJudge.Count>0)//表示查询到商品数量有为负值的
            {
                if (MsgBox.ShowYesNoMessage("此条单据审核后，商品库存有为负值的，确定要审核吗？") == DialogResult.Yes)
                {
                    Audit(et);
                }
            }
            else
            {
                Audit(et);
            }
          
        }
        public void Audit(T_ERP_MaterialCheckMaster et)
        {
            var rd = Calr.ExecSql("exec P_ERP_AuditIvtMaterialCheck @0,@1", et.CheckNo, this.CurUser);
            if (rd.IsOK)
            {
                gcSubmit.RemoveSelected();
            }
            else
            {
                MsgBox.ShowErrMsg(rd.ErrMsg);
            }
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnSubmit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var et = gcInStockMarter.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
            if (null == et) return;
            ChengIvk("Submit", "", et);
        }
        #endregion

        //已提交未审核的盘点单
        void Submit()
        {
            pgr2.CurrentPage = 1;
            pgr2.Whrs.Clear(); pgr2.PrmsData.Clear();
            pgr2.PrefixWhr = "select * from V_ERP_SubmitMaterialView";
            int idx = -1;
            if (!string.IsNullOrEmpty(txtivcno.Text.Trim()))
            {
                pgr2.Whrs.Add(string.Format("CheckNo=@{0}", ++idx));
                pgr2.PrmsData.Add(txtivcno.Text.Trim());
            }
            if (!string.IsNullOrEmpty(usredt.Text.Trim()))
            {
                pgr2.Whrs.Add(string.Format("UserName=@{0}", ++idx));
                pgr2.PrmsData.Add(usredt.Text);
            }
            if (!string.IsNullOrEmpty(wareedt.Text))
            {
                pgr2.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_SubmitMaterialView b on a.checkno=b.checkno where a.warename=@{0}))",
                    ++idx));
                pgr2.PrmsData.Add(wareedt.Text);
            }
            if (!string.IsNullOrEmpty(txtitem.Text.Trim()))
            {
                pgr2.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_SubmitMaterialView b on a.checkno=b.checkno where a.MaterialNo like @{0}))",
                    ++idx));
                pgr2.PrmsData.Add("%" + txtitem.Text.Trim() + "%");
            }
            pgr2.OrderBy = "Order By Id desc";
            pgr2.BindPageData();
        }

        //未提交的盘点单
        void UnSubmit()
        {
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear(); pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select * from V_ERP_UnSubmitMaterialView";
            int idx = -1;
            if (!string.IsNullOrEmpty(txtivcno.Text.Trim()))
            {
                pgr1.Whrs.Add(string.Format("CheckNo=@{0}", ++idx));
                pgr1.PrmsData.Add(txtivcno.Text.Trim());
            }
            if (!string.IsNullOrEmpty(usredt.Text.Trim()))
            {
                pgr1.Whrs.Add(string.Format("UserName=@{0}", ++idx));
                pgr1.PrmsData.Add(usredt.Text);
            }
            if (!string.IsNullOrEmpty(wareedt.Text))
            {
                pgr1.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_UnSubmitMaterialView b on a.checkno=b.checkno where a.warename=@{0}))",
                    ++idx));
                pgr1.PrmsData.Add(wareedt.Text);
            }
            if (!string.IsNullOrEmpty(txtitem.Text.Trim()))
            {
                pgr1.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_UnSubmitMaterialView b on a.checkno=b.checkno where a.MaterialNo like @{0}))",
                    ++idx));
                pgr1.PrmsData.Add("%" + txtitem.Text.Trim() + "%");
            }
            pgr1.OrderBy = "Order By Id desc";
            pgr1.BindPageData();
        }

        //已审核
        void Audit()
        {
            //V_ERP_AuditCheckMaster
            pgr3.CurrentPage = 1;
            pgr3.Whrs.Clear(); pgr3.PrmsData.Clear();
            pgr3.PrefixWhr = "select * from V_ERP_AuditMaterialView";
            int idx = -1;
            if (!string.IsNullOrEmpty(txtivcno.Text.Trim()))
            {
                pgr3.Whrs.Add(string.Format("CheckNo=@{0}", ++idx));
                pgr3.PrmsData.Add(txtivcno.Text.Trim());
            }
            if (!string.IsNullOrEmpty(usredt.Text.Trim()))
            {
                pgr3.Whrs.Add(string.Format("UserName=@{0}", ++idx));
                pgr3.PrmsData.Add(usredt.Text);
            }
            if (!string.IsNullOrEmpty(wareedt.Text))
            {
                pgr3.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_AuditMaterialView b on a.checkno=b.checkno where a.warename=@{0}))",
                    ++idx));
                pgr3.PrmsData.Add(wareedt.Text);
            }
            if (!string.IsNullOrEmpty(txtitem.Text.Trim()))
            {
                pgr3.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_AuditMaterialView b on a.checkno=b.checkno where a.MaterialNo like @{0}))",
                    ++idx));
                pgr3.PrmsData.Add("%" + txtitem.Text.Trim() + "%");
            }
            pgr3.OrderBy = "Order By Id desc";
            pgr3.BindPageData();
        }

        //已作废
        void Invalid()
        {
            //V_ERP_InvalidCheckMaster
            pgr4.CurrentPage = 1;
            pgr4.Whrs.Clear(); pgr4.PrmsData.Clear();
            pgr4.PrefixWhr = "select * from V_ERP_InvalidMaterialView";
            int idx = -1;
            if (!string.IsNullOrEmpty(txtivcno.Text.Trim()))
            {
                pgr4.Whrs.Add(string.Format("CheckNo=@{0}", ++idx));
                pgr4.PrmsData.Add(txtivcno.Text.Trim());
            }
            if (!string.IsNullOrEmpty(usredt.Text.Trim()))
            {
                pgr4.Whrs.Add(string.Format("UserName=@{0}", ++idx));
                pgr4.PrmsData.Add(usredt.Text);
            }
            if (!string.IsNullOrEmpty(wareedt.Text))
            {
                pgr4.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_InvalidMaterialView b on a.checkno=b.checkno where a.warename=@{0}))",
                    ++idx));
                pgr4.PrmsData.Add(wareedt.Text);
            }
            if (!string.IsNullOrEmpty(txtitem.Text.Trim()))
            {
                pgr4.Whrs.Add(string.Format("exists(select 1 from T_ERP_MaterialCheckDetail a join V_ERP_InvalidMaterialView b on a.checkno=b.checkno where a.MaterialNo like @{0}))",
                    ++idx));
                pgr4.PrmsData.Add("%" + txtitem.Text.Trim() + "%");
            }
            pgr4.OrderBy = "Order By Id desc";
            pgr4.BindPageData();
        }

        void barBtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {

            switch (xtraMain.SelectedTabPage.Text)
            {
                case "未提交":
                    UnSubmit();
                    break;
                case "已提交":
                    Submit();
                    break;
                case "已审核":
                    Audit();
                    break;
                case "已作废":
                    Invalid();
                    break;
            }
            FocuseRowChange();
        }

        void barBtnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            var vw = new MaterialIvtCheckView();
            vw.EditMode = EnViewEditMode.New;
            if (vw.ShowDialog() == DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnEdt_ItemClick(object sender, ItemClickEventArgs e)
        {
            var et = gcInStockMarter.GetFocusedDataSource<UltraDbEntity.T_ERP_MaterialCheckMaster>();
            var vw = new MaterialIvtCheckView();
            vw.EditMode = EnViewEditMode.Edit;
            vw.Ent = et;
            if (vw.ShowDialog() == DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        public void FocuseRowChange()
        {
            var et = new T_ERP_MaterialCheckMaster();
            switch (xtraMain.SelectedTabPage.Text)
            {
                case "未提交":
                    et = gcInStockMarter.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
                    break;
                case "已提交":
                    et = gcSubmit.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
                    break;
                case "已审核":
                    et = gcAudit.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
                    break;
                case "已作废":
                    et = gcInvalid.GetFocusedDataSource<T_ERP_MaterialCheckMaster>();
                    break;
            }
            if (et == null) { gcInStockDetail.DataSource = null; return; }
            gcInStockDetail.DataSource = SerNoCaller_GC.Calr_MaterialCheckDetail.Get("where CheckNo=@0", et.CheckNo);
        }

        private void gvInStockMarter_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FocuseRowChange();
        }

        private void xtraMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (xtraMain.SelectedTabPage.Text)
            {
                case "未提交":
                    this.barBtnSubmit.Enabled = true;//提交
                    this.barBtnAudit.Enabled = false;//审核
                    this.barBtnRefuse.Enabled = false;//驳回
                    this.barBtnInvalid.Enabled = false;//作废
                    this.barBtnNew.Enabled = true;//新增
                    this.barBtnEdt.Enabled = true;//修改
                    break;
                case "已提交":
                    this.barBtnSubmit.Enabled = false;//提交
                    this.barBtnNew.Enabled = false;//新增
                    this.barBtnEdt.Enabled = false;//修改
                    this.barBtnAudit.Enabled = true;//审核
                    this.barBtnRefuse.Enabled = true;//驳回
                    this.barBtnInvalid.Enabled = true;//作废
                    break;
                case "已审核":
                    this.barBtnSubmit.Enabled = false;//提交
                    this.barBtnNew.Enabled = false;//新增
                    this.barBtnEdt.Enabled = false;//修改
                    this.barBtnAudit.Enabled = false;//审核
                    this.barBtnRefuse.Enabled = false;//驳回
                    this.barBtnInvalid.Enabled = false;//作废
                    break;
                case "已作废":
                    this.barBtnSubmit.Enabled = false;//提交
                    this.barBtnNew.Enabled = false;//新增
                    this.barBtnEdt.Enabled = false;//修改
                    this.barBtnAudit.Enabled = false;//审核
                    this.barBtnRefuse.Enabled = false;//驳回
                    this.barBtnInvalid.Enabled = false;//作废
                    break;
            }
        }

    }
}