using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblMenu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int MenuParentId { get; set; }
        public int? OrderFor { get; set; }
        public int? MenuFor { get; set; }
        public int? MenuSequence { get; set; }
        public int Isactive { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string MenuIconName { get; set; }
    }
}
