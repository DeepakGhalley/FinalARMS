using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstCalendarYear
    {
        public MstCalendarYear()
        {
            MstTaxPayerProfileCensusSmssentYr = new HashSet<MstTaxPayerProfile>();
            MstTaxPayerProfileTaxSmssentYear = new HashSet<MstTaxPayerProfile>();
            MstTaxPeriod = new HashSet<MstTaxPeriod>();
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public int CalendarYearId { get; set; }
        public string CalendarYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfileCensusSmssentYr { get; set; }
        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfileTaxSmssentYear { get; set; }
        public virtual ICollection<MstTaxPeriod> MstTaxPeriod { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
