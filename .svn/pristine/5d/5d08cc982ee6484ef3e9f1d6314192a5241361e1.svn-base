using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class HouseRentDetailVM
    {
        public int HouseDetailId { get; set; }
        public int TaxPayerId { get; set; }
        public string HouseNo { get; set; }
        public string HouseAddress { get; set; }
        public string Remarks { get; set; }
        public string Adate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedOn { get; set; }
        public decimal RentalAmount { get; set; }
        public int HouseAllocationId { get; set; }
        public string BillingScheduleName { get; set; }
        public decimal SecurityAmount { get; set; }
        public DateTime AllocationDate { get; set; }
        public int? TerminatedBy { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Ttin { get; set; }
        public string Cid { get; set; }
        public virtual ICollection<TblHouseAllocation> TblHouseAllocation { get; set; }

    }
}
