using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class rptGetWaterConsumptionVM
    {
        [Key]
        public long sl { get; set; }
        public string consumerNo { get; set; }
        public string waterConnectionType { get; set; }
        public string waterMeterNo { get; set; }
        public string waterLineType { get; set; }
        public DateTime readingDate { get; set; }
        public int consumption { get; set; }
    }
}
