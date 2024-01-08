using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TrnLandFeeDetail
    {
        public int LandFeeDetailId { get; set; }
        public int LandOwnershipId { get; set; }
        public int LandServiceTypeId { get; set; }
        public long TransactionId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Amount { get; set; }

        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
        public virtual MstLandServiceType LandServiceType { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
    }
}
