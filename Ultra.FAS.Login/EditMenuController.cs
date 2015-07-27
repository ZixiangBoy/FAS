using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Ultra.Logic;
using Ultra.Surface.Lanuch;
//using Ultra.Svc;
using Ultra.Web.Core.Common;

namespace Ultra.FAS.Login
{
    public class EditMenuController : Ultra.Logic.EFController<UltraDbEntity.T_ERP_MenuNew>
    {
        [HttpPost]
        public ResultData EditMenuNew(List<UltraDbEntity.T_ERP_MenuNew> mnus,string version,string bsversion)
        {
            bsversion = string.IsNullOrEmpty(bsversion) ? string.Empty : bsversion;
            var rd = new ResultData { IsOK=true,ErrMsg=string.Empty,QueryCount=0 };
            using (var con = new SqlConnection(ConnStr)) {
                con.Open();
                var tran = con.BeginTransaction();
                try {
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text
                                , " delete T_ERP_MenuNew "
                                , new SqlParameter("@0", version)
                                , new SqlParameter("@1", bsversion));
                    using (var blk = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, tran)) {
                        blk.DestinationTableName = "T_ERP_MenuNew";
                        blk.WriteToServerAdv<UltraDbEntity.T_ERP_MenuNew>(mnus
                            , new string[] { "Id", "CreateDate", "UpdateDate", "IsDel","UISelected","IsDynamicAdd" });
                    }
                    tran.Commit();
                } catch (Exception ex) {
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
