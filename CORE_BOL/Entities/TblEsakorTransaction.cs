using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class TblEsakorTransaction
    {
        public long EsakorTransactionId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionApproveDate { get; set; }
        public string TransactorType { get; set; }
        public string TransactionType { get; set; }
        public string PreviousPlotId { get; set; }
        public string PreviousThramNo { get; set; }
        public string Precinct { get; set; }
        public decimal TotalArea { get; set; }
        public string TransferorCid { get; set; }
        public string TransferorName { get; set; }
        public string TranferorOwnershipType { get; set; }
        public decimal TranferorNetArea { get; set; }
        public decimal TranferorPlr { get; set; }
        public string TransfereeCid { get; set; }
        public string TransfereeName { get; set; }
        public string TranfereeOwnershipType { get; set; }
        public string TransfererorPlotId { get; set; }
        public string TransferorThramNo { get; set; }
        public string TransferereePlotId { get; set; }
        public string TransferereeThramNo { get; set; }
        public decimal? TransfereeNetArea { get; set; }
        public decimal? TransfereePlr { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? ApprovalStatus { get; set; }
        public DateTime? ApprovedOrRejectOn { get; set; }
        public int? ApprovedRejectedBy { get; set; }
    }
}
