using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class HouseRentDemandDetailVM
    {
        public int HouseRentDemandDetailId { get; set; }
        public int HouseAllocationId { get; set; }
        public int DemandYear { get; set; }
       
        public int DemandGenerateScheduleId { get; set; }
        public decimal InstallmentAmount { get; set; }
        public long DemandId { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedOn { get; set; }

        public virtual TblDemand Demand { get; set; }
        public virtual EnumDemandGenerateSchedule DemandGenerateSchedule { get; set; }
        public virtual TblHouseAllocation HouseAllocation { get; set; }


    }
}
