using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using ARMS_BLL.Functions;
using QRCoder;
using System.Drawing;
using System.IO;

namespace CORE_BLL
{
    public class MiscellaneousRecordBLL : IMiscellaneousRecord
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<MiscellaneousRecordModel> GetAll()
        {
            var data = (from x in ctx.TblMiscellaneousRecord
                        join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join a in ctx.MstSlab on x.SlabId equals a.SlabId

                        select new MiscellaneousRecordModel
                        {
                            MiscellaneousRecordId = x.MiscellaneousRecordId,
                            TransactionId = x.TransactionId,
                            TaxId = x.TaxId,
                            SlabId = x.SlabId,
                            Name = x.Name,
                            Address = x.Address,
                            Cid = x.Cid,
                            MobileNo = x.MobileNo,
                            Quantity = x.Quantity,
                            Amount = x.Amount,
                            PaymentStatus = x.PaymentStatus,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                            //Transaction = y.Transaction,
                            Tax = z.TaxName,
                            Slab = a.SlabName



                        });
            return data.ToList();

        }
        public async Task<MiscellaneousRecordModel> Details(long? id)
        {
            //var data1 = (from x in ctx.TblEcdetail.Where(x => x.EcDetailId == id)
            //            join l in ctx.TblEcdetail on x.EcDetailId equals l.EcDetailId into ecdetail
            //            from l in ecdetail.DefaultIfEmpty()
            //            join y in ctx.MstEcapplicantdetail on x.ApplicantId equals y.ApplicantId
            //            join z in ctx.MstEcactivityType on x.EcActivityTypeId equals z.EcActivityTypeId
            //            join i in ctx.EnumIndustryType on x.IndustryTypeId equals i.IndustryTypeId
            //            join j in ctx.EnumApprovalStatus on x.ApprovalStatusId equals j.ApprovalStatusId into aps
            //            from j in aps.DefaultIfEmpty()
            //            join k in ctx.EnumProjectStatus on x.ProjectStatusId equals k.ProjectStatusId into prs
            //            from k in prs.DefaultIfEmpty()
            //            select new GetProjectDetailVM
            //            {
            //                EcDetailId = x.EcDetailId,
            //                ApplicantId = x.ApplicantId,
            //                ProjectName = x.ProjectName,
            //                StartDate = x.StartDate,
            //                EndDate = x.EndDate,
            //                //ProjectCloseDate = x.ProjectCloseDate,
            //                //ProjectClosedBy = (k.ProjectStatus == null ? "Under Review" : k.ProjectStatus),
            //                ProjectCloseRemarks = (l.ProjectCloseRemarks == null ? "Project is  still Under Review" : l.ProjectCloseRemarks),
            //                //ApprovalOn = x.ApprovalOn,
            //                //ApprovalRemarks = x.ApprovalRemarks,
            //                //ApprovedBy = x.ApprovedBy,
            //                Quantity = x.Quantity,
            //                ApplicantName = y.ApplicantName,
            //                ApprovalStatusName = (j.ApprovalStatus == null ? "Under Investigation" : j.ApprovalStatus),
            //                ActivityType = z.ActivityType,
            //                IndustryTypeName = i.IndustryTypeName,
            //                ProjectStatusName = (k.ProjectStatus == null ? "Under Review" : k.ProjectStatus),
            //                Address = y.Address,
            //                ContactNo = y.ContactNo,
            //                FaxNo = y.FaxNo,
            //            });
            //return data1.ToList();
            var data = (from a in ctx.TblMiscellaneousRecord.Where(aa => aa.MiscellaneousRecordId == id)
                        join y in ctx.TblTransactionDetail on a.TransactionId equals y.TransactionId
                        join c in ctx.MstTransactionType on y.TransactionTypeId equals c.TransactionTypeId
                        join z in ctx.MstTaxMaster on a.TaxId equals z.TaxId
                        join b in ctx.MstSlab on a.SlabId equals b.SlabId

                        select new MiscellaneousRecordModel
                        {
                            MiscellaneousRecordId = a.MiscellaneousRecordId,
                            TransactionId = a.TransactionId,
                            TaxId = a.TaxId,
                            SlabId = a.SlabId,
                            Name = a.Name,
                            Address = a.Address,
                            Cid = a.Cid,
                            MobileNo = a.MobileNo,
                            Quantity = a.Quantity,
                            Amount = a.Amount,
                            PaymentStatus = a.PaymentStatus,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedOn = a.ModifiedOn,
                            ModifiedBy = a.ModifiedBy,
                            TransactionTypeId = y.TransactionTypeId,
                            TransactionType = c.TransactionType,
                            Tax = z.TaxName,
                            Slab = b.SlabName
                        });

            return await data.FirstOrDefaultAsync();

        }
    

        public int Update(MiscellaneousRecordModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var DataT = ctx.TblTransactionDetail.FirstOrDefault(u => u.TransactionId == obj.TransactionId);
                    DataT.TransactionTypeId = obj.TransactionTypeId; DataT.TransactionValue = obj.Amount; DataT.ModifiedBy = obj.ModifiedBy; DataT.ModifiedOn = obj.ModifiedOn;

                    ctx.SaveChanges();
                    var Data = ctx.TblMiscellaneousRecord.FirstOrDefault(u => u.MiscellaneousRecordId == obj.MiscellaneousRecordId);

                    //   Data.TransactionId = obj.TransactionId;
                    Data.TaxId = obj.TaxId;
                    Data.SlabId = obj.SlabId;
                    Data.Name = obj.Name;
                    Data.Address = obj.Address;
                    Data.Cid = obj.Cid;
                    Data.MobileNo = obj.MobileNo;
                    Data.Quantity = obj.Quantity;
                    Data.Amount = obj.Amount;
                    Data.PaymentStatus = obj.PaymentStatus;
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
        public bool CheckExists(int id)
        {
            return ctx.TblMiscellaneousRecord.Any(e => e.MiscellaneousRecordId == id);
        }
        public async Task Delete(int? id)
        {
            var MstLap = await ctx.TblMiscellaneousRecord
                           .FirstOrDefaultAsync(m => m.MiscellaneousRecordId == id);
        }
        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var TblMiscellaneousRecord = ctx.TblMiscellaneousRecord.Find(id);
                ctx.TblMiscellaneousRecord.Remove(TblMiscellaneousRecord);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }


        public List<MstTransactionTypeTaxMap> fetchPV(int id)
        {
            var data = (from a in ctx.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == id)

                        select new MstTransactionTypeTaxMap
                        {
                            TaxId = a.TaxId,
                            Tax = a.Tax

                        });


            return data.ToList();
        }
        public List<MstTaxMaster> fetchPG(int id)
        {
            var data = (from a in ctx.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == id)
                        join b in ctx.MstTaxMaster on a.TaxId equals b.TaxId

                        select new MstTaxMaster
                        {
                            TaxId = b.TaxId,
                            TaxName = b.TaxName
                        });
            return data.ToList();
        }
        public List<MstSlab> fetchBB(int id)
        {
            var data = (from a in ctx.MstSlab.Where(x => x.SlabId == id)
                        select new MstSlab
                        {
                            SlabId = a.SlabId,
                            SlabName = a.SlabName
                        });
            return data.ToList();
        }
        public List<MstSlab> fetchLUSC(int id)
        {
            var data = (from a in ctx.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == id)
                        join b in ctx.MstSlab on a.TaxId equals b.TaxId
                       
                        select new MstSlab
                        {
                            SlabId = b.SlabId,
                            SlabName = b.SlabName

                        });


            return data.ToList();
        }

        public long SaveMiscellaneousRecord(MiscellaneousRecordModel obj)
        {
            try
            {
                var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                int cyr = ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(xx => xx.CalendarYearId);// make default check at startup



                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                sq = sq == null ? 0 : ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                sq = sq + 1;

                using TransactionScope s = new TransactionScope();
                long transactionId;

                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = obj.TransactionTypeId,//you need to make drop down for dysnamic value
                    //Transaction = "Miscellaneous",
                    WorkLevelId = 1,
                    TransactionValue = obj.Amount,// obj.TotalPayable,  calculated value here from interface                
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblTransactionDetail.Add(entityTRn);
                ctx.SaveChanges();
                transactionId = entityTRn.TransactionId;

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

                long ipk;
                var entities = new TblMiscellaneousRecord
                {
                    MiscellaneousRecordId = obj.MiscellaneousRecordId,
                    TransactionId = transactionId,
                    TaxId = obj.TaxId,
                    SlabId = obj.SlabId,
                    Name = obj.Name,
                    Address = obj.Address,
                    Cid = obj.Cid,
                    MobileNo = obj.MobileNo,
                    Quantity = obj.Quantity,
                    Amount = obj.Amount,
                    PaymentStatus = obj.PaymentStatus,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblMiscellaneousRecord.Add(entities);
                ctx.SaveChanges();
                ipk = entities.MiscellaneousRecordId;


                var entity = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = obj.TaxId,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = obj.Amount,
                    TotalAmount = obj.Amount,
                    MiscellaneousRecordId = ipk, 
                    LandDetailId = null,
                    TaxPayerId = null,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate=obj.CreatedOn
                };
                ctx.TblDemand.Add(entity);
                ctx.SaveChanges();


               
                s.Complete();
                s.Dispose();
               

                return ipk;




            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        public List<MiscellaneousRecordModel> fetchdataByCid(string Cid, string Name, string fromdate, string todate)
        {

            var data = (from x in ctx.TblMiscellaneousRecord.Where(x => (string.IsNullOrEmpty(Cid) || x.Cid == Cid) && (string.IsNullOrEmpty(Name) || x.Name == Name) && (string.IsNullOrEmpty(fromdate) || x.CreatedOn.Date >= Convert.ToDateTime(fromdate) && (string.IsNullOrEmpty(todate) || x.CreatedOn.Date <= Convert.ToDateTime(todate))))
                        join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join a in ctx.MstSlab on x.SlabId equals a.SlabId
                        join b in ctx.MstRate on a.SlabId equals b.SlabId
                        select new MiscellaneousRecordModel
                        {
                            MiscellaneousRecordId = x.MiscellaneousRecordId,
                            TransactionId = x.TransactionId,
                            TaxId = x.TaxId,
                            SlabId = x.SlabId,
                            Name = x.Name,
                            Address = x.Address,
                            Cid = x.Cid,
                            MobileNo = x.MobileNo,
                            Quantity = x.Quantity,
                            Amount = x.Amount,
                            PaymentStatus = x.PaymentStatus,


                            //Transaction = y.Transaction,
                            Tax = z.TaxName,
                            Slab = a.SlabName,
                            Rate = b.Rate
                        });
            return data.ToList();
        }


        public List<MiscellaneousRecordModel> GetApplicantDetails(int id)
        {
            var data = (from x in ctx.TblMiscellaneousRecord.Where(x => x.MiscellaneousRecordId == id)
                        join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join a in ctx.MstSlab on x.SlabId equals a.SlabId



                        select new MiscellaneousRecordModel
                        {
                            MiscellaneousRecordId = x.MiscellaneousRecordId,
                            TransactionId = x.TransactionId,
                            TaxId = x.TaxId,
                            SlabId = x.SlabId,
                            Name = x.Name,
                            Address = x.Address,
                            Cid = x.Cid,
                            MobileNo = x.MobileNo,
                            Quantity = x.Quantity,
                            Amount = x.Amount,
                            PaymentStatus = x.PaymentStatus,


                            //Transaction = y.Transaction,
                            Tax = z.TaxName,
                            Slab = a.SlabName
                        });
            return data.ToList();
        }


        //public async Task Delete(int? id)
        //{
        //    var TblMiscellaneousRecord = await ctx.TblMiscellaneousRecord
        //                   .FirstOrDefaultAsync(m => m.MiscellaneousRecordId == id);
        //}
        //public bool DuplicateCheckOnSave(string InspectionType)
        //{
        //    return ctx.TblMiscellaneousRecord.Any(e => e.InspectionType == InspectionType);
        //}
        //public bool DuplicateCheckOnUpdate(string InspectionType, int InspectionTypeId)
        //{
        //    return ctx.TblMiscellaneousRecord.Any(e => e.InspectionType == InspectionType && e.InspectionTypeId != InspectionTypeId);
        //}

        //*************************** Print demand receipt***************************************
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
        public List<MiscellaneousRecordModel> PrintDemand(int id)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == id).Max(x => x.DemandNo);

            var data = (from x in ctx.TblMiscellaneousRecord.Where(x => x.MiscellaneousRecordId == id)
                            //join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join a in ctx.MstSlab on x.SlabId equals a.SlabId
                        join b in ctx.MstRate on a.SlabId equals b.SlabId

                        join c in ctx.TblDemand on x.TransactionId equals c.TransactionId
                        join d in ctx.TblDemandNo on c.DemandNoId equals d.DemandNoId
                        join au in ctx.AspNetUsers on c.CreatedBy equals au.UserId

                        let qr = GenerateQr(dn.ToString())

                        select new MiscellaneousRecordModel
                        {
                            QrImage = qr,
                            CreatedOn = d.CreatedOn,
                            TaxId = x.TaxId,
                            Tax = z.TaxName,
                            DemandNo = d.DemandNo,
                            User = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),

                            Name = x.Name,
                            Address = x.Address,
                            MobileNo = x.MobileNo,
                            Cid = x.Cid,
                            SlabId = x.SlabId,
                            Quantity = x.Quantity,
                            Amount = x.Amount,
                            Slab = a.SlabName,
                            Rate = b.Rate
                        });
            return data.ToList();
        }



        public List<MiscellaneousRecordModel> mPrintDemand(int id)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == id).Max(x => x.DemandNo);

            var data = (from x in ctx.TblMiscellaneousRecord.Where(x => x.MiscellaneousRecordId == id)
                            //join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        
                        join c in ctx.TblDemand on x.TransactionId equals c.TransactionId
                        join d in ctx.TblDemandNo on c.DemandNoId equals d.DemandNoId
                        join au in ctx.AspNetUsers on c.CreatedBy equals au.UserId

                        let qr = GenerateQr(dn.ToString())

                        select new MiscellaneousRecordModel
                        {
                            QrImage = qr,
                            CreatedOn = d.CreatedOn,
                            TaxId = x.TaxId,
                            Tax = z.TaxName,
                            DemandNo = d.DemandNo,
                            User = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),

                            Name = x.Name,
                            Address = x.Address,
                            MobileNo = x.MobileNo,
                            Cid = x.Cid,
                          
                            Amount = x.Amount,
                           
                        });
            return data.ToList();
        }



        public List<MiscellaneousRecordModel> MReport(int TaxId, string fromdate, string todate)
        {

            var data = (from y in ctx.TblLedger.Where(x => (x.TaxId == TaxId) || (string.IsNullOrEmpty(fromdate) || x.CreatedOn.Date >= Convert.ToDateTime(fromdate) && (string.IsNullOrEmpty(todate) || x.CreatedOn.Date <= Convert.ToDateTime(todate))))
                        join x in ctx.TblMiscellaneousRecord on y.MiscellaneousRecordId equals x.MiscellaneousRecordId
                        join z in ctx.MstTaxMaster on y.TaxId equals z.TaxId

                        select new MiscellaneousRecordModel
                        {
                            MiscellaneousRecordId = x.MiscellaneousRecordId,
                            TransactionId = x.TransactionId,
                            TaxId = x.TaxId,
                            SlabId = x.SlabId,
                            Name = x.Name,
                            Address = x.Address,
                            Cid = x.Cid,
                            MobileNo = x.MobileNo,
                            Quantity = x.Quantity,
                            Amount = x.Amount,
                            PaymentStatus = x.PaymentStatus,
                            CreatedOn = y.PaymentDate,

                      
                            Tax = z.TaxName,
                         
                        });
            return data.ToList();
        }
    }
}

