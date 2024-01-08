using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class WaterMeterTypesVM
    {
    }
    public partial class WaterMeterTypesModel
    {
        public IEnumerable<MstWaterMeterType> WaterMeterTypesVM { get; set; }
        public int WaterMeterTypeId{ get; set; }
        [Display(Name = "Type")]
        public string WaterMeterType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

