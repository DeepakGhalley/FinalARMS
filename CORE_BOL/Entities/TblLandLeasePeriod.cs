using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblLandLeasePeriod
    {
        public int LandLeasePeriodId { get; set; }
        public int LandLeaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TblLandLease LandLease { get; set; }
    }
}
