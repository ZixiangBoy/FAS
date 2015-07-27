using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.CoreCaller;
using Ultra.FASControls.Controllers;

namespace Ultra.FASControls
{
    public partial class SerNoCaller_WL
    {
        //CtlItemController
        protected static EFCaller<UltraDbEntity.T_ERP_Item> _Calr_Item = null;
        public static EFCaller<UltraDbEntity.T_ERP_Item> Calr_Item
        {
            get
            {
                return
                    _Calr_Item = _Calr_Item ??
                   new EFCaller<UltraDbEntity.T_ERP_Item>(new CtlItemController());
            }
        }

        //CtlItemComboController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemCombo> _Calr_ItemCombo = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemCombo> Calr_ItemCombo
        {
            get
            {
                return
                    _Calr_ItemCombo = _Calr_ItemCombo ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemCombo>(new CtlItemComboController());
            }
        }

        //CtlItemImports_FullBakController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemImports_FullBak> _Calr_ItemImports_FullBak = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemImports_FullBak> Calr_ItemImports_FullBak
        {
            get
            {
                return
                    _Calr_ItemImports_FullBak = _Calr_ItemImports_FullBak ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemImports_FullBak>(new CtlItemImports_FullBakController());
            }
        }

        //CtlItemPackSkuController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemPackSku> _Calr_ItemPackSku = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemPackSku> Calr_ItemPackSku
        {
            get
            {
                return
                    _Calr_ItemPackSku = _Calr_ItemPackSku ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemPackSku>(new CtlItemPackSkuController());
            }
        }

        //CtlItemStyleController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemStyle> _Calr_ItemStyle = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemStyle> Calr_ItemStyle
        {
            get
            {
                return
                    _Calr_ItemStyle = _Calr_ItemStyle ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemStyle>(new CtlItemStyleController());
            }
        }

        //CtlItemImportsController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemImports> _Calr_ItemImports = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemImports> Calr_ItemImports
        {
            get
            {
                return
                    _Calr_ItemImports = _Calr_ItemImports ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemImports>(new CtlItemImportsController());
            }
        }

        //CtlWareAreaController
        protected static EFCaller<UltraDbEntity.T_ERP_WareArea> _Calr_WareArea = null;
        public static EFCaller<UltraDbEntity.T_ERP_WareArea> Calr_WareArea
        {
            get
            {
                return
                    _Calr_WareArea = _Calr_WareArea ??
                   new EFCaller<UltraDbEntity.T_ERP_WareArea>(new CtlWareAreaController());
            }
        }

        //CtlV_ERP_InventCollectController
        protected static EFCaller<UltraDbEntity.V_ERP_InventCollect> _Calr_V_ERP_InventCollect = null;
        public static EFCaller<UltraDbEntity.V_ERP_InventCollect> Calr_V_ERP_InventCollect
        {
            get
            {
                return
                    _Calr_V_ERP_InventCollect = _Calr_V_ERP_InventCollect ??
                   new EFCaller<UltraDbEntity.V_ERP_InventCollect>(new CtlV_ERP_InventCollectController());
            }
        }

        //CtlWreckPriceController
        protected static EFCaller<UltraDbEntity.T_ERP_WreckPrice> _Calr_WreckPrice = null;
        public static EFCaller<UltraDbEntity.T_ERP_WreckPrice> Calr_WreckPrice
        {
            get
            {
                return
                    _Calr_WreckPrice = _Calr_WreckPrice ??
                   new EFCaller<UltraDbEntity.T_ERP_WreckPrice>(new CtlWreckPriceController());
            }
        }

        //CtlWreckTypeController
        protected static EFCaller<UltraDbEntity.T_ERP_WreckType> _Calr_WreckType = null;
        public static EFCaller<UltraDbEntity.T_ERP_WreckType> Calr_WreckType
        {
            get
            {
                return
                    _Calr_WreckType = _Calr_WreckType ??
                   new EFCaller<UltraDbEntity.T_ERP_WreckType>(new CtlWreckTypeController());
            }
        }

        //CtlWorkerController
        protected static EFCaller<UltraDbEntity.T_ERP_Worker> _Calr_Worker = null;
        public static EFCaller<UltraDbEntity.T_ERP_Worker> Calr_Worker
        {
            get
            {
                return
                    _Calr_Worker = _Calr_Worker ??
                   new EFCaller<UltraDbEntity.T_ERP_Worker>(new CtlWorkerController());
            }
        }

        //CtlDeliveryController
        protected static EFCaller<UltraDbEntity.T_ERP_Delivery> _Calr_Delivery = null;
        public static EFCaller<UltraDbEntity.T_ERP_Delivery> Calr_Delivery
        {
            get
            {
                return
                    _Calr_Delivery = _Calr_Delivery ??
                   new EFCaller<UltraDbEntity.T_ERP_Delivery>(new CtlDeliveryController());
            }
        }

        //CtlDeliveryItemController
        protected static EFCaller<UltraDbEntity.T_ERP_DeliveryItem> _Calr_DeliveryItem = null;
        public static EFCaller<UltraDbEntity.T_ERP_DeliveryItem> Calr_DeliveryItem
        {
            get
            {
                return
                    _Calr_DeliveryItem = _Calr_DeliveryItem ??
                   new EFCaller<UltraDbEntity.T_ERP_DeliveryItem>(new CtlDeliveryItemController());
            }
        }

        //CtlDeliveryAddrController
        protected static EFCaller<UltraDbEntity.T_ERP_DeliveryAddr> _Calr_DeliveryAddr = null;
        public static EFCaller<UltraDbEntity.T_ERP_DeliveryAddr> Calr_DeliveryAddr
        {
            get
            {
                return
                    _Calr_DeliveryAddr = _Calr_DeliveryAddr ??
                   new EFCaller<UltraDbEntity.T_ERP_DeliveryAddr>(new CtlDeliveryAddrController());
            }
        }

        //CtlProduceDosageController
        protected static EFCaller<UltraDbEntity.T_ERP_ProduceDosage> _Calr_ProduceDosage = null;
        public static EFCaller<UltraDbEntity.T_ERP_ProduceDosage> Calr_ProduceDosage
        {
            get
            {
                return
                    _Calr_ProduceDosage = _Calr_ProduceDosage ??
                   new EFCaller<UltraDbEntity.T_ERP_ProduceDosage>(new CtlProduceDosageController());
            }
        }

        //CtlProduceDosageIptController
        protected static EFCaller<UltraDbEntity.T_ERP_ProduceDosageIpt> _Calr_ProduceDosageIpt = null;
        public static EFCaller<UltraDbEntity.T_ERP_ProduceDosageIpt> Calr_ProduceDosageIpt
        {
            get
            {
                return
                    _Calr_ProduceDosageIpt = _Calr_ProduceDosageIpt ??
                   new EFCaller<UltraDbEntity.T_ERP_ProduceDosageIpt>(new CtlProduceDosageIptController());
            }
        }

        //CtlRoleController
        protected static EFCaller<UltraDbEntity.T_ERP_Role> _Calr_Role = null;
        public static EFCaller<UltraDbEntity.T_ERP_Role> Calr_Role
        {
            get
            {
                return
                    _Calr_Role = _Calr_Role ??
                   new EFCaller<UltraDbEntity.T_ERP_Role>(new CtlRoleController());
            }
        }

        //CtlAfterSaleController
        protected static EFCaller<UltraDbEntity.T_ERP_AfterSale> _Calr_AfterSale = null;
        public static EFCaller<UltraDbEntity.T_ERP_AfterSale> Calr_AfterSale
        {
            get
            {
                return
                    _Calr_AfterSale = _Calr_AfterSale ??
                   new EFCaller<UltraDbEntity.T_ERP_AfterSale>(new CtlAfterSaleController());
            }
        }

        //CtlAfterSalaItemController
        protected static EFCaller<UltraDbEntity.T_ERP_AfterSalaItem> _Calr_AfterSalaItem = null;
        public static EFCaller<UltraDbEntity.T_ERP_AfterSalaItem> Calr_AfterSalaItem
        {
            get
            {
                return
                    _Calr_AfterSalaItem = _Calr_AfterSalaItem ??
                   new EFCaller<UltraDbEntity.T_ERP_AfterSalaItem>(new CtlAfterSalaItemController());
            }
        }

        //CtlExpensesController
        protected static EFCaller<UltraDbEntity.T_ERP_Expenses> _Calr_Expenses = null;
        public static EFCaller<UltraDbEntity.T_ERP_Expenses> Calr_Expenses
        {
            get
            {
                return
                    _Calr_Expenses = _Calr_Expenses ??
                   new EFCaller<UltraDbEntity.T_ERP_Expenses>(new CtlExpensesController());
            }
        }

        //CtlExpensesTypeController
        protected static EFCaller<UltraDbEntity.T_ERP_ExpensesType> _Calr_ExpensesType = null;
        public static EFCaller<UltraDbEntity.T_ERP_ExpensesType> Calr_ExpensesType
        {
            get
            {
                return
                    _Calr_ExpensesType = _Calr_ExpensesType ??
                   new EFCaller<UltraDbEntity.T_ERP_ExpensesType>(new CtlExpensesTypeController());
            }
        }

        //CtlImageController
        protected static EFCaller<UltraDbEntity.T_ERP_Image> _Calr_Image = null;
        public static EFCaller<UltraDbEntity.T_ERP_Image> Calr_Image
        {
            get
            {
                return
                    _Calr_Image = _Calr_Image ??
                   new EFCaller<UltraDbEntity.T_ERP_Image>(new CtlImageController());
            }
        }

        //CtlV_ERP_InventSelectController
        protected static EFCaller<UltraDbEntity.V_ERP_InventSelect> _Calr_V_ERP_InventSelect = null;
        public static EFCaller<UltraDbEntity.V_ERP_InventSelect> Calr_V_ERP_InventSelect
        {
            get
            {
                return
                    _Calr_V_ERP_InventSelect = _Calr_V_ERP_InventSelect ??
                   new EFCaller<UltraDbEntity.V_ERP_InventSelect>(new CtlV_ERP_InventSelectController());
            }
        }

        //CtlResponsibleController
        protected static EFCaller<UltraDbEntity.T_ERP_Responsible> _Calr_Responsible = null;
        public static EFCaller<UltraDbEntity.T_ERP_Responsible> Calr_Responsible
        {
            get
            {
                return
                    _Calr_Responsible = _Calr_Responsible ??
                   new EFCaller<UltraDbEntity.T_ERP_Responsible>(new CtlResponsibleController());
            }
        }

        //CtlMaterialIvtRetController
        protected static EFCaller<UltraDbEntity.T_ERP_MaterialIvtRet> _Calr_MaterialIvtRet = null;
        public static EFCaller<UltraDbEntity.T_ERP_MaterialIvtRet> Calr_MaterialIvtRet
        {
            get
            {
                return
                    _Calr_MaterialIvtRet = _Calr_MaterialIvtRet ??
                   new EFCaller<UltraDbEntity.T_ERP_MaterialIvtRet>(new CtlMaterialIvtRetController());
            }
        }

        //CtlV_ERP_DeliveryOrderController
        protected static EFCaller<UltraDbEntity.V_ERP_DeliveryOrder> _Calr_V_ERP_DeliveryOrder = null;
        public static EFCaller<UltraDbEntity.V_ERP_DeliveryOrder> Calr_V_ERP_DeliveryOrder
        {
            get
            {
                return
                    _Calr_V_ERP_DeliveryOrder = _Calr_V_ERP_DeliveryOrder ??
                   new EFCaller<UltraDbEntity.V_ERP_DeliveryOrder>(new CtlV_ERP_DeliveryOrderController());
            }
        }

        //CtlPostFeeTypeController
        protected static EFCaller<UltraDbEntity.T_ERP_PostFeeType> _Calr_PostFeeType = null;
        public static EFCaller<UltraDbEntity.T_ERP_PostFeeType> Calr_PostFeeType
        {
            get
            {
                return
                    _Calr_PostFeeType = _Calr_PostFeeType ??
                   new EFCaller<UltraDbEntity.T_ERP_PostFeeType>(new CtlPostFeeTypeController());
            }
        }

        //CtlItemResponsibleController
        protected static EFCaller<UltraDbEntity.T_ERP_ItemResponsible> _Calr_ItemResponsible = null;
        public static EFCaller<UltraDbEntity.T_ERP_ItemResponsible> Calr_ItemResponsible
        {
            get
            {
                return
                    _Calr_ItemResponsible = _Calr_ItemResponsible ??
                   new EFCaller<UltraDbEntity.T_ERP_ItemResponsible>(new CtlItemResponsibleController());
            }
        }
    }
}
