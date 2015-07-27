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
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.FASControls;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using Ultra.FASControls.Views;
using Ultra.Common;
using Ultra.FASControls.Caller;

namespace FAS.Suppliers
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
            Text = "编辑";
        }
        //public SuppliersController SLgc
        //{
        //    get;
        //    set;
        //}
        //public SupItemController ILgc
        //{
        //    get;
        //    set;
        //}
        //public SuppItemController SULgc
        //{
        //    get;
        //    set;
        //}

        public EFCaller<UltraDbEntity.T_ERP_Suppliers> SLgc
        {
            get;
            set;
        }
       

        T_ERP_Suppliers entity
        {
            get;
            set;
        }

        private void EdtView_Load(object sender, EventArgs e)
        {
            //SULgc = new SuppItemController(this.ConnString);
            //SLgc = new SuppliersController(this.ConnString);
            //ILgc = new SupItemController(this.ConnString);

            SLgc = SerNoCaller.Calr_Suppliers;
                //new EFCaller<T_ERP_Suppliers>(new SuppliersController());
                //new EFCaller<T_ERP_SuppItem>(new SuppItemController());
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                txtSupplierName.Properties.ReadOnly = true;
                entity = SLgc.Get(" where Guid=@0", this.GuidKey).FirstOrDefault();
                if (null == entity) return;
                lblsuppcode.EditValue = entity.SupCode;
                txtSupplierName.EditValue = entity.SuppName;
                txtAddress.EditValue = entity.Address;
                txtCpyMobile.EditValue = entity.CpyMobile;
                txtCpyPerson.EditValue = entity.CpyPerson;
                txtFax.EditValue = entity.Fax;
                txtMobile.EditValue = entity.Mobile;
                txtPhone.EditValue = entity.Phone;
                txtSuppPerson.EditValue = entity.SuppPerson;
                ckeIsUsing.Checked = entity.IsUsing == null ? false : entity.IsUsing.Value;
            }
            else
            {
                entity = new T_ERP_Suppliers
                {
                    Guid = Guid.NewGuid()
                };
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                entity.SupCode = string.IsNullOrEmpty(entity.SupCode) ? entity.SuppName : entity.SupCode;
                entity.Creator = CurUser;
                entity.Updator = CurUser;
                entity.Remark = string.Empty;
                entity.Reserved1 = 0;
                entity.Reserved2 = string.Empty;
                entity.Reserved3 = false;
                entity.IsUsing = ckeIsUsing.Checked;
                entity.Mobile = txtMobile.Text;
                entity.Phone = txtPhone.Text;
                entity.SuppName = txtSupplierName.Text;
                entity.SuppPerson = txtSuppPerson.Text;
                entity.Fax = txtFax.Text;
                entity.Address = txtAddress.Text;
                entity.CpyMobile = txtCpyMobile.Text;
                entity.CpyPerson = txtCpyPerson.Text;
                entity.Guid = Guid.NewGuid();
                var rd = SLgc.Add(entity);
                if (rd.IsOK)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close(); return;
                }
                else
                {
                    MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                    return;
                }
            }
            else if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                entity.Address = txtAddress.Text;
                entity.CpyMobile = txtCpyMobile.Text;
                entity.CpyPerson = txtCpyPerson.Text;
                entity.Fax = txtFax.Text;
                entity.IsUsing = ckeIsUsing.Checked;
                entity.Mobile = txtMobile.Text;
                entity.Phone = txtPhone.Text;
                //entity.SuppName = txtSupplierName.Text;
                entity.SuppPerson = txtSuppPerson.Text;
                entity.Updator = this.CurUser;
                entity.SupCode = string.IsNullOrEmpty(lblsuppcode.Text.Trim()) ? entity.SuppName : lblsuppcode.Text.Trim();
                SLgc.Edt(entity);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close(); return;
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCtl1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 移除商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCtl2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
