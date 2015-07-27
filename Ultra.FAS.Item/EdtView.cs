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
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using UltraDbEntity;

namespace Ultra.FAS.Item
{
    public partial class EdtView : DialogViewEx
    {
        public EdtView()
        {
            InitializeComponent();
        }

        public T_ERP_ItemStyle Entity { get; set; }

        public EFCaller<UltraDbEntity.T_ERP_ItemStyle> Calr { get; set; }

        private void EdtView_Load(object sender, EventArgs e)
        {
            if (null != Entity)
            {
                txtstylename.Text = Entity.StyleName;
                txttypename.Text = Entity.TypeName;
                if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
                {
                    txtstyledata.Text = Entity.StyleData;
                    chkusing.Checked = Entity.IsUsing.Value;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var oj = new UltraDbEntity.T_ERP_ItemStyle
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Guid = Guid.NewGuid(),
                    Remark = string.Empty,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    TypeName = txttypename.Text,
                    StyleName = txtstylename.Text,
                    StyleData = txtstyledata.Text,
                    IsUsing = chkusing.Checked
                };
                var rd = Calr.Add(oj);
                if (!rd.IsOK)
                {
                    MsgBox.ShowMessage(string.Empty, rd.ErrMsg); return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close(); return;
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.IsUsing = chkusing.Checked;
                Entity.StyleData = txtstyledata.Text;
                var rd = Calr.Edt(Entity);
                if (!rd.IsOK)
                {
                    MsgBox.ShowMessage(string.Empty, rd.ErrMsg); return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close(); return;
            }
        }
    }
}
