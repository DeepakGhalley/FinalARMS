using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class BuildingUnitClassVM
    {
    }

    public partial class BuildingUnitClassModel
    {
        public IEnumerable<MstBuildingUnitClass> BuildingUnitClassList { get; set; }
        public int BuildingUnitClassId { get; set; }
        [Display(Name = "Building Unit Class Name")]
        public string BuildingUnitClassName { get; set; }
        [Display(Name = "Building Unit Class Description")]
        public string BuildingUnitClassDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
