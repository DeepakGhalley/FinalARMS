using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstOccupation
    {
        public MstOccupation()
        {
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int OccupationId { get; set; }
        public string Occupation { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
