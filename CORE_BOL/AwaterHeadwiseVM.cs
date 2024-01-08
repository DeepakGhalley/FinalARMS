using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class AwaterHeadwiseVM
    {
        [Key]
        public long Sl { get; set; }
        public string MinorHeadName { get; set; }
        public decimal Amount { get; set; }
      
       

    }
}
