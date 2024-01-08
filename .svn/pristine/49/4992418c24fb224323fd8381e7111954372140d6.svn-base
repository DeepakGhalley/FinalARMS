using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblReceipt
    {
        public TblReceipt()
        {
            TblLedger = new HashSet<TblLedger>();
            TblPaymentLeger = new HashSet<TblPaymentLeger>();
        }

        public long ReceiptId { get; set; }
        public string ReceiptNo { get; set; }
        public int Sl { get; set; }
        public int ReceiptYear { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? RecordedOn { get; set; }

        public virtual ICollection<TblLedger> TblLedger { get; set; }
        public virtual ICollection<TblPaymentLeger> TblPaymentLeger { get; set; }
    }
}
