using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblInaccessibleWaterMeterDetail
    {
        public int InaccessibleWaterMeterDetailId { get; set; }
        public int WaterConnectionId { get; set; }
        public DateTime ReadingDate { get; set; }
        public string Remarks { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstWaterConnection WaterConnection { get; set; }
    }
}
