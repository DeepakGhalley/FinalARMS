﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class ApropertyVM
    {
        [Key]
        public long Sl { get; set; }
        public decimal Amount { get; set; }
      
       

    }
}
