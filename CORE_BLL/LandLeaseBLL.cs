using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace CORE_BLL
{
    public class LandLeaseBLL : ILandLease
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.TblLandLease.Any(e => e.LandLeaseId == id);
        }

        public async Task Delete(int? id)
        {
            var TblLandLease = await ctx.TblLandLease
                                       .FirstOrDefaultAsync(m => m.LandLeaseId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstLandLease = ctx.TblLandLease.Find(id);
                ctx.TblLandLease.Remove(MstLandLease);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<LandLeaseModel> Details(int? id)
        {
            var data = (from a in ctx.TblLandLease.Where(aa => aa.LandLeaseId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        join c in ctx.EnumBillingSchedule on a.BillingScheduleId equals c.BillingScheduleId
                        join x in ctx.EnumLeaseType on a.LeaseActivityTypeId equals x.LeaseTypeId
                        join y in ctx.EnumLeaseActivityType on a.LeaseActivityTypeId equals y.LeaseActivityTypeId
                        join z in ctx.MstTaxPayerProfile on a.TaxPayerId equals z.TaxPayerId
                        //join j in ctx.TblLandOwnershipDetail on z.TaxPayerId equals j.TaxPayerId
                        //join k in ctx.TblLandLeasePeriod on a.LandLeaseId equals k.LandLeaseId
                        select new LandLeaseModel
                        {
                            HasShed = a.HasShed,
                            HassecurityDeposit = a.HassecurityDeposit,
                            StartDate = a.StartDate,
                            LeaseAmount = a.LeaseAmount,
                            ShedAmount = a.ShedAmount,
                            Remarks = a.Remarks,
                            IsActive = a.IsActive,
                            PlotNo = b.PlotNo,
                            billingScheduleName = c.BillingSchedule,
                            leaseType = x.LeaseType,
                            leaseActivityType = y.LeaseActivity,
                            taxPayerName = z.FirstName,
                            LandLeaseId = a.LandLeaseId,
                            LandDetailId = b.LandDetailId,
                            BillingScheduleId = c.BillingScheduleId,
                            LeaseActivityTypeId = y.LeaseActivityTypeId,
                            TaxPayerId = z.TaxPayerId,
                            LeaseTypeId = x.LeaseTypeId

                            //thramNo = j.ThramNo,
                            //Ttin = z.Ttin,
                            //Cid = z.Cid,
                            //CAddressID = z.CAddress,
                            //MobileNoID = z.MobileNo,
                            //EmailID = z.Email,
                            //LocationID = b.Location,

                            //ExtensionFrom = k.StartDate,
                            //ExtensionTo = k.EndDate,
                            //ExtensionRemaks = k.Remarks

                        });

            return await data.FirstOrDefaultAsync();
        }

        public List<LandLeaseModel> fetchLandOwnerShipDetails(string Cid, string Ttin, string plotno)
        {
            var data = (from x in ctx.MstTaxPayerProfile
                        join z in ctx.TblLandLease on x.TaxPayerId equals z.TaxPayerId
                        join l in ctx.EnumLeaseType on z.LeaseTypeId equals l.LeaseTypeId
                        join a in ctx.MstLandDetail on z.LandDetailId equals a.LandDetailId into yy
                       
                        from d in yy.DefaultIfEmpty()
                        join q in ctx.TblLandLeasePeriod on z.LandLeaseId equals q.LandLeaseId
                        where (d.PlotNo == plotno || x.Cid == Cid || x.Ttin == Ttin)
                        select new LandLeaseModel
                        {
                            LandLeaseId = z.LandLeaseId,
                            PlotNo = d.PlotNo,
                            taxPayerName = x.FirstName,
                            LeaseTypeId = z.LeaseTypeId,
                            Sdate = q.EndDate.ToString("dd-MM-yyyy"),
                            LeaseAmount = z.LeaseAmount,
                            ShedAmount = z.ShedAmount,
                            LeaseName = l.LeaseType

                        });
            return data.ToList();
        }
        public List<LandLeaseModel> Listall()
        {
            var data = (from x in ctx.MstTaxPayerProfile
                        join z in ctx.TblLandLease on x.TaxPayerId equals z.TaxPayerId
                        join l in ctx.EnumLeaseType on z.LeaseTypeId equals l.LeaseTypeId
                        join a in ctx.MstLandDetail on z.LandDetailId equals a.LandDetailId into yy
                      
                        from d in yy.DefaultIfEmpty()
                        join q in ctx.TblLandLeasePeriod on z.LandLeaseId equals q.LandLeaseId

                        select new LandLeaseModel
                        {
                            LandLeaseId = z.LandLeaseId,
                            PlotNo = d.PlotNo,
                            taxPayerName = x.FirstName,
                            LeaseTypeId = z.LeaseTypeId,
                           
                            Sdate = q.EndDate.ToString("dd-MM-yyyy"),
                            LeaseAmount = z.LeaseAmount,
                            ShedAmount = z.ShedAmount,
                            LeaseName = l.LeaseType

                        });
            return data.ToList();
        }
        public List<LandLeaseModel> Temporary()
        {
            var data = (from x in ctx.MstTaxPayerProfile
                        join z in ctx.TblLandLease on x.TaxPayerId equals z.TaxPayerId
                        join l in ctx.EnumLeaseType on z.LeaseTypeId equals l.LeaseTypeId
                        join a in ctx.MstLandDetail on z.LandDetailId equals a.LandDetailId into yy

                        from d in yy.DefaultIfEmpty()
                        join q in ctx.TblLandLeasePeriod on z.LandLeaseId equals q.LandLeaseId
                        where z.LeaseTypeId == 1

                        select new LandLeaseModel
                        {
                            LandLeaseId = z.LandLeaseId,
                            PlotNo = d.PlotNo,
                            taxPayerName = x.FirstName,
                            LeaseTypeId = z.LeaseTypeId,

                            Sdate = q.EndDate.ToString("dd-MM-yyyy"),
                            LeaseAmount = z.LeaseAmount,
                            ShedAmount = z.ShedAmount,
                            LeaseName = l.LeaseType

                        });
            return data.ToList();
        }
        public List<LandLeaseModel> Shortterm()
        {
            var data = (from x in ctx.MstTaxPayerProfile
                        join z in ctx.TblLandLease on x.TaxPayerId equals z.TaxPayerId
                        join l in ctx.EnumLeaseType on z.LeaseTypeId equals l.LeaseTypeId
                        join a in ctx.MstLandDetail on z.LandDetailId equals a.LandDetailId into yy

                        from d in yy.DefaultIfEmpty()
                        join q in ctx.TblLandLeasePeriod on z.LandLeaseId equals q.LandLeaseId
                        where z.LeaseTypeId == 2

                        select new LandLeaseModel
                        {
                            LandLeaseId = z.LandLeaseId,
                            PlotNo = d.PlotNo,
                            taxPayerName = x.FirstName,
                            LeaseTypeId = z.LeaseTypeId,

                            Sdate = q.EndDate.ToString("dd-MM-yyyy"),
                            LeaseAmount = z.LeaseAmount,
                            ShedAmount = z.ShedAmount,
                            LeaseName = l.LeaseType

                        });
            return data.ToList();
        }
        public List<LandLeaseModel> Longterm()
        {
            var data = (from x in ctx.MstTaxPayerProfile
                        join z in ctx.TblLandLease on x.TaxPayerId equals z.TaxPayerId
                        join l in ctx.EnumLeaseType on z.LeaseTypeId equals l.LeaseTypeId
                        join a in ctx.MstLandDetail on z.LandDetailId equals a.LandDetailId into yy

                        from d in yy.DefaultIfEmpty()
                        join q in ctx.TblLandLeasePeriod on z.LandLeaseId equals q.LandLeaseId
                        where z.LeaseTypeId == 3
                        select new LandLeaseModel
                        {
                            LandLeaseId = z.LandLeaseId,
                            PlotNo = d.PlotNo,
                            taxPayerName = x.FirstName,
                            LeaseTypeId = z.LeaseTypeId,

                            Sdate = q.EndDate.ToString("dd-MM-yyyy"),
                            LeaseAmount = z.LeaseAmount,
                            ShedAmount = z.ShedAmount,
                            LeaseName = l.LeaseType

                        });
            return data.ToList();
        }
        public List<LandLeaseModel> fetchTaxPayerAsync(string cid, string ttin)
        {
            throw new NotImplementedException();
        }


        // public bool DuplicateCheckOnSave(int LandLeaseId)
        //{
        //   return ctx.TblLandLease.Any(e => e.LandLeaseId == LandLeaseId );
        // }

        //public bool DuplicateCheckOnUpdate(int LandLeaseId)
        //{
        //  return ctx.TblLandLease.Any(e => e.LandLeaseId == LandLeaseId && e.LandLeaseId != LandLeaseId);
        //}

        public IList<LandLeaseModel> GetAll()
        {
            var data = (from x in ctx.TblLandLease
                        join a in ctx.EnumBillingSchedule on x.BillingScheduleId equals a.BillingScheduleId
                        join b in ctx.MstLandDetail on x.LandDetailId equals b.LandDetailId
                        join c in ctx.MstTaxPayerProfile on x.TaxPayerId equals c.TaxPayerId
                        join d in ctx.EnumLeaseType on x.LeaseTypeId equals d.LeaseTypeId
                        join e in ctx.EnumLeaseActivityType on x.LeaseActivityTypeId equals e.LeaseActivityTypeId
                        //join f in ctx.MstTaxPeriod on x.TaxPeriodId equals f.TaxPeriodId
                        join g in ctx.MstTaxPayerProfile on x.TaxPayerId equals g.TaxPayerId
                        join h in ctx.TblLandOwnershipDetail on g.TaxPayerId equals h.TaxPayerId

                        select new LandLeaseModel
                        {
                            LandLeaseId = x.LandLeaseId,
                            LandDetailId = x.LandDetailId,
                            TaxPayerId = x.TaxPayerId,
                            BillingScheduleId = x.BillingScheduleId,
                            LeaseTypeId = x.LeaseTypeId,
                            LeaseActivityTypeId = x.LeaseActivityTypeId,
                            HasShed = x.HasShed,
                            HassecurityDeposit = x.HassecurityDeposit,
                            StartDate = x.StartDate,
                            LeaseAmount = x.LeaseAmount,
                            ShedAmount = x.ShedAmount,
                            Remarks = x.Remarks,
                            billingScheduleName = a.BillingSchedule,
                            leaseType = d.LeaseType,
                            leaseActivityType = e.LeaseActivity,
                            taxPayerName = c.FirstName,
                            PlotNo = b.PlotNo,

                            thramNo = h.ThramNo,
                            Ttin = g.Ttin,
                            Cid = g.Cid,
                            CAddressID = g.CAddress,
                            MobileNoID = g.MobileNo,
                            EmailID = g.Email,
                            LocationID = b.Location

                        });
            return data.ToList();
        }

        public async Task<LandLeasePeriodVM> GetDetails(int? id)
        {
            var data = (from a in ctx.TblLandLease.Where(aa => aa.LandLeaseId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        join z in ctx.MstTaxPayerProfile on a.TaxPayerId equals z.TaxPayerId
                        join j in ctx.TblLandOwnershipDetail on z.TaxPayerId equals j.TaxPayerId
                        //join k in ctx.TblLandLeasePeriod on a.LandLeaseId equals k.LandLeaseId
                        select new LandLeasePeriodVM
                        {

                            startDate = a.StartDate,
                            Plotno = b.PlotNo,
                            taxPayerName = z.FirstName,
                            LandLeaseId = a.LandLeaseId,

                            thramNo = j.ThramNo,
                            Ttin = z.Ttin,
                            Cid = z.Cid,
                            CAddressID = z.CAddress,
                            MobileNoID = z.MobileNo,
                            EmailID = z.Email,
                            LocationID = b.Location,

                            //StartDate = k.StartDate,
                            //EndDate = k.EndDate,
                            //Remarks = k.Remarks

                        });

            return await data.FirstOrDefaultAsync();
        }

        public async Task<LandLeaseModel> GetTerminateDetails(int? id)
        {
            var data = (from a in ctx.TblLandLease.Where(aa => aa.LandLeaseId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        join z in ctx.MstTaxPayerProfile on a.TaxPayerId equals z.TaxPayerId
                        join j in ctx.TblLandOwnershipDetail on z.TaxPayerId equals j.TaxPayerId
                        select new LandLeaseModel
                        {

                            StartDate = a.StartDate,
                            PlotNo = b.PlotNo,
                            taxPayerName = z.FirstName,
                            LandLeaseId = a.LandLeaseId,

                            thramNo = j.ThramNo,
                            Ttin = z.Ttin,
                            Cid = z.Cid,
                            CAddressID = z.CAddress,
                            MobileNoID = z.MobileNo,
                            EmailID = z.Email,
                            LocationID = b.Location,
                            TerminateReason = a.TerminateReason,
                            TerminateDate = (DateTime)a.TerminateDate


                        });

            return await data.FirstOrDefaultAsync();
        }

        public int Save(LandLeaseModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblLandLease
                {
                    LandLeaseId = obj.LandLeaseId,
                    LandDetailId = 7, //TEMPORARY, Dynamic coming soon
                    TaxPayerId = obj.TaxPayerId,
                    BillingScheduleId = obj.BillingScheduleId,
                    LeaseTypeId = obj.LeaseTypeId,
                    LeaseActivityTypeId = obj.LeaseActivityTypeId,
                    HasShed = obj.HasShed,
                    HassecurityDeposit = obj.HassecurityDeposit,
                    StartDate = obj.StartDate,
                    LeaseAmount = obj.LeaseAmount,
                    ShedAmount = obj.ShedAmount,
                    Remarks = obj.Remarks,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblLandLease.Add(entity);
                ctx.SaveChanges();
                ipk = entity.LandLeaseId;

                int ipkk;
                var entityp = new TblLandLeasePeriod
                {
                    LandLeasePeriodId = obj.LandLeasePeriodId,
                    LandLeaseId = 1,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblLandLeasePeriod.Add(entityp);
                ctx.SaveChanges();
                ipkk = entityp.LandLeasePeriodId;

                s.Complete();
                s.Dispose();

                return ipk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveExtension(LandLeasePeriodVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblLandLeasePeriod
                {
                    LandLeaseId = obj.LandLeaseId,
                    LandLeasePeriodId = obj.LandLeasePeriodId,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    Remarks = obj.Remarks,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblLandLeasePeriod.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LandLeasePeriodId;

                return ipk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(LandLeaseModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblLandLease.FirstOrDefault(u => u.LandLeaseId == obj.LandLeaseId);
                    Data.LandDetailId = obj.LandDetailId; Data.TaxPayerId = obj.TaxPayerId; Data.BillingScheduleId = obj.BillingScheduleId;
                    Data.LeaseTypeId = obj.LeaseTypeId; Data.LeaseActivityTypeId = obj.LeaseActivityTypeId;
                    //Data.TaxPeriodId = obj.TaxPeriodId; 
                    Data.HasShed = obj.HasShed; Data.HassecurityDeposit = obj.HassecurityDeposit;
                    Data.StartDate = obj.StartDate;
                    //Data.EndDate = obj.EndDate;
                    Data.LeaseAmount = obj.LeaseAmount;
                    Data.ShedAmount = obj.ShedAmount; Data.Remarks = obj.Remarks; Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
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

        public int UpdateTermination(LandLeaseModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblLandLease.FirstOrDefault(u => u.LandLeaseId == obj.LandLeaseId);
                    Data.IsActive = false;
                    Data.TerminateDate = obj.TerminateDate;
                    Data.TerminateReason = obj.TerminateReason;
                    Data.ModifiedBy = obj.ModifiedBy; 
                    Data.ModifiedOn = obj.ModifiedOn;
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

        public List<LandLeaseModel> fetchTaxPayer(string cid, string ttin)
        {
            throw new NotImplementedException();
        }

        public List<TaxPayerProfileModel> fetchTaxPayerDetail(string cid, string ttin)
        {

            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid  || x.Ttin == ttin)
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = x.TaxPayerId,
                            Ttin = x.Ttin,
                            Cid = x.Cid,
                            Name = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            MobileNo = x.MobileNo

                        });
            return data.ToList();
        }

        public long Savelongterm(LandDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();


                var lri = obj.LeaseActivityTypeId;
                var lti = 0;
                if (lri == 1) { lti = 6; } 
                else if(lri == 2){ lti = 1; }
                else if(lri == 3){ lti = 3; } 
                else if (lri == 4){ lti = 2; }
                else if (lri == 5) { lti = 4; }
              else
                {
                    lti = 5;
                }

                //FOR Subdivision fee


                int ipk;
                int ipkk;
                var entity1 = new MstLandDetail
                {
                    //LandDetailId = obj.LandDetailId,
                    PlotNo = obj.PlotNo,
                    LandAcerage = obj.LandAcerage,
                    LandValue = obj.LandValue,
                    LandPoolingRate = obj.LandPoolingRate,
                    PlotAddress = obj.PlotAddress,
                    Location = obj.Location,
                    LapId = obj.LapId,
                    CreatedBy = obj.CreatedBy,
                    PropertyTypeId = 2,
                    StructureAvailable = obj.StructureAvailable,
                    VacantLandTaxApplicable = obj.VacantLandTaxApplicable,
                    GarbageApplicable = obj.GarbageApplicable,
                    StreetLightApplicable = obj.StreetLightApplicable,
                    StreetNameId = obj.StreetNameId,
                    LandUseSubCategoryId = 1,
                    DemkhongId = obj.DemkhongId,
                    LandTypeId = lti,
                    IsApproved = obj.IsApproved,
                    CreationOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.MstLandDetail.Add(entity1);
                ctx.SaveChanges();
                ipk = entity1.LandDetailId;

                var entityp = new TblLandLease
                {
                    LandLeaseId = obj.LandLeaseId,
                    LandDetailId = (int)ipk,
                    TaxPayerId = obj.TaxPayerId,
                    BillingScheduleId = obj.BillingScheduleId,
                    LeaseTypeId = obj.LeaseTypeId,
                    LeaseActivityTypeId = obj.LeaseActivityTypeId,
                    HasShed = obj.HasShed,
                    HassecurityDeposit = obj.HassecurityDeposit,
                    StartDate = obj.StartDate,
                    LeaseAmount = obj.LeaseAmount,
                    ShedAmount = obj.ShedAmount,
                    LeaseApprovalNo = obj.LeaseApprovalNo,
                    Remarks = obj.Remarks,
                    IsActive = true,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLease.Add(entityp);
                ctx.SaveChanges();
                ipkk = entityp.LandLeaseId;

                var entityperiod = new TblLandLeasePeriod
                {
                    LandLeasePeriodId = obj.LandLeasePeriodId,
                    LandLeaseId = ipkk,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLeasePeriod.Add(entityperiod);
                ctx.SaveChanges();


                int pDays = GetMonthDifference(obj.StartDate ,obj.EndDate) ;

                long pfddid = 0;
                
              

                s.Complete();
                s.Dispose();

                return ipkk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }



        public int SaveLandDetail(LandDetailModel obj)
        {
            try
            {

                var lri = obj.LeaseActivityTypeId;
                var lti = 0;
                if (lri == 1) { lti = 6; }
                else if (lri == 2) { lti = 1; }
                else if (lri == 3) { lti = 3; }
                else if (lri == 4) { lti = 2; }
                else if (lri == 5) { lti = 4; }
                else
                {
                    lti = 5;
                }
                using TransactionScope s = new TransactionScope();
                int ipk;
                int ipkk;
                var entity = new MstLandDetail
                {
                    //LandDetailId = obj.LandDetailId,
                    PlotNo = obj.PlotNo,
                    LandAcerage = obj.LandAcerage,
                    LandValue = obj.LandValue,
                    LandPoolingRate = obj.LandPoolingRate,
                    PlotAddress = obj.PlotAddress,
                    Location = obj.Location,
                    LapId = 1,
                    CreatedBy = obj.CreatedBy,
                    PropertyTypeId = 2,
                    StructureAvailable = obj.StructureAvailable,
                    VacantLandTaxApplicable = obj.VacantLandTaxApplicable,
                    GarbageApplicable = obj.GarbageApplicable,
                    StreetLightApplicable = obj.StreetLightApplicable,
                    StreetNameId = 1,
                    LandUseSubCategoryId = obj.LandUseSubCategoryId,
                    DemkhongId = 1,
                    LandTypeId = lri,
                    IsApproved = obj.IsApproved,
                    CreationOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.MstLandDetail.Add(entity);
                ctx.SaveChanges();
                ipk = entity.LandDetailId;

                var entityp = new TblLandLease
                {
                    LandLeaseId = obj.LandLeaseId,
                    LandDetailId = ipk,
                    TaxPayerId = obj.TaxPayerId,
                    BillingScheduleId = obj.BillingScheduleId,
                    LeaseTypeId = obj.LeaseTypeId,
                    LeaseActivityTypeId = obj.LeaseActivityTypeId,
                    HasShed = obj.HasShed,
                    HassecurityDeposit = obj.HassecurityDeposit,
                    StartDate = obj.StartDate,
                    LeaseAmount = obj.LeaseAmount,
                    ShedAmount = obj.ShedAmount,
                    Remarks = obj.Remarks,
                    IsActive = true,
                    LeaseApprovalNo = obj.LeaseApprovalNo,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLease.Add(entityp);
                ctx.SaveChanges();
                ipkk = entityp.LandLeaseId;

                var entityperiod = new TblLandLeasePeriod
                {
                    LandLeasePeriodId = obj.LandLeasePeriodId,
                    LandLeaseId = ipkk,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLeasePeriod.Add(entityperiod);
                ctx.SaveChanges();

                s.Complete();
                s.Dispose();

                return ipkk;
            }
            catch (Exception ex)
            {
                return 0;
            }
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

        public long SaveLandLeaselongterm(LandDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();

              


                long pfddid = 0;

                //FOR Subdivision fee
                long ipk;
           


               
                int ipkk;
                var entityp = new TblLandLease
                {
                    LandDetailId = obj.LandDetailId,
                    TaxPayerId = obj.TaxPayerId,
                    BillingScheduleId = 3,
                    LeaseTypeId = obj.LeaseTypeId,
                    LeaseActivityTypeId = obj.LeaseActivityTypeId,
                    HasShed = obj.HasShed,
                    //HassecurityDeposit = obj.HassecurityDeposit,
                    StartDate = obj.StartDate,
                    LeaseAmount = obj.LeaseAmount,
                    ShedAmount = obj.ShedAmount,
                    Remarks = obj.Remarks,
                    IsActive = obj.IsActive,
                    LeaseApprovalNo = obj.LeaseApprovalNo,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLease.Add(entityp);
                ctx.SaveChanges();
                ipkk = entityp.LandLeaseId;

                var entityperiod = new TblLandLeasePeriod
                {
                    LandLeasePeriodId = obj.LandLeasePeriodId,
                    LandLeaseId = ipkk,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLeasePeriod.Add(entityperiod);
                ctx.SaveChanges();

                int pDays = GetMonthDifference(obj.StartDate, obj.EndDate);

               
               
                s.Complete();
                s.Dispose();
                ipk = entityperiod.LandLeaseId;

                return ipkk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SaveLandLease(LandDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                int ipkk;
                var entityp = new TblLandLease
                {
                    LandDetailId = obj.LandDetailId,
                    TaxPayerId = obj.TaxPayerId,
                    BillingScheduleId = 1,
                    LeaseTypeId = obj.LeaseTypeId,
                    LeaseActivityTypeId = obj.LeaseActivityTypeId,
                    HasShed = obj.HasShed,
                    //HassecurityDeposit = obj.HassecurityDeposit,
                    StartDate = obj.StartDate,
                    LeaseAmount = obj.LeaseAmount,
                    ShedAmount = obj.ShedAmount,
                    Remarks = obj.Remarks,
                    IsActive = obj.IsActive,
                    LeaseApprovalNo = obj.LeaseApprovalNo,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLease.Add(entityp);
                ctx.SaveChanges();
                ipkk = entityp.LandLeaseId;

                var entityperiod = new TblLandLeasePeriod
                {
                    LandLeasePeriodId = obj.LandLeasePeriodId,
                    LandLeaseId = ipkk,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.TblLandLeasePeriod.Add(entityperiod);
                ctx.SaveChanges();

                s.Complete();
                s.Dispose();
                ipk = entityperiod.LandLeaseId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SaveLandPeriod(LandLeasePeriodVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblLandLeasePeriod
                {
                    LandLeasePeriodId = obj.LandLeasePeriodId,
                    LandLeaseId = obj.LandLeaseId,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblLandLeasePeriod.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LandLeasePeriodId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<LandLeaseModel> LandLeaseDetails(int id)
        {

            var data = from x in ctx.TblLandLease.Where(x => x.TaxPayerId == id)
                       join y in ctx.EnumBillingSchedule on x.BillingScheduleId equals y.BillingScheduleId
                       join z in ctx.EnumLeaseType on x.LeaseTypeId equals z.LeaseTypeId
                       join a in ctx.EnumLeaseActivityType on x.LeaseActivityTypeId equals a.LeaseActivityTypeId
                       join b in ctx.TblLandLeasePeriod on x.LandLeaseId equals b.LandLeaseId
                       join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId

                       //orderby x.StartDate descending

                       select new LandLeaseModel
                       {
                           LandLeaseId = x.LandLeaseId,
                           BillingScheduleId = x.BillingScheduleId,
                           billingScheduleName = y.BillingSchedule,
                           LeaseTypeId = x.LeaseTypeId,
                           leaseType = z.LeaseType,
                           leaseActivityType = a.LeaseActivity,
                           LeaseActivityTypeId = x.LeaseActivityTypeId,
                           EndDateString = b.EndDate.ToString("yyyyMMdd"),
                           StartDateString = b.StartDate.ToString("yyyyMMdd"),
                           StartDate = b.StartDate,
                           EndDate = b.EndDate,
                           ShedAmount = x.ShedAmount,
                           LeaseAmount = x.LeaseAmount,
                           PlotNo = l.PlotNo
                       };

            return data.ToList();
        }

        public IEnumerable<VendorDemandScheduleModel> GetVendorDemandSchedule(int Id,int yr, string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.VendorDemandSchedule.FromSqlRaw($"GetLandLeaseDemandScheduleMonthly {Id},{yr},{StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public IEnumerable<LongtermleaseVM> GetLongTermLandLease (int Id, string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.LongTermLandLeaseDemandSchedule.FromSqlRaw($"GetLongTermLandLease {Id},{StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public long GenerateDemand(int landLeaseId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int taxId, int totalDays, string IDate)
        {

            try
            {
                var LandLease = ctx.TblLandLease.Where(w => w.LandLeaseId == landLeaseId);
                var LeaseActivityTypeId = LandLease.FirstOrDefault().LeaseActivityTypeId;
                var BillingScheduleId = LandLease.FirstOrDefault().BillingScheduleId;

                var ti = 0;
                if (LeaseActivityTypeId == 1) {
                    ti = 20;
                }
                 else if (LeaseActivityTypeId == 2) {
                    ti = 21;
                }
                else if (LeaseActivityTypeId == 3) {
                    ti = 61;
                }
                else if (LeaseActivityTypeId == 4) {
                    ti = 83;
                }
                else if (LeaseActivityTypeId == 5) {
                    ti = 84;
                }
                else
                {
                    ti = 85;
                }

                decimal AmountForDays = Convert.ToDecimal((Amount / totalDays) * pDays);

                long transactionId;
                using TransactionScope s = new TransactionScope();
                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = 16,
                    WorkLevelId = 1,
                    TransactionValue = Amount,
                    TaxPayerId = taxPayerId,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblTransactionDetail.Add(entityTRn);
                ctx.SaveChanges();
                transactionId = entityTRn.TransactionId;
                int sq = ctx.TblDemandNo.Where(p => p.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                sq = sq + 1;

                var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                int cyr = ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(xx => xx.CalendarYearId);// make default check at startup

                long dnid;
                var entityDN = new TblDemandNo
                {
                    DemandNo = ("TTDN/" + (DateTime.Now.Year) + "/" + sq),
                    Sl = (int)sq,
                    DemandYear = DateTime.Now.Year,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblDemandNo.Add(entityDN);
                ctx.SaveChanges();
                dnid = entityDN.DemandNoId;
                DateTime ID;
                CultureInfo provider = CultureInfo.InvariantCulture;

                if (BillingScheduleId == 3)
                {
                    //ID = Convert.ToDateTime(IDate);
                   ID = DateTime.ParseExact(IDate,"dd/MM/yyyy", provider);
                }
                else
                {
                    ID = Convert.ToDateTime(pYear + "-" + pMonth + "-10");
                }
                var entitypd = new TblLandLeaseDemandDetail
                {
                    LandLeaseId = landLeaseId,
                    DemandNoId = dnid,
                    DemandDays = pDays,
                    DemandGenerateScheduleId = pMonth,
                    DemandYear = pYear,
                    InstallmentAmount = AmountForDays,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    InstallmentDate = ID,

                };
                ctx.TblLandLeaseDemandDetail.Add(entitypd);
                ctx.SaveChanges();
                long pfddid = 0;
                pfddid = entitypd.LandLeaseDemandDetailId;
                //FOR Subdivision fee
                long ipk;
                var entity = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = ti,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = AmountForDays,
                    TotalAmount = AmountForDays,
                    LandLeaseDemandDetailId = pfddid,
                    TaxPayerId = taxPayerId,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now /*Convert.ToDateTime((pYear.ToString() + "-" + pMonth.ToString() + "-" + totalDays))*/
                };
                ctx.TblDemand.Add(entity);
                ctx.SaveChanges();


                s.Complete();
                s.Dispose();


                return dnid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LandLeaseModel> GetDemand(int DemandNoId)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                       join z in ctx.MstTaxPayerProfile on x.TaxPayerId equals z.TaxPayerId
                       join a in ctx.MstTaxMaster on x.TaxId equals a.TaxId
                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       join hp in ctx.TblLandLeaseDemandDetail on x.DemandNoId equals hp.DemandNoId
                       join hd in ctx.TblLandLeasePeriod on hp.LandLeaseId equals hd.LandLeaseId

                       let qr = GenerateQr(dn.ToString())

                       select new LandLeaseModel
                       {
                           TaxPayerId = (int)x.TaxPayerId,
                           taxPayerName = z.FirstName + " " + ((z.MiddleName == null || z.MiddleName.Trim() == string.Empty) ? string.Empty : (z.MiddleName + " ")) + ((z.LastName == null || z.LastName.Trim() == string.Empty) ? string.Empty : (z.LastName + " ")),
                           Ttin = z.Ttin,
                           Cid = z.Cid,
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                           CAddressID = z.CAddress,
                           LeaseAmount = x.TotalAmount,
                           DemandDate = x.CreatedOn,
                           TaxName = a.TaxName,
                           QrImage = qr,
                           DemandNo = y.DemandNo,
                           SStartDate = hd.StartDate,
                           EEndDate = hd.EndDate

                       }; ;
            return data.ToList();
        }

        public byte[] GenerateQr(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytesCode(qrCodeImage);
            // return View(BitmapToBytesCode(qrCodeImage));
        }
        //[NonAction]
        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public bool DuplicateCheckOnUpdate()
        {
            return ctx.TblLandLease.Any(e => e.IsActive == false);
        }

        public IList<LandDetailModel> GetPlotNo(string plotNo)
        {
            var data = from x in ctx.MstLandDetail.Where(aa => aa.PlotNo == plotNo && aa.PropertyTypeId == 2)
                        select new LandDetailModel
                        {
                            PlotNo = x.PlotNo,
                            LandAcerage = x.LandAcerage,
                            LandValue = x.LandValue,
                            PlotAddress = x.PlotAddress,
                            Location = x.Location,
                            LandPoolingRate = x.LandPoolingRate,
                            LandUseSubCategoryId = x.LandUseSubCategoryId,
                            StreetNameId = x.StreetNameId,
                            LapId = x.LapId,
                            PropertyTypeId = x.PropertyTypeId,
                            StructureAvailable = x.StructureAvailable,
                            VacantLandTaxApplicable = x.VacantLandTaxApplicable,
                            GarbageApplicable = x.GarbageApplicable,
                            StreetLightApplicable = x.StreetLightApplicable,
                            DemkhongId = x.DemkhongId,
                            LandTypeId = x.LandTypeId,
                            IsApproved = x.IsApproved,
                            LandDetailId = x.LandDetailId

                        };
            return data.ToList();
        }


        public List<LandLeaseModel> GetDemandlongterm(long TransactionId)
        {
            var DataDemand = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
            var DemandNoId = DataDemand.FirstOrDefault().DemandNoId;
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                       
                       join z in ctx.MstTaxPayerProfile on x.TaxPayerId equals z.TaxPayerId
                       join a in ctx.MstTaxMaster on x.TaxId equals a.TaxId
                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       join hp in ctx.TblLandLeaseDemandDetail on x.DemandNoId equals hp.DemandNoId
                       join hd in ctx.TblLandLeasePeriod on hp.LandLeaseId equals hd.LandLeaseId

                       let qr = GenerateQr(dn.ToString())

                       select new LandLeaseModel
                       {
                           TaxPayerId = (int)x.TaxPayerId,
                           taxPayerName = z.FirstName + " " + ((z.MiddleName == null || z.MiddleName.Trim() == string.Empty) ? string.Empty : (z.MiddleName + " ")) + ((z.LastName == null || z.LastName.Trim() == string.Empty) ? string.Empty : (z.LastName + " ")),
                           Ttin = z.Ttin,
                           Cid = z.Cid,
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                           CAddressID = z.CAddress,
                           LeaseAmount = x.TotalAmount,
                           DemandDate = x.CreatedOn,
                           TaxName = a.TaxName,
                           QrImage = qr,
                           DemandNo = dn,
                           SStartDate = hd.StartDate,
                           EEndDate = hd.EndDate

                       }; 
            return data.ToList();
        }
        public List<LandLeaseModel> DisplayExistingLease(int TaxPayerId)
        {

            var data = (from x in ctx.TblLandLease.Where(x => x.TaxPayerId == TaxPayerId)
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join b in ctx.EnumBillingSchedule on x.BillingScheduleId equals b.BillingScheduleId
                        join lt in ctx.EnumLeaseType on x.LeaseTypeId equals lt.LeaseTypeId
                        join lat in ctx.EnumLeaseActivityType on x.LeaseActivityTypeId equals lat.LeaseActivityTypeId

                        select new LandLeaseModel
                        {
                            PlotNo = l.PlotNo,
                            billingScheduleName = b.BillingSchedule,
                            leaseType = lt.LeaseType,
                            leaseActivityType = lat.LeaseActivity,
                            StartDate = x.StartDate,
                            LeaseAmount = x.LeaseAmount,
                            LandDetailId = x.LandDetailId,
                            LandLeaseId = x.LandLeaseId
                        });
            return data.ToList();
        }

        public List<LandLeaseModel> GetLeaseDetailsForUpdate(int LandLeaseId)
        {

            var data = (from x in ctx.TblLandLease
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join b in ctx.EnumBillingSchedule on x.BillingScheduleId equals b.BillingScheduleId
                        join lt in ctx.EnumLeaseType on x.LeaseTypeId equals lt.LeaseTypeId
                        join lat in ctx.EnumLeaseActivityType on x.LeaseActivityTypeId equals lat.LeaseActivityTypeId
                        join lp in ctx.TblLandLeasePeriod on x.LandLeaseId equals lp.LandLeaseId
                        where (x.LandLeaseId == LandLeaseId && l.PropertyTypeId == 2)
                        select new LandLeaseModel
                        {
                            PlotNo = l.PlotNo,
                            LandAcerage = l.LandAcerage,
                            StreetNameId = (int)l.StreetNameId,
                            DemkhongId = (int)l.DemkhongId,
                            LapId = (int)l.LapId,
                            PlotAddress = l.PlotAddress,
                            LeaseTypeId = x.LeaseTypeId,
                            LeaseActivityTypeId = x.LeaseActivityTypeId,
                            StartDate = lp.StartDate,
                            EndDate = lp.EndDate,
                            BillingScheduleId = x.BillingScheduleId,
                            LeaseApprovalNo = x.LeaseApprovalNo,
                            LeaseAmount = x.LeaseAmount,
                            ShedAmount = x.ShedAmount,
                            HasShed = x.HasShed,
                            LandDetailId = x.LandDetailId,
                            LandLeaseId = x.LandLeaseId,
                            LandLeasePeriodId = lp.LandLeasePeriodId
                        });
            return data.ToList();
        }

        public int UpdateLandLease(LandLeaseModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLandDetail.FirstOrDefault(u => u.LandDetailId == obj.LandDetailId);
                    Data.PlotNo = obj.PlotNo; Data.LandAcerage = obj.LandAcerage; Data.StreetNameId = obj.StreetNameId;
                    Data.DemkhongId = obj.DemkhongId; Data.LapId = obj.LapId; Data.PlotAddress = obj.PlotAddress;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();

                    var Data1 = ctx.TblLandLease.FirstOrDefault(u => u.LandLeaseId == obj.LandLeaseId);
                    Data1.LeaseTypeId = obj.LeaseTypeId; Data1.LeaseActivityTypeId = obj.LeaseActivityTypeId;
                    Data1.BillingScheduleId = obj.BillingScheduleId; Data1.StartDate = obj.StartDate;
                    Data1.LeaseApprovalNo = obj.LeaseApprovalNo; Data1.LeaseAmount = obj.LeaseAmount;
                    Data1.ShedAmount = obj.ShedAmount; Data1.HasShed = obj.HasShed;
                    Data1.ModifiedOn = obj.ModifiedOn; Data1.ModifiedBy = obj.ModifiedBy;
                    ctx.SaveChanges();

                    var Data2 = ctx.TblLandLeasePeriod.FirstOrDefault(u => u.LandLeasePeriodId == obj.LandLeasePeriodId);
                    Data2.StartDate = obj.StartDate; Data2.EndDate = obj.EndDate;
                    Data2.ModifiedBy = obj.ModifiedBy; Data2.ModifiedOn = obj.ModifiedOn;
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

    }
}
