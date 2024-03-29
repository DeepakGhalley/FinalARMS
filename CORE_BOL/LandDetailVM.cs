﻿using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class LandDetailModel
    {

        public int LandDetailId { get; set; }
        public int? LapId { get; set; }
        public int? DemkhongId { get; set; }
        public int? StreetNameId { get; set; }
        public int? LandTypeId { get; set; }
        public int? LandUseSubCategoryId { get; set; }
        public int LandUseCategoryId { get; set; }
        public string PlotNo { get; set; }
        public decimal LandAcerage { get; set; }
        public decimal LandValue { get; set; }
        public decimal LandPoolingRate { get; set; }
        public bool StructureAvailable { get; set; }
        public string PlotAddress { get; set; }
        public string Location { get; set; }
        public bool IsApproved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long TransactionId { get; set; }
        public bool VacantLandTaxApplicable { get; set; }
        public bool GarbageApplicable { get; set; }
        public bool StreetLightApplicable { get; set; }
        public string StreetName { get; set; }
        public string LapName { get; set; } 
        public string DemkhongName { get; set; }
        public int LandOwnershipId { get; set; }
        public int PropertyTypeId { get; set; }
        public string PropertyType { get; set; }
        public int WaterConnectionId { get; set; }
        public int WaterMeterReadingId { get; set; }
        public string WaterMeterNo { get; set; }
        public bool IsApportioned { get; set; }

        //for Land Lease
        public int LandLeaseId { get; set; }
        public int TaxPayerId { get; set; }
        public string LeaseApprovalNo { get; set; }
        public int BillingScheduleId { get; set; }
        public int LeaseTypeId { get; set; }
        public int LeaseActivityTypeId { get; set; }
        public bool HasShed { get; set; }
        public bool HassecurityDeposit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal LeaseAmount { get; set; }
        public decimal ShedAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }

        //for land period
        public int LandLeasePeriodId { get; set; }

        //for Betterment Charges
        public string CID { get; set; }
        public string TTIN { get; set; }
        public string ThramNo { get; set; }
        public decimal OwnershipPercentage { get; set; }
        public string Name { get; set; }
        public string LandUseCategoryDescription { get; set; }
        public string LandUseSubCategory { get; set; }
        public decimal BuildUpArea { get; set; }
        public int NoOfFloors { get; set; }
        public string ConstructionType { get; set; } 
        public string BuildingNo { get; set; }
        public string BuildingType { get; set; }
        public int NoOfUnits { get; set; }
        public decimal FloorArea { get; set; }
        public string MobileNo { get; set; }
        public int TransactorTypeId { get; set; }
        public int LandTransferTypeId { get; set; }
        public int TrnLandDetailId { get; set; }
        public int BSI { get; set; }
        public string LandOwnershipType { get; set; }
        public decimal PLr { get; set; }
        //public virtual MstDemkhong Demkhong { get; set; }
        //public virtual MstLandType LandType { get; set; }
        //public virtual MstLandUseSubCategory LandUseSubCategory { get; set; }
        //public virtual MstLap Lap { get; set; }
        //public virtual MstStreetName StreetNameType { get; set; }
        //public virtual TblTransactionDetail Transaction { get; set; }
        //public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
        //public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        //public virtual ICollection<TblLandOwnershipDetail> TblLandOwnershipDetail { get; set; }
    }
}
