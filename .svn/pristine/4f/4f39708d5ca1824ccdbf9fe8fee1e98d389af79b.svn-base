using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class MaintenanceTypeVM
    {
        public int MaintenanceTypeId { get; set; }
        [Display(Name = "Type")]
        public string MaintenanceType { get; set; }
        [Display(Name = "Description")]
        public string MaintenanceTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<MstMaintenanceType> MaintenanceTypeList { get; set; }


    }
}
