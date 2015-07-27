using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.FASControls;

namespace Ultra.FAS.WareHouse
{
    public partial class IvtCollectView : MainSurface, ISurfacePermission
    {
        public IvtCollectView()
        {
            InitializeComponent();
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get { return null; }
        }

        public List<Control> ButtonItems
        {
            get { return null; }
        }

        public List<Control> MenuItems
        {
            get { return null; }
        }

        public List<PermitGridView> Grids
        {
            get
            {
                return new List<PermitGridView> { 
                new PermitGridView(this.gridView1,"库存商品信息")
            };
            }
        }

        public List<Surface.Form.BaseSurface> DialogForms
        {
            get { return null; }
        }

        private void IvtCollectView_Load(object sender, EventArgs e)
        {
            pgr1.Caller = SerNoCaller_WL.Calr_V_ERP_InventSelect;

            var t = new Thread(() =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    wre.LoadFromCache(); area.LoadFromCache(); loc.LoadFromCache();
                }));
            });
            t.IsBackground = true;
            t.Start();
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pgr1.CurrentPage = 1;
            pgr1.Whrs.Clear(); pgr1.PrmsData.Clear();
            pgr1.PrefixWhr = "select a.* from V_ERP_InventSelect a";
            int idx = 0;
            if (!string.IsNullOrEmpty(wre.Text.Trim()))
            {
                pgr1.Whrs.Add("a.WareName = @" + (idx++).ToString());
                pgr1.PrmsData.Add(wre.Text.Trim());
            }
            if (!string.IsNullOrEmpty(area.Text.Trim()))
            {
                pgr1.Whrs.Add("a.AreaName = @" + (idx++).ToString());
                pgr1.PrmsData.Add(area.Text.Trim());
            }
            if (!string.IsNullOrEmpty(loc.Text.Trim()))
            {
                pgr1.Whrs.Add("a.LocName = @" + (idx++).ToString());
                pgr1.PrmsData.Add(loc.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtitem.Text.Trim()))
            {
                pgr1.Whrs.Add("a.ItemName like @" + (idx++).ToString());
                pgr1.PrmsData.Add("%" + txtitem.Text.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(txtsku.Text.Trim()))
            {
                pgr1.Whrs.Add("a.SkuName like @" + (idx++).ToString());
                pgr1.PrmsData.Add("%" + txtsku.Text.Trim() + "%");
            }

            pgr1.OrderBy = "Order By a.Qty desc";
            pgr1.BindPageData();
        }

        private void area_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            if (!string.IsNullOrEmpty(wre.Text))
                editor.Properties.View.ActiveFilterString = "WareName ='" + wre.Text + "'";
            else
                editor.Properties.View.ActiveFilterString = string.Empty;
        }

        private void loc_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            if (!string.IsNullOrEmpty(area.Text))
                editor.Properties.View.ActiveFilterString = "AreaName ='" + area.Text + "'";
            else
                editor.Properties.View.ActiveFilterString = string.Empty;
        }
    }
}
