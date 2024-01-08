﻿using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblEcdetail
    {
        public TblEcdetail()
        {
            TblEcrenewalDetail = new HashSet<TblEcrenewalDetail>();
        }

        public int EcDetailId { get; set; }
        public int ApplicantId { get; set; }
        public int EcActivityTypeId { get; set; }
        public int IndustryTypeId { get; set; }
        public decimal Quantity { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ProjectStatusId { get; set; }
        public int? ProjectClosedBy { get; set; }
        public DateTime? ProjectCloseDate { get; set; }
        public string ProjectCloseRemarks { get; set; }
        public int? ApprovalStatusId { get; set; }
        public string ApprovalRemarks { get; set; }
        public DateTime? ApprovalOn { get; set; }
        public int? ApprovedBy { get; set; }
        public decimal InitialAmount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstEcapplicantdetail Applicant { get; set; }
        public virtual EnumApprovalStatus ApprovalStatus { get; set; }
        public virtual MstEcactivityType EcActivityType { get; set; }
        public virtual EnumIndustryType IndustryType { get; set; }
        public virtual EnumProjectStatus ProjectStatus { get; set; }
        public virtual ICollection<TblEcrenewalDetail> TblEcrenewalDetail { get; set; }
    }
}
