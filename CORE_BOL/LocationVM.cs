using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ZoneModel
    {
        public int ZoneId { get; set; }
        [Display(Name ="Zone Name")]
        public string ZoneName { get; set; }
        [Display(Name ="Zone Code")]
        public string ZoneCode { get; set; }
        [Display(Name ="Zone Reader")]
        public string ZoneReader { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<MstLap> MyList { get; set; }

    }
}
