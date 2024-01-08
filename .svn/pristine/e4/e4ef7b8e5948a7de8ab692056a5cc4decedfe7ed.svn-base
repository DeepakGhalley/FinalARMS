using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLandServiceType
    {
        public MstLandServiceType()
        {
            TrnLandFeeDetail = new HashSet<TrnLandFeeDetail>();
        }

        public int LandServiceTypeId { get; set; }
        public string LandServiceType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TrnLandFeeDetail> TrnLandFeeDetail { get; set; }
    }
}
