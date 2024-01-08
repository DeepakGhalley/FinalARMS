using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TrnLandTransferDetail
    {
        public int LandTransferDetailId { get; set; }
        public int FromLandOwnershipId { get; set; }
        public string ToTaxPayerIds { get; set; }
        public int LandDetailId { get; set; }
        public long TransactionId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TblLandOwnershipDetail FromLandOwnership { get; set; }
        public virtual MstLandDetail LandDetail { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
    }
}
