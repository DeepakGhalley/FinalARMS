using System;
using System.Collections.Generic;
using System.Text;
using CORE_BOL.Entities;

namespace CORE_BOL
{
    public class BuildingUnitDetailsVM
    {
        public int BuildingUnitDetailId { get; set; }
        public int BuildingDetailId { get; set; }
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
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte? TransferStatusId { get; set; }

        public virtual MstBuildingDetail BuildingDetail { get; set; }
        public virtual MstBuildingUnitClass BuildingUnitClass { get; set; }
        public virtual MstBuildingUnitUseType BuildingUnitUseType { get; set; }
        public virtual MstFloorName FloorName { get; set; }
        public virtual EnumUnitOwnerType UnitOwnerType { get; set; }
    }
}
