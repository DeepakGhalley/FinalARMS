using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblComplainDetail
    {
        public TblComplainDetail()
        {
            TblComplainReading = new HashSet<TblComplainReading>();
        }

        public long ComplainDetailId { get; set; }
        public int WaterConnectionId { get; set; }
        public int ComplainTypeId { get; set; }
        public int ComplainStatusId { get; set; }
        public string Instruction { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public int? ComplainReviewedBy { get; set; }
        public string ComplainReviewRemarks { get; set; }
        public DateTime? ComplainReviewedOn { get; set; }
        public int? ComplainRejectedBy { get; set; }
        public string ComplainRejectRemarks { get; set; }
        public DateTime? ComplainRejectedOn { get; set; }
        public int? ComplainApprovedBy { get; set; }
        public string ComplainApprovalRemarks { get; set; }
        public DateTime? ComplainApprovedOn { get; set; }

        public virtual EnumComplainStatus ComplainStatus { get; set; }
        public virtual EnumComplainType ComplainType { get; set; }
        public virtual MstWaterConnection WaterConnection { get; set; }
        public virtual ICollection<TblComplainReading> TblComplainReading { get; set; }
    }
}
