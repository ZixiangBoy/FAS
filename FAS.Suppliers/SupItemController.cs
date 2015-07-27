using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.Logic;
using UltraDbEntity;

namespace Ultra.Suppliers
{
    public class SupItemController : EFController<T_ERP_Item>
    {
        public SupItemController(string con) : base(con) { }

    }
}
