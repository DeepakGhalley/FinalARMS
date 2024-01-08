using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumProjectStatus
    {
        public EnumProjectStatus()
        {
            TblEcdetail = new HashSet<TblEcdetail>();
        }

        public int ProjectStatusId { get; set; }
        public string ProjectStatus { get; set; }

        public virtual ICollection<TblEcdetail> TblEcdetail { get; set; }
    }
}
