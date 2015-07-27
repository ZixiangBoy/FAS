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
using Ultra.FASControls.Extend;
using Ultra.FASControls;

namespace Ultra.FAS.Item
{
    public partial class ItemPropView : MainSurface, ISurfacePermission
    {
        public ItemPropView()
        {
            InitializeComponent();
        }

        EFCaller<UltraDbEntity.T_ERP_ItemStyle> Calr;

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return null;
            }
        }

        public List<Control> ButtonItems
        {
            get
            {
                return new List<Control> { 
                this.btnAdd,this.btnEdt
            };
            }
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
                    new PermitGridView(this.gridView1,"属性名称信息")
                    ,new PermitGridView(this.gridView2,"属性值信息")
                };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            Calr = SerNoCaller_WL.Calr_ItemStyle;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = Calr.Get("select distinct TypeName,StyleName from T_ERP_ItemStyle");
            gridControlEx1.DataSource = et;
            gridControlEx1.ReleaseFocusedRow();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_ItemStyle>();
            if (null == et)
            {
                gridControlEx2.DataSource = null;
                return;
            }
            var ets = Calr.Get("where TypeName=@0 and StyleName=@1 and StyleData Is not null"
                  , et.TypeName, et.StyleName);
            gridControlEx2.DataSource = ets;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_ItemStyle>();
            if (null == et) return;
            var vw = new EdtView();
            vw.Entity = et;
            vw.Calr = this.Calr;
            vw.EditMode = Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }

        private void btnEdt_Click(object sender, EventArgs e)
        {
            var et = gridView2.GetFocusedDataSource<UltraDbEntity.T_ERP_ItemStyle>();
            if (null == et) return;
            var vw = new EdtView();
            vw.Calr = this.Calr;
            vw.Entity = et;
            vw.EditMode = Business.Core.Define.EnViewEditMode.Edit;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(null, null);
            }
        }
    }
}
