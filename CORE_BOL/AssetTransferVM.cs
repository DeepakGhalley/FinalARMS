using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class AssetTransferVM
    {
        public int AssetTransferId { get; set; }
        public int AssetId { get; set; }
        public int? TransferFromDivisionId { get; set; }
        public int? TransferFromSectionId { get; set; }
        public int? TransferToDivisionId { get; set; }
        public string ResponsiblePersonFrom { get; set; }
        public string ResponsiblePersonTo { get; set; }
        public string AssetCode { get; set; }
        public int? TransferToSectionId { get; set; }
        public DateTime? TransferDate { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int AssetTransferTypeId {get;set;}

        //Asset Search
        public string MajorHead { get; set; }
        public int MajorHeadId { get; set; }
        public string MinorHead { get; set; }
        public int MinorHeadId { get; set; }
        public string DetailHead { get; set; }
        public int DetailHeadId { get; set; }
        public string Division { get; set; }
        public int DivisionId { get; set; }
        public string Section { get; set; }
        public int SectionId { get; set; }
        public string AssetName { get; set; }
        public string AssetStatus { get; set; }
        public int AssetStatusId { get; set; }
        public string Lap { get; set; }
        public int LapId { get; set; }
        public string Demkhong { get; set; }
        public int DemkhongId { get; set; }

        public virtual MstAsset Asset { get; set; }
    }
}
