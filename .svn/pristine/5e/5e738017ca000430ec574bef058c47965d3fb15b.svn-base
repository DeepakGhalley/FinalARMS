using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstStallLocation
    {
        public MstStallLocation()
        {
            TblStallDetail = new HashSet<TblStallDetail>();
        }

        public int StallLocationId { get; set; }
        public string StallLocation { get; set; }
        public string StallLocationDetail { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<TblStallDetail> TblStallDetail { get; set; }
    }
}
