using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblLandLeaseDemandDetail
    {
        public TblLandLeaseDemandDetail()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public long LandLeaseDemandDetailId { get; set; }
        public int LandLeaseId { get; set; }
        public int DemandYear { get; set; }
        public int DemandDays { get; set; }
        public int DemandGenerateScheduleId { get; set; }
        public decimal InstallmentAmount { get; set; }
        public long DemandNoId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime InstallmentDate { get; set; }

        public virtual EnumDemandGenerateSchedule DemandGenerateSchedule { get; set; }
        public virtual TblDemandNo DemandNo { get; set; }
        public virtual TblLandLease LandLease { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
