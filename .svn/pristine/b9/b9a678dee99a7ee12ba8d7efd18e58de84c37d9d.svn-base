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
    public class ParkingFeeBLL : IParkingFee
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.TblParkingfeeDetail.Any(e => e.ParkingFeeDetailId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ParkingFeeVM> Details(int? id)
        {
            var data = (from a in ctx.TblParkingfeeDetail.Where(aa => aa.ParkingFeeDetailId == id)
                        join y in ctx.MstParkingZone on a.ParkingZoneId equals y.ParkingZoneId
                        join z in ctx.MstTaxPayerProfile on a.TaxPayerId equals z.TaxPayerId
                        join x in ctx.EnumBillingSchedule on a.BillingScheduleId equals x.BillingScheduleId
                        select new ParkingFeeVM
                        {
                            ParkingFeeDetailId = a.ParkingFeeDetailId,
                            ParkingZoneId = a.ParkingZoneId,
                            ParkingZoneName = y.ParkingzoneName,
                            TaxPayerId = a.TaxPayerId,
                            TaxPayerName = z.Ttin,
                            BillingScheduleId = a.BillingScheduleId,
                            BillingScheduleName = x.BillingSchedule,
                            InstallmentAmount = a.InstallmentAmount,
                            Remarks = a.Remarks,
                            IsActive = a.IsActive,
                            TerminateDate = a.TerminateDate,
                            TerminateReason = a.TerminateReason,
                            TerminatedBy = a.TerminatedBy,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn
                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<ParkingFeeVM> GetAll()
        {
            var data = (from x in ctx.TblParkingfeeDetail
                        join y in ctx.MstParkingZone on x.ParkingZoneId equals y.ParkingZoneId
                        join z in ctx.MstTaxPayerProfile on x.TaxPayerId equals z.TaxPayerId
                        join a in ctx.EnumBillingSchedule on x.BillingScheduleId equals a.BillingScheduleId
                        select new ParkingFeeVM
                        {
                            ParkingFeeDetailId = x.ParkingFeeDetailId,
                            ParkingZoneId = x.ParkingZoneId,
                            ParkingZoneName = y.ParkingzoneName,
                            TaxPayerId = x.TaxPayerId,
                            TaxPayerName = z.Ttin,
                            BillingScheduleId = x.BillingScheduleId,
                            BillingScheduleName = a.BillingSchedule,
                            InstallmentAmount = x.InstallmentAmount,
                            Remarks = x.Remarks,
                            IsActive = x.IsActive,
                            TerminateDate = x.TerminateDate,
                            TerminateReason = x.TerminateReason,
                            TerminatedBy = x.TerminatedBy,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        //public IList<ParkingFeePeriodVM> GetParkingFeeDemand()
        //{
        //    var data = (from x in ctx.TblParkingFeePeriod
        //                //join a in ctx.EnumBillingSchedule on x.BillingScheduleId equals a.BillingScheduleId
        //                select new ParkingFeePeriodVM
        //                {
        //                    ParkingFeePeriodId = x.ParkingFeePeriodId,
        //                    ParkingFeeDetailId = x.ParkingFeeDetailId,
        //                    StartDate = x.StartDate,
        //                    EndDate = x.EndDate,
        //                    Remarks = x.Remarks,
        //                    CreatedBy = x.CreatedBy,
        //                    CreatedOn = x.CreatedOn,
        //                    ModifiedBy = x.ModifiedBy,
        //                    ModifiedOn = x.ModifiedOn
        //                });
        //    return data.ToList();
        //}

        public List<TaxPayerProfileModel> fetchParkingFeeDemandByCid(string cid, string ttin)
        {

            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid  || x.Ttin == ttin )
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

        public List<ParkingFeeVM> fetchParkingFeeDetails(int id)
        {

            var data = from x in ctx.TblParkingfeeDetail.Where(x => x.TaxPayerId == id)
                       join y in ctx.MstParkingZone on x.ParkingZoneId equals y.ParkingZoneId
                       join z in ctx.EnumBillingSchedule on x.BillingScheduleId equals z.BillingScheduleId
                       join a in ctx.TblParkingFeePeriod on x.ParkingFeeDetailId equals a.ParkingFeeDetailId
                       orderby a.StartDate descending

                       select new ParkingFeeVM
                       {
                           ParkingFeeDetailId = x.ParkingFeeDetailId,
                           IsActive = x.IsActive,
                           ParkingZoneName = y.ParkingzoneName,
                           BillingScheduleName = z.BillingSchedule,
                           BillingScheduleId = z.BillingScheduleId,
                           StartDate = a.StartDate.ToString("yyyyMMdd"),
                           StartDateD = a.StartDate,
                           EndDateD = a.EndDate,
                           EndDate = a.EndDate.ToString("yyyyMMdd"),
                           InstallmentAmount = x.InstallmentAmount
                       }; ;
            return data.Take(1).ToList();
        }

        public List<ParkingFeeVM> generateParkingFeeDemand(int DemandNoId)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                       join z in ctx.MstTaxPayerProfile on x.TaxPayerId equals z.TaxPayerId
                       join a in ctx.MstTaxMaster on x.TaxId equals a.TaxId
                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       join hp in ctx.TblParkingFeeDemandDetail on x.DemandNoId equals hp.DemandNoId
                       join hd in ctx.TblParkingFeePeriod on hp.ParkingFeeDetailId equals hd.ParkingFeeDetailId

                       let qr = GenerateQr(dn.ToString())

                       select new ParkingFeeVM
                       {
                           TaxPayerId = (int)x.TaxPayerId,
                           TaxPayerName = z.FirstName + " " + ((z.MiddleName == null || z.MiddleName.Trim() == string.Empty) ? string.Empty : (z.MiddleName + " ")) + ((z.LastName == null || z.LastName.Trim() == string.Empty) ? string.Empty : (z.LastName + " ")),
                           ttin = z.Ttin,
                           cid = z.Cid,
                           Address = z.CAddress,
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                           TotalAmount = x.TotalAmount,
                           DemandDate = x.CreatedOn,
                           TaxName = a.TaxName,
                           QrImage = qr,
                           DemandNo = y.DemandNo,
                           SStartDate = hd.StartDate,
                           EEndDate = hd.EndDate
                       }; ;
            return data.ToList();
        }

        public List<ParkingFeePeriodVM> fetchParkingFeePeriod(int id)
        {

            var data = from x in ctx.TblParkingFeePeriod.Where(x => x.ParkingFeeDetailId == id).Take(1)
                       orderby x.StartDate descending
                       select new ParkingFeePeriodVM
                       {
                           ParkingFeeDetailId = x.ParkingFeeDetailId,
                           StartDate = x.StartDate,
                           EndDate = x.EndDate,
                           Remarks = x.Remarks,
                       }; ;
            return data.ToList();
        }

        public int Save(ParkingFeeVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                int ipkk;
                var entity = new TblParkingfeeDetail
                {
                    ParkingFeeDetailId = obj.ParkingFeeDetailId,
                    ParkingZoneId = obj.ParkingZoneId,
                    TaxPayerId = obj.TaxPayerId,
                    BillingScheduleId = 1,
                    InstallmentAmount = obj.InstallmentAmount,
                    Remarks = obj.Remarks,
                    IsActive = true,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                };
                ctx.TblParkingfeeDetail.Add(entity);
                ctx.SaveChanges();
                ipk = entity.ParkingFeeDetailId;

                var entityp = new TblParkingFeePeriod
                {
                    ParkingFeeDetailId = ipk,
                    StartDate = obj.StartDateD,
                    EndDate = obj.EndDateD,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                };
                ctx.TblParkingFeePeriod.Add(entityp);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

                return ipk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ParkingFeeVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblParkingfeeDetail.FirstOrDefault(u => u.ParkingFeeDetailId == obj.ParkingFeeDetailId);
                    Data.ParkingFeeDetailId = obj.ParkingFeeDetailId;
                    Data.ParkingZoneId = obj.ParkingZoneId;
                    Data.TaxPayerId = obj.TaxPayerId;
                    Data.BillingScheduleId = obj.BillingScheduleId;
                    Data.InstallmentAmount = obj.InstallmentAmount;
                    Data.Remarks = obj.Remarks;
                    Data.IsActive = obj.IsActive;
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

        public int Terminate(ParkingFeeVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblParkingfeeDetail.FirstOrDefault(u => u.ParkingFeeDetailId == obj.ParkingFeeDetailId);
                    Data.IsActive = false;
                    Data.TerminateDate = obj.TerminateDate;
                    Data.TerminateReason = obj.TerminateReason;
                    Data.TerminatedBy = obj.TerminatedBy;
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

        public int Extension(ParkingFeePeriodVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblParkingFeePeriod
                {
                    ParkingFeeDetailId = obj.ParkingFeeDetailId,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    Remarks = obj.Remarks,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblParkingFeePeriod.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ParkingFeePeriodId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<TaxPayerProfileModel> fetchdataByCid(string Cid, string Name)
        {

            var data = (from x in ctx.MstTaxPayerProfile.Where(x => (string.IsNullOrEmpty(Cid) || x.Cid == Cid) && (string.IsNullOrEmpty(Name) || x.Cid == Name))
                        select new TaxPayerProfileModel
                        {
                            Cid = x.Cid,
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            Ttin = x.Ttin,
                            PhoneNo = x.PhoneNo,
                        });
            return data.ToList();
        }
        public IEnumerable<VendorDemandScheduleModel> GetVendorDemandSchedule(int Id,int yr, string StartDate, string EndDate)
        {
            try
            {
                var result = ctx.VendorDemandSchedule.FromSqlRaw($"GetVendorDemandSchedule {Id},{yr},{StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public IEnumerable<DemandYearsModel> GetDemandYears (string StartDate, string EndDate)
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

        public long GenerateDemand(int ParkingFeeDetailId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int totalDays)
        {

            try
            {
                decimal AmountForDays = Convert.ToDecimal((Amount / totalDays) * pDays);


                long transactionId;
                using TransactionScope s = new TransactionScope();
                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = 18,
                    WorkLevelId = 1,
                    TransactionValue = Amount,
                    TaxPayerId = taxPayerId,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblTransactionDetail.Add(entityTRn);
                ctx.SaveChanges();
                transactionId = entityTRn.TransactionId;
                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                sq = sq == null ? 0 : ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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

                var entitypd = new TblParkingFeeDemandDetail
                {
                    ParkingFeeDetailId = ParkingFeeDetailId,
                    DemandNoId = dnid,
                    DemandDays = pDays,
                    DemandGenerateScheduleId = pMonth,
                    DemandYear = pYear,
                    InstallmentAmount = AmountForDays,
                    InstallmentDate = Convert.ToDateTime(pYear+"-"+pMonth+"-10"),
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,

                };
                ctx.TblParkingFeeDemandDetail.Add(entitypd);
                ctx.SaveChanges();
                long pfddid = 0;
                pfddid = entitypd.ParkingDemandDetailId;
                //FOR Subdivision fee
                long ipk;
                var entity = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = 45,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = AmountForDays,
                    TotalAmount = AmountForDays,
                    ParkingDemandDetailId = pfddid,
                    TaxPayerId = taxPayerId,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = Convert.ToDateTime((pYear.ToString() + "-" + pMonth.ToString() + "-" + totalDays))
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

        public bool DuplicateCheckOnUpdate()
        {
            return ctx.TblParkingfeeDetail.Any(e => e.IsActive == false);
        }
    }
}
