using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
  public class SuppliersVM
    {
        public int SupplierId { get; set; }
        [Required]
        [DisplayName("Supplier Code")]
        public string SupplierCode { get; set; }

        [Required]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
     
        [DisplayName("Supplier Address")]
        public string SupplierAddress { get; set; }
        [Required]
        [DisplayName("Contact Person")]
        public string SupplierContactPerson { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        public string SupplierContactNumber { get; set; }
        [Required]
        [DisplayName("Fax Number")]

        public string SupplierFaxNumber { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [DisplayName("License Number")]
        public string LicenseNo { get; set; }
        public IEnumerable<MstSuppliers> MstSuppliersVM { get; set; }

    }
}
