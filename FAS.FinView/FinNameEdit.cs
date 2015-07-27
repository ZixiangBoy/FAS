using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.CoreCaller;
using Ultra.FASControls;
using Ultra.FASControls.Caller;
using Ultra.Surface.Common;
using Ultra.Surface.Form;

namespace FAS.FinView
{
    public partial class FinNameEdit : DialogViewEx
    {
        public FinNameEdit()
        {
            InitializeComponent();
        }

        public UltraDbEntity.T_ERP_FinName Entity { get; set; }
        public EFCaller<UltraDbEntity.T_ERP_FinName> Calr { get; set; }
        private void FinNameEdit_Load(object sender, EventArgs e)
        {
            Calr = SerNoCaller_GC.Calr_FinName;
            if (Entity != null && EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                txttype.Text = Entity.FinName; txtremark.Text = Entity.FinRemark;
                txttype.Properties.ReadOnly = true;
                checkCtl1.Checked = Entity.IsUsing;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                if (!CheckedFinName())
                {
                    MsgBox.ShowMessage("已存在该科目");
                    return;
                }
                var tr = new UltraDbEntity.T_ERP_FinName
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Guid = Guid.NewGuid(),
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    FinName=txttype.Text,
                    FinRemark=txtremark.Text,
                    IsUsing = checkCtl1.Checked
                };
                
                var bok = Calr.Add(tr);
                if (bok.IsOK)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close(); return;
                }
                return;
            }
            else if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.IsUsing = checkCtl1.Checked;
                Entity.FinName = txttype.Text;
                Entity.FinRemark = txtremark.Text;
                Entity.Updator = CurUser;
                Calr.Edt(Entity);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close(); return;
            }
        }
        private bool CheckedFinName()
        {
           var dd= SerNoCaller_GC.Calr_FinName.Get("Where FinName=@0", txttype.Text);
           if (dd == null || dd.Count() < 1)
           {
               return true;
           }
           else
               return false;
        }

    }
}
