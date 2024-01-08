using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblDeposit
    {
        public long DepositId { get; set; }
        public long? PaymentLedgerId { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime PaymentFromDate { get; set; }
        public DateTime PaymentToDate { get; set; }
        public DateTime DepositDate { get; set; }
        public int? PaymentStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual TblPaymentLeger PaymentLedger { get; set; }
        public virtual EnumPaymentStatus PaymentStatus { get; set; }
    }
}
