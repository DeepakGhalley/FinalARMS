using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstTaxPayerProfile
    {
        public MstTaxPayerProfile()
        {
            TblHouseAllocation = new HashSet<TblHouseAllocation>();
            TblLandLease = new HashSet<TblLandLease>();
            TblLandOwnershipDetail = new HashSet<TblLandOwnershipDetail>();
            TblParkingfeeDetail = new HashSet<TblParkingfeeDetail>();
            TblStallAllocation = new HashSet<TblStallAllocation>();
            TrnOccupancyCertificateApplication = new HashSet<TrnOccupancyCertificateApplication>();
        }

        public int TaxPayerId { get; set; }
        public int TaxPayerTypeId { get; set; }
        public int? VendorTypeId { get; set; }
        public string Ttin { get; set; }
        public string Cid { get; set; }
        public string Tpn { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public int GenderId { get; set; }
        public int PVillageId { get; set; }
        public int? CDzongkhagId { get; set; }
        public string CAddress { get; set; }
        public int OccupationId { get; set; }
        public string WorkingAgency { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string BankAccountNo { get; set; }
        public int? BankBranchId { get; set; }
        public int? TaxSmssentYearId { get; set; }
        public int? CensusSmssentYrId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstBankBranch BankBranch { get; set; }
        public virtual MstDzongkhag CDzongkhag { get; set; }
        public virtual MstCalendarYear CensusSmssentYr { get; set; }
        public virtual EnumGender Gender { get; set; }
        public virtual MstOccupation Occupation { get; set; }
        public virtual MstVillage PVillage { get; set; }
        public virtual EnumTaxPayerType TaxPayerType { get; set; }
        public virtual MstCalendarYear TaxSmssentYear { get; set; }
        public virtual EnumTitle Title { get; set; }
        public virtual EnumVendorType VendorType { get; set; }
        public virtual ICollection<TblHouseAllocation> TblHouseAllocation { get; set; }
        public virtual ICollection<TblLandLease> TblLandLease { get; set; }
        public virtual ICollection<TblLandOwnershipDetail> TblLandOwnershipDetail { get; set; }
        public virtual ICollection<TblParkingfeeDetail> TblParkingfeeDetail { get; set; }
        public virtual ICollection<TblStallAllocation> TblStallAllocation { get; set; }
        public virtual ICollection<TrnOccupancyCertificateApplication> TrnOccupancyCertificateApplication { get; set; }
    }
}
