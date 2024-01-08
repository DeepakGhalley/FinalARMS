using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class FloorNameModel
    {
        public int FloorNameId { get; set; }
        [Display(Name = "Floor Name")]
        public string FloorName { get; set; }
        [Display(Name = "Floor Description")]
        public string FloorNameDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<MstFloorName> floorNames { get; set; }

    }
}
