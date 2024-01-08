using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumWorkLevel
    {
        public EnumWorkLevel()
        {
            TblConstructionApprovedDetail = new HashSet<TblConstructionApprovedDetail>();
            TblTransactionDetail = new HashSet<TblTransactionDetail>();
            TrnSewerageConnection = new HashSet<TrnSewerageConnection>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
        }

        public int WorkLevelId { get; set; }
        public string WorkLevel { get; set; }

        public virtual ICollection<TblConstructionApprovedDetail> TblConstructionApprovedDetail { get; set; }
        public virtual ICollection<TblTransactionDetail> TblTransactionDetail { get; set; }
        public virtual ICollection<TrnSewerageConnection> TrnSewerageConnection { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
    }
}
