using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstRate
    {
        public int RateId { get; set; }
        public int TaxId { get; set; }
        public int SlabId { get; set; }
        public decimal Rate { get; set; }
        public decimal? MinimumRate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstSlab Slab { get; set; }
        public virtual MstTaxMaster Tax { get; set; }
    }
}
