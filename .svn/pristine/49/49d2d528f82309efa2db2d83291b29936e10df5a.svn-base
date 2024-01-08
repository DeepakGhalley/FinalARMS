using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumTitle
    {
        public EnumTitle()
        {
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
            MstUser = new HashSet<MstUser>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int TitleId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual ICollection<MstUser> MstUser { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
