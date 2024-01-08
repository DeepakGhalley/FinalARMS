using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class FinancialInformationVM
    {
        public int FinancialInfoId { get; set; }
        public int AssetId { get; set; }
        public DateTime DateofProcurement { get; set; }
        public DateTime DateofCommissioning { get; set; }
        public decimal UsefulLife { get; set; }
        public decimal CostofProcurement { get; set; }
        public string ProcurementOrderRefNo { get; set; }
        public DateTime ProcurementOrderDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstAsset Asset { get; set; }
    }
}
