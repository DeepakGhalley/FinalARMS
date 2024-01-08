using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTaxPeriod
    {
        public int TaxPeriodId { get; set; }
        public int TransactionTypeId { get; set; }
        public int CalendarYearId { get; set; }
        public decimal PenaltyOrRate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstCalendarYear CalendarYear { get; set; }
        public virtual MstTransactionType TransactionType { get; set; }
    }
}
