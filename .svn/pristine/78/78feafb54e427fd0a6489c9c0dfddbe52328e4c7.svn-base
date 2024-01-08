using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
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
    public class ECRenewalDetailBLL : IECRenewalDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.TblEcrenewalDetail.Any(e => e.EcRenewalId == id); ;
        }

        public async Task Delete(int? id)
        {
            var TblECRenewalDetail = await ctx.TblEcrenewalDetail
            .FirstOrDefaultAsync(m => m.EcRenewalId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var TblECRenewalDetail = ctx.TblEcrenewalDetail.Find(id);
                ctx.TblEcrenewalDetail.Remove(TblECRenewalDetail);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<ECRenewalDetailModel> Details(int? id)
        {
            var data = (from a in ctx.TblEcrenewalDetail.Where(aa => aa.EcRenewalId == id)
                        select new ECRenewalDetailModel
                        {
                            EcDetailId = a.EcDetailId,
                            EcRenewalId = a.EcRenewalId,
                            CalendarYear = a.CalendarYear,
                            EcUseTypeId = a.EcUseTypeId,
                            ValidUpTo = a.ValidUpTo,
                            Amount = a.Amount,
                            EcSl = a.EcSl,
                            Remarks = a.Remarks,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public List<ECDetailModel> fetchECRenewalByCid(string cid, string applicantname)
        {
            var data = (from a in ctx.MstEcapplicantdetail.Where(x => x.Cid == cid || x.LicenceNo == cid || x.ApplicantName.StartsWith(applicantname))

                        select new ECDetailModel
                        {
                            Cid = a.Cid,
                            LicenceNo = a.LicenceNo,
                            ApplicantName = a.ApplicantName,
                            Address = a.Address,
                            PostBoxNo = a.PostBoxNo,
                            ContactNo = a.ContactNo,
                            FaxNo = a.FaxNo,
                            ApplicantId = a.ApplicantId
                        });
            return data.ToList();
        }


        public IList<ECRenewalDetailModel> GetAll()
        {
            var data = (from x in ctx.TblEcdetail
                        join y in ctx.MstEcapplicantdetail on x.ApplicantId equals y.ApplicantId
                        join z in ctx.MstEcactivityType on x.EcActivityTypeId equals z.EcActivityTypeId
                        join a in ctx.EnumIndustryType on x.IndustryTypeId equals a.IndustryTypeId
                        select new ECRenewalDetailModel
                        {
                            ApplicantId = x.ApplicantId,
                            EcDetailId = x.EcDetailId,
                            ApplicantName = y.ApplicantName,
                            Cid = y.Cid,
                            IndustryTypeName = a.IndustryTypeName,
                            ActivityType = z.ActivityType,
                            StartDate =x.StartDate,
                            EndDate = x.EndDate
                        });
            return data.ToList();
        }

        public List<ECDetailModel> GetECDetails(int ApplicantId)
        {
            var data = (from a in ctx.TblEcdetail.Where(x => x.ApplicantId == ApplicantId)
                        join at in ctx.MstEcactivityType on a.EcActivityTypeId equals at.EcActivityTypeId
                        join it in ctx.EnumIndustryType on a.IndustryTypeId equals it.IndustryTypeId
                        join ps in ctx.EnumProjectStatus on a.ProjectStatusId equals ps.ProjectStatusId into d
                        from dd in d.DefaultIfEmpty()
                        join aps in ctx.EnumApprovalStatus on a.ApprovalStatusId equals aps.ApprovalStatusId into ds
                        from dss in ds.DefaultIfEmpty()

                        select new ECDetailModel
                        {
                            EcDetailId = a.EcDetailId,
                            EcActivityTypeId = a.EcActivityTypeId,
                            ActivityType = at.ActivityType,
                            IndustryTypeId = a.IndustryTypeId,
                            IndustryTypeName = it.IndustryTypeName,
                            ProjectName = a.ProjectName,
                            StartDate = a.StartDate,
                            EndDate = a.EndDate,
                            ProjectStatusId = (int)a.ProjectStatusId,
                            ProjectStatusName = (dd.ProjectStatus == null ? "-" : dd.ProjectStatus),
                            ApprovalStatusId = (int)a.ApprovalStatusId,
                            ApprovalStatusName = (dss.ApprovalStatus == null ? "-" : dss.ApprovalStatus),
                            Quantity = a.Quantity
                        });
            return data.ToList();
        }

        public List<ECRenewalDetailModel> GetECRenewalDetails(int ECDetailId)
        {
            var data = (from a in ctx.TblEcrenewalDetail.Where(x => x.EcDetailId == ECDetailId)
                        join b in ctx.EnumEcuseType on a.EcUseTypeId equals b.EcUseTypeId
                        join e in ctx.TblEcdetail on a.EcDetailId equals e.EcDetailId
                        //join d in ctx.TblDemand on a.EcRenewalId equals d.EcRenewalId
                        //join dn in ctx.TblDemandNo on d.DemandNoId equals dn.DemandNoId

                        select new ECRenewalDetailModel
                        {
                           ECdUSeTypeName = b.EcUseType,
                           ValidUpTo = a.ValidUpTo,
                           Amount = a.Amount,
                           EcRefNo = a.EcRefNo,
                           CalendarYear = a.CalendarYear,
                           Remarks = (a.Remarks == null ? "-" : a.Remarks),
                           EcRenewalId = a.EcRenewalId,
                           EndDate = e.EndDate,
                           //DemandNoId = (int)dn.DemandNoId
                        });
            return data.ToList();
        }

        public int SaveECRenewal(ECRenewalDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {

                    var Data = ctx.TblEcrenewalDetail.FirstOrDefault(u => u.EcRenewalId == obj.EcRenewalId);
                    Data.ValidUpTo = obj.ValidUpTo;
                    Data.Remarks = obj.Remarks;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = obj.ModifiedOn;
                    Data.EcUseTypeId = 2;
                    ctx.SaveChanges();

                    var Data1 = ctx.TblEcdetail.FirstOrDefault(u => u.EcDetailId == obj.EcDetailId);
                    Data1.EndDate = obj.ValidUpTo;
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
        public long GenerateECDemand(ECDetailModel obj)
        {
            try
            {
                long transactionId;
                using TransactionScope s = new TransactionScope();
                int ipk; decimal TAmount;

                if (obj.EcActivityTypeId == 6)
                {
                    TAmount = ((obj.Quantity * 2)/100) * 20;
                }
                else
                {
                    if (obj.IndustryTypeId == 1)
                    {
                        TAmount = (500/100) * 20;
                    }
                    else if (obj.IndustryTypeId == 2)
                    {
                        TAmount = (2000/100) * 20;
                    }
                    else if (obj.IndustryTypeId == 3)
                    {
                        TAmount = (30000/100) * 20;
                    }
                    else
                    {
                        TAmount = (50000/100) * 20;
                    }
                }

                var entity = new TblTransactionDetail
                {
                    TransactionTypeId = 9,
                    WorkLevelId = 3,
                    TransactionValue = TAmount,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblTransactionDetail.Add(entity);
                ctx.SaveChanges();
                transactionId = entity.TransactionId;
                TAmount = (decimal)entity.TransactionValue;

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
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblDemandNo.Add(entityDN);
                ctx.SaveChanges();
                dnid = entityDN.DemandNoId;

                var entityD = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = 85, //STATIC ID
                    FinancialYearId = fyr,
                    CalendarYearId = cyr,
                    DemandAmount = TAmount,
                    TotalAmount = TAmount,
                    EcRenewalId = obj.EcRenewalId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate = DateTime.Now,
                    IsPaymentMade = false,
                    ApplicantId = obj.ApplicantId
                };
                ctx.TblDemand.Add(entityD);
                ctx.SaveChanges();

                var entityD1 = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = 36, 
                    FinancialYearId = fyr,
                    CalendarYearId = cyr,
                    DemandAmount = 100,
                    TotalAmount = 100,
                    EcRenewalId = obj.EcRenewalId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate = DateTime.Now,
                    IsPaymentMade = false,
                    ApplicantId = obj.ApplicantId
                };
                ctx.TblDemand.Add(entityD1);
                ctx.SaveChanges();
                var Data = ctx.TblEcrenewalDetail.FirstOrDefault(u => u.EcRenewalId == obj.EcRenewalId);
                Data.Amount = TAmount;
                ctx.SaveChanges();
                var Data1 = ctx.TblEcdetail.FirstOrDefault(u => u.EcDetailId == obj.EcDetailId);
                Data1.InitialAmount = TAmount;
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

                return dnid;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<ECDetailModel> GetECDemand(int DemandNoId)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId);/*.Max(x => x.DemandNo);*/

            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                       join ad in ctx.MstEcapplicantdetail on x.ApplicantId equals ad.ApplicantId
                       join a in ctx.MstTaxMaster on x.TaxId equals a.TaxId
                       join ecr in ctx.TblEcrenewalDetail on x.EcRenewalId equals ecr.EcRenewalId
                       join ec in ctx.TblEcdetail on ecr.EcDetailId equals ec.EcDetailId
                       join at in ctx.MstEcactivityType on ec.EcActivityTypeId equals at.EcActivityTypeId
                       let qr = GenerateQr(dn.ToString())
                       //join k in ctx.AspNetUsers on x.CreatedBy equals k.RoleId

                       select new ECDetailModel
                       {
                           ApplicantName = ad.ApplicantName,
                           EcRenewalId = ecr.EcRenewalId,
                           DemandDate = x.CreatedOn,
                           TaxName = a.TaxName,
                           QrImage = qr,
                           DemandNo = y.DemandNo,
                           StartDate = ec.StartDate,
                           EndDate = ec.EndDate,
                           Cid = ad.Cid,
                           LicenceNo = ad.LicenceNo,
                           Address = ad.Address,
                           TotalAmount = x.TotalAmount,
                           ActivityType = at.ActivityType

                       };
            return data.ToList();
        }

        public byte[] GenerateQr(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytesCode(qrCodeImage);
        }
        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public List<ECDetailModel> GetUserName(int DemandNoId)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       join a in ctx.AspNetUsers on x.CreatedBy equals a.RoleId

                       select new ECDetailModel
                       {
                           UserName = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),

                       };
            return data.ToList();
        }

    }
}
