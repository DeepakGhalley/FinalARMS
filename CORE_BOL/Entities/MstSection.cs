using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstSection
    {
        public MstSection()
        {
            MstAsset = new HashSet<MstAsset>();
            MstDesignation = new HashSet<MstDesignation>();
            MstTransactionType = new HashSet<MstTransactionType>();
            MstUser = new HashSet<MstUser>();
        }

        public int SectionId { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public int DivisionId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstDivision Division { get; set; }
        public virtual ICollection<MstAsset> MstAsset { get; set; }
        public virtual ICollection<MstDesignation> MstDesignation { get; set; }
        public virtual ICollection<MstTransactionType> MstTransactionType { get; set; }
        public virtual ICollection<MstUser> MstUser { get; set; }
    }
}
