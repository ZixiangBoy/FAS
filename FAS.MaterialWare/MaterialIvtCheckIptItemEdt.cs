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
using Ultra.Common;
using Ultra.Xls;
using Ultra.CoreCaller;
using Ultra.Surface.Common;
using Ultra.FASControls.Extend;
using Ultra.Win.Core.Common;
using Ultra.FASControls;
using Ultra.FASControls.Caller;


namespace FAS.MaterialWare
{
    public partial class MaterialIvtCheckIptItemEdt : DialogViewEx
    {
        public MaterialIvtCheckIptItemEdt()
        {
            InitializeComponent();
        }

        Dictionary<string, string> dicKF = new Dictionary<string, string>(30);

        private void IptItemView_Load(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvCheck.Columns)
            {
                if (!dicKF.ContainsKey(col.Caption))
                    dicKF.Add(col.Caption, col.FieldName);
            }
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            gcCheck.GridExportXls();
        }

        /// <summary>
        /// 从文件读取数据并加载至网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChk_Click(object sender, EventArgs e)
        {
            
            //读取文件数据
            var ipitm = XlsCommon.Read<IptCheck>(fileBrowser1.Text, dicKF);
            gcCheck.DataSource = ipitm;
            if (ipitm == null) return;
            foreach (var item in ipitm)
            {
                var ermsg = string.Empty;
                ChkData(item, out ermsg);
            }
            if (ipitm.Where(j => !j.Valid).Count() > 0)
            {
                gcCheck.RefreshDataSource();
                return;
            }
            //判断是否重复存在同库位
            var mch = ipitm.GroupBy(j => j.MaterialNo +j.WareName+j.AreaName+j.LocName).Where(g => g.Count() > 1)
                .Select(j => new { Element = j.Key });
            ipitm.Where(j => mch.Any(k => k.Element == j.MaterialNo + j.WareName + j.AreaName + j.LocName)).ToList().ForEach(j =>
            {
                j.ChkResult = "存在同库位的商品";
                j.Valid = false;
            });
            gcCheck.RefreshDataSource();

            btnImp.Enabled = ipitm.Where(j => !j.Valid).Count() < 1;
        }

        /// <summary>
        /// 检查数据有效性
        /// </summary>
        /// <param name="itm"></param>
        /// <returns></returns>
        bool ChkData(IptCheck itm, out string ermsg)
        {
            ermsg = string.Empty;
            StringBuilder sb = new StringBuilder(20);
            var ber = false;
            if (string.IsNullOrEmpty(itm.WareName) || string.IsNullOrEmpty(itm.AreaName) || string.IsNullOrEmpty(itm.LocName))
            {
                itm.ChkResult = ermsg = ("库位不能为空 ");
                itm.Valid = ber = false;return ber;
            }
            if (string.IsNullOrEmpty(itm.MaterialNo))
            {
                itm.ChkResult = ermsg = "物料货号不能为空";
                itm.Valid = ber = false;return ber;
            }
            if (itm.Num<0)
            {
                itm.ChkResult = ermsg = "盘点数不能为空或者小于0";
                itm.Valid = ber = false; return ber;
            }
            itm.Valid = ber = true;
            return ber;
        }

        /// <summary>
        /// 执行数据导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImp_Click(object sender, EventArgs e)
        {
            var ets = gcCheck.GetDataSource<IptCheck>();
            if (null == ets || ets.Count < 1) return;
            var icds = ets.MapTo<List<IptCheck>, List<UltraDbEntity.T_ERP_MaterialCheckDetail>>();
            (this as Form).BeginWaitDlg("正在导入,请稍候 ...");
            var gid = Guid.NewGuid();
            icds.ForEach(j =>
            {
                j.ItemSession = gid;
                j.Guid = Guid.NewGuid();
                j.Creator = j.Updator = CurUser;
                j.Remark = string.Empty; j.Reserved1 = 0; j.Reserved2 = string.Empty;
                j.Reserved3 = false;
            });

            var rd = SerNoCaller_GC.Calr_MaterialCheckDetail.AddEx(icds, " exec P_ERP_NewMaterialIvtCheck @0,@1,@2 ,@3,@4,@5 ",
                    this.CurUser, TimeSync.Default.CurrentSyncTime.ToString("yyyy-MM-dd"), CurUser, "", gid, Guid.Empty);
            (this as Form).EndWaitDlg();
            if (!rd.IsOK)
            {
                MsgBox.ShowErrMsg(rd.ErrMsg);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            MsgBox.ShowMessage("导入完成");
            Close();
        }

        private void btnCtl1_Click(object sender, EventArgs e)
        {
            this.gridColumn10.Visible = false;
            this.gcCheck.GridExportXls();
            this.gridColumn10.Visible = true;
        }

        private void btnCtl2_Click(object sender, EventArgs e)
        {
            string ware = string.Empty;
            var ds = Ultra.FASControls.BusControls.WareHouseGridEdit.GetNotVirtualWare();
            if (null != ds && ds.Count < 2 && ds.Count > 0)
            {
                ware = ds.FirstOrDefault().WareName;
            }
            else
            {
                var vw = new Ultra.FASControls.Views.ChoseWareView();
                if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    ware = vw.WareName;
            }

            var ets = SerNoCaller.Calr_InventoryMaterial.Get(" where WareName = @0 ",ware);
            
            Dictionary<string, string> dic = new Dictionary<string, string> { 
               {UltraDbEntity.T_ERP_InventoryMaterial.Meta_WareName,"仓库"}
               ,{UltraDbEntity.T_ERP_InventoryMaterial.Meta_AreaName,"区域"}
               ,{UltraDbEntity.T_ERP_InventoryMaterial.Meta_LocName,"库位"}
               ,{UltraDbEntity.T_ERP_InventoryMaterial.Meta_MaterialNo,"物料货号"}
               ,{UltraDbEntity.T_ERP_InventoryMaterial.Meta_MaterialName,"物料名称"}
               ,{UltraDbEntity.T_ERP_InventoryMaterial.Meta_Qty,"原库存数"}
               ,{UltraDbEntity.T_ERP_InventoryMaterial.Meta_Remark,"盘点数"}
            };
            Ultra.FASControls.Views.ExportDataView evw = new Ultra.FASControls.Views.ExportDataView();
            evw.Export<UltraDbEntity.T_ERP_InventoryMaterial>(ets, dic);
        }
    }


    [Serializable]
    public class IptCheck : UltraDbEntity.T_ERP_MaterialCheckDetail
    {
        public string ChkResult { get; set; }

        public bool Valid { get; set; }
    }
}
