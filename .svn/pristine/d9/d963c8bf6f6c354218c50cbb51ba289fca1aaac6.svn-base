using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstSlab
    {
        public MstSlab()
        {
            MstRate = new HashSet<MstRate>();
            TblMiscellaneousRecord = new HashSet<TblMiscellaneousRecord>();
        }

        public int SlabId { get; set; }
        public int TaxId { get; set; }
        public string SlabName { get; set; }
        public int? LandUseSubCategoryId { get; set; }
        public int? Define1 { get; set; }
        public int? Define2 { get; set; }
        public decimal? SlabStart { get; set; }
        public decimal? SlabEnd { get; set; }
        public int? ConstructionTypeId { get; set; }
        public int? BuildingUnitUseTypeId { get; set; }
        public int? BuildingUnitClassId { get; set; }
        public int? WaterLineTypeId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public int? IndustryTypeId { get; set; }
        public int? LeaseActivityTypeId { get; set; }

        public virtual MstBuildingUnitClass BuildingUnitClass { get; set; }
        public virtual MstBuildingUnitUseType BuildingUnitUseType { get; set; }
        public virtual MstConstructionType ConstructionType { get; set; }
        public virtual MstLandUseSubCategory LandUseSubCategory { get; set; }
        public virtual MstTaxMaster Tax { get; set; }
        public virtual MstWaterLineType WaterLineType { get; set; }
        public virtual ICollection<MstRate> MstRate { get; set; }
        public virtual ICollection<TblMiscellaneousRecord> TblMiscellaneousRecord { get; set; }
    }
}
