using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
  public  class AssetStatusModel
    {
        public int AssetStatusId { get; set; }
        [Required]
        [DisplayName("Asset Status")]
        public string AssetStatus { get; set; }
        public string StatusDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        
        public IEnumerable<MstAssetStatus> AssetStatusVM { get; set; }
    }
}
