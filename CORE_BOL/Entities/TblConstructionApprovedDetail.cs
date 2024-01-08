using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblConstructionApprovedDetail
    {
        public int ConstructionApprovedDetailId { get; set; }
        public int LandOwnershipId { get; set; }
        public string G2cApplicationNo { get; set; }
        public decimal ScrutinyFee { get; set; }
        public decimal ServiceFee { get; set; }
        public int WorkLevelId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
        public virtual EnumWorkLevel WorkLevel { get; set; }
    }
}
