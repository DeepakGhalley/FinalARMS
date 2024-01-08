using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class LandLeaseDemandDetailModel
    {

        public long LandLeaseDemandDetailId { get; set; }
        public int LandLeaseId { get; set; }
        [Display(Name = "Demand Year")]
        public int DemandYear { get; set; }
        public int DemandGenerateScheduleId { get; set; }
        [Display(Name = "Installment Amount")]
        public decimal InstallmentAmount { get; set; }
        [Display(Name = "Demand")]
        public long DemandNoId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
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
        [Display(Name = "Name")]
        public string taxPayerName { get; set; }
        [Display(Name = "Plot No.")]
        public string PlotNo { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Thram No.")]
        public string ThramNo { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public virtual TblDemand Demand { get; set; }
        [Display(Name = "Demand Generate Schedule")]
        public virtual EnumDemandGenerateSchedule DemandGenerateSchedule { get; set; }
        [Display(Name = "LandLease")]
        public virtual TblLandLease LandLease { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
    }
}
