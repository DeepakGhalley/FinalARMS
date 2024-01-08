using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTransactionType
    {
        public MstTransactionType()
        {
            MstProcessLevel = new HashSet<MstProcessLevel>();
            MstTaxPeriod = new HashSet<MstTaxPeriod>();
            MstTransactionTypeTaxMap = new HashSet<MstTransactionTypeTaxMap>();
            TblTransactionDetail = new HashSet<TblTransactionDetail>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionTypeDescription { get; set; }
        public int SectionId { get; set; }
        public string Node { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool HasApprovalProcess { get; set; }

        public virtual MstSection Section { get; set; }
        public virtual ICollection<MstProcessLevel> MstProcessLevel { get; set; }
        public virtual ICollection<MstTaxPeriod> MstTaxPeriod { get; set; }
        public virtual ICollection<MstTransactionTypeTaxMap> MstTransactionTypeTaxMap { get; set; }
        public virtual ICollection<TblTransactionDetail> TblTransactionDetail { get; set; }
    }
}
