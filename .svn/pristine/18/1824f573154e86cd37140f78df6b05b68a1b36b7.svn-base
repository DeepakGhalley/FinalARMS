using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
   public class StallAllocationVM
    {
        public int StallAllocationId { get; set; }
        public int StallDetailId { get; set; }
        public bool IsActive { get; set; }
        public string StallName { get; set; }
        public string TTIN { get; set; }
        public string TaxPayerName { get; set; }
        public int TaxPayerId { get; set; }
        public string Cid { get; set; }
        public int BillingScheduleId { get; set; }
        public string BillingSchedule { get; set; }
        public DateTime? AllocationDate { get; set; }
        public int RateId { get; set; }
        public decimal RentalAmount { get; set; }
        public bool HasSecurityDeposit { get; set; }
        public decimal SecurityAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsTerminated { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? TerminateDate { get; set; }
        public string TerminateReason { get; set; }
        public int TerminatedBy { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedOn { get; set; }
        public string StallNo { get; set;}
        public decimal StallArea { get; set; }
        public string BillingScheduleName { get; set; }
        public string StartDate { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public string EndDate { get; set; }
        public int StallLocationId { get; set; }
        public string StallLocation { get; set; }
        public int StallTypeId { get; set; }
        public string StallType { get; set; }
        public virtual ICollection<TblStallDetail> StallDetails { get; set; }
        public virtual ICollection<MstTaxPayerProfile> TaxPayers { get; set; }
        public virtual ICollection<EnumBillingSchedule> BillingSchedules { get; set; }
        public virtual ICollection<MstRate> Rates { get; set; }



    }
}
