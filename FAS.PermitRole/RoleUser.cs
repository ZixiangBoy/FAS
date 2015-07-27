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
using Ultra.Win.Core.Common;
using Ultra.Web.Core.Common;
using Ultra.Common;
using Ultra.FASControls.Extend;
using Ultra.Surface.Common;
using Ultra.FASControls.Caller;
using MoreLinq;
using Ultra.FASControls;

namespace FAS.PermitRole
{
    public partial class RoleUser : DialogViewEx
    {
        public RoleUser()
        {
            InitializeComponent();
        }

        private void RoleUser_Load(object sender, EventArgs e)
        {
            gtRole.Properties.DataSource =
                SerNoCaller_WL.Calr_Role.Get("where IsDel=0");
            return;
        }

        private void gtRole_EditValueChanged(object sender, EventArgs e)
        {
            var r = gtRole.EditValue;
            if (null == r || string.IsNullOrEmpty(r.ToString())) return;

            var gid = Guid.Parse(r.ToString());
            //var usr = Lgc.GetRoleUser(gid);
            //--var usr = SerNoCaller.Calr_User.Get("select distinct Remark,Reserved3,Id,Guid,UserName from V_ERP_UserByRole");
            //不是所选角色的用户
            var noroleusr = SerNoCaller.Calr_User.Get("select distinct Remark,Reserved3,Id,Guid,UserName from V_ERP_UserByRole where Remark<>@0"
                , gid).ToList();
            gcRight.DataSource = noroleusr.DistinctBy(j => j.UserName).ToList();
            //usr.Where(j => !j.Reserved3).DistinctBy(j => j.UserName).ToList();
            //已是所选角色的用户
            var roleusr = SerNoCaller.Calr_User.Get("select distinct Remark,Reserved3,Id,Guid,UserName from V_ERP_UserByRole where Remark=@0"
                , gid).ToList();
            gcLeft.DataSource = roleusr.DistinctBy(j => j.UserName).ToList();
            var rig = gcRight.GetDataSource<UltraDbEntity.T_ERP_User>();
            var lef = gcLeft.GetDataSource<UltraDbEntity.T_ERP_User>();
            gcRight.DataSource = rig.Where(j => !lef.Any(k => k.UserName == j.UserName)).ToList();
            //usr.Where(j=>string.Compare(j.Remark,r.ToString(),true)==0).Where(j => j.Reserved3)
            //.DistinctBy(j=>j.UserName).ToList();
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
            var etrs = gcRight.DataSource as List<UltraDbEntity.T_ERP_User>;
            if (null == etrs) return;
            var etr = gvRight.GetFocusedDataSource<UltraDbEntity.T_ERP_User>();
            if (null == etr) return;
            var etl = gcLeft.DataSource as List<UltraDbEntity.T_ERP_User>;
            etl = null == etl ? new List<UltraDbEntity.T_ERP_User>() : etl;
            etl.Add(etr);
            etrs.Remove(etr);
            gcLeft.DataSource = etl;
            gcLeft.RefreshDataSource();
            gcRight.DataSource = etrs;
            gcRight.RefreshDataSource();
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            var etrs = gcRight.DataSource as List<UltraDbEntity.T_ERP_User>;
            if (null == etrs) return;
            var etl = gcLeft.DataSource as List<UltraDbEntity.T_ERP_User>;
            etl = null == etl ? new List<UltraDbEntity.T_ERP_User>() : etl;
            etl.AddRange(etrs);
            etrs.Clear();
            gcLeft.RefreshDataSource();
            gcRight.RefreshDataSource();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            var etrs = gcLeft.DataSource as List<UltraDbEntity.T_ERP_User>;
            if (null == etrs) return;
            var etr = gcLeft.GetFocusedDataSource<UltraDbEntity.T_ERP_User>();
            if (null == etr) return;
            var etl = gcRight.DataSource as List<UltraDbEntity.T_ERP_User>;
            etl = null == etl ? new List<UltraDbEntity.T_ERP_User>() : etl;
            etl.Add(etr);
            etrs.Remove(etr);
            gcLeft.RefreshDataSource();
            gcRight.RefreshDataSource();
        }

        private void btnrightall_Click(object sender, EventArgs e)
        {
            var etrs = gcLeft.DataSource as List<UltraDbEntity.T_ERP_User>;
            if (null == etrs) return;
            var etl = gcRight.DataSource as List<UltraDbEntity.T_ERP_User>;
            etl = null == etl ? new List<UltraDbEntity.T_ERP_User>() : etl;
            etl.AddRange(etrs);
            etrs.Clear();
            gcLeft.RefreshDataSource();
            gcRight.RefreshDataSource();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var r = gtRole.EditValue;
            var rle = gtRole.Properties.DataSource as List<UltraDbEntity.T_ERP_Role>;
            if (null == rle || rle.Count < 1) return;

            if (null == r || string.IsNullOrEmpty(r.ToString())) return;
            var gid = Guid.Parse(r.ToString());
            var re = rle.Where(j => j.Guid == gid).FirstOrDefault();
            if (null == re) return;
            var etl = gcLeft.DataSource as List<UltraDbEntity.T_ERP_User>;
            etl = etl ?? new List<UltraDbEntity.T_ERP_User>(20);
            var rus = new List<UltraDbEntity.T_ERP_RoleUser>(20);
            etl.ForEach(j =>
            {
                rus.Add(new UltraDbEntity.T_ERP_RoleUser
                {
                    Guid = Guid.NewGuid(),
                    UserName = j.UserName,
                    RoleGuid = gid,
                    RoleName = re.Name,
                    Creator = CurUser,
                    Updator = CurUser
                });
            });
            //var bok = Lgc.SaveRoleSet(rus);
            var bok = rus.Count > 0 ? new Ultra.CoreCaller.Caller().InvokePost<List<UltraDbEntity.T_ERP_RoleUser>>
                (rus, new Ultra.FASControls.Controllers.CtlRoleUserController(), "SaveRoleSet") :
                new Ultra.CoreCaller.Caller().InvokePost<List<UltraDbEntity.T_ERP_RoleUser>>
                (new List<UltraDbEntity.T_ERP_RoleUser>{new UltraDbEntity.T_ERP_RoleUser{
                    Guid=Guid.Empty,UserName="admin",RoleGuid=gid,Reserved2="admin"
                }}
            , new Ultra.FASControls.Controllers.CtlRoleUserController(), "SaveRoleSet");
            if (bok.IsOK)
            {
                MsgBox.ShowMessage(string.Empty, "保存成功!");
            }
            else
            {
                MsgBox.ShowErrMsg(bok.ErrMsg);
            }
        }
    }
}
