using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class AssetAttributeVM
    {
        public int AssetAttributeId { get; set; }
        [Display(Name = "Parent Attribute ID")]
        public int ParentAttributeId { get; set; }
        [Display(Name = "Parent Attribute Name")]
        public string ParentAttributeName { get; set; }
        [Display(Name = "Attribute Name")]
        public string AttributeName { get; set; }
        [Display(Name = "Attribute Description")]

        public string AttributeDescription { get; set; }
        [Display(Name = "Value Required")]

        public bool ValueRequired { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstParentAttribute ParentAttribute { get; set; }
        //public virtual ICollection<TblTechnicalAttributeDetail> TblTechnicalAttributeDetail { get; set; }
    }
}
