using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstSuppliers
    {
        public MstSuppliers()
        {
            MstAsset = new HashSet<MstAsset>();
        }

        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string LicenseNo { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierContactPerson { get; set; }
        public string SupplierContactNumber { get; set; }
        public string SupplierFaxNumber { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstAsset> MstAsset { get; set; }
    }
}
