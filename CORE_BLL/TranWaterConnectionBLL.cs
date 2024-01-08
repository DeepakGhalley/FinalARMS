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
    public class TranWaterConnectionBLL : ITranWaterConnection
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<TranWaterConnectionModel> GetAll()
        {
            var data = (from x in ctx.TrnWaterConnection
                        join y in ctx.MstLandDetail on x.LandDetailId equals y.LandDetailId
                        join z in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals z.WaterConnectionStatusId
                        join a in ctx.MstWaterMeterType on x.WaterMeterTypeId equals a.WaterMeterTypeId
                        join b in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on x.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstZone on x.ZoneId equals d.ZoneId
                        join e in ctx.EnumOwnerType on x.OwnerTypeId equals e.OwnerTypeId
                        join f in ctx.TblLandOwnershipDetail on y.LandDetailId equals f.LandDetailId
                        join h in ctx.MstTaxPayerProfile on f.TaxPayerId equals h.TaxPayerId

                        select new TranWaterConnectionModel
                        {
                            TrnWaterConnectionId = x.TrnWaterConnectionId,
                            //WaterConnectionId = (int)x.TrnWaterConnectionId,
                            LandDetailId = x.LandDetailId,
                            PlotNo = y.PlotNo,

                            location = y.Location,
                            ThramNo = f.ThramNo,
                            Cid = h.Cid,
                            Ttin = h.Ttin,

                            WaterConnectionStatusId = x.WaterConnectionStatusId,

                            WaterMeterNo = x.WaterMeterNo,
                            WaterMeterTypeId = x.WaterMeterTypeId,
                            ConsumerNo = x.ConsumerNo,

                            ConnectionDate = x.ApplicationDate,
                            SewerageConnection = x.SewerageConnection,
                            WaterConnectionType = b.WaterConnectionType,
                            WaterLineTypeId = x.WaterLineTypeId,
                            StandardCosumption = (int)x.StandardCosumption,
                            BillingAddress = x.BillingAddress,
                            ZoneName = d.ZoneCode,
                            FlatNo = x.FlatNo,
                            InitialReading = x.InitialReading,
                            OrganisationName = x.OrganisationName,
                            Remarks = x.Remarks,
                            ReUse = (bool)x.ReUse,
                            DisconnectDate = (DateTime)x.DisconnectDate,
                            NoOfUnits = x.NoOfUnits,
                            OwnerTypeId = x.OwnerTypeId,
                            ChangeTypeId = (int)x.ChangeTypeId,
                            ReconnectionDate = (DateTime)x.ReconnectionDate,
                            SewarageConnectionDate = (DateTime)x.SewarageConnectionDate,
                            SewarageConnectedBy = (int)x.SewarageConnectedBy,
                            PrimaryMobileNo = x.PrimaryMobileNo,
                            SecondaryMobileNo = x.SecondaryMobileNo,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<TranWaterConnectionModel> Details(int? id)
        {
            var data = (from a in ctx.TrnWaterConnection.Where(aa => aa.TrnWaterConnectionId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        join c in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals c.WaterConnectionStatusId
                        select new TranWaterConnectionModel
                        {
                            TrnWaterConnectionId = a.TrnWaterConnectionId,
                            LandDetailId = a.LandDetailId,
                            WaterConnectionStatusId = a.WaterConnectionStatusId,
                            WaterMeterNo = a.WaterMeterNo,
                            WaterMeterTypeId = a.WaterMeterTypeId,
                            ConsumerNo = a.ConsumerNo,
                            ConnectionDate = a.ApplicationDate,
                            SewerageConnection = a.SewerageConnection,
                            WaterConnectionTypeId = a.WaterConnectionTypeId,
                            WaterLineTypeId = a.WaterLineTypeId,
                            StandardCosumption = (int)a.StandardCosumption,
                            BillingAddress = a.BillingAddress,
                            ZoneId = a.ZoneId,
                            FlatNo = a.FlatNo,
                            InitialReading = a.InitialReading,
                            OrganisationName = a.OrganisationName,
                            Remarks = a.Remarks,
                            ReUse = (bool)a.ReUse,
                            DisconnectDate = (DateTime)a.DisconnectDate,
                            NoOfUnits = a.NoOfUnits,
                            OwnerTypeId = a.OwnerTypeId,
                            ReconnectionDate = (DateTime)a.ReconnectionDate,
                            SewarageConnectionDate = (DateTime)a.SewarageConnectionDate,
                            SewarageConnectedBy = (int)a.SewarageConnectedBy,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            SecondaryMobileNo = a.SecondaryMobileNo,
                            PlotNo = b.PlotNo,
                            WaterConnectionStatus = c.WaterConnectionStatus

                        });

            return await data.FirstOrDefaultAsync();

        }
        public long Save(TranWaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                var wcef = ctx.MstSlab.Where(x => x.TaxId == 75).Max(x => x.EffectiveDate);
                var wcslab = ctx.MstSlab.Single(x => x.TaxId == 75 && x.EffectiveDate == wcef);
                var NWCrateData = ctx.MstRate.Single(x => x.SlabId == wcslab.SlabId);

                var mef = ctx.MstSlab.Where(x => x.TaxId == 40).Max(x => x.EffectiveDate);
                var slab = ctx.MstSlab.Single(x => x.TaxId == 40 && x.WaterLineTypeId==obj.WaterLineTypeId  && x.EffectiveDate == mef);
                var rateData = ctx.MstRate.Single(x => x.SlabId == slab.SlabId);
                    

                long TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 2,
                    WorkLevelId = 3,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    TransactionValue = rateData.Rate
                    
                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = TRNEntity.TransactionId;

                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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

                var entityD = new TblDemand
                {

                    TransactionId = TransactionId,
                    DemandNoId = dnid,
                    TaxId = 40,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = rateData.Rate,
                    TotalAmount = rateData.Rate,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TaxPayerId = obj.TaxPayerId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entityD);
                ctx.SaveChanges();

                var entitywcf = new TblDemand
                {

                    TransactionId = TransactionId,
                    DemandNoId = dnid,
                    TaxId = 75,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = NWCrateData.Rate,
                    TotalAmount = NWCrateData.Rate,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TaxPayerId = obj.TaxPayerId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entitywcf);
                ctx.SaveChanges();


                WorkLevelId = (int)TRNEntity.WorkLevelId;
                //int wcid;
                //var entitywc = new MstWaterConnection
                //{

                //    LandDetailId = obj.LandDetailId,
                //    LandOwnershipId = (int)obj.LandOwnershipId,
                //    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                //    OwnerTypeId = obj.OwnerTypeId,
                //    ChangeTypeId = 1,
                //    WaterMeterNo = obj.WaterMeterNo,
                //    WaterMeterTypeId = obj.WaterMeterTypeId,
                //    ConsumerNo = obj.ConsumerNo,
                //    ConnectionDate = obj.ConnectionDate,
                //    SewerageConnection = obj.SewerageConnection,
                //    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                //    StandardConsumption = obj.StandardCosumption,
                //    CreatedBy = obj.CreatedBy,
                //    CreatedOn = obj.CreatedOn,
                //    BillingAddress = obj.BillingAddress,
                //    ZoneId = obj.ZoneId,
                //    FlatNo = obj.FlatNo,
                //    InitialReading = obj.InitialReading,
                //    OrganisationName = obj.OrganisationName,
                //    IsActive = true,
                //    IsPermanentDisconnect = true,
                //    Remarks = obj.Remarks,
                //    DisconnectDate = obj.DisconnectDate,
                //    NoOfUnits = obj.NoOfUnits,
                //    ReconnectionDate = obj.ReconnectionDate,
                //    SewarageConnectionDate = obj.SewarageConnectionDate,
                //    SewarageConnectedBy = obj.SewarageConnectedBy,
                //    PrimaryMobileNo = obj.PrimaryMobileNo,
                //    SecondaryMobileNo =obj. SecondaryMobileNo,
                //    TransactionId = TransactionId,
                //    SolidWaste = false,
                //     WaterLineTypeId = obj.WaterLineTypeId
                //    //TransactionId = item.TransactionId,
                //};
                //ctx.MstWaterConnection.Add(entitywc);
                //ctx.SaveChanges();
                //wcid = entitywc.WaterConnectionId;
                //int ipk;
                //var entitywmr = new TblWaterMeterReading
                //{
                //    WaterConnectionId = wcid,
                //    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                //    WaterMeterTypeId = obj.WaterMeterTypeId,
                //    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                //    StandardConsumption = obj.StandardCosumption,
                //    CreatedBy = obj.CreatedBy,
                //    CreatedOn = obj.CreatedOn,
                //    BillingAddress = obj.BillingAddress,
                //    ZoneId = obj.ZoneId,
                //    FlatNo = obj.FlatNo,
                //    IsActive = true,
                //    Remarks = obj.Remarks,
                //    PrimaryMobileNo = obj.PrimaryMobileNo,
                //    SecondaryMobileNo = obj.SecondaryMobileNo,
                //    TransactionId = TransactionId,
                //    WaterLineTypeId = obj.WaterLineTypeId,
                //    IsDisconnected = false,
                //    IsRead = false,
                //    PreviousReading = 0,
                //    PreviousReadingDate = obj.CreatedOn,
                //    NoOfUnit = obj.NoOfUnits,
                //    Consumption = 0,
                //    IsPermanentConnection = true,
                //    Sewerage = true,
                //    SolidWaste = false,
                //    Reading = 0,
                //    ReadingDate = obj.CreatedOn,
                //    ReadBy = obj.CreatedBy,

                //    //TransactionId = item.TransactionId,
                //};
                //ctx.TblWaterMeterReading.Add(entitywmr);
                //ctx.SaveChanges();

                //s.Complete();
                //s.Dispose();
                //ipk = (int)entitywmr.WaterMeterReadingId;
                int ipk;
                var IPC = obj.IPC;
                if (IPC == 0)
                {
                    
                    var entity = new TrnWaterConnection
                    {
                        TrnWaterConnectionId = obj.TrnWaterConnectionId,
                        LandDetailId = obj.LandDetailId,
                        WaterConnectionStatusId = obj.WaterConnectionStatusId,
                        WaterMeterNo = obj.WaterMeterNo,
                        WaterMeterTypeId = obj.WaterMeterTypeId,
                        ConsumerNo = obj.ConsumerNo,
                        ApplicationDate = obj.ConnectionDate,
                        //SewerageConnection = Convert.ToBoolean("false"),
                        SewerageConnection = false,
                        WaterConnectionTypeId = obj.WaterConnectionTypeId,
                        WaterLineTypeId = obj.WaterLineTypeId,
                        StandardCosumption = obj.StandardCosumption,
                        BillingAddress = obj.BillingAddress,
                        ZoneId = obj.ZoneId,
                        FlatNo = obj.FlatNo,
                        InitialReading = obj.InitialReading,
                        OrganisationName = obj.OrganisationName,
                        Remarks = obj.Remarks,
                        //ReUse = Convert.ToBoolean("true"),
                        NoOfUnits = obj.NoOfUnits,
                        OwnerTypeId = obj.OwnerTypeId,
                        PrimaryMobileNo = obj.PrimaryMobileNo,
                        SecondaryMobileNo = obj.SecondaryMobileNo,
                        //IsActive = Convert.ToBoolean("true"),
                        IsActive = true,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                        WorkLevelId = WorkLevelId,
                        TransactionId = TransactionId,
                        LandOwnershipId = obj.LandOwnershipId,
                        IsPermanent = false

                    };
                    ctx.TrnWaterConnection.Add(entity);
                    ctx.SaveChanges();
                    
                }

                
                else
                {
                    
                    var entity = new TrnWaterConnection
                    {
                        TrnWaterConnectionId = obj.TrnWaterConnectionId,
                        LandDetailId = obj.LandDetailId,
                        WaterConnectionStatusId = obj.WaterConnectionStatusId,
                        WaterMeterNo = obj.WaterMeterNo,
                        WaterMeterTypeId = obj.WaterMeterTypeId,
                        ConsumerNo = obj.ConsumerNo,
                        ApplicationDate = obj.ConnectionDate,
                        //SewerageConnection = Convert.ToBoolean("false"),
                        SewerageConnection = false,
                        WaterConnectionTypeId = obj.WaterConnectionTypeId,
                        WaterLineTypeId = obj.WaterLineTypeId,
                        StandardCosumption = obj.StandardCosumption,
                        BillingAddress = obj.BillingAddress,
                        ZoneId = obj.ZoneId,
                        FlatNo = obj.FlatNo,
                        InitialReading = obj.InitialReading,
                        OrganisationName = obj.OrganisationName,
                        Remarks = obj.Remarks,
                        //ReUse = Convert.ToBoolean("true"),
                        NoOfUnits = obj.NoOfUnits,
                        OwnerTypeId = obj.OwnerTypeId,
                        PrimaryMobileNo = obj.PrimaryMobileNo,
                        SecondaryMobileNo = obj.SecondaryMobileNo,
                        //IsActive = Convert.ToBoolean("true"),
                        IsActive = true,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                        WorkLevelId = WorkLevelId,
                        TransactionId = TransactionId,
                        LandOwnershipId = obj.LandOwnershipId,
                        IsPermanent = true
                        

                    };
                    ctx.TrnWaterConnection.Add(entity);
                    ctx.SaveChanges();
                   
                }

               
                s.Complete();
                s.Dispose();
               

                return TransactionId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(TranWaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TrnWaterConnection.FirstOrDefault(u => u.TrnWaterConnectionId == obj.TrnWaterConnectionId);
                    Data.LandDetailId = obj.LandDetailId; Data.WaterConnectionStatusId = obj.WaterConnectionStatusId;
                    Data.WaterMeterNo = obj.WaterMeterNo; Data.WaterMeterTypeId = obj.WaterMeterTypeId;
                    Data.ConsumerNo = obj.ConsumerNo; Data.ApplicationDate = obj.ConnectionDate;
                    Data.WaterLineTypeId = obj.WaterLineTypeId; Data.StandardCosumption = obj.StandardCosumption;
                    Data.BillingAddress = obj.BillingAddress; Data.ZoneId = obj.ZoneId; Data.FlatNo = obj.FlatNo;
                    Data.InitialReading = obj.InitialReading; Data.OrganisationName = obj.OrganisationName; Data.Remarks = obj.Remarks;
                    Data.NoOfUnits = obj.NoOfUnits;
                    Data.OwnerTypeId = obj.OwnerTypeId;
                    Data.PrimaryMobileNo = obj.PrimaryMobileNo; Data.SecondaryMobileNo = obj.SecondaryMobileNo;
                    Data.WaterConnectionTypeId = obj.WaterConnectionTypeId;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
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
            return ctx.MstWaterConnection.Any(e => e.WaterConnectionId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstWaterConnection = ctx.MstWaterConnection.Find(id);
                ctx.MstWaterConnection.Remove(MstWaterConnection);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstWaterConnection = await ctx.MstWaterConnection
                           .FirstOrDefaultAsync(m => m.WaterConnectionId == id);
        }
        public bool DuplicateCheckOnSave(string ConsumerNo)
        {
            return ctx.MstWaterConnection.Any(e => e.ConsumerNo == ConsumerNo);
        }
        public bool DuplicateCheckOnSewerage(int SewerageConnectionId)
        {
            return ctx.TrnSewerageConnection.Any(e => e.SewerageConnectionId == SewerageConnectionId);
        }
        public bool DuplicateCheckOnUpdate(string ConsumerNo, int LandDetailId, int WaterMeterTypeId, int WaterConnectionTypeId, string WaterConnectionType, int WaterLineTypeId, int ZoneId, int OwnerTypeId)
        {
            return ctx.MstWaterConnection.Any(e => e.ConsumerNo == ConsumerNo && e.LandDetailId == LandDetailId && e.WaterMeterTypeId == WaterMeterTypeId && e.WaterConnectionTypeId == WaterConnectionTypeId && e.WaterLineTypeId == WaterLineTypeId && e.ZoneId == ZoneId && e.OwnerTypeId == OwnerTypeId);
        }

        public bool DuplicateCheckOnUpdate(string ConsumerNo, int WaterConnectionId, int LandDetailId, int WaterMeterTypeId, int WaterConnectionTypeId, int WaterLineTypeId, int ZoneId, int OwnerTypeId)
        {
            throw new NotImplementedException();
        }

        public List<GetLandOwnershipDetails> fetchLandOwnershipDetails(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join b in ctx.TblLandOwnershipDetail on a.TaxPayerId equals b.TaxPayerId
                        join c in ctx.MstLandDetail on b.LandDetailId equals c.LandDetailId
                        let td = ctx.TblTransactionDetail.Where(m => m.TaxPayerId == a.TaxPayerId).Max(m => m.TransactionId)
                        select new GetLandOwnershipDetails
                        {
                            CID = a.Cid,
                            TPN = a.Tpn,
                            TTIN = a.Ttin,
                            Name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            ThramNo = b.ThramNo,
                            PlotNo = c.PlotNo,
                            PlotAddress = c.PlotAddress,
                            LandAcreage = c.LandAcerage,
                            LandValue = c.LandValue,
                            LandDetailId = b.LandDetailId ,
                            LandOwnershipId = b.LandOwnershipId,
                            TaxPayerId = a.TaxPayerId,
                            //TransactionId = td
                        });
                return data.ToList();
        }

        public List<TranWaterConnectionModel> GetTranWaterConnectionDetails(int id)
        {
            var Data = (from a in ctx.MstWaterConnection.Where(x => x.LandDetailId == id)
                        select new TranWaterConnectionModel
                        {
                            WaterMeterNo = a.WaterMeterNo,
                            ConsumerNo = a.ConsumerNo,
                            OrganisationName = a.OrganisationName,
                            NoOfUnits = a.NoOfUnits,
                            BillingAddress = a.BillingAddress,
                            PrimaryMobileNo = a.PrimaryMobileNo
                        });
            return Data.ToList();
        }


        public List<TranWaterConnectionModel> Getwaterdetailstoupgadeanddowngrate(int id)
        {
            var Data = (from a in ctx.MstWaterConnection.Where(x => x.LandDetailId == id)
                        join wmr in ctx.TblWaterMeterReading on a.WaterConnectionId equals wmr.WaterConnectionId
                        join wl in ctx.MstWaterLineType on a.WaterLineTypeId equals wl.WaterLineTypeId
                        join wm in ctx.MstWaterMeterType on a.WaterMeterTypeId equals wm.WaterMeterTypeId
                        join wc in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals wc.WaterConnectionTypeId
                        where a.IsActive == true
                        select new TranWaterConnectionModel
                        {
                            WaterMeterNo = a.WaterMeterNo,
                            ConsumerNo = a.ConsumerNo,
                            OrganisationName = a.OrganisationName,
                            NoOfUnits = a.NoOfUnits,
                            BillingAddress = a.BillingAddress,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            WaterLineType = wl.WaterLineType,
                            WaterMeterType = wm.WaterMeterType,
                            WaterConnectionType = wc.WaterConnectionType,
                            WaterConnectionId = a.WaterConnectionId,
                            WaterMeterReadingId = (int)wmr.WaterMeterReadingId
                           
                        });
            return Data.ToList();
        }
        public List<TranWaterConnectionModel> fetchWaterConnection(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join b in ctx.TblLandOwnershipDetail on a.TaxPayerId equals b.TaxPayerId
                        join c in ctx.MstLandDetail on b.LandDetailId equals c.LandDetailId

                        select new TranWaterConnectionModel
                        {

                            ThramNo = b.ThramNo,
                            location = c.Location,
                            PlotNo = c.PlotNo



                        });
            return data.ToList();
        }

        //For Meter Replacements
        public List<WaterConnectionModel> GetWaterDetails(int? id)
        {
            var data = (from x in ctx.MstWaterConnection .Where(x=>x.WaterConnectionId== id)
                        join a in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals a.WaterConnectionStatusId
                        join b in ctx.MstWaterLineType on x.WaterLineTypeId equals b.WaterLineTypeId
                        join c in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals c.WaterConnectionTypeId
                        join e in ctx.TblWaterMeterReading on x.WaterConnectionId equals e.WaterConnectionId
                        select new WaterConnectionModel
                        {
                            WaterConnectionStatus = a.WaterConnectionStatus,
                            WaterMeterNo = x.WaterMeterNo,
                            ConsumerNo = x.ConsumerNo,
                            ConnectionDate = x.ConnectionDate,
                            WaterLineType = b.WaterLineType,
                            WaterConnectionType = c.WaterConnectionType,
                            WaterConnectionId = x.WaterConnectionId,
                            WaterMeterReadingId = (int)e.WaterMeterReadingId

                        });
            return data.ToList();
        }

        //For Meter Replacement
        public List<TranWaterConnectionModel> GetReadingDetails(int? id)
        {
            var data = (from x in ctx.TblWaterMeterReading.Where(x=>x.WaterMeterReadingId==id)
                        join a in ctx.MstWaterMeterType on x.WaterMeterTypeId equals a.WaterMeterTypeId
                        join b in ctx.MstWaterLineType on x.WaterLineTypeId equals b.WaterLineTypeId
                        select new TranWaterConnectionModel
                        {
                            WaterMeterType = a.WaterMeterType,
                            WaterLineType = b.WaterLineType,
                            previousReading = x.PreviousReading,
                            previousReadingDate = x.PreviousReadingDate,
                            Reading = x.Reading,
                            ReadingDate = x.ReadingDate,
                            NoOfUnits = x.NoOfUnit,
                            Consumption = x.Consumption,


                        });
            return data.ToList();
        }


        public List<WaterConnectionModel> getWaterDisconnection(string cid, string ttin, string consumerno, string meterno)
        {
            var data = (from x in ctx.MstTaxPayerProfile
                        join b in ctx.TblLandOwnershipDetail on x.TaxPayerId equals b.TaxPayerId
                        join a in ctx.MstLandDetail on b.LandDetailId equals a.LandDetailId
                        join c in ctx.MstWaterConnection on a.LandDetailId equals c.LandDetailId
                       // join y in ctx.MstWaterMeterType on c.WaterLineTypeId equals y.WaterMeterTypeId
                        where (c.ConsumerNo == consumerno || c.WaterMeterNo == meterno || x.Cid == cid || x.Ttin == ttin) && c.IsActive == true

                        select new WaterConnectionModel
                        {
                            WaterConnectionId = c.WaterConnectionId,
                            BillingAddress = c.BillingAddress,
                            ConsumerNo = c.ConsumerNo,
                            WaterMeterNo = c.WaterMeterNo,
                            //WaterMeterType = y.WaterMeterType,
                            LandDetailId = a.LandDetailId,
                            TaxPayerName = x.FirstName + ' ' + x.MiddleName + ' ' + x.LastName,
                            PrimaryMobileNo = c.PrimaryMobileNo,
                            PlotNo = a.PlotNo,
                            LandAcerage = a.LandAcerage
                        });
            return data.ToList();
        }

        public List<WaterConnectionModel> getWaterConnectionDetails(int? id)
        {
            var data = (from a in ctx.MstWaterConnection.Where(a => a.WaterConnectionId == id)
                        join b in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals b.WaterConnectionStatusId
                        join c in ctx.MstWaterLineType on a.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals d.WaterConnectionTypeId
                        join z in ctx.MstZone on a.ZoneId equals z.ZoneId

                        select new WaterConnectionModel
                        {
                            ConsumerNo = a.ConsumerNo,
                            WaterMeterNo = a.WaterMeterNo,
                            ConnectionDate = a.ConnectionDate,                          
                            WaterConnectionStatus = b.WaterConnectionStatus,
                            WaterLineType = c.WaterLineType,
                            WaterConnectionType = d.WaterConnectionType,
                            ZoneName = z.ZoneName,
                            BillingAddress = a.BillingAddress,
                            DisconnectDate = (DateTime)a.DisconnectDate,
                            ReconnectionDate = (DateTime)a.ReconnectionDate,
                            MaxReadingDate = a.MaxReadingDate,
                            WaterConnectionId = a.WaterConnectionId
                            
                        });
            return data.ToList();
        }


        //public int savewaterdisconnection(TranWaterConnectionModel obj)
        //{
        //    try
        //    {
        //        using (TransactionScope s = new TransactionScope())
        //        {

        //            ctx.SaveChanges();

        //            var IPD = obj.IPD;
        //            if (IPD == 1)
        //            {

        //                var waterId = obj.WaterConnectionId;
        //                var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == waterId);
        //                Data.Remarks = obj.Remarks;
        //                Data.DisconnectDate = obj.DisconnectDate;
        //                Data.IsActive = false;
        //                Data.IsPermanentConnection = true;
        //            }
        //            else
        //            {

        //                var waterId = obj.WaterConnectionId;
        //                var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == waterId);
        //                Data.Remarks = obj.Remarks;
        //                Data.DisconnectDate = obj.DisconnectDate;
        //                Data.IsActive = false;
        //                Data.IsPermanentConnection = false;
        //            }

        //            s.Complete();
        //            s.Dispose();
        //            return 1;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}


        public int SaveWaterDisconnection(TranWaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                long TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 21,
                    WorkLevelId = 3,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn
                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = TRNEntity.TransactionId;
                WorkLevelId = (int)TRNEntity.WorkLevelId;
                int ipk;

                var waterId = obj.WaterConnectionId;

                var watertrnDetailData = ctx.MstWaterConnection.Where(w => w.WaterConnectionId == waterId);
                var landDetailId = watertrnDetailData.FirstOrDefault().LandDetailId;
                var WaterconnectionStatusId = watertrnDetailData.FirstOrDefault().WaterConnectionStatusId;
                var MeterNo = watertrnDetailData.FirstOrDefault().WaterMeterNo;
                var WaterMeterTypeId = watertrnDetailData.FirstOrDefault().WaterMeterTypeId;
                var consNo = watertrnDetailData.FirstOrDefault().ConsumerNo;
                var SewerageConnection = watertrnDetailData.FirstOrDefault().SewerageConnection;
                var WaterConnectionTypeId = watertrnDetailData.FirstOrDefault().WaterConnectionTypeId;
                var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;
                var BillingAddress = watertrnDetailData.FirstOrDefault().BillingAddress;
                var ZoneId = watertrnDetailData.FirstOrDefault().ZoneId;
                var FlatNo = watertrnDetailData.FirstOrDefault().FlatNo;
                var OrganisationName = watertrnDetailData.FirstOrDefault().OrganisationName;
                var IsActive = watertrnDetailData.FirstOrDefault().IsActive;
                var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                var OwnerTypeId = watertrnDetailData.FirstOrDefault().OwnerTypeId;
                var ChangeTypeId = watertrnDetailData.FirstOrDefault().ChangeTypeId;
                var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                var landownershipId = watertrnDetailData.FirstOrDefault().LandOwnershipId;
                var InitialReading = watertrnDetailData.FirstOrDefault().InitialReading;
                var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                var IsPermanentConnection = watertrnDetailData.FirstOrDefault().IsPermanentConnection;

                //var Data1 = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == waterId).OrderByDescending().WaterMeterReadingId;
                //var WaterMeterReadingId = Data1.FirstOrDefault().WaterMeterReadingId.OrderByDescending();
                //var ID = from x in ctx.TblWaterMeterReading
                //         orderby x.WaterMeterReadingId descending
                //         where x.WaterConnectionId  == waterId
                //         select x.WaterMeterReadingId;
                //var WaterMeterReadingId =(Convert.ToInt64(ID));
                //var trntypeid = ctx.TblTransactionDetail.Where(t => t.TransactionId == trnid).order().TransactionTypeId;

                var WaterMeterReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == waterId).Max(y => y.WaterMeterReadingId);



                var tblwatermeterreadingData = ctx.TblWaterMeterReading.Where(w => w.WaterConnectionId == waterId);
                var StandardConsumption = tblwatermeterreadingData.FirstOrDefault().StandardConsumption;
                
                var ReadingDate = tblwatermeterreadingData.FirstOrDefault().ReadingDate;
                var Reading = tblwatermeterreadingData.FirstOrDefault().Reading;
                var PreviousReading = tblwatermeterreadingData.FirstOrDefault().PreviousReading;
                var PreviousReadingDate = tblwatermeterreadingData.FirstOrDefault().PreviousReadingDate;
                var entity = new TrnWaterConnection
                {
                  
                    LandDetailId = landDetailId,
                    WaterConnectionStatusId = WaterconnectionStatusId,
                    WaterMeterNo = MeterNo,
                    WaterMeterTypeId = WaterMeterTypeId,
                    ConsumerNo = consNo,                    
                    SewerageConnection = SewerageConnection,
                    WaterConnectionTypeId = WaterConnectionTypeId,
                    WaterLineTypeId = WaterLineTypeId,
                    StandardCosumption = (int)StandardConsumption,
                    BillingAddress = BillingAddress,
                    ZoneId = ZoneId,
                    FlatNo = FlatNo,
                    OrganisationName = OrganisationName,
                    IsActive = false,
                    Remarks = Remarks,
                    NoOfUnits = NoOfUnits,
                    OwnerTypeId = OwnerTypeId,
                    ChangeTypeId = ChangeTypeId,
                    PrimaryMobileNo = PrimaryMobileNo,
                    SecondaryMobileNo = SecondaryMobileNo,
                    WorkLevelId = 3,
                    TransactionId = TransactionId,
                    IsPermanent = IsPermanentConnection,
                    ApprovalStatusId = true,
                    LandOwnershipId = landownershipId,
                    InitialReading = obj.InitialReading,
                    PreviousReading = PreviousReading,
                    PreviousReadingDate = PreviousReadingDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    DisconnectDate = obj.DisconnectDate,
                    IsPermanentDisconnect = obj.IsPermanentDisconnect,
                    OldWaterConnectionId= waterId
                };
                ctx.TrnWaterConnection.Add(entity);
                ctx.SaveChanges();

               

                var IPD = obj.IPD;
                if (IPD == 1)
                {

                   
                    var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == waterId);
                    Data.Remarks = obj.Remarks;
                    Data.DisconnectDate = obj.DisconnectDate;
                    Data.IsActive = false;
                    Data.IsPermanentConnection = true;
                    ctx.SaveChanges();

                    var Data2 = ctx.TblWaterMeterReading.FirstOrDefault(u => u.WaterMeterReadingId == WaterMeterReadingId);
                    Data2.IsActive = false;
                    Data2.IsDisconnected = true;
                    ctx.SaveChanges();

                    ctx.SaveChanges();

                }
                else
                {

                    var Data2 = ctx.TblWaterMeterReading.FirstOrDefault(u => u.WaterMeterReadingId == WaterMeterReadingId);
                    Data2.IsActive = false;
                    Data2.IsDisconnected = true;
                   
                    ctx.SaveChanges();

                    var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == waterId);
                    Data.Remarks = obj.Remarks;
                    Data.DisconnectDate = obj.DisconnectDate;
                    Data.IsActive = false;
                    Data.IsPermanentConnection = false;
                    ctx.SaveChanges();
                }
                s.Complete();
                s.Dispose();
                ipk = (int)entity.TrnWaterConnectionId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public List<WaterConnectionModel> fetchWaterConnectionDetails(string watermeterno)
        {
            var data = (from x in ctx.MstWaterConnection.Where(x => x.WaterMeterNo == watermeterno)
                        select new WaterConnectionModel
                        {
                            LandDetailId = x.LandDetailId,
                            WaterConnectionStatusId = x.WaterConnectionStatusId,
                            WaterLineTypeId = x.WaterLineTypeId,
                            WaterMeterTypeId = x.WaterMeterTypeId,
                            ConsumerNo = x.ConsumerNo,
                            ConnectionDate = x.ConnectionDate,
                            SewerageConnection = x.SewerageConnection,
                            WaterConnectionTypeId = x.WaterConnectionTypeId,
                            StandardCosumption =(int) x.StandardConsumption,
                            ZoneId = x.ZoneId,
                            InitialReading = x.InitialReading,
                            OwnerTypeId = x.OwnerTypeId,
                            PrimaryMobileNo = x.PrimaryMobileNo,
                            IsActive = x.IsActive,
                            BillingAddress = x.BillingAddress
                        });
            return data.ToList();
        }

        public IList<TranWaterConnectionModel> GetDisconnectRequests()
        {
            var data = (from x in ctx.TrnWaterConnection.Where(x=> x.ApprovalStatusId == null)
                        join y in ctx.MstLandDetail on x.LandDetailId equals y.LandDetailId
                        join z in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals z.WaterConnectionStatusId
                        join a in ctx.MstWaterMeterType on x.WaterMeterTypeId equals a.WaterMeterTypeId
                        join b in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on x.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstZone on x.ZoneId equals d.ZoneId
                        join e in ctx.EnumOwnerType on x.OwnerTypeId equals e.OwnerTypeId
                        select new TranWaterConnectionModel
                        {
                            TrnWaterConnectionId = x.TrnWaterConnectionId,
                            LandDetailId = x.LandDetailId,
                            PlotNo = y.PlotNo,
                            WaterConnectionStatusId = x.WaterConnectionStatusId,
                            WaterMeterNo = x.WaterMeterNo,
                            WaterMeterTypeId = x.WaterMeterTypeId,
                            ConsumerNo = x.ConsumerNo,
                            ConnectionDate = x.ApplicationDate,
                            WaterConnectionType = b.WaterConnectionType,
                            WaterLineTypeId = x.WaterLineTypeId,
                            StandardCosumption =(int) x.StandardCosumption,
                            BillingAddress = x.BillingAddress,
                            ZoneName = d.ZoneName,
                            FlatNo = x.FlatNo,
                            InitialReading = x.InitialReading,
                            OrganisationName = x.OrganisationName,
                            Remarks = x.Remarks,
                            DisconnectDate = (DateTime)x.DisconnectDate,
                            NoOfUnits = x.NoOfUnits,
                            OwnerTypeId = x.OwnerTypeId,
                            PrimaryMobileNo = x.PrimaryMobileNo,
                        });
            return data.ToList();
        }

        public async Task<TranWaterConnectionModel> DisconnectRequestsDetails(int? id)
        {
            var data = (from a in ctx.TrnWaterConnection.Where(aa => aa.TrnWaterConnectionId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        join c in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals c.WaterConnectionStatusId
                        join d in ctx.MstWaterMeterType on a.WaterMeterTypeId equals d.WaterMeterTypeId
                        join e in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals e.WaterConnectionTypeId
                        join f in ctx.MstWaterLineType on a.WaterLineTypeId equals f.WaterLineTypeId
                        join g in ctx.MstZone on a.ZoneId equals g.ZoneId
                        join h in ctx.EnumOwnerType on a.OwnerTypeId equals h.OwnerTypeId
                        join i in ctx.MstWaterConnection on b.LandDetailId equals i.LandDetailId
                        select new TranWaterConnectionModel
                        {
                            WaterConnectionId = i.WaterConnectionId,
                            TrnWaterConnectionId = a.TrnWaterConnectionId,
                            LandDetailId = a.LandDetailId,
                            WaterConnectionStatusId = a.WaterConnectionStatusId,
                            WaterMeterNo = a.WaterMeterNo,
                            WaterMeterTypeId = a.WaterMeterTypeId,
                            ConsumerNo = a.ConsumerNo,
                            ConnectionDate = a.ApplicationDate,
                            SewerageConnection = a.SewerageConnection,
                            WaterConnectionTypeId = a.WaterConnectionTypeId,
                            WaterLineTypeId = a.WaterLineTypeId,
                            StandardCosumption = (int)a.StandardCosumption,
                            BillingAddress = a.BillingAddress,
                            ZoneId = a.ZoneId,
                            InitialReading = a.InitialReading,
                            OrganisationName = a.OrganisationName,
                            Remarks = a.Remarks,
                            DisconnectDate = (DateTime)a.DisconnectDate,
                            NoOfUnits = a.NoOfUnits,
                            OwnerTypeId = a.OwnerTypeId,
                            ReconnectionDate = (DateTime)a.ReconnectionDate,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            PlotNo = b.PlotNo,
                            WaterConnectionStatus = c.WaterConnectionStatus,
                            WaterMeterType = d.WaterMeterType,
                            WaterConnectionType = e.WaterConnectionType,
                            WaterLineType = f.WaterLineType,
                            ZoneName = g.ZoneName,
                            OwnerType = h.OwnerType,
                            PermanentDisconnect = (a.IsPermanentDisconnect == true ? "Permanent" : "Temporary"),
                            WorkLevelId = a.WorkLevelId,
                            TransactionId = a.TransactionId,
                            IsPermanentDisconnect = a.IsPermanentDisconnect

                        });

            return await data.FirstOrDefaultAsync();
        }

        public int ApproveDisconnectionRequest(TranWaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TrnWaterConnection.FirstOrDefault(u => u.TrnWaterConnectionId == obj.TrnWaterConnectionId);
                    Data.ApprovalStatusId = obj.ApprovalStatusId;
                    ctx.SaveChanges();

                    var data = ctx.MstWaterConnection.FirstOrDefault(x => x.WaterConnectionId == obj.WaterConnectionId);
                    data.IsPermanentDisconnect = obj.IsPermanentDisconnection;
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

        public int RejectDisconnectionRequest(TranWaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TrnWaterConnection.FirstOrDefault(u => u.TrnWaterConnectionId == obj.TrnWaterConnectionId);
                    Data.ApprovalStatusId = obj.ApprovalStatusId;
                    ctx.SaveChanges();

                    //var data = ctx.MstWaterConnection.FirstOrDefault(x => x.WaterConnectionId == obj.WaterConnectionId);
                    //data.IsPermanentDisconnect = obj.IsPermanentDisconnect;
                    //ctx.SaveChanges();
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

        //For Meter Replacement
        public List<TranWaterConnectionModel> fetchWaterConnectionMR(string cid, string ttin, string ConsumerNo, string MeterNo)
        {
            var data = (from a in ctx.TblWaterMeterReading
                        join d in ctx.MstWaterConnection on a.WaterConnectionId equals d.WaterConnectionId
                        join b in ctx.TblLandOwnershipDetail on d.LandOwnershipId equals b.LandOwnershipId
                        join x in ctx.MstTaxPayerProfile on b.TaxPayerId equals x.TaxPayerId
                        join e in ctx.MstLandDetail on d.LandDetailId equals e.LandDetailId
                            into d_temp
                        from d_value in d_temp.DefaultIfEmpty()
                        where (d.ConsumerNo == ConsumerNo || d.WaterMeterNo == MeterNo || x.Cid == cid || x.Ttin == ttin) && d.IsActive == true
                
                        select new TranWaterConnectionModel
                        {
                            LandDetailId= d_value.LandDetailId,
                            ThramNo = b.ThramNo,
                            location = d_value.Location,
                            PlotNo = d_value.PlotNo,
                            ConsumerNo = d.ConsumerNo,
                            WaterMeterNo = d.WaterMeterNo,
                            IsActive = d.IsActive,
                            WaterConnectionId = d.WaterConnectionId

                        });
            return data.ToList();
        }

        public List<TranWaterConnectionModel> getWaterConnectionDetailsMR(int? id)
        {
            var data = (from x in ctx.TblWaterMeterReading.Where(x => x.WaterMeterReadingId == id)
                        join q in ctx.MstWaterConnection on x.WaterConnectionId equals q.WaterConnectionId
                        join y in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals y.WaterConnectionTypeId
                        join z in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals z.WaterConnectionStatusId
                        join a in ctx.MstWaterMeterType on x.WaterMeterTypeId equals a.WaterMeterTypeId
                        join b in ctx.MstLandDetail on q.LandDetailId equals b.LandDetailId
                        join ow in ctx.TblLandOwnershipDetail on q.LandOwnershipId equals ow.LandOwnershipId
                        join tp in ctx.MstTaxPayerProfile on ow.TaxPayerId equals tp.TaxPayerId
                        join c in ctx.MstWaterLineType on x.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.EnumOwnerType on q.OwnerTypeId equals d.OwnerTypeId
                        join e in ctx.MstZone on x.ZoneId equals e.ZoneId


                        select new TranWaterConnectionModel
                        {
                            WaterConnectionId = x.WaterConnectionId,
                            WaterConnectionStatusId = q.WaterConnectionStatusId,
                            WaterConnectionTypeId = q.WaterConnectionTypeId,
                            WaterMeterTypeId = q.WaterMeterTypeId,
                            LandDetailId = b.LandDetailId,
                            WaterLineTypeId = q.WaterLineTypeId,
                            OwnerTypeId = q.OwnerTypeId,
                            ZoneId = q.ZoneId,
                            ConsumerNo = q.ConsumerNo,
                            WaterMeterNo = q.WaterMeterNo,
                            WaterConnectionTypeName = y.WaterConnectionType,
                            WaterConnectionStatus = z.WaterConnectionStatus,
                            SewerageConnection = q.SewerageConnection,
                            BillingAddress = q.BillingAddress,
                            NoOfUnits = q.NoOfUnits,
                            WaterMeterType = a.WaterMeterType,
                            FlatNo = q.FlatNo,
                            StandardCosumption =(int) q.StandardConsumption,
                            PlotNo = b.PlotNo,
                            CreatedOn = q.CreatedOn,
                            WaterLineType = c.WaterLineType,
                            InitialReading = q.InitialReading,
                            OwnerType = d.OwnerType,
                            Remarks = q.Remarks,
                            ZoneName = e.ZoneName,
                            IsActive = q.IsActive,
                            PrimaryMobileNo = q.PrimaryMobileNo,
                            ConnectionDate = q.ConnectionDate,
                            SolidWaste = q.SolidWaste,
                            TaxPayerId = tp.TaxPayerId,
                            previousReading = x.PreviousReading,
                            previousReadingDate = x.PreviousReadingDate,
                            Reading = x.Reading,
                            ReadingDate = x.ReadingDate,
                            ReconnectionDate = (DateTime)q.ReconnectionDate,
                            OrganisationName = q.OrganisationName,
                            DisconnectDate = (DateTime)q.DisconnectDate,
                            ChangeTypeId = (int)q.ChangeTypeId,
                            SewarageConnectionDate = (DateTime)q.SewarageConnectionDate,
                            SewarageConnectedBy = (int)q.SewarageConnectedBy,
                            IsPermanentDisconnect = q.IsPermanentDisconnect,
                            LandOwnershipId = q.LandOwnershipId



                        });
            return data.ToList();
        }


        public List<TranWaterConnectionModel> fetchPlotDetails(string plotno)
        {
            var data = (from a in ctx.MstLandDetail.Where(x => x.PlotNo == plotno)

                        select new TranWaterConnectionModel
                        {
                            PlotNo = a.PlotNo,
                            PlotAddress = a.PlotAddress,
                            location = a.Location


                        });
            return data.ToList();
        }

        public int SaveWaterMeterReplacementwithourDemand(TranWaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                var mef = ctx.MstSlab.Where(x => x.TaxId == 42).Max(x => x.EffectiveDate);
                var slab = ctx.MstSlab.Single(x => x.TaxId == 42 && x.WaterLineTypeId == obj.WaterLineTypeId && x.EffectiveDate == mef);
                var rateData = ctx.MstRate.Single(x => x.SlabId == slab.SlabId);
                int TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 8,
                    WorkLevelId = 3,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    TransactionValue = rateData.Rate
                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = (int)TRNEntity.TransactionId;


                
               int ipk;
                var entity = new TrnWaterConnection
                {
                    LandDetailId = obj.LandDetailId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    WaterMeterNo = obj.WaterMeterNo,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    ConsumerNo = obj.ConsumerNo,
                    ApplicationDate = obj.ApplicationDate,
                    SewerageConnection = obj.SewerageConnection,
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    StandardCosumption = obj.StandardCosumption,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingAddress = obj.BillingAddress,
                    ZoneId = obj.ZoneId,
                    FlatNo = obj.FlatNo,
                    InitialReading = obj.InitialReading,
                    OrganisationName = obj.OrganisationName,
                    IsActive = true,
                    Remarks = obj.Remarks,
                    ReUse = obj.ReUse,
                    DisconnectDate = obj.DisconnectDate,
                    NoOfUnits = obj.NoOfUnits,
                    OwnerTypeId = obj.OwnerTypeId,
                    ChangeTypeId = (short?)obj.ChangeTypeId,
                    ReconnectionDate = DateTime.Now,
                    SewarageConnectionDate = obj.SewarageConnectionDate,
                    SewarageConnectedBy = obj.SewarageConnectedBy,
                    PrimaryMobileNo = obj.PrimaryMobileNo,
                    SecondaryMobileNo = obj.SecondaryMobileNo,
                    TransactionId = TransactionId,
                    IsPermanentDisconnect = obj.IsPermanentDisconnect,
                    LandOwnershipId = obj.LandOwnershipId,
                    ReadingDate = DateTime.Now,
                    PreviousReadingDate = obj.previousReadingDate,
                    PreviousReading = obj.previousReading,
                    WorkLevelId = 3,
                    OldWaterConnectionId = obj.OldWaterConnectionId
                };
                ctx.TrnWaterConnection.Add(entity);
                ctx.SaveChanges();

            
                int wcid;
                var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == TransactionId);
                var landDetailId = watertrnDetailData.FirstOrDefault().LandDetailId;
                var landownershipId = watertrnDetailData.FirstOrDefault().LandOwnershipId;
                var WaterconnectionStatusId = watertrnDetailData.FirstOrDefault().WaterConnectionStatusId;
                var OwnerTypeId = watertrnDetailData.FirstOrDefault().OwnerTypeId;
                var ChangeTypeId = watertrnDetailData.FirstOrDefault().ChangeTypeId;
                var MeterNo = watertrnDetailData.FirstOrDefault().WaterMeterNo;
                var WaterMeterTypeId = watertrnDetailData.FirstOrDefault().WaterMeterTypeId;
                var consNo = watertrnDetailData.FirstOrDefault().ConsumerNo;
                var ConnectionDate = watertrnDetailData.FirstOrDefault().CreatedOn;
                var SewerageConnection = watertrnDetailData.FirstOrDefault().SewerageConnection;
                var WaterConnectionTypeId = watertrnDetailData.FirstOrDefault().WaterConnectionTypeId;
                var StandardCosumption = watertrnDetailData.FirstOrDefault().StandardCosumption;
                var CreatedBy = watertrnDetailData.FirstOrDefault().CreatedBy;
                var CreatedOn = watertrnDetailData.FirstOrDefault().CreatedOn;
                var BillingAddress = watertrnDetailData.FirstOrDefault().BillingAddress;
                var ZoneId = watertrnDetailData.FirstOrDefault().ZoneId;
                var FlatNo = watertrnDetailData.FirstOrDefault().FlatNo;
                var InitialReading = watertrnDetailData.FirstOrDefault().InitialReading;
                var OrganisationName = watertrnDetailData.FirstOrDefault().OrganisationName;
                var IsActive = watertrnDetailData.FirstOrDefault().IsActive;
                var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                var TransactionId1 = watertrnDetailData.FirstOrDefault().TransactionId;
                var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;
                var PreviousReading = watertrnDetailData.FirstOrDefault().PreviousReading;
                var CurrReadingDate = watertrnDetailData.FirstOrDefault().ReadingDate;
                var PreviousReadingDate = watertrnDetailData.FirstOrDefault().PreviousReadingDate;
                var OldWaterConnectionId = watertrnDetailData.FirstOrDefault().OldWaterConnectionId;


                var entitywc = new MstWaterConnection
                {
                    LandDetailId = landDetailId,
                    LandOwnershipId = (int)landownershipId,
                    WaterConnectionStatusId = WaterconnectionStatusId,
                    OwnerTypeId = OwnerTypeId,
                    ChangeTypeId = ChangeTypeId,
                    WaterMeterNo = MeterNo,
                    WaterMeterTypeId = WaterMeterTypeId,
                    ConsumerNo = consNo,
                    ConnectionDate = ConnectionDate,
                    SewerageConnection = SewerageConnection,
                    WaterConnectionTypeId = WaterConnectionTypeId,
                    StandardConsumption = StandardCosumption,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingAddress = BillingAddress,
                    ZoneId = ZoneId,
                    FlatNo = FlatNo,
                    InitialReading = 0,// InitialReading,
                    OrganisationName = OrganisationName,
                    IsActive = IsActive,
                    IsPermanentDisconnect = IsPermanentDisconnect,
                    IsPermanentConnection = true,
                    Remarks = Remarks,
                    DisconnectDate = DisconnectDate,
                    NoOfUnits = NoOfUnits,
                    //ReconnectionDate = ReconnectionDate,
                    SewarageConnectionDate = SewarageConnectionDate,
                    SewarageConnectedBy = SewarageConnectedBy,
                    PrimaryMobileNo = PrimaryMobileNo,
                    SecondaryMobileNo = SecondaryMobileNo,
                    TransactionId = TransactionId,
                    SolidWaste = false,
                    WaterLineTypeId = WaterLineTypeId,

                };
                ctx.MstWaterConnection.Add(entitywc);
                ctx.SaveChanges();
                wcid = entitywc.WaterConnectionId;
                var entitywmr = new TblWaterMeterReading
                {
                    WaterConnectionId = wcid,
                    WaterConnectionStatusId = WaterconnectionStatusId,
                    WaterMeterTypeId = WaterMeterTypeId,
                    WaterConnectionTypeId = WaterConnectionTypeId,
                    StandardConsumption = (int?)StandardCosumption,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingAddress = BillingAddress,
                    ZoneId = ZoneId,
                    FlatNo = FlatNo,
                    IsActive = IsActive,
                    Remarks = Remarks,
                    PrimaryMobileNo = PrimaryMobileNo,
                    SecondaryMobileNo = SecondaryMobileNo,
                    WaterLineTypeId = WaterLineTypeId,
                    IsDisconnected = false,
                    IsRead = false,
                    PreviousReading = 0,
                    PreviousReadingDate = (DateTime)PreviousReadingDate,
                    NoOfUnit = NoOfUnits,
                    Consumption = 0,
                    IsPermanentConnection = true,
                    Sewerage = true,
                    SolidWaste = false,
                    Reading = 0,
                    ReadingDate = (DateTime)CurrReadingDate,
                    ReadBy = ZoneId,
                    CreateTransactionId = TransactionId,


                };
                ctx.TblWaterMeterReading.Add(entitywmr);
                ctx.SaveChanges();

                var update = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId);
                if (update.Any())
                {
                    update.FirstOrDefault().IsActive = false;
                    update.FirstOrDefault().IsPermanentDisconnect = true;
                    ctx.SaveChanges();
                }

                var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == OldWaterConnectionId).Max(y => y.WaterMeterReadingId);

                var entitywr = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
                entitywr.FirstOrDefault().IsDisconnected = true;
                entitywr.FirstOrDefault().IsActive = false;
                entitywr.FirstOrDefault().IsRead = true;

                ctx.SaveChanges();

                s.Complete();
                s.Dispose();
                ipk = TransactionId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int SaveWaterMeterReplacement(TranWaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                var mef = ctx.MstSlab.Where(x => x.TaxId == 42).Max(x => x.EffectiveDate);
                var slab = ctx.MstSlab.Single(x => x.TaxId == 42 && x.WaterLineTypeId == obj.WaterLineTypeId && x.EffectiveDate == mef);
                var rateData = ctx.MstRate.Single(x => x.SlabId == slab.SlabId);
                int TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 8,
                    WorkLevelId = 3,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    TransactionValue = rateData.Rate
                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = (int)TRNEntity.TransactionId;

                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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

                var entityD = new TblDemand
                {

                    TransactionId = TransactionId,
                    DemandNoId = dnid,
                    TaxId = 42,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = rateData.Rate,
                    TotalAmount = rateData.Rate,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TaxPayerId = obj.TaxPayerId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entityD);
                ctx.SaveChanges();

                int ipk;
                var entity = new TrnWaterConnection
                {
                    LandDetailId = obj.LandDetailId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    WaterMeterNo = obj.WaterMeterNo,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    ConsumerNo = obj.ConsumerNo,
                    ApplicationDate = obj.ApplicationDate,
                    SewerageConnection = obj.SewerageConnection,
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    StandardCosumption = obj.StandardCosumption,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingAddress = obj.BillingAddress,
                    ZoneId = obj.ZoneId,
                    FlatNo = obj.FlatNo,
                    InitialReading = obj.InitialReading,
                    OrganisationName = obj.OrganisationName,
                    IsActive = true,
                    Remarks = obj.Remarks,
                    ReUse = obj.ReUse,
                    DisconnectDate = obj.DisconnectDate,
                    NoOfUnits = obj.NoOfUnits,
                    OwnerTypeId = obj.OwnerTypeId,
                    ChangeTypeId = (short?)obj.ChangeTypeId,
                    ReconnectionDate = DateTime.Now,
                    SewarageConnectionDate = obj.SewarageConnectionDate,
                    SewarageConnectedBy = obj.SewarageConnectedBy,
                    PrimaryMobileNo = obj.PrimaryMobileNo,
                    SecondaryMobileNo = obj.SecondaryMobileNo,
                    TransactionId = TransactionId,
                    IsPermanentDisconnect = obj.IsPermanentDisconnect,
                    LandOwnershipId = obj.LandOwnershipId,
                    ReadingDate = DateTime.Now,
                    PreviousReadingDate = obj.previousReadingDate,
                    PreviousReading = obj.previousReading,
                    WorkLevelId = 3,
                    OldWaterConnectionId = obj.OldWaterConnectionId
                };
                ctx.TrnWaterConnection.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = TransactionId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //SearchBox for MeterShifting and WaterReconnection
        public List<TranWaterConnectionModel> fetchWaterConnections(string cid, string ttin, string ConsumerNo, string MeterNo)
        {
            var data = (from a in ctx.MstTaxPayerProfile
                        //join lo in ctx.TblLandOwnershipDetail on a.TaxPayerId equals lo.TaxPayerId
                        //join wc in ctx.MstWaterConnection on lo.LandDetailId equals wc.LandDetailId
                            //join l in ctx.MstLandDetail on g equals l.LandDetailId
                            //join wc in ctx.MstWaterConnection on g equals wc.LandDetailId
                            join l in ctx.TblLandOwnershipDetail on a.TaxPayerId equals l.TaxPayerId
                            into l_temp
                            from l_value in l_temp.DefaultIfEmpty()

                            join d in ctx.MstWaterConnection on l_value.LandOwnershipId equals d.LandOwnershipId
                            into d_temp
                            from d_value in d_temp.DefaultIfEmpty()
                            //let g = ctx.TblWaterMeterReading.Where(a => a.WaterConnectionId == a.WaterConnectionId).Any(y => y.IsDisconnected)
                        where (d_value.ConsumerNo == ConsumerNo || d_value.WaterMeterNo == MeterNo || a.Cid == cid || a.Ttin == ttin)
                        where d_value.IsActive == false /*&& g == true*/
                        select new TranWaterConnectionModel
                        {

                            TitleId = a.TitleId,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            CAddress = a.CAddress,
                            PhoneNo = a.PhoneNo,
                            Fax = a.Fax,
                            LandDetailId = d_value.LandDetailId,
                            TaxPayerId = a.TaxPayerId,
                            WaterConnectionId = d_value.WaterConnectionId




                        });
            return data.Distinct().ToList();
        }


        //SearchBox for WaterReconnection
        public List<TranWaterConnectionModel> fetchWaterReconnection(string cid, string ttin, string ConsumerNo, string MeterNo)
        {
            var data = (from a in ctx.MstTaxPayerProfile 
                            //join lo in ctx.TblLandOwnershipDetail on a.TaxPayerId equals lo.TaxPayerId
                            //join wc in ctx.MstWaterConnection on lo.LandDetailId equals wc.LandDetailId
                            //join l in ctx.MstLandDetail on g equals l.LandDetailId
                            //join wc in ctx.MstWaterConnection on g equals wc.LandDetailId
                        join l in ctx.TblLandOwnershipDetail on a.TaxPayerId equals l.TaxPayerId
                        into l_temp
                        from l_value in l_temp.DefaultIfEmpty()

                        join d in ctx.MstWaterConnection on l_value.LandOwnershipId equals d.LandOwnershipId
                        into d_temp
                        from d_value in d_temp.DefaultIfEmpty()
                       let g = ctx.TblWaterMeterReading.Where(a => a.WaterConnectionId == a.WaterConnectionId).Any(y => y.IsDisconnected)
                        where (d_value.ConsumerNo == ConsumerNo || d_value.WaterMeterNo == MeterNo || a.Cid == cid || a.Ttin == ttin)
                        where d_value.IsActive == false && g == true
                        select new TranWaterConnectionModel
                        {

                            TitleId = a.TitleId,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            CAddress = a.CAddress,
                            PhoneNo = a.PhoneNo,
                            Fax = a.Fax,
                            LandDetailId = d_value.LandDetailId,
                            TaxPayerId = a.TaxPayerId,
                            WaterConnectionId = d_value.WaterConnectionId




                        });
            return data.Distinct().ToList();
        }
        //Displaying LandDetails
        public List<LandDetailModel> GetLandDetails(int? id)
        {
            var data = (from x in ctx.MstWaterConnection. Where(x => x.WaterConnectionId == id && x.IsActive == false)
                            join z in ctx.MstLandDetail on x.LandDetailId equals z.LandDetailId
                        select new LandDetailModel
                        {
                            LandDetailId = x.LandDetailId,
                            PlotNo = z.PlotNo,
                            LandAcerage = z.LandAcerage,
                            WaterMeterNo = x.WaterMeterNo,
                            WaterConnectionId = x.WaterConnectionId


                        });
            return data.ToList();
        }


        //Water Reconnection Start//
        public List<TranWaterConnectionModel> GetDisconnectWaterDetails(int? id)
        {
            var data = /*(from x in ctx.MstWaterConnection.Where(x => x.WaterConnectionId == id)*/
             (from x in ctx.TblWaterMeterReading.Where(x => x.WaterConnectionId == id)
                        join a in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals a.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on x.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals d.WaterConnectionStatusId
                        //let g = ctx.TblWaterMeterReading.Where(x => x.WaterConnectionId == x.WaterConnectionId).Any(y => y.IsDisconnected)
                        join r in ctx.MstWaterConnection on x.WaterConnectionId equals r.WaterConnectionId
                        where (x.IsDisconnected == true)
                        select new TranWaterConnectionModel
                        {

                            WaterConnectionStatus = d.WaterConnectionStatus,
                            WaterMeterNo = r.WaterMeterNo,
                            ConsumerNo = r.ConsumerNo,
                            WaterLineType = c.WaterLineType,
                            WaterConnectionType = a.WaterConnectionType,
                            ConnectionDate = r.ConnectionDate,
                            WaterConnectionId = x.WaterConnectionId,
                            WaterMeterReadingId = (int)x.WaterMeterReadingId,
                        });
            return data.ToList();
        }

        public List<TranWaterConnectionModel> WaterMerterReadingMReconnection(int? id)
        {
            var data = (from x in ctx.TblWaterMeterReading.Where(x => x.WaterMeterReadingId == id).Take(5).OrderByDescending(x => x.WaterMeterReadingId)
                        join r in ctx.MstWaterConnection on x.WaterConnectionId equals r.WaterConnectionId
                        join z in ctx.MstZone on r.ZoneId equals z.ZoneId
                        select new TranWaterConnectionModel
                        {

                            WaterConnectionId = x.WaterConnectionId,
                            ConsumerNo = r.ConsumerNo,
                            WaterMeterNo = r.WaterMeterNo,
                            BillingAddress = r.BillingAddress,
                            ZoneName = z.ZoneName,
                            Reading = x.Reading,
                            ReadingDate = x.ReadingDate,
                            previousReading = x.PreviousReading,
                            previousReadingDate = x.PreviousReadingDate,
                        });
            return data.ToList();
        }

        public int Savewaterreconnection(TranWaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                var mef = ctx.MstSlab.Where(x => x.TaxId == 41).Max(x => x.EffectiveDate);
                var slab = ctx.MstSlab.Single(x => x.TaxId == 41 && x.EffectiveDate == mef);
                var rateData = ctx.MstRate.Single(x => x.SlabId == slab.SlabId);


                var DataWaterMeterReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == obj.OldWaterConnectionId).Max(u => u.WaterMeterReadingId);
                var DataWaterMeterReading = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == DataWaterMeterReadingId);
                var pr = DataWaterMeterReading.FirstOrDefault().PreviousReading;
                var prd = DataWaterMeterReading.FirstOrDefault().PreviousReadingDate;
                var cr = DataWaterMeterReading.FirstOrDefault().Reading;
                var crd = DataWaterMeterReading.FirstOrDefault().ReadingDate;

                int TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 7,
                    WorkLevelId = 1,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    TransactionValue = rateData.Rate
                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = (int)TRNEntity.TransactionId;

                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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

                var entityD = new TblDemand
                {

                    TransactionId = TransactionId,
                    DemandNoId = dnid,
                    TaxId = 41,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = rateData.Rate,
                    TotalAmount = rateData.Rate,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TaxPayerId = obj.TaxPayerId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entityD);
                ctx.SaveChanges();

                int ipk;
                var entity = new TrnWaterConnection
                {
                    LandDetailId = obj.LandDetailId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    WaterMeterNo = obj.WaterMeterNo,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    ConsumerNo = obj.ConsumerNo,
                    ApplicationDate = obj.ApplicationDate,
                    SewerageConnection = obj.SewerageConnection,
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    StandardCosumption = obj.StandardCosumption,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingAddress = obj.BillingAddress,
                    ZoneId = obj.ZoneId,
                    FlatNo = obj.FlatNo,                  
                    OrganisationName = obj.OrganisationName,
                    IsActive = true,
                    Remarks = obj.Remarks,
                    ReUse = obj.ReUse,
                    DisconnectDate = obj.DisconnectDate,
                    NoOfUnits = obj.NoOfUnits,
                    OwnerTypeId = obj.OwnerTypeId,
                    ChangeTypeId = (short?)obj.ChangeTypeId,
                    ReconnectionDate =DateTime.Now,
                    SewarageConnectionDate = obj.SewarageConnectionDate,
                    SewarageConnectedBy = obj.SewarageConnectedBy,
                    PrimaryMobileNo = obj.PrimaryMobileNo,
                    SecondaryMobileNo = obj.SecondaryMobileNo,
                    TransactionId = TransactionId,
                    IsPermanentDisconnect = obj.IsPermanentDisconnect,
                    LandOwnershipId = obj.LandOwnershipId,
                    ReadingDate = DateTime.Now,
                    InitialReading = obj.InitialReading,
                    PreviousReadingDate = obj.previousReadingDate,
                    PreviousReading = obj.previousReading,
                    WorkLevelId = obj.WorkLevelId,
                    OldWaterConnectionId = obj.OldWaterConnectionId
                    
                };
                ctx.TrnWaterConnection.Add(entity);
                ctx.SaveChanges();
                //RECONNECT WC

                //var Data = ctx.MstWaterConnection.Where(u =>u.IsActive==false && u.WaterConnectionId == obj.OldWaterConnectionId);// TO BE UPDATED
                //Data.FirstOrDefault().IsActive = true;
                //Data.FirstOrDefault().IsPermanentDisconnect = false ;
                //ctx.SaveChanges();

                //var trntypeid = ctx.TblTransactionDetail.Single(t => t.TransactionId == TransactionId).TransactionTypeId;
               
                 
                //    var watertrnDetailData = ctx.TrnWaterConnection.Single(w => w.TransactionId == TransactionId);
                //    var landDetailId = watertrnDetailData.LandDetailId;
                //    var landownershipId = watertrnDetailData.LandOwnershipId;
                //    var WaterconnectionStatusId = watertrnDetailData.WaterConnectionStatusId;
                //    var OwnerTypeId = watertrnDetailData.OwnerTypeId;
                //    var ChangeTypeId = watertrnDetailData.ChangeTypeId;
                //    var MeterNo = watertrnDetailData.WaterMeterNo;
                //    var WaterMeterTypeId = watertrnDetailData.WaterMeterTypeId;
                //    var consNo = watertrnDetailData.ConsumerNo;
                //    var SewerageConnection = watertrnDetailData.SewerageConnection;
                //    var WaterConnectionTypeId = watertrnDetailData.WaterConnectionTypeId;
                //    var StandardCosumption = watertrnDetailData.StandardCosumption;
                //    var BillingAddress = watertrnDetailData.BillingAddress;
                //    var ZoneId = watertrnDetailData.ZoneId;
                //    var FlatNo = watertrnDetailData.FlatNo;
                //    var InitialReading = watertrnDetailData.InitialReading;
                //    var OrganisationName = watertrnDetailData.OrganisationName;
                //    var Remarks = watertrnDetailData.Remarks;
                //    var NoOfUnits = watertrnDetailData.NoOfUnits;
                //    var ReconnectionDate = watertrnDetailData.ReconnectionDate;
                //    var SewarageConnectionDate = watertrnDetailData.SewarageConnectionDate;
                //    var SewarageConnectedBy = watertrnDetailData.SewarageConnectedBy;
                //    var PrimaryMobileNo = watertrnDetailData.PrimaryMobileNo;
                //    var SecondaryMobileNo = watertrnDetailData.SecondaryMobileNo;
                //    var WaterLineTypeId = watertrnDetailData.WaterLineTypeId;
                //    var OldWaterConnectionId = watertrnDetailData.OldWaterConnectionId;

                //var entitywmr = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == OldWaterConnectionId);
                //entitywmr.FirstOrDefault().IsDisconnected = false;
                //entitywmr.FirstOrDefault().IsRead = true;
                
               // ctx.SaveChanges();

                //DEMAND GENERATE WR

                


                s.Complete();
                s.Dispose();
                ipk = TransactionId;

                return TransactionId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
      

        public List<TranWaterConnectionModel> DisplayWaterReconnectionDetail(int? id)
        {
            var data = (from x in ctx.MstWaterConnection.Where(x => x.WaterConnectionId == id)
                        join a in ctx.TblWaterMeterReading on x.WaterConnectionId equals a.WaterConnectionId
                        join c in ctx.TblLandOwnershipDetail on x.LandOwnershipId equals c.LandOwnershipId
                        join d in ctx.MstTaxPayerProfile on c.TaxPayerId equals d.TaxPayerId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join z in ctx.MstZone on x.ZoneId equals z.ZoneId

                        //join b in ctx.MstWaterConnection on a.WaterConnectionId equals b.WaterConnectionId

                        select new TranWaterConnectionModel
                        {
                           LandDetailId = x.LandDetailId,
                           WaterConnectionStatusId = x.WaterConnectionStatusId,
                           WaterMeterNo = x.WaterMeterNo,
                           WaterMeterTypeId = x.WaterMeterTypeId,
                           ConsumerNo = x.ConsumerNo,
                           PlotNo = l.PlotNo,
                           ZoneName = z.ZoneName,
                           //ApplicationDate = x.ApplicationDate,
                           SewerageConnection = x.SewerageConnection,
                           WaterConnectionTypeId = x.WaterConnectionTypeId,
                           WaterLineTypeId = x.WaterLineTypeId,
                           StandardCosumption = (int)x.StandardConsumption,
                           BillingAddress = x.BillingAddress,
                           ZoneId = x.ZoneId,
                           FlatNo = x.FlatNo,
                           InitialReading = x.InitialReading,
                           OrganisationName = x.OrganisationName,
                           //ReUse = x.Reuse,
                           DisconnectDate = (DateTime)x.DisconnectDate,
                           NoOfUnits = x.NoOfUnits,
                           OwnerTypeId = x.OwnerTypeId,
                           ChangeTypeId = (int)x.ChangeTypeId,
                           ReconnectionDate = (DateTime)x.ReconnectionDate,
                           previousReadingDate = a.PreviousReadingDate,
                           previousReading = a.PreviousReading,
                           ReadingDate = a.ReadingDate,
                           SewarageConnectionDate = (DateTime)x.SewarageConnectionDate,
                           SewarageConnectedBy = (int)x.SewarageConnectedBy,
                           PrimaryMobileNo = x.PrimaryMobileNo,
                           SecondaryMobileNo = x.SecondaryMobileNo,
                           //WorkLevelId = x.WorkLevelId,
                           TransactionId = (long)x.TransactionId,
                           IsPermanentDisconnection = x.IsPermanentConnection,
                           //ApprovalStatusId = x.ApprovalStatusId,
                           LandOwnershipId = x.LandOwnershipId,
                           WaterConnectionId = x.WaterConnectionId,
                           TaxPayerId = d.TaxPayerId
                        });
            return data.ToList();
        }
        //Water Reconnection End//


        //Meter Shifting Start//
        public List<TranWaterConnectionModel> GetWaterMeterDetails(int id)
        {
            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerId == id)
                        join i in ctx.TblLandOwnershipDetail on x.TaxPayerId equals i.TaxPayerId
                        join j in ctx.MstLandDetail on i.LandDetailId equals j.LandDetailId
                        join k in ctx.MstWaterConnection on i.LandDetailId equals k.LandDetailId
                        join a in ctx.MstWaterConnectionType on k.WaterConnectionTypeId equals a.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on k.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.EnumWaterConnectionStatus on k.WaterConnectionStatusId equals d.WaterConnectionStatusId
                        join g in ctx.TblWaterMeterReading on k.WaterConnectionId equals g.WaterConnectionId
                        join h in ctx.MstZone on k.ZoneId equals h.ZoneId

                        where (g.IsActive == true)

                        select new TranWaterConnectionModel
                        {

                            WaterConnectionStatus = d.WaterConnectionStatus,
                            WaterMeterNo = k.WaterMeterNo,
                            ConsumerNo = k.ConsumerNo,
                            WaterLineType = c.WaterLineType,
                            WaterConnectionType = a.WaterConnectionType,
                            WaterConnectionId = k.WaterConnectionId,
                            ZoneName = h.ZoneName,
                            WaterConnectionStatusId = k.WaterConnectionStatusId,
                            PlotNo = j.PlotNo,
                            BillingAddress = k.BillingAddress,
                            TaxPayerId = i.TaxPayerId,
                            LandDetailId = i.LandDetailId,
                            ConnectionDate = k.ConnectionDate,
                            IsActive = (bool)g.IsActive
                        });
            return data.ToList();
        }

        public List<TranWaterConnectionModel> DisplayMeterShiftingDetail(int id)
        {
            var data = (from x in ctx.MstWaterConnection.Where(x => x.WaterConnectionId == id)
                        join a in ctx.TblWaterMeterReading on x.WaterConnectionId equals a.WaterConnectionId
                        join c in ctx.TblLandOwnershipDetail on x.LandOwnershipId equals c.LandOwnershipId
                        join d in ctx.MstTaxPayerProfile on c.TaxPayerId equals d.TaxPayerId
                        join z in ctx.MstZone on x.ZoneId equals z.ZoneId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        //join b in ctx.MstWaterConnection on a.WaterConnectionId equals b.WaterConnectionId

                        select new TranWaterConnectionModel
                        {
                            LandDetailId = x.LandDetailId,
                            WaterConnectionStatusId = x.WaterConnectionStatusId,
                            WaterMeterNo = x.WaterMeterNo,
                            WaterMeterTypeId = x.WaterMeterTypeId,
                            ConsumerNo = x.ConsumerNo,                            
                            SewerageConnection = x.SewerageConnection,
                            WaterConnectionTypeId = x.WaterConnectionTypeId,
                            WaterLineTypeId = x.WaterLineTypeId,
                            StandardCosumption = (int)x.StandardConsumption,
                            BillingAddress = x.BillingAddress,
                            ZoneId = x.ZoneId,
                            ZoneName = z.ZoneName, 
                            FlatNo = x.FlatNo,
                            InitialReading = x.InitialReading,
                            OrganisationName = x.OrganisationName,
                            PlotNo = l.PlotNo,
                            DisconnectDate = (DateTime)x.DisconnectDate,
                            NoOfUnits = x.NoOfUnits,
                            OwnerTypeId = x.OwnerTypeId,
                            ChangeTypeId = (int)x.ChangeTypeId,
                            ReconnectionDate = (DateTime)x.ReconnectionDate,
                            ReadingDate = a.ReadingDate,
                            previousReadingDate = a.PreviousReadingDate,
                            previousReading = a.PreviousReading,
                            SewarageConnectionDate = (DateTime)x.SewarageConnectionDate,
                            SewarageConnectedBy = (int)x.SewarageConnectedBy,
                            PrimaryMobileNo = x.PrimaryMobileNo,
                            SecondaryMobileNo = x.SecondaryMobileNo,
                            //WorkLevelId = x.WorkLevelId,
                            TransactionId = (long)x.TransactionId,
                            IsPermanentDisconnection = x.IsPermanentConnection,
                            //ApprovalStatusId = x.ApprovalStatusId,
                            LandOwnershipId = x.LandOwnershipId,
                            WaterConnectionId = x.WaterConnectionId,
                            TaxPayerId = d.TaxPayerId


                        });
            return data.ToList();
        }

        public int Savewatermetershifting(TranWaterConnectionModel obj)
        {

            try
            {
                using TransactionScope s = new TransactionScope();
                var mef = ctx.MstSlab.Where(x => x.TaxId == 57).Max(x=>x.EffectiveDate);
                var slab = ctx.MstSlab.Single(x => x.TaxId == 57 && x.EffectiveDate == mef) ;
                var rateData = ctx.MstRate.Single(x => x.SlabId==slab.SlabId);

                int TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 22,
                    WorkLevelId = 1,
                    TransactionValue = rateData.Rate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = (int)TRNEntity.TransactionId;

                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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

                var entityD = new TblDemand
                {

                    TransactionId = TransactionId,
                    DemandNoId = dnid,
                    TaxId = 57,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = rateData.Rate,
                    TotalAmount = rateData.Rate,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TaxPayerId = obj.TaxPayerId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entityD);
                ctx.SaveChanges();

                int ipk;
                var entity = new TrnWaterConnection
                {
                    LandDetailId = obj.LandDetailId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    WaterMeterNo = obj.WaterMeterNo,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    ConsumerNo = obj.ConsumerNo,
                    ApplicationDate = obj.ApplicationDate,
                    SewerageConnection = obj.SewerageConnection,
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    StandardCosumption = obj.StandardCosumption,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    BillingAddress = obj.BillingAddress,
                    ZoneId = obj.ZoneId,
                    FlatNo = obj.FlatNo,
                    InitialReading = obj.InitialReading,
                    OrganisationName = obj.OrganisationName,
                    IsActive = true,
                    Remarks = obj.Remarks,
                    ReUse = obj.ReUse,
                    DisconnectDate = obj.DisconnectDate,
                    NoOfUnits = obj.NoOfUnits,
                    OwnerTypeId = obj.OwnerTypeId,
                    ChangeTypeId = (short?)obj.ChangeTypeId,
                    ReconnectionDate = DateTime.Now,
                    SewarageConnectionDate = obj.SewarageConnectionDate,
                    SewarageConnectedBy = obj.SewarageConnectedBy,
                    PrimaryMobileNo = obj.PrimaryMobileNo,
                    SecondaryMobileNo = obj.SecondaryMobileNo,
                    TransactionId = TransactionId,
                    IsPermanentDisconnect = obj.IsPermanentDisconnect,
                    LandOwnershipId = obj.LandOwnershipId,
                    ReadingDate = DateTime.Now,
                    PreviousReadingDate = obj.previousReadingDate,
                    PreviousReading = obj.previousReading,
                    WorkLevelId = obj.WorkLevelId,
                    OldWaterConnectionId = obj.OldWaterConnectionId


                };
                ctx.TrnWaterConnection.Add(entity);
                ctx.SaveChanges();
                var trntypeid = ctx.TblTransactionDetail.Single(t => t.TransactionId == TransactionId).TransactionTypeId;


                var watertrnDetailData = ctx.TrnWaterConnection.Single(w => w.TransactionId == TransactionId);
                var landDetailId = watertrnDetailData.LandDetailId;
                var landownershipId = watertrnDetailData.LandOwnershipId;
                var WaterconnectionStatusId = watertrnDetailData.WaterConnectionStatusId;
                var OwnerTypeId = watertrnDetailData.OwnerTypeId;
                var ChangeTypeId = watertrnDetailData.ChangeTypeId;
                var MeterNo = watertrnDetailData.WaterMeterNo;
                var WaterMeterTypeId = watertrnDetailData.WaterMeterTypeId;
                var consNo = watertrnDetailData.ConsumerNo;
                var SewerageConnection = watertrnDetailData.SewerageConnection;
                var WaterConnectionTypeId = watertrnDetailData.WaterConnectionTypeId;
                var StandardCosumption = watertrnDetailData.StandardCosumption;
                var BillingAddress = watertrnDetailData.BillingAddress;
                var ZoneId = watertrnDetailData.ZoneId;
                var FlatNo = watertrnDetailData.FlatNo;
                var InitialReading = watertrnDetailData.InitialReading;
                var OrganisationName = watertrnDetailData.OrganisationName;
                var Remarks = watertrnDetailData.Remarks;
                var NoOfUnits = watertrnDetailData.NoOfUnits;
                var ReconnectionDate = watertrnDetailData.ReconnectionDate;
                var SewarageConnectionDate = watertrnDetailData.SewarageConnectionDate;
                var SewarageConnectedBy = watertrnDetailData.SewarageConnectedBy;
                var PrimaryMobileNo = watertrnDetailData.PrimaryMobileNo;
                var SecondaryMobileNo = watertrnDetailData.SecondaryMobileNo;
                var WaterLineTypeId = watertrnDetailData.WaterLineTypeId;
                var OldWaterConnectionId = watertrnDetailData.OldWaterConnectionId;
                s.Complete();
                s.Dispose();
                ipk = TransactionId;

                return TransactionId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //Meter Shifting End

        //Water Reconnection DashBoard
        public IList<TranWaterConnectionModel> GetReconnectionRequests(bool id)
        {
            var data = (from x in ctx.TrnWaterConnection.Where(x => x.IsPermanentDisconnect == false)
                        join y in ctx.MstLandDetail on x.LandDetailId equals y.LandDetailId
                        join z in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals z.WaterConnectionStatusId
                        join a in ctx.MstWaterMeterType on x.WaterMeterTypeId equals a.WaterMeterTypeId
                        join b in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on x.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstZone on x.ZoneId equals d.ZoneId
                        join f in ctx.TblTransactionDetail on x.TransactionId equals f.TransactionId
                        join e in ctx.EnumOwnerType on x.OwnerTypeId equals e.OwnerTypeId
                        where(f.TransactionTypeId == 7)
                        select new TranWaterConnectionModel
                        {
                            TrnWaterConnectionId = x.TrnWaterConnectionId,
                            LandDetailId = x.LandDetailId,
                            PlotNo = y.PlotNo,
                            WaterMeterNo = x.WaterMeterNo,
                            ConsumerNo = x.ConsumerNo,
                            ConnectionDate = x.ApplicationDate,
                            BillingAddress = x.BillingAddress,
                            DisconnectDate = (DateTime)x.DisconnectDate,
                        });
            return data.ToList();
        }
        public List<TranWaterConnectionModel> GetReconnectionDetail(int? id)
        {
            var data = (from x in ctx.TrnWaterConnection.Where(x => x.TrnWaterConnectionId == id)
                        join a in ctx.MstLandDetail on x.LandDetailId equals a.LandDetailId
                        join b in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals b.WaterConnectionStatusId
                        join c in ctx.MstWaterMeterType on x.WaterMeterTypeId equals c.WaterMeterTypeId
                        join d in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals d.WaterConnectionTypeId
                        join e in ctx.MstWaterLineType on x.WaterLineTypeId equals e.WaterLineTypeId
                        join f in ctx.MstZone on x.ZoneId equals f.ZoneId
                        select new TranWaterConnectionModel
                        {
                           WaterMeterNo = x.WaterMeterNo,
                           ConsumerNo = x.ConsumerNo,
                           PlotNo = a.PlotNo,
                           WaterConnectionStatus = b.WaterConnectionStatus,
                           WaterMeterType = c.WaterMeterType,
                           ConnectionDate = x.ApplicationDate,
                           WaterConnectionType = d.WaterConnectionType,
                           WaterLineType = e.WaterLineType,
                           StandardCosumption = (int)x.StandardCosumption,
                           BillingAddress = x.BillingAddress,
                           ZoneName = f.ZoneName,
                           FlatNo = x.FlatNo,
                           InitialReading = x.InitialReading,
                           DisconnectDate = (DateTime)x.DisconnectDate,
                           NoOfUnits = x.NoOfUnits,
                           ReconnectionDate = (DateTime)x.ReconnectionDate,
                           PhoneNo = x.PrimaryMobileNo,
                           TrnWaterConnectionId = x.TrnWaterConnectionId,
                           TransactionId = x.TransactionId
                                                   
                        });
            return data.ToList();
        }

        public int ApproveReconnectionRequest(TranWaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TrnWaterConnection.FirstOrDefault(u => u.TrnWaterConnectionId == obj.TrnWaterConnectionId);
                    Data.WorkLevelId = obj.WorkLevelId; Data.ApprovalStatusId = obj.ApprovalStatusId;
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

        public int RejectReconnectionRequest(TranWaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TrnWaterConnection.FirstOrDefault(u => u.TrnWaterConnectionId == obj.TrnWaterConnectionId);
                    Data.WorkLevelId = obj.WorkLevelId; Data.ApprovalStatusId = obj.ApprovalStatusId;
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

        //UPDATE REAMRKS FOR REJECTION
        public int UpdateRejectedRemarks(TranWaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TrnWaterConnection.FirstOrDefault(u => u.TrnWaterConnectionId == obj.TrnWaterConnectionId);
                    Data.Remarks = obj.Remarks;
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

        //WATER RECEIPT
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
        public IList<LedgerDemandVM> WaterDemandReceipt(long TransactionId)
        {
            var DataDemand = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
            var lDemandId = DataDemand.FirstOrDefault().DemandNoId;
            var rn = ctx.TblDemandNo.Where(d => d.DemandNoId == lDemandId).Max(x => x.DemandNo);

            var data = (from a in ctx.TblDemand.Where(a => a.TransactionId == TransactionId)
                        join d in ctx.TblDemandNo on a.DemandNoId equals d.DemandNoId
                        join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                        join tp in ctx.MstTaxPayerProfile on a.TaxPayerId equals tp.TaxPayerId
                        join cn in ctx.TrnWaterConnection on a.TransactionId equals cn.TransactionId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId                   
                        let netamt = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Sum(t => t.TotalAmount)
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            consumerNo = cn.ConsumerNo,
                            WaterMeterNO = cn.WaterMeterNo,
                            NetAmount = netamt,
                            DemandNo = d.DemandNo,
                            TaxName = t.TaxName,
                            DemandAmount = a.DemandAmount,
                            TotalAmount = a.TotalAmount,
                            CreatedOn = d.CreatedOn,
                            BillingDate = a.BillingDate,
                            FirstName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            //Caddress = tp.CAddress,
                            BillingAddress = cn.BillingAddress,
                            PhoneNo = cn.PrimaryMobileNo,



                        });

            return data.ToList();
        }





        //*************************** Print demand receipt***************************************
        
        public List<WaterconnectionDemandVM> PrintDemandWater(int TransactionId)
        {
            var DataDemand = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
            var DemandNoId = DataDemand.FirstOrDefault().DemandNoId;
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);


            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                            //join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join t in ctx.TrnWaterConnection on x.TransactionId equals t.TransactionId
                        join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId

                        let netamt = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Sum(t => t.TotalAmount)
                        //let BillingDate = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Max(t => t.BillingDate)
                        let qr = GenerateQr(dn.ToString())

                        select new WaterconnectionDemandVM
                        {
                            QrImage = qr,
                            CreatedOn = x.CreatedOn,
                            TaxId = x.TaxId,
                            TaxName = z.TaxName,
                            DemandNo = dn,
                            Createdby = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                            Name = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            MobileNo = tp.MobileNo,
                            Cid = tp.Cid,
                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            ConsumerNo = t.ConsumerNo,
                            BillingAddress = t.BillingAddress,
                            WaterMeterNo = t.WaterMeterNo


                        });
            return data.ToList();
        }

        public List<WaterconnectionDemandVM> checkpayment(int WaterConnectionId)
        {
           
             var data = (from x in ctx.MstWaterConnection.Where(x => x.WaterConnectionId == WaterConnectionId)
                            //join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.TblWaterMeterReading on x.WaterConnectionId equals z.WaterConnectionId
                        join t in ctx.TblDemand on z.WaterMeterReadingId equals t.WaterMeterReadingId
                        where t.IsPaymentMade == false
                       

                        select new WaterconnectionDemandVM
                        {
                            
                             IsPaymentMade = t.IsPaymentMade,
                             TransactionId = (long)t.WaterMeterReadingId

                        });
            return data.ToList();
        }


  //SEWERAGE CONNECTION
        public int SaveSewerage(TranWaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                var wcef = ctx.MstSlab.Where(x => x.TaxId == 43).Max(x => x.EffectiveDate);
                var wcslab = ctx.MstSlab.Single(x => x.TaxId == 43 && x.EffectiveDate == wcef);
                var RateData = ctx.MstRate.Single(x => x.SlabId == wcslab.SlabId);

                long TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 5,
                    WorkLevelId = 3,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    TransactionValue = RateData.Rate

                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = TRNEntity.TransactionId;

                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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

                var entityD = new TblDemand
                {

                    TransactionId = TransactionId,
                    DemandNoId = dnid,
                    TaxId = 43,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = RateData.Rate,
                    TotalAmount = RateData.Rate,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TaxPayerId = obj.TaxPayerId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entityD);
                ctx.SaveChanges();

                WorkLevelId = (int)TRNEntity.WorkLevelId;

                int ipk;
                var entity = new TrnSewerageConnection
                {
                    SewerageConnectionId = obj.SewerageConnectionId,
                    Amount = RateData.Rate,
                    MobileNo = obj.PhoneNo,
                    ContactAddress = obj.CAddress,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    TransactionId = TransactionId,
                    LandOwnershipId = (int)obj.LandOwnershipId,
                    
                    
                };
                ctx.TrnSewerageConnection.Add(entity);
                ctx.SaveChanges();
                ipk = (int)entity.SewerageConnectionId;
                s.Complete();
                s.Dispose();


                return (int)TransactionId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IList<SewerageConnectionVM> GetSewerage()
        {
            var data = (from x in ctx.TrnSewerageConnection
                        join f in ctx.TblLandOwnershipDetail on x.LandOwnershipId equals f.LandOwnershipId
                        join y in ctx.MstLandDetail on f.LandDetailId equals y.LandDetailId
                        join h in ctx.MstTaxPayerProfile on f.TaxPayerId equals h.TaxPayerId

                        select new SewerageConnectionVM
                        {
                            PlotNo = y.PlotNo,
                            TTIN = h.Ttin,
                            Amount = x.Amount,
                            MobileNo = x.MobileNo,
                            ContactAddress = x.ContactAddress
                        });
            return data.ToList();

        }

        //*************************** PRINT SEWERAGE DEMAND**************************************

        public List<WaterconnectionDemandVM> PrintDemandSewerage(int TransactionId)
        {
            var DataDemand = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
            var DemandNoId = DataDemand.FirstOrDefault().DemandNoId;
            var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);


            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                            //join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join t in ctx.TrnSewerageConnection on x.TransactionId equals t.TransactionId
                        join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId

                        let netamt = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Sum(t => t.TotalAmount)
                        //let BillingDate = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Max(t => t.BillingDate)
                        let qr = GenerateQr(dn.ToString())

                        select new WaterconnectionDemandVM
                        {
                            QrImage = qr,
                            CreatedOn = x.CreatedOn,
                            TaxId = x.TaxId,
                            TaxName = z.TaxName,
                            DemandNo = dn,
                            Createdby = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                            Name = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            MobileNo = tp.MobileNo,
                            Cid = tp.Cid,
                            TotalAmount = netamt,
                            Amount = x.TotalAmount,


                        });
            return data.ToList();
        }




        public long upgrade(TranWaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                var wcef = ctx.MstSlab.Where(x => x.TaxId == 75).Max(x => x.EffectiveDate);
                var wcslab = ctx.MstSlab.Single(x => x.TaxId == 75 && x.EffectiveDate == wcef);
                var NWCrateData = ctx.MstRate.Single(x => x.SlabId == wcslab.SlabId);

                var mef = ctx.MstSlab.Where(x => x.TaxId == 40).Max(x => x.EffectiveDate);
                var slab = ctx.MstSlab.Single(x => x.TaxId == 40 && x.WaterLineTypeId == obj.WaterLineTypeId && x.EffectiveDate == mef);
                var rateData = ctx.MstRate.Single(x => x.SlabId == slab.SlabId);


                long TransactionId;
                int WorkLevelId;
                var TRNEntity = new TblTransactionDetail
                {
                    TransactionTypeId = 43,
                    WorkLevelId = 3,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                    TransactionValue = rateData.Rate

                };
                ctx.TblTransactionDetail.Add(TRNEntity);
                ctx.SaveChanges();
                TransactionId = TRNEntity.TransactionId;

                int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
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

                var entityD = new TblDemand
                {

                    TransactionId = TransactionId,
                    DemandNoId = dnid,
                    TaxId = 82,
                    FinancialYearId = Convert.ToInt32(fyr),
                    CalendarYearId = cyr,
                    DemandAmount = rateData.Rate,
                    TotalAmount = rateData.Rate,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    TaxPayerId = obj.TaxPayerId,
                    CreatedBy = obj.CreatedBy,
                    WaterMeterReadingId = obj.WaterMeterReadingId,
                    CreatedOn = DateTime.Now,
                    BillingDate = DateTime.Now
                };
                ctx.TblDemand.Add(entityD);
                ctx.SaveChanges();

                var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == obj.WaterConnectionId).Max(y => y.WaterMeterReadingId);

                var watertrnDetailData = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
              

               
                var WaterconnectionStatusId = watertrnDetailData.FirstOrDefault().WaterConnectionStatusId;
                 var WaterConnectionTypeId = watertrnDetailData.FirstOrDefault().WaterConnectionTypeId;
                var CreatedBy = watertrnDetailData.FirstOrDefault().CreatedBy;
                var CreatedOn = watertrnDetailData.FirstOrDefault().CreatedOn;
                var BillingAddress = watertrnDetailData.FirstOrDefault().BillingAddress;
                var ZoneId = watertrnDetailData.FirstOrDefault().ZoneId;
                var FlatNo = watertrnDetailData.FirstOrDefault().FlatNo;
                var IsActive = watertrnDetailData.FirstOrDefault().IsActive;
                var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnit;
                var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;
                var PreviousReading = watertrnDetailData.FirstOrDefault().PreviousReading;



                var wc = ctx.MstWaterConnection.Where(w => w.WaterConnectionId == obj.WaterConnectionId);


                var ConsumerNo = wc.FirstOrDefault().ConsumerNo;
                var WaterMeterNo = wc.FirstOrDefault().WaterMeterNo;
                var OwnerTypeId = wc.FirstOrDefault().OwnerTypeId;
                var ChangeTypeId = wc.FirstOrDefault().ChangeTypeId;
                var OrganisationName = wc.FirstOrDefault().OrganisationName;

                var entitywmr = new TrnWaterConnection
                {


                    OldWaterConnectionId = obj.WaterConnectionId,
                    WaterConnectionStatusId = WaterconnectionStatusId,
                    LandDetailId = obj.LandDetailId,
                    LandOwnershipId = obj.LandOwnershipId,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    WaterConnectionTypeId = WaterConnectionTypeId,
                    StandardCosumption = obj.StandardCosumption,
                    CreatedBy = CreatedBy,
                    CreatedOn = DateTime.Now,
                    BillingAddress = BillingAddress,
                    ZoneId = ZoneId,
                    FlatNo = FlatNo,
                    IsActive = false,
                    Remarks = Remarks,
                    PrimaryMobileNo = PrimaryMobileNo,
                    SecondaryMobileNo = SecondaryMobileNo,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    IsPermanentDisconnect = false,
                    IsPermanent = true,
                    PreviousReading = (int)PreviousReading,
                    PreviousReadingDate = DateTime.Now,
                    NoOfUnits = NoOfUnits,
                    InitialReading = (int)obj.InitialReading,
                    ReadingDate = DateTime.Now,
                    TransactionId = TransactionId,
                    WorkLevelId = 3,
                    ConsumerNo = ConsumerNo,
                    WaterMeterNo = WaterMeterNo,
                    OwnerTypeId = OwnerTypeId,
                    ChangeTypeId = ChangeTypeId,
                    OrganisationName = OrganisationName,
                    ApplicationDate = DateTime.Now
                    

                };
                ctx.TrnWaterConnection.Add(entitywmr);
                ctx.SaveChanges();


            s.Complete();
                s.Dispose();


                return TransactionId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
            //*************************** Print demand receipt***************************************
            public List<WaterconnectionDemandVM> Printupgrade(int TransactionId)
         
            {
                var DataDemand = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Take(1);
                var DemandNoId = DataDemand.FirstOrDefault().DemandNoId;
                var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);


            var data = (from x in ctx.TblDemand.Where(x => x.TransactionId == TransactionId)
                            //join y in ctx.TblTransactionDetail on x.TransactionId equals y.TransactionId
                            join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join t in ctx.TblWaterMeterReading on x.WaterMeterReadingId equals t.WaterMeterReadingId
                        join w in ctx.MstWaterConnection on t.WaterConnectionId equals w.WaterConnectionId

                        join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                            join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId

                            let netamt = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Sum(t => t.TotalAmount)
                            //let BillingDate = ctx.TblDemand.Where(l => l.TransactionId == TransactionId).Max(t => t.BillingDate)
                            let qr = GenerateQr(dn.ToString())

                            select new WaterconnectionDemandVM
                            {
                                QrImage = qr,
                                CreatedOn = x.CreatedOn,
                                TaxId = x.TaxId,
                                TaxName = z.TaxName,
                                DemandNo = dn,
                                Createdby = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                                Name = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                                MobileNo = tp.MobileNo,
                                Cid = tp.Cid,
                                TotalAmount = netamt,
                                Amount = x.TotalAmount,
                                ConsumerNo = w.ConsumerNo,
                                BillingAddress = t.BillingAddress,
                                WaterMeterNo = w.WaterMeterNo


                            });
                return data.ToList();
            }

        
    }
}

