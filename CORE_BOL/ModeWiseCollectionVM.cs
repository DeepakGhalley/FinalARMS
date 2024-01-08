using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ModeWiseCollectionVM
    {
        [Key]
        public int sl { get; set; }
        public long receiptId { get; set; }
        public string receiptNo { get; set; }
        public string PaymentModeNo { get; set; }
        public DateTime PaymentModeDate { get; set; }
        public DateTime PaymentDate { get; set; }
      
        public decimal TotalAmount { get; set; }
    }
}
