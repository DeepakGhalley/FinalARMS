using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstStructureCategory
    {
        public MstStructureCategory()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int StructureCategoryId { get; set; }
        public string StructureCategory { get; set; }
        public string StructureCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
