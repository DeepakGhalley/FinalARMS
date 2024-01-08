﻿using CORE_BOL.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace CORE_BOL
{
    public partial class TranWaterConnectionModel 
    {
       
        public int WaterConnectionId { get; set; }
        [Display(Name = "Land Detail")]
        public int SewerageConnectionId { get; set; }
        public string billmonth { get; set; }
        public string TaxName { get; set; }
        public string ReceiptNo { get; set; }
        public int LandDetailId { get; set; }
        [Display(Name = "Plot No")]
        public string Ids { get; set; }
        public string EmailId { get; set; }
        public string OwnerName { get; set; }
        public decimal Amount { get; set; }
        public string PlotNo { get; set; }
        [Display(Name = "Water Connection Status")]
        public int WaterConnectionStatusId { get; set; }
        public string WaterConnectionStatus { get; set; }
        [Display(Name = "Water Meter No")]
        public string WaterMeterNo { get; set; }
        [Display(Name = "Water Meter Type")]
        public int WaterMeterTypeId { get; set; }
        public int WaterMeterReadingId { get; set; }
        public string WaterMeterType { get; set; }
        [Display(Name = "Consumer No")]
        public string ConsumerNo { get; set; }
        [Display(Name = "Connection Date")]
        public bool Sewerage { get; set; }
        public DateTime ConnectionDate { get; set; }
        [Display(Name = "Sewerage Connection")]
        public bool SewerageConnection { get; set; }
        [Display(Name = "Water Connection Type")]
        public int WaterConnectionTypeId { get; set; }
        [Display(Name = "Water Connection Type")]
        public string WaterConnectionType { get; set; }
        [Display(Name = "Water Line Type")]
        public int WaterLineTypeId { get; set; }
        public string WaterLineType { get; set; }
        [Display(Name = "Standard Consumption")]
        public int StandardCosumption { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }
        [Display(Name = "Zone Name")]
        public int ZoneId { get; set; }
        [Display(Name = "Zone Name")]
        public string ZoneName { get; set; }
        [Display(Name = "Flat No")]
        public string FlatNo { get; set; }
        [Display(Name = "Initial Reading")]
        public decimal InitialReading { get; set; }
        [Display(Name = "Organisation Name")]
        public string OrganisationName { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public int? Bucid { get; set; }
        public bool ReUse { get; set; }
        public string Name { get; set; }
        [Display(Name = "Disconnect Date")]
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DisconnectDate { get; set; }
        [Display(Name = "No Of Units")]
        public int NoOfUnits { get; set; }
        [Display(Name = "Owner Type")]
        public int OwnerTypeId { get; set; }
        [Display(Name = "Owner Type")]
        public string OwnerType { get; set; }
        [Display(Name = "Change Type")]
        public int ChangeTypeId { get; set; }
        [Display(Name = "Reconnection Date")]
        public DateTime ReconnectionDate { get; set; }
        [Display(Name = "Sewarage Connection Date")]
        public DateTime SewarageConnectionDate { get; set; }
        [Display(Name = "Sewarage Connection By")]
        public int SewarageConnectedBy { get; set; }
        [Display(Name = "Primary Mobile No")]
        public int? OldWaterConnectionId { get; set; }
        public string PrimaryMobileNo { get; set; }
        [Display(Name = "Secondary Mobile No")]
        public string SecondaryMobileNo { get; set; }
        [Display(Name = "Work Level")]
        public int WorkLevelId { get; set; }
        [Display(Name = "Transaction")]
        public long TransactionId { get; set; }
        public long TrnWaterConnectionId { get; set; }
        public int SearchTaxPayerProfile { get; set; }
        public int TaxPayerId { get; set; }
        [Display(Name = "Thram No")]
        public string ThramNo { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "TTIN")]
        public string Ttin { get; set; }
        [Display(Name = "CID")]
        public string Cid { get; set; }
        public int Reading { get; set; }
        public int ReadBy { get; set; }
        public int Consumption { get; set; }
        public bool IsPermanentConnection { get; set; }
        public int IPC { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; }
         public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CAddress { get; set; }
        public string PhoneNo { get; set; }
        public bool SolidWaste { get; set; }
        public string Fax { get; set; }
        public bool? IsPermanentDisconnect { get; set; }
        public bool? IsPermanentDisconnection { get; set; }
        public bool? ApprovalStatusId { get; set; }
        [Display(Name = "Disconnection Type")]
        public string PermanentDisconnect { get; set; }
        [Display(Name = "Disconnection Type")]
        public string PlotAddress { get; set; }
        [Display(Name = "Water Connection Type Name")]
        public string WaterConnectionTypeName { get; set; }
        public DateTime ApplicationDate { get; set; }
        //public bool solidWaste { get; set; }


        //METER REPLACEMENT from Tbl_WaterMeterReading
        //public int consumption { get; set; }
        public int previousReading { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime previousReadingDate { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReadingDate { get; set; }
        public int Year { get; set; }
        public int RMonth { get; set; }
        public int IPD { get; set; }
        public long RecepitId { get; set; }
        public decimal Totalamount { get; set; }

        public int? LandOwnershipId { get; set; }


        public virtual ICollection<MstLandDetail> LandDetails { get; set; }
        public virtual ICollection<EnumWaterConnectionStatus> WaterConnectionStatuses { get; set; }
        public virtual ICollection<MstWaterMeterType> WaterMeterTypes { get; set; }
        public virtual ICollection<MstWaterConnectionType> WaterConnectionTypes { get; set; }
        public virtual ICollection<MstWaterLineType> WaterLineTypes { get; set; }
        public virtual ICollection<MstZone> Zones { get; set; }
        //public virtual ICollection<EnumOnerType> OwnerTypes { get; set; }
        public virtual EnumWorkLevel WorkLevel { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }

    }

    public partial class WaterconnectionDemandVM
    {

       
        public long TransactionId { get; set; }
        public long TaxId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Createdby { get; set; }
        public byte[] QrImage { get; set; }
        public string Cid { get; set; }
        public string MobileNo { get; set; }
        
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string TaxName { get; set; }
        public string DemandNo { get; set; }
        public string ConsumerNo { get; set; }
        public string BillingAddress { get; set; }
        public string WaterMeterNo { get; set; }
        public bool IsPaymentMade { get; set; }
   

       
        
    }
   
    }