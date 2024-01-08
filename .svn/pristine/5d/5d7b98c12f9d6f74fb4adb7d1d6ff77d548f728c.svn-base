using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ParkingFeeVM
    {
        public int ParkingFeeDetailId { get; set; }
        public int ParkingFeePeriodId { get; set; }
        
        [Display(Name = "Parking Zone")]
        public int ParkingZoneId { get; set; }
        public string ParkingZoneName { get; set; }

        [Display(Name = "Tax payer")]
        public int TaxPayerId { get; set; }
        public string TaxPayerName { get; set; }

        [Display(Name = "Billing Schedule")]
        public int BillingScheduleId { get; set; }
        public string BillingScheduleName { get; set; }

        [Display(Name = "Installment Amount")]
        public decimal? InstallmentAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Terminate Date")]
        public DateTime? TerminateDate { get; set; }

        [Display(Name = "Terminate Reason")]
        public string TerminateReason { get; set; }

        [Display(Name = "Terminate By")]
        public int? TerminatedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime StartDateD { get; set; }
        public string StartDate { get; set; }
        public DateTime EndDateD { get; set; }
        public string EndDate { get; set; }
        public string ttin { get; set; }
        public string cid { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public string TaxName { get; set; }
        public DateTime DemandDate { get; set; }
        public byte[] QrImage { get; set; }
        public string DemandNo { get; set; }
        public string Creatorname { get; set; }
        public DateTime EEndDate { get; set; }
        public DateTime SStartDate { get; set; }




        public virtual EnumBillingSchedule BillingSchedule { get; set; }
        public virtual MstParkingZone ParkingZone { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
        public virtual ICollection<TblParkingFeeDemandDetail> TblParkingFeeDemandDetail { get; set; }
    }
}
