using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CORE_BOL
{
    public class DepositVM
    {
        [Key]
        public long Sl { get; set; }
       
        public string PaymentMode { get; set; }
        public string PaymentModeNo { get; set; }
        public string PaymentModeDate { get; set; }
        public string BranchName { get; set; }

        public decimal Amount { get; set; }
        public long PaymentLedgerId { get; set; }


    }
    public class DepositSaveVM
    {
        public long DepositId { get; set; }
        public long? PaymentLedgerId { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime PaymentFromDate { get; set; }
        public DateTime PaymentToDate { get; set; }
        public DateTime DepositDate { get; set; }
        public int? PaymentStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

       
        public string PaymentMode { get; set; }
        public string BranchName { get; set; }
        public string PaymentModeNo { get; set; }
        public DateTime PaymentModeDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class PaymentDepositReportVM
    {
        [Key]
        public long Sl { get; set; }

        public string PaymentMode { get; set; }
        public string BranchName { get; set; }
        public string PaymentModeNo { get; set; }
        public string PaymentModeDate { get; set; }
        public decimal Amount { get; set; }
        public string UserName { get; set; }


    }
}
