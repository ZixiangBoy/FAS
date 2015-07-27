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
    public partial class RptMd : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMd()
        {
            InitializeComponent();
        }

        public void BindPrintData(FHPrintInfo prt)
        {
            this.DataSource = prt.Items;
            this.xrtBNo.DataBindings.Add("Text", prt.Delivery, "SendNo");
            this.xtrReceiverName.DataBindings.Add("Text", prt.Delivery, "ReceiverName");

            this.xrPostFeeType.DataBindings.Add("Text", prt.Delivery, "PostFeeType");
            this.xrReceiverPhone.DataBindings.Add("Text", prt.Addr, "ReceiverPhone");
            this.xrReceiverAddress.DataBindings.Add("Text", prt.Addr, "Remark");
            this.xrLogisName.DataBindings.Add("Text", prt.Delivery, "LogisName");
            this.xrLogisAddress.DataBindings.Add("Text", prt.Delivery, "LogisAddress");

            this.xrPrintTime.DataBindings.Add("Text", prt.Delivery, "UpdateDate");
            this.xrOrderTime.DataBindings.Add("Text", prt.Delivery, "CreateDate");
            this.xrDridver.DataBindings.Add("Text", prt.Delivery, "Driver");
            this.xrRecvOprUser.DataBindings.Add("Text", prt.Delivery, "Reserved2");
            this.xrXh.DataBindings.Add("Text", DataSource, "Reserved1");
            this.xrOuterIid.DataBindings.Add("Text", DataSource, "OuterIid");
            this.xrOuterSkuId.DataBindings.Add("Text", DataSource, "OuterSkuId");
            this.xrNum.DataBindings.Add("Text", DataSource, "SendNum");
        }

    }

}


