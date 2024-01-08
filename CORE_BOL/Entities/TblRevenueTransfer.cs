﻿using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblRevenueTransfer
    {
        public int RevenueTransferId { get; set; }
        public decimal RevenueTransferAmount { get; set; }
        public DateTime RevenueTransferDate { get; set; }
        public string RevenueTakenBy { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}