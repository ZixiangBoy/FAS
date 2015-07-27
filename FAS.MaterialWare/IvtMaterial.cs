using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.FASControls;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;

namespace FAS.MaterialWare {
    public partial class IvtMaterial : MainSurface, ISurfacePermission {

        public List<Control> ButtonItems {
            get { return null; }
        }

        public List<BaseSurface> DialogForms {
            get { return null; }
        }

        public List<PermitGridView> Grids {
            get {
                return new List<PermitGridView> {
                    new PermitGridView(gridView1,"物料库存")
                };
            }
        }

        public List<Control> MenuItems {
            get { return null; }
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem>{
                    barBtnInvalid
                };
            }
        }

        public IvtMaterial() {
            InitializeComponent();
        }

        private void IvtMaterial_Load(object sender, EventArgs e) {
            materialGridEdt1.LoadData();
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            ivtMaterialPager1.Caller = SerNoCaller.Calr_V_ERP_InventoryMaterial;
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ivtMaterialPager1.CurrentPage = 1;
            ivtMaterialPager1.PrefixWhr = "select * from V_ERP_InventoryMaterial";
            ivtMaterialPager1.Whrs.Clear(); ivtMaterialPager1.PrmsData.Clear();
            int idx = 0;
            if (materialGridEdt1.GetSelectedValue()!=null) {
                ivtMaterialPager1.Whrs.Add("MaterialName=@" + (idx++).ToString());
                ivtMaterialPager1.PrmsData.Add(materialGridEdt1.GetSelectedValue().MaterialName);
            }
            ivtMaterialPager1.BindPageData();
        }
    }
}
