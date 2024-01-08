using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBuildingUnitDetail
    {
        public MstBuildingUnitDetail()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public int BuildingUnitDetailId { get; set; }
        public int BuildingDetailId { get; set; }
        public int BuildingUnitClassId { get; set; }
        public int FloorNameId { get; set; }
        public int BuildingUnitUseTypeId { get; set; }
        public bool IsRegularized { get; set; }
        public string FloorNo { get; set; }
        public string FlatNo { get; set; }
        public int NoOfUnit { get; set; }
        public decimal FloorArea { get; set; }
        public int NoOfrooms { get; set; }
        public int TaxPayerId { get; set; }
        public int LandDetailId { get; set; }
        public int UnitOwnerTypeId { get; set; }
        public bool IsMainOwner { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte? TransferStatusId { get; set; }
        public bool? IsActive { get; set; }
        public string CreateG2cApplicationNo { get; set; }
        public string UpdateG2cApplicationNo { get; set; }
        public bool HasIssue { get; set; }
        public string Remarks { get; set; }

        public virtual MstBuildingDetail BuildingDetail { get; set; }
        public virtual MstBuildingUnitClass BuildingUnitClass { get; set; }
        public virtual MstBuildingUnitUseType BuildingUnitUseType { get; set; }
        public virtual MstFloorName FloorName { get; set; }
        public virtual EnumUnitOwnerType UnitOwnerType { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
