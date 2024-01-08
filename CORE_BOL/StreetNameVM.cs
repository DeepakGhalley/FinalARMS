using System;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class StreetNameVM
    {
    }
    public partial class StreetNameModel
    {
        public int StreetNameId { get; set; }
        [Display(Name = "Street Name   ")]

        public string StreetName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<MstStreetName> StreetNameVM { get; set; }
    }
}
