using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.Surface.Form;
using Ultra.Surface.Lanuch;

namespace Ultra.FASControls
{
    public class MainReportEx {
        public static string SelectePageText { get; set; }

        public static void SetFormXtraTab(XtraTabControl tab) {
            var pages = tab.TabPages;
            foreach (XtraTabPage p in pages) {
                if (p.Text.Equals(SelectePageText)) {
                    tab.SelectedTabPage = p;
                }
            }

            if (ActionEvt != null) {
                ActionEvt(null, null);
            }
        }

        public static Action<object,EventArgs> ActionEvt;

        public static void ShowView(BaseSurface parentView, string mclsname) {
            var mnus=Lanucher.Cache.Get<List<UltraDbEntity.T_ERP_MenuNew>>("SYS.MenuLstNew");
            if(mnus==null || mnus.Count()<1) return;
            var menu=mnus.FirstOrDefault(k=>k.MenuClsName==mclsname);
            if(menu==null) return;
            var vw = Lanucher.Cache.Get<BaseSurface>(menu.MenuClsName + "-" + menu.MenuAsmName);
            if (null != vw && !vw.IsDisposed) {
                //vw.Activated+=(sender,e) => {
                //    foreach (var c in vw.Controls) {
                //        if (c is XtraTabControl) {
                //            SetFormXtraTab(c as XtraTabControl);
                //        }
                //    }
                //};
                vw.Activate(); return;
            }
            vw = Lanucher.Start(mclsname);
            if (null == vw) return;
            var pv=Lanucher.Cache.Get<BaseSurface>("MainView");
            if (null == pv) return;
            vw.Text =menu.MenuName;
            vw.MdiParent = Lanucher.Cache.Get<BaseSurface>("MainView");
            vw.LanucherParent = Lanucher.Cache.Get<BaseSurface>("MainView"); ;
            Lanucher.Cache.Put<BaseSurface>(menu.MenuClsName + "-" + menu.MenuAsmName, vw);
            vw.Show();
            vw.Activate();
        }
    }
}
