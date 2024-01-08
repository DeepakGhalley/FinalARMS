using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblDemandLedgerPaymentUpdate
    {
        public long PaymentUpdateId { get; set; }
        public long? DemandId { get; set; }
        public long? LedgerId { get; set; }
        public long? PaymentLedgerId { get; set; }
        public decimal? OldAmount { get; set; }
        public decimal? NewAmount { get; set; }
        public string FileName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual TblDemand Demand { get; set; }
        public virtual TblLedger Ledger { get; set; }
        public virtual TblPaymentLeger PaymentLedger { get; set; }
    }
}
