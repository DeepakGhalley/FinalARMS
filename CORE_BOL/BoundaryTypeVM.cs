using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class BoundaryTypeVM
    {
    }
    public partial class BoundaryTypeModel
    {

        public int BoundaryTypeId { get; set; }
        [Display(Name = "Boundary Type ")]
        public string BoundaryType { get; set; }
        [Display(Name = "BoundaryType Description ")]

        public string BoundaryTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<MstBoundaryType> BoundaryTypeVM { get; set; }

    }
}