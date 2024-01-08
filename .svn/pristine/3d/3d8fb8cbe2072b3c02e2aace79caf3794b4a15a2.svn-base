using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumLeaseType
    {
        public EnumLeaseType()
        {
            TblLandLease = new HashSet<TblLandLease>();
        }

        public int LeaseTypeId { get; set; }
        public string LeaseType { get; set; }

        public virtual ICollection<TblLandLease> TblLandLease { get; set; }
    }
}
