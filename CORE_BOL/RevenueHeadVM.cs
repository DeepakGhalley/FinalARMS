using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    class RevenueHeadVM
    {
    }
    public partial class MajorHeadModel
    {
        public IEnumerable<MstMajorHead> MajorHeadVM { get; set; }
        public int MajorHeadId { get; set; }
        [Display(Name = "Major Head Name")]
        public string MajorHeadName { get; set; }
        [Display(Name = "Major Head Code")]
        public string MajorHeadCode { get; set; }
        [Display(Name = "Major Head Description")]
        public string MajorHeadDescription { get; set; }
        [Display(Name = "Major Head Symbol")]
        public string MajorHeadSymbol { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public partial class MinorHeadModel
    {
        public int MinorHeadId { get; set; }
        [Display(Name = "Minor Head Name")]
        public string MinorHeadName { get; set; }
        [Display(Name = "Minor Head Code")]
        public string MinorHeadCode { get; set; }
        [Display(Name = "Minor Head Description")]
        public string MinorHeadDescription { get; set; }
        [Display(Name = "Minor Head Symbol")]
        public string MinorHeadSymbol { get; set; }
        [Display(Name = "Major Head")]
        public int MajorHeadId { get; set; }
        [Display(Name = "Major Head Name")]
        public string MajorHeadName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<MstMajorHead> MajorHeads { get; set; }
        public IEnumerable<MstMinorHead> MinorHeadsList { get; set; }
    }

    public partial class DetailHeadModel
    {
        public int DetailHeadId { get; set; }
        [Display(Name = "Detail Head Name")]
        public string DetailHeadName { get; set; }
        [Display(Name = "Detail Head Code")]
        public string DetailHeadCode { get; set; }
        [Display(Name = "Detail Head Description")]
        public string DetailHeadDescription { get; set; }
        [Display(Name = "Detail Head Symbol")]
        public string DetailHeadSymbol { get; set; }
        [Display(Name = "Minor Head")]
        public int MinorHeadId { get; set; }
        [Display(Name = "Minor Head Name")]
        public string MinorHeadName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<MstMinorHead> MiniorHeads { get; set; }
        public IEnumerable<MstDetailHead> DetailHeadsList { get; set; }
    }
}
