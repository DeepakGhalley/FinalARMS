using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstZone
    {
        public MstZone()
        {
            MstAsset = new HashSet<MstAsset>();
            MstWaterConnection = new HashSet<MstWaterConnection>();
            TblWaterMeterReading = new HashSet<TblWaterMeterReading>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
        }

        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneReader { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstAsset> MstAsset { get; set; }
        public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual ICollection<TblWaterMeterReading> TblWaterMeterReading { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
    }
}
