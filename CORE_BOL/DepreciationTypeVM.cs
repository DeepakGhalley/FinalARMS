using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class DepreciationTypeVM
    {
    }
    public partial class DepreciationTypeModel
    {
        public IEnumerable<MstDepreciationType> DepreciationTypeList { get; set; }
        public int DepreciationTypeId { get; set; }
        [Display(Name = "Depreciation Type")]
        public string DepreciationType { get; set; }
        [Display(Name = "Depreciation Type Description")]
        public string DepreciationTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
