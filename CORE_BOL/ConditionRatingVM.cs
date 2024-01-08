using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ConditionRatingVM
    {

        public int ConditionRatingId { get; set; }
        [Display(Name = "Condition Rating")]
        public string ConditionRating { get; set; }
        [Display(Name = "Description")]
        public string ConditionRatingDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<MstConditionRating> ConditionRatingList { get; set; }
    }
}
