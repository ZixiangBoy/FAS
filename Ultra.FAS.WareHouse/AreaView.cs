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
    public partial class AreaView : MainSurface, ISurfacePermission
    {
        public AreaView()
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
                new PermitGridView(this.gridView1,"区域信息")
            };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        public EFCaller<UltraDbEntity.T_ERP_WareArea> Calr { get; set; }
        EFCaller<UltraDbEntity.T_ERP_WareHouse> WareCalr { get; set; }

        private void AreaView_Load(object sender, EventArgs e)
        {
            Calr = SerNoCaller.Calr_WareArea;
            WareCalr = SerNoCaller.Calr_WareHouse;

            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = Calr.Get();
            gridControlEx1.DataSource = et;
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_WareArea>();
            if (null == et) return;
            var vw = new AreaEdt();
            vw.Calr = this.Calr;
            vw.WareCalr = this.WareCalr;

            vw.Entity = et;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;            
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new AreaEdt();
            vw.Calr = this.Calr;
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }
    }
}
