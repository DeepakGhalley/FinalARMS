using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class Tblaudit
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TableName { get; set; }
        public string Pk { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserId { get; set; }
    }
}
