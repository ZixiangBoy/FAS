using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UltraDbEntity;
using System.Collections.Generic;

namespace FAS.Report
{
    public partial class RptCDProce : DevExpress.XtraReports.UI.XtraReport
    {
        public RptCDProce()
        {
            InitializeComponent();
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
        }

        //public object _Detail { get; set; }

        public void BindPrintData()
        {
            //this.DataSource = _Detail;

            xrCreated.DataBindings.Add("Text", DataSource, "Created");
            xrTradeNo.DataBindings.Add("Text", DataSource, "TradeNo");
            xrCompanyName.DataBindings.Add("Text", DataSource, "CompanyName");
            xrReceiverName.DataBindings.Add("Text", DataSource, "ReceiverName");
            xrOuterIid.DataBindings.Add("Text", DataSource, "OuterIid");
            xrOuterSkuId.DataBindings.Add("Text", DataSource, "OuterSkuId");
            xrDirection.DataBindings.Add("Text", DataSource, "Direction");
            xrTradeMark.DataBindings.Add("Text", DataSource, "TradeMark");
            xrNum.DataBindings.Add("Text", DataSource, "Num");
            xrSurface.DataBindings.Add("Text", DataSource, "Surface");
            xr车裁.DataBindings.Add("Text", DataSource, "车裁");
            xr打包.DataBindings.Add("Text", DataSource, "打包");
            xr打底.DataBindings.Add("Text", DataSource, "打底");
            xr扣布.DataBindings.Add("Text", DataSource, "扣布");
            xr围边.DataBindings.Add("Text", DataSource, "围边");

        }

    }

}
