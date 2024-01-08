﻿using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblBfsTransactiondetails
    {
        public TblBfsTransactiondetails()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
            TblPaymentLeger = new HashSet<TblPaymentLeger>();
        }

        public long BfsTransactionDetailId { get; set; }
        public string BfsMsgType { get; set; }
        public string BfsBenfId { get; set; }
        public string BfsOrderNo { get; set; }
        public string BfsBenfBankCode { get; set; }
        public string BfsTxnCurrency { get; set; }
        public decimal? BfsTxnAmount { get; set; }
        public string BfsRemitterEmail { get; set; }
        public string BfsPaymentDesc { get; set; }
        public string BfsVersion { get; set; }
        public string BfsBenfTxnTime { get; set; }
        public string BfsChecksum { get; set; }
        public string BfsResponseChecksum { get; set; }
        public string BfsBfsTxnId { get; set; }
        public string BfsRemitterBankId { get; set; }
        public string BfsRemitterAccNo { get; set; }
        public string BfsRemitterOtp { get; set; }
        public string BfsDebitAuthCode { get; set; }
        public string BfsDebitAuthNo { get; set; }
        public string BfsResponseDesc { get; set; }
        public string BfsResponseCode { get; set; }
        public string BfsBankId { get; set; }
        public string BfsBankName { get; set; }
        public string BfsRemitterName { get; set; }
        public string BfsTxnTime { get; set; }
        public string BfsStatusState { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string DemandIds { get; set; }

        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
        public virtual ICollection<TblPaymentLeger> TblPaymentLeger { get; set; }
    }
}
