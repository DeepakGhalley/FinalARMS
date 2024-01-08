using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumAssetEntryStatus
    {
        public EnumAssetEntryStatus()
        {
            MstAsset = new HashSet<MstAsset>();
        }

        public int AssetEntryStatusId { get; set; }
        public string AssetEntryStatus { get; set; }

        public virtual ICollection<MstAsset> MstAsset { get; set; }
    }
}
