using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstSecondaryAccountHead
    {
        public MstSecondaryAccountHead()
        {
            MstTertiaryAccountHead = new HashSet<MstTertiaryAccountHead>();
        }

        public int SecondaryAccountHeadId { get; set; }
        public int PrimaryAccountHeadId { get; set; }
        public string SecondaryAccountHeadName { get; set; }
        public string SecondaryaccountHeadCode { get; set; }
        public string SecondaryaccountHeadDescription { get; set; }
        public string SecondaryaccountHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstPrimaryAccountHead PrimaryAccountHead { get; set; }
        public virtual ICollection<MstTertiaryAccountHead> MstTertiaryAccountHead { get; set; }
    }
}
