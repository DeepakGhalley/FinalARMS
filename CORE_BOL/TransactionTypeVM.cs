using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class TransactionTypeVM
    {
        //public MstTransactionType()
        //{
        //    MstProcessLevel = new HashSet<MstProcessLevel>();
        //    MstTaxPeriod = new HashSet<MstTaxPeriod>();
        //    MstTransactionTypeTaxMap = new HashSet<MstTransactionTypeTaxMap>();
        //    TblTransactionDetail = new HashSet<TblTransactionDetail>();
        //}

        public int TransactionTypeId { get; set; }
        [Display(Name = "Transaction Type")]
        [Required]
        public string TransactionType { get; set; }
        [Display(Name = "Transaction Type Description")]
        public string TransactionTypeDescription { get; set; }
        [Display(Name = "Section")]
        [Required]
        public int SectionId { get; set; }
        [Display(Name = "Node")]
        [Required]
        public string Node { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Section Name")]
   
        public string SectionName { get; set; }
        [Display(Name = "HasApproval Process")]
        public bool HasApprovalProcess { get; set; }

        public virtual MstSection Section { get; set; }
        public virtual ICollection<MstProcessLevel> MstProcessLevel { get; set; }
        public virtual ICollection<MstTaxPeriod> MstTaxPeriod { get; set; }
        public virtual ICollection<MstTransactionTypeTaxMap> MstTransactionTypeTaxMap { get; set; }
        public virtual ICollection<TblTransactionDetail> TblTransactionDetail { get; set; }
    }
}
