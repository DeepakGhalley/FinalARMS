using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumWaterTankLocation
    {
        public EnumWaterTankLocation()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int WaterTankLocationId { get; set; }
        public string WaterTankLocation { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
