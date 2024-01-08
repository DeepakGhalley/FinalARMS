using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTechnicalAttribute
    {
        public MstTechnicalAttribute()
        {
            MstDetailTechnicalAttribute = new HashSet<MstDetailTechnicalAttribute>();
        }

        public int TechnicalAttributeId { get; set; }
        public int ParentAttributeId { get; set; }
        public string TechnicalAttribute { get; set; }
        public string TechnicalAttributeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstParentAttribute ParentAttribute { get; set; }
        public virtual ICollection<MstDetailTechnicalAttribute> MstDetailTechnicalAttribute { get; set; }
    }
}
