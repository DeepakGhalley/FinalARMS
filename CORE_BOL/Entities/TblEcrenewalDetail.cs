using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblEcrenewalDetail
    {
        public TblEcrenewalDetail()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public int EcRenewalId { get; set; }
        public int EcDetailId { get; set; }
        public int EcUseTypeId { get; set; }
        public DateTime ValidUpTo { get; set; }
        public decimal Amount { get; set; }
        public string EcRefNo { get; set; }
        public int EcSl { get; set; }
        public int CalendarYear { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual TblEcdetail EcDetail { get; set; }
        public virtual EnumEcuseType EcUseType { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
