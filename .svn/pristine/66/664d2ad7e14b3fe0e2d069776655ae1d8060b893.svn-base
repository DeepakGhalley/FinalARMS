using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class MiscellaneousRecordModel
    {
        public long MiscellaneousRecordId { get; set; }
        public long RecepitId { get; set; }
        public long TransactionId { get; set; }
        [Required]
        public int TaxId { get; set; }
        public int SlabId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] QrImage { get; set; }
        public string Cid { get; set; }
        public string MobileNo { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public bool PaymentStatus { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]// add this line for date
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public int TransactionTypeId { get; set; }
        //public virtual ICollection<MstTransactionType> TransactionType { get; set; }
        public string TransactionType { get; set; }
        public string Transaction { get; set; }
        public virtual ICollection<TblTransactionDetail> Transactions { get; set; }

        public string Tax { get; set; }
        public virtual ICollection<MstTaxMaster> Taxs { get; set; }

        public string Slab { get; set; }
        public virtual ICollection<MstSlab> Slabs { get; set; }

        public int RateId { get; set; }
        public decimal Rate { get; set; }
        public virtual ICollection<MstRate> Rates { get; set; }


        public long DemandId { get; set; }
      
        public long DemandNoId { get; set; }
        public string DemandNo { get; set; }
        public int FinancialYearId { get; set; }
        public int CalendarYearId { get; set; }
        public decimal DemandAmount { get; set; }
        public decimal? ExemptionAmount { get; set; }
        public string ExemptionLetter { get; set; }
        public decimal TotalAmount { get; set; }
        public int? LandDetailId { get; set; }
        public int? TaxPayerId { get; set; }

        public int? EcId { get; set; }
        public long? Miscid { get; set; }
        public long? Vendorid { get; set; }
        public long? LandLeaseDemandDetailId { get; set; }
        public string User { get; set; }
        public virtual MstCalendarYear CalendarYear { get; set; }
        public virtual TblDemandNo DemandNos { get; set; }
        public virtual MstFinancialYear FinancialYear { get; set; }
        public virtual TblLandLeaseDemandDetail LandLeaseDemandDetail { get; set; }
     
        public virtual ICollection<TblHouseRentDemandDetail> TblHouseRentDemandDetail { get; set; }
        public virtual ICollection<TblLandLeaseDemandDetail> TblLandLeaseDemandDetail { get; set; }
        public virtual ICollection<TblParkingFeeDemandDetail> TblParkingFeeDemandDetail { get; set; }
        public virtual ICollection<TblStallDetailDemand> TblStallDetailDemand { get; set; }



    }
}
