using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblMiscellaneousRecord
    {
        public TblMiscellaneousRecord()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public long MiscellaneousRecordId { get; set; }
        public long TransactionId { get; set; }
        public int TaxId { get; set; }
        public int SlabId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cid { get; set; }
        public string MobileNo { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public bool PaymentStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstSlab Slab { get; set; }
        public virtual MstTaxMaster Tax { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
