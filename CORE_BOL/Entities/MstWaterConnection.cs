using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstWaterConnection
    {
        public MstWaterConnection()
        {
            TblComplainDetail = new HashSet<TblComplainDetail>();
            TblInaccessibleWaterMeterDetail = new HashSet<TblInaccessibleWaterMeterDetail>();
            TblWaterMeterReading = new HashSet<TblWaterMeterReading>();
            TrnWaterConnection = new HashSet<TrnWaterConnection>();
        }

        public int WaterConnectionId { get; set; }
        public int LandDetailId { get; set; }
        public int LandOwnershipId { get; set; }
        public int WaterConnectionStatusId { get; set; }
        public int OwnerTypeId { get; set; }
        public short? ChangeTypeId { get; set; }
        public string WaterMeterNo { get; set; }
        public int WaterMeterTypeId { get; set; }
        public string ConsumerNo { get; set; }
        public DateTime ConnectionDate { get; set; }
        public bool SewerageConnection { get; set; }
        public bool SolidWaste { get; set; }
        public int WaterConnectionTypeId { get; set; }
        public int WaterLineTypeId { get; set; }
        public int StandardConsumption { get; set; }
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
        public bool? IsPermanentConnection { get; set; }
        public string Remarks { get; set; }
        public bool? IsPermanentDisconnect { get; set; }
        public DateTime? DisconnectDate { get; set; }
        public int NoOfUnits { get; set; }
        public DateTime? ReconnectionDate { get; set; }
        public DateTime? SewarageConnectionDate { get; set; }
        public int? SewarageConnectedBy { get; set; }
        public string PrimaryMobileNo { get; set; }
        public string SecondaryMobileNo { get; set; }
        public long? TransactionId { get; set; }
        public DateTime? MaxReadingDate { get; set; }

        public virtual MstLandDetail LandDetail { get; set; }
        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
        public virtual EnumOwnerType OwnerType { get; set; }
        public virtual EnumWaterConnectionStatus WaterConnectionStatus { get; set; }
        public virtual MstWaterConnectionType WaterConnectionType { get; set; }
        public virtual MstWaterLineType WaterLineType { get; set; }
        public virtual MstWaterMeterType WaterMeterType { get; set; }
        public virtual MstZone Zone { get; set; }
        public virtual ICollection<TblComplainDetail> TblComplainDetail { get; set; }
        public virtual ICollection<TblInaccessibleWaterMeterDetail> TblInaccessibleWaterMeterDetail { get; set; }
        public virtual ICollection<TblWaterMeterReading> TblWaterMeterReading { get; set; }
        public virtual ICollection<TrnWaterConnection> TrnWaterConnection { get; set; }
    }
}
