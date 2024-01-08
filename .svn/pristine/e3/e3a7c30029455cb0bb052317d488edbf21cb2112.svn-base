using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumLandOwnershipType
    {
        public EnumLandOwnershipType()
        {
            TblLandOwnershipDetail = new HashSet<TblLandOwnershipDetail>();
        }

        public int LandOwnershipTypeId { get; set; }
        public string LandOwnershipType { get; set; }
        public string LandOwnershipTypeDescription { get; set; }

        public virtual ICollection<TblLandOwnershipDetail> TblLandOwnershipDetail { get; set; }
    }
}
