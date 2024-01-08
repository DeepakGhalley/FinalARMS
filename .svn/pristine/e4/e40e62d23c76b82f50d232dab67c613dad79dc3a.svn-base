using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CORE_BOL
{
    public class AssetMaintenanceVM
    {
        public int AssetMaintenanceId { get; set; }
        public int AssetId { get; set; }
        public string AssetCode { get; set; }
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

        //Asset Search
        public string PrimaryAccountHead { get; set; }
        public int PrimaryAccountHeadId { get; set; }
        public string SecondaryAccountHead { get; set; }
        public int SecondaryAccountHeadId { get; set; }
        public string TertiaryAccountHead { get; set; }
        public int TertiaryAccountHeadId { get; set; }
        public string Division { get; set; }
        public int DivisionId { get; set; }
        public string Section { get; set; }
        public int SectionId { get; set; }
        public string AssetName { get; set; }
        public string AssetStatus { get; set; }
        public int AssetStatusId { get; set; }
        public string Lap { get; set; }
        public int LapId { get; set; }
         public string Demkhong { get; set; }
         public int DemkhongId { get; set; }
         public string AssetFunction { get; set; }
         public string ResponsiblePerson { get; set; }
        public virtual MstAsset Asset { get; set; }
        public virtual MstMaintenanceType MaintenanceType { get; set; }
    }
}
