using CORE_BOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CORE_DLL
{
   public interface ICommonFunction
    {
        #region ENUMSTART
        //***********ASSET_ENUM_START*****************//
        IEnumerable SelectListCalYear();
        IEnumerable SelectListMonths();
        IEnumerable SelectListGender();
        IEnumerable<CommonFunctionModel> SelectListTitle();
        IEnumerable<CommonFunctionModel> SelectListECUseType();
        IEnumerable<CommonFunctionModel> SelectListIndustryType();
        IEnumerable<CommonFunctionModel> SelectListBuildingclass();
        IEnumerable<CommonFunctionModel> SelectListMeterReplacementType();
        IEnumerable<CommonFunctionModel> SelectListOccupancyType();
        IEnumerable<CommonFunctionModel> SelectListPaymentModeType(); 
        IEnumerable<CommonFunctionModel> SelectListStallType(); 
        
        IEnumerable<CommonFunctionModel> SelectListPaymentModeTypeOffLine();
        IEnumerable<CommonFunctionModel> SelectListPaymentModeTypePaymentFailure();
        IEnumerable<CommonFunctionModel> SelectListProjectStatus();
        IEnumerable<CommonFunctionModel> SelectListServiceAccessibilityType();
        IEnumerable<CommonFunctionModel> SelectListStoreyType();
        IEnumerable<CommonFunctionModel> SelectListPropertyType();
        IEnumerable<CommonFunctionModel> SelectListVendorType();
        //***********ASSET_ENUM_END*****************//
        #endregion
        #region REVENUE_ENUM_START
        //***********REVENUE_ENUM_START*****************//  
        IEnumerable<CommonFunctionModel> SelectListTaxByTransactionType(int? TransactionTypeId);
        IEnumerable<CommonFunctionModel> SelectListWorkLevel();
        IEnumerable<CommonFunctionModel> SelectListApprovslStatus();
        IEnumerable<CommonFunctionModel> SelectListBuildingEditReason();
        IEnumerable<CommonFunctionModel> SelectListECAcitvityType();
        IEnumerable<CommonFunctionModel> SelectListFeeType();
        IEnumerable<CommonFunctionModel> SelectListOwnerType();
        IEnumerable<CommonFunctionModel> SelectListWaterBIllEditReason();
        IEnumerable<CommonFunctionModel> SelectListWaterConnectionStatus();
        IEnumerable<CommonFunctionModel> SelectListTaxPayerType();
        IEnumerable<CommonFunctionModel> SelectListLandOwnershipType();


        //***********REVENUE_ENUM_END*****************//
        #endregion

        #region ASSET_MASTER_START

        //***********ASSET_MASTER_START*****************//   
        IEnumerable<CommonFunctionModel> SelectListDivision();
        IEnumerable<CommonFunctionModel> SelectListSection();  
        IEnumerable<CommonFunctionModel> SelectListDesignation();
        IEnumerable<CommonFunctionModel> SelectListPrimaryHead();
        IEnumerable<CommonFunctionModel> SelectListSecondaryHead();
        IEnumerable<CommonFunctionModel> SelectListTertiaryHead();
        IEnumerable<CommonFunctionModel> SelectListLap();
        IEnumerable<CommonFunctionModel> SelectListSupplier();
        IEnumerable<CommonFunctionModel> SelectListModificationReason();
        IEnumerable<CommonFunctionModel> SelectListParentAttribute();
        IEnumerable<CommonFunctionModel> SelectListDisposalType();
        IEnumerable<CommonFunctionModel> SelectListMaintenanceType();
        IEnumerable<CommonFunctionModel> SelectListInspectionType();
        IEnumerable<CommonFunctionModel> SelectListDepreciationType();
        IEnumerable<CommonFunctionModel> SelectListConditionRating();
        IEnumerable<CommonFunctionModel> SelectListAssetFunction();
        IEnumerable<CommonFunctionModel> SelectListMeasurementUnit();
        IEnumerable<CommonFunctionModel> SelectListTransactionType(); IEnumerable<CommonFunctionModel> SelectListTransactionTypeForG2CServices(); 
        IEnumerable<CommonFunctionModel> SelectListMiscellaneousTransactionType();
        List<CommonFunctionModel> SelectListAttributeUnitMap(int AssetAttributeId);
        List<CommonFunctionModel> SelectListApplicantDetails(int ApplicationId);
        IEnumerable<CommonFunctionModel> SelectListPlotWithOwnership(int LandDetailId);


        //***********ASSET_MASTER_END*****************//
        #endregion

        #region REVENUE_MASTER_START

        //***********REVENUE_MASTER_START*****************//
        IEnumerable<CommonFunctionModel> SelectListRole();
        IEnumerable<CommonFunctionModel> SelectListUser();
        IEnumerable<CommonFunctionModel> SelectListMinorHead();
        IEnumerable<CommonFunctionModel> SelectListMajorHead();
        IEnumerable<CommonFunctionModel> SelectListMajorDetailHead();

        IEnumerable<CommonFunctionModel> SelectListZone();
        IEnumerable<CommonFunctionModel> SelectListZoneReader();
        IEnumerable<CommonFunctionModel> SelectListDemkhong();
        IEnumerable<CommonFunctionModel> SelectListFinancialYear();
        IEnumerable<CommonFunctionModel> SelectListTaxMaster();
        IEnumerable<CommonFunctionModel> SelectListTaxMasterTransactionTypeId(int id);
        IEnumerable<CommonFunctionModel> SelectListDetailHead();
        IEnumerable<CommonFunctionModel> SelectListDzongkhag();
        IEnumerable<CommonFunctionModel> SelectListGewog();
        IEnumerable<CommonFunctionModel> SelectListVillage();
        IEnumerable<CommonFunctionModel> SelectListLandType();
        IEnumerable<CommonFunctionModel> SelectListLogoUpload();
        IEnumerable<CommonFunctionModel> SelectListEsSignUpload();
        IEnumerable<CommonFunctionModel> SelectListDcdSignUpload();
        IEnumerable<CommonFunctionModel> SelectListLandUseCategory();
        IEnumerable<CommonFunctionModel> SelectListLandUseSubCategory();
        IEnumerable<CommonFunctionModel> SelectListWaterConnectionType();
        IEnumerable<CommonFunctionModel> SelectListWaterLineType();
        IEnumerable<CommonFunctionModel> SelectListWaterMeterType();
        IEnumerable<CommonFunctionModel> SelectListBank();
        IEnumerable<CommonFunctionModel> SelectListBankBranch();
        IEnumerable<CommonFunctionModel> SelectListBuildingUnitClass();
        IEnumerable<CommonFunctionModel> SelectListTechnicalAttribute();
        IEnumerable<CommonFunctionModel> SelectListDetailTechnicalAttribute();
        IEnumerable<CommonFunctionModel> SelectListAttributeUnitMaps();
        IEnumerable<CommonFunctionModel> SelectListAssetRegister();
        IEnumerable<CommonFunctionModel> SelectListApplicantDetail();
        IEnumerable<CommonFunctionModel> SelectListOccupation();
        IEnumerable<CommonFunctionModel> SelectListCalendarYear();
        IEnumerable<CommonFunctionModel> SelectListSlabFor();
        IEnumerable<CommonFunctionModel> SelectListAssetAttribute();
        //IEnumerable<CommonFunctionModel> SelectListECActivityTypes();
        IEnumerable<CommonFunctionModel> SelectListAssetStatus();
        IEnumerable<CommonFunctionModel> SelectListArea();
        IEnumerable<CommonFunctionModel> SelectListBoundaryType();
        IEnumerable<CommonFunctionModel> SelectListBuildingColour();
        IEnumerable<CommonFunctionModel> SelectListConstructionType();
        IEnumerable<CommonFunctionModel> SelectListLandDetail();
        IEnumerable<CommonFunctionModel> SelectListTaxPayerProfile();
        IEnumerable<CommonFunctionModel> SelectListBillingSchedule();
        IEnumerable<CommonFunctionModel> SelectListLeaseType();
        IEnumerable<CommonFunctionModel> SelectListLeaseActivityType();
        IEnumerable<CommonFunctionModel> SelectListTaxPeriod();

        IEnumerable<CommonFunctionModel> SelectListMaterialType();
        IEnumerable<CommonFunctionModel> SelectListParkingSlot();
        IEnumerable<CommonFunctionModel> SelectListStructureCategory();
        IEnumerable<CommonFunctionModel> SelectListStructureType();
        IEnumerable<CommonFunctionModel> SelectListWaterTankLocation();
        IEnumerable<CommonFunctionModel> SelectListBuildingDetail();
        IEnumerable<CommonFunctionModel> SelectListBuildingUnitUseType();
        IEnumerable<CommonFunctionModel> SelectListFloorName();
        IEnumerable<CommonFunctionModel> SelectListUnitOwnerType();
        IEnumerable<CommonFunctionModel> SelectListStreetName();
        IEnumerable<CommonFunctionModel> SelectListSlab();
        IEnumerable<CommonFunctionModel> SelectListLandServiceType();
      

        IEnumerable<CommonFunctionModel> SelectListTaxTypeClassification();
        IEnumerable<CommonFunctionModel> SelectListRoofingType();



        //***********REVENUE_MASTER_START_END*****************//
        #endregion

        #region ENV_CLEARANCE
        IEnumerable<CommonFunctionModel> SelectListECDetails();
        #endregion
        #region Vendor_ENUM_START
        //***********Vendor_ENUM_START*****************// 

        IEnumerable<CommonFunctionModel> SelectListStallLocations();
        IEnumerable<CommonFunctionModel> SelectListStallAllocations();
        IEnumerable<CommonFunctionModel> SelectListParkingZones();
        IEnumerable<CommonFunctionModel> SelectListStallDetails();
        IEnumerable<CommonFunctionModel> SelectListHouseDetails();

        IEnumerable<CommonFunctionModel> SelectListHouseAllocations();
        IEnumerable<CommonFunctionModel> SelectListRates();




        #endregion
      
        IEnumerable<DemandYearsModel> VendorDemandYears(string StartDate, string EndDate);
        IEnumerable<CommonFunctionModel> SelectListComplainType();
        IEnumerable<CommonFunctionModel> SelectListAssetTransferType();

    }
}
