using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblParkingfeeDetail
    {
        public TblParkingfeeDetail()
        {
            TblParkingFeeDemandDetail = new HashSet<TblParkingFeeDemandDetail>();
            TblParkingFeePeriod = new HashSet<TblParkingFeePeriod>();
        }

        public int ParkingFeeDetailId { get; set; }
        public int ParkingZoneId { get; set; }
        public int TaxPayerId { get; set; }
        public int BillingScheduleId { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime? TerminateDate { get; set; }
        public string TerminateReason { get; set; }
        public int? TerminatedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual EnumBillingSchedule BillingSchedule { get; set; }
        public virtual MstParkingZone ParkingZone { get; set; }
        public virtual MstTaxPayerProfile TaxPayer { get; set; }
        public virtual ICollection<TblParkingFeeDemandDetail> TblParkingFeeDemandDetail { get; set; }
        public virtual ICollection<TblParkingFeePeriod> TblParkingFeePeriod { get; set; }
    }
}
