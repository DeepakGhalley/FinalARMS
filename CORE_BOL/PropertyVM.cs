using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class PropertyVM
    {
    }
    public partial class BuildingDetailModel
    {
        public bool IsRegularized { get; set; }
        public int BuildingOwnershipId { get; set; }
        public bool IsMainOwner { get; set; }
        public int TaxPayerId { get; set; }
        public int BuildingDetailId { get; set; }

        [Display(Name ="Land detail")]
        public int LandDetailId { get; set; }

        [Display(Name ="Building class id")]
        public int BuildingClassId { get; set; }
        [Display(Name = "Storey Type")]
        public int StoryTypeId { get; set; }
        public string StoryType { get; set; }

        [Display(Name ="Building No")]
        public string BuildingNo { get; set; }
        //public string PlotNo { get; set; }

        [Display(Name = "Buildup Area")]
        public decimal BuildupArea { get; set; }

        [Display(Name = "Plinth Area")]
        public decimal? PlinthArea { get; set; }

        [Display(Name = "No of Units")]
        public int NoOfUnits { get; set; }

        [Display(Name = "No of Floors")]
        public int NumberOfFloors { get; set; }

        [Display(Name = "Garbage Service Accessibility")]
        public int? GarbagServiceAccessibilityId { get; set; }

        [Display(Name = "Street Light Accessibility")]
        public int? StreetLightAccessibilityId { get; set; }

        [Display(Name = "Occupancy Certificate No")]
        public string OccupancyCertificateNo { get; set; }
        
        [Display(Name = "Construction Type")]
        public int ConstructionTypeId { get; set; }

        [Display(Name = "Year of construction")]
        public int? YearOfConstruction { get; set; }

        [Display(Name = "Occupancy Certificate Issued")]
        public bool OccupancyCertificateIssued { get; set; }

        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Occupancy Certificate Issue Date")]
        public DateTime? OccupancyCertificateIssueDate { get; set; }

        [Display(Name = "Payment Completion Status")]
        public bool PaymentCompletionStatusId { get; set; }

        [Display(Name = "Water connection")]
        public bool WaterConnection { get; set; }

        [Display(Name = "Sewerage connection")]
        public bool SewerageConnection { get; set; }

        public bool Attic { get; set; }

        [Display(Name = "Structure Category")]
        public int? StructureCategoryId { get; set; }

        [Display(Name = "Structure Type")]
        public int? StructureTypeId { get; set; }

        [Display(Name = "Material Type")]
        public int? MaterialTypeId { get; set; }
        [Display(Name = "Arch Feature")]
        public bool ArchFeature { get; set; }
        public bool Roofing { get; set; }

        [Display(Name = "Roofing Type")]
        public int? RoofingTypeId { get; set; }

        [Display(Name = "Traditional Painting")]
        public bool TraditionalPainting { get; set; }

        [Display(Name = "Building Colour")]
        public int? BuildingColourId { get; set; }

        [Display(Name = "Boundary Type")]
        public int? BoundaryTypeId { get; set; }
        public bool Plantation { get; set; }

        [Display(Name = "Watertank Location")]
        public int? WaterTankLocationId { get; set; }
        public string WaterTankLocationName { get; set; }

        [Display(Name = "Number Displayed")]
        public bool NumberDisplayed { get; set; }

        [Display(Name = "Parking Slot")]
        public int? ParkingSlotId { get; set; }
        [Display(Name = "Fire Extingusher")]
        public bool FireExtingusher { get; set; }

        [Display(Name = "Water supply accessibility")]
        public int? WaterSupplyAccessibilityId { get; set; }
        public string WaterSupplyAccessibilityType { get; set; }
        [Display(Name = "Road Access")]
        public bool RoadAccess { get; set; }

        [Display(Name = "Drain to storm water drain")]
        public bool DrainToStormWaterDrain { get; set; }

        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of final inspection")]
        public DateTime? DateOfFinalInspection { get; set; }

        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Occupancy altered on")]
        public DateTime? OccupancyAlteredOn { get; set; }

        [Display(Name = "Occupancy altered by")]
        public int? OccupancyAlteredBy { get; set; }

        [Display(Name = "Occupancy reference")]
        public int? OccupancyReferenceId { get; set; }

        [Display(Name = "Advance info fed by")]
        public int? AdvanceInfoFedBy { get; set; }

        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Advance info fed on")]
        public DateTime? AdvanceInfoInfoFedOn { get; set; }
        public string? Remarks { get; set; }
        public string? ModificationRemarks { get; set; }

        [Display(Name = "Modification Reason")]
        public int? ModificationReasonId { get; set; }

        [Display(Name = "Transaction")]
        public int? TransactionId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Plot No")]
        public string plotNo { get; set; }
        public string GarbagServiceAccessibilityType { get; set; }
        public string StreetLightAccessibilityType { get; set; }
        public string ParkingSlotName { get; set; }
        public string WaterTankAllocationName { get; set; }
        public string BoundryTypeName { get; set; }
        public string RoofingTypeName { get; set; }
        public string MaterialTypeName { get; set; }
        public string StructureTypeName { get; set; }
        public string StructureCategoryName { get; set; }
        public string ConstructiTypeName { get; set; }
        public string BuildingcolorName { get; set; }
        public int OwnershipId { get; set; }
        public int BuildingUnitId { get; set; }
        public string BuildingClassName { get; set; }
        public int OCId { get; set; }
        public int SC { get; set; } // SEWERAGE CONNECTION
        public int AT { get; set; } // ATTIC
        public int WC { get; set; } // WATER CONNECTION
        public int AF { get; set; } // ARCH FEATURE
        public int TP { get; set; } // TRADITIONAL PAINTING
        public int PT { get; set; } // PLANTATION
        public int ND { get; set; } // NUMBER DISPLAYED
        public int FE { get; set; } // FIRE EXTINGUSHER
        public int DTSWD { get; set; } // DRAIN TO STORM WATER DRAIN
        public int RA { get; set; } // ROAD ACCESS
        public int RF { get; set; } // ROOFING 
        public int OCI { get; set; } // OCCUPANCY CERTIFICATE ISSUED


        public virtual MstBoundaryType BoundaryType { get; set; }
        public virtual MstBuildingColour BuildingColour { get; set; }
        public virtual MstConstructionType ConstructionType { get; set; }
        public virtual EnumServiceAccessibilityType GarbagServiceAccessibility { get; set; }
        public virtual MstLandDetail LandDetail { get; set; }
        public virtual MstMaterialType MaterialType { get; set; }
        public virtual MstParkingSlot ParkingSlot { get; set; }
        public virtual MstRoofingType RoofingType { get; set; }
        public virtual EnumServiceAccessibilityType StreetLightAccessibility { get; set; }
        public virtual MstStructureCategory StructureCategory { get; set; }
        public virtual MstStructureType StructureType { get; set; }
        public virtual EnumServiceAccessibilityType WaterSupplyAccessibility { get; set; }
        public virtual EnumWaterTankLocation WaterTankLocation { get; set; }
        public virtual ICollection<MstBuildingUnitDetail> MstBuildingUnitDetail { get; set; }
    }
    public partial class BuildingUnitDetailModel
    {
        public int BuildingUnitDetailId { get; set; }
        [Display(Name = "Building Detail")]
        public int BuildingDetailId { get; set; }
        [Display(Name = "Building Unit Class")]
        public int BuildingUnitClassId { get; set; }
        [Display(Name = "Floor Name")]
        public int FloorNameId { get; set; }
        [Display(Name = "Building Unit Use Type")]
        public int BuildingUnitUseTypeId { get; set; }
        [Display(Name = "Floor No")]
        public string FloorNo { get; set; }
        [Display(Name = "No of Unit")]
        public int NoOfUnit { get; set; }
        [Display(Name = "Floor Area")]
        public decimal FloorArea { get; set; }
        [Display(Name = "No of Rooms")]
        public int NoOfrooms { get; set; }
        [Display(Name = "Tax Payer")]
        public int TaxPayerId { get; set; }
        [Display(Name = "Unit Owner Type")]
        public int UnitOwnerTypeId { get; set; }
        [Display(Name = "Is Main Owner")]
        public bool IsMainOwner { get; set; }
        public int IsMOwner { get; set; }
        public int IsR { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Transfer Status")]
        public byte? TransferStatusId { get; set; }
        [Display(Name = "Building No")]
        public string BuildingNo { get; set; }
        public string BuildingUnitClassName { get; set; }
        public string BuildingUnitUseTypeName { get; set; }
        public string Floor { get; set; }
        public string UnitOwnerTypename { get; set; }
        public int BuildUpArea { get; set; }
        public int NoofFloors { get; set; }
        public int PlinthArea { get; set; }
        public string MainOwner { get; set; }
        public string Cid { get; set; }
        public string Ttin { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        [Display(Name = "Plot No")]
        public string PlotNo { get; set; }
        public string TaxPayerName { get; set; }
        [Display(Name = "Flat No")]
        public string FlatNo { get; set; }
        [Display(Name = "Is Regularized")]
        public bool IsRegularized { get; set; }
        public string Regularized { get; set; }
        [Display(Name = "Plot No")]
        public int LandDetailId { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public decimal Plr { get; set; }
        public string ConstructionType{ get; set; }
        public int LandOwnershipId { get; set; }
        public string BUID { get; set; }
        public virtual MstBuildingDetail BuildingDetail { get; set; }
        public virtual MstBuildingUnitClass BuildingUnitClass { get; set; }
        public virtual MstBuildingUnitUseType BuildingUnitUseType { get; set; }
        public virtual MstFloorName FloorName { get; set; }
        public virtual EnumUnitOwnerType UnitOwnerType { get; set; }
    }

}
