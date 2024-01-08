using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumComplainStatus
    {
        public EnumComplainStatus()
        {
            TblComplainDetail = new HashSet<TblComplainDetail>();
        }

        public int ComplainStatusId { get; set; }
        public string ComplainStatus { get; set; }

        public virtual ICollection<TblComplainDetail> TblComplainDetail { get; set; }
    }
}
