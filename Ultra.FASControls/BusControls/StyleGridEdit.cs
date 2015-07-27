using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultra.FASControls.BusControls
{
    public class StyleGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_ItemStyle>
    {
        protected override List<UltraDbEntity.T_ERP_ItemStyle> GetData(string whr, params object[] prms)
        {
            return SerNoCaller_WL.Calr_ItemStyle.Get(whr, prms);
        }
    }

    public class AreaEdtGridEdit : WareAreaGridEdit
    {

    }

}
