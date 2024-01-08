using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstDzongkhag
    {
        public MstDzongkhag()
        {
            MstGewog = new HashSet<MstGewog>();
            MstTaxPayerProfile = new HashSet<MstTaxPayerProfile>();
            TrnTaxPayerInformation = new HashSet<TrnTaxPayerInformation>();
        }

        public int DzongkhagId { get; set; }
        public string DzongkhagName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstGewog> MstGewog { get; set; }
        public virtual ICollection<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual ICollection<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
    }
}
