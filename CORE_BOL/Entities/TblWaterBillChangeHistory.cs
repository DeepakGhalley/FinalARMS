using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblWaterBillChangeHistory
    {
        public int WaterBillChangeHistoryId { get; set; }
        public long WaterMeterReadingId { get; set; }
        public long TransactionId { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal NewAmount { get; set; }
        public int OldPreviousReading { get; set; }
        public int NewPreviousReading { get; set; }
        public int OldReading { get; set; }
        public int NewReading { get; set; }
        public int OldUnit { get; set; }
        public int NewUnit { get; set; }
        public int OldWaterConnectionTypeId { get; set; }
        public int NewWaterConnectionTypeId { get; set; }
        public int OldStdConsumption { get; set; }
        public int NewStdConsumption { get; set; }
        public bool OldSewerage { get; set; }
        public bool NewSewerage { get; set; }
        public int OldConsumption { get; set; }
        public int NewConsumption { get; set; }
        public int WaterBillEditReasonId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        public virtual MstWaterConnectionType NewWaterConnectionType { get; set; }
        public virtual MstWaterConnectionType OldWaterConnectionType { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual EnumWaterBillEditReason WaterBillEditReason { get; set; }
        public virtual TblWaterMeterReading WaterMeterReading { get; set; }
    }
}
