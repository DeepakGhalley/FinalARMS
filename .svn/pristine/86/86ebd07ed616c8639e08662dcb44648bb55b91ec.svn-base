using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstWaterMeterType
    {
        public MstWaterMeterType()
        {
            MstWaterConnection = new HashSet<MstWaterConnection>();
            TblWaterMeterReading = new HashSet<TblWaterMeterReading>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
            TrnWaterMeterReading = new HashSet<TrnWaterMeterReading>();
        }

        public int WaterMeterTypeId { get; set; }
        public string WaterMeterType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual ICollection<TblWaterMeterReading> TblWaterMeterReading { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
        public virtual ICollection<TrnWaterMeterReading> TrnWaterMeterReading { get; set; }
    }
}
