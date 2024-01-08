using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBuildingColour
    {
        public MstBuildingColour()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int BuildingColourId { get; set; }
        public string BuildingColourType { get; set; }
        public string BuildingColourDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
