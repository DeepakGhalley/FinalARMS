using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumAssetTransferType
    {
        public EnumAssetTransferType()
        {
            TblAssetTransfer = new HashSet<TblAssetTransfer>();
        }

        public int AssetTransferTypeId { get; set; }
        public string AssetTransferType { get; set; }

        public virtual ICollection<TblAssetTransfer> TblAssetTransfer { get; set; }
    }
}
