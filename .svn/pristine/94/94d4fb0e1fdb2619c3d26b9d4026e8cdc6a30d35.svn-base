using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstStructureType
    {
        public MstStructureType()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int StructureTypeId { get; set; }
        public string StructureType { get; set; }
        public string StructureTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
