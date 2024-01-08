using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
   
    public partial class WaterLineTypesModel
    {
        public IEnumerable<MstWaterLineType> WaterLineTypes { get; set; }
        public int WaterLineTypeId { get; set; }
        [Display(Name = "Type")]
        public string WaterLineType { get; set; }
        
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
