using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblVersionControl
    {
        public int Id { get; set; }
        public decimal Version { get; set; }
        public string Device { get; set; }
    }
}
