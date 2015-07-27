using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.FASControls;
using Ultra.Surface.Form;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using Ultra.Surface.Common;
using Ultra.Win.Core.Common;
using DevExpress.XtraEditors;

namespace FAS.Trade {
    public partial class TrdEdtView : DialogViewEx {
        public T_ERP_Trade Trade { get; set; }

        private List<T_ERP_Order> DelOdrs { get; set; }

        private string TradeNo;

        public TrdEdtView() {
            InitializeComponent();
        }

        private void TrdEdtView_Load(object sender, EventArgs e) {
            InitEvent();
            LoadData();
        }

        private void InitEvent() {
            rspItem.EditValueChanged += rspItem_EditValueChanged;
            rspNum.Validating += rspNum_Validating;

            gvOrder.OptionsView.ShowAutoFilterRow = false;
        }

        private void LoadData() {
            companyGridEdit1.LoadFromCache();

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New) {
                gcOrder.DataSource = new List<T_ERP_Order>();
                dateCreated.DateTime = TimeSync.Default.CurrentSyncTime;
                TradeNo = SerNoCaller.GetSerNo("订单").SerialNo;
            } else {
                TradeNo = Trade.TradeNo;
                gcOrder.DataSource = SerNoCaller.Calr_Order.Get(" where tradeno=@0", TradeNo);

                txtReceiverName.Text = Trade.ReceiverName;
                txtRemark.Text = Trade.Remark;
                dateCreated.DateTime = Trade.Created;
                dateProDelDate.DateTime = Trade.ProDelDate;
                chkIsUrgent.Checked = Trade.IsUrgent;
                txtRecvOprUser.Text = Trade.RecvOprUser;

                txtLogisAddress.Text = Trade.LogisAddress;
                txtLogisName.Text = Trade.LogisName;
                txtReceiverState.Text = Trade.ReceiverState;
                txtReceiverCity.Text = Trade.ReceiverCity;
                txtReceiverDistrict.Text = Trade.ReceiverDistrict;
                txtReceiverAddress.Text = Trade.ReceiverAddress;
                txtReceiverMobile.Text = Trade.ReceiverMobile;

                companyGridEdit1.SetSelectedValue(companyGridEdit1.DataSource.FirstOrDefault(k=>k.CompanyName==Trade.CompanyName));
            }
            var maters = SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%皮%' ");
            DelOdrs = new List<T_ERP_Order>();
            rspItem.DataSource = new Ultra.FASControls.BusControls.ItemGridEdit().LoadFromCache();// SerNoCaller.Calr_Item.Get(" where isdel=0 and isusing=1");
            rspSurface.DataSource = maters.Where(k=>k.MaterialName.Contains("真皮") && !k.MaterialName.Contains("仿真")).ToList(); 
            //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache("where isusing=1 and MaterialName like '%真皮%' and MaterialName not like '%仿真%'"); //SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%真皮%' and MaterialName not like '%仿真%' ");
            rspImitSurface.DataSource = maters.Where(k => k.MaterialName.Contains("仿皮")).ToList(); 
                //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache("where isusing=1 and MaterialName like '%仿皮%'");// SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%仿皮%' ");
            rspGenSurface.DataSource = maters.Where(k => k.MaterialName.Contains("仿真")).ToList(); 
                //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache(" where isusing=1 and MaterialName like '%仿真%' ");// SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%仿真%' ");
            rspEnvSurface.DataSource = maters.Where(k => k.MaterialName.Contains("环保")).ToList(); 
            //new Ultra.FASControls.BusControls.MaterialGridEdt().LoadFromCache(" where isusing=1 and MaterialName like '%环保%'");// SerNoCaller.Calr_Material.Get(" where isusing=1 and MaterialName like '%环保%' ");
            rspTradeMark.DataSource = new Ultra.FASControls.BusControls.TradeMarkGridEdt().LoadFromCache();// SerNoCaller.Calr_TradeMark.Get(" where isusing=1 ");
        }

        void rspNum_Validating(object sender, CancelEventArgs e) {
            var rsp = sender as SpinEdit;
            if (rsp.Value < 1) {
                e.Cancel = true;
            }
        }

        void rspItem_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var item = view.GetFocusedDataSource<T_ERP_Item>();
            if (item == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            odr.ItemName = item.ItemName;
            odr.SkuName = item.SkuName;
            odr.OuterIid = item.OuterIid;
            odr.OuterSkuId = item.OuterSkuId;
            odr.Num = 1;
            odr.Color = item.Color;
            odr.Material = item.Material;
            odr.Surface = item.Surface;
            odr.SurfaceNums = item.SurfaceNums;
            odr.IsDynamicAdd = true;
            odr.Direction = item.Direction;
            gcOrder.RefreshDataSource();
        }

        private void btnAddItem_Click(object sender, EventArgs e) {
            var odr = new T_ERP_Order();
            odr.Guid = Guid.NewGuid();
            odr.TradeNo = TradeNo;
            odr.Creator = odr.Updator = this.CurUser;
            odr.Reserved2 = odr.Remark = string.Empty;

            var odrs = gcOrder.GetDataSource<T_ERP_Order>();
            odrs = odrs ?? new List<T_ERP_Order>();

            odrs.Add(odr);

            gcOrder.RefreshDataSource();
        }

        private void btnDelItem_Click(object sender, EventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;

            var odrs = gcOrder.GetDataSource<T_ERP_Order>();
            odrs = odrs ?? new List<T_ERP_Order>();

            odrs.Remove(odr);
            if (!DelOdrs.Any(k => k.Guid == odr.Guid)) {
                DelOdrs.Add(odr);
            }
            gcOrder.RefreshDataSource();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate()) return;

            Trade = Trade ?? new T_ERP_Trade();

            Trade.Created = dateCreated.DateTime;
            Trade.Creator = Trade.Updator = this.CurUser;
            Trade.Reserved2 = string.Empty;
            Trade.Remark = txtRemark.Text;
            Trade.IsUrgent = chkIsUrgent.Checked;
            Trade.ProDelDate = dateProDelDate.DateTime;
            Trade.ReceiverName = txtReceiverName.Text;
            Trade.RecvOprUser = txtRecvOprUser.Text;

            Trade.LogisAddress = txtLogisAddress.Text;
            Trade.LogisName = txtLogisName.Text;
            Trade.ReceiverState = txtReceiverState.Text;
            Trade.ReceiverCity=txtReceiverCity.Text;
            Trade.ReceiverDistrict=txtReceiverDistrict.Text;
            Trade.ReceiverAddress = txtReceiverAddress.Text;
            Trade.ReceiverMobile = txtReceiverMobile.Text;

            var comp=companyGridEdit1.GetSelectedValue();
            if(comp!=null){
                Trade.CompanyName = comp.CompanyName;
                Trade.CompanyMobile = comp.CompanyMobile;
                Trade.CompanyAddress = comp.CompanyAddress;
            }


            var odrs = gcOrder.GetDataSource<T_ERP_Order>();
            if (odrs == null || odrs.Count < 1) {
                MsgBox.ShowErrMsg("没有添加商品，不能保存!");
                return;
            }

            if (odrs.Any(k => string.IsNullOrEmpty(k.ItemName))) {
                MsgBox.ShowErrMsg("必须选择商品!");
                return;
            }

            if (odrs.Any(k => string.IsNullOrEmpty(k.TradeMark))) {
                MsgBox.ShowErrMsg("必须选择商商标!");
                return;
            }
            
            //if (odrs.Any(k => string.IsNullOrEmpty(k.Surface))) {
            //    MsgBox.ShowErrMsg("商品必须选择皮料!");
            //    return;
            //}

            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New) {
                Trade.TradeNo = TradeNo;
                Trade.Guid = Guid.NewGuid();

                var rd=SerNoCaller.Calr_Order.Add(odrs);
                rd = SerNoCaller.Calr_Trade.Add(Trade);

            } else {

                var rd =SerNoCaller.Calr_Order.ExecSql(" delete t_erp_order where tradeno=@0",Trade.TradeNo);

                rd=SerNoCaller.Calr_Order.Add(odrs);
                rd=SerNoCaller.Calr_Trade.Edt(Trade);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void rspSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            odr.Surface = mater.MaterialName;
            odr.SurfaceNums = mater.MaterialNo;

            gcOrder.RefreshDataSource();

            //自动选择仿皮
            //var imitView = rspImitSurface.DataSource;
            var imitmater = (rspImitSurface.DataSource as List<T_ERP_Material>)
                .FirstOrDefault(k => k.MaterialName == mater.MaterialName.Substring(0,mater.MaterialName.Length-2)+"仿皮");
            if (imitmater == null) {
                odr.ImitSurface = string.Empty;
                odr.ImitSurfaceNums = string.Empty;
                gcOrder.RefreshDataSource();
                return;
            }
            if (odr == null) return;
            odr.ImitSurface = imitmater.MaterialName;
            odr.ImitSurfaceNums = imitmater.MaterialNo;

            gcOrder.RefreshDataSource();
        }

        private void rspImitSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            odr.ImitSurface = mater.MaterialName;
            odr.ImitSurfaceNums = mater.MaterialNo;
            gcOrder.RefreshDataSource();
        }

        private void rspGenSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            odr.GenuineSurface = mater.MaterialName;
            odr.GenuineSurfaceNums = mater.MaterialNo;
            gcOrder.RefreshDataSource();
        }

        private void rspEnvSurface_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var mater = view.GetFocusedDataSource<T_ERP_Material>();
            if (mater == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            odr.EnvSurface = mater.MaterialName;
            odr.EnvSurfaceNums = mater.MaterialNo;
            gcOrder.RefreshDataSource();
        }

        private void rspTradeMark_EditValueChanged(object sender, EventArgs e) {
            var gridlookup = sender as GridLookUpEdit;
            var view = gridlookup.Properties.View;
            var tm = view.GetFocusedDataSource<T_ERP_TradeMark>();
            if (tm == null) return;
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            odr.TradeMark = tm.TradeMark;
            gcOrder.RefreshDataSource();
        }

        private void rspUpLoadImg_Click(object sender, EventArgs e) {
            var odr = gcOrder.GetFocusedDataSource<T_ERP_Order>();
            if (odr == null) return;
            var vw = new UploadImgView();
            vw.Order = odr;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
        }

    }
}
