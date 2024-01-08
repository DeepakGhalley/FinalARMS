using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumComplainType
    {
        public EnumComplainType()
        {
            TblComplainDetail = new HashSet<TblComplainDetail>();
        }

        public int ComplainTypeId { get; set; }
        public string ComplainType { get; set; }

        public virtual ICollection<TblComplainDetail> TblComplainDetail { get; set; }
    }
}
