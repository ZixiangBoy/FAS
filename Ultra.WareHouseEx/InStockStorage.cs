using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.FASControls.Extend;
using Ultra.Common;
using Ultra.Surface.Common;
using System.IO;
using Ultra.Surface.Lanuch;
using MoreLinq;
using Ultra.FASControls;

namespace Ultra.WareHouseEx
{
    public partial class InStockStorage : DialogViewEx
    {
        public InStockStorage()
        {
            InitializeComponent();
        }

        List<UltraDbEntity.T_ERP_WareLoc> CacheLoc;
        public List<UltraDbEntity.T_ERP_InStockItem> ListItem;

        public UltraDbEntity.T_ERP_InStock Ent { get; set; }

        void ShowViewMode()
        {
            this.gridColumn8.ColumnEdit = null;

            btnOK.Visible = btnOK.Enabled = false;
            gvStckItem.OptionsBehavior.Editable = false;
            if (null == Ent) return;
            gcStckItem.DataSource = SerNoCaller.Calr_InStockItem.Get("where Session=@0", Ent.ItemSession);

        }

        private void StockAddView_Load(object sender, EventArgs e)
        {
            gvStckItem.OptionsView.ShowAutoFilterRow = false;
            ListItem.ForEach(j =>
            {
                j.AssignItemNum = j.AssignItemNum - Convert.ToInt32(j.Num);
            });
            gcStckItem.DataSource = ListItem;
        }

        private void gvStckItem_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "LocName")
            {
                var et = CacheLoc.FirstOrDefault(j => j.LocName == e.Value.ToString());
                var nt = gvStckItem.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockItem>();
                nt.WareName = et.WareName; nt.AreaName = et.AreaName;
                gvStckItem.MakeRowEditImmediateSave(e.Value);
            }
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            //////释放锁定
            //if (ListItem != null && ListItem.Count > 0)
            //{
            //    SerNoCaller.Calr_Purch.ExecSql("exec P_ERP_NFreeInStorkCancelLock @0,@1", ListItem.FirstOrDefault().StockNo, this.Cursor);
            //}
            //DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //Close();
            //gcStckItem.RemoveSelected();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            var dt = gcStckItem.GetDataSource<UltraDbEntity.T_ERP_InStockItem>();
            if (null == dt || dt.Count < 1)
            {
                MsgBox.ShowErrMsg("必须包含入库商品!");
                return;
            }
            var c = dt.Where(j => string.IsNullOrEmpty(j.WareName) || string.IsNullOrEmpty(j.AreaName) ||
                 string.IsNullOrEmpty(j.LocName) || j.Reserved1 > j.AssignItemNum || j.Reserved1 < 1).Count();
            if (c > 0)
            {
                MsgBox.ShowErrMsg("必须为所有商品都分配上库位,并且商品入库数量必须小于等于可入库数量,请检查商品信息!");
                return;
            }
            dt.ForEach(j => j.Num = j.Num + j.Reserved1);
            var vt = SerNoCaller.Calr_InStockItem.BatchEdt(dt, UltraDbEntity.T_ERP_InStockItem.Meta_Num
                , UltraDbEntity.T_ERP_InStockItem.Meta_AreaName, UltraDbEntity.T_ERP_InStockItem.Meta_LocName);
            if (!string.IsNullOrEmpty(vt.ErrMsg))
            {
                MsgBox.ShowErrMsg("修改时失败！" + vt.ErrMsg);
                return;
            }
            var cot = dt.Where(j => j.AssignItemNum != j.Reserved1).ToList();
            if (cot.Count > 0)//表示未全部入库
            {
                //入库提交
                Ent = SerNoCaller.Calr_InStock.GetByProc("exec P_ERP_NInStock @0,@1,@2"
                      , dt.FirstOrDefault().StockNo, this.CurUser, "Submit").FirstOrDefault();
            }
            else
            {
                //入库审核
                Ent = SerNoCaller.Calr_InStock.GetByProc("exec P_ERP_NAuditInStock @0,@1,@2"
                      , dt.FirstOrDefault().StockNo, this.CurUser, "Audit").FirstOrDefault();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close(); return;
        }

        public string[] Lanucer { get; set; }

        private void NInStockStorage_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnDelItem_Click(null, null);
        }

        private void gvStckItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CacheLoc = this.Cacher.Get<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc");
            if (null == CacheLoc || CacheLoc.Count < 1)
            {
                var fi = Path.Combine(Lanucher.AppDir, "SYS.Cache.V_ERP_NotVirtualLoc.jsn");
                if (File.Exists(fi))
                    CacheLoc = File.ReadAllText(fi).DeSerialize<List<UltraDbEntity.T_ERP_WareLoc>>();
                else
                    CacheLoc = SerNoCaller.Calr_WareLoc.Get("Select * from V_ERP_NotVirtualLoc")
                        .OrderBy(j => j.Distance).ThenBy(j => j.Shelf).ThenBy(j => j.Floor).ToList();

                File.WriteAllText(fi, (CacheLoc).SerializeJson());
                CacheLoc = SerNoCaller.Calr_WareLoc.Get("Select * from V_ERP_NotVirtualLoc")
                        .OrderBy(j => j.Distance).ThenBy(j => j.Shelf).ThenBy(j => j.Floor).ToList();

                this.Cacher.Put<List<UltraDbEntity.T_ERP_WareLoc>>("SYS.Cache.V_ERP_NotVirtualLoc", CacheLoc);
            }
            var dt = gvStckItem.GetFocusedDataSource<UltraDbEntity.T_ERP_InStockItem>();
            if (dt != null)
            {
                CacheLoc = CacheLoc.Where(j => j.WareName == dt.WareName).ToList();
            }
            repLoc.DataSource = CacheLoc;

        }
    }
}
