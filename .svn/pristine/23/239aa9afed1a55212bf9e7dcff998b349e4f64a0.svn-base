using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstMinorHead
    {
        public MstMinorHead()
        {
            MstDetailHead = new HashSet<MstDetailHead>();
        }

        public int MinorHeadId { get; set; }
        public int MajorHeadId { get; set; }
        public string MinorHeadName { get; set; }
        public string MinorHeadCode { get; set; }
        public string MinorHeadDescription { get; set; }
        public string MinorHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstMajorHead MajorHead { get; set; }
        public virtual ICollection<MstDetailHead> MstDetailHead { get; set; }
    }
}
