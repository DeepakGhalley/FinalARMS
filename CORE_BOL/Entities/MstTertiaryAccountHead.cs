using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTertiaryAccountHead
    {
        public MstTertiaryAccountHead()
        {
            MstAsset = new HashSet<MstAsset>();
            MstParentAttribute = new HashSet<MstParentAttribute>();
        }

        public int TertiaryAccountHeadId { get; set; }
        public int SecondaryAccountHeadId { get; set; }
        public string TertiaryAccountHeadName { get; set; }
        public string TertiaryAccountHeadCode { get; set; }
        public string TertiaryAccountHeadDescription { get; set; }
        public string TertiaryAccountHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string AssetType { get; set; }

        public virtual MstSecondaryAccountHead SecondaryAccountHead { get; set; }
        public virtual ICollection<MstAsset> MstAsset { get; set; }
        public virtual ICollection<MstParentAttribute> MstParentAttribute { get; set; }
    }
}
