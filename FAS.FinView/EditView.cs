using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.CoreCaller;
using Ultra.FASControls.Caller;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Win.Core.Common;

namespace FAS.FinView
{
    public partial class EditView : DialogViewEx
    {
        public EditView()
        {
            InitializeComponent();
        }
        public UltraDbEntity.T_ERP_FinRec Entity { get; set; }
        public EFCaller<UltraDbEntity.T_ERP_FinRec> Calr { get; set; }
        public EFCaller<UltraDbEntity.T_ERP_FinName> FinCalr { get; set; }
        private void EditView_Load(object sender, EventArgs e)
        {
            List<UltraDbEntity.T_ERP_FinName> ds = SerNoCaller_GC.Calr_FinName.Get("where IsUsing=1 and IsDel=0");       
            comboBoxEdit2.Properties.Items.AddRange(ds.Select(k=>k.FinName).ToArray());
            Calr = SerNoCaller_GC.Calr_FinRec;
            if (Entity != null && EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                comboBoxEdit2.SelectedText = Entity.FinName;
                Fee1.Value = Entity.Amount;
                txttype.Text = Entity.Customer;
                BlankNo1.Text = Entity.BlankNo;
                checkEdit1.Checked = Entity.IsDone;
                memoEdit1.Text = Entity.UseWay;
                dateEdit2.DateTime = (DateTime)Entity.FinTime;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (comboBoxEdit2.Text == string.Empty)
            { MsgBox.ShowMessage("科目必须填写"); return; }
            CheckedFinName();
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                var tr = new UltraDbEntity.T_ERP_FinRec
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Guid = Guid.NewGuid(),
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    FinName = comboBoxEdit2.Text,
                    Amount = Fee1.Value,
                    Customer = txttype.Text,
                    BlankNo = BlankNo1.Text,
                    IsDone = checkEdit1.Checked,
                    UseWay = memoEdit1.Text,
                    FinTime = dateEdit2.DateTime
                    //TimeSync.Default.CurrentSyncTime
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

                Entity.FinName = comboBoxEdit2.Text;
                Entity.UseWay = memoEdit1.Text;
                Entity.IsDone = checkEdit1.Checked;
                Entity.Customer = txttype.Text;
                Entity.BlankNo = BlankNo1.Text;
                Entity.Updator = CurUser;
                Entity.Amount = Fee1.Value;
                Entity.FinTime = dateEdit2.DateTime;
                Entity.Remark = string.Empty;
                Entity.Reserved1 = 0;
                Entity.Reserved2 = string.Empty;
                Entity.Reserved3 = false;
                var rt=Calr.Edt(Entity);
                if (!rt.IsOK)
                {
                    MsgBox.ShowErrMsg(rt.ErrMsg);
                    return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close(); return;
            }
        }

        private void CheckedFinName()
        {
            var dt = SerNoCaller_GC.Calr_FinName.Get("where FinName=@0", comboBoxEdit2.Text);
            if (dt == null || dt.Count()<1)
            {
                var tr = new UltraDbEntity.T_ERP_FinName
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Guid = Guid.NewGuid(),
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    FinName = comboBoxEdit2.Text,
                    IsUsing=true
                };
                var bok = SerNoCaller_GC.Calr_FinName.Add(tr);
                if (!bok.IsOK)
                {
                    MsgBox.ShowErrMsg("科目保存失败！");
                    return;
                }
            }
            return;
        }

    }
}
