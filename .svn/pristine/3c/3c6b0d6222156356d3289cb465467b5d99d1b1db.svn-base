using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstDemkhong
    {
        public MstDemkhong()
        {
            MstAsset = new HashSet<MstAsset>();
            MstLandDetail = new HashSet<MstLandDetail>();
            TrnLandDetail = new HashSet<TrnLandDetail>();
        }

        public int DemkhongId { get; set; }
        public string DemkhongName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstAsset> MstAsset { get; set; }
        public virtual ICollection<MstLandDetail> MstLandDetail { get; set; }
        public virtual ICollection<TrnLandDetail> TrnLandDetail { get; set; }
    }
}
