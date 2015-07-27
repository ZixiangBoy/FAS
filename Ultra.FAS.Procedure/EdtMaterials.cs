using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.CoreCaller;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using Ultra.Common;
using Ultra.Surface.Common;
using PetaPoco;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using DevExpress.XtraEditors;

namespace Ultra.FAS.Procedure
{
    public partial class EdtMaterials : DialogViewEx
    {
        public EdtMaterials()
        {
            InitializeComponent();
        }

        public List<UltraDbEntity.T_ERP_ProduceDosage> ExistsRng { get; set; }

        public UltraDbEntity.T_ERP_Item Item { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var ds = gcMaterial.GetDataSource<UltraDbEntity.T_ERP_ProduceDosage>();
            if (ds == null || ds.Count < 1) return;
            //判断是否存在重复的
            var query = from t in ds.AsEnumerable()
                        group t by new { t1 = t.ProcedureName, t2 = t.MaterialNo } into m
                        select new
                        {
                            ProcedureName = m.Key.t1,
                            MaterialNo = m.Key.t2,
                            Cnt = m.Count()
                        };
            if (query.ToList().Count > 0 && query.Where(j=>j.Cnt > 1).Count()>0)
            {
                MsgBox.ShowErrMsg("不可存在同工序同材料的数据"); return;
            }
            
            FASControls.SerNoCaller_WL.Calr_ProduceDosage.ExecSql(" delete from T_ERP_ProduceDosage where ItemGuid = @0 ", Item.Guid);
            FASControls.SerNoCaller_WL.Calr_ProduceDosage.Add(ds);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void EdtMaterials_Load(object sender, EventArgs e)
        {
            gcMaterial.DataSource = ExistsRng;
            lookUpEdtProduce.DataSource = FASControls.SerNoCaller.Calr_Procedure.Get(" where isnull(IsUsing,0) = 1");
            lookUpEdtMaterial.DataSource = FASControls.SerNoCaller.Calr_Material.Get(" where isnull(IsUsing,0) = 1");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var rcds = gcMaterial.GetDataSource<T_ERP_ProduceDosage>();
            rcds = rcds ?? new List<T_ERP_ProduceDosage>();

            var rcd = new T_ERP_ProduceDosage()
            {
                Guid = Guid.NewGuid(),
                Creator = this.CurUser,
                Updator = this.CurUser,
                Remark = string.Empty,
                Reserved1 = 0,
                Reserved2 = string.Empty,
                Reserved3 = false,
                OuterIid = Item.OuterIid,
                OuterSkuId = Item.OuterSkuId,
                ItemGuid = Item.Guid
            };
            rcds.Add(rcd);
            gcMaterial.DataSource = rcds;
            gcMaterial.RefreshDataSource();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            gcMaterial.RemoveSelected();
        }

        private void lookUpEdtProduce_EditValueChanged(object sender, EventArgs e)
        {
            var pd = gcMaterial.GetFocusedDataSource<UltraDbEntity.T_ERP_ProduceDosage>();
            if (pd == null) return;
            var rspGvEdtProduce = sender as GridLookUpEdit;
            var gvSearchProduce = rspGvEdtProduce.Properties.View;
            var produce = gvSearchProduce.GetFocusedDataSource<T_ERP_Procedure>();
            pd.ProcedureName = produce.ProcedureName;
            pd.ProcedureGuid = produce.Guid;
            gcMaterial.RefreshDataSource();
        }

        private void lookUpEdtMaterial_EditValueChanged(object sender, EventArgs e)
        {
            var pd = gcMaterial.GetFocusedDataSource<UltraDbEntity.T_ERP_ProduceDosage>();
            if (pd == null) return;
            var rspGvEdtMaterial = sender as GridLookUpEdit;
            var gvSearchMaterial = rspGvEdtMaterial.Properties.View;
            var material = gvSearchMaterial.GetFocusedDataSource<T_ERP_Material>();
            pd.MaterialGuid = material.Guid;
            pd.MaterialNo = material.MaterialNo;
            pd.MaterialName = material.MaterialName;
            pd.Unit = material.Unit;
            gcMaterial.RefreshDataSource();
        }
    }
}
