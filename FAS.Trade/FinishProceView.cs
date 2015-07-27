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
using Ultra.Win.Core.Common;
using UltraDbEntity;
using Ultra.FASControls.Extend;

namespace FAS.Trade {
    public partial class FinishProceView : DialogViewEx {

        public T_ERP_OrderProced OrderProced { get; set; } 

        public FinishProceView() {
            InitializeComponent();
        }

        private void FinishProceView_Load(object sender, EventArgs e) {
            gridControlEx1.DataSource = SerNoCaller_WL.Calr_Worker.Get(" select Guid,Worker RealName,DeptName from T_ERP_OrderProcedWorker where OrderProdNo=@0", OrderProced.OrderProdNo);
            gridControlEx2.DataSource = SerNoCaller_WL.Calr_Worker.Get(" where not exists(select 1 from T_ERP_OrderProcedWorker where OrderProdNo=@0 and worker=T_ERP_Worker.RealName)", OrderProced.OrderProdNo);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var ws = gridControlEx1.GetDataSource<T_ERP_Worker>();
            if (ws == null || ws.Count < 1) return;

            //OrderProced.IsFinish = true;
            //OrderProced.FinishTime = TimeSync.Default.CurrentSyncTime;
            OrderProced.ProceUser = ws.Select(k=>k.RealName).Aggregate((s1,s2)=>s1+","+s2);

            SerNoCaller.Calr_OrderProced.Edt(OrderProced);
            var ows=ws.Select(k => new T_ERP_OrderProcedWorker { 
                Guid=Guid.NewGuid(),
                OrderProdNo=OrderProced.OrderProdNo,
                Creator=this.CurUser,
                Updator=this.CurUser,
                Remark=string.Empty,
                Reserved2=string.Empty,
                Worker=k.RealName,
                DeptName=k.DeptName
            }).ToList();
            SerNoCaller.Calr_OrderProcedWorker.ExecSql("delete from T_ERP_OrderProcedWorker where OrderProdNo=@0",OrderProced.OrderProdNo);
            SerNoCaller.Calr_OrderProcedWorker.Add(ows);

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void pnlFill_Paint(object sender, PaintEventArgs e) {

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var et=gridControlEx2.GetFocusedDataSource<T_ERP_Worker>();
            if (et == null) return;

            var fromws = gridControlEx2.GetDataSource<T_ERP_Worker>();
            fromws.Remove(et);

            var ws = gridControlEx1.GetDataSource<T_ERP_Worker>();
            ws = ws ?? new List<T_ERP_Worker>();
            ws.Add(et);
            gridControlEx1.DataSource = ws;
            gridControlEx1.RefreshDataSource();
            gridControlEx2.RefreshDataSource();
        }

        private void btnDel_Click(object sender, EventArgs e) {
            var et = gridControlEx1.GetFocusedDataSource<T_ERP_Worker>();
            if (et == null) return;

            var fromws = gridControlEx1.GetDataSource<T_ERP_Worker>();
            fromws.Remove(et);

            var ws = gridControlEx2.GetDataSource<T_ERP_Worker>();
            ws = ws ?? new List<T_ERP_Worker>();
            ws.Add(et);
            gridControlEx2.DataSource = ws;
            gridControlEx1.RefreshDataSource();
            gridControlEx2.RefreshDataSource();
        }
    }
}
