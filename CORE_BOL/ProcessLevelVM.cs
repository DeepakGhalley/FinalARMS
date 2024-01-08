using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ProcessLevelModel
    {
        public int ProcessLevelId { get; set; }
        [Display(Name = "Transaction Type")]
        public int? TransactionTypeId { get; set; }
        [Display(Name = "Process 2")]
        public bool Process2Approval { get; set; }
        [Display(Name = "Process 3")]
        public bool Process3Approval { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string TransationTypeName { get; set; }

        public virtual MstTransactionType TransactionType { get; set; }
    }
}
