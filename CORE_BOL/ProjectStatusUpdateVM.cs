using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ProjectStatusUpdateVM
    {
        public int EcDetailId { get; set; }
        //[Display(Name = "Applicant")]
        //public int ApplicantId { get; set; }
        //[Display(Name = "Activity Type")]
        //public int EcActivityTypeId { get; set; }
        //[Display(Name = "Industry Type")]
        //public int IndustryTypeId { get; set; }
        //public decimal Quantity { get; set; }
        //[Display(Name = "Project Name")]
        //public string ProjectName { get; set; }
        //[Display(Name = "Start Date")]
        //public DateTime StartDate { get; set; }
        //[Display(Name = "End Date")]
        //public DateTime EndDate { get; set; }
        //[Display(Name = "Project Status")]
        //public int ProjectStatusId { get; set; }
        [Display(Name = "Project Closed By")]
        public int? ProjectClosedBy { get; set; }
        [Display(Name = "Project Closed Date")]
        public DateTime? ProjectCloseDate { get; set; }
        [Display(Name = "Project Closed Remarks")]
        public string ProjectCloseRemarks { get; set; }
        //[Display(Name = "Approval Status")]
        //public int ApprovalStatusId { get; set; }
        //[Display(Name = "Approval Remarks")]
        //public string ApprovalRemarks { get; set; }
        //[Display(Name = "Approval On")]
        //public DateTime? ApprovalOn { get; set; }
        //[Display(Name = "Approval By")]
        //public int? ApprovedBy { get; set; }
        //[Display(Name = "Initial Amount")]
        //public decimal InitialAmount { get; set; }
        //[Display(Name = "EC Reference ID")]
        //public int CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public DateTime? ModifiedOn { get; set; }
        //public int? ModifiedBy { get; set; }
        //public string ApplicantName { get; set; }
        //public string ApprovalStatusName { get; set; }
        //public string ActivityType { get; set; }
        //public string IndustryTypeName { get; set; }
        //public string ProjectStatusName { get; set; }
        //public string Cid { get; set; }
        //public string LicenceNo { get; set; }
        //public string Address { get; set; }
        //public string PostBoxNo { get; set; }
        //public string ContactNo { get; set; }
        //public string FaxNo { get; set; }



        //public virtual MstEcapplicantdetail Applicant { get; set; }
        //public virtual EnumApprovalStatus ApprovalStatus { get; set; }
        //public virtual MstEcactivityType EcActivityType { get; set; }
        //public virtual EnumIndustryType IndustryType { get; set; }
        //public virtual EnumProjectStatus ProjectStatus { get; set; }
        //public virtual ICollection<TblEcrenewalDetail> TblEcrenewalDetail { get; set; }
    }
}

