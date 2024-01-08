using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstDesignation
    {
        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public int SectionId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstSection Section { get; set; }
    }
}
