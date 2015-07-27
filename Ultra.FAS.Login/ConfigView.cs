using DataAccess.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Lanuch;

namespace Ultra.FAS.Login
{
    public partial class ConfigView : DialogViewEx
    {
        public ConfigView()
        {
            InitializeComponent();
        }

        private void rdbWeb_CheckedChanged(object sender, EventArgs e)
        {
            gpweb.Enabled = true;
            gpdb.Enabled = false;
        }

        private void rdbDB_CheckedChanged(object sender, EventArgs e)
        {

            gpweb.Enabled = false;
            gpdb.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdbWeb.Checked)//web模式
            {
                if (string.IsNullOrEmpty(txtsvr.Text.Trim()))
                {
                    MsgBox.ShowErrMsg("请填入服务器地址!");
                    return;
                }
                var bok = TestWebCon();
                if (!bok) return;

                //连接成功
                Lanucher.SetMode(true);
                var svrurl = preUrl(txtsvr.Text.Trim());
                Ultra.CoreCaller.Caller.RootAddr = svrurl;
                Lanucher.SetSvrURL(svrurl);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else if (rdbDB.Checked)
            {
                string cn = string.Empty;
                var bok = dbcfgold.TryConnect(out cn);
                if (!bok)
                {
                    MsgBox.ShowErrMsg(MSG_TXTConnFail);
                    return;
                }
                //连接成功
                Lanucher.SetMode(false);
                Lanucher.SetConnectionStrng(cn);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            Lanucher.SetImgSvrURL(imgServer.Text.Trim());
            Application.Restart();
            //if (!string.IsNullOrEmpty(imgServer.Text))
            //{
            //    Lanucher.SetImgSvrURL(imgServer.Text.Trim());
            //}
        }
        private readonly string MSG_TXTConnFail = "无法连接至指定的数据库,可能的原因:\r\n1.数据库名称或数据库用户密码输入有误.\r\n2.网络连接失败.";

        string preUrl(string url)
        {
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "http://" + url;
            }
            if (!url.EndsWith("/"))
                url = url + "/";
            return url;
        }

        bool TestWebCon()
        {
            var url = txtsvr.Text.Trim();
            url = preUrl(url);
            var rot = url;

            /******passby webproxy ************/
            HttpClient client = new HttpClient();
            var ipx =
            System.Net.GlobalProxySelection.Select as System.Net.WebProxy;
            var ui = new Uri(rot);
            if (null != ipx) { var psl = ipx.BypassList.ToList(); psl.Add(ui.Host); ipx.BypassList = psl.ToArray(); }
            /*********************/
    
            client.BaseAddress = new Uri(rot);
            //api/test/get/
            url = string.Format("{0}{1}", rot, string.Empty
                //Ultra.Common.Util.Decrypt("6BBAA23AAC094522F3B9AF1D544E5D19")
                );
            try
            {
               
                //尝试访问
                var msg = client.GetStringAsync(url).Result;
    
                if (string.IsNullOrEmpty(msg))
                {
                    return false;
                }
                Ultra.CoreCaller.Caller.RootAddr = rot;
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#else
                MsgBox.ShowErrMsg(ex.Message);
                return false;
#endif
            }
        }

        bool TestImgWebCon()
        {
            var url = imgServer.Text.Trim();
            url = preUrl(url);
            var rot = url;
            /******passby webproxy ************/
            HttpClient client = new HttpClient();
            var ipx =
            System.Net.GlobalProxySelection.Select as System.Net.WebProxy;
            var ui = new Uri(rot);
            if (null != ipx) { var psl = ipx.BypassList.ToList(); psl.Add(ui.Host); ipx.BypassList = psl.ToArray(); }
            /*********************/

            url = string.Format("{0}{1}", rot,
                 //string.Empty
                Ultra.Common.Util.Decrypt("6BBAA23AAC094522F3B9AF1D544E5D19")
                );
            try
            {
                //尝试访问
                var msg = client.GetStringAsync(url).Result;
                if (string.IsNullOrEmpty(msg))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#else
                MsgBox.ShowErrMsg(ex.Message);
                return false;
#endif
            }
        }

        private void ConfigView_Load(object sender, EventArgs e)
        {
            rdbDB_CheckedChanged(null, null);
            dbcfgold.cmbsvr.TextChanged += cmbsvr_TextChanged;
        }

        void cmbsvr_TextChanged(object sender, EventArgs e)
        {
            var ips =dbcfgold.cmbsvr.Text.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (null == ips || ips.Length < 1) return;
            imgServer.Text = string.Format("http://{0}:30000/", ips[0]);
        }

        private void txtsvr_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "测试连接")
            {
                if (TestWebCon())
                {
                    MsgBox.ShowMessage("成功访问!服务器正在运行.");
                    return;
                }
            }
        }

        private void imgServer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "测试连接")
            {
                if (TestImgWebCon())
                {
                    Lanucher.SetImgSvrURL(imgServer.Text.Trim());
                    MsgBox.ShowMessage("成功访问!图片服务器正在运行.");
                    return;
                }
            }
            else if (e.Button.Caption == "保存配置")
            {
                if (TestImgWebCon())
                {
                    Lanucher.SetImgSvrURL(imgServer.Text.Trim());
                    MsgBox.ShowMessage("成功访问!图片服务器正在运行.");
                    return;
                }
            }
        }
    }
}
