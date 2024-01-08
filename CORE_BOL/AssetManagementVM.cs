using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class AssetManagementVM
    {
       
            [Key]
            public long Sl { get; set; }
            public string Assetname { get; set; }
            public int Qty { get; set; }
            public int SecondaryAccountHeadId { get; set; }
          
      
    }
}
