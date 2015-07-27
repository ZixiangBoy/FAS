using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Ultra.Common;
using Ultra.CoreCaller;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Lanuch;
using Ultra.Web.Core.Common;

namespace Ultra.FAS.Login {
    public partial class MenuView : BaseSurface {

        public MenuView() {
            InitializeComponent();
        }

        private void btnCtl1_Click(object sender, EventArgs e) {
            var md = new MenuData {
                IsUsing = checkCtl1.Checked,
                MenuGrpName = "新建菜单组",
                MenuItem = null
            };
            var nd = this.treeCtl1.Nodes.Add(new object[] { "新建菜单组", md });
            nd.Tag = md;
            this.treeCtl1.FocusedNode = nd;
        }

        private void btnCtl2_Click(object sender, EventArgs e) {
            var nd = this.treeCtl1.FocusedNode;
            var pnd = nd.ParentNode == null ? nd : nd.ParentNode;
            var md2 = new MenuData {
                IsUsing = checkCtl1.Checked,
                MenuGrpName = pnd.GetValue(0).ToString(),
                MenuItem = new MenuItemData {
                    IsUsing = checkCtl1.Checked,
                    MenuName = "新建菜单项",
                    MenuClsName = string.Empty,
                    MenuAsmName = string.Empty
                }
            };
            var tnd = pnd.Nodes.Add(new object[] { "新建菜单项", md2 });
            tnd.Tag = md2;
            this.treeCtl1.FocusedNode = tnd;
        }

        private void btnCtl5_Click(object sender, EventArgs e) {
            if (this.treeCtl1.FocusedNode == null) return;
            if (Ultra.Surface.Common.MsgBox.ShowYesNoMessage(null, "确定要删除吗?") == System.Windows.Forms.DialogResult.No)
                return;
            treeCtl1.Nodes.Remove(treeCtl1.FocusedNode);
        }

        private string BuildMenuXml() {
            XDocument xdoc = new XDocument(
                new XElement("Menus")
                );
            if (treeCtl1.Nodes.Count < 1)
                return xdoc.ToString();
            foreach (TreeListNode xd in treeCtl1.Nodes) {
                var ss = GetMenuGrp(xd);
                if (null != ss)
                    xdoc.Element("Menus").Add(ss);
            }
            return xdoc.ToString();
        }

        private List<UltraDbEntity.T_ERP_MenuNew> BuildNewMenuData() {
            var menus = new List<UltraDbEntity.T_ERP_MenuNew>();
            if (treeCtl1.Nodes.Count < 1)
                return null;
            var menuSort = 0;
            foreach (TreeListNode pd in treeCtl1.Nodes) {
                foreach (TreeListNode sd in pd.Nodes) {
                    var tg = sd.Tag as MenuData;
                    if (tg == null) continue;
                    menus.Add(new UltraDbEntity.T_ERP_MenuNew {
                        Guid = Guid.NewGuid(),
                        MenuGrpName = pd.GetValue(0).ToString(),
                        MenuAsmName = string.Empty,
                        MenuName = tg.MenuItem.MenuName,
                        IsUsing = tg.MenuItem.IsUsing,
                        MenuClsName = tg.MenuItem.MenuClsName,
                        Version = "1.0",
                        Remark = string.Empty,
                        Creator = this.CurUser,
                        Updator = this.CurUser,
                        MenuSort = ++menuSort,
                        Reserved1 = 0,
                        Reserved2 = string.IsNullOrEmpty(Lanucher.OptCfg.Get<string>("Ver")) ? string.Empty : Lanucher.OptCfg.Get<string>("Ver"),
                        Reserved3 = false
                    });
                }
            }
            return menus;
        }

        private XElement GetMenuGrp(TreeListNode nd) {
            var xe = new XElement("MenuGrp", new XAttribute("Name", nd.GetValue(0).ToString()));
            var ss = GetMenuItem(nd);
            if (null != ss)
                xe.Add(ss.ToArray());
            return xe;
        }

        private List<XElement> GetMenuItem(TreeListNode nd) {
            if (nd.Nodes == null || nd.Nodes.Count < 1) return null;
            List<XElement> xels = new List<XElement>(nd.Nodes.Count);
            foreach (TreeListNode xd in nd.Nodes) {
                MenuData tg = xd.Tag as MenuData;
                if (tg == null) continue;
                xels.Add(new XElement("MenuItem",
                    new XAttribute("Name", tg.MenuItem.MenuName),
                    new XAttribute("ClsName", tg.MenuItem.MenuClsName),
                    new XAttribute("AsmName", string.Empty),// tg.MenuItem.MenuAsmName),
                    new XAttribute("IsUsing", tg.MenuItem.IsUsing.ToString())
                    ));
            }
            return xels;
        }

        private void ExtractMenu(string xml) {
            if (string.IsNullOrEmpty(xml)) return;
            XDocument xdoc = XDocument.Parse(xml);
            foreach (XElement item in xdoc.Element("Menus").Elements()) {
                var md = new MenuData {
                    IsUsing = true,
                    MenuGrpName = item.Attribute("Name").Value,
                    MenuItem = null
                };
                var td = treeCtl1.Nodes.Add(new object[] { item.Attribute("Name").Value, md });
                td.Tag = md;
                foreach (XElement xd in item.Elements()) {
                    var mi = new MenuData {
                        IsUsing = string.Compare(xd.Attribute("IsUsing").Value, "true", true) == 0,
                        MenuGrpName = md.MenuGrpName,
                        MenuItem = new MenuItemData {
                            MenuAsmName = xd.Attribute("AsmName").Value,
                            MenuClsName = xd.Attribute("ClsName").Value,
                            MenuName = xd.Attribute("Name").Value,
                            IsUsing = string.Compare(true.ToString(), xd.Attribute("IsUsing").Value) == 0
                        }
                    };
                    var tsd = td.Nodes.Add(new object[] { 
                        mi.MenuItem.MenuName,mi
                    });
                    tsd.Tag = mi;
                }
            }
        }

        private void btnCtl6_Click(object sender, EventArgs e) {
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                File.WriteAllText(fdlg.FileName, BuildMenuXml());
                if (MsgBox.ShowYesNoMessage(null, "导出成功，是否立即打开?") == System.Windows.Forms.DialogResult.Yes) {
                    SystemInvoke.OpenFile(fdlg.FileName);
                }
            }
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCtl3_Click(object sender, EventArgs e) {
            if (MsgBox.ShowYesNoMessage(null, "重新加载菜单，有可能丢失当前的更改，是否继续?") ==
               System.Windows.Forms.DialogResult.No) return;
            //普及版本
            var bscver = Lanucher.OptCfg.Get<string>("Ver");
            var nmnus = Ultra.FASControls.SerNoCaller.Calr_MenuNew.Get(" SELECT * FROM T_ERP_MenuNew ");
            if (nmnus == null) return;
            treeCtl1.ClearNodes();
            LoadNewMenu(nmnus);
        }

        private void LoadNewMenu(List<UltraDbEntity.T_ERP_MenuNew> newmenus) {
            var mns = newmenus.Select(k => new MenuData {
                IsUsing = k.IsUsing,
                MenuGrpName = k.MenuGrpName,
                MenuItem = new MenuItemData {
                    MenuAsmName = k.MenuAsmName,
                    MenuName = k.MenuName,
                    MenuClsName = k.MenuClsName,
                    IsUsing = k.IsUsing
                }
            }).ToList();

            var grpname = string.Empty;
            TreeListNode td = null;
            mns.ForEach(smd => {
                if (string.IsNullOrEmpty(grpname) || !grpname.Equals(smd.MenuGrpName)) {
                    grpname = smd.MenuGrpName;
                    var md = new MenuData {
                        IsUsing = true,
                        MenuGrpName = smd.MenuGrpName,
                        MenuItem = null
                    };
                    td = treeCtl1.Nodes.Add(new object[] { md.MenuGrpName, md });
                }
                var tsd = td.Nodes.Add(new object[] { 
                        smd.MenuItem.MenuName,smd
                    });
                tsd.Tag = smd;
            });
        }

        private void treeCtl1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (e.Node == null) {
                txtMenuName.Text = txtModName.Text = string.Empty; return;
            }
            var mcd = e.Node.Tag as MenuData;
            if (null == mcd || mcd.MenuItem == null) {
                if (mcd != null)
                    txtmnugrpname.Text = mcd.MenuGrpName;
                txtMenuName.Text = txtModName.Text = string.Empty;
                return;
            }
            txtMenuName.Text = mcd.MenuItem.MenuName;
            txtModName.Text = mcd.MenuItem.MenuClsName;
            checkCtl1.Checked = mcd.MenuItem.IsUsing;
        }

        private void btnCtl7_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtMenuName.Text)) {
                return;
            }
            var nd = treeCtl1.FocusedNode;
            if (nd.ParentNode == null) {
                var xtg = nd.Tag as MenuData;
                xtg = xtg == null ? new MenuData {
                    MenuItem = null,
                    IsUsing = checkCtl1.Checked,
                    MenuGrpName = nd.GetValue(0).ToString()
                } : xtg;
                xtg.MenuGrpName = txtmnugrpname.Text;
                nd.Tag = xtg;
                nd.SetValue(0, txtmnugrpname.Text);
                return;
            }
            var tg = nd.Tag as MenuData;
            tg = tg == null ? new MenuData {
                MenuItem = new MenuItemData {
                    IsUsing = checkCtl1.Checked
                },
                IsUsing = checkCtl1.Checked,
                MenuGrpName = nd.ParentNode.GetValue(0).ToString()
            } : tg;
            tg.MenuItem.MenuClsName = txtModName.Text;
            tg.MenuItem.MenuAsmName = txtmnuAsm.Text;
            tg.MenuItem.MenuName = txtMenuName.Text;
            tg.MenuItem.IsUsing = checkCtl1.Checked;
            nd.SetValue(0, txtMenuName.Text);

            nd.Tag = tg;
        }


        public string Version { get; set; }
        private void btnCtl4_Click(object sender, EventArgs e) {
            if (treeCtl1.Nodes.Count < 1)
                return;
            if (MsgBox.ShowYesNoMessage("", "确定要保存菜单至服务器?") == System.Windows.Forms.DialogResult.No)
                return;
            //普及版本
            var bscver = Lanucher.OptCfg.Get<string>("Ver");
            //保存新菜单
            var newmenus = BuildNewMenuData();
            if (newmenus == null) return;
            var rd = new EditMenuController().EditMenuNew(newmenus, Version, bscver);
            if (!rd.IsOK) { MsgBox.ShowErrMsg(rd.ErrMsg); }

            MsgBox.ShowMessage("", "保存成功!");
        }

        private void btnCtl8_Click(object sender, EventArgs e) {
            var nd = treeCtl1.FocusedNode;
            if (null == nd) return;
            var md = nd.Tag as MenuData;
            if (null == md) return;
            if (nd.ParentNode == null) {
                md.MenuGrpName = txtmnugrpname.Text;
                nd.Tag = md;
                nd.SetValue(0, md.MenuGrpName);
            }

        }

        private void MenuView_Load(object sender, EventArgs e) {
        }
    }
}
