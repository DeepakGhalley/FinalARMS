using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class InspectionTypeVM
    {
    }
    public partial class InspectionTypeMode
    {
        public IEnumerable<MstInspectionType> InspectionTypeVM { get; set; }
        public int InspectionTypeId { get; set; }
        [Display(Name = "Inspection Type")]
        public string InspectionType { get; set; }
        [Display(Name = "Description")]
        public string InspectionTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
