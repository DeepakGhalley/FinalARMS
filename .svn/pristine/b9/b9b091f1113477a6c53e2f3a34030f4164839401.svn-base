using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstStallType
    {
        public MstStallType()
        {
            TblStallDetail = new HashSet<TblStallDetail>();
            TblStallDetailDemand = new HashSet<TblStallDetailDemand>();
        }

        public int StallTypeId { get; set; }
        public string StallType { get; set; }

        public virtual ICollection<TblStallDetail> TblStallDetail { get; set; }
        public virtual ICollection<TblStallDetailDemand> TblStallDetailDemand { get; set; }
    }
}
