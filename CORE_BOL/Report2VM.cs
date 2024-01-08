﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class Report2VM
    {
        [Key]
        public long Sl { get; set; }
        public string ConsumerNo { get; set; }
        public string BillingAddress { get; set; }
        public string MeterNo { get; set; }
        public int PrevReading { get; set; }
        //public int CurrentReading { get; set; }
        //public string Remarks { get; set; }
        public string PrevReadingDate { get; set; }
        public string zoneName { get; set; }
        public string ReadingYearMonth { get; set; }
    }

    public class ZoneWiseWaterCollection
    {
        [Key]
        public long Sl { get; set; }
        public string zonename { get; set; }
        public string WaterConnectionType { get; set; }
        public int TotalNo { get; set; }
    }
    
    public class WaterAccountWiseReport
    {
        [Key]
        public long Sl { get; set; }
        public string Months { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string BillNo { get; set; }
        public string PayStatus { get; set; }
        public decimal PaymentAmount { get; set; }
        public string TaxName { get; set; }
        public int PrevReading { get; set; }
        public int CurrReading { get; set; }
        public int Consumption { get; set; }
        public string ConnectionStatus { get; set; }
    }
    public class ZoneWiseWaterConsumption
    {
        [Key]
        public long Sl { get; set; }
        public string Yr { get; set; }
        public string zonename { get; set; }
        public string ConsumerNo { get; set; }
        public string MeterNo { get; set; }
        public int Consumption { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
    }
    
    public class MonthlyZoneWiseWaterConsumption
    {
        [Key]
        public long Sl { get; set; }
        public string ConsumerNo { get; set; }
        public string Yr { get; set; }
        public int Mnths { get; set; }
        public string MeterNo { get; set; }
        public int Consumption { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string zonename { get; set; }
    }

    public class DemandCancelModel
    {
        [Key]
        public long Sl { get; set; }
        public string DemandNo { get; set; }
        public decimal TotalCancelAmount { get; set; }
        public string TaxPayerName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string TTIN { get; set; }
        public string CID { get; set; }
        public string remarks { get; set; }
    }


    public class OnlinePaymentReconciliationsReport
    {
        [Key]
        public long sl { get; set; }
        public string bfs_orderNo { get; set; }
        public string transactionType { get; set; }
        public decimal bfs_txnAmount { get; set; }
        public DateTime createdOn { get; set; }
        public string Names { get; set; }
        public string ttin { get; set; }
        public string cid { get; set; }
        public string PlotNo { get; set; }
        public string ThramNo { get; set; }
        public string WaterMeterNo { get; set; }
        public string ConsumerNo { get; set; }
    }

    public class PaymentModeWiseReport
    {
        [Key]
        public long Sl { get; set; }
        public string ReceiptNo { get; set; }
        public string PaymentModeNo { get; set; }
        public string PaymentModeDate { get; set; }
        public string PaymentDate { get; set; }
        public decimal grandTotal { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UserName { get; set; }
        public string ExecutionDate { get; set; }
        public decimal Cash { get; set; }
        public decimal Cheque { get; set; }
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
    }



}
