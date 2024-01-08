using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class spTaxCalculationAPIModel
    {
        [Key]
        public long Sl { get; set; }
        public int pType { get; set; }
        public int calendarYearId { get; set; }
        public string calendarYear { get; set; }
        public string plotNo { get; set; }
        public decimal landAcerage { get; set; }
        public int landOwnershipId { get; set; }
        public int taxPayerId { get; set; }
        public string thramNo { get; set; }
        public decimal pLR { get; set; }
        public int lastTaxPaidYear { get; set; }
        public int landDetailId { get; set; }
        public bool isApportioned { get; set; }
        public int LandTaxId { get; set; }
        public decimal LandTaxRate { get; set; }
        public decimal LandTaxAmount { get; set; }
        public decimal LandTaxPenalty { get; set; }
        public int UDTaxId { get; set; }
        public string UDTaxApplicable { get; set; }
        public decimal penaltyOrRate { get; set; }
        public decimal UDTaxRate { get; set; }
        public decimal UDTaxAmount { get; set; }
        public decimal UDTaxPenaltyAmount { get; set; }
        public int UnitTaxId { get; set; }
        public int GarbageTaxId { get; set; }
        public int StreetLightTaxId { get; set; }
        public int noOfUnit { get; set; }
        public decimal UnitTax { get; set; }
        public decimal GarbageTax { get; set; }
        public decimal StreetLightTax { get; set; }
        public decimal UnitTaxRate { get; set; }
        public decimal GarbageTaxRate { get; set; }
        public decimal StreetLightRate { get; set; }
        public decimal UnitTaxPenalty { get; set; }
        public decimal GarbageTaxPenalty { get; set; }
        public decimal StreetLightTaxPenalty { get; set; }
        public int TotalDays { get; set; }
        public int PenaltyDays { get; set; }
        public string flatNo { get; set; }
        //public decimal GrandTotal { get; set; }
    }
}
