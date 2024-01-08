using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTransactionTypeTaxMap
    {
        public int TransactionTypeTaxMapId { get; set; }
        public int TransactionTypeId { get; set; }
        public int TaxId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTaxMaster Tax { get; set; }
        public virtual MstTransactionType TransactionType { get; set; }
    }
}
