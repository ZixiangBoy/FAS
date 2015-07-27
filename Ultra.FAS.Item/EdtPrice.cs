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

namespace Ultra.FAS.Item
{
    public partial class EdtPrice : DialogViewEx
    {
        public EdtPrice()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_WreckPrice Ent { get; set; }

        /// <summary>
        /// 已存在的费用
        /// </summary>
        public List<UltraDbEntity.T_ERP_WreckPrice> ExistsRng { get; set; }

        public UltraDbEntity.T_ERP_Item Item { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            var pro = lookUpEdit1.EditValue as T_ERP_WreckType;
            
            if(ExistsRng!=null && ExistsRng.Where(j => j.ProcedureGuid == pro.Guid && Ent!=null && j.Guid != Ent.Guid).Count() > 0){
                MsgBox.ShowMessage("已存在该类型的费用");
                return;
            }
            
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var oj = new UltraDbEntity.T_ERP_WreckPrice
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Guid = Guid.NewGuid(),
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,

                    CostPrice = labelSpinEdit1.Value,
                    OuterIid = Item.OuterIid,
                    OuterSkuId = Item.OuterSkuId,
                    ItemGuid = Item.Guid,
                    ProcedureGuid = pro.Guid,
                    ProcedureName = pro.TypeName
                };

                FASControls.SerNoCaller_WL.Calr_WreckPrice.Add(oj);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Ent.CostPrice = labelSpinEdit1.Value;
                Ent.ProcedureGuid = pro.Guid;
                Ent.ProcedureName = pro.TypeName;
                FASControls.SerNoCaller_WL.Calr_WreckPrice.Edt(Ent);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close(); 
            }
        }

        private void EdtPrice_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = FASControls.SerNoCaller_WL.Calr_WreckType.Get(" where isnull(IsUsing,0) = 1 ");
            if (Ent != null && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                var pros = lookUpEdit1.Properties.DataSource as List<T_ERP_WreckType>;
                var pro = pros.Where(j => j.Guid == Ent.ProcedureGuid).FirstOrDefault();

                lookUpEdit1.EditValue = pro;
                if (pro != null)
                    lookUpEdit1.SelectedText = pro.TypeName;
                lookUpEdit1.Properties.ReadOnly = true;
                labelSpinEdit1.Value = Ent.CostPrice;
            }
            else
                Ent = new T_ERP_WreckPrice();
        }
    }
}
