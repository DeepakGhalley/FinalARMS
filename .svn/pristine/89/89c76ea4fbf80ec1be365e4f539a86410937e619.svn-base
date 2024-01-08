using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumOccupancyType
    {
        public EnumOccupancyType()
        {
            TrnOccupancyCertificateApplication = new HashSet<TrnOccupancyCertificateApplication>();
        }

        public int OccupancyTypeId { get; set; }
        public string OccupancyType { get; set; }

        public virtual ICollection<TrnOccupancyCertificateApplication> TrnOccupancyCertificateApplication { get; set; }
    }
}
