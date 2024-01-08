using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class PavaRateVM
    {
    }
        public partial class PavaRateModel
        {
            public IEnumerable<MstPavaRate> PavaRateList { get; set; }
            public int PavaRateId { get; set; }
            public string LandUseSubCategoryName { get; set; }
            [Display(Name = "Land Use Sub Category")]
            public int LandUseSubCategoryId { get; set; }
            [Display(Name = "Land Value")]
            public decimal LandValue { get; set; }
            [Display(Name = "Applicable Date")]
            public DateTime ApplicableDate { get; set; }
            public bool IsActive { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public int? ModifiedBy { get; set; }
            public DateTime? ModifiedOn { get; set; }
            public virtual MstLandUseSubCategory LandUseSubCategory { get; set; }
        }
}
