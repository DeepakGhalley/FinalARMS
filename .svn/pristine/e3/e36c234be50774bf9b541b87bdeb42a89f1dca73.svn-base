using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumDepreciationType
    {
        public EnumDepreciationType()
        {
            TblAssetDepreciation = new HashSet<TblAssetDepreciation>();
        }

        public int DepreciationTypeId { get; set; }
        public string DepreciationType { get; set; }

        public virtual ICollection<TblAssetDepreciation> TblAssetDepreciation { get; set; }
    }
}
