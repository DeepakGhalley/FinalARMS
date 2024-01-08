using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTaxTypeClassification
    {
        public int TaxTypeClassificationId { get; set; }
        public string TaxTypeClassificationName { get; set; }
        public string TaxTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
