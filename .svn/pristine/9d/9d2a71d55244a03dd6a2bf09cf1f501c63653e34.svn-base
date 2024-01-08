using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblLandOwnershipDetail
    {
        public TblLandOwnershipDetail()
        {
            MstWaterConnection = new HashSet<MstWaterConnection>();
            TblBuildingOwnership = new HashSet<TblBuildingOwnership>();
            TblConstructionApprovedDetail = new HashSet<TblConstructionApprovedDetail>();
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
            TrnConstructionApprovalApplicationFeeDetail = new HashSet<TrnConstructionApprovalApplicationFeeDetail>();
            TrnLandFeeDetail = new HashSet<TrnLandFeeDetail>();
            TrnLandTransferDetail = new HashSet<TrnLandTransferDetail>();
            TrnOccupancyCertificateApplication = new HashSet<TrnOccupancyCertificateApplication>();
            TrnSewerageConnection = new HashSet<TrnSewerageConnection>();
            TrnVacuumTankerService = new HashSet<TrnVacuumTankerService>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
        }

        public int LandOwnershipId { get; set; }
        public int LandDetailId { get; set; }
        public int LandOwnershipTypeId { get; set; }
        public int TaxPayerId { get; set; }
        public string ThramNo { get; set; }
        public decimal? OwnershipPercentage { get; set; }
        public decimal PLr { get; set; }
        public int? PreviousTaxPayerId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? TransactionId { get; set; }
        public bool? IsActive { get; set; }
        public string Remarks { get; set; }
        public int? LastTaxPaidYear { get; set; }

        public virtual MstLandDetail LandDetail { get; set; }
        public virtual EnumLandOwnershipType LandOwnershipType { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual ICollection<TblBuildingOwnership> TblBuildingOwnership { get; set; }
        public virtual ICollection<TblConstructionApprovedDetail> TblConstructionApprovedDetail { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
        public virtual ICollection<TrnConstructionApprovalApplicationFeeDetail> TrnConstructionApprovalApplicationFeeDetail { get; set; }
        public virtual ICollection<TrnLandFeeDetail> TrnLandFeeDetail { get; set; }
        public virtual ICollection<TrnLandTransferDetail> TrnLandTransferDetail { get; set; }
        public virtual ICollection<TrnOccupancyCertificateApplication> TrnOccupancyCertificateApplication { get; set; }
        public virtual ICollection<TrnSewerageConnection> TrnSewerageConnection { get; set; }
        public virtual ICollection<TrnVacuumTankerService> TrnVacuumTankerService { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
    }
}
