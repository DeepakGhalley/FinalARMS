﻿using CORE_BOL;
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
    public class HouseDetailBLL : IHouseDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public IList<HouseAllocationVM> GetAll()
        {
            var data = (from x in ctx.TblHouseDetail
                        join d in ctx.TblHouseAllocation on x.HouseDetailId equals d.HouseDetailId
                             into d_temp
                        from d_value in d_temp.DefaultIfEmpty()
                        join ttin in ctx.MstTaxPayerProfile on d_value.TaxPayerId equals ttin.TaxPayerId
                        into ttin_temp
                        from ttin_value in ttin_temp.DefaultIfEmpty()
                        let c = ctx.TblHouseAllocation.Where(y => y.HouseDetailId == x.HouseDetailId).Max(x => x.HouseAllocationId)
                        let t = ctx.TblHouseAllocation.Where(d => d.HouseDetailId == x.HouseDetailId).Any(x => x.IsTerminated)
                        select new HouseAllocationVM
                        {
                            HouseDetailId = x.HouseDetailId,
                            HouseAllocationId = c,
                            HouseNo = x.HouseNo,
                            HouseAddress = x.HouseAddress,
                            Remarks = x.Remarks,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                            IsTerminated = t,
                            ttin = ttin_value.Ttin,
                            TaxPayerId = ttin_value.TaxPayerId
                        });
            return data.ToList();

        }
        public async Task<HouseAllocationVM> Details(int? id)

        {
            var data = (from a in ctx.TblHouseAllocation.Where(aa => aa.HouseAllocationId == id)

                        select new HouseAllocationVM
                        {
                            HouseAllocationId = a.HouseAllocationId,
                            IsTerminated = a.IsTerminated

                        });

            return await data.FirstOrDefaultAsync();

        }

        public async Task<HouseRentDetailVM> GetDetails(int? id)

        {
            var data = (from a in ctx.TblHouseDetail.Where(aa => aa.HouseDetailId == id)
                      

                        select new HouseRentDetailVM
                        {
                            HouseDetailId = a.HouseDetailId,
                            HouseNo = a.HouseNo,
                            HouseAddress = a.HouseAddress,
                            
                            Remarks = a.Remarks,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,


                        });

            return await data.FirstOrDefaultAsync();

        }

        public int Save(HouseRentDetailVM obj)

        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblHouseDetail
                {
                  
                    HouseNo = obj.HouseNo,
                    HouseAddress = obj.HouseAddress,
                    Remarks = obj.Remarks,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblHouseDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.HouseDetailId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(HouseRentDetailVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblHouseDetail.FirstOrDefault(u => u.HouseDetailId == obj.HouseDetailId);
                   Data.HouseNo = obj.HouseNo; Data.HouseAddress = obj.HouseAddress;
                    Data.Remarks = obj.Remarks; Data.IsActive = obj.IsActive;
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
        public bool CheckExists(int id)
        {
            return ctx.TblHouseDetail.Any(e => e.HouseDetailId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var TblHouseDetail = ctx.TblHouseDetail.Find(id);
                ctx.TblHouseDetail.Remove(TblHouseDetail);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var TblStallDetail = await ctx.TblHouseDetail
                           .FirstOrDefaultAsync(m => m.HouseDetailId == id);
        }
        public bool DuplicateCheckOnSave(string HouseNo)
        {
            return ctx.TblHouseDetail.Any(e => e.HouseNo == HouseNo);
        }
        public bool DuplicateCheckOnUpdate(string HouseNo, int HouseDetailId)
        {
            return ctx.TblHouseDetail.Any(e => e.HouseNo == HouseNo && e.HouseDetailId == HouseDetailId);
        }

        public List<HouseRentDetailVM> fetchHouse(string HouseNo, string HouseAddress)
        {
            var data = (from a in ctx.TblHouseDetail.Where(x => x.HouseNo == HouseNo || x.HouseAddress == HouseAddress)
                            
                        select new HouseRentDetailVM
                        {
                            
                            HouseNo = a.HouseNo,
                            HouseAddress = a.HouseAddress,
                          

                        });
            return data.ToList();
        }

        public int SaveHouseAllocation(HouseAllocationVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int HouseAllocationId;
                var entity = new TblHouseAllocation
                {
                    HouseDetailId = obj.HouseDetailId,
                    TaxPayerId = obj.TaxPayerId,
                    BillingScheduleId = obj.BillingScheduleId,
                    AllocationDate = (DateTime)obj.AllocationDate,
                    RentalAmount = obj.RentalAmount,
                    HasSecurityDeposit = obj.HasSecurityDeposit,
                    SecurityAmount = obj.SecurityAmount,
                    Remarks = obj.Remarks,
                    TerminatedBy = obj.TerminatedBy,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblHouseAllocation.Add(entity);
                ctx.SaveChanges();

                HouseAllocationId = entity.HouseAllocationId;
                int ipk;

                var houseperiod = new TblHouseRentPeriod
                {
                    HouseAllocationId = HouseAllocationId,
                    StartDate = obj.SStartDate,
                    EndDate = obj.EEndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                };
                ctx.TblHouseRentPeriod.Add(houseperiod);
                ctx.SaveChanges();
                ipk = houseperiod.HouseRentPeriodId;
                s.Complete();
                s.Dispose();

                return HouseAllocationId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<HouseRentDetailVM> GetHouseDetails(int? id)
        {
            var data = (from x in ctx.TblHouseDetail.Where(x => x.HouseDetailId == id)
                        join y in ctx.TblHouseAllocation on x.HouseDetailId equals y.HouseDetailId
                        join z in ctx.TblHouseRentPeriod on y.HouseAllocationId equals z.HouseAllocationId
                        join t in ctx.MstTaxPayerProfile on y.TaxPayerId equals t.TaxPayerId
                        join tt in ctx.EnumTitle on t.TitleId equals tt.TitleId
                        select new HouseRentDetailVM
                        {
                            HouseNo = x.HouseNo,
                            HouseAddress = x.HouseAddress,
                            HouseDetailId = x.HouseDetailId,
                            EndDate = z.EndDate,
                            StartDate = z.StartDate,
                            Ttin = t.Ttin,
                            Cid = t.Cid,
                            Name = tt.Title + "" + t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            
                        });
            return data.ToList();
        }

        public List<TaxPayerProfileModel> GetTaxPayer(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x =>x.TaxPayerTypeId == 3 && (x.Cid == cid || x.Ttin == ttin) /*(string.IsNullOrEmpty(cid) || x.Cid == cid) && (string.IsNullOrEmpty(ttin) || x.Ttin == ttin)*/)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId

                        select new TaxPayerProfileModel
                        {
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            CAddress = a.CAddress,
                            PhoneNo = a.MobileNo,
                            FullName = b.Title + "" + a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            TaxPayerId = a.TaxPayerId
                        });
            return data.ToList();
        }
        public List<HouseAllocationVM> GetHouseAllocationDetail(int? id)
        {
            var data = (from x in ctx.TblHouseAllocation.Where(x => x.TaxPayerId == id)
                        join a in ctx.MstTaxPayerProfile on x.TaxPayerId equals a.TaxPayerId
                        join b in ctx.EnumBillingSchedule on x.BillingScheduleId equals b.BillingScheduleId
                        join c in ctx.TblHouseDetail on x.HouseDetailId equals c.HouseDetailId
                        //join d in ctx.MstRate on x.RateId equals d.RateId
                        select new HouseAllocationVM
                        {
                            HouseAllocationId = x.HouseAllocationId,
                            HouseDetailId = x.HouseDetailId,
                            TaxPayerId = x.TaxPayerId,
                            BillingScheduleId = x.BillingScheduleId,
                            BillingSchedule = b.BillingSchedule,
                            AllocationDate = x.AllocationDate,
                            //RateId = 1,
                            RentalAmount = x.RentalAmount,
                            HasSecurityDeposit = x.HasSecurityDeposit,
                            SecurityAmount = x.SecurityAmount,
                            Remarks = x.Remarks,
                            TerminateDate = x.TerminateDate,
                            TerminateReason = x.TerminateReason,
                            //IsTerminated = x.IsTerminated,
                            //TerminatedBy = (int)x.TerminatedBy,
                            CreatedBy = (int)x.CreatedBy,
                            CreatedOn = (DateTime)x.CreatedOn,
                            ModifiedBy = (int)x.ModifiedBy,
                            ModifiedOn = (DateTime)x.ModifiedOn,

                        });
            return data.ToList();
        }

        public List<HousePeriodVM> GetRenewDetails(int? id)
        {
            var data = (from x in ctx.TblHouseRentPeriod
                       
                        select new HousePeriodVM
                        {
                            HouseRentPeriodId = x.HouseRentPeriodId,
                            HouseAllocationId = x.HouseAllocationId,
                            Remarks = x.Remarks,
                            CreatedBy = (int)x.CreatedBy,
                            CreatedOn = (DateTime)x.CreatedOn,
                            ModifiedBy = (int)x.ModifiedBy,
                            ModifiedOn = (DateTime)x.ModifiedOn,

                        });
            return data.ToList();
        }

        public int Terminate(HouseAllocationVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblHouseAllocation.FirstOrDefault(u => u.HouseAllocationId == obj.HouseAllocationId);

                    Data.TerminateDate = obj.TerminateDate;
                    Data.IsTerminated = true;
                    Data.TerminateReason = obj.TerminateReason;
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

        //Demand Generation





        //Qrcode
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

        public long GenerateDemand(int HouseAllocationId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int totalDays)
        {

            try
            {
                decimal AmountForDays = Convert.ToDecimal((Amount / totalDays) * pDays);
                
                long transactionId;
                using TransactionScope s = new TransactionScope();
                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = 15,
                    WorkLevelId = 1,
                    TransactionValue = Amount,
                    TaxPayerId = taxPayerId,
                   //InstallmentDate= Convert.ToDateTime(pYear + "-" + pMonth + "-01"),
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

                var entityHd = new TblHouseRentDemandDetail
                {
                    HouseAllocationId = HouseAllocationId,
                    DemandNoId = dnid,
                    DemandDays = pDays,
                    DemandGenerateScheduleId = pMonth,
                    DemandYear = pYear,
                    InstallmentAmount = AmountForDays,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    InstallmentDate=Convert.ToDateTime(pYear+"-"+pMonth+"-10")

                };
                ctx.TblHouseRentDemandDetail.Add(entityHd);
                ctx.SaveChanges();
                long hrddid = 0;
                hrddid = entityHd.HouseRentDemandDetailId;
                ////FOR Subdivision fee
                ////long ipk;

                var entity = new TblDemand
                {

                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = 19,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = AmountForDays,
                    TotalAmount = AmountForDays,
                    HouseRentDemandDetailId = hrddid,
                    TaxPayerId = taxPayerId,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = Convert.ToDateTime((pYear.ToString() + "-" + pMonth.ToString() +"-" + totalDays))
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



        public List<TaxPayerProfileModel> fetchHouseRentDemandByCid(string cid, string ttin)
        {

            var data = (from x in ctx.MstTaxPayerProfile.Where(x =>( x.Cid == cid || x.Ttin == ttin) )
                       
                        select new TaxPayerProfileModel
                        { 
                            TaxPayerId = x.TaxPayerId,
                            Ttin = x.Ttin,
                            Cid = x.Cid,
                            Name = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            MobileNo = x.MobileNo,



                        });
            return data.ToList();
        }

        public List<HouseAllocationVM> fetchHouseRentDetails(int id)
        {

            var data = from x in ctx.TblHouseAllocation.Where(x => x.TaxPayerId == id)
                       join h in ctx.TblHouseDetail on x.HouseDetailId equals h.HouseDetailId
                       join z in ctx.EnumBillingSchedule on x.BillingScheduleId equals z.BillingScheduleId
                       join a in ctx.TblHouseRentPeriod on x.HouseAllocationId equals a.HouseAllocationId
                       orderby a.StartDate descending

                       select new HouseAllocationVM
                       {
                           HouseAllocationId = x.HouseAllocationId,
                           HouseNo = h.HouseNo,
                           HouseAddress = h.HouseAddress,
                           BillingScheduleName = z.BillingSchedule,
                           BillingScheduleId = z.BillingScheduleId,
                           StartDate = a.StartDate.ToString("yyyyMMdd"),
                           EndDate = a.EndDate.ToString("yyyyMMdd"),
                          
                           RentalAmount = x.RentalAmount
                       };
            return data.ToList();
        }

        public List<HouseAllocationVM> generateHouseRentDemand(int DemandNoId)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                       join z in ctx.MstTaxPayerProfile on x.TaxPayerId equals z.TaxPayerId
                       join a in ctx.MstTaxMaster on x.TaxId equals a.TaxId
                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       join hp in ctx.TblHouseRentDemandDetail on x.DemandNoId equals hp.DemandNoId
                       join hd in ctx.TblHouseRentPeriod on hp.HouseAllocationId equals hd.HouseAllocationId
                       
                       let qr = GenerateQr(dn.ToString())

                       select new HouseAllocationVM
                       {
                           TaxPayerId = (int)x.TaxPayerId,
                           TaxPayerName = z.FirstName + " " + z.LastName,
                           ttin = z.Ttin,
                           cid = z.Cid,
                           Address = z.CAddress,
                           TotalAmount = x.TotalAmount,
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                           DemandDate = x.CreatedOn,
                           TaxName = a.TaxName,
                           DemandNo = y.DemandNo,
                           QrImage = qr,
                           SStartDate = hd.StartDate,
                           EEndDate = hd.EndDate

                       }; ;
            return data.ToList();
        }

        public List<HousePeriodVM> fetchHouseRentPeriod(int id)
        {

            var data = from x in ctx.TblHouseRentPeriod.Where(x => x.HouseRentPeriodId == id).Take(1)
                       orderby x.StartDate descending
                       select new HousePeriodVM
                       {
                           HouseAllocationId = x.HouseAllocationId,
                           StartDate = x.StartDate,
                           EndDate = x.EndDate,
                           Remarks = x.Remarks,
                       }; ;
            return data.ToList();
        }
        public IEnumerable<HouseRentDemandScheduleModule> GetHouseRentDemandScheduleMonthly(int Id, int year, string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.HouseRentDemandSchedule.FromSqlRaw($"GetHouseRentDemandScheduleMonthly {Id},{year},{StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public IEnumerable<DemandYearsModel> GetDemandYears(string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.DemandYearsModel.FromSqlRaw($"GetDemandYears {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        //House Renewal
        public List<HouseRentDetailVM> GetRenewalHouseRentDetail(int? id)
        {
            var data = (from x in ctx.TblHouseAllocation.Where(x => x.TaxPayerId == id)
                        join a in ctx.TblHouseDetail on x.HouseDetailId equals a.HouseDetailId
                        join b in ctx.EnumBillingSchedule on x.BillingScheduleId equals b.BillingScheduleId

                        select new HouseRentDetailVM
                        {
                            HouseNo = a.HouseNo,
                            HouseAddress = a.HouseAddress,
                            BillingScheduleName = b.BillingSchedule,
                            RentalAmount = x.RentalAmount,
                            SecurityAmount = x.SecurityAmount,
                            Adate = x.AllocationDate.ToString("dd-mm-yyyy"),
                            HouseAllocationId = x.HouseAllocationId

                        });
            return data.ToList();
        }

        public List<HouseAllocationVM> GetRenewalHouseRentAllocation(int? id)
        {
            var data = (from x in ctx.TblHouseRentPeriod.Where(x => x.HouseAllocationId == id).Take(1)//.OrderBy(x=>x.StallPeriodId)

                        join y in ctx.TblHouseAllocation on x.HouseAllocationId equals y.HouseAllocationId
                        join a in ctx.TblHouseDetail on y.HouseDetailId equals a.HouseDetailId
                        join b in ctx.EnumBillingSchedule on y.BillingScheduleId equals b.BillingScheduleId
                        orderby x.HouseRentPeriodId descending
                        select new HouseAllocationVM
                        {
                            BillingSchedule = b.BillingSchedule,
                            RentalAmount = y.RentalAmount,
                            SecurityAmount = y.SecurityAmount,
                            Adate = y.AllocationDate.ToString("dd-MM-yyyy"),
                            HouseNo = a.HouseNo,
                            EndDate = x.EndDate.ToString("dd-MM-yyyy"),
                            StartDate = x.StartDate.ToString("dd-MM-yyyy"),
                            HouseAllocationId = x.HouseAllocationId

                        });
            return data.ToList();
        }
        public int SaveRenew(HousePeriodVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblHouseRentPeriod
                {
                    HouseAllocationId = obj.HouseAllocationId,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    Remarks = obj.Remarks,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    ModifiedBy = obj.ModifiedBy,
                    ModifiedOn = Convert.ToDateTime(obj.ModifiedOn),
                };
                ctx.TblHouseRentPeriod.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.HouseRentPeriodId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}

        //public bool DuplicateCheckOnUpdate() { 
        //    return ctx.TblStallAllocation.Any(e => e.IsTerminated == true);
        //}

   