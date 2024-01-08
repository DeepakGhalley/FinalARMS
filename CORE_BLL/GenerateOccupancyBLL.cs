using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace CORE_BLL
{
    public class GenerateOccupancyBLL : IGenerateOccupancy
    {
        readonly tt_dbContext ctx = new tt_dbContext();
       
     
        public List<OccupancyCertificate> FetchLandOwnershipDetails(string Ttin, string Cid)
        {

            var data = (from x in ctx.TblLandOwnershipDetail
                        join t in ctx.MstTaxPayerProfile on x.TaxPayerId equals t.TaxPayerId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join p in ctx.EnumPropertyType on l.PropertyTypeId equals p.PropertyTypeId
                        join o in ctx.EnumLandOwnershipType on x.LandOwnershipTypeId equals o.LandOwnershipTypeId
                        where Cid == t.Cid || Ttin == t.Ttin

                         select new OccupancyCertificate
                        {
                            
                            PlotNo = l.PlotNo,
                            Ttin = t.Ttin,
                            Cid = t.Cid,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            ThramNo = x.ThramNo,
                            PropertyType = p.PropertyType,
                            PlotAddress = l.PlotAddress,
                            LandDetailId = x.LandDetailId,
                            LandOwnershipId = x.LandOwnershipId,
                            TaxPayerId = x.TaxPayerId,
                            LandOnwershipType = o.LandOwnershipType,
                            LandOwnershipTypeId = x.LandOwnershipTypeId


                         });
            return data.ToList();
        }

        public List<BuildingDetailModel> FetchBuildingDetails(int LandDetailId,int TaxpayerId)
        {
            var GetBuildingDetailId = (
          from x in ctx.MstBuildingUnitDetail.Where(x => x.LandDetailId == LandDetailId && x.TaxPayerId == TaxpayerId)
         
          select x.BuildingDetailId).ToList();


            var data = (from x in ctx.MstBuildingDetail.Where(x => GetBuildingDetailId.Contains(x.BuildingDetailId))
                        join c in ctx.MstBuildingUnitClass on x.BuildingClassId equals c.BuildingUnitClassId
                        join s in ctx.EnumStoryType on x.StoryTypeId equals s.StoryTypeId

                        select new BuildingDetailModel
                        {

                            BuildingNo = x.BuildingNo,
                            BuildingClassName = c.BuildingUnitClassName,
                            StoryType = s.StoryType,
                            NoOfUnits = x.NoOfUnits,
                            BuildupArea = x.BuildupArea,
                            PlinthArea = x.PlinthArea,
                            NumberOfFloors = x.NumberOfFloors,
                            YearOfConstruction = x.YearOfConstruction,
                            BuildingDetailId = x.BuildingDetailId,
                            LandDetailId = x.LandDetailId,
                            DateOfFinalInspection = x.DateOfFinalInspection

                        });
            return data.ToList();
        }

        public List<BuildingUnitDetailModel> FetchBuildingUnitDetails(int BuildingDetailId, int TaxpayerId)
        {

            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingDetailId == BuildingDetailId && x.TaxPayerId == TaxpayerId)
                        join f in ctx.MstFloorName on x.FloorNameId equals f.FloorNameId
                        join u in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals u.BuildingUnitUseTypeId
                        join o in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals o.UnitOwnerTypeId

                        select new BuildingUnitDetailModel
                        {

                            Floor = f.FloorName,
                            BuildingUnitUseTypeName = u.BuildingUnitUseType,
                            UnitOwnerTypename = o.UnitOwnerType,
                            FloorArea = x.FloorArea,
                            FloorNo = x.FloorNo,
                            FlatNo = x.FlatNo,
                            NoOfrooms = x.NoOfrooms,
                            BuildingUnitDetailId = x.BuildingUnitDetailId,
                            TaxPayerId = x.TaxPayerId,
                            NoOfUnit = x.NoOfUnit
                            

                        });
            return data.ToList();
        }

        public List<OccupancyCertificate> GetBDDetails(int BuildingDetailId)
        {

            var data = (from x in ctx.TblLandOwnershipDetail
                        join t in ctx.MstTaxPayerProfile on x.TaxPayerId equals t.TaxPayerId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join b in ctx.MstBuildingDetail on l.LandDetailId equals b.LandDetailId
                        join s in ctx.EnumStoryType on b.StoryTypeId equals s.StoryTypeId
                        join o in ctx.MstBuildingUnitClass on b.BuildingClassId equals o.BuildingUnitClassId           
                        where (b.BuildingDetailId == BuildingDetailId)

                        select new OccupancyCertificate
                        {

                            PlotNo = l.PlotNo,
                            Ttin = t.Ttin,
                            Cid = t.Cid,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            ThramNo = x.ThramNo,
                            BuildingNo = b.BuildingNo,
                            StoryType = s.StoryType,
                            BuildingUnitClassName = o.BuildingUnitClassName


                        });
            return data.ToList();
        }
        public List<OccupancyCertificate> GetBUDDetails(int BuildingUnitDetailId)
        {

            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingUnitDetailId == BuildingUnitDetailId)
                        join ut in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals ut.BuildingUnitUseTypeId
                        join o in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals o.UnitOwnerTypeId
                        join c in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals c.BuildingUnitClassId
                        join t in ctx.MstTaxPayerProfile on x.TaxPayerId equals t.TaxPayerId
                        join b in ctx.MstBuildingDetail on x.BuildingDetailId equals b.BuildingDetailId
                        join bu in ctx.MstBuildingUnitClass on b.BuildingClassId equals bu.BuildingUnitClassId
                        join s in ctx.EnumStoryType on b.StoryTypeId equals s.StoryTypeId

                        select new OccupancyCertificate
                        {
                            BuildingUnitUseType = ut.BuildingUnitUseType,
                            UnitOwner = o.UnitOwnerType,
                            BuildingUnitClassName = c.BuildingUnitClassName,
                            Ttin = t.Ttin,
                            Cid = t.Cid,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            TaxPayerId = x.TaxPayerId,
                            BuildingNo = b.BuildingNo,
                            StoryType = s.StoryType

                        });
            return data.ToList();
        }

        public int SaveBuildingOC(OccupancyCertificate obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                int sq = ctx.TrnOccupancyCertificateApplication.Where(p => p.Yr == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                sq = sq + 1;

                var entity = new TrnOccupancyCertificateApplication
                {
                    
                OccupancyTypeId = obj.OccupancyTypeId,
                LandOwnershipId = obj.LandOwnershipId,
                LandDetailId = obj.LandDetailId,
                BuildingDetailId = obj.BuildingDetailId,
                TaxPayerId = obj.TaxPayerId,
                IsBuildingOc = obj.IsBuildingOc,
                DateOfFinalInspection = obj.DateOfFinalInspection,
                LogoSignMapId = obj.LogoSignMapId,
                IssueDate = obj.IssueDate,
                ValidTillDate = obj.ValidTillDate,
                IsNewOc = obj.IsNewOC,
                Sl = (int)sq,
                Yr = DateTime.Now.Year,
                OcReferenceNo = ("TT/DCD/I&MS/10" + "/" + (DateTime.Now.Year) + "/" + sq),
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                };
                ctx.TrnOccupancyCertificateApplication.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.OccupancyCertificateApplicationId;
                return ipk;
                ;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SaveBuildingUnitOC(OccupancyCertificate obj)
        {

            try
            {
                using TransactionScope s = new TransactionScope();
                string[] ids = obj.BuildingUnit.Split(',');
                var UnitId = (ctx.MstBuildingUnitDetail.Where(x => ids.Contains(x.BuildingUnitDetailId.ToString())));
                int ipk = 0;
                
                foreach (var item in UnitId.ToList())
                { 
                int? sq = ctx.TrnOccupancyCertificateApplication.Where(x => x.Yr == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                sq = sq == null ? 0 : ctx.TrnOccupancyCertificateApplication.Where(x => x.Yr == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                sq = sq + 1;

                    var entity = new TrnOccupancyCertificateApplication
                    {

                        OccupancyTypeId = obj.OccupancyTypeId,
                        LandOwnershipId = obj.LandOwnershipId,
                        LandDetailId = obj.LandDetailId,
                        BuildingDetailId = obj.BuildingDetailId,
                        BuildingUnitDetailId = item.BuildingUnitDetailId,
                        TaxPayerId = obj.TaxPayerId,
                        DateOfFinalInspection = obj.DateOfFinalInspection,
                        LogoSignMapId = obj.LogoSignMapId,
                        IssueDate = obj.IssueDate,
                        ValidTillDate = obj.ValidTillDate,
                        IsNewOc = obj.IsNewOC,
                        IsBuildingOc = obj.IsBuildingOc,
                        Sl = (int)sq,
                        Yr = DateTime.Now.Year,
                        OcReferenceNo = ("TT/DCD/I&MS/10" + "/" + (DateTime.Now.Year) + "/" + sq),
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = obj.CreatedOn,
                    };
                    ctx.TrnOccupancyCertificateApplication.Add(entity);
                    ctx.SaveChanges();
                    ipk = entity.OccupancyCertificateApplicationId;
                }
                s.Complete();
                return ipk;


            }

            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<OccupancyCertificate> CheckDuplicate(int BDId, int BTId)
        {

            var data = (from x in ctx.TrnOccupancyCertificateApplication.Where(x => x.BuildingDetailId == BDId && x.TaxPayerId == BTId)

                        select new OccupancyCertificate
                        {
                            TaxPayerId = x.TaxPayerId,
                            BuildingDetailId = x.BuildingDetailId,
                            BuildingUnitDetailId = (int)x.BuildingUnitDetailId,
                            ValidTillDate = x.ValidTillDate

                        });
            return data.ToList();
        }
        public List<OccupancyCertificate> CheckDuplicateU(int BUId, int UTId)
        {

            var data = (from x in ctx.TrnOccupancyCertificateApplication.Where(x => x.BuildingUnitDetailId == BUId && x.TaxPayerId == UTId)

                        select new OccupancyCertificate
                        {
                            TaxPayerId = x.TaxPayerId,
                            BuildingDetailId = x.BuildingDetailId,
                            BuildingUnitDetailId = (int)x.BuildingUnitDetailId,
                            ValidTillDate = x.ValidTillDate

                        });
            return data.ToList();
        }
    }
}

