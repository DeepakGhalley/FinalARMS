using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstDivision
    {
        public MstDivision()
        {
            MstSection = new HashSet<MstSection>();
            MstUser = new HashSet<MstUser>();
        }

        public int DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstSection> MstSection { get; set; }
        public virtual ICollection<MstUser> MstUser { get; set; }
    }
}
