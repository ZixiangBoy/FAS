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
using Ultra.FASControls.Views;
using Ultra.Common;
using Ultra.Surface.Common;
using System.IO;
using Ultra.Surface.Lanuch;
using System.Threading;
using Ultra.FASControls;
using UltraDbEntity;
using DevExpress.XtraEditors;

namespace Ultra.FAS.Refund
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_AfterSale AfterSale;
        public bool isAudit;
        public Guid ImgSession { get; set; }
        public List<T_ERP_ItemResponsible> ItemResps;
        public List<T_ERP_Responsible> Resps;

        private void SendGoodsEdt_Load(object sender, EventArgs e)
        {
            repResp.DataSource = Resps;
            gvOrder.OptionsView.ShowAutoFilterRow = false;
            gvExpenses.OptionsView.ShowAutoFilterRow = false;
            repExpenses.DataSource = Ultra.FASControls.SerNoCaller_WL.Calr_ExpensesType.Get(" where isnull(IsUsing,0) = 1 ");
            var rep = Resps = FASControls.SerNoCaller_WL.Calr_Responsible.Get(" where isnull(IsUsing,0) = 1 ");
            if(rep!=null && rep.Count>0)
                repChkEdit.DataSource = rep.Select(j=>j.ResponsibleName);
            if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                txtAfterNo.Text = AfterSale.AfterNo;
                txtReceiverName.Text = AfterSale.ReceiverName;
                ImgSession = AfterSale.ImageSession == null ? Guid.NewGuid() : AfterSale.ImageSession.Value;
                memoEdit1.Text = AfterSale.Remark;
                btnSelect.Text = AfterSale.AfterNo;
                var orders = FASControls.SerNoCaller_WL.Calr_AfterSalaItem.Get(" where AfterNo = @0 ", AfterSale.AfterNo);
                if(orders!=null && orders.Count>0)
                    orders.ForEach(j=>j.UISelected=true);
                gcOrder.DataSource = orders;
                gcExpenses.DataSource = FASControls.SerNoCaller_WL.Calr_Expenses.Get(" where FromNo = @0 ", AfterSale.AfterNo);
            }
            else
                ImgSession = Guid.NewGuid();
            imgupd.Session = ImgSession;
            if (isAudit)
            {
                btnSelect.Enabled = false;
                gvOrder.OptionsBehavior.Editable = false;
                memoEdit1.Properties.ReadOnly = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var data = gcOrder.GetDataSource<UltraDbEntity.T_ERP_AfterSalaItem>();
            if (data == null || data.Count < 1)
            {
                MsgBox.ShowErrMsg("请选择单据");
                return;
            }
            var ds = data.Where(j => j.UISelected).ToList();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("没有选择任何行数据！保存无效！"); return; }
            var dss = ds.Where(j => j.TroubleNum < 0 || j.TroubleNum > j.Num || j.TroubleNum==null).ToList();
            if (dss != null && dss.Count > 0)
            {
                MsgBox.ShowErrMsg("售后数不能小于0或大于当前生产数");
                return;
            }
            
            var cnt = ds.Select(j => j.TroubleNum).Sum();
            var exp = gcExpenses.GetDataSource<UltraDbEntity.T_ERP_Expenses>();
            decimal fee = 0;
            if (exp != null && exp.Count > 0)
            {
                var exps = exp.Where(j => j.Expenses == null || string.IsNullOrEmpty(j.ExpensesType)).ToList();
                if (exps != null && exps.Count > 0)
                {
                    MsgBox.ShowErrMsg("售后类型和金额不能为空，请检查");
                    return;
                }
                fee = exp.Select(j => j.Expenses.Value).Sum();
            }

            var AfterNo = string.Empty;
            if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                AfterNo = AfterSale.AfterNo;
                AfterSale.ReceiverName = txtReceiverName.Text;
                AfterSale.TradeNo = btnSelect.Text;
                AfterSale.Remark = memoEdit1.Text;
                AfterSale.AfterFee = fee;
                AfterSale.ItemCount = cnt;
                FASControls.SerNoCaller_WL.Calr_AfterSale.Edt(AfterSale);
            }
            else
            {
                AfterNo = SerNoCaller.GetSerNo("售后单").SerialNo;
                UltraDbEntity.T_ERP_AfterSale afs = new UltraDbEntity.T_ERP_AfterSale
                {
                    Creator = this.CurUser,
                    Updator = this.CurUser,
                    Reserved2 = string.Empty,
                    Guid = Guid.NewGuid(),
                    CreateDate = Ultra.Win.Core.Common.TimeSync.Default.CurrentSyncTime,
                    UpdateDate = Ultra.Win.Core.Common.TimeSync.Default.CurrentSyncTime,
                    AfterNo = AfterNo,
                    TradeNo = btnSelect.Text,
                    ReceiverName = txtReceiverName.Text,
                    ItemCount = cnt,
                    Remark = memoEdit1.Text,
                    AfterFee = fee,
                    ImageSession = ImgSession
                };
                FASControls.SerNoCaller_WL.Calr_AfterSale.Add(afs);
            }
            if (!isAudit)
            {
                SaveItem(AfterNo);
            }
            SaveExp(AfterNo);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();

        }

        private void SaveExp(string AfterNo)
        {
            FASControls.SerNoCaller_WL.Calr_Expenses.ExecSql(" delete from T_ERP_Expenses where FromNo = @0 ", AfterNo);
            var ds = gcExpenses.GetDataSource<UltraDbEntity.T_ERP_Expenses>();
            if (ds == null || ds.Count < 1) return;
            ds.ForEach(j =>
            {
                j.Guid = Guid.NewGuid();
                j.FromNo = AfterNo;
                j.Creator = this.CurUser;
                j.Updator = this.CurUser;
                j.Reserved1 = 0;
                j.Reserved2 = string.Empty;
                j.Reserved3 = false;
            });
            FASControls.SerNoCaller_WL.Calr_Expenses.Add(ds);
        }

        private void SaveItem(string AfterNo)
        {
            FASControls.SerNoCaller_WL.Calr_ItemResponsible.ExecSql(@"delete a from T_ERP_ItemResponsible a
                                                                    join T_ERP_AfterSalaItem b on a.ItemGuid = b.Guid
                                                                    where b.AfterNo = @0 ", AfterNo);
            FASControls.SerNoCaller_WL.Calr_AfterSalaItem.ExecSql(" delete from T_ERP_AfterSalaItem where AfterNo = @0 ", AfterNo);
            ItemResps = ItemResps ?? new List<T_ERP_ItemResponsible>();
            var ds = gcOrder.GetDataSource<UltraDbEntity.T_ERP_AfterSalaItem>().Where(j => j.UISelected).ToList();
            ds.ForEach(j => {
                j.AfterNo = AfterNo;
                j.TradeNo = btnSelect.Text;
                j.Creator = this.CurUser;
                j.Updator = this.CurUser;
                j.Reserved1 = 0;
                j.Reserved2 = string.Empty;
                j.Reserved3 = false;
                j.IsRefund = j.IsRefund == null?false:j.IsRefund.Value;
                j.IsRetGoods = j.IsRetGoods == null ? false : j.IsRetGoods.Value;
                j.IsPatch = j.IsPatch == null ? false : j.IsPatch.Value;
                if (!string.IsNullOrEmpty(j.Responsible))
                {
                    var reps = j.Responsible.Split(',').ToList();
                    reps.ForEach(k =>
                    {
                        var ir = new T_ERP_ItemResponsible
                        {
                            Guid = Guid.NewGuid(),
                            Creator = this.CurUser,
                            Updator = this.CurUser,
                            Remark = string.Empty,
                            Reserved1 = 0,
                            Reserved2 = string.Empty,
                            Reserved3 = false,
                            ItemGuid = j.Guid,
                            ResponsibleName = k.Trim()
                        };
                        ItemResps.Add(ir);
                    });
                }
                
            });
            FASControls.SerNoCaller_WL.Calr_AfterSalaItem.Add(ds);
            FASControls.SerNoCaller_WL.Calr_ItemResponsible.Add(ItemResps);
        }

        private void btnAddAddr_Click(object sender, EventArgs e)
        {
            var ds = gcOrder.GetDataSource<UltraDbEntity.T_ERP_AfterSalaItem>();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("请先选择单据"); return; }

            ds = ds.Where(j => j.UISelected).ToList();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("请先选择商品信息"); return; }
            
            var rcds = gcExpenses.GetDataSource<T_ERP_Expenses>();
            rcds = rcds ?? new List<T_ERP_Expenses>();

            var rcd = new T_ERP_Expenses()
            {
                Guid = Guid.NewGuid(), 
                Creator = this.CurUser,
                Updator = this.CurUser,
                Remark = string.Empty,
                Reserved1 = 0,
                Reserved2 = string.Empty,
                Reserved3 = false
            };
            rcds.Add(rcd);
            gcExpenses.DataSource = rcds;
            gcExpenses.RefreshDataSource();
        }

        private void btnDelAddr_Click(object sender, EventArgs e)
        {
            gcExpenses.RemoveSelected();
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var vw = new SelectProdTrdView();
            if (vw.ShowDialog() == DialogResult.OK)
            {
                btnSelect.Text = vw.Trade.TradeNo;
                txtReceiverName.Text = vw.Trade.ReceiverName;
                LoadItems(vw.Trade.TradeNo);
            }
        }

        private void LoadItems(string trdNo)
        {
            gcOrder.DataSource = SerNoCaller.Calr_Order.Get(" where tradeno=@0", trdNo).MapTo<List<T_ERP_Order>, List<T_ERP_AfterSalaItem>>();
        }

        private void repChkEdit_EditValueChanged(object sender, EventArgs e)
        {
            //var ds = gcOrder.GetFocusedDataSource<UltraDbEntity.T_ERP_AfterSalaItem>();
            //if (ds == null) return;
            //if (ds.Guid == Guid.Empty) ds.Guid = Guid.NewGuid();
            //var rb = repChkEdit.GetCheckedItems();
            //if (rb == null) return;
            //ItemResps = ItemResps ?? new List<T_ERP_ItemResponsible>();
            //ItemResps = ItemResps.Where(j => j.ItemGuid != ds.Guid).ToList();
            //var reps = rb.ToString().Split(',').ToList();
            //reps.ForEach(j => {
            //    var ir = new T_ERP_ItemResponsible
            //    {
            //        Guid = Guid.NewGuid(),
            //        Creator = this.CurUser,
            //        Updator = this.CurUser,
            //        Remark = string.Empty,
            //        Reserved1 = 0,
            //        Reserved2 = string.Empty,
            //        Reserved3 = false,
            //        ItemGuid = ds.Guid,
            //        ResponsibleName = j.Trim()
            //    };
            //    var flt = ItemResps.Where(k => k.ResponsibleName == j.Trim());
            //    if (flt == null || flt.Count() < 1)
            //        ItemResps.Add(ir);
            //});
        }

        private void gvExpenses_ShownEditor(object sender, EventArgs e)
        {
            //var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //if (gv.FocusedColumn.FieldName == "RespName")
            //{
            //    var grd = gv.ActiveEditor as GridLookUpEdit;
            //    var ds = gcOrder.GetDataSource<UltraDbEntity.T_ERP_AfterSalaItem>();
            //    if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("请先选择单据"); return; }

            //    ds = ds.Where(j => j.UISelected).ToList();
            //    if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("请先选择商品信息"); return; }

            //    var resps = new List<string>();
            //    ds.ForEach(j =>
            //    {
            //        if (!string.IsNullOrEmpty(j.Responsible))
            //        {
            //            var reps = j.Responsible.Split(',').ToList();
            //            reps.ForEach(k =>{
            //                resps.Add(k.Trim());
            //            });
            //        }
            //    });
            //    resps = resps.Distinct().ToList();
            //    var flt = Resps.Where(j => resps.Contains(j.ResponsibleName)).ToList();
            //    grd.Properties.DataSource = flt;
            //}
            
        }

        private void repResp_QueryPopUp(object sender, CancelEventArgs e)
        {
            var grd = sender as GridLookUpEdit;

            var ds = gcOrder.GetDataSource<UltraDbEntity.T_ERP_AfterSalaItem>();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("请先选择单据"); return; }

            ds = ds.Where(j => j.UISelected).ToList();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("请先选择商品信息"); return; }

            var resps = new List<string>();
            ds.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Responsible))
                {
                    var reps = j.Responsible.Split(',').ToList();
                    reps.ForEach(k =>
                    {
                        resps.Add(k.Trim());
                    });
                }
            });
            resps = resps.Distinct().ToList();
            var flt = Resps.Where(j => resps.Contains(j.ResponsibleName)).ToList();
            grd.Properties.DataSource = flt;
        }

    }
}
