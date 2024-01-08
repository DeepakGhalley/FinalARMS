using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class MstLogoSignMap
    {
        public MstLogoSignMap()
        {
            TrnOccupancyCertificateApplication = new HashSet<TrnOccupancyCertificateApplication>();
        }

        public int LogoSignMapId { get; set; }
        public int LogoId { get; set; }
        public int EsSignId { get; set; }
        public int DcdSignId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual MstDcdsignUpload DcdSign { get; set; }
        public virtual MstEsSignUpload EsSign { get; set; }
        public virtual MstLogoUpload Logo { get; set; }
        public virtual ICollection<TrnOccupancyCertificateApplication> TrnOccupancyCertificateApplication { get; set; }
    }
}
