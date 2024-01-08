using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class Propertytaxapi
    {
        public int CalendarYearId { get; set; }
        public string CalendarYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlotNo { get; set; }
        public decimal LandAcerage { get; set; }
        public int? LandUseSubCategoryId { get; set; }
        public int PropertyTypeId { get; set; }
        public int LandTypeId { get; set; }
        public int? StreetNameId { get; set; }
        public int? DemkhongId { get; set; }
        public int? LapId { get; set; }
        public int LandOwnershipId { get; set; }
        public int LandOwnershipTypeId { get; set; }
        public int TaxPayerId { get; set; }
        public string ThramNo { get; set; }
        public decimal PLr { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveOwnership { get; set; }
        public int? LastTaxPaidYear { get; set; }
        public string LandUseCategory { get; set; }
        public string LandUseSubCategory { get; set; }
        public int LandDetailId { get; set; }
        public bool IsApportioned { get; set; }
    }
}
