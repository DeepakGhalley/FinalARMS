using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class RateVM
    {
        public int RateId { get; set; }
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public int SlabId { get; set; }
        public string Slab { get; set; }
        public decimal Rate { get; set; }
        public decimal? MinimumRate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstSlab Slabs { get; set; }
        public virtual MstTaxMaster Tax { get; set; }
    }
}
