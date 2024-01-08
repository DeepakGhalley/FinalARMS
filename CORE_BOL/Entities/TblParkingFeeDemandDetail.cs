using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblParkingFeeDemandDetail
    {
        public TblParkingFeeDemandDetail()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public long ParkingDemandDetailId { get; set; }
        public int ParkingFeeDetailId { get; set; }
        public int DemandYear { get; set; }
        public int DemandGenerateScheduleId { get; set; }
        public long DemandNoId { get; set; }
        public decimal InstallmentAmount { get; set; }
        public DateTime InstallmentDate { get; set; }
        public int DemandDays { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual EnumDemandGenerateSchedule DemandGenerateSchedule { get; set; }
        public virtual TblDemandNo DemandNo { get; set; }
        public virtual TblParkingfeeDetail ParkingFeeDetail { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
