using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{

    public  class ApplicantdetailModel
    {
        public ApplicantdetailModel()
        {
            TblEcdetail = new HashSet<TblEcdetail>();
            TblEcrenewalDetail = new HashSet<TblEcrenewalDetail>();
        }

        public int ApplicantId { get; set; }
        [Display(Name ="CID")]
        public string Cid { get; set; }
        [Display(Name = "Licence No")]
        public string LicenceNo { get; set; }
        [Display(Name = "Applicant Name")]
        public string ApplicantName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Post Box No")]
        public string PostBoxNo { get; set; }
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        [Display(Name = "Fax No")]
        public string FaxNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<TblEcdetail> TblEcdetail { get; set; }
        public virtual ICollection<TblEcrenewalDetail> TblEcrenewalDetail { get; set; }
    }

    public partial class ECDetailModel
    {
        public ECDetailModel()
        {
            TblEcrenewalDetail = new HashSet<TblEcrenewalDetail>();
        }

        public int EcDetailId { get; set; }
        [Display(Name = "Applicant")]
        public int ApplicantId { get; set; }
        [Display(Name = "Activity Type")]
        public int EcActivityTypeId { get; set; }
        [Display(Name = "Industry Type")]
        public int IndustryTypeId { get; set; }
        public decimal Quantity { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Project Status")]
        public int ProjectStatusId { get; set; }
        [Display(Name = "Project Closed By")]
        public int? ProjectClosedBy { get; set; }
        [Display(Name = "Project Closed Date")]
        public DateTime? ProjectCloseDate { get; set; }
        [Display(Name = "Project Closed Remarks")]
        public string ProjectCloseRemarks { get; set; }
        [Display(Name = "Approval Status")]
        public int ApprovalStatusId { get; set; }
        [Display(Name = "Approval Remarks")]
        public string ApprovalRemarks { get; set; }
        [Display(Name = "Approval On")]
        public DateTime? ApprovalOn { get; set; }
        [Display(Name = "Approval By")]
        public int? ApprovedBy { get; set; }
        [Display(Name = "Initial Amount")]
        public decimal InitialAmount { get; set; }
        [Display(Name = "EC Reference ID")]
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ApplicantName { get; set; }
        public string ApprovalStatusName { get; set; }
        public string ActivityType { get; set; }
        public string IndustryTypeName { get; set; }
        public string ProjectStatusName { get; set; }
        public string Cid { get; set; }
        public string LicenceNo { get; set; }
        public string Address { get; set; }
        public string PostBoxNo { get; set; }
        public string ContactNo { get; set; }
        public string FaxNo { get; set; }
        public string Remarks { get; set; }
        public string Ids { get; set; }
        public int DemandId { get; set; }
        public int EcRenewalId { get; set; }
        public DateTime DemandDate { get; set; }
        public string TaxName { get; set; }
        public int DemandNoId { get; set; }
        public byte[] QrImage { get; set; }
        public string DemandNo { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserName { get; set; }
        public decimal TransactionValue { get; set; }
        public decimal DemandAmount { get; set; }


        public virtual MstEcapplicantdetail Applicant { get; set; }
        public virtual EnumApprovalStatus ApprovalStatus { get; set; }
        public virtual MstEcactivityType EcActivityType { get; set; }
        public virtual EnumIndustryType IndustryType { get; set; }
        public virtual EnumProjectStatus ProjectStatus { get; set; }
        public virtual ICollection<TblEcrenewalDetail> TblEcrenewalDetail { get; set; }
    }

    public partial class ECRenewalDetailModel
    {
        public int EcRenewalId { get; set; }
        [Display(Name = "EC Detail")]
        public int EcDetailId { get; set; }
        [Display(Name = "EC Use Type")]
        public int EcUseTypeId { get; set; }
        
        [Display(Name = "Valid upto")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ValidUpTo { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "EC Ref No")]
        public string EcRefNo { get; set; }
        public int EcSl { get; set; }
        [Display(Name = "Calendar Year")]
        public int CalendarYear { get; set; }
        public string Remarks { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ECdetailName { get; set; }
        public string ECdUSeTypeName { get; set; }
        public string ActivityType { get; set; }
        public string ApplicantName { get; set; }
        public string IndustryTypeName { get; set; }
        public string Cid { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime EndDate { get; set; }
        public int ApplicantId { get; set; }
        public int FinancialYearId { get; set; }
        public string demandNo { get; set; }
        public int DemandNoId { get; set; }




        public virtual TblEcdetail EcDetail { get; set; }
        public virtual EnumEcuseType EcUseType { get; set; }
        public virtual MstEcapplicantdetail ApplicantDetail { get; set; }
        public virtual EnumApprovalStatus ApprovalStatus { get; set; }
        public virtual MstEcactivityType EcActivityType { get; set; }
        public virtual EnumIndustryType IndustryType { get; set; }
        public virtual EnumProjectStatus ProjectStatus { get; set; }
    }

    public class MultiViewModel
    {
        public MstEcapplicantdetail Applicant { get; set; }
        public TblEcdetail Ecdetail { get; set; }
    }

}
