using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class TaxRateVM
    {
        [Key]
        public long sl { get; set; }
        public string taxName { get; set; }
        public string slabName { get; set; }
        [Display(Name = "Slab Start")]
        public decimal? slabStart { get; set; }
        [Display(Name = "Slab End")]
        public decimal? slabEnd { get; set; }
        public decimal rate { get; set; }
        public DateTime effectiveDate { get; set; }

    }
}
