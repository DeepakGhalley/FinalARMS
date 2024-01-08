using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class ViewNotJointLandTax
    {
        public int LandOwnershipId { get; set; }
        public int LandDetailId { get; set; }
        public string PlotNo { get; set; }
        public int LandOwnershipTypeId { get; set; }
        public bool IsApportioned { get; set; }
        public decimal LandAcerage { get; set; }
        public decimal PLr { get; set; }
        public int? LandUseSubCategoryId { get; set; }
        public int TaxPayerId { get; set; }
        public bool StructureAvailable { get; set; }
        public int LastTaxPaidYear { get; set; }
        public int? CurrentYear { get; set; }
        public int SlabId { get; set; }
        public int RateId { get; set; }
        public decimal LandTaxRate { get; set; }
        public int? NoOfYears { get; set; }
        public decimal? TotalLandTaxAmount { get; set; }
        public decimal? UdtaxAmount { get; set; }
    }
}
