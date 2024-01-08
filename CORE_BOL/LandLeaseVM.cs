using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class LandLeaseModel
    {
        public int LandLeaseId { get; set; }
        [Display(Name = "Plot No.")]
        public int LeaseTypeId { get; set; }
        public int LandDetailId { get; set; }
        [Display(Name = "Tax Payer")]
        public int TaxPayerId { get; set; }
        [Display(Name = "Billing Schedule")]
        public int BillingScheduleId { get; set; }

        [Display(Name = "Lease Type")]

        public int LeaseActivityTypeId { get; set; }
        [Display(Name = "Tax Period")]
        public int TaxPeriodId { get; set; }
        [Display(Name = "Has Shed")]
        public bool HasShed { get; set; }
        [Display(Name = "Has security Deposit")]
        public bool HassecurityDeposit { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string Sdate { get; set; }
        public string StartDateString { get; set; }
        public string LeaseName { get; set; }

        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string EndDateString { get; set; }
        [Display(Name = "Lease Amount")]
        public decimal LeaseAmount { get; set; }
        [Display(Name = "Shed Amount")]
        public decimal ShedAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string landLeaseName { get; set; }
        public string billingScheduleName { get; set; }
        [Display(Name = "Name")]
        public string taxPayerName { get; set; }
        public string leaseActivityType { get; set; }
        public string LandDetailName { get; set; }
        public string PlotNo { get; set; }
        public string leaseType { get; set; }
        [Display(Name = "Thram No")]
        public string thramNo { get; set; }
        [Display(Name = "TTIN")]
        public string Ttin { get; set; }
        [Display(Name = "CID")]
        public string Cid { get; set; }
        [Display(Name = "Current Address")]
        public string CAddressID { get; set; }
        [Display(Name = "Mobile No")]
        public string MobileNoID { get; set; }
        [Display(Name = "Email")]
        public string EmailID { get; set; }
        [Display(Name = "Location")]
        public string LocationID { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Termination")]
        public DateTime TerminateDate { get; set; }
        [Display(Name = "Reason")]
        public string TerminateReason { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExtensionFrom { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime ExtensionTo { get; set; }
        public string ExtensionRemaks { get; set; }
        public int LandLeasePeriodId { get; set; }
        public DateTime DemandDate { get; set; }
        public string TaxName { get; set; }
        public byte[] QrImage { get; set; }
        public string DemandNo { get; set; }
        public string Creatorname { get; set; }
        public DateTime SStartDate { get; set; }
        public DateTime EEndDate { get; set; }
        public decimal LandAcerage { get; set; }
        public int StreetNameId { get; set; }
        public int DemkhongId { get; set; }
        public int LapId { get; set; }
        public string PlotAddress { get; set; }
        public string LeaseApprovalNo { get; set; }
        public int BSI { get; set; }
        public int HS { get; set; }


        //public virtual EnumBillingSchedule BillingSchedule { get; set; }
        //public virtual MstLandDetail LandDetail { get; set; }
        //public virtual EnumLeaseActivityType LeaseActivityType { get; set; }
        //public virtual EnumLeaseType LeaseType { get; set; }
        //public virtual MstTaxPayerProfile TaxPayer { get; set; }
        //public virtual ICollection<TblLandLeaseDemandDetail> TblLandLeaseDemandDetail { get; set; }
        //public virtual ICollection<TblLandLeasePeriod> TblLandLeasePeriod { get; set; }

    }

}