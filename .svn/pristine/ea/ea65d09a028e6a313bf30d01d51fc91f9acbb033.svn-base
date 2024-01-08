using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstUser
    {
        public MstUser()
        {
            MstDcdsignUpload = new HashSet<MstDcdsignUpload>();
            MstEsSignUpload = new HashSet<MstEsSignUpload>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? DivisionId { get; set; }
        public int? SectionId { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Cid { get; set; }
        public string Eid { get; set; }
        public DateTime Dob { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstDivision Division { get; set; }
        public virtual TblRole Role { get; set; }
        public virtual MstSection Section { get; set; }
        public virtual EnumTitle Title { get; set; }
        public virtual ICollection<MstDcdsignUpload> MstDcdsignUpload { get; set; }
        public virtual ICollection<MstEsSignUpload> MstEsSignUpload { get; set; }
    }
}
