using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class RoofingType
    {
    }
    public partial class RoofingTypemodel
    {
        public IEnumerable<MstRoofingType> MstRoofingType { get; set; }
        public int RoofingTypeId { get; set; }
        [Display(Name = "Roofing Type ")]

        public string RoofingType { get; set; }
        [Display(Name = "RoofingType Description ")]

        public string RoofingTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

       
    }
}
