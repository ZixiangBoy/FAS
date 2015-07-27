using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;

namespace Ultra.NWareHouseEx
{
    public partial class Form1 : MainSurface, ISurfacePermission
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Control> ISurfacePermission.ButtonItems
        {
            get { throw new NotImplementedException(); }
        }

        List<BaseSurface> ISurfacePermission.DialogForms
        {
            get { throw new NotImplementedException(); }
        }

        List<PermitGridView> ISurfacePermission.Grids
        {
            get { throw new NotImplementedException(); }
        }

        List<Control> ISurfacePermission.MenuItems
        {
            get { throw new NotImplementedException(); }
        }

        List<DevExpress.XtraBars.BarButtonItem> ISurfacePermission.ToolBarItems
        {
            get { throw new NotImplementedException(); }
        }
    }
}
