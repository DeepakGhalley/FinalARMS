using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class ViewLatestOcDetail
    {
        public int TaxPayerId { get; set; }
        public string OcReferenceNo { get; set; }
        public DateTime IssueDate { get; set; }
        public int BuildingDetailId { get; set; }
        public int LandDetailId { get; set; }
    }
}
