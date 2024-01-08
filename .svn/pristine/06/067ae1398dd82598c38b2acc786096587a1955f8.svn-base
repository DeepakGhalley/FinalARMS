using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumLandTransferType
    {
        public EnumLandTransferType()
        {
            TrnLandDetail = new HashSet<TrnLandDetail>();
            TrnTaxDetail = new HashSet<TrnTaxDetail>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int LandTransferTypeId { get; set; }
        public string LandTransferType { get; set; }

        public virtual ICollection<TrnLandDetail> TrnLandDetail { get; set; }
        public virtual ICollection<TrnTaxDetail> TrnTaxDetail { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
