using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
 public class ModificationReasonVM
    {
        public int ModificationReasonId { get; set; }
        [Required]
        [DisplayName("Modification Reason")]
        public string ModificationReason { get; set; }
        [Required]
        [DisplayName("Description")]
        public string ReasonDescription { get; set; }
        [Required]
        [DisplayName("Code")]
        public string ReasonCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<MstModificationReason> MstModificationReasonVM { get; set; }

    }
}
