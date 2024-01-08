using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class AssetDetailVM
    {
    }

    public partial class AssetFunctionModel
    {
        public IEnumerable<MstAssetFunction> AssetFunctionList { get; set; }
        public int AssetFunctionId { get; set; }
        [Display(Name = "Asset Function Name")]
        public string AssetFunctionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string AssetFunctionCode { get; set; }
    }

    public partial class MeasurementUnitModel
    {
        public IEnumerable<MstMeasurementUnit> MeasurementUnitList { get; set; }
        public int MeasurementUnitId { get; set; }
        [Display(Name = "Measurement Unit")]
        public string MeasurementUnit { get; set; }
        [Display(Name = "Measurement Symbol")]
        public string MeasurementUnitSymbol { get; set; }
        [Display(Name = "Measurement Description")]
        public string MeasurementUnitDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
