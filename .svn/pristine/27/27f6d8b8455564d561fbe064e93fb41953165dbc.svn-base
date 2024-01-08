using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblParkingFeePeriod
    {
        public int ParkingFeePeriodId { get; set; }
        public int ParkingFeeDetailId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TblParkingfeeDetail ParkingFeeDetail { get; set; }
    }
}
