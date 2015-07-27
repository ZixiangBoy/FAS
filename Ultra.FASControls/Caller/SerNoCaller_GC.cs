using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.CoreCaller;
using Ultra.FASControls.Controllers;

namespace Ultra.FASControls.Caller
{
    public partial class SerNoCaller_GC
    {
        //CtlInStockMatMasterController
        protected static EFCaller<UltraDbEntity.T_ERP_InStockMatMaster> _Calr_InStockMatMaster = null;
        public static EFCaller<UltraDbEntity.T_ERP_InStockMatMaster> Calr_InStockMatMaster
        {
            get
            {
                return
                    _Calr_InStockMatMaster = _Calr_InStockMatMaster ??
                   new EFCaller<UltraDbEntity.T_ERP_InStockMatMaster>(new CtlInStockMatMasterController());
            }
        }


        //CtlInStockMaterialController
        protected static EFCaller<UltraDbEntity.T_ERP_InStockMaterial> _Calr_InStockMaterial = null;
        public static EFCaller<UltraDbEntity.T_ERP_InStockMaterial> Calr_InStockMaterial
        {
            get
            {
                return
                    _Calr_InStockMaterial = _Calr_InStockMaterial ??
                   new EFCaller<UltraDbEntity.T_ERP_InStockMaterial>(new CtlInStockMaterialController());
            }
        }


        //CtlMaterialIvtAdjController
        protected static EFCaller<UltraDbEntity.T_ERP_MaterialIvtAdj> _Calr_MaterialIvtAdj = null;
        public static EFCaller<UltraDbEntity.T_ERP_MaterialIvtAdj> Calr_MaterialIvtAdj
        {
            get
            {
                return
                    _Calr_MaterialIvtAdj = _Calr_MaterialIvtAdj ??
                   new EFCaller<UltraDbEntity.T_ERP_MaterialIvtAdj>(new CtlMaterialIvtAdjController());
            }
        }


        //CtlMaterialCheckMasterController
        protected static EFCaller<UltraDbEntity.T_ERP_MaterialCheckMaster> _Calr_MaterialCheckMaster = null;
        public static EFCaller<UltraDbEntity.T_ERP_MaterialCheckMaster> Calr_MaterialCheckMaster
        {
            get
            {
                return
                    _Calr_MaterialCheckMaster = _Calr_MaterialCheckMaster ??
                   new EFCaller<UltraDbEntity.T_ERP_MaterialCheckMaster>(new CtlMaterialCheckMasterController());
            }
        }


        //CtlMaterialCheckDetailController
        protected static EFCaller<UltraDbEntity.T_ERP_MaterialCheckDetail> _Calr_MaterialCheckDetail = null;
        public static EFCaller<UltraDbEntity.T_ERP_MaterialCheckDetail> Calr_MaterialCheckDetail
        {
            get
            {
                return
                    _Calr_MaterialCheckDetail = _Calr_MaterialCheckDetail ??
                   new EFCaller<UltraDbEntity.T_ERP_MaterialCheckDetail>(new CtlMaterialCheckDetailController());
            }
        }


        //CtlMaterialCheckResultController
        protected static EFCaller<UltraDbEntity.T_ERP_MaterialCheckResult> _Calr_MaterialCheckResult = null;
        public static EFCaller<UltraDbEntity.T_ERP_MaterialCheckResult> Calr_MaterialCheckResult
        {
            get
            {
                return
                    _Calr_MaterialCheckResult = _Calr_MaterialCheckResult ??
                   new EFCaller<UltraDbEntity.T_ERP_MaterialCheckResult>(new CtlMaterialCheckResultController());
            }
        }


        //CtlFinNameController
        protected static EFCaller<UltraDbEntity.T_ERP_FinName> _Calr_FinName = null;
        public static EFCaller<UltraDbEntity.T_ERP_FinName> Calr_FinName
        {
            get
            {
                return
                    _Calr_FinName = _Calr_FinName ??
                   new EFCaller<UltraDbEntity.T_ERP_FinName>(new CtlFinNameController());
            }
        }


        //CtlFinRecController
        protected static EFCaller<UltraDbEntity.T_ERP_FinRec> _Calr_FinRec = null;
        public static EFCaller<UltraDbEntity.T_ERP_FinRec> Calr_FinRec
        {
            get
            {
                return
                    _Calr_FinRec = _Calr_FinRec ??
                   new EFCaller<UltraDbEntity.T_ERP_FinRec>(new CtlFinRecController());
            }
        }


        //CtlV_ERP_GetAmountByMonthController
        protected static EFCaller<UltraDbEntity.V_ERP_GetAmountByMonth> _Calr_V_ERP_GetAmountByMonth = null;
        public static EFCaller<UltraDbEntity.V_ERP_GetAmountByMonth> Calr_V_ERP_GetAmountByMonth
        {
            get
            {
                return
                    _Calr_V_ERP_GetAmountByMonth = _Calr_V_ERP_GetAmountByMonth ??
                   new EFCaller<UltraDbEntity.V_ERP_GetAmountByMonth>(new CtlV_ERP_GetAmountByMonthController());
            }
        }
    }
}
