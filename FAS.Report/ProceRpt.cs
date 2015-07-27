using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UltraDbEntity;
using System.Collections.Generic;
using System.Linq;

namespace FAS.Report {
    public partial class ProceRpt : DevExpress.XtraReports.UI.XtraReport {
        public ProceRpt() {
            InitializeComponent();
        }

        public ProcePrtInfo Prt;

        public ProceRpt(ProcePrtInfo prt) {
            InitializeComponent();
            Prt = prt;
        }

        public void BindData() {
            DataSource = new List<PrtOrder>{ Prt.PrtOrder};
            this.xrRecvOprUser.DataBindings.Add("Text", Prt.PrtOrder, "RecvOprUser");
            this.xrPrdNo.DataBindings.Add("Text", Prt.PrtOrder, "PrdNo");
            this.xrReceiverName.DataBindings.Add("Text", Prt.PrtOrder, "ReceiverName");
            this.xrCreateDate.DataBindings.Add("Text", Prt.PrtOrder, "Created");
            this.xrProDelDate.DataBindings.Add("Text", Prt.PrtOrder, "ProDelDate");
            this.xrOuterIid.DataBindings.Add("Text", Prt.PrtOrder, "OuterIid");
            this.xrOuterSkuId.DataBindings.Add("Text", Prt.PrtOrder, "OuterSkuId");
            this.xrSurface.DataBindings.Add("Text", Prt.PrtOrder, "Surface");
            this.xrDirection.DataBindings.Add("Text", Prt.PrtOrder, "Direction");
            this.xrColor.DataBindings.Add("Text", Prt.PrtOrder, "Color");
            this.xrNum.DataBindings.Add("Text", Prt.PrtOrder, "Num");
            this.xrRemark.DataBindings.Add("Text", Prt.PrtOrder, "Remark");

            var totalrows=xrTable.Rows.Count;
            if (totalrows > 5) {
                for (int i = 0; i < totalrows - 5; i++) {
                    xrTable.Rows.RemoveAt(5);
                }
            }

            if (Prt.Detail.Count > 0) {
                int rows = Prt.Detail.Count % 2 > 0 ? Prt.Detail.Count / 2 + 1 : Prt.Detail.Count / 2;
                var rs = new List<XRTableRow>();
                for (int i = 0; i < rows; i++) {
                    XRTableRow row = new XRTableRow();
                    row.HeightF = 40;
                    rs.Add(row);
                }
                for (int i = 0; i < Prt.Detail.Count; i++) {
                    int rowidx = i / 2;
                    var cellidx = i % 2;
                    float cellwidth = 0f;
                    switch (cellidx) {
                        case 0:
                            XRTableCell cell = new XRTableCell();
                            cellwidth = 94.99f;
                            cell.WidthF = cellwidth;
                            cell.Text = Prt.Detail[i].ProceName;
                            rs[rowidx].Cells.Add(cell);
                            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            cell.Borders = DevExpress.XtraPrinting.BorderSide.Left
                            | DevExpress.XtraPrinting.BorderSide.Top;
                                                        
                            cell = new XRTableCell();
                            cell.Text = Prt.Detail[i].ProceUser;
                            if (Prt.Detail.Count % 2 == 1 && rowidx == rs.Count - 1) {
                                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                                cell.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top
                                | DevExpress.XtraPrinting.BorderSide.Right;
                                cellwidth = 705.01f;
                            } else {
                                cellwidth = 305.01f;
                                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                                cell.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top;
                            }

                            cell.WidthF = cellwidth;
                            //cell.Text = Prt.Detail[i].ProceName;
                            rs[rowidx].Cells.Add(cell);
                            break;
                        case 1:
                            XRTableCell cell1 = new XRTableCell();
                            cellwidth = 138.07f;
                            cell1.WidthF = cellwidth;
                            cell1.Text = Prt.Detail[i].ProceName;
                            rs[rowidx].Cells.Add(cell1);
                            cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            cell1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                            | DevExpress.XtraPrinting.BorderSide.Top;
                            
                            cell1 = new XRTableCell();
                            cellwidth = 261.93f;
                            cell1.WidthF = cellwidth;
                            cell1.Text = Prt.Detail[i].ProceUser;
                            rs[rowidx].Cells.Add(cell1);
                            cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            cell1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                            | DevExpress.XtraPrinting.BorderSide.Top
                            | DevExpress.XtraPrinting.BorderSide.Right;
                            break;
                    }
                }
                xrTable.Rows.AddRange(rs.ToArray());


                rs = new List<XRTableRow>();
                for (int i = 0; i < rows; i++) {
                    XRTableRow row = new XRTableRow();
                    row.HeightF = 40;
                    rs.Add(row);
                }
                for (int i = 0; i < Prt.Detail.Count; i++) {
                    int rowidx = i / 2;
                    var cellidx = i % 2;
                    float cellwidth = 0f;
                    switch (cellidx) {
                        case 0:
                            XRTableCell cell = new XRTableCell();
                            cellwidth = 94.99f;
                            cell.WidthF = cellwidth;
                            cell.Text = Prt.Detail[i].ProceName;
                            rs[rowidx].Cells.Add(cell);
                            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            if (rowidx == rs.Count - 1) {
                                cell.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                            } else {
                                cell.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top;
                            }
                            cell.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
                            cell = new XRTableCell();
                                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            if (Prt.Detail.Count % 2 == 1 && rowidx == rs.Count - 1) {
                                cell.Borders = DevExpress.XtraPrinting.BorderSide.All;
                                cellwidth = 705.01f;
                            } else {
                                cellwidth = 305.01f;
                                cell.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top;
                            }
                            if (rowidx == rs.Count - 1) {
                                cell.Borders = cell.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
                            } else {
                                cell.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top;
                            }
                            cell.WidthF = cellwidth;
                            cell.Text = Prt.PrtOrder.PrdNo;
                            rs[rowidx].Cells.Add(cell);
                            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            
                            cell.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
                            break;
                        case 1:
                            XRTableCell cell1 = new XRTableCell();
                            cellwidth = 138.07f;
                            cell1.WidthF = cellwidth;
                            cell1.Text = Prt.Detail[i].ProceName;
                            rs[rowidx].Cells.Add(cell1);
                            cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            if (rowidx == rs.Count - 1) {
                                cell1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                            } else {
                                cell1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top;
                            }
                            cell1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
                            cell1 = new XRTableCell();
                            cellwidth = 261.93f;
                            cell1.WidthF = cellwidth;
                            cell1.Text = Prt.PrtOrder.PrdNo;
                            rs[rowidx].Cells.Add(cell1);
                            cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            if (rowidx == rs.Count - 1) {
                                cell1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom
                                | DevExpress.XtraPrinting.BorderSide.Right;
                            } else {
                                cell1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                | DevExpress.XtraPrinting.BorderSide.Top
                                | DevExpress.XtraPrinting.BorderSide.Right;
                            }
                            cell1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
                            break;
                    }
                }
                xrTable.Rows.AddRange(rs.ToArray());
            }

        }

    }

    public class ProcePrtInfo {
        public PrtOrder PrtOrder { get; set; }
        public List<T_ERP_OrderProce> Detail { get; set; }
    }

    public class PrtOrder {
        public Guid Guid { get; set; }
        public string PrdNo { get; set; }
        //public string ProceName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime Created { get; set; }
        public string Creator { get; set; }
        public string ProDelDate { get; set; }
        public string OuterIid { get; set; }
        public string OuterSkuId { get; set; }
        public string ItemName { get; set; }
        public string SkuName { get; set; }
        public string Color { get; set; }
        public string Direction { get; set; }
        public string Surface { get; set; }
        public string RecvOprUser { get; set; }
        public int Num { get; set; }
    }

    public class T_ERP_OrderProce {
        public string ProceName { get; set; }
        public string ProceUser { get; set; }
    }
}
