using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLandUseCategory
    {
        public MstLandUseCategory()
        {
            MstLandUseSubCategory = new HashSet<MstLandUseSubCategory>();
        }

        public int LandUseCategoryId { get; set; }
        public string LandUseCategory { get; set; }
        public string LandUseCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstLandUseSubCategory> MstLandUseSubCategory { get; set; }
    }
}
