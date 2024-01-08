using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstParentAttribute
    {
        public MstParentAttribute()
        {
            MstAssetAttribute = new HashSet<MstAssetAttribute>();
            MstTechnicalAttribute = new HashSet<MstTechnicalAttribute>();
        }

        public int ParentAttributeId { get; set; }
        public int TertiaryAccountHeadId { get; set; }
        public string ParentAttribute { get; set; }
        public string ParentAttributeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTertiaryAccountHead TertiaryAccountHead { get; set; }
        public virtual ICollection<MstAssetAttribute> MstAssetAttribute { get; set; }
        public virtual ICollection<MstTechnicalAttribute> MstTechnicalAttribute { get; set; }
    }
}
