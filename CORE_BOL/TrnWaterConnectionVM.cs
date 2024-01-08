using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class TrnWaterConnectionVM   
    {
        public long TrnWaterConnectionId { get; set; }
        public int LandDetailId { get; set; }
        public int WaterConnectionStatusId { get; set; }
        public string WaterMeterNo { get; set; }
        public int WaterMeterTypeId { get; set; }
        public string ConsumerNo { get; set; }
        public DateTime ConnectionDate { get; set; }
        public bool SewerageConnection { get; set; }
        public int WaterConnectionTypeId { get; set; }
        public int WaterLineTypeId { get; set; }
        public decimal StandardCosumption { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string BillingAddress { get; set; }
        public int ZoneId { get; set; }
        public string FlatNo { get; set; }
        public decimal InitialReading { get; set; }
        public string OrganisationName { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public bool? ReUse { get; set; }
        public DateTime? DisconnectDate { get; set; }
        public int NoOfUnits { get; set; }
        public int OwnerTypeId { get; set; }
        public short? ChangeTypeId { get; set; }
        public DateTime? ReconnectionDate { get; set; }
        public DateTime? SewarageConnectionDate { get; set; }
        public int? SewarageConnectedBy { get; set; }
        public string PrimaryMobileNo { get; set; }
        public string SecondaryMobileNo { get; set; }
        public int WorkLevelId { get; set; }
        public long TransactionId { get; set; }

        public virtual MstLandDetail LandDetail { get; set; }
        public virtual EnumOwnerType OwnerType { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual EnumWaterConnectionStatus WaterConnectionStatus { get; set; }
        public virtual MstWaterConnectionType WaterConnectionType { get; set; }
        public virtual MstWaterLineType WaterLineType { get; set; }
        public virtual MstWaterMeterType WaterMeterType { get; set; }
        public virtual EnumWorkLevel WorkLevel { get; set; }
        public virtual MstZone Zone { get; set; }
        public String PlotNo { get; set; }
        public decimal StandardConsumption { get; set; }
        public string ZoneName { get; set; }
        public DateTime SewerageConnectionDate { get; set; }
        public int SewerageConnectedBy { get; set; }
        public string waterConnectionStatus { get; set; }
        public string waterMeterType { get; set; }
        public string waterConnectionType { get; set; }
        public string waterLineType { get; set; }
        public string ownerType { get; set; }
        public string workLevel { get; set; }
        public string transaction { get; set; }
    }
}
