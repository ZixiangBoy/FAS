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
using Ultra.FASControls;
using Ultra.FASControls.Caller;
using Ultra.FASControls.Extend;

namespace FAS.Role
{
    public partial class MainView : MainSurface, ISurfacePermission
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnDel.ItemClick += barBtnDel_ItemClick;
        }

        void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_Role>();
            if (null == et) return;
            if (MsgBox.ShowYesNoMessage("删除确认", "确定要删除该项吗?") == System.Windows.Forms.DialogResult.Yes)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_Role>();
            if (null == et) return;
            var vw = new EdtView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            vw.Entity = et;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gridControlEx1.RefreshDataSource();
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridControlEx1.DataSource = SerNoCaller_WL.Calr_Role.Get();
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new EdtView();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ds = gridControlEx1.GetDataSource<UltraDbEntity.T_ERP_Role>();
                ds = ds ?? new List<UltraDbEntity.T_ERP_Role>();
                ds.Insert(0, vw.Entity);
                gridControlEx1.DataSource = ds;
                gridControlEx1.RefreshDataSource();
            }
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
            get { return new List<PermitGridView> {
                new PermitGridView(this.gridView1,"角色信息")
            }; }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }


        
    }
}
