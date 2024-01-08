using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class RoleVM
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
        [Required]

        public int CreatedBy { get; set; }
        [Required]

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<MstUser> MstUser { get; set; }
        public virtual ICollection<TblMenumap> TblMenumap { get; set; }
    }
}
