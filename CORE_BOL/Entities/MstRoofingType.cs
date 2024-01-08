using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstRoofingType
    {
        public MstRoofingType()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int RoofingTypeId { get; set; }
        public string RoofingType { get; set; }
        public string RoofingTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
