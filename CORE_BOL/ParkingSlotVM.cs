using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class ParkingslotVM
    {
    }
    public partial class ParkingSlotModel
    {

        public int ParkingSlotId { get; set; }
        [Display(Name = "ParkingSlot Name")]
        public string ParkingSlotName { get; set; }
        [Display(Name = "ParkingSlot Description")]
        public string ParkingSlotDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<MstParkingSlot> MstParkingSlot { get; set; }
    }
}
