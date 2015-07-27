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
    public partial class LocEdt : DialogViewEx
    {
        public LocEdt()
        {
            InitializeComponent();
        }

        public EFCaller<UltraDbEntity.T_ERP_WareArea> Calr { get; set; }
        public EFCaller<UltraDbEntity.T_ERP_WareLoc> LocCalr { get; set; }

        public UltraDbEntity.T_ERP_WareLoc Entity { get; set; }

        private void LocEdt_Load(object sender, EventArgs e)
        {
            areaEdtGridEdit1.LoadData();
            if (Entity != null && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                textCode.Text = Entity.LocCode;
                textName.Text = Entity.LocName;
                textName.Properties.ReadOnly = textCode.Properties.ReadOnly = true;
                checkCtl1.Checked = Entity.IsDef;
                checkCtl2.Checked = Entity.IsUsing;
                areaEdtGridEdit1.SetSelectedValue(new UltraDbEntity.T_ERP_WareArea
                {
                    Guid = Entity.AreaGuid
                });
                areaEdtGridEdit1.Enabled = false;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            var war = areaEdtGridEdit1.SelectedValue;
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var oj = new UltraDbEntity.T_ERP_WareLoc
                {
                    Creator = CurUser,
                    Updator = CurUser,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    Remark = string.Empty,
                    Guid = Guid.NewGuid(),
                    //
                    LocCode = textCode.Text,
                    LocName = textName.Text,
                    IsUsing = checkCtl2.Checked,
                    IsDef = checkCtl1.Checked,
                    AreaGuid = war.Guid,
                    AreaName = war.AreaName,
                    WareCode = war.WareCode,
                    WareGuid = war.WareGuid,
                    WareName = war.WareName
                };
                if(checkCtl1.Checked)
                {
                    if(MsgBox.ShowYesNoMessage(string.Empty,"是否设置为默认？") == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                var rd = LocCalr.Add(oj);
                if (!rd.IsOK)
                {
                    MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.IsUsing = checkCtl2.Checked;
                Entity.IsDef = checkCtl1.Checked;
                Entity.AreaGuid = war.Guid;
                Entity.AreaName = war.AreaName;
                Entity.WareCode = war.WareCode;
                Entity.WareGuid = war.WareGuid;
                Entity.WareName = war.WareName;
                if (checkCtl1.Checked)
                {
                    if (MsgBox.ShowYesNoMessage(string.Empty, "是否设置为默认？") == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                LocCalr.Edt(Entity);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

    }
}
