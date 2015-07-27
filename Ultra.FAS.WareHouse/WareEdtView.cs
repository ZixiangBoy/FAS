using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.CoreCaller;
using Ultra.FASControls;

namespace Ultra.FAS.WareHouse
{
    public partial class WareEdtView : DialogViewEx
    {
        public WareEdtView()
        {
            InitializeComponent();
        }

        
        public UltraDbEntity.T_ERP_WareHouse Entity { get; set; }

        public EFCaller<UltraDbEntity.T_ERP_WareHouse> Calr { get; set; }


        private void WareEdtView_Load(object sender, EventArgs e)
        {
            txtsquare.EditValue = txtvolume.EditValue = null;
            if (null != Entity && EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                txtcode.Text = Entity.WareCode;
                txtname.Text = Entity.WareName;
                txtmobile.Text = Entity.Mobile;
                txtcontact.Text = Entity.Contact;
                txtphone.Text = Entity.Phone;
                chk.Checked = Entity.IsUsing;
                txtsquare.EditValue = Entity.Square;
                txtvolume.EditValue = Entity.Volume;
                txtcode.Properties.ReadOnly = txtname.Properties.ReadOnly = true;
                chkVirtual.Checked = Entity.IsVirtual == null ? false : Entity.IsVirtual.Value;
                chkVirtual.Properties.ReadOnly = true;
                chkOutWare.Properties.ReadOnly = true;
                chkOutWare.Checked = Entity.IsOut;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Business.Core.Define.EnViewEditMode.New)
            {
                var wre = new UltraDbEntity.T_ERP_WareHouse
                {
                    Guid = Guid.NewGuid(),
                    Contact = txtcontact.Text,
                    Creator = CurUser,
                    Updator = CurUser,
                    WareCode = txtcode.Text,
                    WareName = txtname.Text,
                    Mobile = txtmobile.Text,
                    IsUsing = chk.Checked,
                    Phone = txtphone.Text,
                    Reserved1 = 0,
                    Reserved2 = string.Empty,
                    Reserved3 = false,
                    Remark = string.Empty,
                    IsVirtual=chkVirtual.Checked,
                    IsOut=chkOutWare.Checked,
                };
                if (txtsquare.EditValue != null)
                    wre.Square = txtsquare.Value;
                if (txtvolume.EditValue != null)
                    wre.Volume = txtvolume.Value;
                if (chkOutWare.Checked)//是外发仓库
                {
                    decimal? dsq=txtsquare.EditValue==null?0:txtsquare.Value;
                    decimal? dvl=txtvolume.EditValue==null?0:txtvolume.Value;
                    //自动创建区域和库位
                  var rds=  Calr.GetByProc("exec P_ERP_NewOutWareHouse @0,@1,@2,@3,@4,@5,@6,@7,@8,@9",
                        txtcode.Text, txtname.Text, txtcontact.Text, CurUser, txtmobile.Text, txtphone.Text, chk.Checked,
                        wre.Guid, dsq, dvl);
                  if (null != rds && rds.Count > 0)
                  {
                      var rdx = rds.FirstOrDefault();
                      if (null != rdx)
                      {
                          MsgBox.ShowErrMsg(rdx.WareName);
                          return;
                      }
                  }
                  else
                  {
                      DialogResult = System.Windows.Forms.DialogResult.OK;
                      Close();
                  }
                }
                else
                {
                    var rd = Calr.Add(wre);
                    if (rd.IsOK)
                    {
                        //自动创建出默认库位默认区域
                        SerNoCaller.Calr_WareHouse.ExecSql("exec P_ERP_WareAutoAreaLoc @0,@1", wre.WareName, CurUser);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                        return;
                    }
                }
            }
            else if (EditMode == Business.Core.Define.EnViewEditMode.Edit)
            {
                Entity.Phone = txtphone.Text;
                Entity.IsUsing = chk.Checked;
                Entity.Mobile = txtmobile.Text;
                if (null != txtsquare.EditValue)
                    Entity.Square = txtsquare.Value;
                if (null != txtvolume.EditValue)
                    Entity.Volume = txtvolume.Value;
                Entity.Contact = txtcontact.Text;
                Entity.Updator = CurUser;
                
                var rd = Calr.Edt(Entity);
                if (rd.IsOK)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    MsgBox.ShowMessage(string.Empty, rd.ErrMsg);
                    return;
                }
            }
        }
    }
}
