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
    public class Parkingfee1Bll : IParkingFee1
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public IList<Parkingfee1VM> GetAll()
        {
            var data = (from x in ctx.TblUnScheduledParkingRecord
                        join t in ctx.TblDemand on x.TransactionId equals t.TransactionId
                        join d in ctx.TblDemandNo on t.DemandNoId equals d.DemandNoId
                        
                        select new Parkingfee1VM
                        {
                           UnScheduledParkingRecordId = x.UnScheduledParkingRecordId,
                           Cid = x.Cid,
                           VendorName = x.VendorName,
                           VendorAddress = x.VendorAddress,
                           Amount = x.Amount,
                           DemandNo = d.DemandNo

                        });
            return data.ToList();

        }

        public int Save(Parkingfee1VM obj)
        {
            try
                {
                    using TransactionScope s = new TransactionScope();


                long TransactionId;
                    var TRNEntity = new TblTransactionDetail
                    {
                        TransactionTypeId = 42,
                        WorkLevelId = 3,
                        CreatedOn = obj.CreatedOn,
                        TransactionValue = obj.Amount
                    };
                    ctx.TblTransactionDetail.Add(TRNEntity);
                    ctx.SaveChanges();
                    TransactionId = TRNEntity.TransactionId;
                    
                
                int? sq = 0;
                    var dt = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year));
                    if (dt.Any())
                    {

                        sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                    }
                    else
                    { sq = null; }
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
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,
                    };
                    ctx.TblDemandNo.Add(entityDN);
                    ctx.SaveChanges();
                    dnid = entityDN.DemandNoId;

                int UnScheduledParkingRecordId;
                var entity = new TblUnScheduledParkingRecord
                {
                    Cid = obj.Cid,
                    VendorName = obj.VendorName,
                    VendorAddress = obj.VendorAddress,
                    FromDate = obj.FromDate,
                    ToDate = obj.ToDate,
                    Amount = obj.Amount,
                    TransactionId = TransactionId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now

                };
                ctx.TblUnScheduledParkingRecord.Add(entity);
                ctx.SaveChanges();

                UnScheduledParkingRecordId = entity.UnScheduledParkingRecordId;
                var entityD = new TblDemand
                        {

                            TransactionId = TransactionId,
                            DemandNoId = dnid,
                            TaxId = 45,
                            FinancialYearId = Convert.ToInt32(fyr),
                            CalendarYearId = cyr,
                            DemandAmount = obj.Amount,
                            TotalAmount = obj.Amount,
                            UnScheduledParkingRecordId = UnScheduledParkingRecordId,
                            //TaxPayerId = obj.TaxPayerId,
                            CreatedBy = obj.CreatedBy,
                            CreatedOn = DateTime.Now,
                            BillingDate = DateTime.Now
                        };
                        ctx.TblDemand.Add(entityD);
                        ctx.SaveChanges();
                    
                   
                    
                   
                    s.Complete();
                    s.Dispose();
                   

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


        public List<Parkingfee1VM> PrintUser(int TransactionId)
        {
            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                        join tp in ctx.AspNetUsers on x.CreatedBy equals tp.UserId
                        select new Parkingfee1VM
                        {
                            Creatorname = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),


                        });
            return data.ToList();
        }
        public List<Parkingfee1VM> PrintDemand(int TransactionId)
        {
            var DataDemand = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
            var DemandNoId = DataDemand.FirstOrDefault().DemandNoId;
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);


            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                           
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        
                        join u in ctx.TblUnScheduledParkingRecord on x.TransactionId equals u.TransactionId
                        let netamt = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Sum(t => t.TotalAmount)
                       
                        let qr = GenerateQr(dn.ToString())

                        select new Parkingfee1VM
                        {
                            QrImage = qr,
                            VendorAddress = u.VendorAddress,
                            VendorName = u.VendorName,
                            Amount = x.TotalAmount,
                            TotalAmount = netamt,
                            Cid = u.Cid,
                           FromDate = u.FromDate,
                           ToDate = u.ToDate,
                           DemandNo = dn,
                           Date = x.CreatedOn,
                           TaxName = z.TaxName,
                           CreatedOn = x.CreatedOn

                        });
            return data.ToList();
        }
    }
}



