using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TrnOccupancyCertificateApplication
    {
        public int OccupancyCertificateApplicationId { get; set; }
        public int OccupancyTypeId { get; set; }
        public int LandOwnershipId { get; set; }
        public int LandDetailId { get; set; }
        public int BuildingDetailId { get; set; }
        public int? BuildingUnitDetailId { get; set; }
        public int TaxPayerId { get; set; }
        public DateTime DateOfFinalInspection { get; set; }
        public int LogoSignMapId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ValidTillDate { get; set; }
        public string OcReferenceNo { get; set; }
        public bool IsNewOc { get; set; }
        public int Yr { get; set; }
        public int Sl { get; set; }
        public string G2cApplicationNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsBuildingOc { get; set; }

        public virtual MstBuildingDetail BuildingDetail { get; set; }
        public virtual MstLandDetail LandDetail { get; set; }
        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
        public virtual MstLogoSignMap LogoSignMap { get; set; }
        public virtual EnumOccupancyType OccupancyType { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
    }
}
