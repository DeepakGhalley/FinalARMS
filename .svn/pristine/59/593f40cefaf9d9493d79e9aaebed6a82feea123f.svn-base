using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblBuildingOwnership
    {
        public int BuildingOwnershipId { get; set; }
        public int LandOwnershipId { get; set; }
        public int BuildingDetailId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }

        public virtual MstBuildingDetail BuildingDetail { get; set; }
        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
    }
}
