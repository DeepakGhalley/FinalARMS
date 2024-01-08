using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class AssetDepreciationVM
    {
        public int DepreciationId { get; set; }
        public int AssetId { get; set; }
        public int FinancialYearId { get; set; }
        public int DepreciationTypeId { get; set; }
        public decimal DepreciationValue { get; set; }
        public string DepreciationType { get; set; }
        public string FinancialYear { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Remarks { get; set; }
        public string AssetCode { get; set; }


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
