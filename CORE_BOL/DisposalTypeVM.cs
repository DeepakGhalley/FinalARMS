using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class DisposalTypeVM
    {
    }
    public partial class DisposalTypeModel
    {
        public IEnumerable<MstDisposalType> DisposalTypeList { get; set; }
        public int DisposalTypeId { get; set; }
        [Display(Name = "Disposal Type")]
        public string DisposalType { get; set; }
        [Display(Name = "Disposal Type Description")]
        public string DisposalTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
