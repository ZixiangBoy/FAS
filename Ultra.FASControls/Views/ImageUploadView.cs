using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface;
using Ultra.Surface.Form;
using Ultra.FASControls.Extend;

namespace Ultra.FASControls.Views
{
    public partial class ImageUploadView : EmptySuface
    {
        public ImageUploadView()
        {
            InitializeComponent();
        }

        public static string DatabaseName { get; set; }
        public List<UploadFile> Files { get; set; }
        public Guid Session { get; set; }
        public long MaxFileSize { get; set; }

        private bool _readClpbrd = false;

        //标识是否从剪贴板中读取
        public bool ReadClpBrd { get { return _readClpbrd; } set { _readClpbrd = value; } }

        public void StartUpLoad(List<UploadFile> fis)
        {
            this.btnCtl1.Enabled = false;
            if (fis == null || fis.Count < 1) return;
            foreach (var j in fis)
            {
                if (!File.Exists(j.FilePath))
                {
                    j.ErrMsg = "文件不存在"; continue;
                }
                if (new FileInfo(j.FilePath).Length > MaxFileSize)
                {
                    j.ErrMsg = "文件大小超出了上传限制";
                    j.Done = true; continue;
                }
                try
                {
                    var rd = Ultra.CoreCaller.Caller.SysFUpd(j.FilePath, Session, this.CurUser,DatabaseName);
                    j.Done = rd.IsOK;
                    j.ErrMsg = !rd.IsOK ? rd.ErrMsg : string.Empty;
                    if (j.Done && j.IsClpBrd) File.Delete(j.FilePath);//删除剪贴板文件
                    gridControlEx1.RefreshDataSource();
                }
                catch (Exception ex)
                {
#if DEBUG
                    j.ErrMsg = ex.Message;
                    throw;
#else
                    j.ErrMsg = ex.Message;
#endif
                }

                if (fis.Where(f => !f.Done).Count() > 0)
                    this.btnCtl1.Enabled = true;
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;

                    Close();
                }
            }
            //Ultra.CoreCaller.Caller.SysFUpd(fis.Select(j => j.FilePath).ToArray());
            ////上传线程启动
            //var t = new Thread(j => { });
            //t.IsBackground = true;
            //t.SetApartmentState(ApartmentState.STA);            
            //DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm
            //("正在上传图片,请稍候...", "图片上传");
            //t.Start(dlg);
        }

        private void btnCtl1_Click(object sender, EventArgs e)
        {
            StartUpLoad(Files);
        }

        private void ImageUploadView_Load(object sender, EventArgs e)
        {
            if (ReadClpBrd)//判断剪贴板
            {
                try
                {
                    IDataObject data = Clipboard.GetDataObject();//从剪贴板中获取数据
                    if (data.GetDataPresent(typeof(Bitmap)))//判断是否是图片类型
                    {
                        Bitmap map = (Bitmap)data.GetData(typeof(Bitmap));//将图片数据存到位图中
                        if (null != map)
                        {
                            var pth = Path.Combine(Ultra.Surface.Lanuch.Lanucher.AppDir, "ImageCache");
                            if (!Directory.Exists(pth)) Directory.CreateDirectory(pth);
                            pth = Path.Combine(pth, DateTime.Now.ToString("yy_MM_dd_HHmmssfff") + ".bmp");
                            map.Save(pth);
                            Files.Add(new UploadFile { FilePath = pth ,IsClpBrd=true});
                        }
                    }
                }
                catch (Exception) { }
            }
            gridControlEx1.DataSource = Files;
        }

        private void repositoryItemHyperLinkEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //var et = gridControlEx1.GetFocusedDataSource<UploadFile>();
            //if (null == et) return;
            //Ultra.Web.Core.Common.SystemInvoke.OpenFile(et.FilePath);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "ViewText")
            {
                var et = gridControlEx1.GetFocusedDataSource<UploadFile>();
                if (null == et) return;
                Ultra.Web.Core.Common.SystemInvoke.OpenFile(et.FilePath);
            }
        }
    }
}
