using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public partial class VillageModel
    {
        public int VillageId { get; set; }
        [Display(Name = "Village Name")]
        public string VillageName { get; set; }
        [Display(Name = "Gewog")]
        public int GewogId { get; set; }
        [Display(Name = "Gewog Name")]
        public string GewogName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<MstGewog> Gewogs { get; set; }
        public IEnumerable<MstVillage> VillagesList { get; set; }
    }
}



