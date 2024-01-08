using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstConstructionType
    {
        public MstConstructionType()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
            MstSlab = new HashSet<MstSlab>();
        }

        public int ConstructionTypeId { get; set; }
        public string ConstructionType { get; set; }
        public string ConstructionTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
        public virtual ICollection<MstSlab> MstSlab { get; set; }
    }
}
