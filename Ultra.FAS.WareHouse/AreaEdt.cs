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

namespace Ultra.FAS.WareHouse
{
    public partial class AreaEdt : DialogViewEx
    {
        public AreaEdt()
        {
            InitializeComponent();
        }

        public EFCaller<UltraDbEntity.T_ERP_WareArea> Calr { get; set; }
        public EFCaller<UltraDbEntity.T_ERP_WareHouse> WareCalr { get; set; }
        public UltraDbEntity.T_ERP_WareArea Entity { get; set; }

        private void AreaEdt_Load(object sender, EventArgs e)
        {
            wareHouseGridEdit1.LoadData();

            if (Entity != null && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                txtcode.Text = Entity.AreaCode;
                txtname.Text = Entity.AreaName;
                chkUsing.Checked = Entity.IsUsing;
                checkCtl1.Checked = Entity.IsDef;
                wareHouseGridEdit1.SetSelectedValue(new UltraDbEntity.T_ERP_WareHouse
                {
                    Guid = Entity.WareGuid
                });
                //文本框只读
                txtcode.Properties.ReadOnly = txtname.Properties.ReadOnly = true;
                //下拉框只读
                wareHouseGridEdit1.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            var war = wareHouseGridEdit1.SelectedValue;
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var oj = new UltraDbEntity.T_ERP_WareArea
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    Remark = string.Empty,
                    Guid = Guid.NewGuid(),
                    //
                    IsUsing = chkUsing.Checked,
                    IsDef = checkCtl1.Checked,
                    WareCode = war.WareCode,
                    WareGuid = war.Guid,
                    WareName = war.WareName,
                    AreaCode = txtcode.Text,
                    AreaName = txtname.Text
                };
                //tip 
                if (checkCtl1.Checked)
                {
                    if (MsgBox.ShowYesNoMessage(string.Empty, "是否设置为默认？") == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                var rd = Calr.Add(oj);
                if (!rd.IsOK)
                {
                    MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                    return;
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                    return;
                }
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.IsUsing = chkUsing.Checked;
                Entity.IsDef = checkCtl1.Checked;
                Entity.WareGuid = war.Guid;
                Entity.WareName = war.WareName;
                Entity.WareCode = war.WareCode;
                //tip
                if(checkCtl1.Checked)
                {
                    if (MsgBox.ShowYesNoMessage(string.Empty, "是否设置为默认？") == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                Calr.Edt(Entity);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                return;
            }
        }

    }
}
