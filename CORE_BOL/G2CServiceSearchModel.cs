using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
   public class G2CServiceSearchModel
    {
        [Display(Name = "G2C Services")]
        public int TransactionTypeId { get; set; }
        [Display(Name = "Application No")]
        public String ApplicationNo { get; set; }
    }
}
