using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TrnWaterMeterReading
    {
        public int TrnWaterMeterReadingId { get; set; }
        public long TrnWaterConnectionId { get; set; }
        public int WaterConnectionTypeId { get; set; }
        public int WaterMeterTypeId { get; set; }
        public int WaterLineTypeId { get; set; }
        public int WaterConnectionStatusId { get; set; }
        public int? Bucid { get; set; }
        public int Reading { get; set; }
        public int PreviousReading { get; set; }
        public DateTime PreviousReadingDate { get; set; }
        public int ReadBy { get; set; }
        public DateTime ReadingDate { get; set; }
        public int NoOfUnit { get; set; }
        public int Consumption { get; set; }
        public int? StandardConsumption { get; set; }
        public bool IsPermanentConnection { get; set; }
        public bool Sewerage { get; set; }
        public bool SolidWaste { get; set; }
        public string Remarks { get; set; }
        public string BillingAddress { get; set; }
        public long? TransactionId { get; set; }
        public string PrimaryMobileNo { get; set; }
        public string SecondaryMobileNo { get; set; }

        public virtual TrnWaterConnection TrnWaterConnection { get; set; }
        public virtual EnumWaterConnectionStatus WaterConnectionStatus { get; set; }
        public virtual MstWaterConnectionType WaterConnectionType { get; set; }
        public virtual MstWaterLineType WaterLineType { get; set; }
        public virtual MstWaterMeterType WaterMeterType { get; set; }
    }
}
