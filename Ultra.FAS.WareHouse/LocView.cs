using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.CoreCaller;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.FASControls;
using Ultra.FASControls.Extend;

namespace Ultra.FAS.WareHouse
{
    public partial class LocView : MainSurface, ISurfacePermission
    {
        public LocView()
        {
            InitializeComponent();
        }


        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                barBtnNew,this.barBtnEdt,this.barBtnRefresh
            };
            }
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
                new PermitGridView(this.gridView1,"库位信息")
            };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        public EFCaller<UltraDbEntity.T_ERP_WareLoc> LocCalr { get; set; }
       

        private void LocView_Load(object sender, EventArgs e)
        {
            LocCalr = SerNoCaller.Calr_WareLoc;
                //new EFCaller<UltraDbEntity.T_ERP_WareLoc>(new WareLocController());
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_WareLoc>();
            if (null == et) return;
            var wv = new LocEdt();
            wv.Entity = et;
            wv.LocCalr = LocCalr;
            wv.EditMode = Business.Core.Define.EnViewEditMode.Edit; 
            InitView(wv);
            if (wv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = LocCalr.Get();
            gridControlEx1.DataSource = et;
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new LocEdt();
            vw.LocCalr = LocCalr;
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }
    }
}
