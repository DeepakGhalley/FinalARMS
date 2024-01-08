using CORE_BOL;
using CORE_DLL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CORE_BLL
{
    public class BuildingUnitDetailsBLL : IBuildingUnitDetails
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BuildingUnitDetailModel> Details(int? id)
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
       
        public IList<BuildingUnitDetailModel> GetAll()
        {
            var data = (from x in ctx.MstBuildingUnitDetail
                        join y in ctx.MstBuildingDetail on x.BuildingDetailId equals y.BuildingDetailId
                        join z in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals z.BuildingUnitClassId
                        join a in ctx.MstFloorName on x.FloorNameId equals a.FloorNameId
                        join b in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals b.BuildingUnitUseTypeId
                        select new BuildingUnitDetailModel { 
                            BuildingUnitDetailId = x.BuildingUnitDetailId,
                            BuildingNo = y.BuildingNo,
                            BuildingUnitUseTypeName = b.BuildingUnitUseType,
                            BuildingUnitClassName = z.BuildingUnitClassName,
                            Floor = a.FloorName,
                            FloorNo = x.FloorNo,
                            FloorArea = x.FloorArea,
                            NoOfUnit = x.NoOfUnit,
                            NoOfrooms = x.NoOfrooms,
                            MainOwner = (x.IsMainOwner == true ? "Yes" : "No"),
                            Regularized = (x.IsRegularized == true ? "Yes" : "No"),
                            PlotNo=(ctx.MstLandDetail.Where(p=>p.LandDetailId== y.LandDetailId)).FirstOrDefault().PlotNo
                        });
            return data.ToList();
        }

        public List<BuildingUnitDetailModel> getExisitingBuildingUnitDetails(int id)
        {
            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.TaxPayerId!=100024 && x.BuildingDetailId == id)
                        join y in ctx.MstBuildingDetail on x.BuildingDetailId equals y.BuildingDetailId
                        join z in ctx.MstFloorName on x.FloorNameId equals z.FloorNameId
                        join d in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals d.BuildingUnitClassId
                        join e in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals e.BuildingUnitUseTypeId
                        join f in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals f.UnitOwnerTypeId
                        join g in ctx.MstLandDetail on y.LandDetailId equals g.LandDetailId
                        join h in ctx.MstTaxPayerProfile on x.TaxPayerId equals h.TaxPayerId
                        join t in ctx.EnumTitle on h.TitleId equals t.TitleId
                        select new BuildingUnitDetailModel
                        {
                            BuildingDetailId = y.BuildingDetailId,
                            BuildingNo = y.BuildingNo,
                            BuildingUnitClassName = d.BuildingUnitClassName,
                            BuildingUnitUseTypeName = e.BuildingUnitUseType,
                            UnitOwnerTypename = f.UnitOwnerType,
                            PlotNo = g.PlotNo,
                            TaxPayerName = t.Title + "" + h.FirstName + " " + ((h.MiddleName == null || h.MiddleName.Trim() == string.Empty) ? string.Empty : (h.MiddleName + " ")) + ((h.LastName == null || h.LastName.Trim() == string.Empty) ? string.Empty : (h.LastName + " ")),
                            Cid = h.Cid,
                            Ttin = h.Ttin,
                            FloorArea = x.FloorArea,
                            Floor = z.FloorName,
                            NoOfrooms = x.NoOfrooms,
                            Regularized = (x.IsRegularized == true ? "Yes" : "No")
                        });
            return data.ToList();
        }

        public int Save(BuildingUnitDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstBuildingUnitDetail
                {
                    BuildingDetailId = obj.BuildingDetailId,
                    BuildingUnitClassId = obj.BuildingUnitClassId,
                    FloorNameId = obj.FloorNameId,
                    BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,
                    FloorNo = obj.FloorNo,
                    FloorArea = obj.FloorArea,
                    NoOfUnit = obj.NoOfUnit,
                    NoOfrooms = obj.NoOfrooms,
                    TaxPayerId = obj.TaxPayerId,
                    UnitOwnerTypeId = obj.UnitOwnerTypeId,
                    IsMainOwner = obj.IsMainOwner,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    IsRegularized = obj.IsRegularized,
                    FlatNo = obj.FlatNo,
                    LandDetailId = obj.LandDetailId,
                    IsActive = obj.IsActive
                };
                ctx.MstBuildingUnitDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.BuildingUnitDetailId;

                return ipk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BuildingUnitDetailModel> SearchBuildingDetailsPlotNo(string plotno)
        {
            var data = (from a in ctx.MstLandDetail.Where(a => a.PlotNo == plotno)
                        join b in ctx.MstBuildingDetail on a.LandDetailId equals b.LandDetailId into bb
                        from c in bb.DefaultIfEmpty()

                        select new BuildingUnitDetailModel { 
                            BuildingDetailId = c.BuildingDetailId,
                            BuildingNo = c.BuildingNo,
                            BuildUpArea = (int)c.BuildupArea,
                            NoOfUnit = c.NoOfUnits,
                            NoofFloors = c.NumberOfFloors,
                            PlinthArea = (int)c.PlinthArea,
                            PlotNo = a.PlotNo,
                            LandDetailId = a.LandDetailId,

                        });
            return data.ToList();
        }

        public List<BuildingUnitDetailModel> SearchDetailsByCid(string cid, string ttin)
        {
            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join t in ctx.EnumTitle on x.TitleId equals t.TitleId
                        join y in ctx.TblLandOwnershipDetail on x.TaxPayerId equals y.TaxPayerId
                        join z in ctx.MstLandDetail on y.LandDetailId equals z.LandDetailId
                        select new BuildingUnitDetailModel
                        { 
                            Cid = x.Cid,
                            Ttin = x.Ttin,
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            MobileNo = x.MobileNo,
                            Email = x.Email,
                            TaxPayerId = x.TaxPayerId,
                            PlotNo = z.PlotNo, 
                            TaxPayerName = t.Title + "" + x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                        });
            return data.ToList();
        }

        public int Update(BuildingUnitDetailModel obj)
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

        //UNMAPPED BUILDING UNIT DETAILS
        public List<BuildingUnitDetailModel> getUnMappedBuildingUnitDetails(int id)
        {
            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingDetailId == id && x.TaxPayerId == 100024)
                        join y in ctx.MstBuildingDetail on x.BuildingDetailId equals y.BuildingDetailId
                        join z in ctx.MstFloorName on x.FloorNameId equals z.FloorNameId
                        join d in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals d.BuildingUnitClassId
                        join e in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals e.BuildingUnitUseTypeId
                        join f in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals f.UnitOwnerTypeId
                        join g in ctx.MstLandDetail on y.LandDetailId equals g.LandDetailId
                        join h in ctx.MstTaxPayerProfile on x.TaxPayerId equals h.TaxPayerId
                        join t in ctx.EnumTitle on h.TitleId equals t.TitleId
                        select new BuildingUnitDetailModel
                        {
                            BuildingDetailId = y.BuildingDetailId,
                            BuildingNo = y.BuildingNo,
                            BuildingUnitClassName = d.BuildingUnitClassName,
                            BuildingUnitUseTypeName = e.BuildingUnitUseType,
                            UnitOwnerTypename = f.UnitOwnerType,
                            BuildingUnitDetailId = x.BuildingUnitDetailId,
                            PlotNo = g.PlotNo,
                            TaxPayerName = t.Title + "" + h.FirstName + " " + ((h.MiddleName == null || h.MiddleName.Trim() == string.Empty) ? string.Empty : (h.MiddleName + " ")) + ((h.LastName == null || h.LastName.Trim() == string.Empty) ? string.Empty : (h.LastName + " ")),
                            Cid = h.Cid,
                            Ttin = h.Ttin,
                            FloorArea = x.FloorArea,
                            Floor = z.FloorName,
                            NoOfrooms = x.NoOfrooms,
                            Regularized = (x.IsRegularized == true ? "Yes" : "No")
                        });
            return data.ToList();
        }

        //UPDATE BUILDING UNIT DETAILS
        public long UpdateBuildingUnitDetails(BuildingUnitDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBuildingUnitDetail.FirstOrDefault(u => u.BuildingUnitDetailId == obj.BuildingUnitDetailId);
                    Data.TaxPayerId = obj.TaxPayerId;
                    Data.BuildingUnitDetailId = obj.BuildingUnitDetailId;
                   
                    ctx.SaveChanges();

                    var DataUnit = ctx.MstBuildingUnitDetail.Single(u => u.BuildingUnitDetailId == obj.BuildingUnitDetailId);

                    var BuildingData = ctx.MstBuildingDetail.Single(x => x.BuildingDetailId == DataUnit.BuildingDetailId);
                    var LandData = ctx.MstLandDetail.Single(x => x.LandDetailId == BuildingData.LandDetailId);
                    var LandOwnershipData = ctx.TblLandOwnershipDetail.Single(x => x.LandDetailId == BuildingData.LandDetailId && x.TaxPayerId==DataUnit.TaxPayerId);

                    var entity = new TblLandOwnershipDetail
                    {
                        TaxPayerId = obj.TaxPayerId,
                        LandDetailId = LandOwnershipData.LandDetailId,
                        LandOwnershipTypeId =5,
                        PLr = obj.Plr,
                        PreviousTaxPayerId = LandOwnershipData.TaxPayerId,
                        ThramNo = LandOwnershipData.ThramNo,
                        OwnershipPercentage= LandOwnershipData.OwnershipPercentage,//to be reviewed
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,                        
                     
                    };
                    ctx.TblLandOwnershipDetail.Add(entity);
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


        public List<BuildingUnitDetailModel> SearchByPlot(string PlotNo)
        {
            
               var data = (from x in  ctx.MstLandDetail.Where(x => x.PlotNo == PlotNo)
                           join y in ctx.MstBuildingDetail on x.LandDetailId equals y.LandDetailId
                           join c in ctx.MstBuildingUnitDetail on y.BuildingDetailId equals c.BuildingDetailId
                        join z in ctx.MstBuildingUnitClass on c.BuildingUnitClassId equals z.BuildingUnitClassId
                        join a in ctx.MstFloorName on c.FloorNameId equals a.FloorNameId
                        join b in ctx.MstBuildingUnitUseType on c.BuildingUnitUseTypeId equals b.BuildingUnitUseTypeId
                        join t in ctx.MstTaxPayerProfile on c.TaxPayerId equals t.TaxPayerId
                        join ct in ctx.MstConstructionType on y.ConstructionTypeId equals ct.ConstructionTypeId
                        orderby y.BuildingNo
                        select new BuildingUnitDetailModel
                        {
                            BuildingUnitDetailId = c.BuildingUnitDetailId,
                            BuildingNo = y.BuildingNo,
                            BuildingUnitUseTypeName = b.BuildingUnitUseType,
                            BuildingUnitClassName = z.BuildingUnitClassName,
                            Floor = a.FloorName,
                            FloorNo = c.FloorNo,
                            FloorArea = c.FloorArea,
                            NoOfUnit = c.NoOfUnit,
                            NoOfrooms = c.NoOfrooms,
                            MainOwner = (c.IsMainOwner == true ? "Yes" : "No"),
                            Regularized = (c.IsRegularized == true ? "Yes" : "No"),
                            PlotNo = x.PlotNo,
                           TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                           Ttin = t.Ttin,
                           ConstructionType = ct.ConstructionType

                        });
            return data.ToList();
        }

        public List<BuildingUnitDetailModel> GetBuildingUnitDetail(int id)
        {
            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingUnitDetailId == id && x.IsActive == true)
                        join d in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals d.BuildingUnitClassId
                        join e in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals e.BuildingUnitUseTypeId
                        join f in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals f.UnitOwnerTypeId
                        select new BuildingUnitDetailModel
                        {
                            BuildingUnitDetailId = x.BuildingUnitDetailId,
                            BuildingUnitClassName = d.BuildingUnitClassName,
                            BuildingUnitUseTypeName = e.BuildingUnitUseType,
                            UnitOwnerTypename = f.UnitOwnerType,
                            MainOwner = (x.IsMainOwner == true ? "Yes" : "No"),
                            Regularized = (x.IsRegularized == true ? "Yes" : "No")

                        });
            return data.ToList();
        }
    }
}
