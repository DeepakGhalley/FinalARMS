using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
   public class StallLocationVM
    {
        public int StallLocationId { get; set; }
        public string StallLocation { get; set; }
        public string StallLocationDetail { get; set; }
        public bool IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM//yyyy}")]
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
