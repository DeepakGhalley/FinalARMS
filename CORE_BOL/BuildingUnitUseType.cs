using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public partial class BuildingUnitUseTypeModel
    {
        public int BuildingUnitUseTypeId { get; set; }
        [Display(Name ="Building Unit Use Type")]
        public string BuildingUnitUseType { get; set; }
        [Display(Name ="Building Unit Use Type Description")]
        public string BuildingUnitUseTypeDescription { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
