
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
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CORE_BLL
{
    public class RevenueReportBLL : IRevenueReport
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IEnumerable<ARevenueVM> Revenue(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.Revenue.FromSqlRaw($"ARevenu {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        //*****************************************************Water*********************************************************************
        public IEnumerable<AwaterVM> Revenuewater(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.water.FromSqlRaw($"ARevenuWater {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<AwaterHeadwiseVM> Revenuewaterheadwise(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.Waterheadwise.FromSqlRaw($"ARevenuWaterminorhead {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }


        public IEnumerable<AwaterReceiptwiseVM> Revenuewaterrecepitwise(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.WaterRecepitwise.FromSqlRaw($"ARevenuwaterRecepitwise {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

      

        //*************************** Print Paymen receipt***************************************
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

        //***************************************************PROPERTY*************************************************************************
        public IEnumerable<ApropertyVM> Revenueproperty(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.property.FromSqlRaw($"ARevenuProperty {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<ApropertyheadwiseVM> Revenuepropertyheadwise(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.Propertyheadwise.FromSqlRaw($"ARevenuPropertyminorhead {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public IEnumerable<ApropertyrecepitwiseVM> Revenuepropertyeceiptwise(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.PropertyRecepitwise.FromSqlRaw($"ARevenuPropertyRecepitwise {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<wiseCollectionVM> wiseCollection(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.wiseCollection.FromSqlRaw($"ARevenueIndividualwise {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<wiseCollectionVM> showwiseCollection()
        {

            try
            {
                var result = ctx.IndividualwiseCollection.FromSqlRaw($"ARevenueShowIndividualwise");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<SavewiseCollectionVM> SavewiseCollection(int UserId, int CreatedBy, decimal checkedAmount, string collectionStartDate, string collectionEndDate)

        {

            try
            {
                var result = ctx.SaveIndividualwiseCollection.FromSqlRaw($"ARevenueCreateIndividualwise {UserId},{CreatedBy},{checkedAmount},{collectionStartDate},{collectionEndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }


        public IEnumerable<wiseCollectedVM> Collected(string StartDate, string EndDate)
        {

            try
            {
                var result = ctx.IndividualCollectionReport.FromSqlRaw($"ARevenueCollectedIndividual {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }


        public IEnumerable<ModeWiseCollectionVM> ModeWise(string StartDate, string EndDate,int PaymentModeId,int UserId)
        {
            string myexc = "";
            try
            {
                var result = ctx.ModeWisecollect.FromSqlRaw($"Modewisecollection {StartDate},{EndDate},{PaymentModeId},{UserId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                myexc = ex.ToString();
                return null;

            }
        }
        public IEnumerable<wisedetailVM> detailwise(string StartDate, string EndDate,int UserId)
        {

            try
            {
                var result = ctx.detailwise.FromSqlRaw($"ARevenueIndividualDetailReport {StartDate},{EndDate},{UserId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
