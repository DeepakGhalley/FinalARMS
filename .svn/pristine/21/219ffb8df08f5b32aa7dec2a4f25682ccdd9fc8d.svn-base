using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstAssetAttribute
    {
        public MstAssetAttribute()
        {
            MstAttributeUnitMap = new HashSet<MstAttributeUnitMap>();
            TblTechnicalInformation = new HashSet<TblTechnicalInformation>();
        }

        public int AssetAttributeId { get; set; }
        public int ParentAttributeId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
        public bool ValueRequired { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstParentAttribute ParentAttribute { get; set; }
        public virtual ICollection<MstAttributeUnitMap> MstAttributeUnitMap { get; set; }
        public virtual ICollection<TblTechnicalInformation> TblTechnicalInformation { get; set; }
    }
}
