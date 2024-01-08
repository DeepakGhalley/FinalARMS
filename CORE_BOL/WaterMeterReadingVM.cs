 using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class WaterMeterReadingModel
    {
        public long WaterMeterReadingId { get; set; }
        [DisplayName("Water Connection")]
        public int WaterConnectionId { get; set; }
        [DisplayName("Water Connection Type")]
        public int TrnWaterConnectionId { get; set; }
        public int WaterConnectionTypeId { get; set; }
        [DisplayName("Water Meter Type")]
        public int WaterMeterTypeId { get; set; }
        [DisplayName("Water Line Type")]
        public int WaterLineTypeId { get; set; }
        [DisplayName("Water Connection Status")]
        public int WaterConnectionStatusId { get; set; }
        [DisplayName("CID")]
        public int? Bucid { get; set; }
        [DisplayName("Water Reading")]
        public int Reading { get; set; }
        [DisplayName("Previous Reading")]
        public int PreviousReading { get; set; }
        public bool IsPaymentMade { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Previous Reading Date")]
        public DateTime PreviousReadingDate { get; set; }
        [DisplayName("Meter Read By")]
        public int ReadBy { get; set; }
        public bool IsRead { get; set; }
        public string FlatNo { get; set; }
      
        [DisplayName("Reading Date")]
        public DateTime ReadingDate { get; set; }
        [DisplayName("No of Units")]
        public int NoOfUnit { get; set; }
        public int Consumption { get; set; }
        [DisplayName("Standard Consumption")]
        public int StandardConsumption { get; set; }
        [DisplayName("Is Permanent Connection")]
        public bool IsPermanentConnection { get; set; }
        public int IsPConnection { get; set; }
        public string SewerageName { get; set; }
        [DisplayName("Solid Waste")]
        public bool SolidWaste { get; set; }
        public int SWaste { get; set; }
        public int SConnection { get; set; }
        public bool CheckStatus { get; set; }
        public string Remarks { get; set; }
        [DisplayName("Billing Address")]
        public string BillingAddress { get; set; }
        public long? TransactionId { get; set; }
        [DisplayName("Primary Mobile No")]
        public string PrimaryMobileNo { get; set; }
        [DisplayName("Secondary Mobile No")]
        public string SecondaryMobileNo { get; set; }
        public string ConsumerNo { get; set; }
        public string WaterMeterNo { get; set; }
        public string WaterMeter { get; set; }
        public string WaterConnectionName { get; set; }
        public string WaterConnectionType { get; set; }
        public string WaterConnectionStatusName { get; set; }
        public string WaterLineTypeName { get; set; }
        public string WaterMeterTypeName { get; set; }
        public string WaterLine { get; set; }
        public int zoneId { get; set; }
        public string ZoneReader { get; set; }
        public string IsActive { get; set; }
        public bool Active { get; set; }
        public bool IsDisconnected { get; set; }
        public bool Sewerage { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int FinancialYearId { get; set; }
        public int? sConsumption { get; set; }
        public string bAddress { get; set; }
        public string MobileNo { get; set; }
        public string ZoneName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal WaterTaxAmount { get; set; }
        public decimal SewerageAmount { get; set; }
        public decimal ServiceChargeAmount { get; set; }
        public decimal TotalBillForTheMonth { get; set; }
        public decimal WaterBillForTheMonth { get; set; }
        public decimal OutStandingAmount { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal NetPayableAmount { get; set; }
        public string DemandNo { get; set; }
        public DateTime BillFor { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime Duedate { get; set; }
        public DateTime BillDate { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }

        //Water Bill Edit
        public string TaxPayerName { get; set; }

        //QR CODE
        public byte[] qrImage { get; set; }

        //WATER PAYMENT RECEIPT
        public decimal DemandAmount { get; set; }
        public string TaxName { get; set; }
        public decimal ExemptionAmount { get; set; }
        public string PaymentDate { get; set; }
        public string BillingDate { get; set; }
        public string ReceiptNo { get; set; }
        public decimal AmountPayable { get; set; }
        public string UserName { get; set; }
        //public virtual MstWaterConnection WaterConnection { get; set; }
        //public virtual EnumWaterConnectionStatus WaterConnectionStatus { get; set; }
        //public virtual MstWaterConnectionType WaterConnectionType { get; set; }
        //public virtual MstWaterLineType WaterLineType { get; set; }
        //public virtual MstWaterMeterType WaterMeterType { get; set; }
    }
}
