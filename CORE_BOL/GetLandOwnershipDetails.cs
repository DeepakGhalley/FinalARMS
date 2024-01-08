using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class GetLandOwnershipDetails
    {
        public int LandOwnershipId { get; set; }
        public int LandDetailId { get; set; }
        public string PlotNo { get; set; }
        public int LandOwnershipTypeId { get; set; }
        public string LandOwnershipType { get; set; }
        public int TaxPayerId { get; set; }
        public string CID { get; set; }
        public string TTIN { get; set; }
        public string Name { get; set; }
        public string TPN { get; set; }
        public decimal LandAcreage { get; set; }
        public decimal LandValue { get; set; }
        public string PlotAddress { get; set; }
        public string ThramNo { get; set; }
        public string Title { get; set; }
        public decimal OwnershipPercentage { get; set; }
        public long TransactionId { get; set; }


        public virtual ICollection<MstLandDetail> LandDetails { get; set; }
        public virtual ICollection<EnumLandOwnershipType> LandOwnershipTypes { get; set; }
        public virtual ICollection<MstTaxPayerProfile> TaxPayers { get; set; }
        public virtual ICollection<TblTransactionDetail> Transactions { get; set; }
    }
}
