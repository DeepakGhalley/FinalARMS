﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class wiseCollectedVM
    {
        [Key]
        public long Sl { get; set; }
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal Amount { get; set; }
        public DateTime CollectedOn { get; set; }
    }

}
