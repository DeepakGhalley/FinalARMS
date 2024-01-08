using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ParkingFeeDemandVM
    {
        public long ParkingDemandDetailId { get; set; }
        
        [Display(Name ="Parking Fee Detail")]
        public int ParkingFeeDetailId { get; set; }

        [Display(Name = "Demand Year")]
        public int DemandYear { get; set; }

        [Display(Name = "Demand Generate Schedule")]
        public int DemandGenerateScheduleId { get; set; }

        [Display(Name = "Demand")]
        public long DemandId { get; set; }

        [Display(Name = "Installment Amount")]
        public decimal InstallmentAmount { get; set; }

        [Display(Name = "Installment Date")]
        public DateTime InstallmentDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TblDemand Demand { get; set; }
        public virtual EnumDemandGenerateSchedule DemandGenerateSchedule { get; set; }
        public virtual TblParkingfeeDetail ParkingFeeDetail { get; set; }
    }
}
