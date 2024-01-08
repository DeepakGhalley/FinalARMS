using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumServiceAccessibilityType
    {
        public EnumServiceAccessibilityType()
        {
            MstBuildingDetailGarbagServiceAccessibility = new HashSet<MstBuildingDetail>();
            MstBuildingDetailStreetLightAccessibility = new HashSet<MstBuildingDetail>();
            MstBuildingDetailWaterSupplyAccessibility = new HashSet<MstBuildingDetail>();
        }

        public int ServiceAccessibilityId { get; set; }
        public string ServiceAccessibilityType { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetailGarbagServiceAccessibility { get; set; }
        public virtual ICollection<MstBuildingDetail> MstBuildingDetailStreetLightAccessibility { get; set; }
        public virtual ICollection<MstBuildingDetail> MstBuildingDetailWaterSupplyAccessibility { get; set; }
    }
}
