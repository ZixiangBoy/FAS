using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
namespace Ultra.FASControls.Extend
{
    /// <summary>
    /// 控件扩展方法集
    /// </summary>
    public static class MethodExtend
    {
        /// <summary>
        /// 不选中任何行
        /// </summary>
        public static void ReleaseFocusedRow(this DevExpress.XtraGrid.Views.Grid.GridView gdview)
        {

            if (null != gdview)
                gdview.FocusedRowHandle = -999997;
        }

        /// <summary>
        /// 获取数据源对象实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static List<T> GetDataSource<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview)
        {
            if (null == gdview) return null;
            return gdview.DataSource as List<T>;
        }

        /// <summary>
        /// 获取选中行的数据对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static T GetFocusedDataSource<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview)
        {
            if (null == gdview) return default(T);
            return (T)gdview.GetRow(gdview.FocusedRowHandle);
        }

        /// <summary>
        /// 获取选中行的数据对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static T GetFocusedDataSource<T>(this DevExpress.XtraGrid.GridControl gc)
        {
            if (null == gc) return default(T);
            var gv = gc.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null == gv) return default(T);
            return GetFocusedDataSource<T>(gv);
        }

        /// <summary>
        /// 复制选中行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static T CopyFocusedRow<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview) {
            if (null == gdview) return default(T);
            var ds = GetDataSource<T>(gdview);
            if (null == ds) return default(T);
            T et = GetFocusedDataSource<T>(gdview);
            T net = PetaPoco.Database.DeepCopy<T>(et);
            ds.Insert(gdview.FocusedRowHandle, net);
            gdview.GridControl.DataSource = ds;
            gdview.GridControl.RefreshDataSource();
            return net;
        }

        /// <summary>
        /// 复制选中行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static T CopyFocusedRow<T>(this DevExpress.XtraGrid.GridControl gc) {
            if (null == gc) return default(T);
            var gv = gc.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null == gv) return default(T);
            return CopyFocusedRow<T>(gv);
        }

        /// <summary>
        /// 获取所选行的数据对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static List<T> GetSelectedDataSource<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview)
        {
            var idxs = gdview.GetSelectedRows();
            if (null == idxs || idxs.Length < 1) return null;
            return idxs.ToList().Select(j => (T)gdview.GetRow(j)).ToList();
        }

        /// <summary>
        /// 获取所选行的数据对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static List<T> GetSelectedDataSource<T>(this DevExpress.XtraGrid.GridControl gc)
        {
            var gv = gc.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null == gv) return null;
            return GetSelectedDataSource<T>(gv);
        }

        /// <summary>
        /// 获取数据源对象实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static List<T> GetDataSource<T>(this DevExpress.XtraGrid.GridControl gc)
        {
            if (null == gc) return null;
            return gc.DataSource as List<T>;
        }

        /// <summary>
        /// 添加数据至数据源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static List<T> AddData<T>(this DevExpress.XtraGrid.GridControl gc, T d)
        {
            var ds = gc.DataSource as List<T>;
            if (null == ds) ds = new List<T>();
            ds.Add(d);
            gc.DataSource = ds;
            gc.RefreshDataSource();
            return ds;
        }

        /// <summary>
        /// 移除选中的行
        /// </summary>
        /// <param name="gc"></param>
        public static void RemoveSelected(this DevExpress.XtraGrid.GridControl gc)
        {
            var gv = gc.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null == gv) return;
            gv.DeleteSelectedRows();
        }

        /// <summary>
        /// 根据指定的筛选条件移除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <param name="fnc"></param>
        public static List<T> RemoveByKey<T>(this DevExpress.XtraGrid.GridControl gc, Func<T, bool> fnc)
        {
            var kt = GetDataSource<T>(gc);
            if (null == kt || kt.Count < 1) return null;
            var jt = kt.Where(j => fnc(j)).ToList();
            jt.ForEach(j => kt.Remove(j));
            gc.DataSource = kt;
            gc.RefreshDataSource();
            return jt;
        }

        public static void MakeRowEditImmediateSave(this DevExpress.XtraGrid.Views.Grid.GridView gv, object cellnewValue)
        {
            if (null == gv) return;
            //gv.SetFocusedRowCellValue(gv.FocusedColumn, e.NewValue);                    
            //ColumnView view = gridTrade.FocusedView as ColumnView;
            //view.CloseEditor();
            //if (view.UpdateCurrentRow())
            gv.SetFocusedRowCellValue(gv.FocusedColumn, cellnewValue);
            var view = gv.GridControl.FocusedView as DevExpress.XtraGrid.Views.Base.ColumnView;
            view.CloseEditor();
            if (view.UpdateCurrentRow())
            {

            }
        }
        /// <summary>
        /// user define make row readonly ,will user gridview tag
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="fncNeedReadonly"></param>
        public static void SetRowReadOnly(this DevExpress.XtraGrid.Views.Grid.GridView gv, Func<object, bool> fncNeedReadonly)
        {
            gv.Tag = fncNeedReadonly;
            gv.ShowingEditor -= gv_ShowingEditor;
            gv.ShowingEditor += gv_ShowingEditor;
        }

        static void gv_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null == gv) return;
            var k = gv.GetFocusedRow();
            Func<object, bool> fnc = gv.Tag as Func<object, bool>;
            if (null == fnc) return;
            e.Cancel = fnc(k);
        }

        public static void SetValue(this SpinEdit spt, decimal? vl)
        {
            if (null == vl) spt.EditValue = null;
            else
                spt.Value = vl.Value;
        }

        /// <summary>
        /// 序列化对象为Json串
        /// </summary>
        /// <param name="obj">要被序列化的对象</param>
        /// <returns></returns>
        public static string SerializeJson(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="jsonstr">Json串</param>
        /// <returns></returns>
        public static T DeSerialize<T>(this T oj, string jsonstr)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstr);
        }
        public static T DeSerialize<T>(this string jsonstr)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstr);
        }

        public static void SaveLayOut(this DevExpress.XtraLayout.LayoutControl c)
        {
            var vw = c.FindForm();
            var fm = vw as Ultra.Surface.Form.BaseSurface;
            if (null == fm) return;
            var fvr = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            string xml = string.Empty;
            xml = string.Format("{0}.{1}", fm.GetType().FullName, fvr);

            xml = Ultra.Web.Core.Common.ByteStringUtil.ByteArrayToHexStr(
                Ultra.Web.Core.Common.HashDigest.StringDigest(xml));

            var pth = System.IO.Path.Combine(Ultra.Surface.Lanuch.Lanucher.AppDir, "LayOut");
            if (!System.IO.Directory.Exists(pth))
                System.IO.Directory.CreateDirectory(pth);

            xml = System.IO.Path.Combine(pth, xml + ".ly");
            c.SaveLayoutToXml(xml);
        }

        public static void LoadLayOut(this DevExpress.XtraLayout.LayoutControl c)
        {
            var vw = c.FindForm();
            var fm = vw as Ultra.Surface.Form.BaseSurface;
            if (null == fm) return;
            var fvr = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            string xml = string.Empty;
            xml = string.Format("{0}.{1}", fm.GetType().FullName, fvr);

            xml = Ultra.Web.Core.Common.ByteStringUtil.ByteArrayToHexStr(
                Ultra.Web.Core.Common.HashDigest.StringDigest(xml));

            var pth = System.IO.Path.Combine(Ultra.Surface.Lanuch.Lanucher.AppDir, "LayOut");
            xml = System.IO.Path.Combine(pth, xml + ".ly");
            if (!System.IO.File.Exists(xml)) return;
            c.RestoreLayoutFromXml(xml);
        }

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);

        /// <summary>
        /// 判断按键是否按下
        /// </summary>
        /// <param name="kys"></param>
        /// <returns></returns>
        public static bool IsKeyDown(params System.Windows.Forms.Keys[] kys)
        {
            byte[] keys = new byte[256];

            GetKeyboardState(keys);
            int byt = 128;
            foreach (var k in kys)
            {
                byt = byt & //(int)k;
                    keys[(int)k];
            }

            return byt == 128;
            //if ((keys[(int)System.Windows.Forms.Keys.Up] & keys[(int)System.Windows.Forms.Keys.Right] & 128) 
            //    == 128)
            //{

            //}
        }

        /// <summary>
        /// 判断按键是否按下
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool IsDown(this System.Windows.Forms.Keys k)
        {
            return IsKeyDown(k);
        }

        public static string CusViewOrdColor(this Ultra.Surface.Form.BaseSurface vw)
        {
#if !DEBUG
            string _defclr = "128,128,128";
            var clr = vw.Cacher.Get<string>("SYS.CusViewOrdColor");
            if (!string.IsNullOrEmpty(clr)) return clr;
            clr = vw.OptConfig.Get<string>("CusViewOrdColor");
            if (string.IsNullOrEmpty(clr))
            {
                clr = _defclr;
                vw.OptConfig.Set<string>("CusViewOrdColor", clr);
            }
            vw.Cacher.Put<string>("SYS.CusViewOrdColor", clr);
            return clr;
#else
            string _defclr = "128,128,128";
            var clr = vw.OptConfig.Get<string>("CusViewOrdColor");
            if (string.IsNullOrEmpty(clr))
            {
                clr = _defclr;
                vw.OptConfig.Set<string>("CusViewOrdColor", clr);
            }
            return clr;
#endif
        }

        public static string ToColorValue(this System.Drawing.Color clredt)
        {
            return string.Format("{3},{0},{1},{2}", clredt.R, clredt.G, clredt.B, clredt.A);
        }

        public static void SetAsSellerFlag(this RepositoryItemImageComboBox rp)
        {
            rp.SmallImages = Ultra.Surface.Common.SurfaceUtil.SellerFlags;
            rp.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("灰", 0, 0));
            rp.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("红", 1, 1));
            rp.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("黄", 2, 2));
            rp.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("绿", 3, 3));
            rp.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("蓝", 4, 4));
            rp.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("紫", 5, 5));
            rp.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static DevExpress.XtraBars.PopupMenu CreateRightPopMenu(this Ultra.Surface.Form.MainSurface vw)
        {
            var lst = new List<DevExpress.XtraBars.BarItemLink>();
            foreach (DevExpress.XtraBars.BarItemLink btm in vw.bar1.ItemLinks)
            {
                var btnitm = btm as DevExpress.XtraBars.BarButtonItemLink;
                if (null == btnitm || btnitm.Item.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                    continue;
                if (!btm.Visible) continue;
                lst.Add(btm);
            }
            var pop = new DevExpress.XtraBars.PopupMenu(vw.baseBarMgr);
            pop.Popup += pop_Popup;
            lst.ForEach(j =>
            {
                var btn = new DevExpress.XtraBars.BarButtonItem();
                btn.Caption = j.Caption; btn.ImageIndex = j.ImageIndex;
                pop.AddItem(btn);
                btn.Tag = new MethodInvokePack
                {
                    Method = Ultra.Common.ExtendCommon.GetMethod(j, "OnLinkClick"),
                    Sender = j
                };
                btn.ItemClick += (s1, e1) =>
                {
                    var itm = e1.Item as DevExpress.XtraBars.BarButtonItem;
                    if (null == itm) return;
                    var mip = itm.Tag as MethodInvokePack;
                    if (null == mip) return;
                    mip.Method.Invoke(mip.Sender, null);
                };
            });
            return pop;
        }

        /// <summary>
        /// 同步右键菜单的启用与可视状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void pop_Popup(object sender, EventArgs e)
        {
            var mnu = (sender as DevExpress.XtraBars.PopupMenu); if (null == mnu) return;
            var vw = ((sender as DevExpress.XtraBars.PopupMenu).Manager.Form as Ultra.Surface.Form.MainSurface);
            if (null == vw) return;
            foreach (DevExpress.XtraBars.BarItemLink btm in vw.bar1.ItemLinks)
            {
                foreach (DevExpress.XtraBars.BarButtonItemLink btnitm in mnu.ItemLinks)
                {
                    if (btnitm.Caption.Equals(btm.Caption))
                    {
                        btnitm.Visible =btm.Visible;
                        btnitm.Item.Enabled = btm.Enabled; 
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// GridControl加载画面工具条显示为右键菜单
        /// </summary>
        public static void LoadViewRightMenu(this GridControlEx gc)
        {
            if (null == gc) return;
            var frm = gc.FindForm();
            if (null == frm) return;
            var vw = frm as Ultra.Surface.Form.MainSurface;
            if (null == vw) return;
            gc.PopupMnu = vw.CreateRightPopMenu();
        }

        /// <summary>
        /// 获取当前剪贴板复制的文本
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetClipBoardText(this System.Windows.Forms.Control c)
        {
            string clp = string.Empty;
            try
            {
                System.Windows.Forms.IDataObject iData = System.Windows.Forms.Clipboard.GetDataObject();

                if (iData.GetDataPresent(System.Windows.Forms.DataFormats.Text))
                {
                    clp = (String)iData.GetData(System.Windows.Forms.DataFormats.Text);
                }
            }
            catch { }
            return clp;
        }

        /// <summary>
        /// 设置GridLookUpEdit 可以输入并且自动完成
        /// </summary>
        /// <param name="gct"></param>
        public static void SetGridLookUpEdtAutoComplete(this GridLookUpEdit gct)
        {
            gct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gct.Properties.AutoComplete = true;
            gct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            gct.Properties.ImmediatePopup = true;
        }

        /// <summary>
        /// 设置RepositoryItemGridLookUpEdit 可以输入并且自动完成
        /// </summary>
        /// <param name="gct"></param>
        public static void SetGridLookUpEdtAutoComplete(this DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit gct)
        {
            gct.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gct.AutoComplete = true;
            gct.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            gct.ImmediatePopup = true;
        }
    }

    public class MethodInvokePack
    {
        public object Sender { get; set; }
        public MethodInfo Method { get; set; }
    }
}
