using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultra.FASControls.Controllers {
    public class CtlUserController : Ultra.Logic.EFController<UltraDbEntity.T_ERP_User> {
        public override bool CheckForAdd(UltraDbEntity.T_ERP_User oj, Logic.ResultData rd) {

            var e = Db.FirstOrDefault<UltraDbEntity.T_ERP_User>("where UserName=@0", oj.UserName);
            if (null != e) { rd.ErrMsg = "账号名称不可以重复！"; return rd.IsOK = false; }
            rd.IsOK = true; rd.ErrMsg = string.Empty;
            //Db.Insert(oj);
            return true;
        }

        public override bool CheckForEdt(UltraDbEntity.T_ERP_User oj, Logic.ResultData rd) {
            var e = Db.FirstOrDefault<UltraDbEntity.T_ERP_User>("where UserName=@0 and Guid<>@1",
                oj.UserName, oj.Guid);
            if (null != e) { rd.ErrMsg = "账号名称不可以重复！"; return rd.IsOK = false; }
            rd.IsOK = true; rd.ErrMsg = string.Empty;
            //Db.Update(oj);
            return true;
        }
    }
}
