using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstMajorHead
    {
        public MstMajorHead()
        {
            MstMinorHead = new HashSet<MstMinorHead>();
        }

        public int MajorHeadId { get; set; }
        public string MajorHeadName { get; set; }
        public string MajorHeadCode { get; set; }
        public string MajorHeadDescription { get; set; }
        public string MajorHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstMinorHead> MstMinorHead { get; set; }
    }
}
