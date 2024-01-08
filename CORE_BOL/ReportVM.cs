﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
     public class ReportVM
    {
        [Key]
        public long Sl { get; set; }
        public string PaymentDate { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime StartDate { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime EndDate { get; set; }
        public string TaxName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PenaltyAmount { get; set; }
       // public int FinancialYearId { get; set; }
    }
    public class FinancialYearWiseReportVM
    {
        [Key]
        public long sl { get; set; }
        
        public string TaxName { get; set; }
        public decimal TotalAmount { get; set; }
        public string FinancialYear { get; set; }
        // public int FinancialYearId { get; set; }
    }
    public class DailyPaymentModeWisedemandCollectionVM
    {
        [Key]
        public long Sl { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public decimal SubTotal { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class DailyPaymentModeWisedemandCollectionSUMVM
    {
        [Key]
        public long Sl { get; set; }
        //public string PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public decimal SubTotal { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class DailyReceiptWiseCollection
    {
        [Key]
        public long Sl { get; set; }
        public long receiptId { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentModeNo { get; set; }
        public string PaymentModeDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string ReceiptNo { get; set; }
        public decimal CashAmount { get; set; }
        public decimal ChecqueAmount { get; set; }
        public decimal ThromdeApp { get; set; }
        public decimal OnlinePaymentAmount { get; set; }
        public decimal PIAmount { get; set; }
        public decimal MBOBAmount { get; set; }
        public decimal mPayAmount { get; set; }
        public decimal DkAmount { get; set; }
        public decimal TPayAmount { get; set; }
        public decimal DrukPNBAmount { get; set; }
        public decimal ePayAmount { get; set; }
        public decimal eTeeruAmount { get; set; }
        public decimal ScanPay { get; set; }
        public decimal GrandTotal { get; set; }

    }

    public class IndividaulReceiptWiseDemandCollection
    {
        [Key]
        public long Sl { get; set; }
        public string ReceiptNo { get; set; }
       public string PaymentModeNo { get; set; }
       public string PaymentModeDate { get; set; }
       public string PaymentDate { get; set; }
       public decimal Cash { get;set; }
       public decimal Cheque { get; set; }
        public decimal ScanPay { get; set; }
        public decimal grandTotal { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UserName { get; set; }  
        public string ExecutionDate { get; set; }
    }
    public class IndividualDetails
    {
        public string CreatedBy { get; set; }
        public DateTime PaymentFromDate { get; set; }
        public DateTime PaymentToDate { get; set; }
    }

    public class DefaulterPropertyList
    {
        [Key]
        public long Sl { get; set; }
        public string TaxPayerName { get; set; }
        public string CID { get; set; }
        public string TTIN { get; set; }
        public decimal TotalAmount { get; set; }
        public string TaxPayerType { get; set; }
        public string MobileNo { get; set; }
        public string PlotNo { get; set; }
        public int LastTaxPaidYear { get; set; }
        public int CalendarYear { get; set; }
    }
    public class DefaulterWaterList
    {
        [Key]
        public long Sl { get; set; }
        public string ConsumerNo { get; set; }
        public string WaterMeterNo { get; set; }
        public string BillingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public int NoOfPendingBills { get; set; }
        public string contactNo { get; set; }
        public string zoneName { get; set; }
        public string CalendarYear { get; set; }
        //public string months { get; set; }
    }
    public class YearlyMinorHeadWiseCollection
    {
        [Key]
        public long Sl { get; set; }
        public string MinorHeadName { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class DailyMinorHeadWiseCollection
    {
        [Key]
        public long Sl { get; set; }
        public string MinorHeadName { get; set; }
        public decimal TotalAmount { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    //Missed Out Reading Report Jigme
    public class MissedOutReadingReportVM
    {
        [Key]
        public long Sl { get; set; }
        public string ConsumerNo { get; set; }
        public string MeterNo { get; set; }
        public string connectionDate { get; set; }
        public bool ActiveStatus { get; set; }
        public string LineType { get; set; }
        public string ConnectionType { get; set; }
        public string ConnectionStatus { get; set; }
        public string FlatNo { get; set; }
        public string BillingAddress { get; set; }
    }

    //Floors Wise Count Jigme
    public class FloorsWiseCountReportVM
    {
        [Key]
        public long Sl { get; set; }
        public int NumberOfFloors { get; set; }
        public int BuildingCount { get; set; }
    }


    //VM for Assets Reports
    public class AssetStatusReport
    {
        [Key]
        public long Sl { get; set; }
        public string assetName { get; set; }
        public string areaName { get; set; }
        public string lapName { get; set; }
        public string sectionName { get; set; }
        public string assetFunctionName { get; set; }
        public string TertiaryAccountHeadName { get; set; }
        public string secondaryAccountHeadName { get; set; }
        public string primaryAccountHeadName { get; set; }
        public string responsiblePerson { get; set; }

    }

    public class AssetListByResponsiblePerson
    {
        [Key]
        public long Sl { get; set; }
        public string assetName { get; set; }
        public string areaName { get; set; }
        public string lapName { get; set; }
        public string sectionName { get; set; }
        public string assetFunctionName { get; set; }
        public string TertiaryAccountHeadName { get; set; }
        public string secondaryAccountHeadName { get; set; }
        public string primaryAccountHeadName { get; set; }
        public string responsiblePerson { get; set; }

    }

    public class AssetListing
    {
        [Key]
        public long Sl { get; set; }
        public string assetName { get; set; }
        public string areaName { get; set; }
        public string lapName { get; set; }
        public string sectionName { get; set; }
        public string assetFunctionName { get; set; }
        public string responsiblePerson { get; set; }
        public string remarks { get; set; }

    }

    public class AssetTransferReport
    {
        [Key]
        public long Sl { get; set; }
        public string AssetNumber { get; set; }
        public string assetName { get; set; }
        public string assetCode { get; set; }
        public string transferfrom { get; set; }
        public string transferto { get; set; }
        public DateTime transferDate { get; set; }
    }


    public class AssetMaintenanceReport
    {
        [Key]
        public long Sl { get; set; }
        public string AssetNumber { get; set; }
        public string assetName { get; set; }
        public string assetCode { get; set; }
        public DateTime maintenanceDate { get; set; }
    }


    //public class AssetDepreciationReportVM
    //{
    //    [Key]
    //    public long Sl { get; set; }
    //    public string AssetNumber { get; set; }
    //    public string assetName { get; set; }
    //    public string assetCode { get; set; }
    //    public decimal depreciationValue { get; set; }
    //}

    //VM for Meter Connection reports
    public class DifferentSizesMeterNoReport
    {
        [Key]
        public long Sl { get; set; }
        public string MeterSizes { get; set; }
        public int NumberOfMeter { get; set; }
    }

    public class NoOfConnectionCategoryWiseReport
    {
        [Key]
        public long Sl { get; set; }
        public string ConnectionType { get; set; }
        public int NumberOfConnection { get; set; }

    }

    public class NoOfConnectionZoneWiseReport
    {
        [Key]
        public long Sl { get; set; }
        public string zoneName { get; set; }
        public string ConnectionType { get; set; }
        public int NumberOfConnection { get; set; }

    }

    public class ZoneWiseWaterConsumptionFromToDate
    {
        [Key]
        public long Sl { get; set; }
        public string zonename { get; set; }
        public string MeterNo { get; set; }
        public string ConsumerNo { get; set; }
        public int Consumption { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class ConnectionTypeWiseConsumption
    {
        [Key]
        public long Sl { get; set; }
        public string zonename { get; set; }
        public string MeterNo { get; set; }
        public string ConsumerNo { get; set; }
        public int Consumption { get; set; }
        public decimal TotalAmount { get; set; }
        public string waterConnectionType { get; set; }
    }

    public class ConnectionTypeWiseRevenue
    {
        [Key]
        public long Sl { get; set; }
        public string MeterNo { get; set; }
        public string ConsumerNo { get; set; }
        public decimal TotalAmount { get; set; }
        public string waterConnectionType { get; set; }
        public string billingAddress { get; set; }
    }

    //********************** Precinct Wise Count Report Model ************************
    public class PrecinctWiseCountReportVM
    {
        [Key]
        public long Sl { get; set; }
        public string LandUseCategory { get; set; }
        public string LandUseSubCategory { get; set; }
        public int LandCount { get; set; }
        public decimal TotalLandAcerage { get; set; }
        public int BuildingCount { get; set; }
    }
    //********************** Precinct Wise Count Report Model ************************


}


