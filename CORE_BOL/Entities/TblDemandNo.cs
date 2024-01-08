using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblDemandNo
    {
        public TblDemandNo()
        {
            TblDemand = new HashSet<TblDemand>();
            TblDemandCancel = new HashSet<TblDemandCancel>();
            TblHouseRentDemandDetail = new HashSet<TblHouseRentDemandDetail>();
            TblLandLeaseDemandDetail = new HashSet<TblLandLeaseDemandDetail>();
            TblParkingFeeDemandDetail = new HashSet<TblParkingFeeDemandDetail>();
            TblStallDetailDemand = new HashSet<TblStallDetailDemand>();
        }

        public long DemandNoId { get; set; }
        public string DemandNo { get; set; }
        public int Sl { get; set; }
        public int DemandYear { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblDemandCancel> TblDemandCancel { get; set; }
        public virtual ICollection<TblHouseRentDemandDetail> TblHouseRentDemandDetail { get; set; }
        public virtual ICollection<TblLandLeaseDemandDetail> TblLandLeaseDemandDetail { get; set; }
        public virtual ICollection<TblParkingFeeDemandDetail> TblParkingFeeDemandDetail { get; set; }
        public virtual ICollection<TblStallDetailDemand> TblStallDetailDemand { get; set; }
    }
}
