using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class StructureCategoryVM
    {
    }
    public partial class StructureCategoryModel
    {
        public IEnumerable<MstStructureCategory> StructureCategoryVM { get; set; }
        public int StructureCategoryId { get; set; }
        [Display(Name = "Structure Category  ")]

        public string StructureCategory { get; set; }
        [Display(Name = "StructureCategory Description  ")]

        public string StructureCategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        
    }
}
