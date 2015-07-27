using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;

namespace Ultra.FASControls.Controls
{
    public partial class BasePopupView : DialogViewEx
    {
        public BasePopupView()
        {
            InitializeComponent();
            this.Load += (s1, e1) => { InitUI(); };
        }


        public EntityPopupView OwnerEdit { get; internal set; }

        public virtual void InitUI()
        {
            if (null != OwnerEdit&& !string.IsNullOrEmpty(OwnerEdit.PopupViewText))
            {
                Text = OwnerEdit.PopupViewText;
            }
            else
                Text = "选择您需要的数据";
            if (null == OwnerEdit) return;
            var bmu = OwnerEdit.AllowMultiSelect;
            if (bmu)
            {
                this.gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    Caption = "选择",
                    FieldName = "UISelected",
                    Visible = true
                });
            }
            //foreach (var item in OwnerEdit.ColumnItems)
            foreach (LabelGridEditColItemEx item in OwnerEdit.NameFieldItems)
            {
                this.gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    Caption = item.Caption,
                    FieldName = item.FieldName,
                    Visible = true
                });
            }
            this.btnClose.Left = this.Width-this.btnClose.Width - 30;
            this.btnOK.Left = this.btnClose.Left - this.btnOK.Width - 10;
            Refresh();
        }

        public virtual void Refresh() { }
    }
}
