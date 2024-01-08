using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumUnitOwnerType
    {
        public EnumUnitOwnerType()
        {
            MstBuildingUnitDetail = new HashSet<MstBuildingUnitDetail>();
        }

        public int UnitOwnerTypeId { get; set; }
        public string UnitOwnerType { get; set; }

        public virtual ICollection<MstBuildingUnitDetail> MstBuildingUnitDetail { get; set; }
    }
}
