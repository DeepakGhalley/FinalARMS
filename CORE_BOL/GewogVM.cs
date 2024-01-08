using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public partial class GewogModel
    {
        public int GewogId { get; set; }
        [Display(Name = "Gewog Name")]
        public string GewogName { get; set; }
        [Display(Name = "Dzongkhag")]
        public int DzongkhagId { get; set; }
        [Display(Name = "Dzongkhag Name")]
        public string DzongkhagName { get; set; }

        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<MstDzongkhag> Dzongkhags { get; set; }
        public IEnumerable<MstGewog> GewogsList { get; set; }
    }
}
