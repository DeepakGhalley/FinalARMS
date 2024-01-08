using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Transactions;

namespace CORE_BLL
{
    public class PartialTransferBLL : IPartialTransfer
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

        public Task<PartialTransferModel> Details(int? id)
        {
            throw new NotImplementedException();
        }

        public IList<PartialTransferModel> GetAll()
        {
            var data = (from x in ctx.TrnLandDetail
                        select new PartialTransferModel
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

        public List<BuildingDetailVM> GetBuildingDetails(int? id)
        {
            var data = (from y in ctx.MstBuildingDetail
                        join x in ctx.MstBuildingColour on y.BuildingColourId equals x.BuildingColourId
                        select new BuildingDetailVM { 
                            BuildingDetailId = y.BuildingDetailId,
                            PlinthArea = y.PlinthArea,
                            BuildingNo = y.BuildingNo,
                            BuildingColorType = x.BuildingColourType,
                            NoOfUnits = y.NoOfUnits
                            
                            
                        });
            return data.ToList();
        }

        public List<BuildingUnitDetailsVM> GetBuildingUnitDetails(int id)
        {
            var data = (from x in ctx.MstBuildingUnitDetail.Where(x => x.BuildingDetailId == id)
                        select new BuildingUnitDetailsVM { 
                            BuildingDetailId = x.BuildingDetailId,
                            FloorNo = x.FloorNo,
                            FloorArea = x.FloorArea,
                            NoOfrooms = x.NoOfrooms,
                            NoOfUnit = x.NoOfUnit,
                            IsMainOwner = x.IsMainOwner,
                            BuildingUnitDetailId = x.BuildingUnitDetailId

                        });
            return data.ToList();
        }

        public int SaveActivityType(PartialTransferModel obj)
        {
            throw new NotImplementedException();
        }

        public long SaveDemand(DemandVM obj)
        {
            try
            {
                long transactionId;
                using TransactionScope s = new TransactionScope();
                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = 3,
                    //Transaction = "Partial Property Transfer",
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

                sq = sq + 1;
                var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                int cyr = Convert.ToInt32(ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now).Max(xx => xx.CalendarYearId));// make default check at startup

                obj.FinancialYearId = Convert.ToInt32(fyr);

                int ldid = Convert.ToInt32(ctx.MstLandDetail.Where(x => x.PlotNo == obj.PlotNo).Max(xx => xx.LandDetailId));//check
                int tpid = Convert.ToInt32(ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 1 || x.TaxPayerTypeId == 2 && x.Cid == obj.Cid).Max(xx => xx.TaxPayerId));//check

                long dnid;
                var entityDN = new TblDemandNo
                {
                    DemandNo = ("TTDN/" + (DateTime.Now.Year) + "/" + sq),
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
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = obj.TotalPayable,
                    TotalAmount = obj.TotalPayable,

                    LandDetailId = ldid,
                    TaxPayerId = tpid,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
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
                };
                ctx.TblDemand.Add(entityLagthram);
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

        public int UpdateActivityType(PartialTransferModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
