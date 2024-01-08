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
    public class VacuumTankerServiceBLL : IVacuumTankerService
    {
        readonly tt_dbContext ctx = new tt_dbContext();





        public IList<VacuumTankerServiceVM> GetAll()
        {
            var data = (from a in ctx.TrnVacuumTankerService
                        join b in ctx.TblLandOwnershipDetail on a.LandOwnershipId equals b.LandOwnershipId
                        join tp in ctx.MstTaxPayerProfile on b.TaxPayerId equals tp.TaxPayerId
                        select new VacuumTankerServiceVM
                        {
                            Name = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            ContactName = a.ContactName,
                            NoOfTrips = a.NoOfTrips,
                            Amount = a.Amount,
                            MobileNo = a.MobileNo

                        });

            return data.ToList();
        }

        public IList<TaxPayerProfileModel> GetTaxpayer(string Cid,String Ttin)
        {
            var data = (from tp in ctx.MstTaxPayerProfile
                        join b in ctx.TblLandOwnershipDetail on tp.TaxPayerId equals b.TaxPayerId
                        join c in ctx.MstLandDetail on b.LandDetailId equals c.LandDetailId
                        where (tp.Cid == Cid || tp.Ttin == Ttin)
                        
                        select new TaxPayerProfileModel
                        {
                            Name = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                           Ttin = tp.Ttin,
                           Cid = tp.Cid,
                            MobileNo = tp.MobileNo,
                            PlotNo = c.PlotNo,
                            ThramNo = b.ThramNo,
                            LandOwnershipId = b.LandOwnershipId
                            

                        });

            return data.ToList();
        }

        //save
        public long Save(VacuumTankerServiceVM obj)
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
                    TransactionTypeId = 11,//you need to make drop down for dysnamic value
                    //Transaction = "Miscellaneous",
                    WorkLevelId = 3,
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

                int? tpi;
                int? losi;
                var LandOwnershipId = obj.LandOwnershipId;
                if(LandOwnershipId == null)
                {
                    tpi = null;
                    losi = 1;
                }
                else
                {
                    var LandOwnershipDetail = ctx.TblLandOwnershipDetail.Where(w => w.LandOwnershipId == LandOwnershipId);
                     tpi = LandOwnershipDetail.FirstOrDefault().TaxPayerId;
                    losi = obj.LandOwnershipId;
                }
                long ipk;
                var entities = new TrnVacuumTankerService
                {
                    
                    TransactionId = transactionId,
                    LandOwnershipId = (int)losi,
                    ContactName = obj.Name,
                    MobileNo = obj.MobileNo,
                    Amount = obj.Amount,
                    NoOfTrips = obj.NoOfTrips,
                    EmailId = obj.EmailId,
                    ContactAddress = obj.ContactAddress,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TrnVacuumTankerService.Add(entities);
                ctx.SaveChanges();
                ipk = entities.VacuumTankerServiceId;


                var entity = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = dnid,
                    TaxId = 48,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = obj.Amount,
                    TotalAmount = obj.Amount,
                    MiscellaneousRecordId = null,
                    LandDetailId = null,
                    TaxPayerId = tpi,
                    LandOwnershipId = losi,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate = obj.CreatedOn
                };
                ctx.TblDemand.Add(entity);
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

        public IList<LedgerDemandVM> PrintDemand(int id)
        {
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == id).Max(x => x.DemandNo);

            var data = (from x in ctx.TblDemand.Where(x => x.DemandNoId == id)
                         
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join a in ctx.MstSlab on z.TaxId equals a.TaxId
                        join b in ctx.MstRate on a.SlabId equals b.SlabId

                        join t in ctx.TrnVacuumTankerService on x.TransactionId equals t.TransactionId
                        join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId

                        let qr = GenerateQr(dn.ToString())

                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            CreatedOn = x.CreatedOn,
                            DemandNo = dn,


                            TaxName = z.TaxName,
                            Rate = b.Rate,
                            NoOfTrips = t.NoOfTrips,
                            Amount = x.TotalAmount,

                            UserName = t.ContactName,
                            PhoneNo = t.MobileNo,
                            Address = t.ContactAddress,
                            Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                        });
            return data.ToList();
        }
    }
}
