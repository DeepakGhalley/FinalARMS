using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TrnConstructionApprovalApplicationFeeDetail
    {
        public int ConstructionApprovalApplicationFeeId { get; set; }
        public int LandOwnershipId { get; set; }
        public long TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string G2cApplicationNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
    }
}
