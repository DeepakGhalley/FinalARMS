using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumBillingSchedule
    {
        public EnumBillingSchedule()
        {
            EnumDemandGenerateSchedule = new HashSet<EnumDemandGenerateSchedule>();
            TblHouseAllocation = new HashSet<TblHouseAllocation>();
            TblLandLease = new HashSet<TblLandLease>();
            TblParkingfeeDetail = new HashSet<TblParkingfeeDetail>();
            TblStallAllocation = new HashSet<TblStallAllocation>();
        }

        public int BillingScheduleId { get; set; }
        public string BillingSchedule { get; set; }

        public virtual ICollection<EnumDemandGenerateSchedule> EnumDemandGenerateSchedule { get; set; }
        public virtual ICollection<TblHouseAllocation> TblHouseAllocation { get; set; }
        public virtual ICollection<TblLandLease> TblLandLease { get; set; }
        public virtual ICollection<TblParkingfeeDetail> TblParkingfeeDetail { get; set; }
        public virtual ICollection<TblStallAllocation> TblStallAllocation { get; set; }
    }
}
