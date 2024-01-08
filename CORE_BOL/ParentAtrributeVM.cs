using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class ParentAtrributeVM
    {
    }
    public partial class ParentAttributeModel
    {
        //public IEnumerable<MstParentAttribute> ParentAttributeList { get; set; }
        public int ParentAttributeId { get; set; }
        [Display(Name = "Tertiary Account Head ID")]
        public int TertiaryAccountHeadId { get; set; }
        [Display(Name = "Name")]
        public string ParentAttribute { get; set; }
        [Display(Name = "Description")]
        public string ParentAttributeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string TertiaryAccountHeadNames { get; set; }


        public virtual MstTertiaryAccountHead TertiaryAccountHead { get; set; }
    }
}
