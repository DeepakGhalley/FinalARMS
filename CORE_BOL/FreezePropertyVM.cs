using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class FreezePropertyVM
    {
        public int FreezePropertyId { get; set; }
        public int LandDetailId { get; set; }
        public string LetterNo { get; set; }
        public DateTime LetterDate { get; set; }
        public string Remarks { get; set; }
        public bool IsFreeze { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //for Grid-details
        public string ThramNo { get; set; }
        public int TaxPayerId { get; set; }
        public int LandOwnerShipId { get; set; }
        public int LandTypeId { get; set; }
        public string PlotNo { get; set; }
        public string CID { get; set; }
        public string TTIN { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string LandOwnerShip { get; set; }
        public string LandType { get; set; }
        
    }
}
