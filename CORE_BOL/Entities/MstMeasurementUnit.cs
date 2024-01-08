using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstMeasurementUnit
    {
        public MstMeasurementUnit()
        {
            MstAttributeUnitMap = new HashSet<MstAttributeUnitMap>();
            TblTechnicalInformation = new HashSet<TblTechnicalInformation>();
        }

        public int MeasurementUnitId { get; set; }
        public string MeasurementUnit { get; set; }
        public string MeasurementUnitSymbol { get; set; }
        public string MeasurementUnitDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstAttributeUnitMap> MstAttributeUnitMap { get; set; }
        public virtual ICollection<TblTechnicalInformation> TblTechnicalInformation { get; set; }
    }
}
