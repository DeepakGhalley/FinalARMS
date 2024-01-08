using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstParkingSlot
    {
        public MstParkingSlot()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int ParkingSlotId { get; set; }
        public string ParkingSlotName { get; set; }
        public string ParkingSlotDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
