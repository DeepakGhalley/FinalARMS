using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstEsSignUpload
    {
        public MstEsSignUpload()
        {
            MstLogoSignMap = new HashSet<MstLogoSignMap>();
        }

        public int EsSignId { get; set; }
        public int UserId { get; set; }
        public string SignPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstUser User { get; set; }
        public virtual ICollection<MstLogoSignMap> MstLogoSignMap { get; set; }
    }
}
