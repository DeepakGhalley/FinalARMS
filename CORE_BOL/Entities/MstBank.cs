using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBank
    {
        public MstBank()
        {
            MstBankBranch = new HashSet<MstBankBranch>();
        }

        public int BankId { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstBankBranch> MstBankBranch { get; set; }
    }
}
