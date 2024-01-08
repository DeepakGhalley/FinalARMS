using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblWaterMeterReading
    {
        public TblWaterMeterReading()
        {
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
            TblWaterBillChangeHistory = new HashSet<TblWaterBillChangeHistory>();
        }

        public long WaterMeterReadingId { get; set; }
        public int WaterConnectionId { get; set; }
        public long? TransactionId { get; set; }
        public int WaterConnectionTypeId { get; set; }
        public int WaterMeterTypeId { get; set; }
        public int WaterLineTypeId { get; set; }
        public int WaterConnectionStatusId { get; set; }
        public int? Bucid { get; set; }
        public int ZoneId { get; set; }
        public int Reading { get; set; }
        public bool IsRead { get; set; }
        public DateTime ReadingDate { get; set; }
        public int PreviousReading { get; set; }
        public DateTime PreviousReadingDate { get; set; }
        public int ReadBy { get; set; }
        public int NoOfUnit { get; set; }
        public int Consumption { get; set; }
        public int? StandardConsumption { get; set; }
        public bool IsPermanentConnection { get; set; }
        public bool Sewerage { get; set; }
        public bool SolidWaste { get; set; }
        public string Remarks { get; set; }
        public string FlatNo { get; set; }
        public string BillingAddress { get; set; }
        public string PrimaryMobileNo { get; set; }
        public string SecondaryMobileNo { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDisconnected { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public long? CreateTransactionId { get; set; }

        public virtual TblTransactionDetail CreateTransaction { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual MstWaterConnection WaterConnection { get; set; }
        public virtual EnumWaterConnectionStatus WaterConnectionStatus { get; set; }
        public virtual MstWaterConnectionType WaterConnectionType { get; set; }
        public virtual MstWaterLineType WaterLineType { get; set; }
        public virtual MstWaterMeterType WaterMeterType { get; set; }
        public virtual MstZone Zone { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
        public virtual ICollection<TblWaterBillChangeHistory> TblWaterBillChangeHistory { get; set; }
    }
}
