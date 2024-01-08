using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class TransactionDetailModel
    {
        public long TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public string Transaction { get; set; }
        public int? WorkLevelId { get; set; }
        public decimal? TransactionValue { get; set; }
        public string Remarks { get; set; }
        public int? TaxPayerId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTransactionType TransactionType { get; set; }
    }
}
