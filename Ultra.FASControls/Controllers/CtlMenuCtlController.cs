using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Http;
using Ultra.Logic;
using Ultra.Web.Core.Common;

namespace Ultra.FASControls.Controllers
{
    public class CtlMenuCtlController : Ultra.Logic.EFController<UltraDbEntity.T_ERP_MenuCtl>
    {

        public class MenuItemComparer : IEqualityComparer<UltraDbEntity.T_ERP_MenuItem>
        {
            public bool Equals(UltraDbEntity.T_ERP_MenuItem x, UltraDbEntity.T_ERP_MenuItem y)
            {
                if (x == null)
                    return y == null;
                return x.MenuName == y.MenuName && x.MenuGrpName == y.MenuGrpName && x.MenuClsName == y.MenuClsName;
            }

            public int GetHashCode(UltraDbEntity.T_ERP_MenuItem obj)
            {
                if (obj == null)
                    return 0;
                return obj.Id.GetHashCode();
            }
        }

        [HttpPost]
        public ResultData SaveRolePermission(List<UltraDbEntity.T_ERP_MenuCtl> lst, UltraDbEntity.T_ERP_Role role)
        {
            var rd = new ResultData { IsOK = true, ErrMsg = string.Empty, QueryCount = 0 };

            var excludes = new string[] { "Id", "Guid", "CreateDate", "UpdateDate", "IsDel", "UISelected", "IsDynamicAdd" };
            using (var con = new SqlConnection(ConnStr))
            {
                con.Open();
                var tran = con.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text
                                , @" delete T_ERP_MenuItem where rolename=@0
                                ;delete T_ERP_MenuCtl where rolename=@0 "
                                , new SqlParameter("@0", role.Name));
                    using (var blk = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, tran))
                    {
                        blk.DestinationTableName = "T_ERP_MenuCtl";
                        blk.WriteToServerAdv<UltraDbEntity.T_ERP_MenuCtl>(lst, excludes);

                        blk.DestinationTableName = "T_ERP_MenuItem";
                        blk.WriteToServerAdv<UltraDbEntity.T_ERP_MenuItem>(
                            lst.Select(k =>
                                new UltraDbEntity.T_ERP_MenuItem
                                {
                                    MenuAsmName = string.Empty,
                                    MenuClsName = k.ClsName,
                                    MenuGrpName = k.MenuGrpName,
                                    MenuName = k.MenuName,
                                    RoleGuid = role.Guid,
                                    RoleName = role.Name,
                                    Creator = k.Creator,
                                    Updator = k.Updator,
                                    Reserved2 = string.Empty,
                                    Remark = string.Empty
                                }).Distinct(new MenuItemComparer()).ToList()
                            , excludes);
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    rd.IsOK = false;
                    rd.ErrMsg = ex.Message;
                    tran.Rollback();
#if DEBUG
                    throw;
#endif
                }
            }
            return rd;
        }
    }
}
