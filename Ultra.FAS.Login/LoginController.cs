using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Ultra.Logic;
using Ultra.Surface.Lanuch;
using Ultra.Svc;

namespace Ultra.FAS.Login
{
    public class LoginController : Ultra.Logic.EFController<UltraDbEntity.T_ERP_User>
    {
        [HttpPost]
        public UltraDbEntity.T_ERP_User Authenticate(UltraDbEntity.T_ERP_User usr)
        {
            if (null == usr || string.IsNullOrEmpty(usr.UserName)) return null;
            var et = Db.Fetch<UltraDbEntity.T_ERP_User>("where UserName=@0 and Pwd=@1",
                 usr.UserName, usr.Pwd).FirstOrDefault();
            if (null == et) return null;
            ACEToken atk = new ACEToken(et.UserName, (null == Request) ? "" :
                Request.GetClientIpAddress()
                );
            var chk = string.Format("SYS.Cache.Login.{0}", et.UserName);
            var catk = Lanucher.Cache.Get<ACEToken>(chk);
            if (null == catk)//不存在缓存中
                Lanucher.Cache.Put<ACEToken>(chk, atk);
            else
            {
                atk = catk;
            }
            et.Reserved2 = Ultra.Svc.AES.Encrypt(atk.ToString());
            return et;
        }

        [HttpPost]
        public UltraDbEntity.T_ERP_User ServerTime(UltraDbEntity.T_ERP_User str)
        {
            var d = Db.Fetch<DateTime>("Select GetDate()").FirstOrDefault();
            return new UltraDbEntity.T_ERP_User
            {
                CreateDate = d
            };
        }

        public override List<UltraDbEntity.T_ERP_User> Get(string whr = "", params object[] prms)
        {
            return new List<UltraDbEntity.T_ERP_User> {new UltraDbEntity.T_ERP_User{
                UserName="test"
            } };
        }

        public override Ultra.Logic.ResultData Add(UltraDbEntity.T_ERP_User oj)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override Ultra.Logic.ResultData AddBatch(List<UltraDbEntity.T_ERP_User> ojs)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override Ultra.Logic.ResultData BatchAdd(Ultra.Logic.BatchAddObj<UltraDbEntity.T_ERP_User> boj)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override bool CheckForAdd(UltraDbEntity.T_ERP_User oj, Ultra.Logic.ResultData rd)
        {
            return false;
        }

        public override Ultra.Logic.ResultData Del(UltraDbEntity.T_ERP_User oj)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override bool CheckForDel(UltraDbEntity.T_ERP_User oj, Ultra.Logic.ResultData rd)
        {
            return false;
        }

        public override bool CheckForEdt(UltraDbEntity.T_ERP_User oj, Ultra.Logic.ResultData rd)
        {
            return false;
        }

        public override Ultra.Logic.ResultData Edt(UltraDbEntity.T_ERP_User oj)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override Ultra.Logic.ResultData BatchEdt(List<UltraDbEntity.T_ERP_User> ojs, params string[] cols)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override Ultra.Logic.ResultData EdtPart(UltraDbEntity.T_ERP_User oj, params string[] cols)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override Ultra.Logic.ResultData ExecProc(string sql, params object[] prms)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override Ultra.Logic.ResultData ExecSql(Ultra.Logic.ExcSqlData sd)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override List<UltraDbEntity.T_ERP_User> GetByProc(string procsql, params object[] prms)
        {
            return null;
        }
        public override Ultra.Logic.ResultData ExecSql(string sql, params object[] prms)
        {
            return new Ultra.Logic.ResultData { IsOK = false };
        }

        public override List<UltraDbEntity.T_ERP_User> GetDataBy(string whr = "")
        {
            return null;
        }

        public override PetaPoco.Page<UltraDbEntity.T_ERP_User> GetPageData(int pgidx, int pgsize, string whr, object[] prms)
        {
            return null;
        }
    }
}
