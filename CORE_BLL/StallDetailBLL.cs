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
    public class StallDetailBLL : IStallDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public IList<StallAllocationVM> GetAll()
        {
            var data = (from x in ctx.TblStallDetail
                        join d in ctx.TblStallAllocation on x.StallDetailId equals d.StallDetailId
                            into d_temp
                        from d_value in d_temp.DefaultIfEmpty()
                        join ttin in ctx.MstTaxPayerProfile on d_value.TaxPayerId equals ttin.TaxPayerId
                        into ttin_temp
                        from ttin_value in ttin_temp.DefaultIfEmpty()
                        join a in ctx.MstStallLocation on x.StallLocationId equals a.StallLocationId
                        join s in ctx.MstStallType on x.StallTypeId equals s.StallTypeId
                        let c = ctx.TblStallAllocation.Where(y => y.StallDetailId == x.StallDetailId).Max(x => x.StallAllocationId)
                        let t = ctx.TblStallAllocation.Where(d => d.StallDetailId == x.StallDetailId).Any(x => x.IsTerminated)

            select new StallAllocationVM
                        {
                            StallDetailId = x.StallDetailId,
                            StallAllocationId = d_value.StallAllocationId,
                            StallLocation = a.StallLocation,
                            StallNo = x.StallNo,
                            StallName = x.StallName,
                            StallArea = x.StallArea,
                            Remarks = x.Remarks,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                            IsTerminated = d_value.IsTerminated,
                            StallTypeId = (int)x.StallTypeId,
                            StallType = s.StallType,
                            TTIN = ttin_value.Ttin,
                            TaxPayerId = ttin_value.TaxPayerId
                           

                        });
            return data.Distinct().ToList();

        }
        public async Task<StallAllocationVM> Details(int? id)

        {
            var data = (from a in ctx.TblStallAllocation.Where(aa => aa.StallAllocationId == id)
                       
                        select new StallAllocationVM
                        {
                            StallAllocationId = a.StallAllocationId,
                            IsTerminated = a.IsTerminated

                        });

            return await data.FirstOrDefaultAsync();

        }



        public async Task<StallDetailVM> GetDetails(int? id)

        {
            var data = (from a in ctx.TblStallDetail.Where(aa => aa.StallDetailId == id)
                        join z in ctx.MstStallLocation on a.StallLocationId equals z.StallLocationId
                        join s in ctx.MstStallType on a.StallTypeId equals s.StallTypeId
                        join p in ctx.TblStallPeriod on z.StallLocationId equals p.StallAllocationId
                        select new StallDetailVM
                        {
                            StallDetailId = a.StallDetailId,
                            StallLocationId = z.StallLocationId,
                            StallLocation = z.StallLocation,
                            StallNo = a.StallNo,
                            StallName = a.StallName,
                            StallArea = a.StallArea,
                            Remarks = a.Remarks,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            StallType = s.StallType,
                            StallTypeId = (int)a.StallTypeId,
                            SDate = p.StartDate,
                            EDate = p.EndDate,
                            StallAllocationId = p.StallAllocationId
                            

                        });

            return await data.FirstOrDefaultAsync();

        }


        public async Task<StallDetailVM> GetPDetails(int? id)

        {
            var data = (from a in ctx.TblStallPeriod.Where(aa => aa.StallAllocationId == id)
                            select new StallDetailVM
                        {
                            
                            SDate = a.StartDate,
                            EDate = a.EndDate,
                            StallAllocationId = a.StallAllocationId,
                            Remarks = a.Remarks


                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(StallDetailVM obj)

        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblStallDetail
                {
                    StallLocationId = obj.StallLocationId,
                    StallTypeId = obj.StallTypeId,
                    StallNo = obj.StallNo,
                    StallName = obj.StallName,
                    StallArea = obj.StallArea,
                    Remarks = obj.Remarks,
                    IsActive = true,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn =DateTime.Now,
                };
                ctx.TblStallDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.StallDetailId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(StallDetailVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblStallDetail.FirstOrDefault(u => u.StallDetailId == obj.StallDetailId);
                    Data.StallLocationId = obj.StallLocationId; Data.StallNo = obj.StallNo; Data.StallName = obj.StallName;
                    Data.StallArea = obj.StallArea; Data.Remarks = obj.Remarks; Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn; Data.StallTypeId = obj.StallTypeId;
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

        public int PUpdate(StallDetailVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblStallPeriod.FirstOrDefault(u => u.StallAllocationId == obj.StallAllocationId);
                    Data.StartDate = obj.SDate; Data.EndDate = obj.EDate; Data.Remarks = obj.Remarks;
                   
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
            return ctx.TblStallDetail.Any(e => e.StallDetailId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var TblStallDetail = ctx.TblStallDetail.Find(id);
                ctx.TblStallDetail.Remove(TblStallDetail);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var TblStallDetail = await ctx.TblStallDetail
                           .FirstOrDefaultAsync(m => m.StallDetailId == id);
        }
        public bool DuplicateCheckOnSave(string StallNo)
        {
            return ctx.TblStallDetail.Any(e => e.StallNo == StallNo);
        }
        public bool DuplicateCheckOnUpdate(int StallDetailId)
        {
            return ctx.TblStallDetail.Any(e =>  e.StallDetailId != StallDetailId);
        }

        public List<StallDetailVM> fetchSTALL(string stallno, string stallname)
        {
            var data = (from a in ctx.TblStallDetail.Where(x => x.StallNo == stallno || x.StallName == stallname)
                        //join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        join c in ctx.MstStallLocation on a.StallLocationId equals c.StallLocationId
                        select new StallDetailVM
                        {
                            StallLocationId = a.StallLocationId,
                            StallLocation = c.StallLocation,
                            StallNo = a.StallNo,
                            StallName = a.StallName,
                            StallArea = a.StallArea
                           
                        });
            return data.ToList();
        }    

        public int SaveStallAllocation(StallAllocationVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int StallAllocationId;
                var entity = new TblStallAllocation
                {
                    StallDetailId = obj.StallDetailId,
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
                ctx.TblStallAllocation.Add(entity);
                ctx.SaveChanges();

                StallAllocationId = entity.StallAllocationId;
                int ipk;

                var stallperiod = new TblStallPeriod
                {
                    StallAllocationId = StallAllocationId,
                    StartDate = obj.SDate,
                    EndDate = obj.EDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                };
                 ctx.TblStallPeriod.Add(stallperiod);
                ctx.SaveChanges();
                ipk = stallperiod.StallPeriodId;
                s.Complete();
                s.Dispose();

                return StallAllocationId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<StallDetailVM> GetStallDetails(int? id)
        {
            var data = (from x in ctx.TblStallDetail.Where(x=> x.StallDetailId == id)
                        join s in ctx.TblStallAllocation on x.StallDetailId equals s.StallDetailId
                        join p in ctx.TblStallPeriod on s.StallAllocationId equals p.StallAllocationId
                        let a = ctx.MstStallType.Where(y => y.StallTypeId == x.StallTypeId).Max(x => x.StallType)
                        join t in ctx.MstTaxPayerProfile on s.TaxPayerId equals t.TaxPayerId
                        where s.IsTerminated == false
                        select new StallDetailVM
                        {
                           StallName = x.StallName,
                           StallNo = x.StallNo,
                           StallDetailId = x.StallDetailId,
                           StallAllocationId = p.StallAllocationId,
                           SDate = p.StartDate,
                           EDate = p.EndDate,
                           TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                           TTIN = t.Ttin,
                           CID = t.Cid,
                           StallTypeId = (int)x.StallTypeId,
                           StallType = a,
                        });
            return data.ToList();
        }
       
        public List<TaxPayerProfileModel> GetTaxPayer(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => (string.IsNullOrEmpty(cid) || x.Cid == cid) && (string.IsNullOrEmpty(ttin) || x.Ttin == ttin)).Take(1)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        let s = ctx.TblStallAllocation.Where(m => m.TaxPayerId == a.TaxPayerId).Max(m => m.StallDetailId)
                        select new TaxPayerProfileModel
                        {
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            FullName = b.Title + "" + a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            TaxPayerId = a.TaxPayerId,
                            StallDetailId = s,
                            PhoneNo = a.PhoneNo
                            
                            
                        });
            return data.ToList();
        }
        public List<StallAllocationVM> GetStallAllocationDetail(int? id)
        {
            var data = (from x in ctx.TblStallAllocation.Where(x=> x.TaxPayerId == id)
                        join a in ctx.MstTaxPayerProfile on x.TaxPayerId equals a.TaxPayerId
                        join b in ctx.EnumBillingSchedule on x.BillingScheduleId equals b.BillingScheduleId
                        join c in ctx.TblStallDetail on x.StallDetailId equals c.StallDetailId
                        //join d in ctx.MstRate on x.RateId equals d.RateId
                        select new StallAllocationVM
                        {
                            StallAllocationId = x.StallAllocationId,
                            StallDetailId = x.StallDetailId,
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

        public List<StallPeriodVM> GetRenewDetails(int? id)
        {
            var data = (from x in ctx.TblStallPeriod
                        join a in ctx.TblStallAllocation on x.StallAllocationId equals a.StallAllocationId
                        select new StallPeriodVM
                        {
                            StallPeriodId = x.StallPeriodId,
                            StallAllocationId = x.StallAllocationId,
                            Remarks = x.Remarks,
                            CreatedBy = (int)x.CreatedBy,
                            CreatedOn = (DateTime)x.CreatedOn,
                            ModifiedBy = (int)x.ModifiedBy,
                            ModifiedOn = (DateTime)x.ModifiedOn,

                        });
            return data.ToList();
        }

        public int Terminate(StallAllocationVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblStallAllocation.FirstOrDefault(u => u.StallAllocationId == obj.StallAllocationId);
                             
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

        public List<TaxPayerProfileModel> GetTaxPayerProfile(string Cid, string Ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => (string.IsNullOrEmpty(Cid) || x.Cid == Cid) || (string.IsNullOrEmpty(Ttin) || x.Cid == Ttin))
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        join tt in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals tt.TaxPayerTypeId
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            TitleId = a.TitleId,
                            Title = b.Title,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            FullName = (b.Title + ". " + a.FirstName + " " + a.MiddleName + " " + a.LastName),
                            TaxPayerTypeId = a.TaxPayerTypeId,
                            TaxPayerType = tt.TaxPayerType,
                            MobileNo = a.MobileNo,
                            Email = a.Email,
                            CAddress = a.CAddress
                        });
            return data.ToList();
        }

        //Demand Generation
        public List<TaxPayerProfileModel> fetchStallRentDemandByCid(string cid, string ttin)
        {

            var data = (from x in ctx.MstTaxPayerProfile.Where(x => (x.Cid == cid || x.Ttin == ttin)) //&& x.TaxPayerTypeId == 3)
                        .Take(1)
                        join a in ctx.EnumTitle on x.TitleId equals a.TitleId
                        //join s in ctx.TblStallAllocation on x.TaxPayerId equals s.TaxPayerId
                        //join p in ctx.TblStallPeriod on s.StallAllocationId equals p.StallAllocationId
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = x.TaxPayerId,
                            Ttin = x.Ttin,
                            Cid = x.Cid,
                            Name = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            MobileNo = x.MobileNo,
                            Title = a.Title,
                            PhoneNo = x.PhoneNo,
                            CAddress = x.CAddress,
                            //StartDate = p.StartDate,
                            //EndDate = p.EndDate
                                                                                 
                        });
            return data.ToList();
        }

        public List<StallDetailVM> fetchStallRentDetails(int id)
        {

            var data = from x in ctx.TblStallAllocation.Where(x => x.TaxPayerId == id && x.IsTerminated == false)
                       join y in ctx.TblStallDetail on x.StallDetailId equals y.StallDetailId
                       join z in ctx.EnumBillingSchedule on x.BillingScheduleId equals z.BillingScheduleId
                       join a in ctx.TblStallPeriod on x.StallAllocationId equals a.StallAllocationId
                       join b in ctx.MstStallType on y.StallTypeId equals b.StallTypeId
                       
                       orderby a.StartDate descending

                       select new StallDetailVM
                       {
                           StallAllocationId = x.StallAllocationId,
                           TaxPayerId = x.TaxPayerId,
                           StallNo = y.StallNo, 
                           StallArea = y.StallArea,
                           BillingScheduleId = z.BillingScheduleId,
                           BillingScheduleName = z.BillingSchedule,
                           StartDate = a.StartDate.ToString("yyyyMMdd"),
                           EndDate = a.EndDate.ToString("yyyyMMdd"),
                           RentalAmount = x.RentalAmount,
                           StallType = b.StallType,
                           StallTypeId = (int)y.StallTypeId,
                           IsTerminated = x.IsTerminated,
                       }; 
            return data.ToList();
        }

        public IEnumerable<StallRentDemandScheduleModel> GetStallDemandScheduleMonthly(int Id, int yr, string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.StallRentDemandSchedule.FromSqlRaw($"GetStallDemandScheduleMonthly {Id}, {yr},{StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public byte[] GenerateQr(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytesCode(qrCodeImage);
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

        public long GenerateDemand(int StallAllocationId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int totalDays, int StallTypeId)
        {

            try
            {
                decimal AmountForDays = Convert.ToDecimal((Amount / totalDays) * pDays);


                long transactionId;
                using TransactionScope s = new TransactionScope();
                var staxid = 0;
                if (StallTypeId == 1)
                {
                    staxid = 18;
                }
                else if ( StallTypeId == 2)
                {
                    staxid = 16;
                }
                else if (StallTypeId == 3)
                {
                    staxid = 17;
                }
                else if (StallTypeId > 3)
                {
                    staxid = 113;
                }
                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = 17,
                    WorkLevelId = 3,
                    TransactionValue = Amount,
                    TaxPayerId = taxPayerId,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblTransactionDetail.Add(entityTRn);
                ctx.SaveChanges();
                transactionId = entityTRn.TransactionId;
                int sq = ctx.TblDemandNo.Where(p => p.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                //int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                //sq = sq == null ? 0 : ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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


                var entitypd = new TblStallDetailDemand
                {
                    StallAllocationId = StallAllocationId,
                    StallTypeId = StallTypeId,
                    DemandNoId = dnid,
                    DemandDays = pDays,
                    DemandGenerateScheduleId = pMonth,
                    DemandYear = pYear,
                    Amount = Amount,
                    InstallmentDate = Convert.ToDateTime(pYear + "-" + pMonth + "-10"),
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    


                };
                ctx.TblStallDetailDemand.Add(entitypd);
                ctx.SaveChanges();
                long pfddid = 0;
                pfddid = entitypd.StallDemandDetailId;
                //FOR Subdivision fee
                long ipk;
                var entity = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = staxid,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = Amount,
                    TotalAmount = AmountForDays,
                    StallDemandDetailId = pfddid,
                    TaxPayerId = taxPayerId,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
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

        public List<StallDetailVM> generateStallRentDemand(int DemandNoId)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                       join z in ctx.MstTaxPayerProfile on x.TaxPayerId equals z.TaxPayerId
                       join a in ctx.MstTaxMaster on x.TaxId equals a.TaxId
                       let qr = GenerateQr(dn.ToString())
                       //join s in ctx.TblStallAllocation on z.TaxPayerId equals s.TaxPayerId
                       //join c in ctx.TblStallPeriod on s.StallAllocationId equals c.StallAllocationId
                       //join i in ctx.TblStallDetail on s.StallDetailId equals i.StallDetailId
                       join hp in ctx.TblStallDetailDemand on x.DemandNoId equals hp.DemandNoId
                       join hd in ctx.TblStallPeriod on hp.StallAllocationId equals hd.StallAllocationId
                       //join k in ctx.AspNetUsers on x.CreatedBy equals k.RoleId

                       select new StallDetailVM
                       {
                           TaxPayerId = (int)x.TaxPayerId,
                           TaxPayerName = z.FirstName + " " + ((z.MiddleName == null || z.MiddleName.Trim() == string.Empty) ? string.Empty : (z.MiddleName + " ")) + ((z.LastName == null || z.LastName.Trim() == string.Empty) ? string.Empty : (z.LastName + " ")),
                           TTIN = z.Ttin,
                           CID = z.Cid,
                           Address = z.CAddress,
                           TotalAmount = x.TotalAmount,
                           DemandDate = x.CreatedOn,
                           TaxName = a.TaxName,
                           QrImage = qr,
                           DemandNo = y.DemandNo,
                           SDate = hd.StartDate,
                           EDate = hd.EndDate,
                           //StallType = b,
                           //StallTypeId = (int)i.StallTypeId,
                           //UserName = k.FirstName + " " + ((k.MiddleName == null || k.MiddleName.Trim() == string.Empty) ? string.Empty : (k.MiddleName + " ")) + ((k.LastName == null || k.LastName.Trim() == string.Empty) ? string.Empty : (k.LastName + " ")),

                       }; 
            return data.ToList();
        }

        public List<StallDetailVM> GetUserName(int DemandNoId)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       join a in ctx.AspNetUsers on x.CreatedBy equals a.RoleId

                       select new StallDetailVM
                       {
                           UserName = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                           
                       };
            return data.ToList();
        }

        //Stall Renewal Start

        public List<StallDetailVM> GetRenewalStallDetail(int? id)
        {
            var data = (from x in ctx.TblStallAllocation.Where(x => x.TaxPayerId == id)
                        join a in ctx.TblStallDetail on x.StallDetailId equals a.StallDetailId
                        join c in ctx.MstStallLocation on a.StallLocationId equals c.StallLocationId
                        join b in ctx.EnumBillingSchedule on x.BillingScheduleId equals b.BillingScheduleId
                        where x.IsTerminated == true && a.IsActive == true
                        select new StallDetailVM
                        {
                            StallName = a.StallName,
                            StallNo = a.StallNo,
                            StallArea = a.StallArea,
                            StallLocation = c.StallLocation,
                            BillingScheduleName = b.BillingSchedule,
                            RentalAmount = x.RentalAmount,
                            StallAllocationId = x.StallAllocationId
                            
                        });
            return data.ToList();
        }

        public List<StallAllocationVM> GetRenewalStallAllocation(int? id)
        {
            var data = (from x in ctx.TblStallPeriod.Where(x => x.StallAllocationId == id).Take(1)//.OrderBy(x=>x.StallPeriodId)

                        join y in ctx.TblStallAllocation on x.StallAllocationId equals y.StallAllocationId
                        join a in ctx.TblStallDetail on y.StallDetailId equals a.StallDetailId
                        join b in ctx.EnumBillingSchedule on y.BillingScheduleId equals b.BillingScheduleId
                        orderby x.StallPeriodId descending
                        select new StallAllocationVM
                        {
                            BillingSchedule = b.BillingSchedule,
                            RentalAmount = y.RentalAmount,
                            SecurityAmount = y.SecurityAmount,
                            AllocationDate = y.AllocationDate,
                            EndDate = x.EndDate.ToString("dd-MM-yyyy"),
                            StartDate = x.StartDate.ToString("dd-MM-yyyy"),
                            StallAllocationId = x.StallAllocationId

                        });
            return data.ToList();
        }
        public int SaveRenew(StallPeriodVM obj)
        {
            try
            {
               
                using TransactionScope s = new TransactionScope();
               

                var OldRent = ctx.TblStallAllocation.Where(w => w.StallAllocationId == obj.StallAllocationId);
                var Ramount = OldRent.FirstOrDefault().RentalAmount;
                var SID = OldRent.FirstOrDefault().StallDetailId;
                var tid = OldRent.FirstOrDefault().TaxPayerId;
                var bid = OldRent.FirstOrDefault().BillingScheduleId;
                var hs = OldRent.FirstOrDefault().HasSecurityDeposit;
                var sa = OldRent.FirstOrDefault().SecurityAmount;

                var RentUpdate = ctx.TblStallAllocation.Where(u => u.StallAllocationId == obj.StallAllocationId);
                RentUpdate.FirstOrDefault().IsTerminated = true;
                RentUpdate.FirstOrDefault().TerminatedBy = obj.CreatedBy;
                RentUpdate.FirstOrDefault().TerminateDate = Convert.ToDateTime(obj.CreatedOn);
                RentUpdate.FirstOrDefault().TerminateReason = "Stall Renewed";
                ctx.SaveChanges();

                int StallAllocationId;
                var entitys = new TblStallAllocation
                {
                    StallDetailId = SID,
                    TaxPayerId = tid,
                    BillingScheduleId = bid,
                    AllocationDate = Convert.ToDateTime(obj.CreatedOn),
                    RentalAmount = obj.RevisedRent,
                    HasSecurityDeposit = hs,
                    SecurityAmount = sa,
                    Remarks = obj.Remarks,
               
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblStallAllocation.Add(entitys);
                ctx.SaveChanges();

                StallAllocationId = entitys.StallAllocationId;


                int ipk;
                var entity = new TblStallPeriod
                {
                    StallAllocationId = StallAllocationId,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    Remarks = obj.Remarks,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    ModifiedBy = obj.ModifiedBy,
                    ModifiedOn = Convert.ToDateTime(obj.ModifiedOn),
                };
                ctx.TblStallPeriod.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.StallPeriodId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Yearly Demand
        public IEnumerable<StallRentDemandScheduleModel> GetStallDemandScheduleYearly(int Id, string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.StallRentDemandSchedule.FromSqlRaw($"GetStallDemandScheduleYearly {Id},{StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        //Quarterly Demand
        public IEnumerable<StallRentDemandScheduleModel> GetStallDemandScheduleQuarterly(int Id, string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.StallRentDemandSchedule.FromSqlRaw($"GetStallDemandScheduleQuarterly {Id},{StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public List<StallAllocationVM> GetStartDateEndDate(int? id)
        {
            var data = (from x in ctx.TblStallAllocation.Where(x => x.StallDetailId == id).Take(1)
                        join y in ctx.TblStallPeriod on x.StallAllocationId equals y.StallAllocationId

                        select new StallAllocationVM
                        {
                            EDate = y.EndDate,
                            SDate = y.StartDate

                        });
            return data.ToList();
        }
    }
}
