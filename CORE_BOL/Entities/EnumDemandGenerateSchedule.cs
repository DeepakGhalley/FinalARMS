using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumDemandGenerateSchedule
    {
        public EnumDemandGenerateSchedule()
        {
            TblHouseRentDemandDetail = new HashSet<TblHouseRentDemandDetail>();
            TblLandLeaseDemandDetail = new HashSet<TblLandLeaseDemandDetail>();
            TblParkingFeeDemandDetail = new HashSet<TblParkingFeeDemandDetail>();
            TblStallDetailDemand = new HashSet<TblStallDetailDemand>();
        }

        public int DemandGenerateScheduleId { get; set; }
        public string DemandGenerateSchedule { get; set; }
        public int BillingScheduleId { get; set; }

        public virtual EnumBillingSchedule BillingSchedule { get; set; }
        public virtual ICollection<TblHouseRentDemandDetail> TblHouseRentDemandDetail { get; set; }
        public virtual ICollection<TblLandLeaseDemandDetail> TblLandLeaseDemandDetail { get; set; }
        public virtual ICollection<TblParkingFeeDemandDetail> TblParkingFeeDemandDetail { get; set; }
        public virtual ICollection<TblStallDetailDemand> TblStallDetailDemand { get; set; }
    }
}
