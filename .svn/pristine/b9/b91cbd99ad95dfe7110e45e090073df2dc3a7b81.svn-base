using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstFloorName
    {
        public MstFloorName()
        {
            MstBuildingUnitDetail = new HashSet<MstBuildingUnitDetail>();
        }

        public int FloorNameId { get; set; }
        public string FloorName { get; set; }
        public string FloorNameDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstBuildingUnitDetail> MstBuildingUnitDetail { get; set; }
    }
}
