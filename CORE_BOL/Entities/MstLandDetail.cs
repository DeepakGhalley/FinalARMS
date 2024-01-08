using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLandDetail
    {
        public MstLandDetail()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
            MstWaterConnection = new HashSet<MstWaterConnection>();
            TblLandLease = new HashSet<TblLandLease>();
            TblLandOwnershipDetail = new HashSet<TblLandOwnershipDetail>();
            TrnLandTransferDetail = new HashSet<TrnLandTransferDetail>();
            TrnOccupancyCertificateApplication = new HashSet<TrnOccupancyCertificateApplication>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
        }

        public int LandDetailId { get; set; }
        public int? LapId { get; set; }
        public int? DemkhongId { get; set; }
        public int? StreetNameId { get; set; }
        public int LandTypeId { get; set; }
        public int PropertyTypeId { get; set; }
        public int? LandUseSubCategoryId { get; set; }
        public string PlotNo { get; set; }
        public decimal LandAcerage { get; set; }
        public decimal LandValue { get; set; }
        public decimal LandPoolingRate { get; set; }
        public bool StructureAvailable { get; set; }
        public string PlotAddress { get; set; }
        public string Location { get; set; }
        public bool IsApproved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? TransactionId { get; set; }
        public bool VacantLandTaxApplicable { get; set; }
        public bool GarbageApplicable { get; set; }
        public bool StreetLightApplicable { get; set; }
        public bool IsSubdivided { get; set; }
        public int? LastTaxPaidYear { get; set; }
        public bool? IsApportioned { get; set; }
        public string ThramNo { get; set; }

        public virtual MstDemkhong Demkhong { get; set; }
        public virtual MstLandType LandType { get; set; }
        public virtual MstLandUseSubCategory LandUseSubCategory { get; set; }
        public virtual MstLap Lap { get; set; }
        public virtual EnumPropertyType PropertyType { get; set; }
        public virtual MstStreetName StreetName { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
        public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual ICollection<TblLandLease> TblLandLease { get; set; }
        public virtual ICollection<TblLandOwnershipDetail> TblLandOwnershipDetail { get; set; }
        public virtual ICollection<TrnLandTransferDetail> TrnLandTransferDetail { get; set; }
        public virtual ICollection<TrnOccupancyCertificateApplication> TrnOccupancyCertificateApplication { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
    }
}
