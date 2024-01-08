using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class Parkingfee1VM
    {
        public int UnScheduledParkingRecordId { get; set; }
        public string Cid { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string DemandNo { get; set; }
        public string Creatorname { get; set; }
        public string TaxName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public long TransactionId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Date { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public byte[] QrImage { get; set; }
        public virtual TblTransactionDetail Transaction { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }

    }
}
