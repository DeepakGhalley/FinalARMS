using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class PrecinctVM
    {
    }
    public partial class LandUseCategoryModel
    {
        public int LandUseCategoryId { get; set; }
        [Display(Name = "Name")]
        public string LandUseCategory { get; set; }
        [Display(Name = "Description")]
        public string LandUseCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual ICollection<MstLandUseSubCategory> MstLandUseSubCategory { get; set; }
    }
    public partial class LandUseSubCategoryModel
    {
        public int LandUseSubCategoryId { get; set; }
        [Display(Name = "Land Use Category ID")]
        public int LandUseCategoryId { get; set; }
        [Display(Name = "Land use category name")]
        public string LandUseCategoryName { get; set; }
        [Display(Name = "Land use sub Category")]
        public string LandUseSubCategory { get; set; }
        [Display(Name = "Description")]
        public string LandUseCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstLandUseCategory LandUseCategory { get; set; }
        public virtual ICollection<MstPavaRate> MstPavaRate { get; set; }
    }
}
