using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class BuildingDetailVM
    {
        public int BuildingDetailId { get; set; }
        public int LandDetailId { get; set; }
        public int BuildingClassId { get; set; }
        public string BuildingNo { get; set; }
        public string storyType { get; set; }
        public decimal BuildupArea { get; set; }
        public decimal? PlinthArea { get; set; }
        public int NoOfUnits { get; set; }
        public int NumberOfFloors { get; set; }
        public int? YearOfConstruction { get; set; }
        public bool? WaterConnection { get; set; }
        public bool? SewerageConnection { get; set; }
        public bool? Attic { get; set; }
        public bool? RoadAccess { get; set; }
        public string BuildingColorType { get; set; }
        public int BuildingUnitDetailId { get; set; }
        public string ThramNo { get; set; }
        public string TTIN { get; set; }
        public string TaxPayerName { get; set; }


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
}
