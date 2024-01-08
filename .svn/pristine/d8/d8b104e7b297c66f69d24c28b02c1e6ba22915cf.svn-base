using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TrnTaxDetail
    {
        public int TrnTaxDetailId { get; set; }
        public int TaxId { get; set; }
        public string Amount { get; set; }
        public string ESakorTransactionId { get; set; }
        public int LandTransferTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual EnumLandTransferType LandTransferType { get; set; }
        public virtual MstTaxMaster Tax { get; set; }
    }
}
