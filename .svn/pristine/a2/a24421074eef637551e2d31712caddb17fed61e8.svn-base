using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblHouseDetail
    {
        public TblHouseDetail()
        {
            TblHouseAllocation = new HashSet<TblHouseAllocation>();
        }

        public int HouseDetailId { get; set; }
        public string HouseNo { get; set; }
        public string HouseAddress { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TblHouseAllocation> TblHouseAllocation { get; set; }
    }
}
