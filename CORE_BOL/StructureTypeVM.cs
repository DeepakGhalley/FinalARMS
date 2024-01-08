using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class StructureTypeVm
    {
    }
    public partial class StructureTypeModel
    {
        public IEnumerable<MstStructureType> StructureTypeVm { get; set; }
        public int StructureTypeId { get; set; }
        [Display(Name = "Structure Type  ")]

        public string StructureType { get; set; }
        [Display(Name = "StructureType Description  ")]

        public string StructureTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        
    }
}
