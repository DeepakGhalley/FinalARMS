using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLandType
    {
        public MstLandType()
        {
            MstLandDetail = new HashSet<MstLandDetail>();
            TrnLandDetail = new HashSet<TrnLandDetail>();
        }

        public int LandTypeId { get; set; }
        public string LandTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstLandDetail> MstLandDetail { get; set; }
        public virtual ICollection<TrnLandDetail> TrnLandDetail { get; set; }
    }
}
