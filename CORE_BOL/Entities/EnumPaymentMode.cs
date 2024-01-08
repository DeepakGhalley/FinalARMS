using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumPaymentMode
    {
        public EnumPaymentMode()
        {
            TblPaymentLeger = new HashSet<TblPaymentLeger>();
        }

        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentModeDetails { get; set; }

        public virtual ICollection<TblPaymentLeger> TblPaymentLeger { get; set; }
    }
}
