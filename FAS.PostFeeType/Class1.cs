using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Common;
using Ultra.Logic;

namespace Ultra.PostFeeType
{
    public class Logic : EFLogic<UltraDbEntity.T_ERP_PostFeeType>
    {
        public Logic(string con) : base(con) { }

        public ResultData AddCfg(UltraDbEntity.T_ERP_PostFeeType pc)
        {
            ResultData rd = new ResultData();
            var et = Db.Fetch<UltraDbEntity.T_ERP_PostFeeType>("where TypeName=@0", pc.TypeName);
            if (et != null && et.Count > 0)
            {
                rd.IsOK = false; rd.ErrMsg = "名称不可以重复!";
                return rd;
            }
            Db.Insert(pc);
            return rd;
        }
    }
}
