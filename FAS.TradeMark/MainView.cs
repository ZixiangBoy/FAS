using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using UltraDbEntity;
using Ultra.FASControls.Extend;
using Ultra.FASControls;

namespace FAS.TradeMark {
    public partial class MainView : MainSurface, ISurfacePermission {
        public MainView() {
            InitializeComponent();
        }


        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                this.barBtnNew,this.barBtnEdt
            };
            }
        }

        public List<Control> ButtonItems {
            get { return null; }
        }

        public List<Control> MenuItems {
            get { return null; }
        }

        public List<PermitGridView> Grids {
            get {
                return new List<PermitGridView> { 
                new PermitGridView(this.gridView1,"商标信息")
            };
            }
        }

        public List<BaseSurface> DialogForms {
            get { return null; }
        }

        private void MainView_Load(object sender, EventArgs e) {
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
        }

        private void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gridControlEx1.GetFocusedDataSource<T_ERP_TradeMark>();
            if (et == null) return;
            var vw = new EditView();
            vw.TradeMark = et;
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new EditView();
            //vw.TradeMark = et;
            //vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            gridControlEx1.DataSource = SerNoCaller.Calr_TradeMark.Get();
        }
    }
}
