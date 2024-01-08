using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblDemandCancel
    {
        public int DemandCancelId { get; set; }
        public long DemandNoId { get; set; }
        public decimal TotalCancelAmount { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TblDemandNo DemandNo { get; set; }
    }
}
