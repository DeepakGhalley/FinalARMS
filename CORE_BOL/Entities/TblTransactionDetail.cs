using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblTransactionDetail
    {
        public TblTransactionDetail()
        {
            MstLandDetail = new HashSet<MstLandDetail>();
            TblDemand = new HashSet<TblDemand>();
            TblLandOwnershipDetail = new HashSet<TblLandOwnershipDetail>();
            TblLedger = new HashSet<TblLedger>();
            TblMiscellaneousRecord = new HashSet<TblMiscellaneousRecord>();
            TblUnScheduledParkingRecord = new HashSet<TblUnScheduledParkingRecord>();
            TblWaterBillChangeHistory = new HashSet<TblWaterBillChangeHistory>();
            TblWaterMeterReadingCreateTransaction = new HashSet<TblWaterMeterReading>();
            TblWaterMeterReadingTransaction = new HashSet<TblWaterMeterReading>();
            TrnConstructionApprovalApplicationFeeDetail = new HashSet<TrnConstructionApprovalApplicationFeeDetail>();
            TrnLandFeeDetail = new HashSet<TrnLandFeeDetail>();
            TrnLandTransferDetail = new HashSet<TrnLandTransferDetail>();
            TrnSewerageConnection = new HashSet<TrnSewerageConnection>();
            TrnVacuumTankerService = new HashSet<TrnVacuumTankerService>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
        }

        public long TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? WorkLevelId { get; set; }
        public decimal? TransactionValue { get; set; }
        public string Remarks { get; set; }
        public int? TaxPayerId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstTransactionType TransactionType { get; set; }
        public virtual EnumWorkLevel WorkLevel { get; set; }
        public virtual ICollection<MstLandDetail> MstLandDetail { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLandOwnershipDetail> TblLandOwnershipDetail { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
        public virtual ICollection<TblMiscellaneousRecord> TblMiscellaneousRecord { get; set; }
        public virtual ICollection<TblUnScheduledParkingRecord> TblUnScheduledParkingRecord { get; set; }
        public virtual ICollection<TblWaterBillChangeHistory> TblWaterBillChangeHistory { get; set; }
        public virtual ICollection<TblWaterMeterReading> TblWaterMeterReadingCreateTransaction { get; set; }
        public virtual ICollection<TblWaterMeterReading> TblWaterMeterReadingTransaction { get; set; }
        public virtual ICollection<TrnConstructionApprovalApplicationFeeDetail> TrnConstructionApprovalApplicationFeeDetail { get; set; }
        public virtual ICollection<TrnLandFeeDetail> TrnLandFeeDetail { get; set; }
        public virtual ICollection<TrnLandTransferDetail> TrnLandTransferDetail { get; set; }
        public virtual ICollection<TrnSewerageConnection> TrnSewerageConnection { get; set; }
        public virtual ICollection<TrnVacuumTankerService> TrnVacuumTankerService { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
    }
}
