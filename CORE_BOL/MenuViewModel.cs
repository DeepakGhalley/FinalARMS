using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
   public class MenuViewModel
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int? MenuParentId { get; set; }
        public int? Isactive { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
