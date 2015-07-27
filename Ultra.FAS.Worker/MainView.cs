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
using Ultra.FASControls.Caller;
using Ultra.FASControls.Extend;

namespace Ultra.FAS.Worker
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
                this.barBtnNew,this.barBtnEdt,this.barBtnDel
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
                new PermitGridView(this.gridView1,"用户列表")
            };
            }
        }

        public List<Surface.Form.BaseSurface> DialogForms
        {
            get { return null; }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnDel.ItemClick += barBtnDel_ItemClick;
            wkPgr.Caller = FASControls.SerNoCaller_WL.Calr_Worker;
        }

        void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_Worker>();
            if (null == et) return;
            if (MsgBox.ShowYesNoMessage("确认删除吗") != System.Windows.Forms.DialogResult.Yes) return;
            FASControls.SerNoCaller_WL.Calr_Worker.Del(et);
            barBtnRefresh_ItemClick(null,null);
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_Worker>();
            if (null == et) return;
            var vw = new EdtView();
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            vw.Entity = et;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            wkPgr.CurrentPage = 1;
            wkPgr.Whrs.Clear(); wkPgr.PrmsData.Clear();
            wkPgr.PrefixWhr = "select * from T_ERP_Worker ";
            wkPgr.BindPageData();
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new EdtView();
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var et = vw.Entity;
                if (null != et)
                {
                    var d = gridControlEx1.GetDataSource<UltraDbEntity.T_ERP_Worker>();
                    d = d ?? new List<UltraDbEntity.T_ERP_Worker>();
                    d.Insert(0, et);
                    gridControlEx1.DataSource = d;
                    gridControlEx1.RefreshDataSource();
                }
            }
        }

    }
}
