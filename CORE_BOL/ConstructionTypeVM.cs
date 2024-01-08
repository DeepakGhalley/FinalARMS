using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class ConstructionTypeVM
    {
    }
    public partial class ConstructionTypeModel
    {
        public IEnumerable<MstConstructionType> ConstructionTypeVM { get; set; }
        public int ConstructionTypeId { get; set; }
        [Display(Name = "Construction Type  ")]

        public string ConstructionType { get; set; }
        [Display(Name = "ConstructionType Description  ")]

        public string ConstructionTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        
    }
}
