using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstAttributeUnitMap
    {
        public int AttributeUnitMapId { get; set; }
        public int AssetAttributeId { get; set; }
        public int MeasurementUnitId { get; set; }
        public string AttributeUnitMapName { get; set; }
        public string AttributeUnitMapDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstAssetAttribute AssetAttribute { get; set; }
        public virtual MstMeasurementUnit MeasurementUnit { get; set; }
    }
}
