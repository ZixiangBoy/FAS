using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Http;
using Ultra.Logic;
using Ultra.Web.Core.Common;

namespace Ultra.FASControls.Controllers {

    public class CtlRoleUserController : Ultra.Logic.EFController<UltraDbEntity.T_ERP_RoleUser> {

        string[] Exclude = new string[] { 
            "Id","Guid","CreateDate","UpdateDate","Remark","Reserved1","Reserved2","Reserved3"
            ,"UISelected","IsDynamicAdd","TimeStamp"
        };

        [HttpPost]
        public ResultData CleanRoleUser(Guid roleguid) {
            try {
                Db.Execute("delete T_ERP_RoleUser where roleGuid=@0", roleguid);
                return new ResultData { };
            } catch (Exception ex) {
                return new ResultData { IsOK = false, ErrMsg = ex.Message };
            }
        }

        [HttpPost]
        public ResultData SaveRoleSet(List<UltraDbEntity.T_ERP_RoleUser> ru) {
            var roleguid = ru.Select(j => j.RoleGuid).First();
            using (var con = new SqlConnection(this.ConnStr)) {
                try {
                    con.Open();
                    var tran = con.BeginTransaction();
                    SqlHelper.ExecuteNonQuery(tran, System.Data.CommandType.Text,
                        "delete T_ERP_RoleUser where roleGuid=@gid",
                        new SqlParameter("@gid", roleguid));
                    if (ru != null && ru.Count > 0 && ru.FirstOrDefault() != null
                        && ru.FirstOrDefault().Reserved2 != "admin") {
                        using (var blk = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, tran)) {
                            blk.DestinationTableName = "T_ERP_RoleUser";
                            blk.WriteToServerAdv<UltraDbEntity.T_ERP_RoleUser>(ru, Exclude);
                        }
                    }
                    tran.Commit();
                    return new ResultData { };
                } catch (Exception ex) {
#if DEBUG
                    throw;
#endif
                    return new ResultData { IsOK = false, ErrMsg = ex.Message };
                } finally { con.Close(); }
            }
        }

    }
}
