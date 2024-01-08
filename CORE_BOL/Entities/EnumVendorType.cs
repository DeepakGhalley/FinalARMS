using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumVendorType
    {
        public EnumVendorType()
        {
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
        }

        public int VendorTypeId { get; set; }
        public string VendorType { get; set; }

        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
    }
}
