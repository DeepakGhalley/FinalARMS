using CORE_BOL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
   public class UserDTO
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public int TitleId { get; set; }
        public int? DivisionId { get; set; }
        public int? SectionId { get; set; }
        //[Required] not requuired in manage urser
        
        [DisplayName("Role")]
        public int RoleId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("CID")]
        public string Cid { get; set; }

        [DisplayName("EID")]
        public string Eid { get; set; }

        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("DOB")]
        public DateTime Dob { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DisplayName("Role")]
        public string RoleName { get; set; }
        public string Title { get; set; }
        public string SectionName { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public IEnumerable<MstUser> UserVM { get; set; }
        //public virtual TblMstRole Role { get; set; }
        public long User { get; set; }


        public string Id { get; set; }
        public string PhoneNo { get; set; }
        
    }
}
