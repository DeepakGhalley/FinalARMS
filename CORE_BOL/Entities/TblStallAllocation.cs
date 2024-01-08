using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblStallAllocation
    {
        public TblStallAllocation()
        {
            TblStallDetailDemand = new HashSet<TblStallDetailDemand>();
            TblStallPeriod = new HashSet<TblStallPeriod>();
        }

        public int StallAllocationId { get; set; }
        public int StallDetailId { get; set; }
        public int TaxPayerId { get; set; }
        public int BillingScheduleId { get; set; }
        public DateTime AllocationDate { get; set; }
        public decimal RentalAmount { get; set; }
        public bool HasSecurityDeposit { get; set; }
        public decimal SecurityAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsTerminated { get; set; }
        public DateTime? TerminateDate { get; set; }
        public string TerminateReason { get; set; }
        public int? TerminatedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual EnumBillingSchedule BillingSchedule { get; set; }
        public virtual TblStallDetail StallDetail { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
        public virtual ICollection<TblStallDetailDemand> TblStallDetailDemand { get; set; }
        public virtual ICollection<TblStallPeriod> TblStallPeriod { get; set; }
    }
}
