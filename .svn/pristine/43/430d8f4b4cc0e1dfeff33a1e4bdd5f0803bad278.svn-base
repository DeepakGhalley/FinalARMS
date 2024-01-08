using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class TransactionTypeTaxMapVM
    {
        public int TransactionTypeTaxMapId { get; set; }
        [Display(Name = "Transaction Type")]

        public int TransactionTypeId { get; set; }
        [Display(Name = "Tax Name")]

        public int TaxId { get; set; }
        [Display(Name = "Is Active")]
                public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string TransactionTypeName { get; set; }
        public string TaxName { get; set; }


        public virtual MstTaxMaster Tax { get; set; }
        public virtual MstTransactionType TransactionType { get; set; }
    }
}
