using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Internal;
using QRCoder;
using System.Drawing;
using System.IO;

namespace CORE_BLL
{
    public class DuplicateDemandPrintBLL : IDuplicateDemandPrint
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        //***************************  QR Code ***************************************
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

        //*******************************Property Tax*********************************

        public IList<LandOwneshipModel> FetchDuplicateDemandProperty(string Cid, string Ttin, string Year)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == Cid || x.Ttin == Ttin)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        join td in ctx.TblDemand on a.TaxPayerId equals td.TaxPayerId
                        join cl in ctx.MstCalendarYear on td.CalendarYearId equals cl.CalendarYearId
                        join tt in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals tt.TaxPayerTypeId
                       join tax in ctx.MstTaxMaster on td.TaxId equals tax.TaxId
                        join c in ctx.TblLandOwnershipDetail on td.LandOwnershipId equals c.LandOwnershipId
                        join lot in ctx.EnumLandOwnershipType on c.LandOwnershipTypeId equals lot.LandOwnershipTypeId
                        join d in ctx.MstLandDetail on c.LandDetailId equals d.LandDetailId
                        join lt in ctx.MstLandType on d.LandTypeId equals lt.LandTypeId
                        where (cl.CalendarYear == Year)
                        select new LandOwneshipModel
                        {
                            CalendarYearId = cl.CalendarYearId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            FullName = b.Title + "" + a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),

                            TaxPayerType = tt.TaxPayerType,
                            MobileNo = a.MobileNo,
                            Email = a.Email,
                            CAddress = a.CAddress,
                            ThramNo = c.ThramNo,
                            PlotNo = d.PlotNo,
                            LandOwnershipType = lot.LandOwnershipType,
                            LandTypeName = lt.LandTypeName,
                            LandAcerage = d.LandAcerage,
                            DemandNoId = td.DemandNoId,
                            Plr = c.PLr,

                            TaxName = tax.TaxName

                        }).Distinct();
            return data.ToList();
        }


        //***********************************************date for vendor********************************************************
        public IList<LedgerDemandVM> fetchdemandreceiptuser(int DemandNoId)
        {
            var data = from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                      
                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       select new LedgerDemandVM
                       {
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                       }; ;
            return data.ToList();
        }

        public IList<LedgerDemandVM> PrintDemandforpropertytax(int DemandNoId)
        {
            var rn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

            var data = (from x in ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId)
                       
                        join dn in ctx.TblDemandNo on x.DemandNoId equals dn.DemandNoId
                        join t in ctx.MstTaxMaster on x.TaxId equals t.TaxId

                        let netamt = ctx.TblDemand.Where(l => l.DemandNoId == DemandNoId).Sum(t => t.TotalAmount)

                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            TotalAmount = x.TotalAmount,
                            Receipt = rn,
                            CreatedOn = x.CreatedOn,
                          GrandTotalAmount = netamt,
                            DemandNo = dn.DemandNo,
                            NetAmount = netamt,
                            TaxName = t.TaxName


                        });
      

            return data.ToList();


        }



       
    }
}
