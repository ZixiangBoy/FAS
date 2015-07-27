using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Common;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using Ultra.FASControls;

namespace FAS.User
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
        }

        //public Logic Lgc { get; set; }

        public UltraDbEntity.T_ERP_User Entity { get; set; }

        private void EdtView_Load(object sender, EventArgs e)
        {
            if (Entity != null && EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                txtusername.Text = Entity.UserName; txtusername.Properties.ReadOnly = true;
                txtrealname.Text = Entity.RealName;
                txtmobile.Text = Entity.Moblie;
                txtjobnum.Text = Entity.JobNumber;
                txtWorkAccount.Text = Entity.WorkAccount;
                chkusing.Checked = Entity.IsUsing;

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            if (txtpwd.Text != txtrepwd.Text && !string.IsNullOrEmpty(txtpwd.Text))
            {
                MsgBox.ShowMessage("提示", "两次输入的密码不一致！");
                return;
            }
            if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.New)
            {
                var r = new UltraDbEntity.T_ERP_User
                {
                    Guid = Guid.NewGuid(),
                    DepGuid = Guid.Empty,
                    UserName = txtusername.Text,
                    Creator = CurUser,
                    Updator = CurUser,
                    Email = string.Empty,
                    GroupName = string.Empty,
                    RealName = txtrealname.Text,
                    Moblie = txtmobile.Text,
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    Pwd = ByteStringUtil.ByteArrayToHexStr(HashDigest.StringDigest(txtpwd.Text)),
                    PBT = Util.EncryptToByte(txtpwd.Text),
                    JobNumber = txtjobnum.Text,
                    WorkAccount = txtWorkAccount.Text,
                };
                var bok = SerNoCaller.Calr_User.Add(r);
                if (bok.IsOK)
                {
                    Entity = r;
                    DialogResult = System.Windows.Forms.DialogResult.OK; Close();
                }
                else
                {
                    MsgBox.ShowErrMsg(bok.ErrMsg);
                }
            }
            else if (EditMode == Ultra.Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.RealName = txtrealname.Text;
                Entity.IsUsing = chkusing.Checked;
                Entity.JobNumber = txtjobnum.Text;
                Entity.Moblie = txtmobile.Text;
                Entity.Updator = CurUser;
                if (!string.IsNullOrEmpty(txtpwd.Text))
                {
                    Entity.Pwd = ByteStringUtil.ByteArrayToHexStr(HashDigest.StringDigest(txtpwd.Text));
                    Entity.PBT = Util.EncryptToByte(txtpwd.Text);
                }
                //var bok = Lgc.Edt(Entity, out ermsg);
                var bok = SerNoCaller.Calr_User.Edt(Entity);
                if (bok.IsOK)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK; Close();
                }
                else
                {
                    MsgBox.ShowErrMsg(bok.ErrMsg);
                    return;
                }
            }
        }


    }
}
