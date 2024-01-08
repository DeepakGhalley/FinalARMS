using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class LandOwnershipDetailsVM
    {
        public int LandOwnershipId { get; set; }
        public int LandDetailId { get; set; }
        public string PlotNo { get; set; }
        public string name { get; set; }
        public string TTIN { get; set; }
        public int LandOwnershipTypeId { get; set; }
        public string LandOwnershipType { get; set; }
        public int TaxPayerId { get; set; }
        public string CID { get; set; }
        public  string ThramNo { get; set; }
        public decimal OwnershipPercentage { get; set; }
        public decimal netArea { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int TransactionId { get; set; }
        public int PreviousTaxPayerId { get; set; }
        public decimal PLr { get; set; }
        public bool? IsActive { get; set; }
        public string Remarks { get; set; }
        public bool IsApportioned { get; set; }
        public int IA { get; set; }
        public string IsApp { get; set; }

        public virtual ICollection<MstLandDetail> LandDetails { get; set; }
        public virtual ICollection<EnumLandOwnershipType> LandOwnershipTypes { get; set; }
        public virtual ICollection<MstTaxPayerProfile> TaxPayers { get; set; }
        public virtual ICollection<TblTransactionDetail> Transactions { get; set; }





    }
}
