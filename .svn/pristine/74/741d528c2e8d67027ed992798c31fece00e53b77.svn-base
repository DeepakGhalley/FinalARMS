using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblComplainReading
    {
        public long ComplainReadingId { get; set; }
        public long ComplainDetailId { get; set; }
        public string Remarks { get; set; }
        public string ComplainPhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual TblComplainDetail ComplainDetail { get; set; }
    }
}
