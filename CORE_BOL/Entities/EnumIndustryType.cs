using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumIndustryType
    {
        public EnumIndustryType()
        {
            TblEcdetail = new HashSet<TblEcdetail>();
        }

        public int IndustryTypeId { get; set; }
        public string IndustryTypeName { get; set; }

        public virtual ICollection<TblEcdetail> TblEcdetail { get; set; }
    }
}
