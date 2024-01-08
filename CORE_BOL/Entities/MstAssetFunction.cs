using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstAssetFunction
    {
        public MstAssetFunction()
        {
            MstAsset = new HashSet<MstAsset>();
        }

        public int AssetFunctionId { get; set; }
        public string AssetFunctionName { get; set; }
        public string AssetFunctionDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string FunctionCode { get; set; }

        public virtual ICollection<MstAsset> MstAsset { get; set; }
    }
}
