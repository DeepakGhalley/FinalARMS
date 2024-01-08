using System;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class BuildingColourVM
    {
    }
    public partial class BuildingColourModel
    {
        public int BuildingColourId { get; set; }
        [Display(Name = "BuildingColour Type ")]
        public string BuildingColourType { get; set; }
        [Display(Name = "BuildingColour Description ")]

        public string BuildingColourDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<MstBuildingColour> BuildingColourVM { get; set; }
    }
}
