using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using System.Net;
using Ultra.Web.Core.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using dxSample1;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Ultra.FAS.ERP
{
    public partial class Form1 : MainSurface, ISurfacePermission
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                barBtnCombo//合并
                ,barBtnSplit//拆分
                ,barBtnRepair//返厂维修
                ,barBtnSndMoney//打款
                ,barBtnScrap//报废
                ,barBtnChgGoods//调换货
                ,barBtnNewAfterSale//创建售后单
                ,barBtnCancelPurch//取消采购
            };
            }
        }

        public List<Control> ButtonItems
        {
            get { throw new NotImplementedException(); }
        }

        public List<Control> MenuItems
        {
            get { throw new NotImplementedException(); }
        }

        public List<PermitGridView> Grids
        {
            get { throw new NotImplementedException(); }
        }

        public List<BaseSurface> DialogForms
        {
            get { throw new NotImplementedException(); }
        }

        class User
        {
            public string UserName { get; set; }
            public int Idx { get; set; }
            public string Url { get; set; }
            public string Un { get; set; }
            public Image Img { get; set; }
            public string Key { get; set; }
            public bool UISelected { get; set; }
            public string PropName { get; set; }
        }

        DataTable FillDataTable()
        {
            DataTable _dataTable = new DataTable();
            DataColumn col;
            DataRow row;

            _dataTable.TableName = "SomeTable";

            col = new DataColumn();
            col.ColumnName = "Image";
            col.DataType = System.Type.GetType("System.String");
            _dataTable.Columns.Add(col);

            row = _dataTable.NewRow();
            row["Image"] = @"c:\Users\Public\Documents\DevExpress 2010.2 Demos\Components\Data\1.jpg";
            _dataTable.Rows.Add(row);

            row = _dataTable.NewRow();
            row["Image"] = @"c:\Users\Public\Documents\DevExpress 2010.2 Demos\Components\Data\2.jpg";
            _dataTable.Rows.Add(row);

            row = _dataTable.NewRow();
            row["Image"] = @"Wrong path";
            _dataTable.Rows.Add(row);

            return _dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var usr = new List<User> {
                new User{Idx=1,Key="Baidu", UserName="BaiDu",Url="http://www.baidu.com/img/bdlogo.png"}              
                 ,new User{Idx=3,Key="KE",UserName="KE",Url=@"C:\Users\Administrator\Desktop\ke.png"}

            };

            ToolBarItems.ForEach(j => j.Visibility = DevExpress.XtraBars.BarItemVisibility.Always);

            //将显示图片的那一列绑定的FieldName 加入图片识别列中
            //以便让控件去网络上下载图片
            gridControlEx1.ImageFields.Add("Url_img");
            gridControlEx1.DataSource = usr;

            gridControlEx1.EnableCellStyleColor = true;//开启自动变换背景色
            gridControlEx1.ShadowDataSourceKey = "Key";//用于唯一标识一行数据的属性值(一般选择用Guid)
            //设置用于检测数据是否变化的数据源（注意此处把 user 做了一份拷贝，以防止画面的编辑影响到了参照数据）
            gridControlEx1.ShadowDataSource = Ultra.Web.Core.Common.ObjectHelper.ObjectCopy<List<User>>(usr);

            //设置 标识哪一行哪一个列需要进行变色处理
            gridControlEx1.RowCellColorStyleSource = new List<User> {
                new User{Key="Baidu",PropName="UserName"}
            };
            //new GridCheckMarksSelection(gridView1);

            //DataTable dt = FillDataTable();
            //gridControl1.DataSource = dt;

            //DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repItemGraphicsEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            //repItemGraphicsEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            //gridView1.Columns["Image"].ColumnEdit = repItemGraphicsEdit;

            //gridControl2.DataSource = dt;

            //gridView1.CustomDrawColumnHeader += gridView1_CustomDrawColumnHeader;
            //gridView1.Click += View_Click;
        }

        void gridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == (sender as GridView).Columns["UISelected"])
            {
                e.Info.InnerElements.Clear();
                e.Info.Appearance.ForeColor = Color.Blue;
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, false);
                e.Handled = true;
            }
        }

        void View_Click(object sender, EventArgs e)
        {
            GridHitInfo info; var _view = gridView1; var column = (sender as GridView).Columns["UISelected"];
            Point pt = _view.GridControl.PointToClient(Control.MousePosition);
            info = _view.CalcHitInfo(pt);
            if (info.Column == column)
            {
                if (info.InColumn && info.Column.FieldName == "UISelected")
                {
                    if (gridControlEx1.GetCheckedCount() == _view.DataRowCount)
                        gridControlEx1.UnChekAll();
                    else
                        gridControlEx1.CheckAll();
                }
                //if (info.InRowCell)
                //{
                //    //InvertRowSelection(info.RowHandle);
                //}
            }
            //if (info.InRow && _view.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
            //{
            //    InvertRowSelection(info.RowHandle);
            //}
        }

        RepositoryItemCheckEdit chkedit = new RepositoryItemCheckEdit();
        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = chkedit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = chkedit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;

            info.Bounds = r;
            info.PaintAppearance.ForeColor = Color.Black;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //textBox1.Text = string.Format("FR:{0} LR:{1}", e.FocusedRowHandle);
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //if (e.CellValue!=null && e.CellValue.ToString() == "KE" && e.Column.FieldName == "UserName")
            //{
            //    e.Appearance.BackColor = Color.Yellow;

            //}
        }


    }
}
