using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumPropertyType
    {
        public EnumPropertyType()
        {
            MstLandDetail = new HashSet<MstLandDetail>();
            TrnLandDetail = new HashSet<TrnLandDetail>();
        }

        public int PropertyTypeId { get; set; }
        public string PropertyType { get; set; }

        public virtual ICollection<MstLandDetail> MstLandDetail { get; set; }
        public virtual ICollection<TrnLandDetail> TrnLandDetail { get; set; }
    }
}
