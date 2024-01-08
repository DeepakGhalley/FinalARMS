using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstDepreciationType
    {
        public int DepreciationTypeId { get; set; }
        public string DepreciationType { get; set; }
        public string DepreciationTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
