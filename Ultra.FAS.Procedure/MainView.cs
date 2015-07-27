using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Surface.Lanuch;
using Ultra.FASControls;
using Ultra.FASControls.Extend;

namespace Ultra.FAS.Procedure
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
                this.barBtnNew,this.barBtnEdt
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
                new PermitGridView(this.gridView1,"工序列表")
            };
            }
        }

        public List<Surface.Form.BaseSurface> DialogForms
        {
            get { return null; }
        }



        void DbgSet()
        {
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            this.barBtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barBtnEdt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_Procedure>();
            if (null == et) return;
            var vw = new EdtView();
            //vw.Lgc = Lgc;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            vw.Entity = et;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gridControlEx1.RefreshDataSource();
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            using(var db = new Database(this.ConnString)){
                this.gridControlEx1.DataSource = db.Fetch<UltraDbEntity.T_ERP_Procedure>(" select * from T_ERP_Procedure order by OrderNo ");
            }
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new EdtView();
            //vw.Lgc = Lgc;
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var et = vw.Entity;
                if (null != et)
                {
                    var d = gridControlEx1.GetDataSource<UltraDbEntity.T_ERP_Procedure>();
                    d = d ?? new List<UltraDbEntity.T_ERP_Procedure>();
                    d.Insert(0, et);
                    gridControlEx1.DataSource = d;
                    gridControlEx1.RefreshDataSource();
                }
            }
        }

    }
}
