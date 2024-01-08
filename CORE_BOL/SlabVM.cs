using System;
using CORE_BOL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class SlabVM
    {
        public int SlabId { get; set; }
        [Required]
        [Display(Name = "Tax Name")]
        public int TaxId { get; set; }
        [Required]
        [Display(Name = "Transaction Type")]
        public int TransactionTypeID { get; set; }
        [Display(Name = "Land Use Sub Category")]
        public int LandUseSubCategoryId { get; set; }
        public int TransactionType { get; set; }
        [Display(Name = "Tax Name")]
        public string TaxName { get; set; }
        [Required]
        [Display(Name = "Slab Name")]
        public string SlabName { get; set; }
        [Display(Name = "Define 1")]
        public int? Define1 { get; set; }
        [Display(Name = "Define 2")]
        public int? Define2 { get; set; }
        [Display(Name = "Slab Start")]
        public decimal? SlabStart { get; set; }
        [Display(Name = "Slab End")]
        public decimal? SlabEnd { get; set; }
        [Display(Name = "Construction Type")]
        public int? ConstructionTypeId { get; set; }
        [Display(Name = "Building unit use type")]
        public int? BuildingUnitUseTypeId { get; set; }
        public string BuildingUnitUseType { get; set; }
        [Display(Name = "Building unit class")]
        public int? BuildingUnitClassId { get; set; }
        public string BuildingUnitUnitClass { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public decimal Rate { get; set; }

        public virtual MstBuildingUnitClass BuildingUnitClasses { get; set; }
        public virtual MstBuildingUnitUseType BuildingUnitUseTypes { get; set; }
        public virtual MstTaxMaster Tax { get; set; }
        public virtual ICollection<MstRate> MstRate { get; set; }
        public virtual MstTransactionTypeTaxMap TransactionTypeTaxMap { get; set; }
    }
}
