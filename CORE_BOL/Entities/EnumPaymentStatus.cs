using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumPaymentStatus
    {
        public EnumPaymentStatus()
        {
            TblDeposit = new HashSet<TblDeposit>();
            TblLedger = new HashSet<TblLedger>();
            TblPaymentLeger = new HashSet<TblPaymentLeger>();
        }

        public int PaymentStatusId { get; set; }
        public string PaymentStatus { get; set; }

        public virtual ICollection<TblDeposit> TblDeposit { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
        public virtual ICollection<TblPaymentLeger> TblPaymentLeger { get; set; }
    }
}
