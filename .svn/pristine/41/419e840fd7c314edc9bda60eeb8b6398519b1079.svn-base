using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblAssetDepreciation
    {
        public int DepreciationId { get; set; }
        public int AssetId { get; set; }
        public int FinancialYearId { get; set; }
        public int DepreciationTypeId { get; set; }
        public decimal DepreciationValue { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstAsset Asset { get; set; }
        public virtual EnumDepreciationType DepreciationType { get; set; }
        public virtual MstFinancialYear FinancialYear { get; set; }
    }
}
