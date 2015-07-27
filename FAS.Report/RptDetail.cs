using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UltraDbEntity;
using System.Collections.Generic;

namespace FAS.Report
{
    public partial class RptDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public RptDetail()
        {
            InitializeComponent();
        }

        public object _Detail { get; set; }

        public void BindPrintData()
        {
            this.DataSource = _Detail;
            this.xrNo.DataBindings.Add("Text", DataSource, "RNo");
            this.xrOuterIid.DataBindings.Add("Text", DataSource, "OuterIid");
            this.xrOuterSkuId.DataBindings.Add("Text", DataSource, "OuterSkuId");
            this.xrRemark.DataBindings.Add("Text", DataSource, "Remark");
            this.xrNum.DataBindings.Add("Text", DataSource, "Num");            

        }

    }

}
