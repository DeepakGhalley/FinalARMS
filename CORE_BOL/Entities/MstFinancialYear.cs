using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstFinancialYear
    {
        public MstFinancialYear()
        {
            TblAssetDepreciation = new HashSet<TblAssetDepreciation>();
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
        }

        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TblAssetDepreciation> TblAssetDepreciation { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
