using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class OrganizationVM
    {
    }
    public partial class DivisionModel
    {
        public IEnumerable<MstDivision> DivisionVM { get; set; }
        public int DivisionId { get; set; }
        [Display(Name = "Division Code")]
        public string DivisionCode { get; set; }
        [Display(Name = "Division Name")]
        public string DivisionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public partial class SectionModel
    {
        public int SectionId { get; set; }
        [Display(Name = "Section CodeCode")]
        public string SectionCode { get; set; }
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }
        [Display(Name = "Division")]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual MstDivision Division { get; set; }
        public virtual ICollection<MstDesignation> MstDesignation { get; set; }
        public IEnumerable<MstSection> SectionVM { get; set; }
    }

    public partial class DesignationModel
    {
        public int DesignationId { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Section")]
        public string SectionName { get; set; }
        public int SectionId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstSection Section { get; set; }
        public IEnumerable<MstDesignation> DesignationVM { get; set; }
    }
}
