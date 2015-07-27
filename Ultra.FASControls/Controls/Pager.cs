using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Common;

namespace Ultra.FASControls {
    //public class ItemPricePager : EFPgr<UltraDbEntity.T_ERP_ItemPrice> { }
    public partial class Pager : UserControl {
    }

    public class IvtChkMasterPager : EFPgr<UltraDbEntity.T_ERP_IvtCheckMaster> { }
    public class ItemPager : EFPgr<UltraDbEntity.T_ERP_Item> { }
    public class MaterialPager : EFPgr<UltraDbEntity.T_ERP_Material> { }
    public class IvtMaterialPager : EFPgr<UltraDbEntity.V_ERP_InventoryMaterial> { }
    public class InStockPager : EFPgr<UltraDbEntity.T_ERP_InStock> { }
    public class ProduceMaterPager : EFPgr<UltraDbEntity.T_ERP_ProduceMater> { }
    public class InStockMaterialPager : EFPgr<UltraDbEntity.T_ERP_InStockMatMaster> { }
    public class RecvMaterPager : EFPgr<UltraDbEntity.T_ERP_RecvMater> { }
    public class IvtAdjPager : EFPgr<UltraDbEntity.T_ERP_IvtAdj> { }
    public class IvtCollectPager : EFPgr<UltraDbEntity.V_ERP_InventCollect> { }
    public class MaterialAdjPager : EFPgr<UltraDbEntity.T_ERP_MaterialIvtAdj> { }
    public class InventoryMaterialPager : EFPgr<UltraDbEntity.T_ERP_InventoryMaterial> { }
    public class MaterialCheckPager : EFPgr<UltraDbEntity.T_ERP_MaterialCheckMaster> { }
    public class TrdPager : EFPgr<UltraDbEntity.T_ERP_Trade> { }
    public class FinPager : EFPgr<UltraDbEntity.T_ERP_FinRec> { }
    public class WorkerPager : EFPgr<UltraDbEntity.T_ERP_Worker> { }
    public class TradePrdPager : EFPgr<UltraDbEntity.T_ERP_TradePrd> { }
    public class DeliveryPager : EFPgr<UltraDbEntity.T_ERP_Delivery> { }
    public class OrderProcedPager : EFPgr<UltraDbEntity.T_ERP_OrderProced> { }
    public class AfterSalePager : EFPgr<UltraDbEntity.T_ERP_AfterSale> { }
    public class InStockExPager : EFPgr<UltraDbEntity.T_ERP_InStockEx> { }
    public class InventSelectPager : EFPgr<UltraDbEntity.V_ERP_InventSelect> { }
    public class MaterialRetPager : EFPgr<UltraDbEntity.T_ERP_MaterialIvtRet> { }
    public class CompanyPager : EFPgr<UltraDbEntity.T_ERP_Company> { }
    public class ItemPricePager : EFPgr<UltraDbEntity.T_ERP_ItemPrice> { }
}
