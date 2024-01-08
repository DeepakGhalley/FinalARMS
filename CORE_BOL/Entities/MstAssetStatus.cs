using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstAssetStatus
    {
        public MstAssetStatus()
        {
            MstAsset = new HashSet<MstAsset>();
        }

        public int AssetStatusId { get; set; }
        public string AssetStatus { get; set; }
        public string StatusDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstAsset> MstAsset { get; set; }
    }
}
