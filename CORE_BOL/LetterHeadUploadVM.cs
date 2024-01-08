using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class LetterHeadUploadVM
    {
    }

    public partial class DcdsignUploadModel
    {
        public int DcdSignId { get; set; }
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        [Display(Name = "Sign path")]
        //[Required]

        public string SignPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public IEnumerable<MstDcdsignUpload> DcdSignUpList { get; set; }

    }

    public partial class LogoUploadModel
    {
        public int LogoId { get; set; }
        [Display(Name = "Logo Name")]
        public int UserId { get; set; }
        public string LogoName { get; set; }
        [Display(Name = "Logo Path")]
        public string LogoPath { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<MstLogoUpload> LogoUploadList { get; set; }

    }
    public partial class EsSignUploadsModel
    {
        public int esSignId { get; set; }
        [Display(Name = "User ID")]
        public int userId { get; set; }
        [Display(Name = "Signature path")]
        public string SignPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public IEnumerable<MstEsSignUpload> DcdSignUpList { get; set; }

    }
    public partial class LogoSignMapModel
    {
        public int LogoSignMapId { get; set; }
        public int LogoId { get; set; }
        public string LogoName { get; set; }
        public int ESSignId { get; set; }
        public string SignPath { get; set; }
        public int DCDSignId { get; set; }
        public string SSignPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

    }
}
