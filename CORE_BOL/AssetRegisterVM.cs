using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class AssetRegisterVM
    {
        public int DivisionId { get; set; }
        public int PrimaryAccountHeadId { get; set; }
        public int SecondaryAccountHeadId { get; set; }
        public int AssetId { get; set; }
        [Display(Name = "Tertiary Account Head")]
        public int TertiaryAccountHeadId { get; set; }
        [Display(Name = "Section")]
        public int AreaId { get; set; }
        [Display(Name = "Area")]
        public int SectionId { get; set; }
        [Display(Name = "Asset Status")]
        public int AssetStatusId { get; set; }
        [Display(Name = "Asset Function")]
        public int AssetFunctionId { get; set; }
        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }
        [Display(Name = "Lap")]
        public int? LapId { get; set; }
        public int ZoneId { get; set; }
       
        [Display(Name = "Demkhong")]
        public int ?DemkhongId { get; set; }
        [Display(Name = "Asset Code")]
        public string AssetCode { get; set; }
        [Display(Name = "Asset Name")]
        public string AssetName { get; set; }
        [Display(Name = "Responsible Person")]
        public string ResponsiblePerson { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string Remarks { get; set; }
        public string GisCode { get; set; }
        [Display(Name = "Goods receive date")]
        public DateTime? GoodReceiveDate { get; set; }
        [Display(Name = "Goods received by")]
        public int? GoodReceiveBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string AssetFunctionNames { get; set; }
        public string AssetStatusNames { get; set; }
        public string SectionNames { get; set; }
        public string SupplierNames { get; set; }
        public string TertiaryAccountHeadNames { get; set; }
        public string LapNames { get; set; }
        public string DemkhongNames { get; set; }

        //From TechnicalVM
        public int AssetAttributeId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
        public bool ValueRequired { get; set; }
        public int ParentAttributeId { get; set; }
        public string ParentAttribute { get; set; }
        public string Assetnumber { get; set; }
        public string ParentAttributeDescription { get; set; }
        public virtual MstAssetAttribute AssetAttribute { get; set; }
        public virtual MstParentAttribute ParentAtt { get; set; }



        public virtual MstPrimaryAccountHead PrimaryAccountHead { get; set; }
        public virtual MstSecondaryAccountHead SecondaryAccountHead { get; set; }
        public virtual MstDivision Division { get; set; }
        public virtual MstAssetFunction AssetFunction { get; set; }
        public virtual MstAssetStatus AssetStatus { get; set; }
        public virtual MstSection Section { get; set; }
        public virtual MstSuppliers Supplier { get; set; }
        public virtual MstLap Lap { get; set; }
        public virtual MstDemkhong Demkhong { get; set; }
        public virtual MstTertiaryAccountHead TertiaryAccountHead { get; set; }
        //public virtual TblFinanciaIinformation FinancialInformation { get; set; }
    }
}
