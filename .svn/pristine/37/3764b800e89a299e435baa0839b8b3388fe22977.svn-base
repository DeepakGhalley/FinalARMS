using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBuildingDetail
    {
        public MstBuildingDetail()
        {
            MstBuildingUnitDetail = new HashSet<MstBuildingUnitDetail>();
            TblBuildingOwnership = new HashSet<TblBuildingOwnership>();
            TrnOccupancyCertificateApplication = new HashSet<TrnOccupancyCertificateApplication>();
        }

        public int BuildingDetailId { get; set; }
        public int LandDetailId { get; set; }
        public int BuildingClassId { get; set; }
        public int StoryTypeId { get; set; }
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
        public string CreateG2cApplicationNo { get; set; }
        public string UpdateG2cApplicationNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstBoundaryType BoundaryType { get; set; }
        public virtual MstBuildingColour BuildingColour { get; set; }
        public virtual MstConstructionType ConstructionType { get; set; }
        public virtual EnumServiceAccessibilityType GarbagServiceAccessibility { get; set; }
        public virtual MstLandDetail LandDetail { get; set; }
        public virtual MstMaterialType MaterialType { get; set; }
        public virtual MstParkingSlot ParkingSlot { get; set; }
        public virtual MstRoofingType RoofingType { get; set; }
        public virtual EnumStoryType StoryType { get; set; }
        public virtual EnumServiceAccessibilityType StreetLightAccessibility { get; set; }
        public virtual MstStructureCategory StructureCategory { get; set; }
        public virtual MstStructureType StructureType { get; set; }
        public virtual EnumServiceAccessibilityType WaterSupplyAccessibility { get; set; }
        public virtual EnumWaterTankLocation WaterTankLocation { get; set; }
        public virtual ICollection<MstBuildingUnitDetail> MstBuildingUnitDetail { get; set; }
        public virtual ICollection<TblBuildingOwnership> TblBuildingOwnership { get; set; }
        public virtual ICollection<TrnOccupancyCertificateApplication> TrnOccupancyCertificateApplication { get; set; }
    }
}
