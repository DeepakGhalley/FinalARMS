using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class wisedetailVM
    {
        [Key]
        public long Sl { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentModeNo { get; set; }
        public string PaymentModeDate { get; set; }
        public long receiptId { get; set; }
        public string ReceiptNo { get; set; }
        public decimal CashAmount { get; set; }
        public decimal ChecqueAmount { get; set; }
        public decimal ThromdeApp { get; set; }
        public decimal OnlinePaymentAmount { get; set; }
        public decimal PIAmount { get; set; }
        public decimal MBOBAmount { get; set; }
        public decimal mPayAmount { get; set; }
        public decimal DkAmount { get; set; }
        public decimal TPayAmount { get; set; }
        public decimal DrukPNBAmount { get; set; }
        public decimal ePayAmount { get; set; }
        public decimal eTeeruAmount { get; set; }
        public decimal ScanPay { get; set; }
        public decimal GrandTotal { get; set; }



    }
}
