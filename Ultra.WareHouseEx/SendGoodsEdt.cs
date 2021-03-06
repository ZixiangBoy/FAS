﻿using System;
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
using Ultra.Win.Core.Common;

namespace Ultra.WareHouseEx
{
    public partial class SendGoodsEdt : DialogViewEx
    {
        public SendGoodsEdt()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_Delivery Delivery;
        public bool isAudit;
        public string OprUser;
        public string LogisAddress;

        private void SendGoodsEdt_Load(object sender, EventArgs e)
        {
            gvItem.OptionsView.ShowAutoFilterRow = false;
            gvAddr.OptionsView.ShowAutoFilterRow = false;
            lookupPost.Properties.DataSource = FASControls.SerNoCaller_WL.Calr_PostFeeType.Get(" where isnull(IsUsing,0) = 1 ");
            if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                LogisAddress = Delivery.LogisAddress;
                OprUser = Delivery.Reserved2;
                txtSendNo.Text = Delivery.SendNo;
                txtReceiverName.Text = Delivery.ReceiverName;
                dtSend.EditValue = Delivery.SendDate;
                txtReceiverPhone.Text = Delivery.ReceiverPhone;
                txtLogisName.Text = Delivery.LogisName;
                txtLogisNo.Text = Delivery.LogisNo;
                txtLogisFee.EditValue = Delivery.LogisFee;
                txtDriver.Text = Delivery.Driver;
                lookupPost.Text = Delivery.PostFeeType;
                gcItem.DataSource = FASControls.SerNoCaller_WL.Calr_DeliveryItem.Get(" where SendNo = @0 ", Delivery.SendNo);
                gcAddr.DataSource = FASControls.SerNoCaller_WL.Calr_DeliveryAddr.Get(" where SendNo = @0 ", Delivery.SendNo);
            }
            if (isAudit) {
                dtSend.Properties.ReadOnly = true;
                gvItem.OptionsBehavior.Editable = false;
                gvAddr.OptionsBehavior.Editable = false;
                btnAddItem.Enabled = false;
                btnDelItem.Enabled = false;
                btnAddAddr.Enabled = false;
                btnDelAddr.Enabled = false;
            }
            if (string.IsNullOrEmpty(dtSend.Text))
            {
                dtSend.DateTime = TimeSync.Default.CurrentSyncTime;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var ds = gcItem.GetDataSource<UltraDbEntity.T_ERP_DeliveryItem>();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("没有选择任何商品数据！保存无效！"); return; }
            var dss = ds.Where(j => j.SendNum < 0 || j.SendNum > j.Qty).ToList();
            if (dss != null && dss.Count > 0)
            {
                MsgBox.ShowErrMsg("出库数不能小于0或大于当前库存数");
                return;
            }
            var ads = gcAddr.GetDataSource<UltraDbEntity.T_ERP_DeliveryAddr>();
            if (ads == null || ads.Count < 1) { MsgBox.ShowErrMsg("请添加收货地址"); return; }
            var adss = ads.Where(j => string.IsNullOrEmpty(j.SuppName)).ToList();
            if (adss != null && adss.Count > 0)
            {
                MsgBox.ShowErrMsg("收货地址收货方不能为空");
                return;
            }
            if (string.IsNullOrEmpty(dtSend.Text))
            {
                MsgBox.ShowErrMsg("发货时间不能为空");
                return;
            }
            
            var cnt = ds.Select(j => j.SendNum).Sum();
            if (cnt < 1)
            {
                MsgBox.ShowErrMsg("总发货数量为0 请检查");
                return;
            }
            var SendNo = string.Empty;
            if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                SendNo = Delivery.SendNo;
                Delivery.Reserved2 = OprUser == null ? "" : OprUser;
                Delivery.ReceiverName = txtReceiverName.Text;
                Delivery.SendDate = dtSend.DateTime;
                Delivery.ReceiverPhone = txtReceiverPhone.Text;
                Delivery.LogisName = txtLogisName.Text;
                Delivery.LogisNo = txtLogisNo.Text;
                Delivery.LogisFee = Convert.ToDecimal(txtLogisFee.EditValue);
                Delivery.Driver = txtDriver.Text;
                Delivery.ItemCount = cnt;
                Delivery.Remark = memoEdit1.Text;
                Delivery.PostFeeType = lookupPost.Text;
                Delivery.LogisAddress = LogisAddress;
                FASControls.SerNoCaller_WL.Calr_Delivery.Edt(Delivery);
            }
            else
            {
                SendNo = SerNoCaller.GetSerNo("出库单").SerialNo;
                //主表信息
                UltraDbEntity.T_ERP_Delivery dely = new UltraDbEntity.T_ERP_Delivery
                {
                    Creator = this.CurUser,
                    Updator = this.CurUser,
                    Reserved2 = OprUser,
                    Guid = Guid.NewGuid(),
                    CreateDate = Ultra.Win.Core.Common.TimeSync.Default.CurrentSyncTime,
                    UpdateDate = Ultra.Win.Core.Common.TimeSync.Default.CurrentSyncTime,
                    SendNo = SendNo,
                    ReceiverName = txtReceiverName.Text,
                    SendDate = dtSend.DateTime,
                    ReceiverPhone = txtReceiverPhone.Text,
                    LogisName = txtLogisName.Text,
                    LogisNo = txtLogisNo.Text,
                    LogisFee = Convert.ToDecimal(txtLogisFee.EditValue),
                    Driver = txtDriver.Text,
                    ItemCount = cnt,
                    Remark = memoEdit1.Text,
                    LogisAddress = LogisAddress,
                    PostFeeType = lookupPost.Text
                };
                FASControls.SerNoCaller_WL.Calr_Delivery.Add(dely);
            }
            if (!isAudit)
            {
                SaveItem(SendNo);
                SaveAddr(SendNo);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();

        }

        private void SaveAddr(string SendNo)
        {
            FASControls.SerNoCaller_WL.Calr_DeliveryItem.ExecSql(" delete from T_ERP_DeliveryAddr where SendNo = @0 ", SendNo);
            var ds = gcAddr.GetDataSource<UltraDbEntity.T_ERP_DeliveryAddr>();
            if (ds == null || ds.Count < 1) return;
            ds.ForEach(j => j.SendNo = SendNo);
            FASControls.SerNoCaller_WL.Calr_DeliveryAddr.Add(ds);
        }

        private void SaveItem(string SendNo)
        {
            FASControls.SerNoCaller_WL.Calr_DeliveryAddr.ExecSql(" delete from T_ERP_DeliveryItem where SendNo = @0 ", SendNo);
            var ds = gcItem.GetDataSource<UltraDbEntity.T_ERP_DeliveryItem>().Where(j => j.SendNum > 0).ToList();
            ds.ForEach(j => {
                j.Guid = Guid.NewGuid();
                j.SendNo = SendNo;
                j.Creator = this.CurUser;
                j.Updator = this.CurUser;
                j.Reserved1 = 0;
                j.Reserved2 = string.Empty;
                j.Reserved3 = false;
                j.Remark = j.Remark == null ? "" : j.Remark;
            });
            FASControls.SerNoCaller_WL.Calr_DeliveryItem.Add(ds);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            ItemSelectView vw = new ItemSelectView();
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ds = gcItem.GetDataSource<UltraDbEntity.T_ERP_DeliveryItem>();
                ds = ds ?? new List<UltraDbEntity.T_ERP_DeliveryItem>();
                if (vw.Items == null || vw.Items.Count < 1) return;
                vw.Items.ForEach(et =>
                {
                    var mch = ds.Where(j => j.OuterIid == et.OuterIid
                        && j.OuterSkuId == et.OuterSkuId && j.SuppName == et.SuppName).FirstOrDefault();
                    if (mch != null) mch.SendNum += 1;
                    else { ds.Insert(0, et); }
                    gcItem.DataSource = ds;
                    gcItem.RefreshDataSource();
                });

                var trdNo = ds.Select(j => j.PurchNo);
                var trd = FASControls.SerNoCaller.Calr_Trade.Get(" where TradeNo in (@0)", trdNo);
                if(trd==null||trd.Count<1)return;

                var logisName = string.Join(",", trd.Select(j => j.LogisName));
                if (string.IsNullOrEmpty(txtLogisName.Text))
                {
                    txtLogisName.Text = logisName;
                    txtReceiverPhone.Text = string.Join(",", trd.Select(j => j.ReceiverMobile));
                }
                    
                var addr = trd.MapTo<List<T_ERP_Trade>, List<T_ERP_DeliveryAddr>>();
                var rcds = gcAddr.GetDataSource<T_ERP_DeliveryAddr>();
                rcds = rcds ?? new List<T_ERP_DeliveryAddr>();
                addr.ForEach(j =>
                {
                    j.SuppName = j.ReceiverName;
                    rcds.Add(j);
                });
                gcAddr.DataSource = rcds;
                gcAddr.RefreshDataSource();
                refreshSupp();
            }
        }

        private void refreshSupp()
        {
            var ds = gcAddr.GetDataSource<UltraDbEntity.T_ERP_DeliveryAddr>();
            if (ds == null || ds.Count < 1) return;
            List<string> supps = new List<string>();
            ds.ForEach(et =>
            {
                if (!string.IsNullOrEmpty(et.SuppName) && !supps.Contains(et.SuppName))
                    supps.Add(et.SuppName);
            });
            if (supps.Count > 0)
                txtReceiverName.Text = string.Join(",", supps);

        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            gcItem.RemoveSelected();
        }

        private void btnAddAddr_Click(object sender, EventArgs e)
        {
            var ds = gcItem.GetDataSource<UltraDbEntity.T_ERP_DeliveryItem>();
            if (ds == null || ds.Count < 1) { MsgBox.ShowErrMsg("请先选择商品信息"); return; }
            var rcds = gcAddr.GetDataSource<T_ERP_DeliveryAddr>();
            rcds = rcds ?? new List<T_ERP_DeliveryAddr>();

            var rcd = new T_ERP_DeliveryAddr()
            {
                Guid = Guid.NewGuid(),
                Creator = this.CurUser,
                Updator = this.CurUser,
                Reserved1 = 0,
                Reserved2 = string.Empty,
                Reserved3 = false,
                Remark = string.Empty
            };
            rcds.Add(rcd);
            gcAddr.DataSource = rcds;
            gcAddr.RefreshDataSource();
        }

        private void btnDelAddr_Click(object sender, EventArgs e)
        {
            gcAddr.RemoveSelected();
        }

        private void gvAddr_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SuppName")
                refreshSupp();
        }

        private void txtReceiverName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var vw = new SelectProdTrdView();
            if (vw.ShowDialog() == DialogResult.OK)
            {
                txtReceiverName.Text = vw.Trade.ReceiverName;
                OprUser = vw.Trade.RecvOprUser == null ? "" : vw.Trade.RecvOprUser;
                LoadItems(vw.Trade.TradeNo);
            }
        }

        private void LoadItems(string no)
        {
            var item = SerNoCaller_WL.Calr_V_ERP_DeliveryOrder.Get(" select * from V_ERP_DeliveryOrder where PurchNo=@0", no).MapTo<List<V_ERP_DeliveryOrder>, List<T_ERP_DeliveryItem>>();
            gcItem.DataSource = item;
            gcItem.RefreshDataSource();
            if (item == null || item.Count < 1) return;
            var trdNo = item.Select(j => j.PurchNo);
            var trd = FASControls.SerNoCaller.Calr_Trade.Get(" where TradeNo in (@0)", trdNo);
            if (trd == null || trd.Count < 1) return;

            var logisName = string.Join(",", trd.Select(j => j.LogisName));
            LogisAddress = string.Join(",", trd.Select(j => j.LogisAddress));
            if (string.IsNullOrEmpty(txtLogisName.Text))
                txtLogisName.Text = logisName;
            var addr = trd.MapTo<List<T_ERP_Trade>, List<T_ERP_DeliveryAddr>>();
            addr.ForEach(j =>
            {
                j.SuppName = j.ReceiverName;
            });
            gcAddr.DataSource = addr;
            gcAddr.RefreshDataSource();
        }

        private void gvItem_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gv == null) return;
            var tt = gv.GetRow(e.RowHandle) as T_ERP_DeliveryItem;
            if (tt == null) return;
            if (tt.Qty<1)
                e.Appearance.BackColor = Color.FromArgb(255, 240, 100, 192);
        }

    }
}
