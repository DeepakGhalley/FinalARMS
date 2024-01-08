using CORE_BOL.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace CORE_BOL
{
    public partial class TaxPayerProfileModel
    {
       

        public int TaxPayerId { get; set; }
        [Required]
        [Display(Name = "Tax Payer Type")]
        public int TaxPayerTypeId { get; set; }
        [Display(Name = "Tax Payer Type")]
        public string TaxPayerType { get; set; }
        [Display(Name = "TTIN")]
        public string Ttin { get; set; }
        public int VendorTypeId { get; set; }
        //[Required]
        [Display(Name = "CID")]
        public string Cid { get; set; }
        [Display(Name = "TPN")]
        public string Tpn { get; set; }
        //[Required]
        [Display(Name = "Title")]
        public int TitleId { get; set; }
        [Display(Name = "Title Name")]
        public string Title { get; set; }
        //[Required]
        [Display(Name ="First Name")]      
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Dob { get; set; }
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name ="Village")]
        public int PVillageId { get; set; }
        [Display(Name ="Village Name")]
        public string VillageName { get; set; }
        [Display(Name = "Dzongkhag")]
        public int CDzongkhagId { get; set; }
        [Display(Name = "Dzongkhag Name")]
        public string DzongkhagName { get; set; }
        [Display(Name = "Address")]
        public string CAddress { get; set; }
        [Display(Name = "Occupation")]
        public int OccupationId { get; set; }
        [Display(Name = "Occuaption")]
        public string Occupation { get; set; }
        [Display(Name = "Working Agency")]
        public string WorkingAgency { get; set; }
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }
        [Display(Name = "OrgPhone")]
        public string OrgPhone { get; set; }
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [Display(Name = "Org Email")]
        public string OrgEmail { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Bank Account No")]
        public string BankAccountNo { get; set; }
        [Display(Name = "Bank Branch")]
        public int? BankBranchId { get; set; }
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; } 
        public string PlotNo { get; set; } 
        public string ThramNo { get; set; } 
        public int StallDetailId { get; set; }
        public string Name { get; set; }       
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public int DzongkhagId { get; set; }
        public int LandOwnershipId { get; set; }
        
        public int GewogId { get; set; }
        public int? BankId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public virtual MstVillage Villages { get; set; }
        public virtual MstDzongkhag Dzongkhags { get; set; }
        public virtual MstGewog Gewogs { get; set; }
        public virtual MstBank Banks { get; set; }
        public virtual ICollection<MstOccupation> Occupations { get; set; }
        public virtual ICollection<MstBankBranch> BankBranches { get; set; }
        //public virtual ICollection<EnumTaxPayerType> TaxpayerType { get; set; }
        public virtual ICollection<EnumGender> Genders { get; set; }
        public virtual ICollection<EnumTitle> Titles { get; set; }

        
    }
}