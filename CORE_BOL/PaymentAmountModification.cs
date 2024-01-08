using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
   public class PaymentAmountModification
    {
        public int DemandId { get; set; }
        public int DemandNoId { get; set; }
        public string TaxName { get; set; }
        public decimal TotalDemandAmount { get; set; }
        //public decimal NewDemandAmount { get; set; }
        public string PlotNo { get; set; }
        public string TaxPayerName { get; set; }
        public int ReceiptId { get; set; }
        public string ReceiptNo { get; set; }
        public int RSL { get; set; }
        public int DSL { get; set; }
        public decimal TotalPaymentAmount { get; set; }
        public string DemandNo { get; set; }
        public string PaymentMode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string DemandUpload { get; set; }
        public string PaymentUpload { get; set; }
        public decimal PreviousDemandAmount { get; set; }
        public decimal PreviousPaymentAmount { get; set; }
        public decimal PreviousPaymentModeAmount { get; set; }
        public int PaymentLedgerId { get; set; }
        public int LedgerId { get; set; }
        public string PaymentModeNo { get; set; }
        public DateTime PaymentModeDate { get; set; }
        public decimal TotalPaymentModeAmount { get; set; }
    }
}
