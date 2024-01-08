using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace CORE_BLL
{
    public class ECDetailBLL : IECDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<ECDetailModel> GetAll()
        {
            var data = (from x in ctx.TblEcdetail
                        join ad in ctx.MstEcapplicantdetail on x.ApplicantId equals ad.ApplicantId
                        join at in ctx.MstEcactivityType on x.EcActivityTypeId equals at.EcActivityTypeId
                        join it in ctx.EnumIndustryType on x.IndustryTypeId equals it.IndustryTypeId
                        join ps in ctx.EnumProjectStatus on x.ProjectStatusId equals ps.ProjectStatusId
                        join asi in ctx.EnumApprovalStatus on x.ApprovalStatusId equals asi.ApprovalStatusId

                        select new ECDetailModel
                        {
                            EcDetailId = x.EcDetailId,
                            ApplicantId = x.ApplicantId,
                            ApplicantName = ad.ApplicantName,
                            EcActivityTypeId = x.EcActivityTypeId,
                            ActivityType = at.ActivityType,
                            IndustryTypeId = x.IndustryTypeId,
                            IndustryTypeName = it.IndustryTypeName,
                            Quantity = x.Quantity,
                            ProjectName = x.ProjectName,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            ProjectStatusId = (int)x.ProjectStatusId,
                            ProjectStatusName = ps.ProjectStatus,
                            ProjectClosedBy = x.ProjectClosedBy,
                            ProjectCloseDate = x.ProjectCloseDate,
                            ProjectCloseRemarks = x.ProjectCloseRemarks,
                            ApprovalStatusId = (int)x.ApprovalStatusId,
                            ApprovalStatusName = asi.ApprovalStatus,
                            ApprovalRemarks = x.ApprovalRemarks,
                            ApprovalOn = x.ApprovalOn,
                            ApprovedBy = x.ApprovedBy,
                            InitialAmount = x.InitialAmount

                        });
            return data.Distinct().ToList();

        }
        public List<ECDetailModel> GetApplicantDetails(string CIDLicenceNo, string ApplicantName)
        {
            var data = (from a in ctx.MstEcapplicantdetail.Where(x => x.Cid == CIDLicenceNo || x.LicenceNo == CIDLicenceNo || x.ApplicantName.StartsWith(ApplicantName))

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

        public int SaveECDetail(ECDetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk; int ec; DateTime ed; decimal ia;
                var entity = new TblEcdetail
                {
                    ApplicantId = obj.ApplicantId,
                    ProjectName = obj.ProjectName,
                    IndustryTypeId = obj.IndustryTypeId,
                    EcActivityTypeId = obj.EcActivityTypeId,
                    Quantity = obj.Quantity,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblEcdetail.Add(entity);
                ctx.SaveChanges();
                ec = entity.EcDetailId;
                ed = entity.EndDate;
                //ia = entity.InitialAmount;
                int sq = ctx.TblEcrenewalDetail.Where(p => p.CalendarYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.EcSl).Cast<int?>().Max() ?? 0;
                sq = sq + 1;
                var entityR = new TblEcrenewalDetail
                {
                    EcDetailId = ec,
                    EcUseTypeId = 1,
                    ValidUpTo = ed,
                    //Amount = ia,
                    EcRefNo = ("TT/ENV/" + (DateTime.Now.Year) + "/" + sq),
                    EcSl = sq,
                    CalendarYear = DateTime.Now.Year,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblEcrenewalDetail.Add(entityR);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.EcDetailId;
                return ipk;
                ;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<ECDetailModel> GetECDetails(int ApplicantId)
        {
            var data = (from a in ctx.TblEcdetail.Where(x => x.ApplicantId == ApplicantId)
                        join ecr in ctx.TblEcrenewalDetail on a.EcDetailId equals ecr.EcDetailId
                        join dm in ctx.TblDemand on ecr.EcRenewalId equals dm.EcRenewalId into ddm
                        from dmm in ddm.DefaultIfEmpty()
                        join dn in ctx.TblDemandNo on dmm.DemandNoId equals dn.DemandNoId into ddn
                        from dnn in ddn.DefaultIfEmpty()
                        join ai in ctx.MstEcapplicantdetail on a.ApplicantId equals ai.ApplicantId
                        join at in ctx.MstEcactivityType on a.EcActivityTypeId equals at.EcActivityTypeId
                        join it in ctx.EnumIndustryType on a.IndustryTypeId equals it.IndustryTypeId
                        join ps in ctx.EnumProjectStatus on a.ProjectStatusId equals ps.ProjectStatusId into d
                        from dd in d.DefaultIfEmpty()
                        join aps in ctx.EnumApprovalStatus on a.ApprovalStatusId equals aps.ApprovalStatusId into ds
                        from dss in ds.DefaultIfEmpty()
                        join tx in ctx.MstTaxMaster on dmm.TaxId equals tx.TaxId into txx
                        from txxx in txx.DefaultIfEmpty()
                        join tv in ctx.TblTransactionDetail on dmm.TransactionId equals tv.TransactionId into tvv
                        from tvvv in tvv.DefaultIfEmpty()
                        where ecr.EcUseTypeId == 1 && txxx.TaxId != 36
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
                            DemandId = (int)dmm.DemandId,
                            EcRenewalId = ecr.EcRenewalId,
                            DemandNoId = (int)dnn.DemandNoId,
                            ApplicantId = ai.ApplicantId,
                            Quantity = a.Quantity,
                            TotalAmount = (decimal)tvvv.TransactionValue
                            
                           
                            
                        }).Distinct();
            return data.ToList();
        }

        public int SaveApprovalStatus(ECDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {

                    var Data = ctx.TblEcdetail.FirstOrDefault(u => u.EcDetailId == obj.EcDetailId);
                    Data.ApprovalStatusId = obj.ApprovalStatusId;
                    Data.ApprovalRemarks = obj.ApprovalRemarks;
                    Data.ApprovedBy = obj.ApprovedBy;
                    Data.ProjectStatusId = obj.ProjectStatusId;
                    Data.ApprovalOn = Convert.ToDateTime(obj.ApprovalOn);
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

        public List<ECDetailModel> GetECStatus(int ECDetailId)
        {
            var data = (from a in ctx.TblEcdetail.Where(x => x.EcDetailId == ECDetailId)
                        join aps in ctx.EnumApprovalStatus on a.ApprovalStatusId equals aps.ApprovalStatusId into ds
                        from dss in ds.DefaultIfEmpty()
                        join ps in ctx.EnumProjectStatus on a.ProjectStatusId equals ps.ProjectStatusId into pps
                        from pss in pps.DefaultIfEmpty()

                        select new ECDetailModel
                        {
                            EcDetailId = a.EcDetailId,
                            ApprovalStatusId = (int)a.ApprovalStatusId,
                            ProjectStatusId = (int)a.ProjectStatusId,
                            ApprovalStatusName = (dss.ApprovalStatus == null ? "-" : dss.ApprovalStatus),
                            ProjectStatusName = (pss.ProjectStatus == null ? "-" : pss.ProjectStatus),
                            ApprovalRemarks = a.ApprovalRemarks,
                            ProjectCloseRemarks = a.ProjectCloseRemarks,
                            ProjectCloseDate = a.ProjectCloseDate,
                            ProjectClosedBy = a.ProjectClosedBy,
                            ApprovalOn = a.ApprovalOn,
                            ApprovedBy = a.ApprovedBy
                        });
            return data.ToList();
        }

        public int SaveProjectStatus(ECDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {

                    var Data = ctx.TblEcdetail.FirstOrDefault(u => u.EcDetailId == obj.EcDetailId);
                    Data.ProjectStatusId = obj.ProjectStatusId;
                    Data.ProjectCloseRemarks = obj.ProjectCloseRemarks;
                    Data.ProjectClosedBy = obj.ProjectClosedBy;
                    Data.ProjectCloseDate = obj.ProjectCloseDate;
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

        public List<ECDetailModel> GetECDetailsForUpdate(int ECDetailId)
        {
            var data = (from a in ctx.TblEcdetail.Where(x => x.EcDetailId == ECDetailId)
                        join at in ctx.MstEcactivityType on a.EcActivityTypeId equals at.EcActivityTypeId
                        join it in ctx.EnumIndustryType on a.IndustryTypeId equals it.IndustryTypeId
                        join ps in ctx.EnumProjectStatus on a.ProjectStatusId equals ps.ProjectStatusId into d
                        from dd in d.DefaultIfEmpty()
                        join aps in ctx.EnumApprovalStatus on a.ApprovalStatusId equals aps.ApprovalStatusId into ds
                        from dss in ds.DefaultIfEmpty()
                        join e in ctx.TblEcrenewalDetail on a.EcDetailId equals e.EcDetailId

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
                            Quantity = a.Quantity,
                            ProjectStatusId = (int)a.ProjectStatusId,
                            ProjectStatusName = (dd.ProjectStatus == null ? "-" : dd.ProjectStatus),
                            ApprovalStatusId = (int)a.ApprovalStatusId,
                            ApprovalStatusName = (dss.ApprovalStatus == null ? "-" : dss.ApprovalStatus),
                            EcRenewalId = e.EcRenewalId
                        });
            return data.ToList();
        }

        public int UpdateECDetail(ECDetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {

                    var Data = ctx.TblEcdetail.FirstOrDefault(u => u.EcDetailId == obj.EcDetailId);
                    Data.ProjectName = obj.ProjectName;
                    Data.EcActivityTypeId = obj.EcActivityTypeId;
                    Data.IndustryTypeId = obj.IndustryTypeId;
                    Data.StartDate = obj.StartDate;
                    Data.EndDate = obj.EndDate;
                    Data.Quantity = obj.Quantity;
                    ctx.SaveChanges();

                    var Data1 = ctx.TblEcrenewalDetail.FirstOrDefault(u => u.EcRenewalId == obj.EcRenewalId);
                    Data1.ValidUpTo = obj.EndDate;
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

        public List<ECDetailModel> GetECDetailView(int ECDetailId)
        {
            var data = (from a in ctx.TblEcdetail.Where(x => x.EcDetailId == ECDetailId)
                        join aps in ctx.EnumApprovalStatus on a.ApprovalStatusId equals aps.ApprovalStatusId into ds
                        from dss in ds.DefaultIfEmpty()
                        join ps in ctx.EnumProjectStatus on a.ProjectStatusId equals ps.ProjectStatusId into pps
                        from pss in pps.DefaultIfEmpty()
                        join ad in ctx.MstEcapplicantdetail on a.ApplicantId equals ad.ApplicantId
                        join it in ctx.EnumIndustryType on a.IndustryTypeId equals it.IndustryTypeId
                        join at in ctx.MstEcactivityType on a.EcActivityTypeId equals at.EcActivityTypeId

                        select new ECDetailModel
                        {
                            EcDetailId = a.EcDetailId,
                            ApplicantName = ad.ApplicantName,
                            ProjectName = a.ProjectName,
                            ApprovalStatusName = (dss.ApprovalStatus == null ? "-" : dss.ApprovalStatus),
                            Address = (ad.Address == null ? "-" : ad.Address),
                            IndustryTypeId = a.IndustryTypeId,
                            IndustryTypeName = it.IndustryTypeName,
                            ApprovalOn = a.ApprovalOn,
                            Cid = ad.Cid,
                            LicenceNo = ad.LicenceNo,
                            EcActivityTypeId = a.EcActivityTypeId,
                            ActivityType = at.ActivityType,
                            ProjectStatusId = (int)a.ProjectStatusId,
                            ProjectStatusName = (pss.ProjectStatus == null ? "-" : pss.ProjectStatus),
                            ContactNo = ad.ContactNo,
                            Quantity = a.Quantity,
                            ProjectCloseDate = a.ProjectCloseDate,
                            FaxNo = (ad.FaxNo == null ? "-" : ad.FaxNo),
                            StartDate = a.StartDate,
                            ApprovalRemarks = (a.ApprovalRemarks == null ? "-" : a.ApprovalRemarks),
                            Remarks = (ad.Remarks == null ? "-" : ad.Remarks),
                            EndDate = a.EndDate,
                            ProjectCloseRemarks = (a.ProjectCloseRemarks == null ? "-" : a.ProjectCloseRemarks),
                            InitialAmount = a.InitialAmount
                        });
            return data.ToList();
        }

        public int GenerateECDemand(ECDetailModel obj)
        {
            try
            {
                long transactionId;
                using TransactionScope s = new TransactionScope();
                int ipk; decimal TAmount; int Tid;

                //RATE FOR ENVIRONMENT CLERANCE
                if (obj.EcActivityTypeId == 6)
                {
                    //ROADS
                    var Ref = ctx.MstSlab.Where(x => x.TaxId == 91).Max(x => x.EffectiveDate);
                    var Rslab = ctx.MstSlab.Single(x => x.TaxId == 91 && x.EffectiveDate == Ref);
                    var RRate = ctx.MstRate.Single(x => x.SlabId == Rslab.SlabId);

                    TAmount = obj.Quantity * RRate.Rate;
                    Tid = RRate.TaxId;
                }
                else
                {
                    //COTTAGE
                    var cef = ctx.MstSlab.Where(x => x.TaxId == 54).Max(x => x.EffectiveDate);
                    var cslab = ctx.MstSlab.Single(x => x.TaxId == 54 && x.EffectiveDate == cef);
                    var CRate = ctx.MstRate.Single(x => x.SlabId == cslab.SlabId);
                    //SMALL
                    var sef = ctx.MstSlab.Where(x => x.TaxId == 88).Max(x => x.EffectiveDate);
                    var sslab = ctx.MstSlab.Single(x => x.TaxId == 88 && x.EffectiveDate == sef);
                    var SRate = ctx.MstRate.Single(x => x.SlabId == sslab.SlabId);
                    //MEDIUM
                    var mef = ctx.MstSlab.Where(x => x.TaxId == 89).Max(x => x.EffectiveDate);
                    var mslab = ctx.MstSlab.Single(x => x.TaxId == 89 && x.EffectiveDate == mef);
                    var MRate = ctx.MstRate.Single(x => x.SlabId == mslab.SlabId);
                    //LARGE
                    var lef = ctx.MstSlab.Where(x => x.TaxId == 90).Max(x => x.EffectiveDate);
                    var lslab = ctx.MstSlab.Single(x => x.TaxId == 90 && x.EffectiveDate == lef);
                    var LRate = ctx.MstRate.Single(x => x.SlabId == mslab.SlabId);

                    if (obj.IndustryTypeId == 1)
                    {
                        TAmount = CRate.Rate;
                        Tid = CRate.TaxId;

                    }
                    else if (obj.IndustryTypeId == 2)
                    {
                        TAmount = SRate.Rate;
                        Tid = SRate.TaxId;

                    }
                    else if (obj.IndustryTypeId == 3)
                    {
                        TAmount = MRate.Rate;
                        Tid = MRate.TaxId;

                    }
                    else
                    {
                        TAmount = LRate.Rate;
                        Tid = LRate.TaxId;

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
                    //TAmount = (decimal)entity.TransactionValue;

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
                    TaxId = Tid,
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
                    DemandAmount = 500,
                    TotalAmount = 500,
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

                return (int)dnid;
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
                       join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                       let netamt = ctx.TblDemand.Where(l => l.DemandNoId == DemandNoId).Sum(t => t.TotalAmount)
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
                           DemandAmount = x.DemandAmount,
                           ActivityType = at.ActivityType,
                           TransactionValue = (decimal)t.TransactionValue,
                           TotalAmount = netamt
                           
                           
                          
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
        //[NonAction]
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
