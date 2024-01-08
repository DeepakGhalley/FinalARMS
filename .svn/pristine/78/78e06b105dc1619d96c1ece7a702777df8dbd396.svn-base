using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstMaintenanceType
    {
        public MstMaintenanceType()
        {
            TblAssetMaintenance = new HashSet<TblAssetMaintenance>();
        }

        public int MaintenanceTypeId { get; set; }
        public string MaintenanceType { get; set; }
        public string MaintenanceTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TblAssetMaintenance> TblAssetMaintenance { get; set; }
    }
}
