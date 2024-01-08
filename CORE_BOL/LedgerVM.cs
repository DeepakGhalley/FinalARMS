using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class LedgerVM
    {
        public long LedgerId { get; set; }
        public long DemandId { get; set; }
        public long TransactionId { get; set; }
        public int TaxId { get; set; }
        public int FinancialYearId { get; set; }
        public int CalendarYearId { get; set; }
        public int? LandDetailId { get; set; }
        public int? TaxPayerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime? ReconciledOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ApplicantId { get; set; }
        public int? EcRenewalId { get; set; }
        public long? LandLeaseDemandDetailId { get; set; }
        public long? ParkingDemandDetailId { get; set; }
        public long? StallDemandDetailId { get; set; }
        public long? HouseRentDemandDetailId { get; set; }
        public long? MiscellaneousRecordId { get; set; }
        //public virtual MstEcapplicantdetail Applicant { get; set; }
        //public virtual MstCalendarYear CalendarYear { get; set; }
        //public virtual TblDemand Demand { get; set; }
        //public virtual TblEcrenewalDetail EcRenewal { get; set; }
        //public virtual MstFinancialYear FinancialYear { get; set; }
        //public virtual TblHouseRentDemandDetail HouseRentDemandDetail { get; set; }
        //public virtual TblLandLeaseDemandDetail LandLeaseDemandDetail { get; set; }
        //public virtual TblMiscellaneousRecord MiscellaneousRecord { get; set; }
        //public virtual TblParkingFeeDemandDetail ParkingDemandDetail { get; set; }
        //public virtual TblStallDetailDemand StallDemandDetail { get; set; }
        //public virtual TblTransactionDetail Transaction { get; set; }
    }

    public class LedgerDemandVM
    {
        public double md { get; set; }
        public double tdays { get; set; }
        public DateTime mddate { get; set; }
        public DateTime instmentdate { get; set; }
        public long DemandId { get; set; }
        public string Bank { get; set; }
        public string Month { get; set; }
        public string Receipt { get; set; }
        public long ReceiptId { get; set; }
        public long TransactionTypeId { get; set; }
        public int PaymentledgerId { get; set; }
        public int NoOfTrips { get; set; }
        public int DemandYear { get; set; }
        public int BillingScheduleId { get; set; }
        public string Paymentmode { get; set; }
        public string PaymentModeNo { get; set; }
        public DateTime? PaymentModeDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long TransactionId { get; set; }
        public long DemandNoId { get; set; }
        public int TaxId { get; set; }
        public int LandOwnerShipId { get; set; }
        public string SA { get; set; }
        public int FinancialYearId { get; set; }
        public int CalendarYearId { get; set; }
        public decimal DemandAmount { get; set; }
        public decimal? ExemptionAmount { get; set; }
        public string ExemptionLetter { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GrandTotalAmount { get; set; }
        public string ECRefNo { get; set; }
        
        public decimal TotalPenaltyAmount { get; set; }
        public decimal NetAmount { get; set; }
        public int? LandDetailId { get; set; }
        public int? TaxPayerId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Date { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ApplicantId { get; set; }
        public int? EcRenewalId { get; set; }
        public long? LandLeaseDemandDetailId { get; set; }
        public long? ParkingDemandDetailId { get; set; }
        public long? StallDemandDetailId { get; set; }
        public long? HouseRentDemandDetailId { get; set; }
        public long? MiscellaneousRecordId { get; set; }
        public string DemandNo { get; set; }
        public string TaxName { get; set; }
        public string Ids { get; set; }
        public int TaxIdUD { get; set; }
        public bool StructureAvailable { get; set; }
        public decimal TotalAmountUD { get; set; }
        public decimal rmsamt { get; set; }
        public decimal TotalAmountDemand { get; set; }
        public byte[] QrImage { get; set; }
        public string TransactionType { get; set; }
        public string FullName { get; set; }
        public string PlotNo { get; set; }
        public string ThramNo { get; set; }
        public string Cid { get; set; }
        public string Ttin { get; set; }
        public string Caddress { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CalendarYear { get; set; }
        public decimal PenaltyAmount { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string consumerNo { get; set; }
        public string WaterMeterNO { get; set; }
        public string BillingAddress { get; set; }
        public string Slab { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public string PhoneNo { get; set; }
        public DateTime BillingDate { get; set; }
        public long LedgerId { get; set; }

        public string Address { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public string BillingSchedule { get; set; }
        public string HouseNo { get; set; }
        public int PenaltyDays { get; set; }
        public string FinancialYear { get; set; }
        public string billmonth { get; set; }
        public string StallNo { get; set; }
        public string Creatorname { get; set; }

        public int GarbageTaxId { get; set; }
        public decimal GarbageTax { get; set; }
        public int StreetLightTaxId { get; set; }
        public decimal StreetLightTax { get; set; }
        public bool IsApportioned { get; set; }
        public string ApplicantName { get; set; }
        public string LicenseNo { get; set; }
        public string ActivityType { get; set; }
        public DateTime PaymentDate { get; set; }
       
    }
    public class LedgerPaymentLedgerModel
        {
    public long PaymentLedgerId { get; set; }
    public long ReceiptId { get; set; }
    public int PaymentModeId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentModeNo { get; set; }
    public DateTime? PaymentModeDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime PaymentDate { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public long? TransactionId { get; set; }
        public int? BankBranchId { get; set; }
        public virtual EnumPaymentMode PaymentMode { get; set; }
    public virtual TblReceipt Receipt { get; set; }
    public virtual TblTransactionDetail Transaction { get; set; }
}

    public class DemandCountModel
    {
        public int PropertyTax { get; set; }
        public int Miscellaneous { get; set; }
        public int Ec { get; set; }
    }

    public class OnlinePaymentCheckModel
    {
        public string BfsDebitAuthCode { get; set; }
        public long BfsTransactionDetailId { get; set; }
    }
    public class GenerateAllPropertyTaxModel
    {
        public decimal LandTaxAmount { get; set; }
        public decimal LandTaxPenalty { get; set; }
        public decimal UDTaxAmount { get; set; }
        public decimal UDTaxPenalty { get; set; }
        public decimal UTHAmount { get; set; }
        public decimal UTHPenalty { get; set; }
        public decimal GarbageAmount { get; set; }
        public decimal GarbagePenalty { get; set; }
        public decimal StreetLightAmount { get; set; }
        public decimal StreetLightPenalty { get; set; }
        public int LandDetailId { get; set; }
        public int LandOwnershipId { get; set; }
        public int LandOwnershipTypeId { get; set; }
        public int TaxPayerId { get; set; }
        public int ConstructionTypeId { get; set; }
        public int BuildingUnitClassId { get; set; }
        public int BuildingUnituseTypeId{ get; set; }
        public int LandTaxId { get; set; }
        public decimal LandTaxRate { get; set; }
        public int UDTaxId { get; set; }
        public decimal UDTaxRate { get; set; }
        public decimal PenaltyOrRate { get; set; }
        public int UnitTaxId { get; set; }
        public int GarbageTaxId { get; set; }
        public int StreetLightTaxId { get; set; }
        public string TaxPayerName { get; set; }
        public decimal PLR { get; set; }
        public string TTIN { get; set; }
        public string CID { get; set; }
        public string PlotNo { get; set; }
        public string ThramNo { get; set; }
        public decimal PenaltyDays { get; set; }
        public string BuildingNo { get; set; }
        public string OccupancyCertificateNo { get; set; }
        public string OccupancyCertificateDate { get; set; }
        public string ConstructionType { get; set; }
        public string BuildingUnitUseType { get; set; }
        public string BuildingUnitClassName { get; set; }
        public int NoOfUnits { get; set; }
        public decimal UHTRate { get; set; }
        public decimal GarbageRate { get; set; }
        public decimal TotalAmount { get; set; }
        public int PType { get; set; }
        public int CalendarYearId { get; set; }
        public decimal Amount { get; set; }
        public string UDTaxApplicable { get; set; }
        public string CalendarYear { get; set; }
        public int CreatedBy { get; set; }


    }

    public class EsakorTaxPayerModel
    {
        public string PlotNo { get; set; }
        public string Cid { get; set; }
        public string TaxPayerName { get; set; }
        public decimal Plr { get; set; }
        public decimal TotalArea { get; set; }
        public string ThramNo { get; set; }
      
    }
    

}
