using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblAssetMaintenance
    {
        public int AssetMaintenanceId { get; set; }
        public int AssetId { get; set; }
        public int MaintenanceTypeId { get; set; }
        public int? MaintainedById { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public decimal MaintenanceCost { get; set; }
        public string Reason { get; set; }
        public string SparePartUsed { get; set; }
        public string ServiceOrderNo { get; set; }
        public DateTime? ServiceOrderDate { get; set; }
        public DateTime? DateofNextMaintenance { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string Remarks { get; set; }

        public virtual MstAsset Asset { get; set; }
        public virtual MstMaintenanceType MaintenanceType { get; set; }
    }
}
