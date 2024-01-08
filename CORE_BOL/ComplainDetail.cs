using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class ComplainDetail
    {

        public int ComplainDetailId { get; set; }
        public int WaterConnectionId { get; set; }
        public int ComplainTypeId { get; set; }
        public string ComplainType { get; set; }
        public int ComplainStatusId { get; set; }
        public string ComplainStatus { get; set; }
        public string Instruction { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ComplainReviewedBy { get; set; }
        public string ComplainReviewRemarks { get; set; }
        public DateTime ComplainReviewedOn { get; set; }
        public int ComplainRejectedBy { get; set; }
        public string ComplainRejectRemarks { get; set; }
        public DateTime ComplainRejectedOn { get; set; }
        public int ComplainApprovedBy { get; set; }
        public string ComplainApprovalRemarks { get; set; }
        public DateTime ComplainApprovedOn { get; set; }
        public string PlotNo { get; set; }
        public string ConsumerNo { get; set; }
        public string ZoneName { get; set; }
        public string WaterMeterNo { get; set; }
        public string BillingAddress { get; set; }
        public string TaxPayerName { get; set; }

    }
}
