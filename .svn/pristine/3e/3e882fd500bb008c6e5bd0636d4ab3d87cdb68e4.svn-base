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
    public class PaymentReceiptByReceiptNoBLL : IPaymentReceiptByReceiptNo
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public List<PaymentReceiptByReceiptNo> GetReceiptDetails(string ReceiptNo)
        {
            var data = (from x in ctx.TblReceipt.Where(x => x.ReceiptNo == ReceiptNo)
                        join y in ctx.TblLedger on x.ReceiptId equals y.ReceiptId
                        join wr in ctx.TblWaterMeterReading on y.WaterMeterReadingId equals wr.WaterMeterReadingId 
                        into b
                        from bb in b.DefaultIfEmpty()
                        join w in ctx.MstWaterConnection on bb.WaterConnectionId equals w.WaterConnectionId into c
                        from cc in c.DefaultIfEmpty()
                        join u in ctx.MstLandDetail on y.LandDetailId equals u.LandDetailId into h
                        from uu in h.DefaultIfEmpty()
                        join f in ctx.TblTransactionDetail on y.TransactionId equals f.TransactionId
                        join z in ctx.MstTransactionType on f.TransactionTypeId equals z.TransactionTypeId
                        join p in ctx.TblPaymentLeger on x.ReceiptId equals p.ReceiptId
                        join m in ctx.EnumPaymentMode on p.PaymentModeId equals m.PaymentModeId
                        join l in ctx.MstTaxMaster on y.TaxId equals l.TaxId
                        join t in ctx.MstTaxPayerProfile on y.TaxPayerId equals t.TaxPayerId
                         into t
                        from tp in t.DefaultIfEmpty()
                        join tpt in ctx.EnumTaxPayerType on tp.TaxPayerTypeId equals tpt.TaxPayerTypeId
                          into tpt
                        from tpts in tpt.DefaultIfEmpty()
                        select new PaymentReceiptByReceiptNo
                        {
                            ReceiptId = x.ReceiptId,
                            ReceiptNo = x.ReceiptNo,
                            TaxName = l.TaxName,
                            ReceiptYear = x.ReceiptYear,
                            TaxPayerName = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Amount = y.TotalAmount,
                            PenaltyAmount = y.PenaltyAmount,
                            PaymentMode = m.PaymentMode,
                            TTIN = tp.Ttin,
                            CID = tp.Cid,
                            PlotNo = uu.PlotNo,
                            LandDetailId = (int)y.LandDetailId,
                            IsApportioned = (bool)uu.IsApportioned,
                            GrandTotal = p.Amount,
                            TransactionTypeId = z.TransactionTypeId,
                            ConsumerNo = cc.ConsumerNo,
                            MeterNo = cc.WaterMeterNo,
                            BillingAddress = cc.BillingAddress,
                            MobileNo = tp.MobileNo,
                            TaxPayerType = tpts.TaxPayerType,
                            Email = tp.Email

                        });
            return data.ToList();
        }
        public List<PaymentReceiptByReceiptNo> GetECReceiptDetails(string ReceiptNo)
        {
            var data = (from x in ctx.TblReceipt.Where(x => x.ReceiptNo == ReceiptNo)
                        join y in ctx.TblLedger on x.ReceiptId equals y.ReceiptId
                        join wr in ctx.TblEcrenewalDetail on y.EcRenewalId equals wr.EcRenewalId into b
                        from bb in b.DefaultIfEmpty()
                        join w in ctx.TblEcdetail on bb.EcDetailId equals w.EcDetailId into c
                        from cc in c.DefaultIfEmpty()
                        join u in ctx.MstEcapplicantdetail on y.ApplicantId equals u.ApplicantId into h
                        from uu in h.DefaultIfEmpty()
                        join r in ctx.MstEcactivityType on cc.EcActivityTypeId equals r.EcActivityTypeId
                        join f in ctx.TblTransactionDetail on y.TransactionId equals f.TransactionId
                        join z in ctx.MstTransactionType on f.TransactionTypeId equals z.TransactionTypeId
                        join p in ctx.TblPaymentLeger on x.ReceiptId equals p.ReceiptId
                        join m in ctx.EnumPaymentMode on p.PaymentModeId equals m.PaymentModeId
                        join l in ctx.MstTaxMaster on y.TaxId equals l.TaxId
                        select new PaymentReceiptByReceiptNo
                        {
                            ReceiptId = x.ReceiptId,
                            ReceiptNo = x.ReceiptNo,
                            TaxName = l.TaxName,
                            ReceiptYear = x.ReceiptYear,
                            ApplicantName = uu.ApplicantName,
                            Amount = y.TotalAmount,
                            PaymentMode = m.PaymentMode,
                            TTIN = uu.LicenceNo,
                            CID = uu.Cid,
                            GrandTotal = p.Amount,
                            TransactionTypeId = z.TransactionTypeId,
                            MobileNo = uu.ContactNo,
                            ActivityType = r.ActivityType,
                            ECRefNo = bb.EcRefNo

                        });
            return data.ToList();
        }

        public IList<LedgerDemandVM> fetchECledgerdata(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(l => l.ReceiptId == RecepitId).Max(x => x.ReceiptNo);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == RecepitId)
                            
                        join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                        join d in ctx.TblDemand on a.DemandId equals d.DemandId
                        join dn in ctx.TblDemandNo on d.DemandNoId equals dn.DemandNoId
                        join e in ctx.TblEcrenewalDetail on d.EcRenewalId equals e.EcRenewalId
                        join f in ctx.TblEcdetail on e.EcDetailId equals f.EcDetailId
                        join q in ctx.MstEcapplicantdetail on f.ApplicantId equals q.ApplicantId
                        join u in ctx.MstEcactivityType on f.EcActivityTypeId equals u.EcActivityTypeId
                        join td in ctx.TblTransactionDetail on a.TransactionId equals td.TransactionId

                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let pamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)

                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,
                            TotalAmount = a.TotalAmount,
                            CreatedOn = r.CreatedOn,
                            ApplicantName = q.ApplicantName,
                            Address = q.Address,
                            PhoneNo = q.ContactNo,
                            ActivityType = u.ActivityType,
                            ECRefNo = e.EcRefNo,
                            DemandNo = dn.DemandNo,
                            Cid = q.Cid,
                            LicenseNo = q.LicenceNo


                        });
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
    }
}

