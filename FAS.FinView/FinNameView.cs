using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.CoreCaller;
using Ultra.FASControls.Caller;
using Ultra.FASControls.Extend;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using UltraDbEntity;

namespace FAS.FinView
{
    public partial class FinNameView : MainSurface, ISurfacePermission
    {
        public FinNameView()
        {
            InitializeComponent();
        }

        public List<Control> ButtonItems
        {
            get { return null; }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        public List<PermitGridView> Grids
        {
            get
            {
                return new List<PermitGridView> { 
                new PermitGridView(gv,"财务科目")
            };
            }
        }

        public List<Control> MenuItems
        {
            get { return null; }
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem>
                    {
                        this.barBtnNew,this.barBtnEdt,this.barBtnRefresh
                    };
            }
        }

        public EFCaller<T_ERP_FinName> Calr { get; set; }
        private void FinNameView_Load(object sender, EventArgs e)
        {
            Calr = SerNoCaller_GC.Calr_FinName;
            barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            barBtnNew.ItemClick += barBtnNew_ItemClick;
            barBtnEdt.ItemClick += barBtnEdt_ItemClick;
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gv.GetFocusedDataSource<UltraDbEntity.T_ERP_FinName>();
            if (null == et) return;
            var vw = new FinNameEdit();
            vw.Entity = et;
            vw.Calr = this.Calr;
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new FinNameEdit();
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(null, null);
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et =Calr.Get();
            gc.DataSource = et;
            gc.ReleaseFocusedRow();
        }
    }
}
