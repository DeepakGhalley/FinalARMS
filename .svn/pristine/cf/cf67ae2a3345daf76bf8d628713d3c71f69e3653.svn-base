using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumOwnerType
    {
        public EnumOwnerType()
        {
            MstWaterConnection = new HashSet<MstWaterConnection>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
        }

        public int OwnerTypeId { get; set; }
        public string OwnerType { get; set; }

        public virtual ICollection<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
    }
}
