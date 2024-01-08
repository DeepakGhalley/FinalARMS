using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Collections;

namespace CORE_BLL
{
    public class FullPropertyTransferBLL : IFullPropertyTransfer
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

        public Task<FullPropertyTransferModel> Details(int? id)
        {
            throw new NotImplementedException();

        }

        public IList<LocalLandJointOwners> GetLocalLandOwnershipByPlotId(string PlotNo)
        {
            var data = (from x in ctx.TblLandOwnershipDetail
                        join y in ctx.MstTaxPayerProfile on x.TaxPayerId equals y.TaxPayerId
                        join z in ctx.MstLandDetail on x.LandDetailId equals z.LandDetailId
                        where x.IsActive==true && z.PlotNo== PlotNo
                        orderby y.Cid
                        select new LocalLandJointOwners
                        {
                            Cid = y.Cid,
                            TaxPayerName = y.FirstName + " " + ((y.MiddleName == null || y.MiddleName.Trim() == string.Empty) ? string.Empty : (y.MiddleName + " ")) + ((y.LastName == null || y.LastName.Trim() == string.Empty) ? string.Empty : (y.LastName + " ")),

                            PLr = x.PLr,
                            ThramNo = x.ThramNo,
                            PlotNo = z.PlotNo,
                            LandOwnershipId = x.LandOwnershipId,
                        });
            return data.ToList();
        }
        public long SaveDemand(DemandVM obj)
        {
            try
            {
                long transactionId;
                using TransactionScope s = new TransactionScope();
                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = 1,
                    WorkLevelId = 1,
                    TransactionValue = obj.TotalPayable,
                    TaxPayerId = obj.TaxPayerId,                   
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblTransactionDetail.Add(entityTRn);
                ctx.SaveChanges();
                transactionId = entityTRn.TransactionId;
                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                sq = sq == null ? 0 : ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                sq = sq+1;

                var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x=>x.FinancialYearId);// make default check at startup
                int cyr = ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(xx => xx.CalendarYearId);// make default check at startup
              
                obj.FinancialYearId = Convert.ToInt32(fyr);
                
               int ldid = Convert.ToInt32(ctx.MstLandDetail.Where(x => x.PlotNo==obj.PlotNo).Max(xx => xx.LandDetailId));//check
                int tpid = Convert.ToInt32(ctx.MstTaxPayerProfile.Where(x =>x.TaxPayerTypeId==1 || x.TaxPayerTypeId==2 && x.Cid==obj.Cid).Max(xx => xx.TaxPayerId));//check

                long dnid;
                var entityDN = new TblDemandNo
                {
                    DemandNo =("TTDN/"+(DateTime.Now.Year)+"/" + sq),
                    Sl = (int)sq,
                    DemandYear = DateTime.Now.Year,                    
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblDemandNo.Add(entityDN);
                ctx.SaveChanges();
                dnid = entityDN.DemandNoId;
                //FOR Subdivision fee
                long ipk;
                var entity = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = 27,
                    FinancialYearId =Convert .ToInt32( fyr),
                    CalendarYearId = cyr,
                    DemandAmount = obj.TotalPayable,
                    TotalAmount = obj.TotalPayable,                   
                    LandDetailId = ldid,
                    TaxPayerId = tpid,                   
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate=DateTime.Now
                };
                ctx.TblDemand.Add(entity);
                ctx.SaveChanges();
                //FOR Lagthram fee fee              
                var entityLagthram = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = 28,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = obj.TotalPayable,
                    TotalAmount = obj.TotalPayable,
                    LandDetailId = ldid,
                    TaxPayerId = tpid,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entityLagthram);
                ctx.SaveChanges();

                var entityTrnLand = new TrnLandTransferDetail
                {
                    FromLandOwnershipId = obj.LandOwnershipId,
                    ToTaxPayerIds = obj.TransfereeIds,                   
                    LandDetailId = obj.LandDetailId,                   
                    TransactionId = transactionId,                  
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,                   
                };
                ctx.TrnLandTransferDetail.Add(entityTrnLand);
                ctx.SaveChanges();


                s.Complete();
                s.Dispose();
                ipk = entity.DemandId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<LandDetailModel> GetLandDetailsByPlotNo(string PlotNo,string Cid) 
        {
            var data = (from x in ctx.MstLandDetail.Where(x => x.PlotNo == PlotNo)
                        join sc in ctx.MstLandUseSubCategory on x.LandUseSubCategoryId equals sc.LandUseSubCategoryId
                        join d in ctx.MstDemkhong on x.DemkhongId equals  d.DemkhongId
                        join l in ctx.MstLap on x.LapId equals  l.LapId
                        join y in ctx.TblLandOwnershipDetail on x.LandDetailId equals y.LandDetailId
                        join ot in ctx.EnumLandOwnershipType on y.LandOwnershipTypeId equals ot.LandOwnershipTypeId
                        join p in ctx.MstTaxPayerProfile on y.TaxPayerId equals p.TaxPayerId
                        where p.Cid== Cid && y.IsActive== true
                        
                        select new LandDetailModel
                        {
                            LandDetailId = x.LandDetailId,
                            LapId = x.LapId,
                            DemkhongId = x.DemkhongId,
                            StreetNameId = x.StreetNameId,
                            LandTypeId = x.LandTypeId,
                            PropertyTypeId = x.PropertyTypeId,
                            LandUseSubCategoryId = x.LandUseSubCategoryId,
                            PlotNo = x.PlotNo,
                            LandAcerage = x.LandAcerage,
                            LandValue=x.LandValue,
                            LandPoolingRate=x.LandPoolingRate,
                            StructureAvailable= x.StructureAvailable,
                            PlotAddress=x.PlotAddress,
                            Location = x.Location,
                            IsApproved=x.IsApproved,
                            CreatedBy=x.CreatedBy,
                            CreationOn=x.CreationOn,
                            ModifiedBy=x.ModifiedBy,
                            ModifiedOn=x.ModifiedOn,
                            VacantLandTaxApplicable=x.VacantLandTaxApplicable,
                            StreetLightApplicable=x.StreetLightApplicable,
                            GarbageApplicable=x.GarbageApplicable,
                            ThramNo= y.ThramNo,
                            CID=p.Cid,
                            TTIN=p.Ttin,
                            PLr = y.PLr,
                            LandOwnershipType = ot.LandOwnershipType,
                            LandUseSubCategory=sc.LandUseSubCategory,
                            LapName = l.LapName,
                            DemkhongName=d.DemkhongName,LandOwnershipId=y.LandOwnershipId
                            
                        });
            return data.ToList();
        }

        public int UpdateActivityType(FullPropertyTransferModel obj)
        {
            throw new NotImplementedException();
        }
        public IList<FullPropertyTransferModel> GetAll()
        {
            var data = (from x in ctx.TrnLandDetail
                        select new FullPropertyTransferModel
                        {
                            TransactorTypeId = x.TransactorTypeId,
                            TrnFtlandDetailId = x.TrnFtlandDetailId,
                            LandTransferTypeId = x.LandTransferTypeId,
                            LapId = x.LapId,
                            DemkhongId = x.DemkhongId,
                            StreetNameId = x.StreetNameId,
                            LandTypeId = x.LandTypeId,
                            LandUseSubCategoryId = x.LandUseSubCategoryId,
                            PlotNo = x.PlotNo,
                            LandAcerage = x.LandAcerage,
                            LandPoolingRate = x.LandPoolingRate,
                            LandTransferType = x.LandTransferType,
                            LandType = x.LandType,
                            LandUseSubCategory = x.LandUseSubCategory,
                            LandValue = x.LandValue,
                            Lap = x.Lap,
                            Location = x.Location,
                            StreetLightApplicable = x.StreetLightApplicable,
                            VacantLandTaxApplicable = x.VacantLandTaxApplicable,
                            CreatedBy = x.CreatedBy,
                            CreationOn = x.CreationOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            Demkhong = x.Demkhong,
                            ESakorTransactionId = x.ESakorTransactionId,
                            GarbageApplicable = x.GarbageApplicable,
                            IsApproved = x.IsApproved,
                            PlotAddress = x.PlotAddress,
                            StreetName = x.StreetName,
                            StructureAvailable = x.StructureAvailable,
                            TransactorType = x.TransactorType

                        });
            return data.ToList();
        }

        public List<LandDetailModel> GetPlotDetailsByPlotNo(string PlotNo)
        {
            var data = (from x in ctx.MstLandDetail.Where(x => x.PlotNo == PlotNo)
                        join sc in ctx.MstLandUseSubCategory on x.LandUseSubCategoryId equals sc.LandUseSubCategoryId
                        join d in ctx.MstDemkhong on x.DemkhongId equals d.DemkhongId
                        join l in ctx.MstLap on x.LapId equals l.LapId
                        join o in ctx.TblLandOwnershipDetail on x.LandDetailId equals o.LandDetailId
                        join ot in ctx.EnumLandOwnershipType on o.LandOwnershipTypeId equals ot.LandOwnershipTypeId
                        where x.PlotNo==PlotNo
                        select new LandDetailModel
                        {
                            LandDetailId = x.LandDetailId,
                            LapId = x.LapId,
                            DemkhongId = x.DemkhongId,
                            StreetNameId = x.StreetNameId,
                            LandTypeId = x.LandTypeId,
                            PropertyTypeId = x.PropertyTypeId,
                            LandUseSubCategoryId = x.LandUseSubCategoryId,
                            PlotNo = x.PlotNo,
                            LandAcerage = x.LandAcerage,
                            LandValue = x.LandValue,
                            LandPoolingRate = x.LandPoolingRate,
                            StructureAvailable = x.StructureAvailable,
                            PlotAddress = x.PlotAddress,
                            Location = x.Location,
                            IsApproved = x.IsApproved,
                            CreatedBy = x.CreatedBy,
                            CreationOn = x.CreationOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            VacantLandTaxApplicable = x.VacantLandTaxApplicable,
                            StreetLightApplicable = x.StreetLightApplicable,
                            GarbageApplicable = x.GarbageApplicable,
                            ThramNo = x.ThramNo,
                            LandUseCategoryDescription = sc.LandUseCategoryDescription,
                            LandUseSubCategory = sc.LandUseSubCategory,
                            LapName = l.LapName,
                            DemkhongName = d.DemkhongName,
                            LandOwnershipType=ot.LandOwnershipType

                        });
            return data.ToList();
        }

        public List<TaxPayerProfileModel> CheckTaxpayerRegistration(string Cid)
        {
            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId==1 && x.Cid == Cid)
                        
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = x.TaxPayerId,
                            Cid = x.Cid,
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            TaxPayerTypeId = x.TaxPayerTypeId,

                        });
            return data.ToList();
        }
        //public IEnumerable<object> CheckTaxPayersAndLandOwnership(List<EsakorTaxPayerModel> json_data)
        //{
        //    EsakorTaxPayerModel obj = new EsakorTaxPayerModel();
        //    List<EsakorTaxPayerModel> objl = new List<EsakorTaxPayerModel>();
        //    decimal TotalArea = 0;
        //    foreach (EsakorTaxPayerModel item in json_data)
        //    {
        //        TotalArea = item.Plr + TotalArea;

        //        var data = ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 1 && x.Cid == item.Cid);

        //        if (data.Count() > 0)
        //        {
        //            foreach (var item1 in data)
        //            {
        //                EsakorTaxPayerModel smast = new EsakorTaxPayerModel();
        //                smast.TaxPayerName = item1.FirstName + "" + item1.MiddleName + "" + item1.LastName;
        //                smast.Cid = item.Cid;

        //                objl.Add(smast);
        //            }
        //        }


        //        //if (!data.Any())
        //        //{
        //        //    if (cids == "")
        //        //    {
        //        //        cids = item.Cid;
        //        //        obj.Cid = item.Cid;
        //        //    }
        //        //    else
        //        //    {
        //        //        cids = cids + "," + item.Cid;
        //        //        obj.Cid = obj.Cid + item.Cid;
        //        //    }
        //        //}
        //    }
        //    //objl = (List<EsakorTaxPayerModel>)(IList)obj;

        //    return objl;
        //}

        public async Task<List<EsakorTaxPayerModel>> CheckTaxPayersAndLandOwnershipAsync(List<EsakorTaxPayerModel> json_data)
        {
            EsakorTaxPayerModel obj = new EsakorTaxPayerModel();
            List<EsakorTaxPayerModel> objl = new List<EsakorTaxPayerModel>();
            decimal TotalArea = 0; 
            EsakorTaxPayerModel smast = new EsakorTaxPayerModel();

            foreach (EsakorTaxPayerModel item in json_data)
            {
                TotalArea = item.Plr + TotalArea;

                var data =  ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 1 && x.Cid == item.Cid);

                if (data.Count() > 0)
                {
                    //foreach (var item1 in data)
                    //{
                    //    EsakorTaxPayerModel smast = new EsakorTaxPayerModel();
                    //    smast.TaxPayerName = item1.FirstName + "" + item1.MiddleName + "" + item1.LastName;
                    //    smast.Cid = item1.Cid;
                    //    smast.TotalArea = TotalArea;
                    //    objl.Add(smast);
                    //}
                    //smast.TaxPayerName = item1.FirstName + "" + item1.MiddleName + "" + item1.LastName;
                    if (smast.Cid == null)
                    {
                        smast.Cid = item.Cid;
                    }
                    else
                    {
                        smast.Cid = smast.Cid + "," + item.Cid;
                    }
                    smast.TotalArea = TotalArea;
                    objl.Add(smast);
                }
                else
                {                    
                    if (smast.Cid == null)
                    {
                        smast.Cid = item.Cid;
                    }
                    else
                    {
                        smast.Cid = smast.Cid + "," + item.Cid;
                    }
                    smast.TotalArea = TotalArea;
                    objl.Add(smast);
                }
            }
            return  objl;
        }
    }
}
