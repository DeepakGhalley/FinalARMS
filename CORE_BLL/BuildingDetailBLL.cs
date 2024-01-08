using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class BuildingDetailBLL : IBuildingDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstBuildingDetail.Any(e => e.BuildingDetailId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BuildingDetailModel> Details(int? id)
        {
            var data = (from a in ctx.MstBuildingDetail.Where(aa => aa.BuildingDetailId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        //join c in ctx.MstBuildingColour on a.BuildingColourId equals c.BuildingColourId
                        //join d in ctx.MstConstructionType on a.ConstructionTypeId equals d.ConstructionTypeId
                        //join e in ctx.MstStructureCategory on a.StructureCategoryId equals e.StructureCategoryId
                        //join f in ctx.MstStructureType on a.StructureTypeId equals f.StructureTypeId
                        //join g in ctx.MstMaterialType on a.MaterialTypeId equals g.MaterialTypeId
                        //join h in ctx.MstRoofingType on a.RoofingTypeId equals h.RoofingTypeId
                        //join i in ctx.MstBoundaryType on a.BoundaryTypeId equals i.BoundaryTypeId
                        //join j in ctx.EnumWaterTankLocation on a.WaterTankLocationId equals j.WaterTankLocationId
                        //join k in ctx.MstParkingSlot on a.ParkingSlotId equals k.ParkingSlotId
                        select new BuildingDetailModel
                        {
                            BuildingDetailId = a.BuildingDetailId,
                            LandDetailId = b.LandDetailId,
                            BuildingNo = a.BuildingNo,
                            BuildupArea = a.BuildupArea,
                            PlinthArea = a.PlinthArea,
                            NoOfUnits = a.NoOfUnits,
                            NumberOfFloors = a.NumberOfFloors,
                            GarbagServiceAccessibilityId = a.GarbagServiceAccessibilityId,
                            StreetLightAccessibilityId = a.StreetLightAccessibilityId,
                            OccupancyCertificateNo = a.OccupancyCertificateNo,
                            ConstructionTypeId = a.ConstructionTypeId,
                            YearOfConstruction = a.YearOfConstruction,
                            OccupancyCertificateIssued = (bool)a.OccupancyCertificateIssued,
                            OccupancyCertificateIssueDate = a.OccupancyCertificateIssueDate,
                            PaymentCompletionStatusId = (bool)a.PaymentCompletionStatusId,
                            WaterConnection = (bool)a.WaterConnection,
                            SewerageConnection = (bool)a.SewerageConnection,
                            Attic = (bool)a.Attic,
                            StructureCategoryId = a.StructureCategoryId,
                            StructureTypeId = a.StructureTypeId,
                            MaterialTypeId = a.MaterialTypeId,
                            ArchFeature = (bool)a.ArchFeature,
                            Roofing = (bool)a.Roofing,
                            RoofingTypeId = a.RoofingTypeId,
                            TraditionalPainting = (bool)a.TraditionalPainting,
                            BuildingColourId = a.BuildingColourId,
                            BoundaryTypeId = a.BoundaryTypeId,
                            Plantation = (bool)a.Plantation,
                            WaterTankLocationId = a.WaterTankLocationId,
                            NumberDisplayed = (bool)a.NumberDisplayed,
                            ParkingSlotId = a.ParkingSlotId,
                            FireExtingusher = (bool)a.FireExtingusher,
                            WaterSupplyAccessibilityId = a.WaterSupplyAccessibilityId,
                            RoadAccess = (bool)a.RoadAccess,
                            DrainToStormWaterDrain = (bool)a.DrainToStormWaterDrain,
                            DateOfFinalInspection = a.DateOfFinalInspection,
                            OccupancyAlteredOn = a.OccupancyAlteredOn,
                            OccupancyAlteredBy = a.OccupancyAlteredBy,
                            OccupancyReferenceId = a.OccupancyReferenceId,
                            AdvanceInfoFedBy = a.AdvanceInfoFedBy,
                            AdvanceInfoInfoFedOn = a.AdvanceInfoInfoFedOn,
                            Remarks = a.Remarks,
                            ModificationRemarks = a.ModificationRemarks,
                            ModificationReasonId = a.ModificationReasonId,
                            TransactionId = a.TransactionId,
                            plotNo = b.PlotNo,
                            StoryTypeId = a.StoryTypeId

                            //ParkingSlotName = k.ParkingSlotName,
                            //WaterTankAllocationName = j.WaterTankLocation,
                            //BoundryTypeName = i.BoundaryType,
                            //RoofingTypeName = h.RoofingType,
                            //MaterialTypeName = g.MaterialType,
                            //StructureTypeName = f.StructureType,
                            //StructureCategoryName = e.StructureCategory,
                            //ConstructiTypeName = d.ConstructionType,
                            //BuildingcolorName = c.BuildingColourType
                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<BuildingDetailModel> GetAll()
        {
            var data = (from x in ctx.MstBuildingDetail
                        join y in ctx.MstLandDetail on x.LandDetailId equals y.LandDetailId

                        select new BuildingDetailModel
                        {
                            BuildingDetailId = x.BuildingDetailId,
                            LandDetailId = y.LandDetailId,
                            plotNo = y.PlotNo,
                            BuildingNo = x.BuildingNo,
                            BuildupArea = x.BuildupArea,
                            PlinthArea = x.PlinthArea,
                            NoOfUnits = x.NoOfUnits,
                            NumberOfFloors = x.NumberOfFloors,
                            GarbagServiceAccessibilityId = x.GarbagServiceAccessibilityId,
                            GarbagServiceAccessibility = x.GarbagServiceAccessibility,
                            StreetLightAccessibilityId = x.StreetLightAccessibilityId,
                            OccupancyCertificateNo = x.OccupancyCertificateNo,
                            ConstructionTypeId = x.ConstructionTypeId,
                            YearOfConstruction = x.YearOfConstruction,
                            OccupancyCertificateIssued = (bool)x.OccupancyCertificateIssued,
                            OccupancyCertificateIssueDate = x.OccupancyCertificateIssueDate,
                            PaymentCompletionStatusId = (bool)x.PaymentCompletionStatusId,
                            WaterConnection = (bool)x.WaterConnection,
                            SewerageConnection = (bool)x.SewerageConnection,
                            Attic = (bool)x.Attic,
                            StructureCategoryId = x.StructureCategoryId,
                            StructureTypeId = x.StructureTypeId,
                            MaterialTypeId = x.MaterialTypeId,
                            ArchFeature = (bool)x.ArchFeature,
                            Roofing = (bool)x.Roofing,
                            RoofingTypeId = x.RoofingTypeId,
                            TraditionalPainting = (bool)x.TraditionalPainting,
                            BuildingColourId = x.BuildingColourId,
                            BoundaryTypeId = x.BoundaryTypeId,
                            Plantation = (bool)x.Plantation,
                            WaterTankLocationId = x.WaterTankLocationId,
                            NumberDisplayed = (bool)x.NumberDisplayed,
                            ParkingSlotId = x.ParkingSlotId,
                            FireExtingusher = (bool)x.FireExtingusher,
                            WaterSupplyAccessibilityId = x.WaterSupplyAccessibilityId,
                            RoadAccess = (bool)x.RoadAccess,
                            DrainToStormWaterDrain = (bool)x.DrainToStormWaterDrain,
                            DateOfFinalInspection = x.DateOfFinalInspection,
                            OccupancyAlteredOn = x.OccupancyAlteredOn,
                            OccupancyAlteredBy = x.OccupancyAlteredBy,
                            OccupancyReferenceId = x.OccupancyReferenceId,
                            AdvanceInfoFedBy = x.AdvanceInfoFedBy,
                            AdvanceInfoInfoFedOn = x.AdvanceInfoInfoFedOn,
                            Remarks = x.Remarks,
                            ModificationRemarks = x.ModificationRemarks,
                            ModificationReasonId = x.ModificationReasonId,
                            TransactionId = x.TransactionId,

                        });
            return data.ToList();
        }

        public int Save(BuildingDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstBuildingDetail
                {
                    BuildingDetailId = obj.BuildingDetailId,
                    LandDetailId = obj.LandDetailId,
                    StoryTypeId = obj.StoryTypeId,
                    BuildingClassId = obj.BuildingClassId,
                    BuildingNo = obj.BuildingNo,
                    BuildupArea = obj.BuildupArea,
                    NoOfUnits = obj.NoOfUnits,
                    NumberOfFloors = obj.NumberOfFloors,
                    ConstructionTypeId = obj.ConstructionTypeId,
                    YearOfConstruction = obj.YearOfConstruction,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                };
                ctx.MstBuildingDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.BuildingDetailId;

                return ipk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveAddMore(BuildingDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBuildingDetail.FirstOrDefault(u => u.BuildingDetailId == obj.BuildingDetailId);
                    Data.PlinthArea = obj.PlinthArea;
                    Data.GarbagServiceAccessibilityId = obj.GarbagServiceAccessibilityId;
                    Data.StreetLightAccessibilityId = obj.StreetLightAccessibilityId;
                    Data.OccupancyCertificateNo = obj.OccupancyCertificateNo;
                    Data.OccupancyCertificateIssued = obj.OccupancyCertificateIssued;
                    Data.OccupancyCertificateIssueDate = obj.OccupancyCertificateIssueDate;
                    Data.WaterConnection = obj.WaterConnection;
                    Data.SewerageConnection = obj.SewerageConnection;
                    Data.Attic = obj.Attic;
                    Data.StructureCategoryId = obj.StructureCategoryId;
                    Data.StructureTypeId = obj.StructureTypeId;
                    Data.MaterialTypeId = obj.MaterialTypeId;
                    Data.ArchFeature = obj.ArchFeature;
                    Data.Roofing = obj.Roofing;
                    Data.RoofingTypeId = obj.RoofingTypeId;
                    Data.TraditionalPainting = obj.TraditionalPainting;
                    Data.BuildingColourId = obj.BuildingColourId;
                    Data.BoundaryTypeId = obj.BoundaryTypeId;
                    Data.Plantation = obj.Plantation;
                    Data.WaterTankLocationId = obj.WaterTankLocationId;
                    Data.NumberDisplayed = obj.NumberDisplayed;
                    Data.ParkingSlotId = obj.ParkingSlotId;
                    Data.FireExtingusher = obj.FireExtingusher;
                    Data.WaterSupplyAccessibilityId = obj.WaterSupplyAccessibilityId;
                    Data.RoadAccess = obj.RoadAccess;
                    Data.DrainToStormWaterDrain = obj.DrainToStormWaterDrain;
                    Data.DateOfFinalInspection = obj.DateOfFinalInspection;
                    Data.OccupancyAlteredOn = obj.OccupancyAlteredOn;
                    Data.OccupancyReferenceId = obj.OccupancyReferenceId;
                    Data.AdvanceInfoFedBy = 1; 
                    Data.AdvanceInfoInfoFedOn = DateTime.Now;
                    Data.Remarks = obj.Remarks;
                    Data.ModificationRemarks = obj.ModificationRemarks;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = Convert.ToDateTime(obj.ModifiedOn);
                    Data.StoryTypeId = obj.StoryTypeId;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<LandDetailModel> SearchLAndDetailsByPlotNo(string plotno)
        {
            var data = (from x in ctx.MstLandDetail.Where(x => x.PlotNo == plotno)
                        select new LandDetailModel { 
                            LandDetailId = x.LandDetailId,
                            PlotNo = x.PlotNo,
                            Location = x.Location,
                            PlotAddress = x.PlotAddress,
                            LandAcerage = x.LandAcerage,
                            IsApproved = x.IsApproved
                        });
            return data.ToList();
        }

        public int UpdateBuildingDetail(BuildingDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
        bool SewerageConnection;bool Attic;bool WaterConnection;bool ArchFeature;bool TraditionalPainting;bool Plantation;
        bool NumberDisplayed;bool FireExtingusher;bool DrainToStormWaterDrain;bool RoadAccess;bool Roofing;bool OccupancyCertificateIssued;
                    if(obj.SC == 1)
                    {
                        SewerageConnection = true;
                    }
                    else
                    {
                        SewerageConnection = false;
                    }
                    if(obj.AT == 1)
                    {
                        Attic = true;
                    }
                    else
                    {
                        Attic = false;
                    }
                    if(obj.WC == 1)
                    {
                        WaterConnection = true;
                    }
                    else
                    {
                        WaterConnection = false;
                    }
                    if(obj.AF == 1)
                    {
                        ArchFeature = true;
                    }
                    else
                    {
                        ArchFeature = false;
                    }
                    if(obj.TP == 1)
                    {
                        TraditionalPainting = true;
                    }
                    else
                    {
                        TraditionalPainting = false;
                    }
                    if(obj.PT == 1)
                    {
                        Plantation = true;
                    }
                    else
                    {
                        Plantation = false;
                    }
                    if(obj.ND == 1)
                    {
                        NumberDisplayed = true;
                    }
                    else
                    {
                        NumberDisplayed = false;
                    }
                    if(obj.FE == 1)
                    {
                        FireExtingusher = true;
                    }
                    else
                    {
                        FireExtingusher = false;
                    }
                    if(obj.DTSWD == 1)
                    {
                        DrainToStormWaterDrain = true;
                    }
                    else
                    {
                        DrainToStormWaterDrain = false;
                    }
                    if(obj.RF == 1)
                    {
                        Roofing = true;
                    }
                    else
                    {
                        Roofing = false;
                    }
                    if(obj.RA == 1)
                    {
                        RoadAccess = true;
                    }
                    else
                    {
                        RoadAccess = false;
                    }
                    if(obj.OCI == 1)
                    {
                        OccupancyCertificateIssued = true;
                    }
                    else
                    {
                        OccupancyCertificateIssued = false;
                    }
                    var Data = ctx.MstBuildingDetail.FirstOrDefault(u => u.BuildingDetailId == obj.BuildingDetailId);
                    Data.StoryTypeId = obj.StoryTypeId;
                    Data.StructureTypeId = obj.StructureTypeId;
                    Data.ConstructionTypeId = obj.ConstructionTypeId;
                    Data.GarbagServiceAccessibilityId = obj.GarbagServiceAccessibilityId;
                    Data.StreetLightAccessibilityId = obj.StreetLightAccessibilityId;
                    Data.StructureCategoryId = obj.StructureCategoryId;
                    Data.BoundaryTypeId = obj.BoundaryTypeId;
                    Data.RoofingTypeId = obj.RoofingTypeId;
                    Data.BuildingColourId = obj.BuildingColourId;
                    Data.MaterialTypeId = obj.MaterialTypeId;
                    Data.ParkingSlotId = obj.ParkingSlotId;
                    Data.WaterTankLocationId = obj.WaterTankLocationId;
                    Data.WaterSupplyAccessibilityId = obj.WaterSupplyAccessibilityId;
                    Data.LandDetailId = obj.LandDetailId;
                    Data.BuildingClassId = obj.BuildingClassId;
                    Data.YearOfConstruction = obj.YearOfConstruction;
                    Data.BuildingNo = obj.BuildingNo;
                    Data.BuildupArea = obj.BuildupArea;
                    Data.NoOfUnits = obj.NoOfUnits;
                    Data.NumberOfFloors = obj.NumberOfFloors;
                    Data.DateOfFinalInspection = obj.DateOfFinalInspection;
                    Data.Remarks = obj.Remarks;
                    Data.PlinthArea = obj.PlinthArea;
                    Data.SewerageConnection = SewerageConnection;
                    Data.Attic = Attic;
                    Data.WaterConnection = WaterConnection;
                    Data.ArchFeature = ArchFeature;
                    Data.TraditionalPainting = TraditionalPainting;
                    Data.Plantation = Plantation;
                    Data.NumberDisplayed = NumberDisplayed;
                    Data.FireExtingusher = FireExtingusher;
                    Data.DrainToStormWaterDrain = DrainToStormWaterDrain;
                    Data.RoadAccess = RoadAccess;
                    Data.Roofing = Roofing;
                    Data.OccupancyCertificateIssued = OccupancyCertificateIssued;                  
                    
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = Convert.ToDateTime(obj.ModifiedOn);
                    Data.AdvanceInfoFedBy = 1;
                    Data.AdvanceInfoInfoFedOn = DateTime.Now;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<BuildingDetailModel> fetchBuildingDetail(int LandDetailId)
        {

            var data = (from x in ctx.MstBuildingDetail.Where(x => x.LandDetailId == LandDetailId)
                        join l in ctx.MstBuildingClass on x.BuildingClassId equals l.BuildingClassId
                        //join o in ctx.TblLandOwnershipDetail on l.LandDetailId equals o.LandDetailId
                        let t = ctx.TblBuildingOwnership.Where(y => y.BuildingDetailId == x.BuildingDetailId).FirstOrDefault().BuildingOwnershipId
                        let o = ctx.TrnOccupancyCertificateApplication.Where(y => y.BuildingDetailId == x.BuildingDetailId).FirstOrDefault().OccupancyCertificateApplicationId

                        select new BuildingDetailModel
                        {
                            BuildingDetailId = x.BuildingDetailId,
                            BuildingNo = x.BuildingNo,
                            BuildupArea = x.BuildupArea,
                            NumberOfFloors = x.NumberOfFloors,
                            YearOfConstruction = (x.YearOfConstruction == null ? '-' : x.YearOfConstruction),
                            LandDetailId = x.LandDetailId,
                            OwnershipId = t,
                            OCId = o,
                            BuildingClassName = l.BuildingClassName
                            //TaxPayerId = o.TaxPayerId
                            

                        });
            return data.ToList();
        }

        public List<LandOwneshipModel> GetLandOwnershipDetails(string plotno, string cid)
        {

            var data = (from x in ctx.TblLandOwnershipDetail
                        join y in ctx.MstLandDetail on x.LandDetailId equals y.LandDetailId
                        join lo in ctx.MstTaxPayerProfile on x.TaxPayerId equals lo.TaxPayerId
                        join t in ctx.EnumTitle on lo.TitleId equals t.TitleId
                        where y.PlotNo == plotno && x.IsActive == true || lo.Cid == cid && x.IsActive == true || lo.Ttin == cid && x.IsActive == true

                        select new LandOwneshipModel
                        {
                           LandDetailId = x.LandDetailId,
                           PlotNo = y.PlotNo,
                           TaxPayerName = lo.FirstName + " " + ((lo.MiddleName == null || lo.MiddleName.Trim() == string.Empty) ? string.Empty : (lo.MiddleName + " ")) + ((lo.LastName == null || lo.LastName.Trim() == string.Empty) ? string.Empty : (lo.LastName + " ")),
                           ThramNo = x.ThramNo,
                           OwnershipPercentage =(decimal) x.OwnershipPercentage,
                           TaxPayerId = x.TaxPayerId,
                           Ttin = lo.Ttin,
                           Cid = lo.Cid,
                           LandOwnershipId = x.LandOwnershipId,
                           Plr = x.PLr
                           
                        });
            return data.ToList();
        }
        public List<BuildingUnitDetailModel> GetBuildingUnit(int BuildingDetailId, int TaxPayerId)
        {

            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingDetailId == BuildingDetailId && x.TaxPayerId == TaxPayerId && x.IsActive == true)
                        join buc in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals buc.BuildingUnitClassId
                        join bd in ctx.MstBuildingDetail on x.BuildingDetailId equals bd.BuildingDetailId
                        join fn in ctx.MstFloorName on x.FloorNameId equals fn.FloorNameId
                        join buut in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals buut.BuildingUnitUseTypeId
                        join uot in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals uot.UnitOwnerTypeId

                        select new BuildingUnitDetailModel
                        {
                            BuildingDetailId = x.BuildingDetailId,
                            BuildingUnitClassName = buc.BuildingUnitClassName,
                            Floor = fn.FloorName,
                            BuildingUnitUseTypeName = buut.BuildingUnitUseType,
                            Regularized = (x.IsRegularized == true ? "Yes" : "No"),
                            MainOwner = (x.IsMainOwner == true ? "Yes" : "No"),
                            LandDetailId = x.LandDetailId,
                            NoOfUnit = x.NoOfUnit,
                            UnitOwnerTypename = uot.UnitOwnerType,
                            FloorArea = x.FloorArea,
                            BuildingUnitDetailId = x.BuildingUnitDetailId,
                            BuildingNo = bd.BuildingNo,
                            TaxPayerId = x.TaxPayerId

                        });
            return data.ToList();
        }
        public bool Check(int id, int id2)
        {
             var a = ctx.MstBuildingUnitDetail.Any(e => e.BuildingDetailId == id && e.TaxPayerId == id2);
            return a;
           
        }

        public bool CheckBuildingOwnership(int id)
        {
            var a = ctx.TblBuildingOwnership.Any(e => e.BuildingDetailId == id);
            return a;

        }

        public bool CheckOccupancy(int id, int id2)
        {
            var a = ctx.TrnOccupancyCertificateApplication.Any(e => e.BuildingDetailId == id && e.TaxPayerId == id2);
            return a;

        }
        public int SaveBuildingDetail(BuildingDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                bool SewerageConnection; bool Attic; bool WaterConnection; bool ArchFeature; bool TraditionalPainting; bool Plantation;
                bool NumberDisplayed; bool FireExtingusher; bool DrainToStormWaterDrain; bool RoadAccess; bool Roofing; bool OccupancyCertificateIssued;
                if (obj.SC == 1)
                {
                    SewerageConnection = true;
                }
                else
                {
                    SewerageConnection = false;
                }
                if (obj.AT == 1)
                {
                    Attic = true;
                }
                else
                {
                    Attic = false;
                }
                if (obj.WC == 1)
                {
                    WaterConnection = true;
                }
                else
                {
                    WaterConnection = false;
                }
                if (obj.AF == 1)
                {
                    ArchFeature = true;
                }
                else
                {
                    ArchFeature = false;
                }
                if (obj.TP == 1)
                {
                    TraditionalPainting = true;
                }
                else
                {
                    TraditionalPainting = false;
                }
                if (obj.PT == 1)
                {
                    Plantation = true;
                }
                else
                {
                    Plantation = false;
                }
                if (obj.ND == 1)
                {
                    NumberDisplayed = true;
                }
                else
                {
                    NumberDisplayed = false;
                }
                if (obj.FE == 1)
                {
                    FireExtingusher = true;
                }
                else
                {
                    FireExtingusher = false;
                }
                if (obj.DTSWD == 1)
                {
                    DrainToStormWaterDrain = true;
                }
                else
                {
                    DrainToStormWaterDrain = false;
                }
                if (obj.RF == 1)
                {
                    Roofing = true;
                }
                else
                {
                    Roofing = false;
                }
                if (obj.RA == 1)
                {
                    RoadAccess = true;
                }
                else
                {
                    RoadAccess = false;
                }
                if (obj.OCI == 1)
                {
                    OccupancyCertificateIssued = true;
                }
                else
                {
                    OccupancyCertificateIssued = false;
                }
                var entity = new MstBuildingDetail
                {

                LandDetailId = obj.LandDetailId,
                BuildingClassId = 1,
                StoryTypeId = obj.StoryTypeId,
                BuildingNo = obj.BuildingNo,
                BuildupArea = obj.BuildupArea,
                NoOfUnits = obj.NoOfUnits,
                ConstructionTypeId = obj.ConstructionTypeId,
                YearOfConstruction = obj.YearOfConstruction,
                NumberOfFloors = obj.NumberOfFloors,
                Remarks = obj.Remarks,
                StructureTypeId = obj.StructureTypeId,
                GarbagServiceAccessibilityId = obj.GarbagServiceAccessibilityId,
                StreetLightAccessibilityId = obj.StreetLightAccessibilityId,
                StructureCategoryId = obj.StructureCategoryId,
                BoundaryTypeId = obj.BoundaryTypeId,
                RoofingTypeId = obj.RoofingTypeId,
                BuildingColourId = obj.BuildingColourId,
                MaterialTypeId = obj.MaterialTypeId,
                ParkingSlotId = obj.ParkingSlotId,
                WaterTankLocationId = obj.WaterTankLocationId,
                DateOfFinalInspection = obj.DateOfFinalInspection,
                WaterSupplyAccessibilityId = obj.WaterSupplyAccessibilityId,
                PlinthArea = obj.PlinthArea,
                SewerageConnection = SewerageConnection,
                Attic = Attic,
                WaterConnection = WaterConnection,
                ArchFeature = ArchFeature,
                TraditionalPainting = TraditionalPainting,
                Plantation = Plantation,
                NumberDisplayed = NumberDisplayed,
                FireExtingusher = FireExtingusher,
                DrainToStormWaterDrain = DrainToStormWaterDrain,
                RoadAccess = RoadAccess,
                Roofing = Roofing,
                OccupancyCertificateIssued = OccupancyCertificateIssued,
                CreatedBy = obj.CreatedBy,
                CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstBuildingDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.BuildingDetailId;
                return ipk;
;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<TaxPayerProfileModel> GetTaxPayerDetails(string TTIN, string CID)
        {

            var data = (from x in ctx.MstTaxPayerProfile.Where(x => (string.IsNullOrEmpty(TTIN) || x.Ttin == TTIN) && (string.IsNullOrEmpty(CID) || x.Cid == CID))
                        join t in ctx.EnumTitle on x.TitleId equals t.TitleId
                        select new TaxPayerProfileModel
                        {
                            Ttin = x.Ttin,
                            Name = t.Title + " " + x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            Cid = x.Cid,
                            MobileNo = x.MobileNo,
                            TaxPayerId = x.TaxPayerId

                        });
            return data.ToList();
        }

        public int SaveBuildingUnitDetail(BuildingUnitDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                bool Regularized;
                bool IsMainOwner;
                if (obj.IsR == 1)
                {
                     Regularized = true;
                }
                else {
                     Regularized = false;
                }
                if(obj.IsMOwner == 1)
                {
                    IsMainOwner = true;
                }
                else
                {
                    IsMainOwner = false;
                }
                var entity = new MstBuildingUnitDetail
                {
                    
                   LandDetailId = obj.LandDetailId,
                   BuildingDetailId = obj.BuildingDetailId,
                   BuildingUnitClassId = obj.BuildingUnitClassId,
                   FloorNameId = obj.FloorNameId,
                   BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,                   
                   IsRegularized = Regularized,
                   FloorNo = obj.FloorNo,
                   FlatNo = obj.FlatNo,
                   NoOfUnit = obj.NoOfUnit,
                   FloorArea = obj.FloorArea,
                   NoOfrooms = obj.NoOfrooms,
                   TaxPayerId = obj.TaxPayerId,
                   UnitOwnerTypeId = obj.UnitOwnerTypeId,
                   IsMainOwner = IsMainOwner,
                   Remarks = obj.Remarks,
                CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstBuildingUnitDetail.Add(entity);
                ctx.SaveChanges();

                MstLandDetail MstLandDetail = ctx.MstLandDetail.Find(obj.LandDetailId);
                MstLandDetail.StructureAvailable = true;
                ctx.SaveChanges();


                s.Complete();
                s.Dispose();
                ipk = entity.BuildingUnitDetailId;
                return ipk;
                ;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //HERE
        public async Task<BuildingUnitDetailModel> UnitDetails(int? id)
        {
            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingUnitDetailId == id)
                        join y in ctx.MstBuildingDetail on x.BuildingDetailId equals y.BuildingDetailId
                        join z in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals z.BuildingUnitClassId
                        join a in ctx.MstFloorName on x.FloorNameId equals a.FloorNameId
                        join b in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals b.UnitOwnerTypeId
                        join c in ctx.MstTaxPayerProfile on x.TaxPayerId equals c.TaxPayerId
                        join d in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals d.BuildingUnitUseTypeId
                        join e in ctx.MstLandDetail on x.LandDetailId equals e.LandDetailId
                        select new BuildingUnitDetailModel
                        {
                            BuildingUnitDetailId = x.BuildingUnitDetailId,
                            BuildingDetailId = x.BuildingDetailId,
                            BuildingUnitClassId = x.BuildingUnitClassId,
                            BuildingUnitUseTypeId = x.BuildingUnitUseTypeId,
                            FloorNameId = x.FloorNameId,
                            UnitOwnerTypeId = x.UnitOwnerTypeId,
                            FloorNo = x.FloorNo,
                            FloorArea = x.FloorArea,
                            NoOfrooms = x.NoOfrooms,
                            NoOfUnit = x.NoOfUnit,
                            TaxPayerId = x.TaxPayerId,
                            IsMainOwner = x.IsMainOwner,

                            BuildingNo = y.BuildingNo,
                            BuildingUnitClassName = z.BuildingUnitClassName,
                            Floor = a.FloorName,
                            UnitOwnerTypename = b.UnitOwnerType,
                            TaxPayerName = c.FirstName + ' ' + c.MiddleName + ' ' + c.LastName,
                            BuildingUnitUseTypeName = d.BuildingUnitUseType,
                            FlatNo = x.FlatNo,
                            IsActive = (bool)x.IsActive,
                            IsRegularized = x.IsRegularized,
                            LandDetailId = x.LandDetailId,
                            PlotNo = e.PlotNo

                        });
            return await data.FirstOrDefaultAsync();
        }

        public int UpdateUnit(BuildingUnitDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBuildingUnitDetail.FirstOrDefault(u => u.BuildingUnitDetailId == obj.BuildingUnitDetailId);
                    Data.BuildingUnitClassId = obj.BuildingUnitClassId;
                    Data.FloorNameId = obj.FloorNameId;
                    Data.BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId;
                    Data.FloorNo = obj.FloorNo;
                    Data.FloorArea = obj.FloorArea;
                    Data.NoOfUnit = obj.NoOfUnit;
                    Data.NoOfrooms = obj.NoOfrooms;
                    Data.TaxPayerId = obj.TaxPayerId;
                    Data.UnitOwnerTypeId = obj.UnitOwnerTypeId;
                    Data.IsMainOwner = obj.IsMainOwner;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = Convert.ToDateTime(obj.ModifiedOn);
                    Data.IsActive = obj.IsActive;
                    Data.IsRegularized = obj.IsRegularized;
                    Data.LandDetailId = obj.LandDetailId;
                    Data.FlatNo = obj.FlatNo;
                    Data.IsActive = obj.IsActive;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<BuildingDetailModel> GetBuildingForUpdate(int BuildingDetailId)
        {
            var data = (from x in ctx.MstBuildingDetail.Where(x => x.BuildingDetailId == BuildingDetailId)
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId 
                        join st in ctx.EnumStoryType on x.StoryTypeId equals st.StoryTypeId into z from zz in z.DefaultIfEmpty()
                        join gs in ctx.EnumServiceAccessibilityType on x.GarbagServiceAccessibilityId equals gs.ServiceAccessibilityId into a from aa in a.DefaultIfEmpty()
                        join ct in ctx.MstConstructionType on x.ConstructionTypeId equals ct.ConstructionTypeId into b from bb in b.DefaultIfEmpty()
                        join sct in ctx.MstStructureCategory on x.StructureCategoryId equals sct.StructureCategoryId into d from dd in d.DefaultIfEmpty()
                        join strt in ctx.MstStructureType on x.StructureTypeId equals strt.StructureTypeId into e from  ee in e.DefaultIfEmpty()
                        join mt in ctx.MstMaterialType on x.MaterialTypeId equals mt.MaterialTypeId into f from ff in f.DefaultIfEmpty()
                        join rt in ctx.MstRoofingType on x.RoofingTypeId equals rt.RoofingTypeId into g from gg in g.DefaultIfEmpty()
                        join bc in ctx.MstBuildingColour on x.BuildingColourId equals bc.BuildingColourId into h from hh in h.DefaultIfEmpty()
                        join bt in ctx.MstBoundaryType on x.BoundaryTypeId equals bt.BoundaryTypeId into i from ii in i.DefaultIfEmpty()
                        join wl in ctx.EnumWaterTankLocation on x.WaterTankLocationId equals wl.WaterTankLocationId into j from jj in j.DefaultIfEmpty()
                        join pl in ctx.MstParkingSlot on x.ParkingSlotId equals pl.ParkingSlotId into k from kk in k.DefaultIfEmpty()

                        select new BuildingDetailModel
                        {
                            LandDetailId = x.LandDetailId,
                            BuildingDetailId = x.BuildingDetailId,
                            plotNo = l.PlotNo,
                            YearOfConstruction = x.YearOfConstruction,
                            BuildingNo = x.BuildingNo,
                            BuildupArea = x.BuildupArea,
                              StoryTypeId = x.StoryTypeId,
                            StoryType = zz.StoryType,
                            NoOfUnits = x.NoOfUnits,
                            NumberOfFloors = x.NumberOfFloors,
                              StructureTypeId = x.StructureTypeId,
                            StructureTypeName = ee.StructureType,
                              ConstructionTypeId = x.ConstructionTypeId,
                            ConstructiTypeName = bb.ConstructionType,
                              GarbagServiceAccessibilityId = x.GarbagServiceAccessibilityId,
                            GarbagServiceAccessibilityType = aa.ServiceAccessibilityType,
                              StreetLightAccessibilityId = x.StreetLightAccessibilityId, 
                            StreetLightAccessibilityType = aa.ServiceAccessibilityType,
                              StructureCategoryId = x.StructureCategoryId,
                            StructureCategoryName = dd.StructureCategory,
                              BoundaryTypeId = x.BoundaryTypeId,
                            BoundryTypeName = ii.BoundaryType,
                              RoofingTypeId = x.RoofingTypeId,
                            RoofingTypeName = gg.RoofingType,
                              BuildingColourId = x.BuildingColourId,
                            BuildingcolorName = hh.BuildingColourType,
                              MaterialTypeId = x.MaterialTypeId,
                            MaterialTypeName = ff.MaterialType,
                              ParkingSlotId = x.ParkingSlotId,
                            ParkingSlotName = kk.ParkingSlotName,
                              WaterTankLocationId = x.WaterTankLocationId,
                            WaterTankLocationName = jj.WaterTankLocation,
                            DateOfFinalInspection = x.DateOfFinalInspection,
                            Remarks = x.Remarks,
                              WaterSupplyAccessibilityId = x.WaterSupplyAccessibilityId,
                            WaterSupplyAccessibilityType = aa.ServiceAccessibilityType,
                            PlinthArea = x.PlinthArea,
                            SewerageConnection = (bool)x.SewerageConnection,
                            Attic = (bool)x.Attic,
                            WaterConnection = (bool)x.WaterConnection,
                            ArchFeature = (bool)x.ArchFeature,
                            TraditionalPainting = (bool)x.TraditionalPainting,
                            Plantation = (bool)x.Plantation,
                            NumberDisplayed = (bool)x.NumberDisplayed,
                            FireExtingusher = (bool)x.FireExtingusher,
                            DrainToStormWaterDrain = (bool)x.DrainToStormWaterDrain,
                            RoadAccess = (bool)x.RoadAccess,
                            OccupancyCertificateIssued = (bool)x.OccupancyCertificateIssued,
                            Roofing = (bool)x.Roofing
                            
                        });
            return data.ToList();
        }

        public List<BuildingUnitDetailModel> GetBuildingUnitForUpdate(int BuildingUnitDetailId)
        {
            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingUnitDetailId == BuildingUnitDetailId)
                        join b in ctx.MstBuildingDetail on x.BuildingDetailId equals b.BuildingDetailId
                        join buc in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals buc.BuildingUnitClassId
                        join fn in ctx.MstFloorName on x.FloorNameId equals fn.FloorNameId 
                        join buut in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals buut.BuildingUnitUseTypeId
                        join t in ctx.MstTaxPayerProfile on x.TaxPayerId equals t.TaxPayerId
                        join tt in ctx.EnumTitle on t.TitleId equals tt.TitleId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join uot in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals uot.UnitOwnerTypeId

                        select new BuildingUnitDetailModel
                        {
                            BuildingUnitDetailId = x.BuildingUnitDetailId,
                            BuildingDetailId = x.BuildingDetailId,
                            LandDetailId = x.LandDetailId,
                            BuildingUnitClassId = x.BuildingUnitClassId,
                            FloorNameId = x.FloorNameId,
                            BuildingUnitUseTypeId = x.BuildingUnitUseTypeId,
                            TaxPayerId = x.TaxPayerId,
                            UnitOwnerTypeId = x.UnitOwnerTypeId,
                            IsRegularized = x.IsRegularized,
                            FloorNo = x.FloorNo,
                            FlatNo = x.FlatNo,
                            NoOfUnit = x.NoOfUnit,
                            FloorArea = x.FloorArea,
                            NoOfrooms = x.NoOfrooms,
                            IsMainOwner = x.IsMainOwner,
                            TaxPayerName = tt.Title + "" + t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            Cid = t.Cid,
                            Ttin = t.Ttin,
                            Remarks = x.Remarks
                        });
            return data.ToList();
        }

        public int UpdateBuildingUnitDetail(BuildingUnitDetailModel obj)
        {
            try
            {
                
                    using (TransactionScope s = new TransactionScope())
                {
                    bool IsRegularized; 
                    bool IsMainOwner;
                    if (obj.IsR == 1)
                    {
                        IsRegularized = true;
                    }
                    else
                    {
                        IsRegularized = false;
                    }
                    if (obj.IsMOwner == 1)
                    {
                        IsMainOwner = true;
                    }
                    else
                    {
                        IsMainOwner = false;
                    }
                    
                    var Data = ctx.MstBuildingUnitDetail.FirstOrDefault(u => u.BuildingUnitDetailId == obj.BuildingUnitDetailId);
                    Data.BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId;
                    Data.BuildingUnitClassId = obj.BuildingUnitClassId;
                    Data.FloorNameId = obj.FloorNameId;
                    Data.UnitOwnerTypeId = obj.UnitOwnerTypeId;
                    Data.NoOfUnit = obj.NoOfUnit;
                    Data.IsRegularized = IsRegularized;
                    Data.IsMainOwner = IsMainOwner;
                    Data.FloorArea = obj.FloorArea;
                    Data.FloorNo = obj.FloorNo;
                    Data.FlatNo = obj.FlatNo;
                    Data.Remarks = obj.Remarks;
                    Data.NoOfrooms = obj.NoOfrooms;                    
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = Convert.ToDateTime(obj.ModifiedOn);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }



            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<BuildingDetailModel> GetBDetail(int BuildingDetailId)
        {

            var data = (from x in ctx.MstBuildingDetail.Where(x => x.BuildingDetailId == BuildingDetailId)
                       
                        select new BuildingDetailModel
                        {
                           
                            BuildingNo = x.BuildingNo

                        });
            return data.ToList();
        }

        public List<LandOwneshipModel> GetTaxPayerName(int TaxPayerId, int LandOwnershipId)
        {

            var data = (from lo in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerId == TaxPayerId)                      
                        join t in ctx.EnumTitle on lo.TitleId equals t.TitleId
                        join l in ctx.TblLandOwnershipDetail on lo.TaxPayerId equals l.TaxPayerId
                        where l.LandOwnershipId == LandOwnershipId

                        select new LandOwneshipModel
                        {
                            TaxPayerName = t.Title + "" + lo.FirstName + " " + ((lo.MiddleName == null || lo.MiddleName.Trim() == string.Empty) ? string.Empty : (lo.MiddleName + " ")) + ((lo.LastName == null || lo.LastName.Trim() == string.Empty) ? string.Empty : (lo.LastName + " ")),
                            TaxPayerId = lo.TaxPayerId,
                            Ttin = lo.Ttin,
                            Cid = lo.Cid,
                            ThramNo = l.ThramNo


                        });
            return data.ToList();
        }
    }
}
