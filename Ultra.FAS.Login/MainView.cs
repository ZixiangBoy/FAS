using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Ultra.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Lanuch;
using Ultra.Win.Core.Common;
using Ultra.Web.Core.Common;
using Ultra.Surface.Common;
using DevExpress.XtraTabbedMdi;
using Ultra.CoreCaller;
using System.Reflection;
using System.Diagnostics;
using MoreLinq;
using System.IO;

namespace Ultra.FAS.Login {
    public partial class MainView : BaseSurface {
        public MainView() {
            InitializeComponent();
            Text = "客易工厂系统";
            this.navMenu.Groups.Clear();
            barStaticItem2.Caption =
            barStaticItem3.Caption = string.Empty;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new MenuView();
            Lanucher.InitView(vw);
            vw.MdiParent = this;
            vw.Version = this.Version.Left(3);
            vw.Show();
        }

        EFCaller<UltraDbEntity.T_ERP_User> UserCalr { get; set; }

        string Version = string.Empty; string VersionHash = string.Empty;

        //开启时间同步
        void StartTimeSync() {
            var t = new Thread(() => {
                var destr = new Caller().InvokeTPPost<UltraDbEntity.T_ERP_User>(
                      new UltraDbEntity.T_ERP_User { }, new LoginController(), "ServerTime");
                TimeSync.Default.StartSync(destr.CreateDate);
            });
            t.Start();
        }

        private void MainView_Load(object sender, EventArgs e) {
            this.Cacher.Put<BaseSurface>("MainView", this);
            var sftver = Lanucher.OptCfg.Get<string>("Ver");
            this.Cacher.Put<string>("SoftVer", sftver);

            ThreadLoadRoleTreeNew();
            LoadMenuNew();

            var tf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tile.tle");
            if (File.Exists(tf)) { Text = File.ReadAllText(tf, Encoding.Default); } else { Text = "客易工厂系统"; }
            Text = Text;// +" 版本: 演示评估版";
            StartTimeSync();
            if (!"admin".IgnoreCaseEqual(CurUser)) Text += "\t\t 用户: " + CurUser;


            Ultra.Utility.Common.GetMACs(out LocalMAC);
            Ultra.Utility.Common.GetLocalIpv4(out LocalIP);

            if ((this.CurUser.IgnoreCaseEqual("admin")))
                barButtonItem7.Visibility = BarItemVisibility.Always;
            else { barButtonItem7.Visibility = BarItemVisibility.Never; }

            
            ///////////////////////////////////////////////////////////////////
            var skinGallery = new DevExpress.XtraBars.Ribbon.GalleryDropDown();
            skinGallery.Manager = this.barManager1;
            this.barSkin.ButtonStyle = BarButtonStyle.DropDown;
            this.barSkin.DropDownControl = skinGallery;
            this.barSkin.ActAsDropDown = true;
            skinGallery.Gallery.ItemClick += (obj, se) => {
                this.OptConfig.Set<string>("SkinName", se.Item.Caption);
                Lanucher.ReLoadSkinName();
            };
            SkinHelper.InitSkinGalleryDropDown(skinGallery);

            this.barStaticItem2.Caption = this.CurUser;

            //读取远程IP
            var trmtip = new Thread(() => {
                try { RemoteIP = Ultra.Utility.Common.GetRemoteIP(); } catch { RemoteIP = string.Empty; }
                this.Invoke(new Action(() => { barStaticItem3.Caption += RemoteIP; }));

            }); trmtip.IsBackground = true; trmtip.Start();

            Thread t = new Thread(() => {
                while (true) {
                    Thread.Sleep(1000);
                    while (!this.IsHandleCreated && !this.IsDisposed) { }
                    try {
                        this.Invoke(new Action(() => {
                            barStaticItem4.Caption = TimeSync.Default.CurrentSyncTime.ToString("yyyy-MM-dd HH:mm:ss");
                        }));
                    } catch { }
                }
            });
            t.IsBackground = true;
            t.Start();
            this.Cacher.Put<Thread>("SyncTimeThread", t);


            StartAdminMenu();

            Task.Factory.StartNew(() => InitCache());
                    }
        private void InitCache()
        {
            SqlConnectionStringBuilder bld = new SqlConnectionStringBuilder(Lanucher.ConnectonString);
            this.Cacher.Put<string>("SYS.DataBase", bld.InitialCatalog);
            Ultra.FASControls.Views.ImageUploadView.DatabaseName = bld.InitialCatalog;
        }

        private void ThreadLoadRoleTreeNew() {
            var sftver = this.Cacher.Get<string>("SoftVer");
            var mnus = Ultra.FASControls.SerNoCaller.Calr_MenuNew.Get("SELECT * from T_ERP_MenuNew");
            if (null == mnus || mnus.Count < 1) return;
            this.Cacher.Put<List<UltraDbEntity.T_ERP_MenuNew>>("SYS.MenuLstNew", mnus);
        }

        private void LoadMenuNew() {
            this.navMenu.Groups.Clear();
            var sftver = this.Cacher.Get<string>("SoftVer");
            var mnus = this.Cacher.Get<List<UltraDbEntity.T_ERP_MenuNew>>("SYS.MenuLstNew");
            

            var grpname = string.Empty;
            NavBarGroup nbgp = null;
            foreach (var mn in mnus) {
                if (string.IsNullOrEmpty(grpname) || !grpname.Equals(mn.MenuGrpName)) {
                    var g = mn.Copy();
                    g.MenuName = string.Empty;
                    grpname = mn.MenuGrpName;
                    nbgp = this.navMenu.Groups.Add();
                    nbgp.Caption = mn.MenuGrpName;
                    nbgp.Tag = g;
                    nbgp.Visible = true;
                }
                if (!mn.IsUsing) continue;
                var lnk = new DevExpress.XtraNavBar.NavBarItem(mn.MenuName);
                nbgp.ItemLinks.Add(lnk);
                lnk.Visible = true;
                lnk.Tag = mn;
            }

            var mnustl = OptConfig.Get<string>("Menu");
            var mnustyle = mnustl;
            if (mnustyle == "Taobao") {
                barChkTaobao.Checked = true;
            } else
                barChkSys.Checked = true;

            if (string.Compare(mnustl, "taobao", true) == 0) {
                barChkTaobao.Checked = true; barChkSys.Checked = false;
                foreach (NavBarGroup gp in navMenu.Groups)
                    gp.Expanded = true;
            } else { barChkSys.Checked = true; barChkTaobao.Checked = false; }
            var w = OptConfig.Get<int>("MenuWidth");
            if (w > 0) this.navMenu.Width = w;
        }

        private void StartAdminMenu() {
            if (string.Compare(this.CurUser, "admin", true) == 0) {
                mnuSysParam.Enabled = true;
                mnuSysParam.Visibility = BarItemVisibility.Always;
                barBtnItemBrd.Visibility = BarItemVisibility.Always;
                //barBtnTrdChkPrm.Visibility = BarItemVisibility.Always;
            } else {

            }
        }


        private void barChkSys_CheckedChanged(object sender, ItemClickEventArgs e) {
            barChkTaobao.Checked = !this.barChkSys.Checked;
            if (barChkTaobao.Checked) {
                this.navMenu.PaintStyleKind = NavBarViewKind.ExplorerBar;
                navMenu.SkinExplorerBarViewScrollStyle = SkinExplorerBarViewScrollStyle.ScrollBar;
                spliter.Visible = true;
                foreach (NavBarGroup gp in navMenu.Groups)
                    gp.Expanded = true;
                OptConfig.Set<string>("Menu", "Taobao");
            }
        }

        private void barChkTaobao_CheckedChanged(object sender, ItemClickEventArgs e) {
            barChkSys.Checked = !this.barChkTaobao.Checked;
            if (barChkSys.Checked) {
                spliter.Visible = false;
                this.navMenu.PaintStyleKind = NavBarViewKind.NavigationPane;
                OptConfig.Set<string>("Menu", "System");
            }
        }

        //private List<UltraDbEntity.T_ERP_MenuCtl> MCD = null;
        private string LocalIP = string.Empty;
        private string RemoteIP = string.Empty;
        private string LocalMAC = string.Empty;

        private void navMenu_LinkClicked(object sender, NavBarLinkEventArgs e) {
            //if (IsNewMenu) {
                var md = e.Link.Item.Tag as UltraDbEntity.T_ERP_MenuNew;
                if (null == md)
                    return;
                if (string.IsNullOrEmpty(md.MenuName)) return;
                var vw = this.Cacher.Get<BaseSurface>(md.MenuClsName + "-" + md.MenuAsmName);
                if (null != vw && !vw.IsDisposed) {
                    vw.Activate(); return;
                }
                vw = Lanucher.Start(md.MenuClsName);
                if (null == vw) return;
                vw.Text = md.MenuName;
                vw.MdiParent = this;
                vw.LanucherParent = this;
                this.Cacher.Put<BaseSurface>(md.MenuClsName + "-" + md.MenuAsmName, vw);
                vw.Show();
                vw.Activate();
            //}
            //else {
            //    var md = e.Link.Item.Tag as MenuData;
            //    if (null == md)
            //        return;
            //    if (null == md.MenuItem) return;
            //    var vw = this.Cacher.Get<BaseSurface>(md.MenuItem.MenuClsName + "-" + md.MenuItem.MenuAsmName);
            //    if (null != vw && !vw.IsDisposed) {
            //        vw.Activate(); return;
            //    }
            //    vw = Lanucher.Start(md.MenuItem.MenuClsName);
            //    if (null == vw) return;
            //    vw.Text = md.MenuItem.MenuName;
            //    vw.MdiParent = this;
            //    vw.LanucherParent = this;
            //    this.Cacher.Put<BaseSurface>(md.MenuItem.MenuClsName + "-" + md.MenuItem.MenuAsmName, vw);
            //    vw.Show();
            //    vw.Activate();
            //}
        }

        private void spliter_SplitterMoved(object sender, SplitterEventArgs e) {
            OptConfig.Set<int>("MenuWidth", navMenu.Width);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e) {
            IsLogOff = false;
            Close();
        }

        private bool? IsLogOff = null;

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) {
            IsLogOff = true;
            Close();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e) {
            if (IsLogOff == null)
                IsLogOff = false;
            if (IsLogOff.Value) {
                if (MsgBox.ShowYesNoMessage("注销确认", "确定要注销吗?") == System.Windows.Forms.DialogResult.No) {
                    IsLogOff = false;
                    e.Cancel = true;
                    return;
                }
                var t = this.Cacher.Get<Thread>("SyncTimeThread");
                if (t.IsAlive) {
                    t.Abort();
                }
                DialogResult = System.Windows.Forms.DialogResult.No;
            } else {
                if (MsgBox.ShowYesNoMessage("退出确认", "确定要退出吗?") == System.Windows.Forms.DialogResult.No) { e.Cancel = true; IsLogOff = false; }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        /// <summary>
        /// 记录点击时间
        /// </summary>
        private DateTime m_LastClick = System.DateTime.Now;

        private void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                DateTime dt = DateTime.Now;
                TimeSpan span = dt.Subtract(m_LastClick);
                if (span.TotalMilliseconds < 300 && this.MdiChildren.Length > 0) {
                    if ((xtraTabbedMdiManager1.SelectedPage != null) && (xtraTabbedMdiManager1.SelectedPage.MdiChild != null) &&
                        xtraTabbedMdiManager1.SelectedPage == xtraTabbedMdiManager1.CalcHitInfo(new Point(e.X, e.Y)).Page as XtraMdiTabPage &&
                        this.ActiveMdiChild == xtraTabbedMdiManager1.SelectedPage.MdiChild)
                        this.ActiveMdiChild.Close();
                    m_LastClick = dt.AddMinutes(-1);
                } else m_LastClick = dt;
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e) {
            SystemInvoke.OpenFile("http://www.keyisoft.cn");
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e) {
            new SysInfoView().ShowDialog();
            var vw = new SysInfoView();
            Lanucher.InitView(vw).ShowDialog();
        }

        private void barBtnItemBrd_ItemClick(object sender, ItemClickEventArgs e) {
            //var vw = Lanucher.Start("Ultra.Mem.BroadEdtView");
            //if (null == vw) return;
            //vw.ShowDialog();
        }


        //修改密码
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e) {
            var vw = new ChgPwdView();
            vw.ShowDialog();
        }

        //修改配置
        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e) {
            if (CurUser == "admin") {
                var vw = new ConfigView();
                this.Visible = false;
                vw.ShowDialog();
                this.Visible = true;
            }
        }
    }
}
