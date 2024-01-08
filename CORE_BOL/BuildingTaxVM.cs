﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
   public class BuildingTaxVM
    {
        public int BuildingDetailId { get; set; }
        public int LandDetailId { get; set; }
        public int LandOwnerShipId { get; set; }
        public int BuildingClassId { get; set; }
        public string BuildingNo { get; set; }
        public decimal BuildupArea { get; set; }
        public decimal? PlinthArea { get; set; }
        public int NoOfUnits { get; set; }
        public int NumberOfFloors { get; set; }
        public int? GarbagServiceAccessibilityId { get; set; }
        public int? StreetLightAccessibilityId { get; set; }
        public string OccupancyCertificateNo { get; set; }
        public int ConstructionTypeId { get; set; }
        public string ConstructionType { get; set; }
        public int? YearOfConstruction { get; set; }
        public bool? OccupancyCertificateIssued { get; set; }
        public DateTime? OccupancyCertificateIssueDate { get; set; }
        public bool? PaymentCompletionStatusId { get; set; }
        public bool? WaterConnection { get; set; }
        public bool? SewerageConnection { get; set; }
        public bool? Attic { get; set; }
        public int? StructureCategoryId { get; set; }
        public int? StructureTypeId { get; set; }
        public int? MaterialTypeId { get; set; }
        public bool? ArchFeature { get; set; }
        public bool? Roofing { get; set; }
        public int? RoofingTypeId { get; set; }
        public bool? TraditionalPainting { get; set; }
        public int? BuildingColourId { get; set; }
        public int? BoundaryTypeId { get; set; }
        public bool? Plantation { get; set; }
        public int? WaterTankLocationId { get; set; }
        public bool? NumberDisplayed { get; set; }
        public int? ParkingSlotId { get; set; }
        public bool? FireExtingusher { get; set; }
        public int? WaterSupplyAccessibilityId { get; set; }
        public bool? RoadAccess { get; set; }
        public bool? DrainToStormWaterDrain { get; set; }
        public DateTime? DateOfFinalInspection { get; set; }
        public DateTime? OccupancyAlteredOn { get; set; }
        public int? OccupancyAlteredBy { get; set; }
        public int? OccupancyReferenceId { get; set; }
        public int? AdvanceInfoFedBy { get; set; }
        public DateTime? AdvanceInfoInfoFedOn { get; set; }
        public string Remarks { get; set; }
        public string ModificationRemarks { get; set; }
        public int? ModificationReasonId { get; set; }
        public int? TransactionId { get; set; }
        public int BuildingUnitDetailId { get; set; }
        //public int BuildingDetailId { get; set; }
        public int BuildingUnitClassId { get; set; }
        public string BuildingUnitClass { get; set; }

        public int FloorNameId { get; set; }
        public int BuildingUnitUseTypeId { get; set; }
        public string BuildingUnitUseType { get; set; }

        public string FloorNo { get; set; }
        public int? NoOfUnit { get; set; }
        public decimal FloorArea { get; set; }
        public int NoOfrooms { get; set; }
        public int? TaxPayerId { get; set; }
        public int UnitOwnerTypeId { get; set; }
        public bool IsMainOwner { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int UnitTaxId { get; set; }
        public int SlabId { get; set; }
        public int SlabIdGarbage { get; set; }
     
        public int SlabIdStreetLight { get; set; }
        public decimal UnitTax { get; set; } 
        public decimal UnitTaxRate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public int GarbageTaxId { get; set; }
        public decimal GarbageTaxRate { get; set; }
        public decimal GarbageTax { get; set; }
        public decimal Garbage { get; set; }
        public decimal StreetLightTaxRate { get; set; }
        public int StreetLightTaxId { get; set; }
        public decimal StreetLightTax { get; set; }
    }
    public class BuildingTaxModel
    {
        public int BuildingDetailId { get; set; }
        public int LandDetailId { get; set; }
        public int BuildingClassId { get; set; }
        public string BuildingNo { get; set; }
        public decimal BuildupArea { get; set; }
        public decimal? PlinthArea { get; set; }
        public int NoOfUnits { get; set; }
        public int NumberOfFloors { get; set; }
        public int? GarbagServiceAccessibilityId { get; set; }
        public int? StreetLightAccessibilityId { get; set; }
        public string OccupancyCertificateNo { get; set; }
        public int ConstructionTypeId { get; set; }
        public int? YearOfConstruction { get; set; }
        public bool? OccupancyCertificateIssued { get; set; }
        public DateTime? OccupancyCertificateIssueDate { get; set; }
        public bool? PaymentCompletionStatusId { get; set; }
        public bool? WaterConnection { get; set; }
        public bool? SewerageConnection { get; set; }
        public bool? Attic { get; set; }
        public int? StructureCategoryId { get; set; }
        public int? StructureTypeId { get; set; }
        public int? MaterialTypeId { get; set; }
        public bool? ArchFeature { get; set; }
        public bool? Roofing { get; set; }
        public int? RoofingTypeId { get; set; }
        public bool? TraditionalPainting { get; set; }
        public int? BuildingColourId { get; set; }
        public int? BoundaryTypeId { get; set; }
        public bool? Plantation { get; set; }
        public int? WaterTankLocationId { get; set; }
        public bool? NumberDisplayed { get; set; }
        public int? ParkingSlotId { get; set; }
        public bool? FireExtingusher { get; set; }
        public int? WaterSupplyAccessibilityId { get; set; }
        public bool? RoadAccess { get; set; }
        public bool? DrainToStormWaterDrain { get; set; }
        public DateTime? DateOfFinalInspection { get; set; }
        public DateTime? OccupancyAlteredOn { get; set; }
        public int? OccupancyAlteredBy { get; set; }
        public int? OccupancyReferenceId { get; set; }
        public int? AdvanceInfoFedBy { get; set; }
        public DateTime? AdvanceInfoInfoFedOn { get; set; }
        public string Remarks { get; set; }
        public string ModificationRemarks { get; set; }
        public int? ModificationReasonId { get; set; }
        public int? TransactionId { get; set; }
        public int BuildingUnitDetailId { get; set; }
        //public int BuildingDetailId { get; set; }
        public int BuildingUnitClassId { get; set; }
        public int FloorNameId { get; set; }
        public int BuildingUnitUseTypeId { get; set; }
        public string FloorNo { get; set; }
        public int? NoOfUnit { get; set; }
        public decimal FloorArea { get; set; }
        public int NoOfrooms { get; set; }
        public int? TaxPayerId { get; set; }
        public int UnitOwnerTypeId { get; set; }
        public bool IsMainOwner { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
