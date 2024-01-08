using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblInchargeCollection
    {
        public int InchargeCollectionId { get; set; }
        public int UserId { get; set; }
        public decimal CheckedAmount { get; set; }
        public DateTime CollectionStartDate { get; set; }
        public DateTime CollectionEndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    }
}
