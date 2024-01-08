using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstProcessLevel
    {
        public int ProcessLevelId { get; set; }
        public int? TransactionTypeId { get; set; }
        public bool? Process2Approval { get; set; }
        public bool? Process3Approval { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTransactionType TransactionType { get; set; }
    }
}
