using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBuildingUnitClass
    {
        public MstBuildingUnitClass()
        {
            MstBuildingUnitDetail = new HashSet<MstBuildingUnitDetail>();
            MstSlab = new HashSet<MstSlab>();
        }

        public int BuildingUnitClassId { get; set; }
        public string BuildingUnitClassName { get; set; }
        public string BuildingUnitClassDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstBuildingUnitDetail> MstBuildingUnitDetail { get; set; }
        public virtual ICollection<MstSlab> MstSlab { get; set; }
    }
}
