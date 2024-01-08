using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class WaterConnectionTypesVM
    {
    }
    public partial class WaterConnectionTypesModel
    {
        public IEnumerable<MstWaterMeterType> WaterConnectionTypesVM { get; set; }
        public int WaterConnectionTypeId { get; set; }
        [Display(Name = "Type")]
        public string WaterConnectionType { get; set; }
        
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

