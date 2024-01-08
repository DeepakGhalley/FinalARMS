using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
namespace CORE_BLL
{
    public class InitialConnectionsBLL : IInitialConnections
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        

        public List<WaterConnectionModel> SearchConsumerNo(string ConsumerNo)
        {

            //var oldCon = (from a in ctx.MstWaterConnection.Where(x => x.IsActive == true && x.ConsumerNo == ConsumerNo)
            //         join b in ctx.TblWaterMeterReading on a.WaterConnectionId equals b.WaterConnectionId
            //         select 
            //         a.WaterConnectionId ).ToList();

            var data = (from a in ctx.MstWaterConnection.Where(x =>x.IsActive==true && x.ConsumerNo == ConsumerNo)
                        join b in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals b.WaterConnectionStatusId
                        join c in ctx.MstWaterMeterType on a.WaterMeterTypeId equals c.WaterMeterTypeId
                        join d in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals d.WaterConnectionTypeId
                        join e in ctx.MstWaterLineType on a.WaterLineTypeId equals e.WaterLineTypeId
                        join f in ctx.MstZone on a.ZoneId equals f.ZoneId
                        join x in ctx.MstLandDetail on a.LandDetailId equals x.LandDetailId
                        let tno = (ctx.TblWaterMeterReading.Where(lod => lod.WaterConnectionId == a.WaterConnectionId)).Take(1).FirstOrDefault().WaterMeterReadingId
                        let tn = (ctx.TblWaterMeterReading.Where(lod => lod.WaterConnectionId == a.WaterConnectionId)).Take(1).FirstOrDefault().WaterConnectionId
                        //where oldCon.Contains(a.WaterConnectionId)
                        select new WaterConnectionModel
                        {                          
                            PlotNo = x.PlotNo,
                            WaterConnectionStatus = b.WaterConnectionStatus,
                            WaterMeterNo = a.WaterMeterNo,
                            WaterMeterType = c.WaterMeterType,
                            ConnectionDate = a.ConnectionDate,
                            WaterConnectionType = d.WaterConnectionType,
                            WaterLineType = e.WaterLineType,
                            BillingAddress = a.BillingAddress,
                            ZoneName = f.ZoneName,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            WaterConnectionId  = a.WaterConnectionId,
                            WaterMeterReadingId = (int)tno,
                            ConsumerNo = a.ConsumerNo,
                            WaterConnection  = tn
                         
                        });
            return data.ToList();
        }

        public List<WaterMeterReadingModel> WaterMeterReading(int? id)
        {
            var data = (from a in ctx.TblWaterMeterReading.Where(a => a.WaterConnectionId == id).OrderByDescending(a=>a.WaterMeterReadingId).Take(1)
                      //  join b in ctx.MstWaterConnection on a.WaterConnectionId equals b.WaterConnectionId
                       // let c = ctx.TblWaterMeterReading.Where(y => y.WaterConnectionId == a.WaterConnectionId).Max(x => x.ReadingDate)

                        select new WaterMeterReadingModel
                        {
                            //ConsumerNo = b.ConsumerNo,
                            //WaterMeterNo = b.WaterMeterNo,
                            Reading = a.Reading,
                            ReadingDate = a.ReadingDate,
                            PreviousReading = a.PreviousReading,
                            PreviousReadingDate = a.PreviousReadingDate,
                            Consumption = a.Consumption,
                            WaterConnectionId = a.WaterConnectionId
                        });
            return data.ToList();
        }

        public List<WaterConnectionModel> DisplayWaterConnectionDetail(string ConsumerNo)
        {
            var data = (from a in ctx.MstWaterConnection.Where(a => a.ConsumerNo == ConsumerNo)
                       
                        select new WaterConnectionModel
                        {
                            WaterConnectionId = a.WaterConnectionId,
                            TransactionId = (long)a.TransactionId,
                            WaterConnectionTypeId = a.WaterConnectionTypeId,
                            WaterMeterTypeId = a.WaterMeterTypeId,
                            WaterLineTypeId = a.WaterLineTypeId,
                            WaterConnectionStatusId = a.WaterConnectionStatusId,
                            ZoneId = a.ZoneId,
                            NoOfUnits = a.NoOfUnits,
                            StandardCosumption = a.StandardConsumption,
                            IsPermanentConnect = a.IsPermanentConnection,
                            SewerageConnection = a.SewerageConnection,
                            SolidWaste = a.SolidWaste,
                            FlatNo = a.FlatNo,
                            BillingAddress = a.BillingAddress,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            //SecondaryMobileNo = a.SecondaryMobileNo,
                                                
                        });
            return data.Distinct().ToList();
        }

        public int SaveWaterMeterReading(WaterMeterReadingModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblWaterMeterReading
                {
                WaterConnectionId = obj.WaterConnectionId,
                //TransactionId = obj.TransactionId,
                WaterConnectionTypeId = obj.WaterConnectionTypeId,
                WaterMeterTypeId = obj.WaterMeterTypeId,
                WaterLineTypeId = obj.WaterLineTypeId,
                WaterConnectionStatusId = obj.WaterConnectionStatusId,
                ZoneId = obj.zoneId,
                Reading = obj.Reading,
                IsRead = obj.IsRead,
                ReadingDate = obj.ReadingDate,
                PreviousReading = obj.PreviousReading,
                PreviousReadingDate = obj.PreviousReadingDate,
                ReadBy = obj.ReadBy,
                NoOfUnit = obj.NoOfUnit,
                StandardConsumption = obj.StandardConsumption,
                IsPermanentConnection = obj.IsPermanentConnection,
                Sewerage = obj.Sewerage,
                SolidWaste = obj.SolidWaste,
                Remarks = obj.Remarks,
                FlatNo = obj.FlatNo,
                BillingAddress = obj.BillingAddress,
                PrimaryMobileNo = obj.PrimaryMobileNo,
                IsActive = obj.Active,
                IsDisconnected = obj.IsDisconnected,
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                Consumption = obj.Consumption
            };
                ctx.TblWaterMeterReading.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = (int)entity.WaterMeterReadingId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int SaveWaterConnection(WaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstWaterConnection
                {
                LandDetailId = obj.LandDetailId,
                LandOwnershipId = obj.LandOwnershipId,
                WaterConnectionStatusId = obj.WaterConnectionStatusId,
                OwnerTypeId = obj.OwnerTypeId,
                WaterMeterNo = obj.WaterMeterNo,
                WaterMeterTypeId = obj.WaterMeterTypeId,
                ConsumerNo = obj.ConsumerNo,
                WaterConnectionTypeId = obj.WaterConnectionTypeId,
                WaterLineTypeId = obj.WaterLineTypeId,
                StandardConsumption = obj.StandardCosumption,
                BillingAddress = obj.BillingAddress,
                ZoneId = obj.ZoneId,
                FlatNo = obj.FlatNo,
                InitialReading = obj.InitialReading,
                Remarks = obj.Remarks,
                NoOfUnits = obj.NoOfUnits,
                PrimaryMobileNo = obj.PrimaryMobileNo,
                SecondaryMobileNo = obj.SecondaryMobileNo,
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                SewerageConnection = true,
                SolidWaste = false,
                IsActive = true,
                IsPermanentConnection = true,
                IsPermanentDisconnect = false,
                
            };
                ctx.MstWaterConnection.Add(entity);
                ctx.SaveChanges();
                ipk = (int)entity.WaterConnectionId;

                var entities = new TblWaterMeterReading
                {
                    WaterConnectionId = ipk,
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    ZoneId = obj.ZoneId,
                    Reading = (int)obj.InitialReading,
                    IsRead = false,
                    ReadingDate = obj.ReadingDate,
                    PreviousReading = 0,
                    PreviousReadingDate = obj.PreviousReadingDate,
                    ReadBy = obj.ZoneId,
                    NoOfUnit = obj.NoOfUnits,
                    Consumption = 0,
                    StandardConsumption = obj.StandardCosumption,
                    IsPermanentConnection = (bool)obj.IsPermanentConnect,
                    Sewerage = obj.SewerageConnection,
                    SolidWaste = obj.SolidWaste,
                    Remarks = obj.Remarks,
                    FlatNo = obj.FlatNo,
                    BillingAddress = obj.BillingAddress,
                    PrimaryMobileNo = obj.PrimaryMobileNo,
                    SecondaryMobileNo = obj.SecondaryMobileNo,
                    IsActive = true,
                    IsDisconnected = false,                  
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    
                };
                ctx.TblWaterMeterReading.Add(entities);
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

        public List<LandOwnershipDetailsVM> SearchLandDetails(string PlotNo, string ThramNo, string TTIN)
        {

            var data = (from a in ctx.TblLandOwnershipDetail
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        join c in ctx.MstTaxPayerProfile on a.TaxPayerId equals c.TaxPayerId
                        where b.PlotNo == PlotNo || a.ThramNo == ThramNo || c.Ttin == TTIN

                        select new LandOwnershipDetailsVM
                        {
                            PlotNo = b.PlotNo,
                            LandDetailId = a.LandDetailId,
                            TaxPayerId = a.TaxPayerId,
                            name = c.FirstName + " " + ((c.MiddleName == null || c.MiddleName.Trim() == string.Empty) ? string.Empty : (c.MiddleName + " ")) + ((c.LastName == null || c.LastName.Trim() == string.Empty) ? string.Empty : (c.LastName + " ")),
                            ThramNo = a.ThramNo,
                            TTIN = c.Ttin,
                            CID = c.Cid,
                            LandOwnershipId = a.LandOwnershipId

                        });
            return data.ToList();
        }
    }

}
   
