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
using Ultra.FASControls;

namespace FAS.PermitRole
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
                this.barBtnRoleUsr,this.barBtnRole
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
                new PermitGridView(gridView1,"角色"),
                new PermitGridView(gridView2,"角色用户")
            };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { throw new NotImplementedException(); }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            this.barBtnRoleUsr.ItemClick += barBtnRoleUsr_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnRole.ItemClick += barBtnRole_ItemClick;
        }

        void barBtnRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new EdtView();
            InitView(vw);
            vw.ShowDialog();
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = SerNoCaller_WL.Calr_Role.Get("where IsDel=0");
            gridControlEx1.DataSource = et;
            gridControlEx1.ReleaseFocusedRow();
        }

        void barBtnRoleUsr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new RoleUser();
            InitView(vw);
            vw.ShowDialog();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var re = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_Role>();
            if (null == re)
            {
                gridControlEx2.DataSource = null;
                gridControlEx2.RefreshDataSource();
                return;
            }
            gridControlEx2.DataSource = SerNoCaller.Calr_User.Get("select * from V_ERP_UserByRole where RoleGuid=@0", re.Guid);
        }
    }
}
