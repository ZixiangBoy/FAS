using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using UltraDbEntity;
using DevExpress.XtraPrinting;

namespace FAS.Report
{
    public partial class RptFH : DevExpress.XtraReports.UI.XtraReport
    {
        public RptFH()
        {
            InitializeComponent();
        }

        public void BindPrintData(FHPrintInfo prt)
        {
            this.DataSource = prt.Items;
            this.xrtBNo.DataBindings.Add("Text", prt.Delivery, "SendNo");
            this.xtrReceiverName.DataBindings.Add("Text", prt.Delivery, "ReceiverName");
            this.xrReceiveTime.DataBindings.Add("Text", prt.Delivery, "UpdateDate");
            this.xrComServMobile.DataBindings.Add("Text", prt.Delivery, "ReceiverPhone");
            this.xrReceiverAddress.DataBindings.Add("Text", prt.Delivery, "Reserved2");

            this.xrLogisticsCom.DataBindings.Add("Text", prt.Delivery, "LogisName");
            this.xrSum.DataBindings.Add("Text", prt.Delivery, "ItemCount");//产品数量总和
            if (string.IsNullOrEmpty(xrRemarkMain.Text))
                this.xrRemarkMain.DataBindings.Add("Text", prt.Delivery, "Remark");

            this.xrPrintTime.DataBindings.Add("Text", prt.Delivery, "UpdateDate");
            this.xrXh.DataBindings.Add("Text", DataSource, "Reserved1");
            this.xrOuerIid.DataBindings.Add("Text", DataSource, "OuterIid");
            this.xrOuterSkuId.DataBindings.Add("Text", DataSource, "OuterSkuId");//SkuName SkuPropertiesName
            this.xrGenuineSurface.DataBindings.Add("Text", DataSource, "GenuineSurface");
            this.xrNum.DataBindings.Add("Text", DataSource, "SendNum");
            this.xrRemark.DataBindings.Add("Text", DataSource, "Remark");
            this.xrSurface.DataBindings.Add("Text", DataSource, "Surface");
        }

    }


    public class FHPrintInfo
    {
        public T_ERP_Delivery Delivery { get; set; }
        public List<T_ERP_DeliveryItem> Items { get; set; }
        public T_ERP_DeliveryAddr Addr { get; set; }
    }
}


