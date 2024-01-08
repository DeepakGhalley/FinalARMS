using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class MenuMapModel
    {
        [Key]
        public int menu_id { get; set; }
        public string menu_name { get; set; }
        public int? is_add { get; set; }
        public int? is_view { get; set; }
        public int? is_edit { get; set; }
    }
}
