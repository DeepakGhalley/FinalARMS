using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class OpeningBalaceVM
    {
        [Key]
        public int OpeningBalanceId { get; set; }
        public string Particular { get; set; }
        public decimal? Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime? OpeningBalanceCarriedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }


    }
}
