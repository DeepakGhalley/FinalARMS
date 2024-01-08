using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblRole
    {
        public TblRole()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            MstUser = new HashSet<MstUser>();
            TblMenumap = new HashSet<TblMenumap>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<MstUser> MstUser { get; set; }
        public virtual ICollection<TblMenumap> TblMenumap { get; set; }
    }
}
