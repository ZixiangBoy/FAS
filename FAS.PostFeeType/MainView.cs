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
using Ultra.FASControls.Caller;
using Ultra.FASControls.Extend;

namespace FAS.PostFeeType
{
    public partial class MainView : MainSurface, ISurfacePermission
    {
        public MainView()
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
                    new PermitGridView(this.gridView1,"优惠配置")
                };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }
        
        private void MainView_Load(object sender, EventArgs e)
        {
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            barBtnRefresh_ItemClick(null, null);
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_PostFeeType>();
            if (null == et) return;
            var vw = new EdtView();
            vw.Entity = et;
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var clr = Ultra.FASControls.SerNoCaller.Calr_PostFeeType;
            var et =clr.Get();
            gridControlEx1.DataSource = et;
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new EdtView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
        }
    }
}
