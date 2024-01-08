using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblEsakorThramJointOwnerDetail
    {
        public int ESakorThramOwnerDetailId { get; set; }
        public long ApplicationId { get; set; }
        public string TransactionType { get; set; }
        public string ThramNo { get; set; }
        public string OwnerCid { get; set; }
        public string OwnName { get; set; }
        public string OwnerStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? ApprovalStatus { get; set; }
        public DateTime? ApprovedOrRejectOn { get; set; }
        public int? ApprovedRejectedBy { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string TransactionFee { get; set; }
    }
}
