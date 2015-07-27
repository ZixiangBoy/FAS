using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Cache.Interface;
using Ultra.Web.Core.Common;

namespace Ultra.Common
{
    public sealed class Util
    {

        private static string ConKey = "1F520EC40D7FDD0E2C517288FA4C5B12";
        private static string PwdKey = "9E437346EBA2CB75FF37234EC8EE35D0";

        public static string Encrypt(string src)
        {
            DESEncrypt d = new DESEncrypt();
            return d.EncryptString(src, ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(ConKey)));
        }

        public static string Decrypt(string src)
        {
            DESEncrypt d = new DESEncrypt();
            return d.DecryptString(src, ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(ConKey)));
        }

        public static string EncryptPwd(string src)
        {
            DESEncrypt d = new DESEncrypt();
            return ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(
                d.EncryptString(src, ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(PwdKey)))));
        }

        public static byte[] EncryptToByte(string src)
        {
            DESEncrypt d = new DESEncrypt();
            return d.Encrypt(Encoding.UTF8.GetBytes(src), PwdKey);
        }
        private static Ultra.Cache.Interface.ICache _Che;
        public static Ultra.Cache.Interface.ICache SetCache(ICache che)
        {
            return _Che = che;
        }

        public static bool IsBSMode
        {
            get
            {
                return _Che.Get<bool>("Ultra.SYS.Core.BSMode");
            }
        }

        public static string ImgSvrURL
        {
            get { return _Che.Get<string>("UltraServerImage"); }
        }

        //public static string Decrypt(string src)
        //{
        //    DESEncrypt d = new DESEncrypt();
        //    return d.DecryptString(src, ByteStringUtil.ByteArrayToHexStr(
        //        HashDigest.StringDigest(ConKey)));
        //}

        /// <summary>
        /// 获取本地打印机列表
        /// </summary>
        /// <returns></returns>
        public static List<string> EnumPrinter()
        {
            List<string> prts = new List<string>();
            using (PrintDocument prtdoc = new PrintDocument())
            {
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//获取默认的打印机名 

                foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                    prts.Add(strPrinter);
            }
            return prts;
        }
    }

    internal static class MsgBoxI
    {
        public static DialogResult ShowMessage(string cap, string text)
        {
            if (string.IsNullOrEmpty(cap))
                cap = "提示";
            return XtraMessageBox.Show(text, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowYesNoMessage(string cap, string text)
        {
            if (string.IsNullOrEmpty(cap))
                cap = "提示";
            return XtraMessageBox.Show(text, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }

    public static class ExtendCommon
    {
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="filepath"></param>
        public static void ConfirmExportOK(string filepath, bool showtip = true)
        {
            if (showtip)
            {
                if (MsgBoxI.ShowYesNoMessage("导出成功", "导出成功,是否立即打开?") == DialogResult.Yes)
                {
                    SystemInvoke.OpenFile(filepath);
                }
            }
            else
                SystemInvoke.OpenFile(filepath);
        }

        private static SaveFileDialog _fdlg = null;
        internal static SaveFileDialog fdlg
        {
            get
            {
                return _fdlg = _fdlg == null ? new SaveFileDialog() : _fdlg;
            }
        }

        /// <summary>
        /// Grid导出功能
        /// </summary>
        /// <param name="gc"></param>
        public static void GridExportXls(this DevExpress.XtraGrid.GridControl gc)
        {
            fdlg.Filter = "*.xls|*.xls";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                gc.ExportToXls(fdlg.FileName);
                ConfirmExportOK(fdlg.FileName, true);
            }
        }

        /// <summary>
        /// 字符串转颜色
        /// </summary>
        /// <param name="clor"></param>
        /// <returns></returns>
        public static System.Drawing.Color ToColor(this string clor)
        {
            return GetColorFromString(clor);
        }

        /// <summary>
        /// 字符串转颜色
        /// </summary>
        /// <param name="colorString"></param>
        /// <returns></returns>
        public static Color GetColorFromString(string colorString)
        {
            Color color = Color.Empty;
            ColorConverter converter = new ColorConverter();
            //try
            //{
            color = (Color)converter.ConvertFromString(colorString);
            //}
            //catch
            //{ }
            return color;
        }

        /// <summary>
        /// 获取本机网卡地址列表
        /// </summary>
        /// <param name="mac">输出 网卡地址</param>
        /// <returns></returns>
        public static List<string> GetMACs(out string mac)
        {
            string MAC = string.Empty;
            NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
            List<string> MACS = new List<string>();
            foreach (NetworkInterface ni in nis)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    PhysicalAddress pa = ni.GetPhysicalAddress();

                    MAC = pa.ToString();
                    MACS.Add(MAC);
                    //break;
                }
            }
            mac = MAC;
            if (MACS.Count > 0)
                return MACS;//MACS.Aggregate((s1, s2) => s1 + "," + s2).ToString();
            else
                return null;
        }

        /// <summary>
        /// 获取外网IP
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteIP()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(
                //@"http://www.wwplugin.com/hello.asp"
            Util.Decrypt("BCF3B3613BE762018CD2EB94F6C11AEF0003224E1A222688E9C22379BBDDCB76774470C31FBE8753")
            );
            var res = (HttpWebResponse)req.GetResponse();
            using (var sm = new StreamReader(res.GetResponseStream()))
            {
                return sm.ReadToEnd();
            }
        }

        /// <summary>
        /// 获取本机IPV4 IP
        /// </summary>
        /// <param name="LocalIP"></param>
        /// <returns></returns>
        public static string[] GetLocalIpv4(out string LocalIP)
        {
            LocalIP = string.Empty;
            //事先不知道ip的个数，数组长度未知，因此用StringCollection储存
            IPAddress[] localIPs;
            localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            StringCollection IpCollection = new StringCollection();
            foreach (IPAddress ip in localIPs)
            {
                //根据AddressFamily判断是否为ipv4,如果是InterNetWorkV6则为ipv6
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIP = ip.ToString();
                    IpCollection.Add(ip.ToString());
                }
            }
            string[] IpArray = new string[IpCollection.Count];
            IpCollection.CopyTo(IpArray, 0);
            return IpArray;
        }

        /// <summary>
        /// 采番功能函数
        /// 获取系统生成番号
        /// </summary>
        /// <param name="prefix">番号前缀</param>
        /// <param name="ending">番号后缀</param>
        /// <returns>番号</returns>
        public static string GetSysNo(string prefix, string ending = "")
        {
            //var prm = new MySql.Data.MySqlClient.MySqlParameter("?prfix", prefix);
            //var prm2 = new MySql.Data.MySqlClient.MySqlParameter("?ending", ending);
            //var prm3 = new MySql.Data.MySqlClient.MySqlParameter("?sysno", string.Empty);
            //prm3.Direction = System.Data.ParameterDirection.Output;
            //MySqlHelper.ExecuteNonQuery(Ultra.Surface.Lanuch.Lanucher.ConnectonString
            //    , System.Data.CommandType.StoredProcedure, "P_FAC_GenSysNo",
            //    new MySql.Data.MySqlClient.MySqlParameter[] { 
            //        prm,prm2,prm3
            //    });
            //return prm3.Value.ToString();
            return string.Empty;
        }

        //public static void RequestPermit(this Ultra.Surface.Form.BaseSurface vw)
        //{
        //    if (null == vw) return;
        //    var fulclsname = vw.GetType().FullName;
        //    var cur = vw.GetCurUser<t_fac_user>();
        //    var mcd = vw.Cacher.Get<List<MenuCtlData>>("FAC.SYS.Permission");
        //    if (null == mcd && !cur.UserName.EqualIgnorCase("admin")) return;
        //    var isp = vw as ISurfacePermission;
        //    if (null == isp) return;
        //    try
        //    {
        //        try
        //        {
        //            var tbi = isp.ToolBarItems;
        //            if (null != tbi && tbi.Count > 0)
        //            {
        //                if (!cur.UserName.EqualIgnorCase("admin"))
        //                {
        //                    var mc = mcd.Where(k => k.CtlType == EnCtlType.ToolBarItems && k.ClsName ==
        //                         vw.GetType().FullName
        //                         );
        //                    tbi.Where(j => mc.Any(k => k.ControlName == j.Name)).ToList().ForEach
        //                        (j =>
        //                        {
        //                            j.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //                        });
        //                }
        //                else
        //                {
        //                    tbi.ForEach(k => k.Visibility = DevExpress.XtraBars.BarItemVisibility.Always);
        //                }
        //            }
        //        }
        //        catch { }
        //        try
        //        {
        //            var tbi = isp.Grids;
        //            if (null != tbi && tbi.Count > 0)
        //            {
        //                if (!cur.UserName.EqualIgnorCase("admin"))
        //                {
        //                    var mc = mcd.Where(k => k.CtlType == EnCtlType.Grids && k.ClsName ==
        //                         vw.GetType().FullName
        //                         );//gridview
        //                    var mch = tbi.Where(j => mc.Any(k => k.ControlName == j.Gv.Name));//gridview
        //                    var cols = mcd.Where(k => mch.Any(j => k.ParentCtlName != null && j.Gv.Name == k.ParentCtlName)).ToList();

        //                    var mcol = cols.Where(k => k.CtlType == EnCtlType.GridCol && k.IsEnabled).ToList();//gridcolumn

        //                    var kts = mch.ToList();
        //                    foreach (var k in kts)
        //                    {
        //                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in k.Gv.Columns)
        //                        {
        //                            var ktmch = mcol.Where(t => t.ControlName == col.Name && t.ClsName == fulclsname && t.IsEnabled).FirstOrDefault();
        //                            col.Visible = null != ktmch;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    //tbi.ForEach(k => { 

        //                    //});
        //                }
        //            }
        //        }
        //        catch { }
        //        try
        //        {

        //            var tbn = isp.ButtonItems;
        //            if (null != tbn && tbn.Count > 0)
        //            {
        //                if (!cur.UserName.EqualIgnorCase("admin"))
        //                {
        //                    var mc = mcd.Where(k => k.CtlType == EnCtlType.ButtonItems && k.ClsName == vw.GetType().FullName
        //                        && k.IsEnabled);
        //                    tbn.Where(k => mc.Any(j => j.ControlName == k.Name)).ToList().ForEach
        //                        (k =>
        //                        {
        //                            k.Visible = true;
        //                        });
        //                }
        //            }
        //        }
        //        catch { }

        //    }
        //    catch { }
        //}

        [DllImport("user32.dll")]
        // GetCursorPos() makes everything possible
        static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
        IntPtr hWnd,
        int Msg,
        int wParam,
        int lParam
        );
        //按下鼠标左键
        public static int WM_LBUTTONDOWN = 0x0201;
        //释放鼠标左键
        public static int WM_LBUTTONUP = 0x0202;

        public static void PostMsgMouseClick(Control ctl )
        {
            SendMessage((IntPtr)ctl.Handle, WM_LBUTTONDOWN, 0, 0);
            SendMessage((IntPtr)ctl.Handle, WM_LBUTTONUP, 0, 0);
        }

        /// <summary>
        /// 获取当前鼠标坐村
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        public static Point GetMousePos(this Form frm)
        {
            Point pt = new Point(); pt.X = pt.Y = 0;
            GetCursorPos(ref pt);
            return pt;
        }

        public static TDest MapTo<TSrc, TDest>(this TSrc oj)
        {
            //EmitMapper.ObjectsMapper<TSrc, TDest> mapper =
            return EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<TSrc, TDest>().Map(oj);
        }

        /// <summary>
        /// 判断两个时间范围是否存在重合，如果存在重合则返回true
        /// </summary>
        /// <param name="dr1"></param>
        /// <param name="dr2"></param>
        /// <returns></returns>
        public static bool IsOverlap(this DateTimeRange dr1, DateTimeRange dr2)
        {
            //bool overlap = dr1.Begin < dr2.End && dr2.Begin < dr1.End;
            bool overlap = dr1.Begin.DateDiff(EnDatePart.SECOND, dr2.End) < 0
                && dr2.Begin.DateDiff(EnDatePart.SECOND, dr1.End) < 0;
            return overlap;
        }

        internal static Stack<DevExpress.Utils.WaitDialogForm> StkWaitView = new Stack<DevExpress.Utils.WaitDialogForm>(8);

        /// <summary>
        /// 开始一个等待窗口
        /// </summary>
        /// <param name="vw"></param>
        /// <returns></returns>
        public static void BeginWaitDlg(this Form vw,string text,string title="")
        {
            Application.DoEvents();
            var t = new Thread(() =>
            {
                DevExpress.Utils.WaitDialogForm dlg = null;
                StkWaitView.Push(dlg);
                dlg = new DevExpress.Utils.WaitDialogForm(text,string.IsNullOrEmpty(title)?"正在处理,请稍候...":title);
                //dlg.ShowDialog();
            });
            t.IsBackground = true; t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public static void EndWaitDlg(this Form vw)
        {
            try
            {
                var dlg = StkWaitView.Pop();
                if (null == dlg) return;
                dlg.Invoke(new Action(() =>
                {
                    dlg.Close();
                }));
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 获取指定对象的方法
        /// </summary>
        /// <param name="oj"></param>
        /// <param name="methodname"></param>
        /// <returns></returns>
        public static System.Reflection.MethodInfo GetMethod(this object oj,string methodname)
        {
            var mi = oj.GetType().GetMethod(methodname, System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
            //var mis = oj.GetType().GetMethods(System.Reflection.BindingFlags.NonPublic |
            //     System.Reflection.BindingFlags.Instance);
            //var mch =mis.Where(j => j.Name.EqualIgnorCase(methodname)).FirstOrDefault();
            //return null;
            return mi;
        }

        public static DateTime? IgnoreHourMinSec(this DateTime? de)
        {
            if (null == de) return de;
            DateTime d = de.Value;
            DateTime dn = DateTime.Parse(d.ToString("yyyy-MM-dd"));
            DateTime? drtn = dn;
            return drtn;
        }

        public static DateTime IgnoreHourMinSec(this DateTime de)
        {
            DateTime d = de;
            DateTime dn = DateTime.Parse(d.ToString("yyyy-MM-dd"));
            DateTime drtn = dn;
            return drtn;
        }

        /// <summary>
        /// 匹配分组第一项
        /// </summary>
        /// <param name="str"></param>
        /// <param name="rgx"></param>
        /// <returns></returns>
        public static string RegExMatchFirst(this string str,string rgx)
        {
            System.Text.RegularExpressions.Regex rg=new System.Text.RegularExpressions.Regex(rgx, 
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            var mch =rg.Match(str);
            if (null == mch || mch.Groups == null || mch.Groups.Count < 2)
                return null;
            return mch.Groups[1].Value;
        }
    }


    public sealed class Base32
    {

        // the valid chars for the encoding
        private static string ValidChars = "QAZ2WSX3" + "EDC4RFV5" + "TGB6YHN7" + "UJM8K9LP";

        /// <summary>
        /// Converts an array of bytes to a Base32-k string.
        /// </summary>
        public static string ToBase32String(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();         // holds the base32 chars
            byte index;
            int hi = 5;
            int currentByte = 0;

            while (currentByte < bytes.Length)
            {
                // do we need to use the next byte?
                if (hi > 8)
                {
                    // get the last piece from the current byte, shift it to the right
                    // and increment the byte counter
                    index = (byte)(bytes[currentByte++] >> (hi - 5));
                    if (currentByte != bytes.Length)
                    {
                        // if we are not at the end, get the first piece from
                        // the next byte, clear it and shift it to the left
                        index = (byte)(((byte)(bytes[currentByte] << (16 - hi)) >> 3) | index);
                    }

                    hi -= 3;
                }
                else if (hi == 8)
                {
                    index = (byte)(bytes[currentByte++] >> 3);
                    hi -= 3;
                }
                else
                {

                    // simply get the stuff from the current byte
                    index = (byte)((byte)(bytes[currentByte] << (8 - hi)) >> 3);
                    hi += 5;
                }

                sb.Append(ValidChars[index]);
            }

            return sb.ToString();
        }


        /// <summary>
        /// Converts a Base32-k string into an array of bytes.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Input string <paramref name="s">s</paramref> contains invalid Base32-k characters.
        /// </exception>
        public static byte[] FromBase32String(string str)
        {
            int numBytes = str.Length * 5 / 8;
            byte[] bytes = new Byte[numBytes];

            // all UPPERCASE chars
            str = str.ToUpper();

            int bit_buffer;
            int currentCharIndex;
            int bits_in_buffer;

            if (str.Length < 3)
            {
                bytes[0] = (byte)(ValidChars.IndexOf(str[0]) | ValidChars.IndexOf(str[1]) << 5);
                return bytes;
            }

            bit_buffer = (ValidChars.IndexOf(str[0]) | ValidChars.IndexOf(str[1]) << 5);
            bits_in_buffer = 10;
            currentCharIndex = 2;
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)bit_buffer;
                bit_buffer >>= 8;
                bits_in_buffer -= 8;
                while (bits_in_buffer < 8 && currentCharIndex < str.Length)
                {
                    bit_buffer |= ValidChars.IndexOf(str[currentCharIndex++]) << bits_in_buffer;
                    bits_in_buffer += 5;
                }
            }

            return bytes;
        }
    }
}
