using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblAssetTransfer
    {
        public int AssetTransferId { get; set; }
        public int AssetId { get; set; }
        public int? TransferFromDivisionId { get; set; }
        public int? TransferFromSectionId { get; set; }
        public int? TransferToDivisionId { get; set; }
        public int? TransferToSectionId { get; set; }
        public DateTime? TransferDate { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ResponsiblePersonFrom { get; set; }
        public string ResponsiblePersonTo { get; set; }
        public int AssetTransferTypeId { get; set; }

        public virtual MstAsset Asset { get; set; }
        public virtual EnumAssetTransferType AssetTransferType { get; set; }
    }
}
