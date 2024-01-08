using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class HouseAllocationVM
    {

        public int HouseAllocationId { get; set; }
        public int HouseDetailId { get; set; }
        public bool IsActive { get; set; }
        public int TaxPayerId { get; set; }
        public int BillingScheduleId { get; set; }
        public string BillingSchedule { get; set; }
        public DateTime? AllocationDate { get; set; }
        public string? Adate { get; set; }
        public int RateId { get; set; }
        public decimal RentalAmount { get; set; }
        public bool HasSecurityDeposit { get; set; }
        public decimal SecurityAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsTerminated { get; set; }
        public DateTime? TerminateDate { get; set; }
        public string TerminateReason { get; set; }
        public int? TerminatedBy { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedOn { get; set; }

        public string BillingScheduleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime SStartDate { get; set; }
        public DateTime EEndDate { get; set; }
        public string HouseNo { get; set; }
        public string HouseAddress { get; set; }
        public string TaxPayerName { get; set; }
        public string ttin { get; set; }
        public decimal TotalAmount { get; set; }
        public string cid { get; set; }
        public string Address { get; set; }
        public string Creatorname { get; set; }
        public DateTime DemandDate { get; set; }
        public string TaxName { get; set; }
        public string DemandNo { get; set; }
        public byte[] QrImage { get; set; }


        public virtual EnumBillingSchedule BillingSchedules { get; set; }
        public virtual TblHouseDetail HouseDetail { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
        public virtual ICollection<TblHouseRentDemandDetail> TblHouseRentDemandDetail { get; set; }
        public virtual ICollection<TblHouseRentPeriod> TblHouseRentPeriod { get; set; }


    }
}
