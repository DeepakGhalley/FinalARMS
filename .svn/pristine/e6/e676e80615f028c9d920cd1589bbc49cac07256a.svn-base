using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblStallDetail
    {
        public TblStallDetail()
        {
            TblStallAllocation = new HashSet<TblStallAllocation>();
        }

        public int StallDetailId { get; set; }
        public int StallLocationId { get; set; }
        public string StallNo { get; set; }
        public string StallName { get; set; }
        public decimal StallArea { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? StallTypeId { get; set; }

        public virtual MstStallLocation StallLocation { get; set; }
        public virtual MstStallType StallType { get; set; }
        public virtual ICollection<TblStallAllocation> TblStallAllocation { get; set; }
    }
}
