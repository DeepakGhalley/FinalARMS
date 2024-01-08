﻿using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblPaymentLeger
    {
        public TblPaymentLeger()
        {
            TblDemandLedgerPaymentUpdate = new HashSet<TblDemandLedgerPaymentUpdate>();
            TblDeposit = new HashSet<TblDeposit>();
        }

        public long PaymentLedgerId { get; set; }
        public long ReceiptId { get; set; }
        public int PaymentModeId { get; set; }
        public decimal Amount { get; set; }
        public int? BankBranchId { get; set; }
        public string PaymentModeNo { get; set; }
        public DateTime? PaymentModeDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? PaymentStatusId { get; set; }
        public long? BfsTransactionDetailId { get; set; }
        public DateTime? RecordedOn { get; set; }
        public string Remarks { get; set; }

        public virtual MstBankBranch BankBranch { get; set; }
        public virtual TblBfsTransactiondetails BfsTransactionDetail { get; set; }
        public virtual EnumPaymentMode PaymentMode { get; set; }
        public virtual EnumPaymentStatus PaymentStatus { get; set; }
        public virtual TblReceipt Receipt { get; set; }
        public virtual ICollection<TblDemandLedgerPaymentUpdate> TblDemandLedgerPaymentUpdate { get; set; }
        public virtual ICollection<TblDeposit> TblDeposit { get; set; }
    }
}
