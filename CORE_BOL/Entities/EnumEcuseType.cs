using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumEcuseType
    {
        public EnumEcuseType()
        {
            TblEcrenewalDetail = new HashSet<TblEcrenewalDetail>();
        }

        public int EcUseTypeId { get; set; }
        public string EcUseType { get; set; }

        public virtual ICollection<TblEcrenewalDetail> TblEcrenewalDetail { get; set; }
    }
}
