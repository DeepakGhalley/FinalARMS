using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class AssetAccountHeadVM
    {
    }
    public partial class PrimaryAccountHeadModel 
    {
        public IEnumerable<MstPrimaryAccountHead> PrimaryList { get; set; }
        public int PrimaryAccountHeadId { get; set; }
        [Display(Name ="Account Head Name")]
        public string PrimaryAccountHeadName { get; set; }
        [Display(Name ="Code")]
        public string PrimaryAccountHeadCode { get; set; }
        [Display(Name ="Description")]
        public string PrimaryAccountHeadDescription { get; set; }
        [Display(Name ="Symbol")]
        public string PrimaryAccountHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public partial class SecondaryAccountHeadModel
    {
        public IEnumerable<MstSecondaryAccountHead> SecondaryList { get; set; }
        public int SecondaryAccountHeadId { get; set; }
        [Display(Name ="Account Head Name")]
        public string SecondaryAccountHeadName { get; set; }
        [Display(Name ="Code")]
        public string SecondaryAccountHeadCode { get; set; }
        [Display(Name ="Description")]
        public string SecondaryAccountHeadDescription { get; set; }
        [Display(Name ="Symbol")]
        public string SecondaryAccountHeadSymbol { get; set; }
        [Display(Name ="Primary Account Head")]
        public int PrimaryAccountHeadId { get; set; }
        [Display(Name ="Primary Acoount Head Name")]
        public string PrimaryAccountHeadName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<MstPrimaryAccountHead> PrimaryAccountHeads { get; set; }
        public IEnumerable<MstSecondaryAccountHead> SecondaryAccountHeadList { get; set; }
    }
    public partial class TertiaryAccountHeadModel
    {
        public IEnumerable<MstTertiaryAccountHead> TertiaryList { get; set; }
        public int TertiaryAccountHeadId { get; set; }
        [Display(Name = "Account Head Name")]
        public string TertiaryAccountHeadName { get; set; }
        [Display(Name = "Code")]
        public string TertiaryAccountHeadCode { get; set; }
        [Display(Name = "Description")]
        public string TertiaryAccountHeadDescription { get; set; }
        [Display(Name = "Symbol")]
        public string TertiaryAccountHeadSymbol { get; set; }
        [Display(Name = "Secondary Account Head")]
        public int SecondaryAccountHeadId { get; set; }
        [Display(Name = "Secondary Acoount Head Name")]
        public string SecondaryAccountHeadName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<MstSecondaryAccountHead> SecondaryAccountHeads { get; set; }
        public IEnumerable<MstTertiaryAccountHead> TertiaryAccountHeadList { get; set; }

    }

}
