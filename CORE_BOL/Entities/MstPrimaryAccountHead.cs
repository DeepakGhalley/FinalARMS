using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstPrimaryAccountHead
    {
        public MstPrimaryAccountHead()
        {
            MstSecondaryAccountHead = new HashSet<MstSecondaryAccountHead>();
        }

        public int PrimaryAccountHeadId { get; set; }
        public string PrimaryAccountHeadName { get; set; }
        public string PrimaryAccountHeadCode { get; set; }
        public string PrimaryAccountHeadDescription { get; set; }
        public string PrimaryAccountHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstSecondaryAccountHead> MstSecondaryAccountHead { get; set; }
    }
}
