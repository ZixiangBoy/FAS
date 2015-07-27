using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Logic;

namespace Ultra.Suppliers
{
    public class SuppliersController : EFController<UltraDbEntity.T_ERP_Suppliers>
    {
        public override bool CheckForAdd(UltraDbEntity.T_ERP_Suppliers oj, ResultData rd)
        {
            var et = Db.Fetch<UltraDbEntity.T_ERP_Suppliers>("where SuppName=@0", oj.SuppName);
            if (et != null && et.Count > 0)
            {
                rd.IsOK = false; rd.ErrMsg = "供应商不可以重复!";
                return rd.IsOK;
            }
            return true;
        }
    }
}
