using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstGewog
    {
        public MstGewog()
        {
            MstVillage = new HashSet<MstVillage>();
        }

        public int GewogId { get; set; }
        public int DzongkhagId { get; set; }
        public string GewogName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstDzongkhag Dzongkhag { get; set; }
        public virtual ICollection<MstVillage> MstVillage { get; set; }
    }
}
