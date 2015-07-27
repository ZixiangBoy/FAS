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
using Ultra.FASControls.Caller;

namespace FAS.MaterialWare
{
    public partial class MaterialIvtCheckView : DialogViewEx
    {
        public UltraDbEntity.T_ERP_MaterialCheckMaster Ent { get; set; }
        List<UltraDbEntity.T_ERP_WareLoc> CacheLoc;
        Guid? edtSession;
        public MaterialIvtCheckView()
        {
            InitializeComponent();
        }

        private void IvtCheckView_Load(object sender, EventArgs e)
        {
            var lcedt = new Ultra.FASControls.BusControls.LocEdtGridEdit();
            repLoc.DataSource = CacheLoc = lcedt.LoadFromCache();

            pgr1.Caller = SerNoCaller.Calr_Material;
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
                gcIvtCheckDetail.DataSource = SerNoCaller_GC.Calr_MaterialCheckDetail.Get("where CheckNo=@0", Ent.CheckNo);
                edtSession = Ent.Session;
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
        
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

            var dt = gcIvtCheckDetail.GetDataSource<T_ERP_MaterialCheckDetail>();
            if (null == dt || dt.Count < 1)
            {
                MsgBox.ShowErrMsg("必须包含盘点商品!");
                return;
            }
            var c = dt.Where(j => string.IsNullOrEmpty(j.WareName) || string.IsNullOrEmpty(j.AreaName) ||
                 string.IsNullOrEmpty(j.LocName) ).Count();
            if (c > 0)
            {
                MsgBox.ShowErrMsg("必须为所有商品都分配上库位,请检查商品库位!");
                return;
            }
            var itemssion = Guid.NewGuid();
            //创建商品集合
                dt.ForEach(j =>
                {
                    j.Remark = string.Empty; j.Creator = this.CurUser; j.Updator = this.CurUser;
                    j.Reserved1 = 0; j.Reserved2 = string.Empty; j.Reserved3 = false;
                    j.Guid = Guid.NewGuid();
                    j.ItemSession = itemssion;
                });
            var rd = SerNoCaller_GC.Calr_MaterialCheckDetail.Add(dt);//.Add(dt);
            if (!rd.IsOK)
            {
                MsgBox.ShowErrMsg(rd.ErrMsg); return;
            }

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                Ent = SerNoCaller_GC.Calr_MaterialCheckMaster.GetByProc(" exec P_ERP_NewMaterialIvtCheck @0,@1,@2 ,@3,@4,@5 ",
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
                Ent = SerNoCaller_GC.Calr_MaterialCheckMaster.GetByProc(" exec P_ERP_NewMaterialIvtCheck @0,@1,@2 ,@3,@4 ,@5",
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
 
        private void btnCtl1_Click(object sender, EventArgs e)
        {
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear();
            pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select * from V_ERP_IsUsedMaterial";

            // int idx = 0;
            if (!string.IsNullOrEmpty(txtItem.Text.Trim()))
            {
                pgr1.Whrs.Add("(MaterialNo like '%" + txtItem.Text.Trim() + "%'or MaterialName = '" + txtItem.Text.Trim() + "')");
            }
            pgr1.OrderBy = "Order By MaterialNo";
            pgr1.BindPageData();
        }

        private void gcItem_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var et = gcItem.GetFocusedDataSource<T_ERP_Material>();
            if (et == null) return;
            var jt = et.MapTo<T_ERP_Material, T_ERP_MaterialCheckDetail>();
            var ds = gcIvtCheckDetail.GetDataSource<T_ERP_MaterialCheckDetail>();
            ds = ds ?? new List<T_ERP_MaterialCheckDetail>();
            var ft = ds.Where(j => j.MaterialNo == jt.MaterialNo).FirstOrDefault();
            if (ft != null)
            {
                ft.Num += 1;
                gcIvtCheckDetail.DataSource = ds;
                gcIvtCheckDetail.RefreshDataSource();
                return;
            }
            ds.Insert(0, jt);
            gcIvtCheckDetail.DataSource = ds;
            gcIvtCheckDetail.RefreshDataSource();
        }

        private void gvIvtCheckDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "LocName")
            {
                var et = CacheLoc.FirstOrDefault(j => j.LocName == e.Value.ToString());
                var nt = gvIvtCheckDetail.GetFocusedDataSource<T_ERP_MaterialCheckDetail>();
                nt.WareName = et.WareName; nt.AreaName = et.AreaName;
                gvIvtCheckDetail.MakeRowEditImmediateSave(e.Value);
            }
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            gcIvtCheckDetail.RemoveSelected();
        }

        private void gcIvtCheckDetail_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            gcIvtCheckDetail.RemoveSelected();
        }

    }
}
