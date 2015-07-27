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
using Ultra.Surface.Lanuch;
using Ultra.Web.Core.Common;
using Ultra.FASControls.Caller;
using UltraDbEntity;
using Ultra.FASControls;

namespace FAS.Suppliers
{
    public partial class MainView : MainSurface, ISurfacePermission
    {
        public MainView()
        {
            InitializeComponent();
        }

        public EFCaller<UltraDbEntity.T_ERP_Suppliers> SLgc
        {
            get;
            set;
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> {
                this.barBtnNew,this.barBtnEdt,this.barBtnRefresh//,this.barBtnDel
                ,this.barBtnImport
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
                    new PermitGridView(this.gridView1,"供应商"),
                };
            }
        }

        public List<BaseSurface> DialogForms
        {
            get { return null; }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            SLgc = SerNoCaller.Calr_Suppliers;
            //new EFCaller<T_ERP_Suppliers>(new SuppliersController());

            //new EFCaller<T_ERP_SuppItem>(new SuppItemController());
            InitEvent();
        }

        private void InitEvent()
        {
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            this.barBtnDel.ItemClick += barBtnDel_ItemClick;
            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnImport.ItemClick += barBtnImport_ItemClick;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new ChoseView();
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (vw.IsImportSuppName)//导供应商
                {
                    var vwi = new IptSuppNameView();
                    if (vwi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        barBtnRefresh_ItemClick(null, null);
                        return;
                    }
                }               
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchData();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            T_ERP_Suppliers ent = gridView1.GetRow(gridView1.FocusedRowHandle) as T_ERP_Suppliers;
            var ov = new EdtView();
            ov.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            ov.GuidKey = ent.Guid.ToString();
            InitView(ov);
            if (ov.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            SearchData();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ov = new EdtView();
            ov.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            InitView(ov);
            if (ov.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            SearchData();
        }

        void SearchData()
        {
            gridControlEx1.DataSource = SLgc.Get();
            gridControlEx1.RefreshDataSource();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            gridView1_FocusedRowChanged(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }
    }
}
