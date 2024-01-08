using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
   public class DemandCancelVM
    {
        public int DemandCancelId { get; set; }
        public int DemandNoId { get; set; }
        public string DemandNo { get; set; }
        public decimal TotalCancelAmount { get; set; }
        public string Remarks { get; set; }
        public string TaxName { get; set; }
        public decimal DemandAmount { get; set; }
        public decimal ExemptionAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Name { get; set; }
        public string CID { get; set; }
        public string TTIN { get; set; }
        public int DemandId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsPaymentMade { get; set; }
    }
}
