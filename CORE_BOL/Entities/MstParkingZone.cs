using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstParkingZone
    {
        public MstParkingZone()
        {
            TblParkingfeeDetail = new HashSet<TblParkingfeeDetail>();
        }

        public int ParkingZoneId { get; set; }
        public string ParkingzoneName { get; set; }
        public string ParkingzoneDesc { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TblParkingfeeDetail> TblParkingfeeDetail { get; set; }
    }
}
