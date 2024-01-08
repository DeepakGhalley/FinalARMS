using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblUnScheduledParkingRecord
    {
        public TblUnScheduledParkingRecord()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public int UnScheduledParkingRecordId { get; set; }
        public string Cid { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Amount { get; set; }
        public long TransactionId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
