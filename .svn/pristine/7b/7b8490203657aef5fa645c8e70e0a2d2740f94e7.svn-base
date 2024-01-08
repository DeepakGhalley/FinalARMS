using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumWaterBillEditReason
    {
        public EnumWaterBillEditReason()
        {
            TblWaterBillChangeHistory = new HashSet<TblWaterBillChangeHistory>();
        }

        public int WaterBillEditReasonId { get; set; }
        public string WaterBillEditReason { get; set; }

        public virtual ICollection<TblWaterBillChangeHistory> TblWaterBillChangeHistory { get; set; }
    }
}
