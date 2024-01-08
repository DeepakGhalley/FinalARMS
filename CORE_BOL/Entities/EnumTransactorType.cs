using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumTransactorType
    {
        public EnumTransactorType()
        {
            TrnLandDetail = new HashSet<TrnLandDetail>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int TransactorTypeId { get; set; }
        public string TransactorType { get; set; }

        public virtual ICollection<TrnLandDetail> TrnLandDetail { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
