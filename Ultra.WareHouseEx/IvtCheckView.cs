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
using Ultra.Web.Core.Common;
using Ultra.Win.Core.Common;
using Ultra.FASControls;

namespace Ultra.WareHouseEx
{
    public partial class IvtCheckView : DialogViewEx
    {
        public UltraDbEntity.T_ERP_IvtCheckMaster Ent { get; set; }
        List<UltraDbEntity.T_ERP_WareLoc> CacheLoc;
        Guid? edtSession;
        public  IvtCheckView()
        {
            InitializeComponent();
        }

        private void IvtCheckView_Load(object sender, EventArgs e)
        {
            #region 绑定库位 供应商
            //CacheLoc = this.Cacher.Get<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc");
            //            if (null == CacheLoc || CacheLoc.Count < 1)
            //            {

            //                CacheLoc = SerNoCaller.Calr_UnVirtualWareLoc.Get("Select * from V_ERP_NotVirtualLoc")
            //                    .OrderBy(j => j.Distance).ThenBy(j => j.Shelf).ThenBy(j => j.Floor).ToList();

            //                this.Cacher.Put<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc", CacheLoc);
            //            }
            //repLoc.DataSource = CacheLoc;
            var lcedt = new Ultra.FASControls.BusControls.LocEdtGridEdit();
            repLoc.DataSource = CacheLoc = lcedt.LoadFromCache();

            //repSupp.DataSource = SerNoCaller.Calr_Supplier.Get(" where IsDel=0 and IsUsing=1 ");
            #endregion

            pgr.Caller = SerNoCaller.Calr_Item;
            if (Ent == null)
            {
                txtCheckUser.Text = this.CurUser;
                txtCheckTime.DateTime = DateTime.Now;
            }
            else
            {
                txtCheckNo.Text = Ent.CheckNo;
                txtCheckTime.EditValue = Ent.CheckTime;
                txtCheckUser.Text = Ent.CheckUser;
                gcIvtCheckDetail.DataSource = SerNoCaller.Calr_IvtCheckDetail.Get("where CheckNo=@0", Ent.CheckNo);
                edtSession = Ent.Session;
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            #region

            if (string.IsNullOrEmpty(txtCheckTime.Text))
            {
                MsgBox.ShowErrMsg("盘点时间必须填写!"); txtCheckTime.Select(); return;
            }
            else
            {
                if (
                    TimeSync.Default.CurrentSyncTime.DateDiff(EnDatePart.MINUTE, txtCheckTime.DateTime) < 0)
                {
                    MsgBox.ShowErrMsg("盘点时间必须在当前时间之前!"); txtCheckTime.Select(); return;
                }
            }

            var dt = gcIvtCheckDetail.GetDataSource<T_ERP_IvtCheckDetail>();
            if (null == dt || dt.Count < 1)
            {
                MsgBox.ShowErrMsg("必须包含盘点商品!");
                return;
            }
            var c = dt.Where(j => string.IsNullOrEmpty(j.WareName) || string.IsNullOrEmpty(j.AreaName) ||
                 string.IsNullOrEmpty(j.LocName)).Count();
            if (c > 0)
            {
                MsgBox.ShowErrMsg("必须为所有商品都分配上库位,请检查商品库位信息!");
                return;
            }

            //创建商品集合
            var itemssion = Guid.NewGuid();
            dt.ForEach(j =>
            {
                j.Remark = string.Empty; j.Creator = this.CurUser; j.Updator = this.CurUser;
                j.Reserved1 = 0; j.Reserved2 = string.Empty; j.Reserved3 = false;
                j.Guid = Guid.NewGuid();
                j.ItemSession = itemssion;
            });
            var rd = SerNoCaller.Calr_IvtCheckDetail.Add(dt);//.Add(dt);
            if (!rd.IsOK)
            {
                MsgBox.ShowErrMsg(rd.ErrMsg); return;
            }
            #endregion

            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                Ent = SerNoCaller.Calr_IvtCheckMaster.GetByProc(" exec P_ERP_NewIvtCheck @0,@1,@2 ,@3,@4,@5 ",
                    this.CurUser, txtCheckTime.Text.ToString(), txtCheckUser.Text.Trim(), "", itemssion, Guid.Empty).FirstOrDefault();
                if (Ent == null)
                {
                    MsgBox.ShowErrMsg("操作失败"); return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                return;
            }
            else
            {//修改
                Ent = SerNoCaller.Calr_IvtCheckMaster.GetByProc(" exec P_ERP_NewIvtCheck @0,@1,@2 ,@3,@4 ,@5",
                   this.CurUser, txtCheckTime.Text.ToString(), txtCheckUser.Text.Trim(), txtCheckNo.Text.Trim(), edtSession, itemssion).FirstOrDefault();
                if (Ent == null)
                {
                    MsgBox.ShowErrMsg("修改失败"); return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();

                return;
            }
        }

        #region
        private void btnCtl1_Click(object sender, EventArgs e)
        {
            pgr.CurrentPage = 1;
            pgr.Whrs.Clear();
            pgr.PrmsData.Clear();
            pgr.PrefixWhr = "select Id,Guid,OuterIid,OuterSkuId,ItemName,SkuProperties,PackageCount  from [V_ERP_AuditItem] ";

            // int idx = 0;
            if (!string.IsNullOrEmpty(txtItem.Text.Trim()))
            {
                pgr.Whrs.Add("(ItemName like '%" + txtItem.Text.Trim() + "%'or OuterIid = '" + txtItem.Text.Trim() + "')");
            }
            if (!string.IsNullOrEmpty(txtSku.Text.Trim()))
            {
                pgr.Whrs.Add("(SkuProperties like '%" + txtSku.Text.Trim() + "%'"
                    + "or OuterSkuId like '%" + txtSku.Text.Trim() + "%')");
                // pgr.PrmsData.Add("%"+txtSku.Text.Trim()+"%");
            }
            pgr.OrderBy = "Order By ItemName,SkuProperties";
            pgr.BindPageData();
        }

        private void gcItem_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var ett = gcItem.GetFocusedDataSource<UltraDbEntity.T_ERP_Item>();
            var et = ett.MapTo<UltraDbEntity.T_ERP_Item, UltraDbEntity.T_ERP_IvtCheckDetail>();
            if (null == et) return;
            var ds = gcIvtCheckDetail.GetDataSource<UltraDbEntity.T_ERP_IvtCheckDetail>(); //T_ERP_Item
            ds = ds ?? new List<UltraDbEntity.T_ERP_IvtCheckDetail>();
            var mch = ds.Where(j => j.OuterIid == et.OuterIid && j.OuterSkuId == et.OuterSkuId).FirstOrDefault();
            if (null != mch) mch.Num += 1;
            else
            {
                ds.Insert(0, et);
            }

            gcIvtCheckDetail.DataSource = ds;
            gcIvtCheckDetail.RefreshDataSource();
        }

        private void gvIvtCheckDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "LocName")
            {
                var et = CacheLoc.FirstOrDefault(j => j.LocName == e.Value.ToString());
                var nt = gvIvtCheckDetail.GetFocusedDataSource<T_ERP_IvtCheckDetail>();
                nt.WareName = et.WareName; nt.AreaName = et.AreaName;
                gvIvtCheckDetail.MakeRowEditImmediateSave(e.Value);
            }
        }
        #endregion

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            gcIvtCheckDetail.RemoveSelected();
        }

        private void gvIvtCheckDetail_CellValueChanging_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

    }
}
