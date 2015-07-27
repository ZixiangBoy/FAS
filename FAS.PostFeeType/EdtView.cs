using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.FASControls.Caller;

namespace FAS.PostFeeType
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
        }

     
        public UltraDbEntity.T_ERP_PostFeeType Entity { get; set; }

        private void EdtView_Load(object sender, EventArgs e)
        {
            if (Entity != null && EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                txtusefor.Text = Entity.TypeName; txtusefor.Properties.ReadOnly = true;
                chkreq.Checked = Entity.Required.Value;
                chkuseing.Checked = Entity.IsUsing;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) { return; }
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                var pc = new UltraDbEntity.T_ERP_PostFeeType
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Guid = Guid.NewGuid(),
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    TypeName = txtusefor.Text,
                    IsUsing = chkuseing.Checked,
                    Required = chkreq.Checked
                };
                var rd = Ultra.FASControls.SerNoCaller.Calr_PostFeeType.Add(pc);
                    //Lgc.AddCfg(pc);
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
                Entity.Required = chkreq.Checked;
                Entity.Updator = CurUser;
                Entity.IsUsing = chkuseing.Checked;
                //Lgc.Edt(Entity);
                Ultra.FASControls.SerNoCaller.Calr_PostFeeType.Edt(Entity);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
