using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class OccupationVM
    {
        public int OccupationId { get; set; }
        public string Occupation { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        //public virtual ICollection<MstTaxPayer> MstTaxPayer { get; set; }
    }
}
