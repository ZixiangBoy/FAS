using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ultra.Surface.Lanuch;
using Ultra.Surface.Form;
using Ultra.Surface.Common;
//using Ultra.Win.Core.Common;
using DevExpress.Skins;
using System.Threading;

using System.Diagnostics;
using System.IO;
using System.Text;

using Ultra.Web.Core.Common;
using Ultra.FAS.ERP.Shell;

namespace Ultra.FAS.ERP
{
    static class Program
    {
        static Ultra.Log.ApplicationLog AppLog = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {         
            AppLog = new Ultra.Log.ApplicationLog();
            try
            {
                var dsk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                var lnk = Path.Combine(dsk, "客易工厂系统.lnk");
                var hdsk = Path.Combine(dsk, "Ultra.WLSys.ERP.exe.lnk");
                if (File.Exists(hdsk)) File.Delete(hdsk);
                hdsk = Path.Combine(dsk, "客易工厂系统.exe.lnk");
                if (File.Exists(hdsk)) File.Delete(hdsk);
                using (ShellLink shortcut = new ShellLink())
                {
                    shortcut.Target = Application.ExecutablePath;
                    shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                    shortcut.Description = "客易工厂系统";
                    shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
                    shortcut.Save(lnk);
                }
                var p = Process.Start(new ProcessStartInfo
                  {
                      FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SvcUpdate.exe"),//+ " cli",                    
                      Arguments = "cli"
                  });
            }
            catch { }
            finally { }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        __start:
            string con = string.Empty;
            Ultra.Web.Core.Configuration.OptionConfig cfg = null;
            BaseSurface vw;
            //if (null == args || args.Length < 1)
            {
                cfg = Lanucher.OptCfg;


                //--登录前加载特定模块，以进行登录前的一些数据处理或更新操作
                string upd_dll = "Ultra.BLgn.dll";
                var dllp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, upd_dll);
                if (File.Exists(dllp))
                {
                    try
                    {
                        var asm = System.Reflection.Assembly.LoadFrom(dllp);
                        var tp = asm.GetType("Ultra.BLgn.Update");
                        if (null != tp)
                        {
                            var mi = tp.GetMethod("Run",
                            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                            if (null != mi)
                            {
                                //Thread t = new Thread(() =>
                                //{
                                    try
                                    {
                                        mi.Invoke(null, new object[] { cfg });
                                    }
                                    catch { }
                                //});
                                //t.IsBackground = true;
                                //t.SetApartmentState(ApartmentState.STA);
                                //t.Start();
                            }
                        }
                    }
                    catch { }
                }

                Lanucher.ReLoadConfig();
#if DEBUG
                //var rw = cfg.Get<string>("RDSWEB");
                //if (string.IsNullOrEmpty(rw))
                //{
                //    cfg.Set<string>("RDSWEB", "http://121.196.129.96/ext/dfghjkl/");
                //}

                //rw = cfg.Get<string>("RDSWEB");
                //Lanucher.Cache.Put<string>("Ultra.SYS.RDS", rw);
#endif
                if (Lanucher.IsNeedUsrCfg)
                {
                    var cfgvw = Lanucher.Start("Ultra.FAS.Login.ConfigView");
                    if (cfgvw.ShowDialog() != DialogResult.OK)
                    {
                        MsgBox.ShowErrMsg("配置错误!应用程序即将退出");
                        return;
                    }
                }


                //Ultra.Surface.Lanuch.Lanucher.Start("FAS.FinView.FinRptView").ShowDialog(); return;
                vw = Lanucher.Start("Ultra.FAS.Login.LoginView");//.ShowDialog();
                con = vw.ConnString;

            }
            var dt = vw.ShowDialog();
            if (dt == DialogResult.OK)//登录成功
            {
                if (null == args || args.Length < 1)
                {
                    vw = Lanucher.Start("Ultra.FAS.Login.MainView");
                }
                else
                    vw = Lanucher.Start(args[0]);

            }
            else if (dt == DialogResult.Cancel)//退出
            {
                return;
            }
            dt = vw.ShowDialog();
            if (dt == DialogResult.No)
            {
                Lanucher.Clean("OfficeSkins.Register()");
                goto __start;
            }

        }

        /// <summary>
        /// 检查是否正常连接至数据库
        /// </summary>
        /// <returns></returns>
        static bool CanConnDb(string _connstr)
        {
            //try
            //{
            //    using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection
            //(_connstr))
            //    {
            //        con.Open();
            //    }
            //    return true;
            //}
            //catch
            //{ return false; }
            return true;
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            AppLog.DebugException(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AppLog.DebugException(new Exception(e.ToString()));
        }

        // <summary>  
        /// 对字符串进行压缩  
        /// </summary>  
        /// <param name="str">待压缩的字符串</param>  
        /// <returns>压缩后的字符串</returns>  
        public static string CompressString(string str)
        {
            string compressString = "";
            byte[] compressBeforeByte = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] compressAfterByte = Compress(compressBeforeByte);
            //compressString = Encoding.GetEncoding("UTF-8").GetString(compressAfterByte);  
            compressString = Convert.ToBase64String(compressAfterByte);
            return compressString;
        }
        /// <summary>  
        /// 对字符串进行解压缩  
        /// </summary>  
        /// <param name="str">待解压缩的字符串</param>  
        /// <returns>解压缩后的字符串</returns>  
        public static string DecompressString(string str)
        {
            string compressString = "";
            //byte[] compressBeforeByte = Encoding.GetEncoding("UTF-8").GetBytes(str);  
            byte[] compressBeforeByte = Convert.FromBase64String(str);
            byte[] compressAfterByte = Decompress(compressBeforeByte);
            compressString = System.Text.Encoding.UTF8.GetString(compressAfterByte);
            return compressString;
        }
        // <summary>  
        /// 对byte数组进行压缩  
        /// </summary>  
        /// <param name="data">待压缩的byte数组</param>  
        /// <returns>压缩后的byte数组</returns>  
        public static byte[] Compress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress, true);
                zip.Write(data, 0, data.Length);
                zip.Close();
                byte[] buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static byte[] Decompress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress, true);
                MemoryStream msreader = new MemoryStream();
                byte[] buffer = new byte[0x1000];
                while (true)
                {
                    int reader = zip.Read(buffer, 0, buffer.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    msreader.Write(buffer, 0, reader);
                }
                zip.Close();
                ms.Close();
                msreader.Position = 0;
                buffer = msreader.ToArray();
                msreader.Close();
                return buffer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Convert a string to packed ascii byte array
        /// </summary>
        /// <param name="toBePacked">ascii string to be packed</param>
        /// <returns>packed ascii byte array</returns>
        public static byte[] PackAscii(string toBePacked)
        {
            // convert the ascii to a byte array 
            byte[] ascii = System.Text.Encoding.ASCII.GetBytes(toBePacked.PadRight(8, ' '));
            List<byte> packedAscii = new List<byte>();
            int index = 0;

            // loop through four bytes at a time and pack them into three bytes.
            for (int i = 0; i < ascii.Length; i = i + 4)
            {
                // perform the bitwise operations to truncate the 6th and 7th bit
                uint result = (uint)(((ascii[index] & 0x3F) << 18) +
                                        ((ascii[index + 1] & 0x3F) << 12) +
                                        ((ascii[index + 2] & 0x3F) << 6) +
                                            (ascii[index + 3] & 0x3F));

                // Convert the uint array to byte. If the bitconverter class
                // is little endian, needs to be reversed. 
                byte[] packedTemp = BitConverter.GetBytes(result);
                if (BitConverter.IsLittleEndian)
                {
                    // Reverse the array and skip the first byte
                    Array.Reverse(packedTemp);
                    for (int k = 1; k < 4; k++)
                    {
                        packedAscii.Add(packedTemp[k]);
                    }
                }
                else
                {
                    // Not little endian so just add the first three bytes.
                    for (int j = 0; j < 3; j++)
                    {
                        packedAscii.Add(packedTemp[j]);
                    }
                }
                index += 4;
            }

            return packedAscii.ToArray();
        }

        abstract class Contracts
        {
            public enum EncodingFormat
            {
                Old,
                New,
            };
        }

        class RLE : Contracts, IDisposable
        {
            private string str_base, str_rle;

            private bool HasChar(ref string input)
            {
                bool status = false;

                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsLetter(input[i]))
                    {
                        status = true;
                        break;
                    }
                }

                return status;
            }

            internal string Encode(string input, EncodingFormat format)
            {
                str_rle = null;
                str_base = input;

                if (format == EncodingFormat.New)
                {
                    for (int i = 0; i < str_base.Length; i++)
                    {
                        char symbol = str_base[i];
                        int count = 1;

                        for (int j = i; j < str_base.Length - 1; j++)
                        {
                            if (str_base[j + 1] != symbol) break;

                            count++;
                            i++;
                        }
                        if (count == 1) str_rle += symbol;
                        else str_rle += count.ToString() + symbol;
                    }
                }
                else if (format == EncodingFormat.Old)
                {
                    for (int i = 0; i < str_base.Length; i++)
                    {
                        char symbol = str_base[i];
                        int count = 1;

                        for (int j = i; j < str_base.Length - 1; j++)
                        {
                            if (str_base[j + 1] != symbol) break;

                            count++;
                            i++;
                        }

                        str_rle += count.ToString() + symbol;
                    }
                }

                return str_rle;
            }

            internal string Decode(string input)
            {
                str_rle = null;
                str_base = input;
                int radix = 0;

                for (int i = 0; i < str_base.Length; i++)
                {
                    if (Char.IsNumber(str_base[i]))
                    {
                        radix++;
                    }
                    else
                    {
                        if (radix > 0)
                        {
                            int value_repeat = Convert.ToInt32(str_base.Substring(i - radix, radix));

                            for (int j = 0; j < value_repeat; j++)
                            {
                                str_rle += str_base[i];
                            }

                            radix = 0;
                        }
                        else if (radix == 0)
                        {
                            str_rle += str_base[i];
                        }
                    }
                }

                if (str_rle == null || !HasChar(ref str_rle)) throw new Exception("\r\nCan't to decode! Input string has the wrong syntax. There isn't any char (e.g. 'a'->'z') in your input string, there was/were only number(s).\r\n");

                return str_rle;
            }

            internal double GetPercentage(double x, double y)
            {
                return (100 * (x - y)) / x;
            }

            public void Dispose()
            {
                if (str_rle != null || str_base != null)
                {
                    str_rle = str_base = null;
                }
            }
        }
    }
}
