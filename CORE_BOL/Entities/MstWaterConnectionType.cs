using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstWaterConnectionType
    {
        public MstWaterConnectionType()
        {
            MstWaterConnection = new HashSet<MstWaterConnection>();
            TblWaterBillChangeHistoryNewWaterConnectionType = new HashSet<TblWaterBillChangeHistory>();
            TblWaterBillChangeHistoryOldWaterConnectionType = new HashSet<TblWaterBillChangeHistory>();
            TblWaterMeterReading = new HashSet<TblWaterMeterReading>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
            TrnWaterMeterReading = new HashSet<TrnWaterMeterReading>();
        }

        public int WaterConnectionTypeId { get; set; }
        public string WaterConnectionType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual ICollection<TblWaterBillChangeHistory> TblWaterBillChangeHistoryNewWaterConnectionType { get; set; }
        public virtual ICollection<TblWaterBillChangeHistory> TblWaterBillChangeHistoryOldWaterConnectionType { get; set; }
        public virtual ICollection<TblWaterMeterReading> TblWaterMeterReading { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
        public virtual ICollection<TrnWaterMeterReading> TrnWaterMeterReading { get; set; }
    }
}
