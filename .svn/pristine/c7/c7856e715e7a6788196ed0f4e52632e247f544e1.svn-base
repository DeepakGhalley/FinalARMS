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

namespace CORE_BLL
{
    public class LandFeeDetailBLL : ILandFeeDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        
  public int Save(LandFeeDetailVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();


                long TransactionId;
                int WorkLevelId;
                int TransactionTypeId=0;


                var LandService = obj.LandServiceTypeId;
                if (LandService == 1)
                {
                    TransactionTypeId = 34;
                }
               else if (LandService == 2)
                {
                    TransactionTypeId = 35;
                }
               else if (LandService == 3)
                {
                    TransactionTypeId = 36;
                }
                else if (LandService == 4)
                {
                    TransactionTypeId = 37;
                }
                else if (LandService == 5)
                {
                    TransactionTypeId = 38;
                }
                else if (LandService == 6)
                {
                    TransactionTypeId = 39;
                }
                else if (LandService == 7)
                {
                    TransactionTypeId = 40;
                }
                else if (LandService == 8)
                {
                    TransactionTypeId = 41;
                }
                else if (LandService == 9)
                {
                    TransactionTypeId = 13;
                }
                var TRNEntity = new TblTransactionDetail
                    {
                        TransactionTypeId = TransactionTypeId,
                        WorkLevelId = 3,
                        CreatedOn = obj.CreatedOn,
                        TransactionValue = obj.Amount
                    };
                    ctx.TblTransactionDetail.Add(TRNEntity);
                    ctx.SaveChanges();
                    TransactionId = TRNEntity.TransactionId;
                int? sq = 0;
                //int sq = ctx.TblDemandNo.Where(p => p.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;

                var dt = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year));
                if (dt.Any())
                {

                    sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                }
                
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
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblDemandNo.Add(entityDN);
                ctx.SaveChanges();
                dnid = entityDN.DemandNoId;

                var LandServiceTypeId = obj.LandServiceTypeId;
                if (LandServiceTypeId == 1){
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 28,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }
               else if (LandServiceTypeId == 2)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 26,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }

                else if (LandServiceTypeId == 9)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 22,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.ScrutinyFeeAmount,
                        TotalAmount = obj.ScrutinyFeeAmount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();

                    var entityDs = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 23,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.ServiceandAmenitiesfeeAmount,
                        TotalAmount = obj.ServiceandAmenitiesfeeAmount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityDs);
                    ctx.SaveChanges();
                }
                else if (LandServiceTypeId == 3)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 27,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }
                else if (LandServiceTypeId == 4)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 30,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }
                else if (LandServiceTypeId == 5)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 24,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }
                else if (LandServiceTypeId == 6)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 47,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }
                else if (LandServiceTypeId == 7)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 80,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }
                else if (LandServiceTypeId == 8)
                {
                    var entityD = new TblDemand
                    {

                        TransactionId = TransactionId,
                        DemandNoId = dnid,
                        TaxId = 56,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.Amount,
                        TotalAmount = obj.Amount,
                        LandDetailId = obj.LandDetailId,
                        LandOwnershipId = obj.LandOwnershipId,
                        TaxPayerId = obj.TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingDate = DateTime.Now
                    };
                    ctx.TblDemand.Add(entityD);
                    ctx.SaveChanges();
                }
                int ipk;
                var entity = new TrnLandFeeDetail
                {
                    LandFeeDetailId = obj.LandFeeDetailId,
                    LandServiceTypeId = obj.LandServiceTypeId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TransactionId = TransactionId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now
                    
                };
                ctx.TrnLandFeeDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LandFeeDetailId;

                return (int)TransactionId;
            }
            // catch (System.Exception)
            // {
            //  return 0;
            // }
            catch (Exception ex)
            {

                throw;
            }
        }
 public List<LedgerDemandVM> FetchlandOwnershipDetails(string Ttin, string Cid, string PlotNo, string ThramNo)
        {
            var data = (from x in ctx.TblLandOwnershipDetail
                        join a in ctx.MstTaxPayerProfile on x.TaxPayerId equals a.TaxPayerId
                        join b in ctx.MstLandDetail on x.LandDetailId equals b.LandDetailId
                       

                        
                        where( a.Ttin == Ttin || a.Cid == Cid || b.PlotNo == PlotNo || x.ThramNo == ThramNo) && x.PLr != 0
                        select new LedgerDemandVM
                        {
                            LandOwnerShipId = x.LandOwnershipId,
                            Ttin = a.Ttin,
                            FullName = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            LandDetailId = x.LandDetailId,
                            PlotNo = b.PlotNo,
                            TaxPayerId = x.TaxPayerId,
                            Cid = a.Cid,
                            ThramNo = x.ThramNo,
                          

                        });
            return data.ToList();
        }


        public List<LedgerDemandVM> FetchTaxDetails(long TaxPayerId)
        {
            int [] tid = { 34, 35, 36, 37, 38, 39, 40, 41 };
            var Vendor = (
                  
                  from x in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerId == TaxPayerId)
                  join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                  join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                  where tid.Contains(t.TransactionTypeId)
                  select y.TransactionId).ToList();

          

            var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId))
                       
                        .OrderBy(xx => xx.TransactionId)
                        .OrderBy(xx => xx.TaxPayerId)
                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        where x.IsPaymentMade == false
                        let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                        let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                        let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                        select new LedgerDemandVM
                        {
                            TotalAmount = cuc_sum,
                           
                            DemandNo = y.DemandNo,
                            TaxName = z.TaxName,
                            TransactionId = x.TransactionId
                        }).Distinct();

            return (List<LedgerDemandVM>)data.ToList();
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

       

        public List<LedgerDemandVM> PrintDemand(int TransactionId)
        {
            var DataDemand = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
            var DemandNoId = DataDemand.FirstOrDefault().DemandNoId;
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);


            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                            //join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join o in ctx.TblLandOwnershipDetail on x.LandOwnershipId equals o.LandOwnershipId
                        join l in ctx.MstLandDetail on o.LandDetailId equals l.LandDetailId
                        let netamt = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Sum(t => t.TotalAmount)
                        //let BillingDate = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Max(t => t.BillingDate)
                        let qr = GenerateQr(dn.ToString())

                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            CreatedOn = x.CreatedOn,
                            TaxId = x.TaxId,
                            TaxName = z.TaxName,
                            DemandNo = dn,
                          
                            FullName = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            
                            PhoneNo = tp.MobileNo,
                            Cid = tp.Cid,
                            Amount = netamt,
                            TotalAmount = x.TotalAmount,
                           PlotNo = l.PlotNo,
                          ThramNo = o.ThramNo,
                          Ttin = tp.Ttin

                        });
            return data.ToList();
        }

        public List<LedgerDemandVM> PrintUser(int TransactionId)
        {
            var data = from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)

                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       select new LedgerDemandVM
                       {
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                       }; ;
            return data.ToList();
        }


        //***********************************************date for vendor********************************************************
        public List<LedgerDemandVM> fetchreceiptuser(long TransactionId)
        {
            var data = from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)

                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       select new LedgerDemandVM
                       {
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                       }; ;
            return data.ToList();
        }

    



        //*****************************************Land Tranactions Fee recepit*****************************************
        public List<LedgerDemandVM> LandTransactionFeeRecepit(long TransactionId)
        {
            var DataLedger = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
            var lReceiptId = DataLedger.FirstOrDefault().DemandNoId;
            var rn = ctx.TblDemandNo.Where(d => d.DemandNoId == lReceiptId).Max(x => x.DemandNo);

            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId

                        let netamt = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Sum(t => t.TotalAmount)

                        let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId && lod.LandDetailId == x.LandDetailId)).Take(1).FirstOrDefault().ThramNo
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                          
                            TaxPayerId = tp.TaxPayerId,

                            FullName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            PlotNo = l.PlotNo,
                            //ThramNo = l.ThramNo,
                            TaxName = tx.TaxName,

                            ThramNo = tno,
                            TransactionTypeId = t.TransactionTypeId


                        });

            return data.ToList();


        }

    }
}


