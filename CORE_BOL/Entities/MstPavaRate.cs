using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstPavaRate
    {
        public int PavaRateId { get; set; }
        public int LandUseSubCategoryId { get; set; }
        public decimal LandValue { get; set; }
        public DateTime ApplicableDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstLandUseSubCategory LandUseSubCategory { get; set; }
    }
}
