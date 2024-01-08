using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLap
    {
        public MstLap()
        {
            MstAsset = new HashSet<MstAsset>();
            MstLandDetail = new HashSet<MstLandDetail>();
            TrnLandDetail = new HashSet<TrnLandDetail>();
        }

        public int LapId { get; set; }
        public string LapName { get; set; }
        public string LapDescription { get; set; }
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
