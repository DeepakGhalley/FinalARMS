using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBoundaryType
    {
        public MstBoundaryType()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int BoundaryTypeId { get; set; }
        public string BoundaryType { get; set; }
        public string BoundaryTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
