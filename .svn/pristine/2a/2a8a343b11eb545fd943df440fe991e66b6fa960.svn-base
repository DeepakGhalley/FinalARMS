using CORE_BOL.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;


namespace CORE_BOL
{
    public class ActivityTypeModel
    {
        public int ActivityTypeId { get; set; }
        [Display(Name ="Activity Type")]
        public string ActivityType { get; set; }
        [Display(Name ="Description")]
        public string ActivityDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<MstEcactivityType> ActivityTypeList { get; set; }

    }
}
