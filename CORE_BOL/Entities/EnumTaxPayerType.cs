using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumTaxPayerType
    {
        public EnumTaxPayerType()
        {
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int TaxPayerTypeId { get; set; }
        public string TaxPayerType { get; set; }

        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
