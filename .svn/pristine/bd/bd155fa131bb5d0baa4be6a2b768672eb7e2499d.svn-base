using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstAsset
    {
        public MstAsset()
        {
            TblAssetDepreciation = new HashSet<TblAssetDepreciation>();
            TblAssetMaintenance = new HashSet<TblAssetMaintenance>();
            TblAssetTransfer = new HashSet<TblAssetTransfer>();
            TblTechnicalInformation = new HashSet<TblTechnicalInformation>();
        }

        public int AssetId { get; set; }
        public int TertiaryAccountHeadId { get; set; }
        public int SectionId { get; set; }
        public int AssetStatusId { get; set; }
        public int AssetFunctionId { get; set; }
        public int? SupplierId { get; set; }
        public int? LapId { get; set; }
        public int? DemkhongId { get; set; }
        public int AreaId { get; set; }
        public int? ZoneId { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string ResponsiblePerson { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string Remarks { get; set; }
        public string GisCode { get; set; }
        public DateTime? GoodReceiveDate { get; set; }
        public int? GoodReceiveBy { get; set; }
        public int? AssetEntryStatusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual EnumAssetEntryStatus AssetEntryStatus { get; set; }
        public virtual MstAssetFunction AssetFunction { get; set; }
        public virtual MstAssetStatus AssetStatus { get; set; }
        public virtual MstDemkhong Demkhong { get; set; }
        public virtual MstLap Lap { get; set; }
        public virtual MstSection Section { get; set; }
        public virtual MstSuppliers Supplier { get; set; }
        public virtual MstTertiaryAccountHead TertiaryAccountHead { get; set; }
        public virtual MstZone Zone { get; set; }
        public virtual ICollection<TblAssetDepreciation> TblAssetDepreciation { get; set; }
        public virtual ICollection<TblAssetMaintenance> TblAssetMaintenance { get; set; }
        public virtual ICollection<TblAssetTransfer> TblAssetTransfer { get; set; }
        public virtual ICollection<TblTechnicalInformation> TblTechnicalInformation { get; set; }
    }
}
