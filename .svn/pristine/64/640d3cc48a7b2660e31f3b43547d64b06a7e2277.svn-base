using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class TechnicalVM
    {
        public int TechnicalattributeDetailId { get; set; }
        public int AssetAttributeId { get; set; }
        public int AssetId { get; set; }
        public int MeasurementUnitId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        //For Get Technical
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
        public bool ValueRequired { get; set; }
        public int ParentAttributeId { get; set; }
        public int TertiaryAccountHeadId { get; set; }
        public string ParentAttribute { get; set; }
        public string ParentAttributeDescription { get; set; }







        public virtual MstAsset Asset { get; set; }
        public virtual MstAssetAttribute AssetAttribute { get; set; }
        public virtual MstMeasurementUnit MeasurementUnit { get; set; }
    }
}
