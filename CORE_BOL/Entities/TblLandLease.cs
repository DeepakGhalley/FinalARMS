using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblLandLease
    {
        public TblLandLease()
        {
            TblLandLeaseDemandDetail = new HashSet<TblLandLeaseDemandDetail>();
            TblLandLeasePeriod = new HashSet<TblLandLeasePeriod>();
        }

        public int LandLeaseId { get; set; }
        public int LandDetailId { get; set; }
        public int TaxPayerId { get; set; }
        public int BillingScheduleId { get; set; }
        public int LeaseTypeId { get; set; }
        public int LeaseActivityTypeId { get; set; }
        public bool HasShed { get; set; }
        public bool HassecurityDeposit { get; set; }
        public DateTime StartDate { get; set; }
        public decimal LeaseAmount { get; set; }
        public decimal ShedAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime? TerminateDate { get; set; }
        public string TerminateReason { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string LeaseApprovalNo { get; set; }

        public virtual EnumBillingSchedule BillingSchedule { get; set; }
        public virtual MstLandDetail LandDetail { get; set; }
        public virtual EnumLeaseActivityType LeaseActivityType { get; set; }
        public virtual EnumLeaseType LeaseType { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
        public virtual ICollection<TblLandLeaseDemandDetail> TblLandLeaseDemandDetail { get; set; }
        public virtual ICollection<TblLandLeasePeriod> TblLandLeasePeriod { get; set; }
    }
}
