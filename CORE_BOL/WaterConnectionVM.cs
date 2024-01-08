using CORE_BOL.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace CORE_BOL
{
    public partial class WaterConnectionModel
    {
       
        public int WaterConnectionId { get; set; }
        [Display(Name = "Land Detail")]
        public int LandDetailId { get; set; }
        [Display(Name = "Plot No")]
        public string PlotNo { get; set; }
        [Display(Name = "Water Connection Status")]
        public int WaterConnectionStatusId { get; set; }
        public string WaterConnectionStatus { get; set; }
        [Display(Name = "Water Meter No")]
        public string WaterMeterNo { get; set; }
        [Display(Name = "Water Meter Type")]
        public bool SolidWaste { get; set; }
        public int WaterMeterTypeId { get; set; }
        public string ThramNo { get; set; }
        public string TTIN { get; set; }
        public string CID { get; set; }
        public string WaterMeterType { get; set; }
        [Display(Name = "Consumer No")]
        public string ConsumerNo { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Connection Date")]
        public DateTime ConnectionDate { get; set; }
        [Display(Name = "Sewerage Connection")]
        public int WaterMeterReadingId { get; set; }
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
        public int WaterConnection { get; set; }
        public bool ReUse { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Disconnect Date")]
        public DateTime DisconnectDate { get; set; }
        [Display(Name = "No Of Units")]
        public int NoOfUnits { get; set; }
        [Display(Name = "Owner Type")]
        public int OwnerTypeId { get; set; }
        [Display(Name = "Owner Type")]
        public string OwnerType { get; set; }
        [Display(Name = "Change Type")]
        public int ChangeTypeId { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Reconnection Date")]
        public DateTime ReconnectionDate { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Sewarage Connection Date")]
        public DateTime SewarageConnectionDate { get; set; }
        [Display(Name = "Sewarage Connection By")]
        public int SewarageConnectedBy { get; set; }
        [Display(Name = "Primary Mobile No")]
        public string PrimaryMobileNo { get; set; }
        [Display(Name = "Secondary Mobile No")]
        public string SecondaryMobileNo { get; set; }
        [Display(Name = "Work Level")]
        public DateTime PreviousReadingDate { get; set; }
        public int WorkLevelId { get; set; }
        [Display(Name = "Transaction")]
        public long TransactionId { get; set; }
        public long TrnWaterConnectionId { get; set; }
        public int SearchTaxPayerProfile { get; set; }
        public DateTime? MaxReadingDate { get; set; }
        public bool? IsPermanentDisconnect { get; set; }
        public bool? IsPermanentConnect { get; set; }
        public string TaxPayerName { get; set; }
        public decimal LandAcerage { get; set; }
        public int LandOwnershipId { get; set; }
        public int Reading { get; set; }
        public bool IsRead { get; set; }
        public DateTime ReadingDate { get; set; }
        public int PreviousReading { get; set; }
        public int ReadBy { get; set; }
        public int Consumption { get; set; }
        
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
}