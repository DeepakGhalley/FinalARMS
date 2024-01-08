using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
   public class TechicalInformationVM
    {
        public int TechicalInformationId { get; set; }
        public int AssetAttributeId { get; set; }
        public string AttributeName { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int MeasurementUnitId { get; set; }
        public string MeasurementUnitName { get; set; }
        public string Value { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        //List<TechicalInformationVM> tlist { get; set; }
        public virtual MstAsset Asset { get; set; }
        public virtual MstAssetAttribute AssetAttribute { get; set; }
        public virtual MstMeasurementUnit MeasurementUnit { get; set; }
    }
}
