using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLogoUpload
    {
        public MstLogoUpload()
        {
            MstLogoSignMap = new HashSet<MstLogoSignMap>();
        }

        public int LogoId { get; set; }
        public string LogoName { get; set; }
        public string LogoPath { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstLogoSignMap> MstLogoSignMap { get; set; }
    }
}
