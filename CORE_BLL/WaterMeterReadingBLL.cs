﻿using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.Drawing;
using System.IO;

namespace CORE_BLL
{
    public class WaterMeterReadingBLL : IWaterMeterReading
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<WaterMeterReadingModel> Details(int? id)
        {
            var data = (from a in ctx.TblWaterMeterReading
                        join b in ctx.MstWaterConnection on a.WaterConnectionId equals b.WaterConnectionId
                        join c in ctx.TblLandOwnershipDetail on b.LandDetailId equals c.LandDetailId
                        select new WaterMeterReadingModel
                        {
                            WaterMeterReadingId = a.WaterMeterReadingId,
                            ConsumerNo = b.ConsumerNo,
                            WaterMeterNo = b.WaterMeterNo,
                            PreviousReading = a.PreviousReading,
                            PreviousReadingDate = a.PreviousReadingDate,
                        });
            return await data.FirstOrDefaultAsync();
        }

        public List<WaterMeterReadingModel> fetchReadinfById(int id)
        {
            var data = (from a in ctx.TblWaterMeterReading.Where(x => x.WaterConnectionId == id && x.IsRead == false && x.TransactionId == null)
                        join b in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterMeterType on a.WaterMeterTypeId equals c.WaterMeterTypeId
                        join d in ctx.MstWaterLineType on a.WaterLineTypeId equals d.WaterLineTypeId
                        select new WaterMeterReadingModel
                        {
                            WaterMeterReadingId = a.WaterMeterReadingId,
                            ReadingDate = a.ReadingDate,
                            Reading = a.Reading,
                            PreviousReading = a.PreviousReading,
                            NoOfUnit = a.NoOfUnit,
                            StandardConsumption =(int) a.StandardConsumption,
                            WaterConnectionName = b.WaterConnectionType,
                            WaterMeterTypeName = c.WaterMeterType,
                            WaterLineTypeName = d.WaterLineType,
                            SewerageName = (ctx.MstWaterConnection.Where(x => x.WaterConnectionId == a.WaterConnectionId).FirstOrDefault().SewerageConnection == true ? "Yes" : "No")

                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> fetchWaterConnectionByConsumerNo(string consumerNo, string waterMeterNo)
        {
            var data = (from a in ctx.MstWaterConnection.Where(x => x.ConsumerNo == consumerNo || x.WaterMeterNo == waterMeterNo)
                        join b in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on a.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstWaterMeterType on a.WaterMeterTypeId equals d.WaterMeterTypeId

                        select new WaterMeterReadingModel
                        {
                            WaterConnectionId = a.WaterConnectionId,
                            WaterMeterNo = a.WaterMeterNo,
                            ConsumerNo = a.ConsumerNo,
                            BillingAddress = a.BillingAddress,
                            StandardConsumption = (int)a.StandardConsumption,
                            SewerageName = (ctx.MstWaterConnection.Where(x => x.WaterConnectionId == a.WaterConnectionId).FirstOrDefault().SewerageConnection == true ? "Yes" : "No"),
                            IsActive = (ctx.MstWaterConnection.Where(x => x.WaterConnectionId == a.WaterConnectionId).FirstOrDefault().IsActive == true ? "Active" : "Inactive"),
                            WaterConnectionName = b.WaterConnectionType,
                            WaterLineTypeName = c.WaterLineType,
                            WaterMeterTypeName = d.WaterMeterType,
                            CheckStatus = a.IsActive
                            






                        });
            return data.ToList();
        }

        //Generate Demand Number
        public long GenerateDemand(WaterMeterReadingModel obj)
        {
            try
            {

                using TransactionScope s = new TransactionScope();
                var ReadingData = ctx.TblWaterMeterReading.Where(x => x.WaterMeterReadingId == obj.WaterMeterReadingId);
                var WaterConnectionId = ReadingData.FirstOrDefault().WaterConnectionId;
                var WaterconectionTypeid = ReadingData.FirstOrDefault().WaterConnectionTypeId;
                var ConnectionData = ctx.MstWaterConnection.Where(x => x.WaterConnectionId == WaterConnectionId);
                var landid = ConnectionData.FirstOrDefault().LandDetailId;
                var landownershipid = ConnectionData.FirstOrDefault().LandOwnershipId;
                var DataLandOwnership = ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == landownershipid);
                var taxpayerid = DataLandOwnership.FirstOrDefault().TaxPayerId;
                var CurrentReading = ReadingData.FirstOrDefault().Reading;
                var PreviousReading = ReadingData.FirstOrDefault().PreviousReading;
                var Consumption = ReadingData.FirstOrDefault().Consumption;
                var WaterConnectionTypeId = ReadingData.FirstOrDefault().WaterConnectionTypeId;
                var ReadingDate = ReadingData.FirstOrDefault().ReadingDate;
                var NextMonth = ReadingDate.AddMonths(1);
                var stdConsumption = ReadingData.FirstOrDefault().StandardConsumption;

                var firstDayOfMonth = new DateTime(NextMonth.Year, NextMonth.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                if (Consumption < 0)
                {

                    if (ReadingData.FirstOrDefault().WaterMeterTypeId == 1)
                    {
                        Consumption = 99999 - CurrentReading + PreviousReading;
                    }

                    if (ReadingData.FirstOrDefault().WaterMeterTypeId == 2)
                    {

                        Consumption = 999999 - PreviousReading + CurrentReading;
                    }

                    if (ReadingData.FirstOrDefault().WaterMeterTypeId == 3)
                    {

                        Consumption = 9999 - PreviousReading + CurrentReading;
                    }
                }
                if (Consumption < 20)
                {
                    Consumption =(int) stdConsumption;
                    //make minimium service charge 87

                }
                //********************************************************
                //********* FIRST SLAB**************************
                var SlBID1 = ctx.MstSlab.Where(x => x.TaxId == 14 && x.BuildingUnitUseTypeId == WaterConnectionTypeId && x.SlabEnd == 20);
                var slab1Id = SlBID1.FirstOrDefault().SlabId;
                var sRate1 = ctx.MstRate.Where(x => x.SlabId == slab1Id);
                var Rate1 = sRate1.FirstOrDefault().Rate;
                //********* FIRST SLAB END**************************
                //*********************SECOND SLAB START**********************************
                var SlBID2 = ctx.MstSlab.Where(x => x.TaxId == 14 && x.BuildingUnitUseTypeId == WaterConnectionTypeId && x.SlabEnd == 40);
                var slab2Id = SlBID2.FirstOrDefault().SlabId;
                var sRate2 = ctx.MstRate.Where(x => x.SlabId == slab2Id);
                var Rate2 = sRate2.FirstOrDefault().Rate;
                //*********************SECOND SLAB END********************************** //************************
                //*********************THIRD SLAB START**********************************
                var SlBID3 = ctx.MstSlab.Where(x => x.TaxId == 14 && x.BuildingUnitUseTypeId == WaterConnectionTypeId && x.SlabEnd == 99999);
                var slab3Id = SlBID3.FirstOrDefault().SlabId;
                var sRate3 = ctx.MstRate.Where(x => x.SlabId == slab3Id);
                var Rate3 = sRate3.FirstOrDefault().Rate;
                //*********************THIRD SLAB END********************************** //************************
                //********* IF CONSUMPTION IS 0**************************
                var SlBID4 = ctx.MstSlab.Where(x => x.TaxId == 53);// && x.BuildingUnitUseTypeId == WaterConnectionTypeId && x.SlabEnd == 20);
                var slab4Id = SlBID4.FirstOrDefault().SlabId;
                var sRate4 = ctx.MstRate.Where(x => x.SlabId == slab4Id);
                var Rate4 = sRate4.FirstOrDefault().Rate;
                //********* FIRST SLAB END**************************
                if (Consumption <= 0)
                {
                    var Amount = 0;
                    var SewerageAmount = 0;
                    obj.WaterTaxAmount = 0;
                    obj.SewerageAmount = SewerageAmount;
                    obj.TotalAmount = Amount + SewerageAmount;
                    obj.ServiceChargeAmount = Rate4;
                }
                else if (Consumption > 0 && Consumption <= 20)
                {
                    var Amount = Consumption * Rate1;
                    var SewerageAmount = Amount / 2;
                    obj.WaterTaxAmount = Amount;
                    obj.SewerageAmount = SewerageAmount;

                    obj.TotalAmount = Amount + SewerageAmount;
                }

                else if (Consumption > 20 && Consumption <= 40)
                {
                    var Amt1 = Rate1 * 20;
                    var Amt2 = (Rate2 * (Consumption - 20));
                    var Amount = Amt1 + Amt2;
                    var SewerageAmount = Amount / 2;
                    obj.WaterTaxAmount = Amount;
                    obj.SewerageAmount = SewerageAmount;
                    obj.TotalAmount = Amount + SewerageAmount;
                }

                else if (Consumption > 40)
                {
                    var Amt1 = Rate1 * 20;
                    var Amt2 = (Rate2 * 20);
                    var Amt3 = (Rate3 * (Consumption - 40));
                    var Amount = Amt1 + Amt2 + Amt3;
                    var SewerageAmount = Amount / 2;
                    obj.WaterTaxAmount = Amount;
                    obj.SewerageAmount = SewerageAmount;
                    obj.TotalAmount = Amount + SewerageAmount;
                }

                //********************************************************

                long transactionId;
                var tblTRNdetail = new TblTransactionDetail
                {
                    TransactionTypeId = 19,
                    WorkLevelId = 1,
                    TransactionValue = obj.TotalAmount,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblTransactionDetail.Add(tblTRNdetail);
                ctx.SaveChanges();
                transactionId = tblTRNdetail.TransactionId;
                obj.TransactionId = tblTRNdetail.TransactionId;
               
                int sq = ctx.TblDemandNo.Where(p => p.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                sq = sq + 1;

                var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                int cyr = ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(xx => xx.CalendarYearId);// make default check at startup

                obj.FinancialYearId = Convert.ToInt32(fyr);

                long demanId;
                var tblDM = new TblDemandNo
                {
                    DemandNo = ("TTDN/" + (DateTime.Now.Year) + "/" + sq),
                    Sl = (int)sq,
                    DemandYear = DateTime.Now.Year,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblDemandNo.Add(tblDM);
                ctx.SaveChanges();
                demanId = tblDM.DemandNoId;
                //******************IF water CONSUMPTION  IS<0******************
                if (Consumption <= 0)
                {
                    var entitySC = new TblDemand
                    {
                        TransactionId = transactionId,
                        DemandNoId = demanId,
                        TaxId = 53,
                        FinancialYearId = Convert.ToInt32(fyr),
                        CalendarYearId = cyr,
                        DemandAmount = obj.ServiceChargeAmount,
                        TotalAmount = obj.ServiceChargeAmount,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = obj.CreatedOn,
                        BillingDate = firstDayOfMonth
                        ,LandDetailId= landid,
                        TaxPayerId= taxpayerid,
                        //WaterMeterReadingId = obj.WaterMeterReadingId

                    };
                    ctx.TblDemand.Add(entitySC);
                }
                //******************IF water CONSUMPTION  IS<0  END ******************
                ctx.SaveChanges();
                var entityDM = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = demanId,
                    TaxId = 14,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = obj.WaterTaxAmount,
                    TotalAmount = obj.WaterTaxAmount,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate = firstDayOfMonth,
                    LandDetailId = landid,
                    TaxPayerId = taxpayerid,
                    WaterMeterReadingId = obj.WaterMeterReadingId

                };
                ctx.TblDemand.Add(entityDM);
                ctx.SaveChanges();
                var entityDMSW = new TblDemand
                {
                    TransactionId = transactionId,
                    DemandNoId = demanId,
                    TaxId = 15,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = obj.SewerageAmount,
                    TotalAmount = obj.SewerageAmount,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingDate = firstDayOfMonth ,
                    LandDetailId = landid,
                    TaxPayerId = taxpayerid,
                    WaterMeterReadingId = obj.WaterMeterReadingId
                };
                ctx.TblDemand.Add(entityDMSW);
                ctx.SaveChanges();
                //UPDATE READING TABLE
                var Data = ctx.TblWaterMeterReading.FirstOrDefault(u => u.WaterMeterReadingId == obj.WaterMeterReadingId);
                Data.TransactionId = obj.TransactionId;
                ctx.Entry(Data).State = EntityState.Modified;
                ctx.SaveChanges();


                s.Complete();
                s.Dispose();

                return demanId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IList<WaterMeterReadingModel> GetAll()
        {
            var data = (from a in ctx.TblWaterMeterReading
                        join b in ctx.MstWaterConnection on a.WaterConnectionId equals b.WaterConnectionId
                        join c in ctx.MstWaterMeterType on a.WaterMeterTypeId equals c.WaterMeterTypeId
                        join d in ctx.MstWaterLineType on a.WaterLineTypeId equals d.WaterLineTypeId
                        join e in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals e.WaterConnectionStatusId
                        select new WaterMeterReadingModel
                        {
                            WaterMeterReadingId = a.WaterMeterReadingId,
                            StandardConsumption = (int)a.StandardConsumption,
                            BillingAddress = a.BillingAddress,
                            Reading = a.Reading,
                            WaterMeter = c.WaterMeterType,
                            WaterLine = d.WaterLineType,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            WaterConnectionName = e.WaterConnectionStatus
                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> getWaterMeterReadingDetails(int zone,  DateTime ReadingDate)
        {
            long n = long.Parse(ReadingDate.AddMonths(-1).ToString("yyyyMM"));

            // var ReadingSheetData = ctx.ViewReadingSeet.Where(x=>x.ZoneId==zone && x.ReadingYm == n.ToString()).OrderBy(x=>x.ConsumerNo);
            var y = ReadingDate.AddMonths(-1).Year;
            var m = 0 + ReadingDate.AddMonths(-1).Month;

            var ReadingSheetData = (from r in ctx.TblWaterMeterReading.Where(r => r.IsRead == false && r.ZoneId == zone && r.ReadingDate.Year == y && r.ReadingDate.Month == m)
                            // c.TransactionId == null && .Where(x=> x.ReadingDate.Month== month || x.MaxReadingDate.Value.Year == year && x.MaxReadingDate.Value.Month == month)
                        join c in ctx.MstWaterConnection on r.WaterConnectionId equals c.WaterConnectionId
                        join z in ctx.MstZone on c.ZoneId equals z.ZoneId
                        where c.IsActive==true
                        orderby c.ConsumerNo ascending
                        select new WaterMeterReadingModel
                        {
                            WaterMeterReadingId = r.WaterMeterReadingId,
                            ConsumerNo = c.ConsumerNo,
                            WaterMeterNo = c.WaterMeterNo,
                            PreviousReading = r.Reading,
                            PreviousReadingDate = r.ReadingDate,
                            WaterConnectionId = r.WaterConnectionId,
                            WaterConnectionStatusId = r.WaterConnectionStatusId,
                            WaterConnectionTypeId = r.WaterConnectionTypeId,
                            WaterLineTypeId = r.WaterLineTypeId,
                            WaterMeterTypeId = r.WaterMeterTypeId,
                            BillingAddress = r.BillingAddress,
                            NoOfUnit = c.NoOfUnits,
                            PrimaryMobileNo = r.PrimaryMobileNo,
                            ZoneReader = z.ZoneReader,
                            zoneId = r.ZoneId,
                            TransactionId = r.TransactionId,
                            StandardConsumption = (int)c.StandardConsumption
                        }).ToList();




            return ReadingSheetData;
        }
        public List<WaterMeterReadingModel> CheckDuplicateReadings(int WaterConnectionId, DateTime ReadingDate)
        {

            var data = (from c in ctx.TblWaterMeterReading.Where(x => x.WaterConnectionId == WaterConnectionId && x.ReadingDate.Month == ReadingDate.Month && x.ReadingDate.Year == ReadingDate.Year)
                        select new WaterMeterReadingModel
                        {

                            WaterMeterReadingId = c.WaterMeterReadingId,
                            ReadingDate = c.ReadingDate,

                        });
            return data.ToList();
        }

        public int Save(WaterMeterReadingModel obj)
        {
            throw new NotImplementedException();
        }

        public long SaveWaterMeterReading(WaterMeterReadingModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                var wmr = ctx.TblWaterMeterReading.Single(r=>r.WaterMeterReadingId==obj.WaterMeterReadingId);
                var data = ctx.MstWaterConnection.Where(x => x.WaterConnectionId == obj.WaterConnectionId);
                obj.SolidWaste = data.FirstOrDefault().SolidWaste;
                obj.Sewerage = data.FirstOrDefault().SewerageConnection;
                obj.IsPermanentConnection = (bool)data.FirstOrDefault().IsPermanentConnection;
                obj.PrimaryMobileNo = data.FirstOrDefault().PrimaryMobileNo;
                obj.SecondaryMobileNo = data.FirstOrDefault().SecondaryMobileNo;
                obj.StandardConsumption = data.FirstOrDefault().StandardConsumption;
                obj.WaterConnectionStatusId = data.FirstOrDefault().WaterConnectionStatusId;
                obj.WaterConnectionTypeId = data.FirstOrDefault().WaterConnectionTypeId;
                obj.WaterLineTypeId = data.FirstOrDefault().WaterLineTypeId;
                obj.WaterMeterTypeId = data.FirstOrDefault().WaterMeterTypeId;
                obj.zoneId = data.FirstOrDefault().ZoneId;
                obj.NoOfUnit = data.FirstOrDefault().NoOfUnits;
                obj.BillingAddress = data.FirstOrDefault().BillingAddress;
                //  obj.zoneId = data.FirstOrDefault().ZoneId;

                long ipk;
                var entity = new TblWaterMeterReading
                {
                    // WaterMeterReadingId = obj.WaterMeterReadingId,
                    WaterConnectionId = obj.WaterConnectionId,
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    Reading = obj.Reading,
                    PreviousReading = wmr.Reading,
                    PreviousReadingDate = wmr.ReadingDate,
                    ReadBy = obj.ReadBy,
                    ReadingDate = obj.ReadingDate,
                    NoOfUnit = obj.NoOfUnit,
                    Consumption = obj.Consumption,
                    IsPermanentConnection = obj.IsPermanentConnection,
                    Sewerage = obj.Sewerage,
                    SolidWaste = obj.SolidWaste,
                    BillingAddress = obj.BillingAddress,
                    PrimaryMobileNo = obj.PrimaryMobileNo,
                    TransactionId = obj.TransactionId,
                    StandardConsumption =(int) obj.StandardConsumption,
                    ZoneId = obj.zoneId,
                    CreatedBy=obj.CreatedBy,
                    CreatedOn=DateTime.Now
                };
                ctx.TblWaterMeterReading.Add(entity);
                ctx.SaveChanges();
                ipk = entity.WaterMeterReadingId;

                var DataR = ctx.TblWaterMeterReading.FirstOrDefault(u => u.WaterMeterReadingId == obj.WaterMeterReadingId);
                DataR.IsRead = true;
                ctx.Entry(DataR).State = EntityState.Modified;
                ctx.SaveChanges();

                var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == obj.WaterConnectionId);
                Data.MaxReadingDate = obj.ReadingDate;
                ctx.Entry(Data).State = EntityState.Modified;
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

        public int Update(WaterMeterReadingModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblWaterMeterReading.FirstOrDefault(u => u.WaterMeterReadingId == obj.WaterMeterReadingId);
                    Data.ReadingDate = obj.ReadingDate; Data.PreviousReadingDate = obj.PreviousReadingDate;
                    Data.PreviousReading = obj.PreviousReading; Data.Reading = obj.Reading;
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

        public List<WaterMeterReadingModel> GenerateZoneWiseBill(int zone, int year, int month)
        {
            var data = (from a in ctx.TblWaterMeterReading.Where(b => b.TransactionId == null && b.ZoneId == zone && b.ReadingDate.Year == year && b.ReadingDate.Month == month)
                        join b in ctx.MstWaterConnection on a.WaterConnectionId equals b.WaterConnectionId
                        join c in ctx.MstZone on a.ZoneId equals c.ZoneId
                        select new WaterMeterReadingModel
                        {
                            BillingAddress = a.BillingAddress,
                            WaterMeterNo = b.WaterMeterNo,
                            ConsumerNo = b.ConsumerNo,
                            ZoneReader = c.ZoneReader,
                            ZoneName = c.ZoneName

                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> getReadingInfo(int id)
        {
            var data = (from a in ctx.TblWaterMeterReading.Where(x => x.WaterMeterReadingId == id)
                        join b in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on a.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals d.WaterConnectionStatusId
                        join e in ctx.MstWaterMeterType on a.WaterMeterTypeId equals e.WaterMeterTypeId
                        join f in ctx.MstZone on a.ZoneId equals f.ZoneId
                        join g in ctx.MstWaterConnection on a.WaterConnectionId equals g.WaterConnectionId
                        select new WaterMeterReadingModel
                        {
                            WaterMeterReadingId = a.WaterMeterReadingId,
                            WaterConnectionName = b.WaterConnectionType,
                            WaterLineTypeName = c.WaterLineType,
                            WaterConnectionStatusName = d.WaterConnectionStatus,
                            WaterMeterTypeName = e.WaterMeterType,
                            ZoneName = f.ZoneName,
                            ZoneReader = f.ZoneReader,
                            PreviousReading = a.PreviousReading,
                            PreviousReadingDate = a.PreviousReadingDate,
                            ConsumerNo = g.ConsumerNo,
                            WaterMeterNo = g.WaterMeterNo,
                            NoOfUnit = a.NoOfUnit,
                            ReadBy = a.ReadBy,
                            BillingAddress = a.BillingAddress,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            Consumption = a.Consumption,
                            Reading = a.Reading,
                            ReadingDate = a.ReadingDate,
                            Sewerage = a.Sewerage
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
        public List<WaterMeterReadingModel> getBillingInfo(string consumerno, int year, int month)
        {

            //var dn = ctx.MstWaterConnection.Where(d => d.ConsumerNo == consumerno).Max(x => x.ConsumerNo);
            var data = (from a in ctx.TblWaterMeterReading.Where(a => a.ReadingDate.Year == year && a.ReadingDate.Month == month)
                        join b in ctx.MstZone on a.ZoneId equals b.ZoneId
                        join c in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals c.WaterConnectionStatusId
                        join d in ctx.MstWaterConnection on a.WaterConnectionId equals d.WaterConnectionId                
                        join e in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals e.WaterConnectionTypeId
                        join f in ctx.TblDemand on a.TransactionId equals f.TransactionId
                        join g in ctx.TblDemandNo on f.DemandNoId equals g.DemandNoId into DN
                        from g in DN.DefaultIfEmpty()
                        let qr = GenerateQr(consumerno)
                        let bd = new DateTime(a.ReadingDate.AddMonths(1).Year, a.ReadingDate.AddMonths(1).Month, 1)
                        where (d.ConsumerNo == consumerno)
                        select new WaterMeterReadingModel
                        {
                            BillingAddress = a.BillingAddress,
                            ZoneName = b.ZoneName,
                            WaterConnectionStatusName = c.WaterConnectionStatus,
                            ConsumerNo = d.ConsumerNo,
                            WaterConnectionName = e.WaterConnectionType,
                            WaterMeterNo = d.WaterMeterNo,
                            Reading = a.Reading,
                            ReadingDate = a.ReadingDate,
                            PreviousReading = a.PreviousReading,
                            PreviousReadingDate = a.PreviousReadingDate,
                            NoOfUnit = a.NoOfUnit,
                            Consumption = a.Consumption,
                            CreatedOn = f.CreatedOn,
                            PaymentStatus = (f.IsPaymentMade == false ? "N" : "P"),
                            BillFor = a.ReadingDate,
                            DemandNo = (g.DemandNo == null ? "-" : g.DemandNo),
                            qrImage = qr,
                            TransactionId = f.TransactionId,
                            BillDate = new DateTime(a.ReadingDate.AddMonths(1).Year, a.ReadingDate.AddMonths(1).Month, 1),
                            Duedate = bd.AddMonths(1).AddDays(-1),
                            StandardConsumption =(int) a.StandardConsumption

                        });
            return data.ToList();
        }

        public List<SlabVM> getSlabInfo(int id)
        {
            var data = (from x in ctx.MstSlab.Where(x => x.TaxId == 14)
                        join z in ctx.MstRate on x.SlabId equals z.SlabId
                        select new SlabVM
                        {
                            SlabName = x.SlabName,
                            SlabEnd = x.SlabEnd,
                            SlabStart = x.SlabStart,
                            Rate = z.Rate

                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> getServiceChargesInfo(int id)
        {
            var data = (from x in ctx.MstRate.Where(x => x.TaxId == 53)
                        select new WaterMeterReadingModel
                        {
                            ServiceChargeAmount = x.Rate
                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> getUtilityChargesInfo(int id, string consumerno,int CalendarYear)
        {
            //OUTSTANDING CALCULATION
            var cy = ctx.MstCalendarYear.Where(c => c.CalendarYear == CalendarYear.ToString());
            var dataReading = ctx.TblWaterMeterReading.Where(a => a.TransactionId == id);

            var PRDate = dataReading.FirstOrDefault().ReadingDate;
            var WaterReading = (
                   from x in ctx.MstWaterConnection.Where(x => x.ConsumerNo == consumerno)
                   join y in ctx.TblWaterMeterReading on x.WaterConnectionId equals y.WaterConnectionId
                   join z in ctx.TblDemand on y.TransactionId equals z.TransactionId
                   where (z.IsPaymentMade == false && y.TransactionId != id && y.ReadingDate < PRDate)

                   select y.TransactionId).ToList();
            //PENALTY
            var dataTaxPeriod = ctx.MstTaxPeriod.Where(x => x.TransactionTypeId == 19 && x.CalendarYearId== cy.FirstOrDefault().CalendarYearId);
            var PenaltyPercentage = dataTaxPeriod.FirstOrDefault().PenaltyOrRate;
            var dataDemand = ctx.TblDemand.Where(y => WaterReading.Contains(y.TransactionId)).Select(y => y.TransactionId).Distinct();
            // var dataDemandBD = ctx.TblDemand.Where(y => WaterReading.Contains(y.TransactionId));

            var md = 0; /*var pm = 0;*/
            var totalMonthsForPenalty = 0; decimal OutstandingPenaltyAmt = 0;
            var currentYrMonth = 0; var billingYrMonth = 0;
            foreach (var items in dataDemand)
            {
                //long trid = items;
                var bd = ctx.TblDemand.Where(bd => bd.TransactionId == items).ToList().Distinct();
                currentYrMonth = Convert.ToInt32((DateTime.Now.Year).ToString() + (DateTime.Now.ToString("MM")).ToString());
                billingYrMonth = Convert.ToInt32(bd.FirstOrDefault().BillingDate.Year.ToString() + bd.FirstOrDefault().BillingDate.ToString("MM"));
                //md = (currentYrMonth - billingYrMonth);
                if ((currentYrMonth - billingYrMonth) < 0)
                {
                    md = 0;

                }
                else
                { 
                    if ((currentYrMonth - billingYrMonth) < 12)
                    {
                        md = (currentYrMonth - billingYrMonth);
                    }
                    else if ((currentYrMonth - billingYrMonth) == 89)
                    {
                        md = 1;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 90)
                    {
                        md = 2;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 91)
                    {
                        md = 3;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 92)
                    {
                        md = 4;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 93)
                    {
                        md = 5;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 94)
                    {
                        md = 6;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 95)
                    {
                        md = 7;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 96)
                    {
                        md = 8;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 97)
                    {
                        md = 9;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 98)
                    {
                        md = 10;

                    }
                    else if ((currentYrMonth - billingYrMonth) == 99)
                    {
                        md = 11;

                    }                    
                    else
                    {
                        md = 12;

                    }
                }
               
                //totalMonthsForPenalty = totalMonthsForPenalty + md;
                var OutStandingAmount= ctx.TblDemand.Where(z =>z.IsPaymentMade==false && z.TransactionId==items).Sum(z1 => z1.TotalAmount);
                OutstandingPenaltyAmt = OutstandingPenaltyAmt + ((PenaltyPercentage / (100 * 12)) * OutStandingAmount * md);
            }
            // var CalendarYrId = dataDemandBD.FirstOrDefault().CalendarYearId;
            //var dataCalendarYear = ctx.MstCalendarYear.Where(a=> a.CalendarYearId == CalendarYrId);
            // var CalYrEndDate = dataCalendarYear.FirstOrDefault().EndDate;
            //PENALTY END
            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == id)
                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                        let TotalBillForTheMonth = ctx.TblDemand.Where(y => y.TransactionId == x.TransactionId).Sum(x => x.TotalAmount)
                        let OutStandingAmount = ctx.TblDemand.Where(z => WaterReading.Contains(z.TransactionId)).Sum(z1 => z1.TotalAmount)
                        let PenaltyAmount =OutstandingPenaltyAmt //(PenaltyPercentage / (100*12)) * OutStandingAmount * totalMonthsForPenalty
                        let NetPayableAmount = (TotalBillForTheMonth + OutStandingAmount + PenaltyAmount)

                        select new WaterMeterReadingModel
                        {
                            WaterBillForTheMonth = (x.TotalAmount == 0 ? 0 : x.TotalAmount),
                            SewerageAmount = (x.TotalAmount == 0 ? 0 : x.TotalAmount),
                            TotalBillForTheMonth = TotalBillForTheMonth,
                            OutStandingAmount = OutStandingAmount,
                            PenaltyAmount = PenaltyAmount,
                            NetPayableAmount = NetPayableAmount
                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> getZoneWiseBillingInfo(int zone, int year/*, int month*/)
        {
            var data = (from a in ctx.TblWaterMeterReading.Where(a => a.ZoneId == zone && a.ReadingDate.Year == year /*&&*/ /*a.ReadingDate.Month == month*/)
                        join b in ctx.MstZone on a.ZoneId equals b.ZoneId
                        join c in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals c.WaterConnectionStatusId
                        join d in ctx.MstWaterConnection on a.WaterConnectionId equals d.WaterConnectionId
                        join e in ctx.MstWaterConnectionType on a.WaterLineTypeId equals e.WaterConnectionTypeId
                        join f in ctx.TblDemand on a.TransactionId equals f.TransactionId
                        join g in ctx.TblDemandNo on f.DemandNoId equals g.DemandNoId into DN
                        from g in DN.DefaultIfEmpty()
                        let bd = new DateTime(a.ReadingDate.AddMonths(1).Year, a.ReadingDate.AddMonths(1).Month, 1)

                        select new WaterMeterReadingModel
                        {
                            BillingAddress = a.BillingAddress,
                            ZoneName = b.ZoneName,
                            WaterConnectionStatusName = c.WaterConnectionStatus,
                            ConsumerNo = d.ConsumerNo,
                            WaterConnectionName = e.WaterConnectionType,
                            WaterMeterNo = d.WaterMeterNo,
                            Reading = a.Reading,
                            ReadingDate = a.ReadingDate,
                            PreviousReading = a.PreviousReading,
                            PreviousReadingDate = a.PreviousReadingDate,
                            NoOfUnit = a.NoOfUnit,
                            Consumption = a.Consumption,
                            CreatedOn = f.CreatedOn,
                            PaymentStatus = (f.IsPaymentMade == false ? "N" : "P"),
                            BillFor = a.ReadingDate,
                            DemandNo = (g.DemandNo == null ? "-" : g.DemandNo),
                            TransactionId = f.TransactionId,
                            BillDate = new DateTime(a.ReadingDate.AddMonths(1).Year, a.ReadingDate.AddMonths(1).Month, 1),
                            Duedate = bd.AddMonths(1).AddDays(-1)

                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> getMeterReadingDetails(string consumerno, int year, int month)
        {
            var data = (from a in ctx.TblWaterMeterReading.Where(a => a.ReadingDate.Year == year && a.ReadingDate.Month == month)
                        join b in ctx.MstZone on a.ZoneId equals b.ZoneId
                        join c in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals c.WaterConnectionStatusId
                        join d in ctx.MstWaterConnection on a.WaterConnectionId equals d.WaterConnectionId
                        join e in ctx.MstWaterMeterType on a.WaterMeterTypeId equals e.WaterMeterTypeId
                        join f in ctx.MstWaterLineType on a.WaterLineTypeId equals f.WaterLineTypeId
                        where (d.ConsumerNo == consumerno)
                        select new WaterMeterReadingModel
                        {
                            WaterMeterReadingId = a.WaterMeterReadingId,
                            WaterConnectionStatusName = c.WaterConnectionStatus,
                            WaterMeterTypeName = e.WaterMeterType,
                            WaterLineTypeName = f.WaterLineType,
                            StandardConsumption = (int)a.StandardConsumption,
                            BillingAddress = a.BillingAddress,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            PreviousReadingDate = a.PreviousReadingDate,
                            ReadingDate = a.ReadingDate,
                            Reading = a.Reading,
                            PreviousReading = a.PreviousReading
                            //TransactionId = a.TransactionId
                        });
            return data.ToList();
        }

        //for Water Bill Edit
        public List<WaterMeterReadingModel> fetchWaterBillEdit(string ConsumerNo, int Year, int Month)
        {
            var data = (from a in ctx.MstWaterConnection.Where(x => string.IsNullOrEmpty(ConsumerNo) || x.ConsumerNo == ConsumerNo)
                        join b in ctx.TblWaterMeterReading on a.WaterConnectionId equals b.WaterConnectionId
                        join d in ctx.TblLandOwnershipDetail on a.LandOwnershipId equals d.LandOwnershipId
                        join c in ctx.MstLandDetail on d.LandDetailId equals c.LandDetailId
                        join e in ctx.MstTaxPayerProfile on d.TaxPayerId equals e.TaxPayerId
                        join f in ctx.MstWaterConnectionType on b.WaterConnectionTypeId equals f.WaterConnectionTypeId
                        where (b.ReadingDate.Year == Year && b.ReadingDate.Month == Month)
                        select new WaterMeterReadingModel
                        {
                            ConsumerNo = a.ConsumerNo,
                            WaterMeterReadingId = b.WaterMeterReadingId,
                            TaxPayerName = e.FirstName + " " + ((e.MiddleName == null || e.MiddleName.Trim() == string.Empty) ? string.Empty : (e.MiddleName + " ")) + ((e.LastName == null || e.LastName.Trim() == string.Empty) ? string.Empty : (e.LastName + " ")),
                            WaterMeterNo = a.WaterMeterNo,
                            PreviousReading = b.PreviousReading,
                            bAddress = b.BillingAddress,
                            WaterConnectionTypeId = b.WaterConnectionTypeId,
                            NoOfUnit = b.NoOfUnit,
                            Reading = b.Reading,
                            ReadingDate = b.ReadingDate,
                            Remarks = b.Remarks,
                            WaterConnectionType = f.WaterConnectionType,
                            StandardConsumption =(int) b.StandardConsumption,
                            TransactionId = b.TransactionId   


                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> checkPaymentStatusForWaterBillEdit(int WaterMeterReadingId)
        {
            var data = (from a in ctx.TblDemand.Where(x => x.WaterMeterReadingId == WaterMeterReadingId && x.IsPaymentMade == false)
                        
                        select new WaterMeterReadingModel
                        {
                            TransactionId = a.TransactionId,

                        }) ;
            return data.ToList();
        }

        //for Water Bill Edit
        public int WaterBillEditupdate(WaterMeterReadingModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    // update
                    var ReadingData = ctx.TblWaterMeterReading.Where(x => x.WaterMeterReadingId == obj.WaterMeterReadingId);
                    var WaterConnectionId = ReadingData.FirstOrDefault().WaterConnectionId;
                    //var WaterconectionTypeid = obj.WaterConnectionTypeId;// ReadingData.FirstOrDefault().WaterConnectionTypeId;
                    var ConnectionData = ctx.MstWaterConnection.Where(x => x.WaterConnectionId == WaterConnectionId);
                    //var landid = ConnectionData.FirstOrDefault().LandDetailId;
                    //var landownershipid = ConnectionData.FirstOrDefault().LandOwnershipId;
                    //var DataLandOwnership = ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == landownershipid);
                    //var taxpayerid = DataLandOwnership.FirstOrDefault().TaxPayerId;
                    var CurrentReading = obj.Reading;// ReadingData.FirstOrDefault().Reading;
                    var PreviousReading = ReadingData.FirstOrDefault().PreviousReading;
                    var Consumption = obj.Reading - PreviousReading;// ReadingData.FirstOrDefault().Consumption;
                   // var WaterConnectionTypeId = ReadingData.FirstOrDefault().WaterConnectionTypeId;
                    var ReadingDate = ReadingData.FirstOrDefault().ReadingDate;
                    var NextMonth = ReadingDate.AddMonths(1);
                  //  var stdConsumption = ReadingData.FirstOrDefault().StandardConsumption;
                    var TransactionId = ReadingData.FirstOrDefault().TransactionId;

                    var firstDayOfMonth = new DateTime(NextMonth.Year, NextMonth.Month, 1);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                    if (Consumption < 0)
                    {

                        if (ReadingData.FirstOrDefault().WaterMeterTypeId == 1)
                        {
                            Consumption = 99999 - CurrentReading + PreviousReading;
                        }

                        if (ReadingData.FirstOrDefault().WaterMeterTypeId == 2)
                        {

                            Consumption = 999999 - PreviousReading + CurrentReading;
                        }

                        if (ReadingData.FirstOrDefault().WaterMeterTypeId == 3)
                        {

                            Consumption = 9999 - PreviousReading + CurrentReading;
                        }
                    }

                    var Data = ctx.TblWaterMeterReading.FirstOrDefault(u => u.WaterMeterReadingId == obj.WaterMeterReadingId);
                    Data.WaterConnectionTypeId = obj.WaterConnectionTypeId;
                    Data.NoOfUnit = obj.NoOfUnit;
                    Data.Reading = obj.Reading;
                    Data.Consumption = Consumption;
                    Data.StandardConsumption = obj.StandardConsumption;
                    Data.Remarks = obj.Remarks;
                    ctx.SaveChanges();

                    var Data1 = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == WaterConnectionId);
                    Data1.WaterConnectionTypeId = obj.WaterConnectionTypeId;
                    Data1.StandardConsumption = obj.StandardConsumption;
                    ctx.SaveChanges();

                    if (Consumption < 20)
                    {
                        Consumption = obj.StandardConsumption;
                        //make minimium service charge 87

                    }

                    //********************************************************
                    //********* FIRST SLAB**************************
                    var SlBID1 = ctx.MstSlab.Where(x => x.TaxId == 14 && x.BuildingUnitUseTypeId == obj.WaterConnectionTypeId && x.SlabEnd == 20);
                    var slab1Id = SlBID1.FirstOrDefault().SlabId;
                    var sRate1 = ctx.MstRate.Where(x => x.SlabId == slab1Id);
                    var Rate1 = sRate1.FirstOrDefault().Rate;
                    //********* FIRST SLAB END**************************
                    //*********************SECOND SLAB START**********************************
                    var SlBID2 = ctx.MstSlab.Where(x => x.TaxId == 14 && x.BuildingUnitUseTypeId == obj.WaterConnectionTypeId && x.SlabEnd == 40);
                    var slab2Id = SlBID2.FirstOrDefault().SlabId;
                    var sRate2 = ctx.MstRate.Where(x => x.SlabId == slab2Id);
                    var Rate2 = sRate2.FirstOrDefault().Rate;
                    //*********************SECOND SLAB END********************************** //************************
                    //*********************THIRD SLAB START**********************************
                    var SlBID3 = ctx.MstSlab.Where(x => x.TaxId == 14 && x.BuildingUnitUseTypeId == obj.WaterConnectionTypeId && x.SlabEnd == 99999);
                    var slab3Id = SlBID3.FirstOrDefault().SlabId;
                    var sRate3 = ctx.MstRate.Where(x => x.SlabId == slab3Id);
                    var Rate3 = sRate3.FirstOrDefault().Rate;
                    //*********************THIRD SLAB END********************************** //************************
                    //********* IF CONSUMPTION IS 0**************************
                    var SlBID4 = ctx.MstSlab.Where(x => x.TaxId == 53);// && x.BuildingUnitUseTypeId == WaterConnectionTypeId && x.SlabEnd == 20);
                    var slab4Id = SlBID4.FirstOrDefault().SlabId;
                    var sRate4 = ctx.MstRate.Where(x => x.SlabId == slab4Id);
                    var Rate4 = sRate4.FirstOrDefault().Rate;
                    //********* FIRST SLAB END**************************
                    if (Consumption <= 0)
                    {
                        var Amount = 0;
                        var SewerageAmount = 0;
                        obj.WaterTaxAmount = 0;
                        obj.SewerageAmount = SewerageAmount;
                        obj.TotalAmount = Amount + SewerageAmount;
                        obj.ServiceChargeAmount = Rate4;
                    }
                    else if (Consumption > 0 && Consumption <= 20)
                    {
                        var Amount = Consumption * Rate1;
                        var SewerageAmount = Amount / 2;
                        obj.WaterTaxAmount = Amount;
                        obj.SewerageAmount = SewerageAmount;

                        obj.TotalAmount = Amount + SewerageAmount;
                    }

                    else if (Consumption > 20 && Consumption <= 40)
                    {
                        var Amt1 = Rate1 * 20;
                        var Amt2 = (Rate2 * (Consumption - 20));
                        var Amount = Amt1 + Amt2;
                        var SewerageAmount = Amount / 2;
                        obj.WaterTaxAmount = Amount;
                        obj.SewerageAmount = SewerageAmount;
                        obj.TotalAmount = Amount + SewerageAmount;
                    }

                    else if (Consumption > 40)
                    {
                        var Amt1 = Rate1 * 20;
                        var Amt2 = (Rate2 * 20);
                        var Amt3 = (Rate3 * (Consumption - 40));
                        var Amount = Amt1 + Amt2 + Amt3;
                        var SewerageAmount = Amount / 2;
                        obj.WaterTaxAmount = Amount;
                        obj.SewerageAmount = SewerageAmount;
                        obj.TotalAmount = Amount + SewerageAmount;
                    }

                    //********************************************************

                    //long transactionId;

                    var DataTrnUpdate = ctx.TblTransactionDetail.FirstOrDefault(u => u.TransactionId == TransactionId);
                    DataTrnUpdate.TransactionValue = obj.TotalAmount;
                    DataTrnUpdate.ModifiedBy = obj.ModifiedBy;
                    DataTrnUpdate.ModifiedOn = DateTime.Now;
                    //ctx.Entry(DataTrnUpdate).State = EntityState.Modified;
                    ctx.SaveChanges();

                  
                    obj.TransactionId = TransactionId;
                    //int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                    //sq = sq == null ? 0 : ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                    //sq = sq + 1;

                    //var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                    //int cyr = ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(xx => xx.CalendarYearId);// make default check at startup

                    //obj.FinancialYearId = Convert.ToInt32(fyr);
                    if (Consumption <= 0)
                    {
                        var DataDemandUpdate = ctx.TblDemand.FirstOrDefault(u => u.TaxId == 53 && u.TransactionId == TransactionId);
                        DataDemandUpdate.DemandAmount = obj.ServiceChargeAmount;
                        DataDemandUpdate.TotalAmount = obj.ServiceChargeAmount;
                        DataDemandUpdate.ModifiedBy = obj.CreatedBy;
                        DataDemandUpdate.ModifiedOn = DateTime.Now;
                        ctx.Entry(DataDemandUpdate).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    var DataDemandUpdateWT = ctx.TblDemand.FirstOrDefault(u => u.TaxId == 14 && u.TransactionId == TransactionId);
                    DataDemandUpdateWT.DemandAmount = obj.WaterTaxAmount;
                    DataDemandUpdateWT.TotalAmount = obj.WaterTaxAmount;
                    DataDemandUpdateWT.ModifiedBy = obj.CreatedBy;
                    DataDemandUpdateWT.ModifiedOn = DateTime.Now;
                    ctx.Entry(DataDemandUpdateWT).State = EntityState.Modified;
                    ctx.SaveChanges(); 

                    var DataDemandUpdateST = ctx.TblDemand.FirstOrDefault(u => u.TaxId == 15 && u.TransactionId == TransactionId);
                    DataDemandUpdateST.DemandAmount = obj.SewerageAmount;
                    DataDemandUpdateST.TotalAmount = obj.SewerageAmount;
                    DataDemandUpdateST.ModifiedBy = obj.CreatedBy;
                    DataDemandUpdateST.ModifiedOn = DateTime.Now;
                    ctx.Entry(DataDemandUpdateST).State = EntityState.Modified;
                    ctx.SaveChanges();

                    //long demanId;
                  
                    //******************IF water CONSUMPTION  IS<0******************
                    
                    //******************IF water CONSUMPTION  IS<0  END ******************
                  

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

        public List<WaterMeterReadingModel> GetWaterPaymentDetails(string ConsumerNo, int Year)
        {
            var data = (from a in ctx.MstWaterConnection.Where(x => x.ConsumerNo == ConsumerNo)
                        join b in ctx.TblWaterMeterReading on a.WaterConnectionId equals b.WaterConnectionId
                        join c in ctx.TblLedger on b.TransactionId equals c.TransactionId
                        join u in ctx.AspNetUsers on c.CreatedBy equals u.UserId
                        where ( b.ReadingDate.Year == Year && b.TransactionId !=null)
                       
                        let qr = GenerateQr(ConsumerNo)
                        select new WaterMeterReadingModel
                        {
                            ConsumerNo = a.ConsumerNo,
                            WaterMeterNo = a.WaterMeterNo,
                            Year = b.ReadingDate.Year,
                            Month = b.ReadingDate.ToString("MMMM"),
                            TransactionId = b.TransactionId,
                            qrImage = qr,
                            IsPaymentMade = true,
                            UserName=(u.FirstName + " " +u.MiddleName+ " " + u.LastName),
                        });
            return data.Distinct().ToList();
        }

        public List<WaterMeterReadingModel> GetWaterPaymentInfo(int TransactionId)
        {
            var data = (from a in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                        join b in ctx.TblDemandNo on a.DemandNoId equals b.DemandNoId
                        join c in ctx.TblLedger on a.DemandId equals c.DemandId
                        join d in ctx.TblReceipt on c.ReceiptId equals d.ReceiptId
                        select new WaterMeterReadingModel
                        {
                            BillingDate = a.BillingDate.ToString("dd/MM/yyyy"),
                            DemandNo = b.DemandNo,
                            PaymentDate = c.PaymentDate.ToString("dd/MM/yyyy"),
                            ReceiptNo = d.ReceiptNo
                        }); ;
            return data.ToList();
        }

        public List<WaterMeterReadingModel> FetchWaterPaymentInfo(int TransactionId)
        {
          
                      

                            var data = (from a in ctx.TblLedger.Where(x => x.TransactionId == TransactionId)
                        join b in ctx.MstTaxMaster on a.TaxId equals b.TaxId
                        join c in ctx.TblDemand on a.DemandId equals c.DemandId
                                        join u in ctx.AspNetUsers on c.CreatedBy equals u.UserId
                                        let AmountPayable = ctx.TblLedger.Where(y => y.TransactionId == a.TransactionId).Sum(x => x.TotalAmount)
                        select new WaterMeterReadingModel
                        {
                            TotalAmount = a.TotalAmount,
                            DemandAmount = c.DemandAmount,
                            ExemptionAmount = (decimal)c.ExemptionAmount,
                            TaxName = b.TaxName,
                            AmountPayable = AmountPayable,
                            UserName = (u.FirstName + " " + u.MiddleName + " " + u.LastName),

                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> GetWaterMeterPayment(int id)
        {



            var data = (from a in ctx.TblWaterMeterReading.Where(x => x.WaterMeterReadingId == id)
                        let p = ctx.TblDemand.Where(y => y.WaterMeterReadingId == a.WaterMeterReadingId).Any(x => x.IsPaymentMade)
                        select new WaterMeterReadingModel
                        {
                            IsPaymentMade = p

                        });
            return data.ToList();
        }


        //************* Check ConsumerNo Sequence *************
        public List<WaterMeterReadingModel> SearchCnoSequence(int zone)
        {
            var data = (from x in ctx.MstWaterConnection.Where(x => x.ZoneId == zone)
                        join a in ctx.MstZone on x.ZoneId equals a.ZoneId
                        orderby x.ConsumerNo descending
            select new WaterMeterReadingModel
                        {
                            ConsumerNo = x.ConsumerNo,
                            WaterMeterNo = x.WaterMeterNo,
                            BillingAddress = x.BillingAddress,
                            //ZoneName = a.ZoneName

                        });
            return data.ToList();
        }


        public IList<TranWaterConnectionModel> fetchWaterDetails(string ConsumerNo, int Year,int sMonth,int eMonth)
        {
            try
            {
                var data = (from a in ctx.MstWaterConnection.Where(a => a.ConsumerNo == ConsumerNo)
                            join rd in ctx.TblWaterMeterReading on a.WaterConnectionId equals rd.WaterConnectionId
                            join t in ctx.TblTransactionDetail on rd.TransactionId equals t.TransactionId
                            join c in ctx.TblLedger on t.TransactionId equals c.TransactionId
                            join p in ctx.TblPaymentLeger on c.ReceiptId equals p.ReceiptId
                            join r in ctx.TblReceipt on p.ReceiptId equals r.ReceiptId
                            join tx in ctx.MstTaxMaster on c.TaxId equals tx.TaxId

                            where 
                            (rd.ReadingDate.Year == Year && rd.ReadingDate.Month >= sMonth && rd.ReadingDate.Month <= eMonth

                            )
                            orderby rd.ReadingDate.Year, rd.ReadingDate.Month

                            select new TranWaterConnectionModel
                            {
                                RecepitId = c.ReceiptId,
                                RMonth = rd.ReadingDate.Month,
                                TaxName = tx.TaxName,
                                ReceiptNo = r.ReceiptNo,
                                BillingAddress = a.BillingAddress,
                                ConnectionDate = c.PaymentDate,
                                Totalamount = c.TotalAmount + c.PenaltyAmount,
                                Amount = c.PenaltyAmount,
                                ConsumerNo = a.ConsumerNo,
                                WaterMeterNo = a.WaterMeterNo,
                                Year = rd.ReadingDate.Year,
                                billmonth = rd.ReadingDate.ToString("MMM yyyy"),
                 });
                return data.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
