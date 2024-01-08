using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstMaterialType
    {
        public MstMaterialType()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int MaterialTypeId { get; set; }
        public string MaterialType { get; set; }
        public string MaterialTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
