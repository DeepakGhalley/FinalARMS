using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstEcapplicantdetail
    {
        public MstEcapplicantdetail()
        {
            TblDemand = new HashSet<TblDemand>();
            TblEcdetail = new HashSet<TblEcdetail>();
            TblLedger = new HashSet<TblLedger>();
        }

        public int ApplicantId { get; set; }
        public string Cid { get; set; }
        public string LicenceNo { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
        public string PostBoxNo { get; set; }
        public string ContactNo { get; set; }
        public string FaxNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<TblDemand> TblDemand { get; set; }
        public virtual ICollection<TblEcdetail> TblEcdetail { get; set; }
        public virtual ICollection<TblLedger> TblLedger { get; set; }
    }
}
