using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblEsakorThramPlotDetail
    {
        public int ESakorThramPlotTransactionId { get; set; }
        public long ApplicationId { get; set; }
        public string TransactionType { get; set; }
        public string ThramNo { get; set; }
        public string OwnerCid { get; set; }
        public string OwnName { get; set; }
        public string OwnerType { get; set; }
        public string PartyType { get; set; }
        public string ThramStatus { get; set; }
        public string PlotId { get; set; }
        public decimal NetArea { get; set; }
        public string PrecinctName { get; set; }
        public string PlotStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? ApprovalStatus { get; set; }
        public DateTime? ApprovedOrRejectOn { get; set; }
        public int? ApprovedRejectedBy { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string TransactionFee { get; set; }
    }
}
