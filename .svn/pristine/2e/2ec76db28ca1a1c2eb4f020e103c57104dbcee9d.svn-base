using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
  public  class trnLandDetailVM
    {
        public int TrnLandDetailId { get; set; }
        public int TransactorTypeId { get; set; }
        public int LandTransferTypeId { get; set; }
        public int LapId { get; set; }
        public int DemkhongId { get; set; }
        public int StreetNameId { get; set; }
        public int LandTypeId { get; set; }
        public int LandUseSubCategoryId { get; set; }
        public string PlotNo { get; set; }
        public decimal LandAcerage { get; set; }
        public decimal LandValue { get; set; }
        public decimal LandPoolingRate { get; set; }
        public bool StructureAvailable { get; set; }
        public string PlotAddress { get; set; }
        public string Location { get; set; }
        public bool IsApproved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? VacantLandTaxApplicable { get; set; }
        public bool? GarbageApplicable { get; set; }
        public bool? StreetLightApplicable { get; set; }
        public string ESakorTransactionId { get; set; }
        public int PropertyTypeId { get; set; }

        public virtual MstDemkhong Demkhong { get; set; }
        public virtual MstLandType LandType { get; set; }
        public virtual MstLandUseSubCategory LandUseSubCategory { get; set; }
        public virtual MstLap Lap { get; set; }
        public virtual MstStreetName StreetName { get; set; }
        public virtual EnumTransactorType TransactorType { get; set; }
    }
}
