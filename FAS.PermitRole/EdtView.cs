using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Ultra.Common;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Surface.Lanuch;
using Ultra.Web.Core.Common;
using Ultra.FASControls.Caller;
using Ultra.FASControls.Extend;
using Ultra.FASControls.Controllers;
using Ultra.FASControls;

namespace FAS.PermitRole
{
    public partial class EdtView : DialogViewEx {
        public EdtView() {
            InitializeComponent();
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
                        IsUsing = true,
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

        private void ExtractMenuNew() {
            var mnus=SerNoCaller.Calr_MenuNew.Get(" where isusing=1");

            //var mnus = this.Cacher.Get<List<UltraDbEntity.T_ERP_MenuNew>>("SYS.MenuLstNew");
            if (mnus == null || mnus.Count < 1) return;

            var grpname = string.Empty;
            TreeListNode td = null;
            foreach (var mn in mnus) {
                if (string.IsNullOrEmpty(grpname) || !grpname.Equals(mn.MenuGrpName)) {
                    var g = mn.Copy();
                    g.MenuName = string.Empty;
                    grpname = g.MenuGrpName;
                    td = treeCtl1.Nodes.Add(new object[] { g.MenuGrpName, g });
                }
                var tsd = td.Nodes.Add(new object[] { 
                        mn.MenuName,mn
                    });
                tsd.Tag = mn;
            }
        }

        private void BuildlRoleTree() {
            foreach (TreeListNode td in treeCtl1.Nodes) {
                foreach (TreeListNode tm in td.Nodes) {

                    if (IsNewMenu) {
                        var md = tm.Tag as UltraDbEntity.T_ERP_MenuNew;
                        if (null == md || string.IsNullOrEmpty(md.MenuName)) continue;
                        RefcNew(md.MenuClsName, md.MenuAsmName, tm);
                    } else {
                        var md = tm.Tag as MenuData;
                        if (null == md || md.MenuItem==null) continue;
                        Refc(md.MenuItem.MenuClsName, md.MenuItem.MenuAsmName, tm);
                    }
                }
            }
        }

        private void RefcNew(string cls, string mod, TreeListNode mnu) {
            try {
                var cacheKYPrefix = "SYS.SpeedOpt";
                var pth = Path.Combine(Lanucher.AppDir, mod);
                var md5 = string.Empty;
                //if (File.Exists(pth))
                //{
                //    md5 = ByteStringUtil.ByteArrayToHexStr(HashDigest.FileDigest(pth));
                //}
                var cheoj = Lanucher.Cache.Get<BaseSurface>(string.Format("{0}.{1}", cacheKYPrefix, cls));
                var m = cheoj == null ? Lanucher.Load(cls) : cheoj;
                if (null == cheoj) Lanucher.Cache.Put<BaseSurface>(string.Format("{0}.{1}"
                    , cacheKYPrefix, cls), m);

                var ip = m as ISurfacePermission;
                if (null == ip) return;
                var toolbar = ip.ToolBarItems;
                var grids = ip.Grids;
                var btns = ip.ButtonItems;
                if (null != toolbar && toolbar.Count > 0) {
                    var td = mnu.Nodes.Add(new object[] { "主操作按钮" });
                    foreach (var ti in toolbar) {
                        var tds = td.Nodes.Add(new object[] { ti.Caption });
                        tds.Tag = new UltraDbEntity.T_ERP_MenuCtl {
                            ControlName = ti.Name,
                            TextName = ti.Caption,
                            CtlType = (int)EnCtlType.ToolBarItems,
                            IsEnabled = false,
                            ClsName = cls,
                            ModName = mod,
                            ModMD5 = md5
                        };
                    }
                }
                if (null != grids && grids.Count > 0) {
                    foreach (var ti in grids) {
                        var td = mnu.Nodes.Add(new object[] { ti.Name });
                        td.Tag = new UltraDbEntity.T_ERP_MenuCtl {
                            ControlName = ti.Gv.Name,
                            TextName = ti.Name,
                            CtlType = (int)EnCtlType.Grids,
                            IsEnabled = false,
                            ClsName = cls,
                            ModName = mod,
                            ModMD5 = md5
                        };
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in ti.Gv.Columns) {
                            if (!col.Visible) continue;
                            var tdc = td.Nodes.Add(new object[] { col.Caption });

                            tdc.Tag = new UltraDbEntity.T_ERP_MenuCtl {
                                ControlName = col.Name,
                                ParentCtlName = ti.Gv.Name,
                                TextName = col.Caption,
                                CtlType = (int)EnCtlType.GridCol,
                                IsEnabled = false,
                                ClsName = cls,
                                ModName = mod,
                                ModMD5 = md5
                            };
                        }
                    }
                }
                if (null != btns && btns.Count > 0) {
                    var td = mnu.Nodes.Add(new object[] { "自定义按钮" });
                    foreach (var ti in btns) {
                        var tds = td.Nodes.Add(new object[] { ti.Text });
                        tds.Tag = new UltraDbEntity.T_ERP_MenuCtl {
                            ControlName = ti.Name,
                            TextName = ti.Text,
                            CtlType = (int)EnCtlType.ButtonItems,
                            IsEnabled = false,
                            ClsName = cls,
                            ModName = mod,
                            ModMD5 = md5
                        };
                    }
                }
            } catch //(Exception)
            {

                //throw;
            }
        }

        private void Refc(string cls, string mod, TreeListNode mnu) {
            try {
                var cacheKYPrefix = "SYS.SpeedOpt";
                var pth = Path.Combine(Lanucher.AppDir, mod);
                var md5 = string.Empty;
                //if (File.Exists(pth))
                //{
                //    md5 = ByteStringUtil.ByteArrayToHexStr(HashDigest.FileDigest(pth));
                //}
                var cheoj = Lanucher.Cache.Get<BaseSurface>(string.Format("{0}.{1}", cacheKYPrefix, cls));
                var m = cheoj == null ? Lanucher.Load(cls) : cheoj;
                if (null == cheoj) Lanucher.Cache.Put<BaseSurface>(string.Format("{0}.{1}"
                    , cacheKYPrefix, cls), m);

                var ip = m as ISurfacePermission;
                if (null == ip) return;
                var toolbar = ip.ToolBarItems;
                var grids = ip.Grids;
                var btns = ip.ButtonItems;
                if (null != toolbar && toolbar.Count > 0) {
                    var td = mnu.Nodes.Add(new object[] { "主操作按钮" });
                    foreach (var ti in toolbar) {
                        var tds = td.Nodes.Add(new object[] { ti.Caption });
                        tds.Tag = new MenuCtlData {
                            ControlName = ti.Name,
                            TextName = ti.Caption,
                            CtlType = EnCtlType.ToolBarItems,
                            IsEnabled = false,
                            ClsName = cls,
                            ModName = mod,
                            ModMD5 = md5
                        };
                    }
                }
                if (null != grids && grids.Count > 0) {
                    foreach (var ti in grids) {
                        var td = mnu.Nodes.Add(new object[] { ti.Name });
                        td.Tag = new MenuCtlData {
                            ControlName = ti.Gv.Name,
                            TextName = ti.Name,
                            CtlType = EnCtlType.Grids,
                            IsEnabled = false,
                            ClsName = cls,
                            ModName = mod,
                            ModMD5 = md5
                        };
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in ti.Gv.Columns) {
                            if (!col.Visible) continue;
                            var tdc = td.Nodes.Add(new object[] { col.Caption });

                            tdc.Tag = new MenuCtlData {
                                ControlName = col.Name,
                                ParentCtlName = ti.Gv.Name,
                                TextName = col.Caption,
                                CtlType = EnCtlType.GridCol,
                                IsEnabled = false,
                                ClsName = cls,
                                ModName = mod,
                                ModMD5 = md5
                            };
                        }
                    }
                }
                if (null != btns && btns.Count > 0) {
                    var td = mnu.Nodes.Add(new object[] { "自定义按钮" });
                    foreach (var ti in btns) {
                        var tds = td.Nodes.Add(new object[] { ti.Name });
                        tds.Tag = new MenuCtlData {
                            ControlName = ti.Name,
                            TextName = ti.Text,
                            CtlType = EnCtlType.ButtonItems,
                            IsEnabled = false,
                            ClsName = cls,
                            ModName = mod,
                            ModMD5 = md5
                        };
                    }
                }
            } catch //(Exception)
            {

                //throw;
            }
        }

        DevExpress.Utils.WaitDialogForm dlg;

        public void ThreadLoadMenu() {
            var mnu = this.Cacher.Get<string>("SYS.Menu");
            ExtractMenu(mnu);
            BuildlRoleTree();
            var xmlfile = Path.Combine(Lanucher.AppDir, "Ultra.KY.RS");
            //treeCtl1.ExportToXml(xmlfile);
            Lanucher.Cache.Put<string>("Ultra.KY.RS", xmlfile);

            return;
        }

        public override object CallBack(params object[] args) {
            ThreadLoadMenu();
            return null;// base.CallBack(args);
        }

        private void EdtView_Load(object sender, EventArgs e) {
            treeCtl1.Enabled = false;
            gtRole.Properties.DataSource = SerNoCaller_WL.Calr_Role.Get("where IsDel=0");

            dlg = new DevExpress.Utils.WaitDialogForm("正在加载权限设置信息 ...",
              "数据加载中");

            if (IsNewMenu) {
                var t = new Thread(() => {
                    this.Invoke(new Action(() => {
                        ExtractMenuNew();
                        BuildlRoleTree();
                        Visible = true;
                    }));
                });
                this.Invoke(new Action(() => dlg.Close()));
                t.SetApartmentState(ApartmentState.STA);
                t.IsBackground = true;
                t.Start();
            } else {
                var t = new Thread(() => {
                _redo:
                    var mnu = this.Cacher.Get<string>("SYS.Menu");
                    var rolexml = Lanucher.Cache.Get<string>("Ultra.KY.RS");
                    bool donerolexml = !string.IsNullOrEmpty(rolexml);
                    if (!donerolexml) {
                        Thread.Sleep(800);
                        goto _redo;
                    }

                    //加载菜单
                    this.Invoke(new Action(() => {
                        ExtractMenu(mnu);
                        BuildlRoleTree();
                        //treeCtl1.ImportFromXml(rolexml);
                        Visible = true;
                    }));
                    this.Invoke(new Action(() => dlg.Close()));
                });
                t.SetApartmentState(ApartmentState.STA);
                t.IsBackground = true;
                t.Start();
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var r = gtRole.EditValue;
            if (null == r || string.IsNullOrEmpty(r.ToString())) return;
            var gid = Guid.Parse(r.ToString());
            var rs = gtRole.Properties.DataSource as List<UltraDbEntity.T_ERP_Role>;
            if (null == rs || rs.Count < 1) return;
            var rle = rs.Where(j => j.Guid == gid).FirstOrDefault();
            if (null == rle) return;
            if (IsNewMenu) {
                SaveNew(rle);
            } else {
                Save(rle);
            }
        }

        private void SaveNew(UltraDbEntity.T_ERP_Role rle) {
            List<UltraDbEntity.T_ERP_MenuCtl> lst = new List<UltraDbEntity.T_ERP_MenuCtl>(100);
            foreach (TreeListNode td in treeCtl1.Nodes) {
                var mnugrp = td.GetValue(0).ToString();
                foreach (TreeListNode tds in td.Nodes) {
                    var mnuname = tds.GetValue(0).ToString();
                    foreach (TreeListNode tmd in tds.Nodes) {
                        var mcd = tmd.Tag as UltraDbEntity.T_ERP_MenuCtl;
                        if (null != mcd) {
                            mcd.IsEnabled = tmd.Checked;
                            mcd.MenuGrpName = mnugrp;
                            mcd.MenuName = mnuname;
                            lst.Add(CreateMenuCtl(rle, mcd));
                        }
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            var md = tkd.Tag as UltraDbEntity.T_ERP_MenuCtl;
                            if (null == md) continue;
                            md.IsEnabled = tkd.Checked;
                            md.MenuGrpName = mnugrp;
                            md.MenuName = mnuname;
                            lst.Add(CreateMenuCtl(rle, md));
                        }
                    }
                }
            }
            var rd = new CtlMenuCtlController().SaveRolePermission(lst.Where(k => k.IsEnabled).ToList(), rle);
            if (rd.IsOK) {
                MsgBox.ShowMessage(string.Empty, "保存成功!");
                return;
            } else {
                MsgBox.ShowErrMsg(rd.ErrMsg);
            }
        }

        private UltraDbEntity.T_ERP_MenuCtl CreateMenuCtl(UltraDbEntity.T_ERP_Role rle, UltraDbEntity.T_ERP_MenuCtl mcd) {
            return
                new UltraDbEntity.T_ERP_MenuCtl {
                    IsEnabled = mcd.IsEnabled,
                    MenuGrpName = mcd.MenuGrpName,
                    MenuName = mcd.MenuName,
                    Creator = CurUser,
                    Updator = CurUser,
                    ModMD5 = mcd.ModMD5,
                    ModName = mcd.ModName,
                    ClsName = mcd.ClsName,
                    ControlName = mcd.ControlName,
                    CtlType = (int)mcd.CtlType,
                    CtlTypeName = mcd.ControlName,
                    ParentCtlName = mcd.ParentCtlName,
                    TextName = mcd.TextName,
                    RoleGuid = rle.Guid,
                    RoleName = rle.Name,
                    Remark = string.Empty,
                    Reserved2 = string.Empty
                };
        }

        private void Save(UltraDbEntity.T_ERP_Role rle) {
            List<MenuCtlData> lst = new List<MenuCtlData>(100);
            foreach (TreeListNode td in treeCtl1.Nodes) {
                var mnugrp = td.GetValue(0).ToString();
                foreach (TreeListNode tds in td.Nodes) {
                    var mnuname = tds.GetValue(0).ToString();
                    foreach (TreeListNode tmd in tds.Nodes) {
                        var mcd = tmd.Tag as MenuCtlData;
                        if (null != mcd) {
                            mcd.IsEnabled = tmd.Checked;
                            mcd.MenuGrpName = mnugrp;
                            mcd.MenuName = mnuname;
                            lst.Add(mcd);
                        }
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            var md = tkd.Tag as MenuCtlData;
                            if (null == md) continue;
                            md.IsEnabled = tkd.Checked;
                            md.MenuGrpName = mnugrp; md.MenuName = mnuname;
                            lst.Add(md);
                        }
                    }
                }
            }
            var t = new UltraDbEntity.T_ERP_RoleSet {
                Creator = CurUser,
                Updator = CurUser,
                Remark = string.Empty,
                Reserved1 = 0,
                Reserved2 = string.Empty,
                Reserved3 = false,
                RoleSetTree = Ultra.Utility.Common.SerializeJson(lst),
                //ObjectHelper.SerializeJson(lst),
                RoleGuid = rle.Guid,
                RoleName = rle.Name
            };
            //var rd = Lgc.SaveRoleSet(t);
            var rd = new Ultra.CoreCaller.Caller().InvokePost<UltraDbEntity.T_ERP_RoleSet>(
                t, new Ultra.FASControls.Controllers.CtlRoleSetController(), "AddEdtRoleSet");
            if (rd.IsOK) {
                MsgBox.ShowMessage(string.Empty, "保存成功!");
                return;
            } else {
                MsgBox.ShowErrMsg(rd.ErrMsg);
            }
        }


        private void NodePrev(TreeListNode td) {
            if (td.ParentNode != null) {
                if (td.Checked)
                    td.ParentNode.Checked = true;
                else {
                    var flg = false;
                    foreach (TreeListNode tnd in td.ParentNode.Nodes) {
                        if (tnd.Checked) {
                            flg = true;
                            break;
                        }
                    }

                    td.ParentNode.Checked = flg;
                }
                NodePrev(td.ParentNode);
            } else {
                if (!td.Checked) {
                    foreach (TreeListNode tkd in td.Nodes) {
                        if (tkd.Checked) { td.Checked = true; break; }
                    }
                }
            }
        }

        private void NodeNext(TreeListNode td) {
            foreach (TreeListNode tnd in td.Nodes) {
                tnd.Checked = td.Checked;
                if (tnd.Nodes != null)
                    NodeNext(tnd);
            }

        }

        private void treeCtl1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e) {
            NodeNext(e.Node);
            NodePrev(e.Node);
        }

        private void ClearNodeCheck() {
            foreach (TreeListNode td in treeCtl1.Nodes) {
                td.Checked = false;
                foreach (TreeListNode tds in td.Nodes) {
                    tds.Checked = false;
                    foreach (TreeListNode tmd in tds.Nodes) {
                        tmd.Checked = false;
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            tkd.Checked = false;
                        }
                    }
                }
            }
        }


        private void SetNodeRole(List<MenuCtlData> roledata) {
            foreach (TreeListNode td in treeCtl1.Nodes) {
                foreach (TreeListNode tds in td.Nodes) {
                    foreach (TreeListNode tmd in tds.Nodes) {
                        var md = tmd.Tag as MenuCtlData;
                        if (null != md) {
                            var et = roledata.Where(k => k.ClsName == md.ClsName && k.ModName == md.ModName &&
                                md.ControlName == k.ControlName).FirstOrDefault();
                            if (null == et) {
                                tmd.Checked = false;
                                NodeNext(tmd);
                                NodePrev(tmd);
                            } else {
                                tmd.Checked = et.IsEnabled;
                                NodeNext(tmd);
                                NodePrev(tmd);
                            }
                        }
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            var mdt = tkd.Tag as MenuCtlData;
                            if (null == mdt) continue;
                            var et = roledata.Where(k => k.ClsName == mdt.ClsName
                                && k.ModName == mdt.ModName &&
                               mdt.ControlName == k.ControlName).FirstOrDefault();
                            if (null == et) {
                                tkd.Checked = false;
                                NodeNext(tkd);
                                NodePrev(tkd);
                            } else {
                                tkd.Checked = et.IsEnabled;
                                NodeNext(tkd);
                                NodePrev(tkd);
                            }
                        }
                    }
                }
            }
        }

        private void SetNodeRoleNew(List<UltraDbEntity.T_ERP_MenuCtl> roledata) {
            foreach (TreeListNode td in treeCtl1.Nodes) {
                foreach (TreeListNode tds in td.Nodes) {
                    foreach (TreeListNode tmd in tds.Nodes) {
                        var md = tmd.Tag as UltraDbEntity.T_ERP_MenuCtl;
                        if (null != md) {
                            var et = roledata.Where(k => k.ClsName == md.ClsName && k.ModName == md.ModName &&
                                md.ControlName == k.ControlName).FirstOrDefault();
                            if (null == et) {
                                tmd.Checked = false;
                                NodeNext(tmd);
                                NodePrev(tmd);
                            } else {
                                tmd.Checked = et.IsEnabled;
                                NodeNext(tmd);
                                NodePrev(tmd);
                            }
                        }
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            var mdt = tkd.Tag as UltraDbEntity.T_ERP_MenuCtl;
                            if (null == mdt) continue;
                            var et = roledata.Where(k => k.ClsName == mdt.ClsName
                                && k.ModName == mdt.ModName &&
                               mdt.ControlName == k.ControlName).FirstOrDefault();
                            if (null == et) {
                                tkd.Checked = false;
                                NodeNext(tkd);
                                NodePrev(tkd);
                            } else {
                                tkd.Checked = et.IsEnabled;
                                NodeNext(tkd);
                                NodePrev(tkd);
                            }
                        }
                    }
                }
            }
        }

        private void gtRole_EditValueChanged(object sender, EventArgs e) {
            var r = gtRole.EditValue;
            if (null == r || string.IsNullOrEmpty(r.ToString())) {
                treeCtl1.Enabled = false;
                ClearNodeCheck();
                return;
            }
            treeCtl1.Enabled = true;
            var gid = Guid.Parse(r.ToString());
            //var mcd = Lgc.GetMenuByRole(gid);
            if (IsNewMenu) {
                var mcd = SerNoCaller.Calr_MenuCtl.Get("where RoleGuid=@0", gid);
                if (null == mcd) { ClearNodeCheck(); return; }
                SetNodeRoleNew(mcd);
            } else {
                List<MenuCtlData> mcd = null;
                var et = SerNoCaller.Calr_RoleSet.Get("where RoleGuid=@0", gid).FirstOrDefault();
                if (null != r && null != et) {
                    mcd = new List<MenuCtlData>().DeSerialize(et.RoleSetTree);
                }
                if (null == mcd) { ClearNodeCheck(); return; }
                SetNodeRole(mcd);
            }

        }
    }
}
