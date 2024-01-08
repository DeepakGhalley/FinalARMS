using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class OccupancyCertificateUnitMap
    {
        public int OccupancyCertificateUnitMapId { get; set; }
        public int? OccupancyCertificateApplicationId { get; set; }
        public int? BuildingUnitDetailId { get; set; }
    }
}
