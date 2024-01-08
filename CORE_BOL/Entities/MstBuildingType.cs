using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstBuildingType
    {
        public int BuildingTypeId { get; set; }
        public string BuildingType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
