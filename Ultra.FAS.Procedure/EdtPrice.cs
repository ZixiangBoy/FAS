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

namespace Ultra.FAS.Procedure
{
    public partial class EdtPrice : DialogViewEx
    {
        public EdtPrice()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_ProducePrice Ent { get; set; }

        /// <summary>
        /// 已存在的工价
        /// </summary>
        public List<UltraDbEntity.T_ERP_ProducePrice> ExistsRng { get; set; }

        public UltraDbEntity.T_ERP_Item Item { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            var pro = lookUpEdit1.EditValue as T_ERP_Procedure;

            if(ExistsRng!=null && ExistsRng.Where(j => j.ProcedureGuid == pro.Guid && j.Guid != Ent.Guid).Count() > 0){
                MsgBox.ShowMessage("已存在该工序的工价");
                return;
            }
            
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var oj = new UltraDbEntity.T_ERP_ProducePrice
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
                    NumIid = Item.NumIid,
                    ProcedureGuid = pro.Guid,
                    ProcedureName = pro.ProcedureName
                };

                using (var db = new Database(this.ConnString))
                {
                    db.Insert(oj);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Ent.CostPrice = labelSpinEdit1.Value;
                Ent.ProcedureGuid = pro.Guid;
                Ent.ProcedureName = pro.ProcedureName;
                using (var db = new Database(this.ConnString))
                {
                    db.Update(Ent);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close(); 
            }
        }

        private void EdtPrice_Load(object sender, EventArgs e)
        {
            using (var db = new Database(this.ConnString))
            {
                lookUpEdit1.Properties.DataSource = db.Fetch<UltraDbEntity.T_ERP_Procedure>(" where isnull(IsUsing,0) = 1 ");
            }
            if (Ent != null && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                //Ent.ProcedureGuid
                var pros = lookUpEdit1.Properties.DataSource as List<T_ERP_Procedure>;
                var pro = pros.Where(j => j.Guid == Ent.ProcedureGuid).FirstOrDefault();

                lookUpEdit1.EditValue = pro;
                if (pro != null)
                    lookUpEdit1.SelectedText = pro.ProcedureName;
                lookUpEdit1.Properties.ReadOnly = true;
                labelSpinEdit1.Value = Ent.CostPrice;
            }
        }
    }
}
