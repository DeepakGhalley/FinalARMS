using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstDetailTechnicalAttribute
    {
        public int DetailTechnicalAttributeId { get; set; }
        public int TechnicalAttributeId { get; set; }
        public string DetailTechnicalAttribute { get; set; }
        public string DetailTechnicalAttributeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTechnicalAttribute TechnicalAttribute { get; set; }
    }
}
