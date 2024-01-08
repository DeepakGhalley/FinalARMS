using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblDemand
    {
        public TblDemand()
        {
            TblDemandLedgerPaymentUpdate = new HashSet<TblDemandLedgerPaymentUpdate>();
            TblLedger = new HashSet<TblLedger>();
        }

        public long DemandId { get; set; }
        public long TransactionId { get; set; }
        public long DemandNoId { get; set; }
        public int TaxId { get; set; }
        public int FinancialYearId { get; set; }
        public int CalendarYearId { get; set; }
        public decimal DemandAmount { get; set; }
        public decimal? ExemptionAmount { get; set; }
        public string ExemptionLetter { get; set; }
        public decimal TotalAmount { get; set; }
        public int? LandDetailId { get; set; }
        public int? TaxPayerId { get; set; }
        public int? LandOwnershipId { get; set; }
        public int? BuildingUnitDetailId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? WaterMeterReadingId { get; set; }
        public int? ApplicantId { get; set; }
        public int? EcRenewalId { get; set; }
        public long? LandLeaseDemandDetailId { get; set; }
        public long? ParkingDemandDetailId { get; set; }
        public long? StallDemandDetailId { get; set; }
        public long? HouseRentDemandDetailId { get; set; }
        public long? MiscellaneousRecordId { get; set; }
        public bool IsPaymentMade { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string G2cApplicationNo { get; set; }
        public bool IsCancelled { get; set; }
        public decimal? CancelDemandAmount { get; set; }
        public decimal? CancelTotalAmount { get; set; }
        public int? UnScheduledParkingRecordId { get; set; }
        public long? BfsTransactionDetailId { get; set; }
        public string Remarks { get; set; }

        public virtual MstEcapplicantdetail Applicant { get; set; }
        public virtual TblBfsTransactiondetails BfsTransactionDetail { get; set; }
        public virtual MstBuildingUnitDetail BuildingUnitDetail { get; set; }
        public virtual MstCalendarYear CalendarYear { get; set; }
        public virtual TblDemandNo DemandNo { get; set; }
        public virtual TblEcrenewalDetail EcRenewal { get; set; }
        public virtual MstFinancialYear FinancialYear { get; set; }
        public virtual TblHouseRentDemandDetail HouseRentDemandDetail { get; set; }
        public virtual TblLandLeaseDemandDetail LandLeaseDemandDetail { get; set; }
        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
        public virtual TblMiscellaneousRecord MiscellaneousRecord { get; set; }
        public virtual TblParkingFeeDemandDetail ParkingDemandDetail { get; set; }
        public virtual TblStallDetailDemand StallDemandDetail { get; set; }
        public virtual MstTaxMaster Tax { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual TblUnScheduledParkingRecord UnScheduledParkingRecord { get; set; }
        public virtual TblWaterMeterReading WaterMeterReading { get; set; }
        public virtual ICollection<TblDemandLedgerPaymentUpdate> TblDemandLedgerPaymentUpdate { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
