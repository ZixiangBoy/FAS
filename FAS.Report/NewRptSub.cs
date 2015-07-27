using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UltraDbEntity;
using System.Collections.Generic;
using System.Linq;

namespace FAS.Report
{
    public partial class NewRptSub : DevExpress.XtraReports.UI.XtraReport
    {
        public NewRptSub()
        {
            InitializeComponent();
        }

        private List<ProcePrtInfo> _Prts;

        public NewRptSub(List<ProcePrtInfo> prts)
        {
            InitializeComponent();
            _Prts = prts;
        }

        public void BindData()
        {
            DataSource = _Prts;
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var PrtOrder=GetCurrentColumnValue("PrtOrder") as PrtOrder;
            var Detail=GetCurrentColumnValue("Detail") as List<T_ERP_OrderProce>;
            ((ProceRpt)((XRSubreport)sender).ReportSource).Prt = new ProcePrtInfo { PrtOrder=PrtOrder,Detail=Detail };
            ((ProceRpt)((XRSubreport)sender).ReportSource).BindData();
        }

    }
}
