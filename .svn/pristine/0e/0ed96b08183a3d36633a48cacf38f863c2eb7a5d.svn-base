using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstDetailHead
    {
        public MstDetailHead()
        {
            MstTaxMaster = new HashSet<MstTaxMaster>();
        }

        public int DetailHeadId { get; set; }
        public int MinorHeadId { get; set; }
        public string DetailHeadName { get; set; }
        public string DetailHeadCode { get; set; }
        public string DetailHeadDescription { get; set; }
        public string DetailHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstMinorHead MinorHead { get; set; }
        public virtual ICollection<MstTaxMaster> MstTaxMaster { get; set; }
    }
}
