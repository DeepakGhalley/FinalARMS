using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class BankVM
    {
    }
    public partial class BankModel
    {
        public int BankId { get; set; }
        [Display(Name = "Bank Code")]
        public string BankCode { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }

    public partial class BankBranchModel
    {
        public int BankBranchId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        [Display(Name = "Branch Office Address")]
        public string BranchOfficeAddress { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        [Display(Name = "Fax Number")]
        public string FaxNo { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual MstBank Bank { get; set; }
    }
}
