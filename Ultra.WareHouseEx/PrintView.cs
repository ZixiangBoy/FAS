using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using FAS.Report;
using Ultra.Win.Core.Common;
using DevExpress.XtraReports.UI;

namespace Ultra.WareHouseEx
{
    public partial class PrintView : BaseSurface
    {
        public PrintView()
        {
            InitializeComponent();
        }

        XtraReport print = new RptMd();
        public List<T_ERP_Delivery> Deliverys { get; set; }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<FHPrintInfo> printinfoys = new List<FHPrintInfo>();
            print.Pages.Clear();
            print.PrintingSystem.ClearContent();
            print.CreateDocument();
            print.Pages.Clear(); print.PrintingSystem.Pages.Clear();

            Deliverys.ForEach(j =>
            {
                FHPrintInfo pi = new FHPrintInfo();
                var addr = FASControls.SerNoCaller_WL.Calr_DeliveryAddr.Get(" where SendNo = @0 ", j.SendNo).FirstOrDefault();
                if (addr != null)
                {
                    addr.Remark = addr.ReceiverDistrict + addr.ReceiverCity + addr.ReceiverState + addr.ReceiverAddress;
                    addr.ReceiverPhone = addr.ReceiverPhone == null ? addr.ReceiverMobile : addr.ReceiverMobile+','+addr.ReceiverPhone;
                }
                var items = FASControls.SerNoCaller_WL.Calr_DeliveryItem.Get(" select * from V_ERP_DeliveryItem where SendNo = @0 ", j.SendNo);
                var xh = 1;
                items.ForEach(k => k.Reserved1 = xh++);
                pi.Items = items;
                j.UpdateDate = TimeSync.Default.CurrentSyncTime;
                j.CreateDate = items.FirstOrDefault().UpdateDate;
                pi.Delivery = j;
                pi.Addr = addr;
                printinfoys.Add(pi);
            });

            printinfoys.ForEach(k =>
            {
                var rpt = new RptMd();
                rpt.BindPrintData(k);
                rpt.CreateDocument();                
                print.Pages.AddRange(rpt.Pages);
            });

            print.PrintingSystem.StartPrint -= print_StartPrint;
            print.PrintingSystem.StartPrint += print_StartPrint;

            print.Print(cmbPrinter.Text);

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void PrintView_Load(object sender, EventArgs e)
        {
            this.cmbPrinter.LoadPrinter();
            this.gcUnAudit.DataSource = Deliverys;
        }

        void print_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = (short)labelSpinEdit1.Value;//设置打印份数
            e.PrintDocument.PrinterSettings.Collate = false;//打印份数，不自动分页
        }

        private void gvUnAudit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            T_ERP_Delivery et = gcUnAudit.GetFocusedDataSource<T_ERP_Delivery>();
            if(et==null)
                gcItem.DataSource = null;
            else
                gcItem.DataSource = FASControls.SerNoCaller_WL.Calr_DeliveryItem.Get(" where SendNo = @0 ", et.SendNo);
        }
    }
}
