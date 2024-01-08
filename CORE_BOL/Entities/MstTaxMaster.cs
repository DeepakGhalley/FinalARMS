using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTaxMaster
    {
        public MstTaxMaster()
        {
            MstLandUseSubCategoryLandTax = new HashSet<MstLandUseSubCategory>();
            MstLandUseSubCategoryUdTax = new HashSet<MstLandUseSubCategory>();
            MstRate = new HashSet<MstRate>();
            MstSlab = new HashSet<MstSlab>();
            MstTransactionTypeTaxMap = new HashSet<MstTransactionTypeTaxMap>();
            TblDemand = new HashSet<TblDemand>();
            TblLedger = new HashSet<TblLedger>();
            TblMiscellaneousRecord = new HashSet<TblMiscellaneousRecord>();
            TrnTaxDetail = new HashSet<TrnTaxDetail>();
        }

        public int TaxId { get; set; }
        public int DetailHeadId { get; set; }
        public string TaxName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstDetailHead DetailHead { get; set; }
        public virtual ICollection<MstLandUseSubCategory> MstLandUseSubCategoryLandTax { get; set; }
        public virtual ICollection<MstLandUseSubCategory> MstLandUseSubCategoryUdTax { get; set; }
        public virtual ICollection<MstRate> MstRate { get; set; }
        public virtual ICollection<MstSlab> MstSlab { get; set; }
        public virtual ICollection<MstTransactionTypeTaxMap> MstTransactionTypeTaxMap { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
        public virtual ICollection<TblMiscellaneousRecord> TblMiscellaneousRecord { get; set; }
        public virtual ICollection<TrnTaxDetail> TrnTaxDetail { get; set; }
    }
}
