using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class LandLeasePeriodVM
    {
        public int LandLeasePeriodId { get; set; }
        public int LandLeaseId { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Extension From")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Extension To")]
        public DateTime EndDate { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Name")]
        public string taxPayerName { get; set; }
        [Display(Name = "Plot No")]
        public string Plotno { get; set; }
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
        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        public virtual TblLandLease LandLease { get; set; }
    }
}
