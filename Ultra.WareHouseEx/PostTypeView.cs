using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.FASControls.Extend;
using Ultra.CoreCaller;
using Ultra.FASControls.Caller;
using Ultra.FASControls;



namespace Ultra.WareHouseEx
{
    public partial class PostTypeView : MainSurface, ISurfacePermission
    {
        public PostTypeView()
        {
            InitializeComponent();
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> {
                this.barBtnNew,this.barBtnEdt,this.barBtnRefresh
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
                return new List<PermitGridView>
                {
                    new PermitGridView(this.gridView1,"运费类型")
                };
            }
        }


        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        public EFCaller<UltraDbEntity.T_ERP_PostFeeType> Calr { get; set; }

        private void MainView_Load(object sender, EventArgs e)
        {
            Calr = SerNoCaller_WL.Calr_PostFeeType;
            this.barBtnNew.ItemClick +=barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick +=barBtnEdt_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = Calr.Get();
            gridControlEx1.DataSource = et;
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_PostFeeType>();

            var vw = new PostTypeEdt();
            vw.Calr = this.Calr;
            vw.Entity = et;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
            
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new PostTypeEdt();
            vw.Calr = this.Calr;
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
            
        }

    }
}
