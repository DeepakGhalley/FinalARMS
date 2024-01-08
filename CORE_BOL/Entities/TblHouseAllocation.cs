using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblHouseAllocation
    {
        public TblHouseAllocation()
        {
            TblHouseRentDemandDetail = new HashSet<TblHouseRentDemandDetail>();
            TblHouseRentPeriod = new HashSet<TblHouseRentPeriod>();
        }

        public int HouseAllocationId { get; set; }
        public int HouseDetailId { get; set; }
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
        public virtual TblHouseDetail HouseDetail { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
        public virtual ICollection<TblHouseRentDemandDetail> TblHouseRentDemandDetail { get; set; }
        public virtual ICollection<TblHouseRentPeriod> TblHouseRentPeriod { get; set; }
    }
}
