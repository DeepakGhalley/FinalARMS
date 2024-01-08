using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class PaymentReceiptByReceiptNo
    {
        public long ReceiptId { get; set; }
        public int LandDetailId { get; set; }
        public bool IsApportioned { get; set; }
        public string ReceiptNo { get; set; }
        public string TaxName { get; set; }
        public string TaxPayerName { get; set; }
        public decimal Amount { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string TTIN { get; set; }
        public int ReceiptYear { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public int TransactionTypeId { get; set; }
        public string CID { get; set; }
        public string MobileNo { get; set; }
        public string PlotNo { get; set; }
        public string ConsumerNo { get; set; }
        public string MeterNo { get; set; }
        public string BillingAddress { get; set; }
        public string TaxPayerType { get; set; }
        public string Email { get; set; }
        public string ApplicantName { get; set; }
        public string LicenseNo { get; set; }
        public string ActivityType { get; set; }
        public string ECRefNo { get; set; }
    }
}
