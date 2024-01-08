using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblFreezPropertyDetail
    {
        public int FreezePropertyId { get; set; }
        public int LandDetailId { get; set; }
        public string LetterNo { get; set; }
        public DateTime LetterDate { get; set; }
        public string Remarks { get; set; }
        public bool IsFreeze { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
