using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumApprovalStatus
    {
        public EnumApprovalStatus()
        {
            TblEcdetail = new HashSet<TblEcdetail>();
        }

        public int ApprovalStatusId { get; set; }
        public string ApprovalStatus { get; set; }

        public virtual ICollection<TblEcdetail> TblEcdetail { get; set; }
    }
}
