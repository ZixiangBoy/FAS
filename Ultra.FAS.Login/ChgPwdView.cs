using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;

namespace Ultra.FAS.Login
{
    public partial class ChgPwdView : DialogViewEx
    {
        public ChgPwdView()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            var curusr = this.Cacher.Get<UltraDbEntity.T_ERP_User>("CurrentUser");
           if(curusr.Pwd!= ByteStringUtil.ByteArrayToHexStr(HashDigest.StringDigest(txtoldpwd.Text)))
           {
               MsgBox.ShowErrMsg("输入的当前密码不正确!");return;
           }
            curusr.Pwd=ByteStringUtil.ByteArrayToHexStr(HashDigest.StringDigest(txtnewpwd.Text));
            curusr.PBT = Ultra.Common.Util.EncryptToByte(txtnewpwd.Text);
            var rd = Ultra.FASControls.SerNoCaller.Calr_User.EdtPart(curusr, "Pwd", "PBT");
            if(!rd.IsOK)
            {
                MsgBox.ShowErrMsg(rd.ErrMsg);return;
            }
            DialogResult= System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void ChgPwdView_Load(object sender, EventArgs e)
        {
            txtcur.Text = CurUser;
        }
    }
}
