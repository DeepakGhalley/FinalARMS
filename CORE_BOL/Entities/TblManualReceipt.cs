﻿using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblManualReceipt
    {
        public int ManualReceiptId { get; set; }
        public string ManualTaxName { get; set; }
        public string ManualReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal Amount { get; set; }
        public string CollectedBy { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}