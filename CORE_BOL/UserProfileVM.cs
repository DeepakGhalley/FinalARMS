using CORE_BOL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class UserProfileVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; } 
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNo { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Cid { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("DOB")]
        public DateTime Dob { get; set; }
        public string Eid { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; } 
        public string Title { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string Password { get; set; }
        
    }
}

