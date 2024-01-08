using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class TaxMasterVM
    {
        public string DetailHeadName { get; set; }
        public int TaxId { get; set; }
        [Display(Name = "Tax Type Classification")]
        public int TaxTypeClassificationId { get; set; }
        public string TaxTypeClassificationName { get; set; }
        [Display(Name = "Detail Head")]
        public int DetailHeadId { get; set; }
        [Display(Name = "Tax Name")]
        public string TaxName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstDetailHead DetailHead { get; set; }
        public virtual MstTaxTypeClassification TaxTypeClassification { get; set; }
        public virtual ICollection<MstRate> MstRate { get; set; }
        public virtual ICollection<MstSlab> MstSlab { get; set; }
        public virtual ICollection<MstTransactionTypeTaxMap> MstTransactionTypeTaxMap { get; set; }
        public virtual ICollection<TblDemand> TblDemand { get; set; }

    }
    public class TaxTypeClassificationVM
    {
        public int TaxTypeClassificationId { get; set; }
        [Display(Name = "Tax Type Classification")]
        public string TaxTypeClassification { get; set; }
        [Display(Name = "Description")]
        public string TaxTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstTaxMaster> MstTaxMaster { get; set; }
    }
}
