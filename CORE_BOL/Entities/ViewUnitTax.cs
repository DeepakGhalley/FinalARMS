using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class ViewUnitTax
    {
        public int LandDetailId { get; set; }
        public int TaxPayerId { get; set; }
        public int? NoOfUnit { get; set; }
        public decimal? UnitTaxAmount { get; set; }
        public decimal? GarbageTaxAmount { get; set; }
        public decimal? StreetLightTaxAmount { get; set; }
    }
}
