using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class UpdateECdetailVM
    {
        public int EcDetailId { get; set; }
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
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public decimal InitialAmount { get; set; }

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



        public virtual MstEcapplicantdetail Applicant { get; set; }
        public virtual EnumApprovalStatus ApprovalStatus { get; set; }
        public virtual MstEcactivityType EcActivityType { get; set; }
        public virtual EnumIndustryType IndustryType { get; set; }
        public virtual EnumProjectStatus ProjectStatus { get; set; }
        public virtual ICollection<TblEcrenewalDetail> TblEcrenewalDetail { get; set; }
    }
}
