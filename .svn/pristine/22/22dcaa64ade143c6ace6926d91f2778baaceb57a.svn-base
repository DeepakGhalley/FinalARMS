using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class TaxPeriodVM
    {
        public int TaxPeriodId { get; set; }
        [Required]
        [DisplayName("Transaction Type")]
        public int TransactionTypeId { get; set; }
        [Required]
        [DisplayName("Calendar Year")]
        public int CalendarYearId { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Effective Date")]
        public DateTime EffectiveDate { get; set; }
        //[Required]
        //public DateTime EndDate { get; set; }
        [Required]
        [DisplayName("Penalty")]
        public decimal Penalty { get; set; }
        //[DisplayName("Is Active")]
        //public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string TaxTypeClass { get; set; }
        public string CalendarYr { get; set; }
        public virtual MstCalendarYear CalendarYear { get; set; }
        public virtual MstTaxTypeClassification TaxTypeClassification { get; set; }
    }
}
