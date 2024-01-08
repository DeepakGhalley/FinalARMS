using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class OnlinePropertyTaxPaymentVM
    {
        public int TaxPayerId { get; set; }
        public string Name { get; set; }
        public string DemandNo { get; set; }
        public string ExemptionLetter { get; set; }
        public long DemandNoId { get; set; }
        public long DemandId { get; set; }
        public long TransactionId { get; set; }
        public string Ttin { get; set; }
        public string Cid { get; set; }
        public string Email { get; set; }
        public string TaxName { get; set; }
        public int TransactionTypeId { get; set; }
        public string PlotNo { get; set; }
        public string PlotAddress { get; set; }
        public string CalendarYear { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal DemandAmount { get; set; }
        public decimal? ExemptionAmount { get; set; }

    }
}
