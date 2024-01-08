using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstEcactivityType
    {
        public MstEcactivityType()
        {
            TblEcdetail = new HashSet<TblEcdetail>();
        }

        public int EcActivityTypeId { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<TblEcdetail> TblEcdetail { get; set; }
    }
}
