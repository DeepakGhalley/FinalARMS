using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
  public  class StallRentDemandScheduleModel
    {
        [Key]
        public long Sl { get; set; }
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Year { get; set; }
        public string MonthId { get; set; }
        public string Month { get; set; }
        public int Days { get; set; }
        public long? DemandNoId { get; set; }
        public  int totalDays { get; set; }
        public DateTime fd { get; set; }

    }
}
