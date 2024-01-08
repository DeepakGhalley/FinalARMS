using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBankBranch
    {
        public MstBankBranch()
        {
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
            TblPaymentLeger = new HashSet<TblPaymentLeger>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int BankBranchId { get; set; }
        public int BankId { get; set; }
        public string BranchName { get; set; }
        public string BranchOfficeAddress { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstBank Bank { get; set; }
        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual ICollection<TblPaymentLeger> TblPaymentLeger { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
