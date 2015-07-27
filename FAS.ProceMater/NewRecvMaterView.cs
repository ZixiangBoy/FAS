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
using UltraDbEntity;
using Ultra.Common;
using Ultra.FASControls.Extend;
using DevExpress.XtraEditors;
using Ultra.FASControls;
using Ultra.Win.Core.Common;
using System.IO;
using Ultra.Surface.Lanuch;

namespace FAS.ProduceMater {
    public partial class NewRecvMaterView : DialogViewEx {
      
        public List<T_ERP_ProduceMater> ProMaters { get; set; }
        public List<T_ERP_RecvMater> RecvMater { get; set; }
        List<UltraDbEntity.T_ERP_WareLoc> CacheLoc;
        public NewRecvMaterView() {
            InitializeComponent();
        }

        private void EdtView_Load(object sender, EventArgs e) {
            var users=userEdt.LoadData();
            rspRecvMaterUser.Items.AddRange(users.Select(k => k.RealName).ToArray());
                            CacheLoc = this.Cacher.Get<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc");
                if (null == CacheLoc || CacheLoc.Count < 1)
                {
                    var fi = Path.Combine(Lanucher.AppDir, "SYS.Cache.V_ERP_NotVirtualLoc.jsn");
                    if (File.Exists(fi))
                        CacheLoc = File.ReadAllText(fi).DeSerialize<List<UltraDbEntity.T_ERP_WareLoc>>();
                    else
                        CacheLoc = SerNoCaller.Calr_WareLoc.Get("Select * from V_ERP_NotVirtualLoc")
                            .OrderBy(j => j.Distance).ThenBy(j => j.Shelf).ThenBy(j => j.Floor).ToList();

                    File.WriteAllText(fi, (CacheLoc).SerializeJson());
                    CacheLoc = SerNoCaller.Calr_WareLoc.Get("Select * from V_ERP_NotVirtualLoc")
                            .OrderBy(j => j.Distance).ThenBy(j => j.Shelf).ThenBy(j => j.Floor).ToList();

                    this.Cacher.Put<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc", CacheLoc);
                }
                reploc.DataSource = CacheLoc;
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                var ets = (from k in ProMaters
                           group k by new { k.ProduceNo, k.MaterialNo, k.MaterialName } into g
                           select new T_ERP_RecvMater
                           {
                               ProduceNo = g.Key.ProduceNo,
                               MaterialNo = g.Key.MaterialNo,
                               MaterialName = g.Key.MaterialName,
                               UseQty = g.Sum(j => j.UseQty),
                               ActQty = g.Sum(j => j.UseQty)
                           }).ToList();
                gcRecvMater.DataSource = ets;
            }
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                gcRecvMater.DataSource = RecvMater;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var rms = gcRecvMater.GetDataSource<T_ERP_RecvMater>();
            if (rms.Any(k => string.IsNullOrEmpty(k.UserName) || k.ActQty <= 0)) {
                MsgBox.ShowMessage("领料人和实际领料数量必填");
                return;
            }
            if (rms.Count(k => string.IsNullOrEmpty(k.WareName)) > 0)
            {
                MsgBox.ShowErrMsg("必须所有商品分配库位！");
                return;
            }
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                var grpGuid = Guid.NewGuid();
                rms.ForEach(k =>
                    {
                        k.Session = grpGuid;
                        k.Creator = k.Updator = this.CurUser;
                        k.CreateDate = k.UpdateDate = k.RecvDate = TimeSync.Default.CurrentSyncTime;
                        k.Reserved1 = 0;
                        k.Reserved2 = string.Empty;
                        k.Reserved3 = false;
                        k.Remark = "";
                    });

                var rd = SerNoCaller.Calr_RecvMater.Add(rms);
                if (rd.IsOK)
                {
                   var dt= SerNoCaller.Calr_RecvMater.ExecSql("exec P_FAS_RecvMater @0,@1", grpGuid, this.CurUser);
                   //if (!dt.IsOK)
                   //{
                   //    MsgBox.ShowErrMsg(dt.ErrMsg);
                   //    return;
                   //}

                }
                if (!rd.IsOK)
                {
                    MsgBox.ShowErrMsg(rd.ErrMsg);
                    return;
                }             
            }
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                var rd = SerNoCaller.Calr_RecvMater.BatchEdt(rms);
                if (!rd.IsOK)
                {
                    MsgBox.ShowErrMsg(rd.ErrMsg);
                    return;
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void userEdt_EditValueChanged(object sender, EventArgs e) {
            if (userEdt.GetSelectedValue() == null) return;

            if (MsgBox.ShowYesNoMessage(string.Empty, "确定要批量修改领料人?") == System.Windows.Forms.DialogResult.Yes)
            {
                var rms = gcRecvMater.GetDataSource<T_ERP_RecvMater>();
                rms.ForEach(k => k.UserName = userEdt.GetSelectedValue().RealName);
                gcRecvMater.RefreshDataSource();
            }
        }

        private void rspRecvMaterQty_EditValueChanged(object sender, EventArgs e) {
            var rsp = sender as SpinEdit;
            var rm = gcRecvMater.GetFocusedDataSource<T_ERP_RecvMater>();
            rm.ActQty = rsp.Value;
            gcRecvMater.RefreshDataSource();
        }

        private void rspRecvMaterUser_EditValueChanged(object sender, EventArgs e) {
            var rsp = sender as ComboBoxEdit;
            var rm = gcRecvMater.GetFocusedDataSource<T_ERP_RecvMater>();
            rm.UserName = rsp.SelectedItem.ToString();
            gcRecvMater.RefreshDataSource();
        }

        private void gvRecvMater_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var ds = gcRecvMater.GetDataSource<UltraDbEntity.T_ERP_RecvMater>();
            if (null == ds || ds.Count < 1) return;
            if (e.Column.FieldName == "LocName")
            {
                var et = CacheLoc.FirstOrDefault(j => j.LocName == e.Value.ToString());
                var nt = gvRecvMater.GetFocusedDataSource<UltraDbEntity.T_ERP_RecvMater>();
                nt.WareName = et.WareName; nt.AreaName = et.AreaName;
                gvRecvMater.MakeRowEditImmediateSave(e.Value);
                if (ds.Where(j => string.IsNullOrEmpty(j.LocName)).Count() > 0)
                {
                    ds.ForEach(j =>
                    {
                        j.LocName = e.Value.ToString();
                        j.WareName = et.WareName;
                        j.AreaName = et.AreaName;
                    });
                }
                gcRecvMater.DataSource = ds;
            }
            gcRecvMater.RefreshDataSource();
        }
    }
}
