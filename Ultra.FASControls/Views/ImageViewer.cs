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

namespace Ultra.FASControls.Views
{
    public partial class ImageViewer : DialogViewEx
    {
        public ImageViewer()
        {
            InitializeComponent();
            this.Load += ImageViewer_Load;
        }

        void ImageViewer_Load(object sender, EventArgs e)
        {
            if (null != this.Ent)
                this.listBoxControl1.DataSource = Ent;
            else
            {
                var kt =Calr.Get("where Session=@0", Session);
                int idx=0;
                kt.ForEach(j =>
                {
                    j.Reserved1 = ++idx;
                });
                this.listBoxControl1.DataSource = kt;
            }
            if (null != this.webBrowser1.Document)
                this.webBrowser1.Document.ContextMenuShowing += Document_ContextMenuShowing;
        }

        void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            e.ReturnValue = false;
        }

        public Guid Session { get; set; }
        public Ultra.CoreCaller.EFCaller<UltraDbEntity.T_ERP_Image> Calr { get; set; }
        public List<UltraDbEntity.T_ERP_Image> Ent { get; set; }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var et = listBoxControl1.GetItem(listBoxControl1.SelectedIndex) as UltraDbEntity.T_ERP_Image;
            if (null == et)
            {
            }
            else
            {
                var str = "<html><body><center><img src='{0}'></center></body></html>";
                this.webBrowser1.DocumentText = string.Format(str,
                    string.Format("{0}images/{1}",
                    //Ultra.CoreCaller.Caller.RootAddr
                    Ultra.Surface.Lanuch.Lanucher.ImgSvrURL
                    , et.SavedFileName
                    ));
            }
        }
    }
}
