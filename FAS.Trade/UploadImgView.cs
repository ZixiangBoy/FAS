using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using UltraDbEntity;

namespace FAS.Trade {
    public partial class UploadImgView : BaseSurface {

        public T_ERP_Order Order { get; set; }

        public UploadImgView() {
            InitializeComponent();
        }

        private void UploadImgView_Load(object sender, EventArgs e) {
            imageUpload1.Session = Order.Guid;

            imageUpload1.LoadData(Order.Guid);
        }

        private void imageUpload1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var btn = e.Button;
            switch (btn.Caption) {
                case "上传图片":
                    imageUpload1.LoadData(Order.Guid);
                    break;
                case "查看图片":
                    imageUpload1.LoadData(Order.Guid);
                    break;
                default:
                    break;
            }
        }
    }
}
