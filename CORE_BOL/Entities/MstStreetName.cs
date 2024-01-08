using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstStreetName
    {
        public MstStreetName()
        {
            MstLandDetail = new HashSet<MstLandDetail>();
            TrnLandDetail = new HashSet<TrnLandDetail>();
        }

        public int StreetNameId { get; set; }
        public string StreetName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstLandDetail> MstLandDetail { get; set; }
        public virtual ICollection<TrnLandDetail> TrnLandDetail { get; set; }
    }
}
