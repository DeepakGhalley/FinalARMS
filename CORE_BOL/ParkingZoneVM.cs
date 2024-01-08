using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ParkingZoneVM
    {
        public int ParkingZoneId { get; set; }

        [Display(Name = "Parking Zone Name")]
        public string ParkingzoneName { get; set; }

        [Display(Name = "Parking Zone Description")]
        public string ParkingzoneDesc { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TblParkingfeeDetail> TblParkingfeeDetail { get; set; }
    }
}
