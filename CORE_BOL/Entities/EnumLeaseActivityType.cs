using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumLeaseActivityType
    {
        public EnumLeaseActivityType()
        {
            TblLandLease = new HashSet<TblLandLease>();
        }

        public int LeaseActivityTypeId { get; set; }
        public string LeaseActivity { get; set; }

        public virtual ICollection<TblLandLease> TblLandLease { get; set; }
    }
}
