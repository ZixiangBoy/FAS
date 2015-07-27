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

namespace FAS.ProduceMater {
    public partial class NewProduceMater : DialogViewEx {
        public T_ERP_ProduceMater ProMater { get; set; }
        
        public NewProduceMater() {
            InitializeComponent();
        }

        private void NewProduceMater_Load(object sender, EventArgs e)
        {
            var items = itemEdt.LoadFromCache();
            var prods = prodEdt.LoadFromCache();
            var mats = materEdt.LoadFromCache();
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                itemEdt.SetSelectedValue(items.FirstOrDefault(k => k.OuterIid == ProMater.OuterIid && k.OuterSkuId == ProMater.OuterSkuId));
                prodEdt.SetSelectedValue(prods.FirstOrDefault(k => k.ProcedureName == ProMater.ProcedureName));
                txtProduceNo.Text = ProMater.ProduceNo;
                txtNum.Value = ProMater.Num;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (ProMater == null)
                ProMater = new T_ERP_ProduceMater() { Creator=this.CurUser,Remark=string.Empty,Reserved2=string.Empty };

            ProMater.ProduceNo = txtProduceNo.Text;
            var item=itemEdt.GetSelectedValue();
            ProMater.ItemName = item.ItemName;
            ProMater.SkuName = item.SkuName;
            ProMater.OuterIid = item.OuterIid;
            ProMater.OuterSkuId = item.OuterSkuId;
            ProMater.ProcedureName = prodEdt.GetSelectedValue().ProcedureName;
            var mater = materEdt.GetSelectedValue();
            ProMater.MaterialName = mater.MaterialName;
            ProMater.MaterialNo = mater.MaterialNo;
            ProMater.UseQty = txtUseQty.Value;
            ProMater.Updator = this.CurUser;
            ProMater.UpdateDate = TimeSync.Default.CurrentSyncTime;

            SerNoCaller.Calr_ProduceMater.Add(ProMater);

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void itemEdt_EditValueChanged(object sender, EventArgs e)
        {
            txtSkuName.Text = itemEdt.SelectedValue.OuterSkuId;

        }
    }
}
