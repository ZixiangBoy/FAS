using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAC.Login.Controls
{
    class Ctls
    {
    }

    public class MnuPanel : DevExpress.XtraEditors.PanelControl
    { }
    public class SptPanel : DevExpress.XtraEditors.SplitContainerControl { }
    public class TreeCtl : DevExpress.XtraTreeList.TreeList { }
    public class GroupPanel : DevExpress.XtraEditors.GroupControl { }
    public class BtnCtl : DevExpress.XtraEditors.SimpleButton { }
    public class CheckCtl : DevExpress.XtraEditors.CheckEdit { }
    public class PopMenuCtl : DevExpress.XtraBars.PopupMenu { }
    public class ListCtl : DevExpress.XtraEditors.ListBoxControl { }
    public class SpltPanel : DevExpress.XtraEditors.SplitContainerControl
    {
        public SpltPanel() : base() { Horizontal = false; }
    }

    public class LblSpt : DevExpress.XtraEditors.LabelControl
    {
        public LblSpt()
            : base()
        {
            Text = "～";

        }

        public string SpltChr { get { return "～"; } }

        protected override void OnCreateControl()
        {
            this.Text = "～";
            base.OnCreateControl();
            this.Text = "～";
        }
    }
}
