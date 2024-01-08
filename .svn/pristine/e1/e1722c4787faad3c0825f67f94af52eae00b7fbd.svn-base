using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class AttributeVM
    {
    }

    public partial class AttributeUnitMapModel
    {
        public int AttributeUnitMapId { get; set; }
        [Display(Name = "Asset Attribute")]
        public int AssetAttributeId { get; set; }
        [Display(Name = "Measurement Unit")]
        public int MeasurementUnitId { get; set; }
        [Display(Name ="Attribute Unit Map Name")]
        public string AttributeUnitMapName { get; set; }
        [Display(Name = "Attribute Unit Map Description")]
        public string AttributeUnitMapDescription { get; set; }
        public string DetailTechnicalAttributeName { get; set; }
        public string MeasurementUnitName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstDetailTechnicalAttribute DetailTechnicalAttribute { get; set; }
        public virtual MstMeasurementUnit MeasurementUnit { get; set; }
    }

    public partial class DetailTechnicalAttributeModel
    {
        public DetailTechnicalAttributeModel()
        {
            MstAttributeUnitMap = new HashSet<MstAttributeUnitMap>();
        }

        public int DetailTechnicalAttributeId { get; set; }
        [Display(Name = "Technical Attribute")]
        public int TechnicalAttributeId { get; set; }
        [Display(Name = "Detail Technical Attribute")]
        public string DetailTechnicalAttribute { get; set; }
        [Display(Name = "Detail Technical Attribute Description")]
        public string DetailTechnicalAttributeDescription { get; set; }
        public string TechnicalAttributeName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTechnicalAttribute TechnicalAttribute { get; set; }
        public virtual ICollection<MstAttributeUnitMap> MstAttributeUnitMap { get; set; }
    }

    public partial class TechnicalAttributeModel
    {
        public TechnicalAttributeModel()
        {
            MstDetailTechnicalAttribute = new HashSet<MstDetailTechnicalAttribute>();
        }

        public int TechnicalAttributeId { get; set; }
        [Display(Name = "Parent Attribute")]
        public int ParentAttributeId { get; set; }
        public string TertiaryAccountHeadName { get; set; }
        [Display(Name = "Technical Attribute")]
        public string TechnicalAttribute { get; set; }
        [Display(Name = "Technical Attribute Description")]
        public string TechnicalAttributeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTertiaryAccountHead TertiaryAccountHead { get; set; }
        public virtual ICollection<MstDetailTechnicalAttribute> MstDetailTechnicalAttribute { get; set; }
    }
}
