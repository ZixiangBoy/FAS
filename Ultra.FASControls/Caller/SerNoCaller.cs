using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.CoreCaller;
using Ultra.FASControls.Controllers;

namespace Ultra.FASControls
{
    public partial class SerNoCaller {
        //CtlPostFeeTypeController
        protected static EFCaller<UltraDbEntity.T_ERP_PostFeeType> _Calr_PostFeeType = null;
        public static EFCaller<UltraDbEntity.T_ERP_PostFeeType> Calr_PostFeeType {
            get {
                return
                    _Calr_PostFeeType = _Calr_PostFeeType ??
                   new EFCaller<UltraDbEntity.T_ERP_PostFeeType>(new CtlPostFeeTypeController());
            }
        }
        //CtlItemPrice_ImptController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemPrice_Impt> _Calr_ItemPrice_Impt = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemPrice_Impt> Calr_ItemPrice_Impt {
            get {
                return
                    _Calr_ItemPrice_Impt = _Calr_ItemPrice_Impt ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemPrice_Impt>(new CtlItemPrice_ImptController());
            }
        }
        //CtlItemPriceController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemPrice> _Calr_ItemPrice = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemPrice> Calr_ItemPrice {
            get {
                return
                    _Calr_ItemPrice = _Calr_ItemPrice ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemPrice>(new CtlItemPriceController());
            }
        }
        //CtlTradeMarkController
        protected static EFCaller<UltraDbEntity.T_ERP_TradeMark> _Calr_TradeMark = null;
        public static EFCaller<UltraDbEntity.T_ERP_TradeMark> Calr_TradeMark {
            get {
                return
                    _Calr_TradeMark = _Calr_TradeMark ??
                   new EFCaller<UltraDbEntity.T_ERP_TradeMark>(new CtlTradeMarkController());
            }
        }
        //CtlCompanyController
        protected static EFCaller<UltraDbEntity.T_ERP_Company> _Calr_Company = null;
        public static EFCaller<UltraDbEntity.T_ERP_Company> Calr_Company {
            get {
                return
                    _Calr_Company = _Calr_Company ??
                   new EFCaller<UltraDbEntity.T_ERP_Company>(new CtlCompanyController());
            }
        }
        //CtlV_ERP_PrintOrderProceDetailController
        protected static EFCaller<UltraDbEntity.V_ERP_PrintOrderProceDetail> _Calr_V_ERP_PrintOrderProceDetail = null;
        public static EFCaller<UltraDbEntity.V_ERP_PrintOrderProceDetail> Calr_V_ERP_PrintOrderProceDetail {
            get {
                return
                    _Calr_V_ERP_PrintOrderProceDetail = _Calr_V_ERP_PrintOrderProceDetail ??
                   new EFCaller<UltraDbEntity.V_ERP_PrintOrderProceDetail>(new CtlV_ERP_PrintOrderProceDetailController());
            }
        }
        //CtlV_ERP_PrintOrderProceController
        protected static EFCaller<UltraDbEntity.V_ERP_PrintOrderProce> _Calr_V_ERP_PrintOrderProce = null;
        public static EFCaller<UltraDbEntity.V_ERP_PrintOrderProce> Calr_V_ERP_PrintOrderProce {
            get {
                return
                    _Calr_V_ERP_PrintOrderProce = _Calr_V_ERP_PrintOrderProce ??
                   new EFCaller<UltraDbEntity.V_ERP_PrintOrderProce>(new CtlV_ERP_PrintOrderProceController());
            }
        }
        //CtlItemInStockController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemInStock> _Calr_ItemInStock = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemInStock> Calr_ItemInStock {
            get {
                return
                    _Calr_ItemInStock = _Calr_ItemInStock ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemInStock>(new CtlItemInStockController());
            }
        }
        //CtlInStockExController
        protected static EFCaller<UltraDbEntity.T_ERP_InStockEx> _Calr_InStockEx = null;
        public static EFCaller<UltraDbEntity.T_ERP_InStockEx> Calr_InStockEx {
            get {
                return
                    _Calr_InStockEx = _Calr_InStockEx ??
                   new EFCaller<UltraDbEntity.T_ERP_InStockEx>(new CtlInStockExController());
            }
        }
        //CtlSuppliers_ImpController
        protected static EFCaller<UltraDbEntity.T_ERP_Suppliers_Imp> _Calr_Suppliers_Imp = null;
        public static EFCaller<UltraDbEntity.T_ERP_Suppliers_Imp> Calr_Suppliers_Imp {
            get {
                return
                    _Calr_Suppliers_Imp = _Calr_Suppliers_Imp ??
                   new EFCaller<UltraDbEntity.T_ERP_Suppliers_Imp>(new CtlSuppliers_ImpController());
            }
        }
        //CtlOrderInStockController
        protected static EFCaller<UltraDbEntity.T_ERP_OrderInStock> _Calr_OrderInStock = null;
        public static EFCaller<UltraDbEntity.T_ERP_OrderInStock> Calr_OrderInStock {
            get {
                return
                    _Calr_OrderInStock = _Calr_OrderInStock ??
                   new EFCaller<UltraDbEntity.T_ERP_OrderInStock>(new CtlOrderInStockController());
            }
        }
        //CtlOrderProcedWorkerController
        protected static EFCaller<UltraDbEntity.T_ERP_OrderProcedWorker> _Calr_OrderProcedWorker = null;
        public static EFCaller<UltraDbEntity.T_ERP_OrderProcedWorker> Calr_OrderProcedWorker {
            get {
                return
                    _Calr_OrderProcedWorker = _Calr_OrderProcedWorker ??
                   new EFCaller<UltraDbEntity.T_ERP_OrderProcedWorker>(new CtlOrderProcedWorkerController());
            }
        }
        //CtlOrderProcedController
        protected static EFCaller<UltraDbEntity.T_ERP_OrderProced> _Calr_OrderProced = null;
        public static EFCaller<UltraDbEntity.T_ERP_OrderProced> Calr_OrderProced {
            get {
                return
                    _Calr_OrderProced = _Calr_OrderProced ??
                   new EFCaller<UltraDbEntity.T_ERP_OrderProced>(new CtlOrderProcedController());
            }
        }
        //CtlV_ERP_PrintOrderPrdController
        protected static EFCaller<UltraDbEntity.V_ERP_PrintOrderPrd> _Calr_V_ERP_PrintOrderPrd = null;
        public static EFCaller<UltraDbEntity.V_ERP_PrintOrderPrd> Calr_V_ERP_PrintOrderPrd {
            get {
                return
                    _Calr_V_ERP_PrintOrderPrd = _Calr_V_ERP_PrintOrderPrd ??
                   new EFCaller<UltraDbEntity.V_ERP_PrintOrderPrd>(new CtlV_ERP_PrintOrderPrdController());
            }
        }
        //CtlOrderPrdController
        protected static EFCaller<UltraDbEntity.T_ERP_OrderPrd> _Calr_OrderPrd = null;
        public static EFCaller<UltraDbEntity.T_ERP_OrderPrd> Calr_OrderPrd {
            get {
                return
                    _Calr_OrderPrd = _Calr_OrderPrd ??
                   new EFCaller<UltraDbEntity.T_ERP_OrderPrd>(new CtlOrderPrdController());
            }
        }
        //CtlTradePrdController
        protected static EFCaller<UltraDbEntity.T_ERP_TradePrd> _Calr_TradePrd = null;
        public static EFCaller<UltraDbEntity.T_ERP_TradePrd> Calr_TradePrd {
            get {
                return
                    _Calr_TradePrd = _Calr_TradePrd ??
                   new EFCaller<UltraDbEntity.T_ERP_TradePrd>(new CtlTradePrdController());
            }
        }
        //CtlOrderController
        protected static EFCaller<UltraDbEntity.T_ERP_Order> _Calr_Order = null;
        public static EFCaller<UltraDbEntity.T_ERP_Order> Calr_Order {
            get {
                return
                    _Calr_Order = _Calr_Order ??
                   new EFCaller<UltraDbEntity.T_ERP_Order>(new CtlOrderController());
            }
        }
        //CtlTradeController
        protected static EFCaller<UltraDbEntity.T_ERP_Trade> _Calr_Trade = null;
        public static EFCaller<UltraDbEntity.T_ERP_Trade> Calr_Trade {
            get {
                return
                    _Calr_Trade = _Calr_Trade ??
                   new EFCaller<UltraDbEntity.T_ERP_Trade>(new CtlTradeController());
            }
        }
        //CtlProduceMaterController
        protected static EFCaller<UltraDbEntity.T_ERP_ProduceMater> _Calr_ProduceMater = null;
        public static EFCaller<UltraDbEntity.T_ERP_ProduceMater> Calr_ProduceMater {
            get {
                return
                    _Calr_ProduceMater = _Calr_ProduceMater ??
                   new EFCaller<UltraDbEntity.T_ERP_ProduceMater>(new CtlProduceMaterController());
            }
        }
        //CtlRecvMaterController
        protected static EFCaller<UltraDbEntity.T_ERP_RecvMater> _Calr_RecvMater = null;
        public static EFCaller<UltraDbEntity.T_ERP_RecvMater> Calr_RecvMater {
            get {
                return
                    _Calr_RecvMater = _Calr_RecvMater ??
                   new EFCaller<UltraDbEntity.T_ERP_RecvMater>(new CtlRecvMaterController());
            }
        }
        //CtlProcedureController
        protected static EFCaller<UltraDbEntity.T_ERP_Procedure> _Calr_Procedure = null;
        public static EFCaller<UltraDbEntity.T_ERP_Procedure> Calr_Procedure {
            get {
                return
                    _Calr_Procedure = _Calr_Procedure ??
                   new EFCaller<UltraDbEntity.T_ERP_Procedure>(new CtlProcedureController());
            }
        }
        //CtlMaterial_ImptController
        protected static EFCaller<UltraDbEntity.T_ERP_Material_Impt> _Calr_Material_Impt = null;
        public static EFCaller<UltraDbEntity.T_ERP_Material_Impt> Calr_Material_Impt {
            get {
                return
                    _Calr_Material_Impt = _Calr_Material_Impt ??
                   new EFCaller<UltraDbEntity.T_ERP_Material_Impt>(new CtlMaterial_ImptController());
            }
        }
        //CtlWareAreaController
        protected static EFCaller<UltraDbEntity.T_ERP_WareArea> _Calr_WareArea = null;
        public static EFCaller<UltraDbEntity.T_ERP_WareArea> Calr_WareArea {
            get {
                return
                    _Calr_WareArea = _Calr_WareArea ??
                   new EFCaller<UltraDbEntity.T_ERP_WareArea>(new CtlWareAreaController());
            }
        }
        //CtlV_ERP_InventoryMaterialController
        protected static EFCaller<UltraDbEntity.V_ERP_InventoryMaterial> _Calr_V_ERP_InventoryMaterial = null;
        public static EFCaller<UltraDbEntity.V_ERP_InventoryMaterial> Calr_V_ERP_InventoryMaterial {
            get {
                return
                    _Calr_V_ERP_InventoryMaterial = _Calr_V_ERP_InventoryMaterial ??
                   new EFCaller<UltraDbEntity.V_ERP_InventoryMaterial>(new CtlV_ERP_InventoryMaterialController());
            }
        }
        //CtlInventoryMaterialController
        protected static EFCaller<UltraDbEntity.T_ERP_InventoryMaterial> _Calr_InventoryMaterial = null;
        public static EFCaller<UltraDbEntity.T_ERP_InventoryMaterial> Calr_InventoryMaterial {
            get {
                return
                    _Calr_InventoryMaterial = _Calr_InventoryMaterial ??
                   new EFCaller<UltraDbEntity.T_ERP_InventoryMaterial>(new CtlInventoryMaterialController());
            }
        }
        //CtlSuppliersController
        protected static EFCaller<UltraDbEntity.T_ERP_Suppliers> _Calr_Suppliers = null;
        public static EFCaller<UltraDbEntity.T_ERP_Suppliers> Calr_Suppliers {
            get {
                return
                    _Calr_Suppliers = _Calr_Suppliers ??
                   new EFCaller<UltraDbEntity.T_ERP_Suppliers>(new CtlSuppliersController());
            }
        }
        //CtlMaterialController
        protected static EFCaller<UltraDbEntity.T_ERP_Material> _Calr_Material = null;
        public static EFCaller<UltraDbEntity.T_ERP_Material> Calr_Material {
            get {
                return
                    _Calr_Material = _Calr_Material ??
                   new EFCaller<UltraDbEntity.T_ERP_Material>(new CtlMaterialController());
            }
        }        
        //CtlRoleUserController
        protected static EFCaller<UltraDbEntity.T_ERP_RoleUser> _Calr_RoleUser = null;
        public static EFCaller<UltraDbEntity.T_ERP_RoleUser> Calr_RoleUser {
            get {
                return
                    _Calr_RoleUser = _Calr_RoleUser ??
                   new EFCaller<UltraDbEntity.T_ERP_RoleUser>(new CtlRoleUserController());
            }
        }
        //CtlUserController
        protected static EFCaller<UltraDbEntity.T_ERP_User> _Calr_User = null;
        public static EFCaller<UltraDbEntity.T_ERP_User> Calr_User {
            get {
                return
                    _Calr_User = _Calr_User ??
                   new EFCaller<UltraDbEntity.T_ERP_User>(new CtlUserController());
            }
        }


        //CtlMenuNewController
        protected static EFCaller<UltraDbEntity.T_ERP_MenuNew> _Calr_MenuNew = null;
        public static EFCaller<UltraDbEntity.T_ERP_MenuNew> Calr_MenuNew {
            get {
                return
                    _Calr_MenuNew = _Calr_MenuNew ??
                   new EFCaller<UltraDbEntity.T_ERP_MenuNew>(new CtlMenuNewController());
            }
        }

        //CtlMenuCtlController
        protected static EFCaller<UltraDbEntity.T_ERP_MenuCtl> _Calr_MenuCtl = null;
        public static EFCaller<UltraDbEntity.T_ERP_MenuCtl> Calr_MenuCtl
        {
            get
            {
                return
                    _Calr_MenuCtl = _Calr_MenuCtl ??
                   new EFCaller<UltraDbEntity.T_ERP_MenuCtl>(new CtlMenuCtlController());
            }
        }

        //CtlRoleSetController
        protected static EFCaller<UltraDbEntity.T_ERP_RoleSet> _Calr_RoleSet = null;
        public static EFCaller<UltraDbEntity.T_ERP_RoleSet> Calr_RoleSet
        {
            get
            {
                return
                    _Calr_RoleSet = _Calr_RoleSet ??
                   new EFCaller<UltraDbEntity.T_ERP_RoleSet>(new CtlRoleSetController());
            }
        }
    }
}
