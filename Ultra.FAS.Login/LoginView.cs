using PetaPoco;
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
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using Ultra.Surface.Common;
using Ultra.CoreCaller;
using System.Net.Http;
using System.IO;
using Ultra.Utility;
using Ultra.Surface.Lanuch;
using UltraDbEntity;

namespace Ultra.FAS.Login {
    public partial class LoginView : FrameWorkBaseSuperView {
        public LoginView() {
            InitializeComponent();
            this.DlgBgImg = this.BackgroundImage;
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            this.Enter += (s1, e1) => { TopMost = false; };
            this.Load += (s1, e1) => {

                Util.SetCache(this.Cacher);
                var lgn = OptConfig.Get<string>("Login");

                if (lgn != "admin") { txtUsr.Text = lgn; txtpwd.Focus(); }
# if DEBUG
                txtUsr.Text = "admin"; txtpwd.Text = "123";
#endif


            };

        }

        EFCaller<UltraDbEntity.T_ERP_User> LoginCalr { get; set; }

        private void btnCtl1_Click(object sender, EventArgs e) {
            LoginCalr = new EFCaller<UltraDbEntity.T_ERP_User>(new LoginController());

            if (!dxValidationProvider1.Validate()) return;
            var pwd = Util.EncryptPwd(txtpwd.Text);
            try {
                var rt = new Caller().InvokeTPPost<UltraDbEntity.T_ERP_User>(
                      new UltraDbEntity.T_ERP_User {
                          UserName = txtUsr.Text,
                          Pwd = ByteStringUtil.ByteArrayToHexStr(HashDigest.StringDigest(this.txtpwd.Text))
                      }, new LoginController(), "Authenticate");

                if (rt == null) {
                    MsgBox.ShowErrMsg("无效的用户名或密码!");
                    return;
                }
                LoginProcess(rt);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            } catch (Exception ex) {
                MsgBox.ShowErrMsg(ex.ToString());
            }
        }

        public void LoginProcess(UltraDbEntity.T_ERP_User rt) {
            this.Cacher.Put<bool>("IsNewMenu", true);
            this.Cacher.Put<UltraDbEntity.T_ERP_User>("CurrentUser", rt);
            this.Cacher.Put<string>("CurUser", rt.UserName);
            if (rt.UserName != "admin")
                OptConfig.Set<string>("Login", rt.UserName);

            Caller.SetHdr(rt.Reserved2);
        }

        private void btnCtl2_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        //更改配置
        private void labelControl1_Click(object sender, EventArgs e) {
            var vw = new ConfigView();
            this.Visible = false;
            vw.ShowDialog();
            this.Visible = true;
        }

        private void labelControl1_MouseHover(object sender, EventArgs e) {
            Cursor = Cursors.Hand;
        }

        private void labelControl1_MouseLeave(object sender, EventArgs e) {
            Cursor = Cursors.Default;
        }

        public override object CallBack(params object[] args) {
            if (args[0].ToString() == "LoginProcess") {
                LoginProcess(args[1] as UltraDbEntity.T_ERP_User);
                return null;
            } else
                return base.CallBack(args);
        }

        private void txtpwd_Enter(object sender, EventArgs e) {
        }

        private void txtpwd_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnCtl1_Click(null, null);

            }
        }

    }
}
