using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumGender
    {
        public EnumGender()
        {
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int GenderId { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
