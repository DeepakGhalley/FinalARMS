using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLandUseSubCategory
    {
        public MstLandUseSubCategory()
        {
            MstLandDetail = new HashSet<MstLandDetail>();
            MstPavaRate = new HashSet<MstPavaRate>();
            MstSlab = new HashSet<MstSlab>();
            TrnLandDetail = new HashSet<TrnLandDetail>();
        }

        public int LandUseSubCategoryId { get; set; }
        public int LandUseCategoryId { get; set; }
        public string LandUseSubCategory { get; set; }
        public string LandUseCategoryDescription { get; set; }
        public int LandTaxId { get; set; }
        public int UdTaxId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstTaxMaster LandTax { get; set; }
        public virtual MstLandUseCategory LandUseCategory { get; set; }
        public virtual MstTaxMaster UdTax { get; set; }
        public virtual ICollection<MstLandDetail> MstLandDetail { get; set; }
        public virtual ICollection<MstPavaRate> MstPavaRate { get; set; }
        public virtual ICollection<MstSlab> MstSlab { get; set; }
        public virtual ICollection<TrnLandDetail> TrnLandDetail { get; set; }
    }
}
