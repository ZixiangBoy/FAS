using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.CoreCaller;
using Ultra.FASControls.Controllers;

namespace Ultra.FASControls
{
    public partial class SerNoCaller
    {
        protected static EFCaller<UltraDbEntity.T_ERP_SerNo> _ins = null;
        public static EFCaller<UltraDbEntity.T_ERP_SerNo> Instance
        {
            get
            {
                return _ins = (_ins == null) ? new EFCaller<UltraDbEntity.T_ERP_SerNo>(
                    new CtlSerNoController()) : _ins;
            }
        }

        public static UltraDbEntity.T_ERP_SerNo GetSerNo(string dep)
        {
            var et = Instance.GetByProc("exec P_ERP_GetSerialNo @0", dep)
                .FirstOrDefault();
            return et;
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

        //CtlIvtAdjController
        protected static EFCaller<UltraDbEntity.T_ERP_IvtAdj> _Calr_IvtAdj = null;
        public static EFCaller<UltraDbEntity.T_ERP_IvtAdj> Calr_IvtAdj
        {
            get
            {
                return
                    _Calr_IvtAdj = _Calr_IvtAdj ??
                   new EFCaller<UltraDbEntity.T_ERP_IvtAdj>(new CtlIvtAdjController());
            }
        }
        //CtlInventoryController
        protected static EFCaller<UltraDbEntity.T_ERP_Inventory> _Calr_Inventory = null;
        public static EFCaller<UltraDbEntity.T_ERP_Inventory> Calr_Inventory
        {
            get
            {
                return
                    _Calr_Inventory = _Calr_Inventory ??
                   new EFCaller<UltraDbEntity.T_ERP_Inventory>(new CtlInventoryController());
            }
        }
        //CtlIvtCheckMasterController
        protected static EFCaller<UltraDbEntity.T_ERP_IvtCheckMaster> _Calr_IvtCheckMaster = null;
        public static EFCaller<UltraDbEntity.T_ERP_IvtCheckMaster> Calr_IvtCheckMaster
        {
            get
            {
                return
                    _Calr_IvtCheckMaster = _Calr_IvtCheckMaster ??
                   new EFCaller<UltraDbEntity.T_ERP_IvtCheckMaster>(new CtlIvtCheckMasterController());
            }
        }
        //CtlIvtCheckDetailController
        protected static EFCaller<UltraDbEntity.T_ERP_IvtCheckDetail> _Calr_IvtCheckDetail = null;
        public static EFCaller<UltraDbEntity.T_ERP_IvtCheckDetail> Calr_IvtCheckDetail
        {
            get
            {
                return
                    _Calr_IvtCheckDetail = _Calr_IvtCheckDetail ??
                   new EFCaller<UltraDbEntity.T_ERP_IvtCheckDetail>(new CtlIvtCheckDetailController());
            }
        }
        //CtlWareHouseController
        protected static EFCaller<UltraDbEntity.T_ERP_WareHouse> _Calr_WareHouse = null;
        public static EFCaller<UltraDbEntity.T_ERP_WareHouse> Calr_WareHouse
        {
            get
            {
                return
                    _Calr_WareHouse = _Calr_WareHouse ??
                   new EFCaller<UltraDbEntity.T_ERP_WareHouse>(new CtlWareHouseController());
            }
        }
        //CtlInStockController
        protected static EFCaller<UltraDbEntity.T_ERP_InStock> _Calr_InStock = null;
        public static EFCaller<UltraDbEntity.T_ERP_InStock> Calr_InStock
        {
            get
            {
                return
                    _Calr_InStock = _Calr_InStock ??
                   new EFCaller<UltraDbEntity.T_ERP_InStock>(new CtlInStockController());
            }
        }


        //CtlInStockItemController
        protected static EFCaller<UltraDbEntity.T_ERP_InStockItem> _Calr_InStockItem = null;
        public static EFCaller<UltraDbEntity.T_ERP_InStockItem> Calr_InStockItem
        {
            get
            {
                return
                    _Calr_InStockItem = _Calr_InStockItem ??
                   new EFCaller<UltraDbEntity.T_ERP_InStockItem>(new CtlInStockItemController());
            }
        }

        //CtlPackInStockController
        protected static EFCaller<UltraDbEntity.T_ERP_PackInStock> _Calr_PackInStock = null;
        public static EFCaller<UltraDbEntity.T_ERP_PackInStock> Calr_PackInStock
        {
            get
            {
                return
                    _Calr_PackInStock = _Calr_PackInStock ??
                   new EFCaller<UltraDbEntity.T_ERP_PackInStock>(new CtlPackInStockController());
            }
        }


        //CtlWareLocController
        protected static EFCaller<UltraDbEntity.T_ERP_WareLoc> _Calr_WareLoc = null;
        public static EFCaller<UltraDbEntity.T_ERP_WareLoc> Calr_WareLoc
        {
            get
            {
                return
                    _Calr_WareLoc = _Calr_WareLoc ??
                   new EFCaller<UltraDbEntity.T_ERP_WareLoc>(new CtlWareLocController());
            }
        }


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

        //CtlLogController
        protected static EFCaller<UltraDbEntity.T_ERP_Log> _Calr_Log = null;
        public static EFCaller<UltraDbEntity.T_ERP_Log> Calr_Log
        {
            get
            {
                return
                    _Calr_Log = _Calr_Log ??
                   new EFCaller<UltraDbEntity.T_ERP_Log>(new CtlLogController());
            }
        }
    }
}
