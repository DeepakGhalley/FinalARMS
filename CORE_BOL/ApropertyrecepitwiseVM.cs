using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ApropertyrecepitwiseVM
    {
        [Key]
        public long Sl { get; set; }
        public long ReceiptId { get; set; }
        public string ReceiptNo { get; set; }
        public decimal Amount { get; set; }
      
       

    }
}
