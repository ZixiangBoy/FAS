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
using Ultra.FASControls;
using DevExpress.XtraEditors;
using Ultra.Surface.Common;
using Ultra.Common;
using FAS.Report;
using MoreLinq;
using Ultra.Win.Core.Common;
using DevExpress.XtraPrinting;
using Ultra.Web.Core.Common;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace FAS.Trade {
    public partial class PrintPrdView : BaseSurface {

        bool PrtPreView = false;

        public T_ERP_TradePrd TradePrd { get; set; }

        public Guid PrintSession { get; set; }

        public PrintPrdView() {
            InitializeComponent();
        }

        private void PrintPrdView_Load(object sender, EventArgs e) {
            var ps = SerNoCaller.Calr_Procedure.Get(" where isusing=1");
            cmbProce.Properties.Items.AddRange(ps.Select(k => k.ProcedureName).ToArray());

            rspWorker.DataSource = SerNoCaller_WL.Calr_Worker.Get();

            RefreashPrintOrder();
        }

        private void btnPrt_Click(object sender, EventArgs e) {
            PrtPreView = false;
            PrintSession = Guid.NewGuid();
            var dlg = new DevExpress.Utils.WaitDialogForm("正在处理打印数据 ...",
             "正在打印");
            //打印单据
            var errflag = false;
            try {               //生成打印的数据
                if (errflag = GenData()) {
                    if (cmbPrtTemp.SelectedItem.ToString().Equals("标准模板")) {
                        //打印单据
                        DoStdPrint(PrtPreView);
                    } else if (cmbPrtTemp.SelectedItem.ToString().Equals("床垫模板")) {
                        DoCDPrint(PrtPreView);
                    }
                }
            } catch (Exception) {
                RefreashPrintOrder();
                throw;
            } finally {
                dlg.Close();
            }
            if (errflag) {
                RefreashPrintOrder();
                MsgBox.ShowMessage("打印完成！");
            }
        }

        private void DoCDPrint(bool PrtPreView) {
            var dt = SqlHelper.ExecuteDataTable(ConnString, CommandType.Text, "select * from V_ERP_PrintOrderProceCD where printsession=@0"
                , new SqlParameter("@0", PrintSession));

            var rpt = new RptCDProce();
            rpt.ShowPrintMarginsWarning = false;
            rpt.DataSource = dt;
            rpt.BindPrintData();
            rpt.PrintingSystem.ShowMarginsWarning = false;            
            SetPrintToolsVisible(rpt);
            if (PrtPreView) {
                rpt.ShowPreview();
            } else {
                rpt.Print();
            }
        }

        void SetPrintToolsVisible(XtraReport rpt) {
            DevExpress.XtraReports.UI.ReportPrintTool mRptPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rpt);//这条语句少了。
            DevExpress.XtraPrinting.PrintingSystemBase mPSB = mRptPrintTool.PrintingSystem;
            mPSB.SetCommandVisibility(new DevExpress.XtraPrinting.PrintingSystemCommand[] 
    { 
        DevExpress.XtraPrinting.PrintingSystemCommand.Background , 
        DevExpress.XtraPrinting.PrintingSystemCommand.ClosePreview ,
            DevExpress.XtraPrinting.PrintingSystemCommand.Customize ,
            DevExpress.XtraPrinting.PrintingSystemCommand.DocumentMap ,
            DevExpress.XtraPrinting.PrintingSystemCommand.File ,
            DevExpress.XtraPrinting.PrintingSystemCommand.FillBackground ,
            DevExpress.XtraPrinting.PrintingSystemCommand.Open ,
            DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup ,
            DevExpress.XtraPrinting.PrintingSystemCommand.Print ,
            DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect ,
            DevExpress.XtraPrinting.PrintingSystemCommand.Save,
            DevExpress.XtraPrinting.PrintingSystemCommand.Watermark,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportCsv,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportGraphic,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportPdf,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportTxt,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx,
            DevExpress.XtraPrinting.PrintingSystemCommand.ExportXps,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendFile,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendMht,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendXls,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx,
            DevExpress.XtraPrinting.PrintingSystemCommand.SendXps,
            DevExpress.XtraPrinting.PrintingSystemCommand.SubmitParameters
        }, DevExpress.XtraPrinting.CommandVisibility.None);
        }

        private void DoStdPrint(bool PrtPreView) {
            var proces = gcOrder.GetDataSource<V_ERP_PrintOrderPrd>().Where(k => k.Num > 0)
                .Select(k => new { k.ProceName, k.Guid, k.ProceUser }).ToList();

            var odrs = SerNoCaller.Calr_V_ERP_PrintOrderProce.Get(" where printsession=@0", PrintSession);
            //var proces = SerNoCaller.Calr_V_ERP_PrintOrderProceDetail.Get(" where printsession=@0", PrintSession);

            var pordrs = odrs.MapTo<List<V_ERP_PrintOrderProce>, List<PrtOrder>>();
            var prts = new List<ProcePrtInfo>();
            pordrs.ForEach(k => {
                prts.Add(new ProcePrtInfo() {
                    PrtOrder = k,
                    Detail = proces.Where(j => k.Guid == j.Guid && !j.ProceName.Equals("木工")).Select(j => new T_ERP_OrderProce { ProceName = j.ProceName, ProceUser = j.ProceUser }).ToList()
                });
                var mg = proces.FirstOrDefault(j => k.Guid == j.Guid && j.ProceName.Equals("木工"));
                if (mg != null) {
                    prts.Add(new ProcePrtInfo() {
                        PrtOrder = k,
                        Detail = new List<T_ERP_OrderProce> { new T_ERP_OrderProce { ProceName = mg.ProceName, ProceUser = mg.ProceUser } }
                    });
                }
            });

            var prtsys = new XtraReport();
            var rpt = new NewRptSub(prts);
            rpt.BindData();
            rpt.CreateDocument();
            prtsys.Pages.AddRange(rpt.Pages);
            SetPrintToolsVisible(prtsys);
            prtsys.PrintingSystem.ShowMarginsWarning = false;
            if (PrtPreView) {
                prtsys.ShowPreview();
            } else {
                prtsys.Print();
            }
        }

        private bool GenData() {
            if (!PrintValidate()) return false;
            var odrs = gcOrder.GetDataSource<V_ERP_PrintOrderPrd>();
            odrs = odrs ?? new List<V_ERP_PrintOrderPrd>();

            var proces = odrs.Where(k => k.PrintNum > 0).ToList().MapTo<List<V_ERP_PrintOrderPrd>, List<T_ERP_OrderProced>>();


            foreach (var k in proces) {
                k.PrintSession = this.PrintSession;
                k.Guid = Guid.NewGuid();
                k.Updator = k.Creator = this.CurUser;
                k.Remark = k.Reserved2 = k.OrderProdNo = string.Empty;
            }
            var rd = SerNoCaller.Calr_OrderProced.Add(proces);
            TradePrd.IsPrint = true;
            TradePrd.PrintUser = this.CurUser;
            TradePrd.PrintTime = TimeSync.Default.CurrentSyncTime;
            rd = SerNoCaller.Calr_TradePrd.Edt(TradePrd);
            if (rd.IsOK) {
                SerNoCaller.Calr_OrderProced.ExecSql("exec P_FAS_GenProceNo");
            }
            return rd.IsOK;
        }

        private bool PrintValidate() {
            var odrs = gcOrder.GetDataSource<V_ERP_PrintOrderPrd>();
            odrs = odrs ?? new List<V_ERP_PrintOrderPrd>();

            if (odrs.Count < 1) return false;

            if (odrs.Any(k => string.IsNullOrEmpty(k.ProceUser))) {
                MsgBox.ShowMessage("必须分配工人");
                return false;
            }

            var ps = (from p in odrs
                      group p by new {
                          p.OrderPrdGuid, p.ProceName
                      } into g
                      select new V_ERP_PrintOrderPrd {
                          OrderPrdGuid = g.Key.OrderPrdGuid,
                          ProceName = g.Key.ProceName,
                          PrintNum = g.Sum(j => j.PrintNum)
                      }).ToList();

            var cs = ps.Where(k => odrs.FirstOrDefault(j=>j.OrderPrdGuid==k.OrderPrdGuid).CanPrtNum < k.PrintNum).ToList();

            if (cs.Count > 0) {
                odrs.ForEach(k => {
                    if (cs.Any(j =>j.OrderPrdGuid==k.OrderPrdGuid && j.ProceName==k.ProceName)) {
                        k.Reserved2 = "255,240,100,192";
                    }
                });

                gcOrder.RefreshDataSource();
                return false;
            }

            var proces = odrs.Where(k => k.PrintNum > 0).ToList().MapTo<List<V_ERP_PrintOrderPrd>, List<T_ERP_OrderProced>>();

            if (proces == null || proces.Count < 1) {
                MsgBox.ShowErrMsg("没有需要打印的数据!");
                return false;
            }
            
            return true;
        }

        void RefreashPrintOrder() {
            var ps = cmbProce.Properties.GetCheckedItems();
            var whr = ps.ToString().Replace(" ", "").Replace(",", "','");
            if (!string.IsNullOrEmpty(whr)) {
                var where = string.Format(" where prdno='{1}' and ProceName in ('{0}')", whr, TradePrd.PrdNo);
                gcOrder.DataSource = SerNoCaller.Calr_V_ERP_PrintOrderPrd.Get(where);
            } else {
                gcOrder.DataSource = SerNoCaller.Calr_V_ERP_PrintOrderPrd.Get(" where prdno=@0", TradePrd.PrdNo);
            }
        }

        private void proceedt_EditValueChanged(object sender, EventArgs e) {

        }

        private void rspPrintNum_EditValueChanged(object sender, EventArgs e) {
            var rsp = sender as SpinEdit;
            var et = gcOrder.GetFocusedDataSource<V_ERP_PrintOrderPrd>();
            if (et == null) return;
            et.PrintNum = (int)rsp.Value;
            gcOrder.RefreshDataSource();
        }

        private void rspPrintNum_Validating(object sender, CancelEventArgs e) {
            var rsp = sender as SpinEdit;
            var et = gcOrder.GetFocusedDataSource<V_ERP_PrintOrderPrd>();
            if (et == null) return;

            if (et.CanPrtNum < rsp.Value || rsp.Value < 0) {
                e.Cancel = true;
            }
        }

        private void btnSplit_Click(object sender, EventArgs e) {
            var et = gcOrder.GetFocusedDataSource<V_ERP_PrintOrderPrd>();
            if (et == null) return;

            if (et.CanPrtNum == et.PrintNum) {
                MsgBox.ShowErrMsg("打印数量必须小于可打印数量才能拆分!");
                return;
            }

            var newodr = et.Copy();

            var odrs = gcOrder.GetDataSource<V_ERP_PrintOrderPrd>();
            odrs = odrs ?? new List<V_ERP_PrintOrderPrd>();
            newodr.PrintNum = newodr.CanPrtNum - newodr.PrintNum;
            odrs.Add(newodr);

            gcOrder.RefreshDataSource();
        }

        private void btnDel_Click(object sender, EventArgs e) {
            var et = gcOrder.GetFocusedDataSource<V_ERP_PrintOrderPrd>();
            if (et == null) return;

            var odrs = gcOrder.GetDataSource<V_ERP_PrintOrderPrd>();
            odrs = odrs ?? new List<V_ERP_PrintOrderPrd>();
            odrs.Remove(et);
            gcOrder.RefreshDataSource();
        }

        private void cmbProce_EditValueChanged(object sender, EventArgs e) {
            RefreashPrintOrder();
        }

        private void rspWorker_EditValueChanged(object sender, EventArgs e) {
            var rsp = sender as GridLookUpEdit;
            var view = rsp.Properties.View;

            var worker = view.GetFocusedDataSource<T_ERP_Worker>();
            if (worker == null) return;
            var et = gcOrder.GetFocusedDataSource<V_ERP_PrintOrderPrd>();
            if (et == null) return;

            et.ProceUser = worker.RealName;

            gcOrder.RefreshDataSource();
        }

        private void btnPrtPreView_Click(object sender, EventArgs e) {
            PrtPreView = true;
            PrintSession = Guid.NewGuid();
            var dlg = new DevExpress.Utils.WaitDialogForm("正在处理打印数据 ...",
             "正在打印");
            //打印单据
            var errflag = false;
            try {               //生成打印的数据
                if (errflag = GenData()) {
                    if (cmbPrtTemp.SelectedItem.ToString().Equals("标准模板")) {
                        //打印单据
                        DoStdPrint(PrtPreView);
                    } else if (cmbPrtTemp.SelectedItem.ToString().Equals("床垫模板")) {
                        DoCDPrint(PrtPreView);
                    }
                    SerNoCaller.Calr_OrderProced.ExecSql(" delete T_ERP_OrderProced where PrintSession=@0", PrintSession);

                }

            } catch (Exception) {
                RefreashPrintOrder();
                throw;
            } finally {
                dlg.Close();
            }
        }
    }
}
