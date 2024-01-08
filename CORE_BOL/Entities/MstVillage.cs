using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstVillage
    {
        public MstVillage()
        {
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int VillageId { get; set; }
        public int GewogId { get; set; }
        public string VillageName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstGewog Gewog { get; set; }
        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
