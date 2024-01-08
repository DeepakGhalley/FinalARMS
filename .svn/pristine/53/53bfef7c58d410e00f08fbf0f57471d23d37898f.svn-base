using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class StallDetailVM
    {
        public int StallDetailId { get; set; }
        public int StallLocationId { get; set; }
        public string UserName { get; set; }
        public string StallLocation { get; set; }
        public int StallTypeId { get; set; }
        public string StallType { get; set; }
        public string StallNo { get; set; }
        public string StallName { get; set; }
        public decimal StallArea { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsTerminated { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedOn { get; set; }
        public int StallAllocationId { get; set; }
        public int BillingScheduleId { get; set; }
        public string BillingScheduleName { get; set; }
        public string StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SDate { get; set; }
        public string EndDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EDate { get; set; }
        public decimal RentalAmount { get; set; }
        public int TaxPayerId { get; set; }
        public string TaxPayerName { get; set; }
        public string TTIN { get; set; }
        public string CID { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DemandDate { get; set; }
        public string TaxName { get; set; }
        public byte[] QrImage { get; set; }
        public string DemandNo { get; set; }

        public virtual ICollection< MstStallLocation> StallLocations { get; set; }


    }
}
