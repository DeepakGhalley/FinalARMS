﻿using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class LandDetailBLL : ILandDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstLandDetail.Any(e => e.LandDetailId == id); ;
        }

        public async Task Delete(int? id)
        {
            var MstLandDetail = await ctx.MstLandDetail
            .FirstOrDefaultAsync(m => m.LandDetailId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstLandDetail = ctx.MstLandDetail.Find(id);
                ctx.MstLandDetail.Remove(MstLandDetail);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<LandDetailModel> Details(int? id)
        {
          
                        var data = (from a in ctx.MstLandDetail.Where(aa => aa.LandDetailId == id)
                                    join y in ctx.MstLap on a.LapId equals y.LapId
                                    join z in ctx.MstDemkhong on a.DemkhongId equals z.DemkhongId
                                    join i in ctx.MstLandType on a.LandTypeId equals i.LandTypeId
                                    join b in ctx.MstLandUseSubCategory on a.LandUseSubCategoryId equals b.LandUseSubCategoryId
                                    join c in ctx.MstStreetName on a.StreetNameId equals c.StreetNameId
                                    join f in ctx.MstLandUseCategory on b.LandUseCategoryId equals f.LandUseCategoryId
                                    join g in ctx.EnumPropertyType on a.PropertyTypeId equals g.PropertyTypeId

                                    select new LandDetailModel
                                    {
                                        LandDetailId = a.LandDetailId,
                                        LapId = a.LapId,
                                        DemkhongId = a.DemkhongId,
                                        StreetNameId = a.StreetNameId,
                                        LandTypeId = a.LandTypeId,
                                        LandUseSubCategoryId = a.LandUseSubCategoryId,
                                        PlotNo = a.PlotNo,
                                        LandAcerage = a.LandAcerage,
                                        LandValue = a.LandValue,
                                        LandPoolingRate = a.LandPoolingRate,
                                        StreetLightApplicable = (bool)a.StreetLightApplicable,
                                        PlotAddress = a.PlotAddress,
                                        Location = a.Location,
                                        IsApproved = a.IsApproved,
                                        PropertyType = g.PropertyType,
                                        PropertyTypeId = g.PropertyTypeId,
                                        LandUseCategoryId = f.LandUseCategoryId,
                                        VacantLandTaxApplicable = (bool)a.VacantLandTaxApplicable,
                                        GarbageApplicable = (bool)a.GarbageApplicable,
                                        StreetName = c.StreetName,
                                        DemkhongName = z.DemkhongName,
                                        IsApportioned = (bool)a.IsApportioned,
                                        StructureAvailable = a.StructureAvailable,
                                        ThramNo = a.ThramNo
                                    });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string PlotNo, int LandDetailId)
        {
            return ctx.MstLandDetail.Any(e => e.PlotNo == PlotNo && LandDetailId == LandDetailId);
        }

       

        public List<MstLandUseSubCategory> fetchLUSC(int id)
        {
            var data = (from a in ctx.MstLandUseSubCategory.Where(x => x.LandUseCategoryId == id)
                        
                        select new MstLandUseSubCategory
                        {
                            LandUseSubCategoryId = a.LandUseSubCategoryId,
                            LandUseSubCategory = a.LandUseSubCategory

                        });


            return data.ToList();
        }

    

        public IList<LandDetailModel> GetAll()
        {
            var data = (from a in ctx.MstLandDetail.Take(5).Where(x => x.PropertyTypeId != 2)
                        join y in ctx.MstLap on a.LapId equals y.LapId
                        join z in ctx.MstDemkhong on a.DemkhongId equals z.DemkhongId
                        join i in ctx.MstLandType on a.LandTypeId equals i.LandTypeId
                        join b in ctx.MstLandUseSubCategory on a.LandUseSubCategoryId equals b.LandUseSubCategoryId
                        join c in ctx.MstStreetName on a.StreetNameId equals c.StreetNameId
                        join p in ctx.EnumPropertyType on a.PropertyTypeId equals p.PropertyTypeId
                        select new LandDetailModel
                        {
                            LandDetailId = a.LandDetailId,
                            LapId = a.LapId,
                            DemkhongId = a.DemkhongId,
                            LandTypeId = a.LandTypeId,
                            LandUseSubCategoryId = a.LandUseSubCategoryId,
                            PlotNo = a.PlotNo,
                            LandAcerage = a.LandAcerage,
                            LandValue = a.LandValue,
                            LandPoolingRate = a.LandPoolingRate,
                            StreetLightApplicable = (bool)a.StreetLightApplicable,
                            PlotAddress = a.PlotAddress,
                            Location = a.Location,
                            IsApproved = a.IsApproved,
                            CreatedBy = a.CreatedBy,
                            CreationOn = a.CreationOn,
                            ModifiedOn = a.ModifiedOn,
                            ModifiedBy = a.ModifiedBy,
                            ThramNo = a.ThramNo,
                            VacantLandTaxApplicable = (bool)a.VacantLandTaxApplicable,
                            GarbageApplicable = (bool)a.GarbageApplicable,
                            StreetName=c.StreetName,
                            DemkhongName = z.DemkhongName,
                            PropertyType=p.PropertyType,
                            IsApportioned = (bool)a.IsApportioned
                            
                        });
            return data.ToList();
        }

        public int Save(LandDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstLandDetail
                {
                    LandDetailId = obj.LandDetailId,
                    LapId = obj.LapId,
                    DemkhongId = obj.DemkhongId,
                    StreetNameId = obj.StreetNameId,
                    LandTypeId = (int) obj.LandTypeId,
                    LandUseSubCategoryId = obj.LandUseSubCategoryId,
                    PlotNo = obj.PlotNo,
                    LandAcerage = obj.LandAcerage,
                    LandValue = 0,
                    LandPoolingRate = 0,
                    StructureAvailable = false,
                    PlotAddress = obj.PlotAddress,
                    Location = obj.PlotAddress,
                    IsApproved = obj.IsApproved,
                    CreatedBy = obj.CreatedBy,
                    CreationOn = obj.CreationOn,
                    PropertyTypeId = obj.PropertyTypeId,
                    VacantLandTaxApplicable = false,
                    GarbageApplicable = false,
                    StreetLightApplicable = false,
                    IsApportioned = obj.IsApportioned,
                    ThramNo = obj.ThramNo
                };
                ctx.MstLandDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LandDetailId;

                return ipk;
            }
            // catch (System.Exception)
            // {
            //  return 0;
            // }
            catch (Exception ex)
            {

                throw;
            }
        }


        public int Update(LandDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLandDetail.FirstOrDefault(u => u.LandDetailId == obj.LandDetailId);
                    Data.LapId = obj.LapId; Data.DemkhongId = obj.DemkhongId; Data.StreetNameId = obj.StreetNameId;
                    Data.LandTypeId = (int)obj.LandTypeId; Data.ThramNo = obj.ThramNo;
                    Data.LandUseSubCategoryId = obj.LandUseSubCategoryId;
                    Data.LandAcerage = obj.LandAcerage; Data.LandValue = 0; Data.LandPoolingRate = 0;
                    Data.StreetLightApplicable = false; Data.PlotAddress = obj.PlotAddress;
                    Data.Location = obj.PlotAddress; Data.IsApproved = obj.IsApproved;
                    Data.VacantLandTaxApplicable = false; Data.PropertyTypeId = obj.PropertyTypeId;
                    Data.GarbageApplicable = false; Data.StreetLightApplicable = false;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn; Data.IsApportioned = obj.IsApportioned;
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

        public bool DuplicateCheckOnUpdate(int LandDetailId,string PlotNo)
        {
            return ctx.MstLandDetail.Any(e =>e.LandDetailId != LandDetailId && e.PlotNo == PlotNo);

        }

        public List<MstLandDetail> getLandDetailById(int id)
        {
            var data = (from a in ctx.TblLandOwnershipDetail.Where(x => x.TaxPayerId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        
                        select new MstLandDetail
                        {
                            LandDetailId = b.LandDetailId,
                            PlotNo = b.PlotNo,
                            LandAcerage = b.LandAcerage,
                            LandValue = b.LandValue,
                            PlotAddress = b.PlotAddress,
                            Location = b.Location
                        });
            return data.ToList();
        }
        public List<MstTaxPayerProfile> fetchCID(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        select new MstTaxPayerProfile
                        {
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            TitleId = b.TitleId,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName


                        });
            return data.ToList();
        }

        public int SaveLandOwnershipDetail(LandOwnershipDetailsVM obj)
        {
            try
            {

                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblLandOwnershipDetail
                {
                    
                    LandDetailId = obj.LandDetailId,
                    TaxPayerId = obj.TaxPayerId,
                    LandOwnershipTypeId = obj.LandOwnershipTypeId,
                    ThramNo = obj.ThramNo,
                    OwnershipPercentage = 100,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    PLr = obj.PLr,
                    IsActive = true,
                    Remarks = obj.Remarks
                    //ModifiedBy = obj.ModifiedBy,
                    //ModifiedOn = Convert.ToDateTime(obj.ModifiedOn),
                };
                ctx.TblLandOwnershipDetail.Add(entity);
                ctx.SaveChanges();

                if (obj.LandOwnershipId > 0)
                {
                    if (obj.LandOwnershipTypeId == 2)
                    {


                        var entitymaxReadingId = ctx.TblLandOwnershipDetail.Where(u => u.LandDetailId == obj.LandDetailId && u.IsActive == true);
                        var LandOwnershipId = entitymaxReadingId.FirstOrDefault().LandOwnershipId;
                        var lasttaxyear = ctx.TblLandOwnershipDetail.Where(u => u.LandDetailId == obj.LandDetailId && u.IsActive == true).Max(y => y.LastTaxPaidYear);


                        var entitywr = ctx.TblLandOwnershipDetail.Where(u => u.LandOwnershipId == LandOwnershipId);
                        entitywr.FirstOrDefault().PLr = 0;
                        entitywr.FirstOrDefault().IsActive = false;
                        entitywr.FirstOrDefault().LastTaxPaidYear = lasttaxyear;
                        ctx.SaveChanges();

                        var BData = (ctx.MstBuildingDetail.Where(x => x.LandDetailId == obj.LandDetailId));

                        if (BData.Count() > 0)
                        {
                            var DataTrnUpdate = ctx.MstBuildingUnitDetail.Where(u => u.LandDetailId == obj.LandDetailId);
                            foreach (var user in DataTrnUpdate)
                            {
                                user.TaxPayerId = obj.TaxPayerId;
                                ctx.SaveChanges();
                            }

                            //  DataTrnUpdate.ForEachAsync(b => b.TaxPayerId = obj.TaxPayerId);

                        }

                    }

                }
                var A = obj.IA;
                bool IsApportioned;
                if (A == 1)
                {
                    IsApportioned = true;
                }
                else
                {
                    IsApportioned = false;
                }


                var Data = ctx.MstLandDetail.FirstOrDefault(u => u.LandDetailId == obj.LandDetailId);
                Data.IsApportioned = IsApportioned;
                ctx.SaveChanges();

                s.Complete();
                s.Dispose();
                ipk = entity.LandOwnershipId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<LandOwnershipDetailsVM> GetLandOwnershipDetail(int? id)
        {
            var data = (from x in ctx.TblLandOwnershipDetail.Where(x=>x.LandDetailId==id && x.IsActive == true)
                        join a in ctx.MstTaxPayerProfile on x.TaxPayerId equals a.TaxPayerId
                        join b in ctx.MstLandDetail on x.LandDetailId equals b.LandDetailId
                        join c in ctx.EnumLandOwnershipType on x.LandOwnershipTypeId equals c.LandOwnershipTypeId
                        
                        select new LandOwnershipDetailsVM
                        {
                            LandOwnershipId = x.LandOwnershipId,
                            TTIN = a.Ttin,
                            name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            LandDetailId = x.LandDetailId,
                            PlotNo = b.PlotNo,
                            TaxPayerId = x.TaxPayerId,
                            CID = a.Cid,
                            LandOwnershipTypeId = x.LandOwnershipTypeId,
                            LandOwnershipType = c.LandOwnershipType,
                            ThramNo = x.ThramNo,
                            netArea = x.PLr,
                            OwnershipPercentage = (decimal)x.OwnershipPercentage,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            IsApp = (b.IsApportioned == true ? "Yes" : "No"),



                        });
            return data.ToList();
        }

        public List<BuildingOwnershipVM> GetBuildingOwnershipDetail(int? id)
        {
            var data = (from x in ctx.TblBuildingOwnership.Where(x => x.LandOwnershipId == id)
                        join b in ctx.MstBuildingDetail on x.BuildingDetailId equals b.BuildingDetailId
                        join c in ctx.EnumStoryType on b.StoryTypeId equals c.StoryTypeId
                        select new BuildingOwnershipVM
                        {
                            BuildingOwnershipId=x.BuildingOwnershipId,
                            BuildingDetailId = x.BuildingDetailId,
                            BuildingNo = b.BuildingNo,
                            BuildupArea = b.BuildupArea,
                            NumberOfFloors = b.NumberOfFloors,
                            YearOfConstruction = b.YearOfConstruction,
                            storyType = c.StoryType,
                            //CreatedBy = (int)x.CreatedBy,
                            //CreatedOn = (DateTime)x.CreatedOn,
                            //ModifiedBy = (int)x.ModifiedBy,
                            //ModifiedOn = (DateTime)x.ModifiedOn,

                        });
            return data.ToList();
        }
        public List<BuildingDetailVM> DisplayOtherBuildingDetail(int landOwnId )
        {
           var data1 = (ctx.TblLandOwnershipDetail.Single(b => b.LandOwnershipId == landOwnId));
                        
            var buildingd = (
                 from x in ctx.TblBuildingOwnership.Where(x => x.LandOwnershipId == landOwnId)
                 select x.BuildingDetailId).ToList();

            var bl = (
                 from x in ctx.TblBuildingOwnership.Where(b => b.LandOwnershipId != landOwnId)
                 join lo in ctx.TblLandOwnershipDetail on x.LandOwnershipId equals lo.LandOwnershipId
                 where lo.LandDetailId == data1.LandDetailId
                 select x.BuildingDetailId).ToList();

            var data = (from x in ctx.MstBuildingDetail.Where(x => !buildingd.Contains(x.BuildingDetailId) //&& !bl.Contains(x.BuildingDetailId)
                        && x.LandDetailId== data1.LandDetailId)
                        join b in ctx.MstBuildingDetail on x.BuildingDetailId equals b.BuildingDetailId
                        join c in ctx.EnumStoryType on b.StoryTypeId equals c.StoryTypeId                      
                        join lo in ctx.TblLandOwnershipDetail on data1.LandOwnershipId equals lo.LandOwnershipId
                        join tp in ctx.MstTaxPayerProfile on lo.TaxPayerId equals tp.TaxPayerId

                        select new BuildingDetailVM
                        {
                            BuildingDetailId=b.BuildingDetailId,
                            BuildingNo = b.BuildingNo,
                            BuildupArea = b.BuildupArea,
                            NumberOfFloors = b.NumberOfFloors,
                            YearOfConstruction = b.YearOfConstruction,
                            storyType = c.StoryType,
                            ThramNo = lo.ThramNo,
                            TTIN = tp.Ttin,
                            TaxPayerName = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " "))


                        });
            return data.ToList();
        }

        public List<LandOwnershipDetailsVM> CheckDuplicateLandOwnership(int LandDetailId, int TaxPayerId)
        {
            var data = (from x in ctx.TblLandOwnershipDetail.Where(x =>x.IsActive==true && x.TaxPayerId== TaxPayerId && x.LandDetailId == LandDetailId)
                        join a in ctx.MstTaxPayerProfile on x.TaxPayerId equals a.TaxPayerId
                        join b in ctx.MstLandDetail on x.LandDetailId equals b.LandDetailId
                        join c in ctx.EnumLandOwnershipType on x.LandOwnershipTypeId equals c.LandOwnershipTypeId
                        select new LandOwnershipDetailsVM
                        {
                            LandOwnershipId = x.LandOwnershipId,
                            TTIN = a.Ttin,
                            name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            LandDetailId = x.LandDetailId,
                            PlotNo = b.PlotNo,
                            TaxPayerId = x.TaxPayerId,
                            CID = a.Cid,
                            LandOwnershipTypeId = x.LandOwnershipTypeId,
                            LandOwnershipType = c.LandOwnershipType,
                            ThramNo = x.ThramNo,
                            netArea = x.PLr,
                            OwnershipPercentage = (decimal)x.OwnershipPercentage,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,

                        });
            return data.ToList();
        }
        public int CreateBuildingOwnership(BuildingOwnershipVM obj) 
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                string[] ids = obj.Ids.Split(',');
                var bdngs = (ctx.MstBuildingDetail.Where(x => ids.Contains(x.BuildingDetailId.ToString())));
                var DataLandOwership = (ctx.TblLandOwnershipDetail.Single(x => x.LandOwnershipId==obj.LandOwnershipId));
                var pk=0;
                foreach (var item in bdngs.ToList())
                {
                    var entityR = new TblBuildingOwnership
                    {
                        BuildingDetailId = item.BuildingDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                    };
                    ctx.TblBuildingOwnership.Add(entityR);
                    ctx.SaveChanges();


                    //unit update


                }
                // ctx.SaveChanges();

                //s.Complete();
                //var unitupdate = ctx.MstBuildingUnitDetail.Where(x => BUID.Contains(x.BuildingUnitDetailId.ToString())).ToList();
                 //unitupdate.First().TaxPayerId = DataLandOwership.TaxPayerId;
                //unitu//date.ForEach(a => a.TaxPayerId = DataLandOwership.TaxPayerId);



                //var some = db.SomeTable.Where(x => ls.Contains(x.friendid)).ToList();
                //some.ForEach(a => a.status = true);
              

                //ctx.SaveChanges();
                pk = 1;
                s.Complete();

                s.Dispose();

                return pk;
               
            }
            
            catch (Exception ex)
            {
                return 0;

            }

        }

        public List<LandDetailModel> fetchLandDetailByPlotNo(string plotno)
        {

            var data = (from x in ctx.MstLandDetail.Where(x =>x.PropertyTypeId != 2 && x.PlotNo == plotno)                                             
                        join y in ctx.EnumPropertyType on x.PropertyTypeId equals y.PropertyTypeId
                        select new LandDetailModel
                        {
                            LandDetailId = x.LandDetailId,
                            PlotNo = x.PlotNo,
                            LandAcerage = x.LandAcerage,
                            LandValue = x.LandValue,
                            PropertyType = y.PropertyType,
                            PlotAddress = x.PlotAddress,
                            Location = x.Location,
                            ThramNo = x.ThramNo

                        });
            return data.ToList();
        }
        
        public List<LandDetailModel> GetData1(string ttin)
        {

            var data = (from x in ctx.MstLandDetail.Where(x => x.PropertyTypeId != 2)
                        join lod in ctx.TblLandOwnershipDetail on x.LandDetailId equals lod.LandDetailId
                        into lod_temp
                        from lod_value in lod_temp.DefaultIfEmpty()
                        join t in ctx.MstTaxPayerProfile on lod_value.TaxPayerId equals t.TaxPayerId
                        into t_temp
                        from t_value in t_temp.DefaultIfEmpty()
                        join y in ctx.EnumPropertyType on x.PropertyTypeId equals y.PropertyTypeId
                        where t_value.Ttin == ttin && lod_value.IsActive== true 
                        select new LandDetailModel
                        {
                            LandDetailId = x.LandDetailId,
                            PlotNo = x.PlotNo,
                            LandAcerage = x.LandAcerage,
                            LandValue = x.LandValue,
                            PropertyType = y.PropertyType,
                            PlotAddress = x.PlotAddress,
                            Location = x.Location,
                            ThramNo = x.ThramNo

                        });
            return data.ToList();
        }
        public List<LandDetailModel> GetData2(string cid)
        {

            var data = (from x in ctx.MstLandDetail.Where(x => x.PropertyTypeId != 2)
                        join lod in ctx.TblLandOwnershipDetail on x.LandDetailId equals lod.LandDetailId
                        into lod_temp
                        from lod_value in lod_temp.DefaultIfEmpty()
                        join t in ctx.MstTaxPayerProfile on lod_value.TaxPayerId equals t.TaxPayerId
                        into t_temp
                        from t_value in t_temp.DefaultIfEmpty()
                        join y in ctx.EnumPropertyType on x.PropertyTypeId equals y.PropertyTypeId
                        where t_value.Cid == cid && lod_value.IsActive == true
                        select new LandDetailModel
                        {
                            LandDetailId = x.LandDetailId,
                            PlotNo = x.PlotNo,
                            LandAcerage = x.LandAcerage,
                            LandValue = x.LandValue,
                            PropertyType = y.PropertyType,
                            PlotAddress = x.PlotAddress,
                            Location = x.Location,
                            ThramNo = x.ThramNo

                        });
            return data.ToList();
        }

        public List<LandOwneshipModel> GetLandOwneshipForUpdate(int LandOwnershipId)
        {

            var data = (from a in ctx.TblLandOwnershipDetail.Where(aa => aa.LandOwnershipId == LandOwnershipId)
                        join l in ctx.MstLandDetail on a.LandDetailId equals l.LandDetailId
                        join b in ctx.EnumLandOwnershipType on a.LandOwnershipTypeId equals b.LandOwnershipTypeId

                        select new LandOwneshipModel
                        {
                          LandOwnershipId = a.LandOwnershipId,
                          Plr = a.PLr,
                          ThramNo = a.ThramNo,
                          OwnershipPercentage = (decimal)a.OwnershipPercentage,
                          LandOwnershipTypeId = a.LandOwnershipTypeId,
                          Remarks = a.Remarks,
                          IsApportioned = (bool)l.IsApportioned
                          
                        });

            return data.ToList();
        }
        public int UpdateLandOwnership(LandOwneshipModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblLandOwnershipDetail.FirstOrDefault(u => u.LandOwnershipId == obj.LandOwnershipId);
                    Data.PLr = obj.Plr; Data.ThramNo = obj.ThramNo;Data.Remarks = obj.Remarks; 
                    Data.LandOwnershipTypeId = obj.LandOwnershipTypeId;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;  
                    ctx.SaveChanges();


                    var watertrnDetailData = ctx.TblLandOwnershipDetail.Where(w => w.LandOwnershipId == obj.LandOwnershipId);
                    var landDetailId = watertrnDetailData.FirstOrDefault().LandDetailId;

                    var A = obj.IA;
                    bool IsApportioned;
                    if (A == 0)
                    {
                        IsApportioned = true;
                    }
                    else
                    {
                        IsApportioned = false;
                    }
                    var Data1 = ctx.MstLandDetail.FirstOrDefault(u => u.LandDetailId == landDetailId);
                    Data1.IsApportioned = IsApportioned; 
                   
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();

                    return 1 ;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<BuildingUnitDetailModel> ViewBuildingUnit(string Ids)
        {
            string[] id = Ids.Split(',');

            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.IsActive == true && id.Contains(x.BuildingDetailId.ToString()))
                        join i in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals i.BuildingUnitClassId
                        join b in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals b.BuildingUnitUseTypeId
                        join u in ctx.EnumUnitOwnerType on x.UnitOwnerTypeId equals u.UnitOwnerTypeId
                        join f in ctx.MstFloorName on x.FloorNameId equals f.FloorNameId
                        join a in ctx.MstTaxPayerProfile on x.TaxPayerId equals a.TaxPayerId

                        select new BuildingUnitDetailModel
                        {
                            BuildingUnitClassName = i.BuildingUnitClassName,
                            BuildingUnitUseTypeName = b.BuildingUnitUseType,
                            UnitOwnerTypename = u.UnitOwnerType,
                            Floor = f.FloorName,
                            NoOfUnit = x.NoOfUnit,
                            BuildingUnitDetailId = x.BuildingUnitDetailId

                        }).Distinct();
            return (List<BuildingUnitDetailModel>)data.ToList();
        }

        public int CreateBuildingUnit(BuildingUnitDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                string[] BUID = obj.BUID.Split(',');
                var Data = ctx.MstBuildingUnitDetail.Where(x => BUID.Contains(x.BuildingUnitDetailId.ToString()));
                var DataLandOwership = ctx.TblLandOwnershipDetail.Single(x => x.LandOwnershipId == obj.LandOwnershipId);
                var pk = 0;
                foreach (var item in Data)
                {
                    var Data1 = ctx.MstBuildingUnitDetail.Where(u => u.BuildingUnitDetailId == item.BuildingUnitDetailId);

                    Data1.FirstOrDefault().TaxPayerId = DataLandOwership.TaxPayerId;
                    ctx.SaveChanges();
                    

                }
                s.Complete();
                return pk;

            }

            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
    

