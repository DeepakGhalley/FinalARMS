using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstConditionRating
    {
        public int ConditionRatingId { get; set; }
        public string ConditionRating { get; set; }
        public string ConditionRatingDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
