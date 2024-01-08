using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumWaterConnectionStatus
    {
        public EnumWaterConnectionStatus()
        {
            MstWaterConnection = new HashSet<MstWaterConnection>();
            TblWaterMeterReading = new HashSet<TblWaterMeterReading>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
            TrnWaterMeterReading = new HashSet<TrnWaterMeterReading>();
        }

        public int WaterConnectionStatusId { get; set; }
        public string WaterConnectionStatus { get; set; }

        public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual ICollection<TblWaterMeterReading> TblWaterMeterReading { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
        public virtual ICollection<TrnWaterMeterReading> TrnWaterMeterReading { get; set; }
    }
}
