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
    public class trnWaterConnectionBLL : ItrnWaterConnection
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<TrnWaterConnectionVM> GetAll()
        {
            var data = (from x in ctx.TrnWaterConnection
                        join y in ctx.MstLandDetail on x.LandDetailId equals y.LandDetailId
                        join z in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals z.WaterConnectionStatusId
                        join a in ctx.MstWaterMeterType on x.WaterMeterTypeId equals a.WaterMeterTypeId
                        join b in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on x.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstZone on x.ZoneId equals d.ZoneId
                        join e in ctx.EnumOwnerType on x.OwnerTypeId equals e.OwnerTypeId
                        join f in ctx.EnumWorkLevel on x.WorkLevelId equals f.WorkLevelId
                        join g in ctx.TblTransactionDetail on x.TransactionId equals g.TransactionId
                        

                        select new TrnWaterConnectionVM
                        {
                            TrnWaterConnectionId = (int)x.TrnWaterConnectionId,
                            LandDetailId = x.LandDetailId,
                            PlotNo = y.PlotNo,
                            WaterConnectionStatusId = x.WaterConnectionStatusId,
                            waterConnectionStatus = z.WaterConnectionStatus,
                            WaterMeterNo = x.WaterMeterNo,
                            WaterMeterTypeId = x.WaterMeterTypeId,
                            waterMeterType = a.WaterMeterType,
                            ConsumerNo = x.ConsumerNo,
                            ConnectionDate = x.ApplicationDate,
                            SewerageConnection = x.SewerageConnection,
                            WaterConnectionTypeId = x.WaterConnectionTypeId,
                            waterConnectionType = b.WaterConnectionType,
                            WaterLineTypeId = x.WaterLineTypeId,
                            waterLineType = c.WaterLineType,
                            StandardConsumption = x.StandardCosumption,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = (int)x.ModifiedBy,
                            ModifiedOn = (DateTime)x.ModifiedOn,
                            BillingAddress = x.BillingAddress,
                            ZoneId = x.ZoneId,
                            ZoneName = d.ZoneName,
                            FlatNo = x.FlatNo,
                            InitialReading = x.InitialReading,
                            OrganisationName = x.OrganisationName,
                            IsActive = x.IsActive,
                            Remarks = x.Remarks,
                            ReUse = (bool)x.ReUse,
                            DisconnectDate = (DateTime)x.DisconnectDate,
                            NoOfUnits = x.NoOfUnits,
                            OwnerTypeId = x.OwnerTypeId,
                            ownerType = e.OwnerType,
                            ChangeTypeId = x.ChangeTypeId,
                            ReconnectionDate = (DateTime)x.ReconnectionDate,
                            SewerageConnectionDate = (DateTime)x.SewarageConnectionDate,
                            SewerageConnectedBy = (int)x.SewarageConnectedBy,
                            PrimaryMobileNo = x.PrimaryMobileNo,
                            SecondaryMobileNo = x.SecondaryMobileNo,
                            WorkLevelId = x.WorkLevelId,
                            workLevel = f.WorkLevel,
                            TransactionId = (int)x.TransactionId,
                           // transaction = g.Transaction,
                        });
            return data.ToList();

        }

        public async Task<TrnWaterConnectionVM> Details(int? id)
        {
            var data = (from a in ctx.TrnWaterConnection.Where(aa => aa.TrnWaterConnectionId == id)
                        join y in ctx.MstLandDetail on a.LandDetailId equals y.LandDetailId
                        join z in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals z.WaterConnectionStatusId
                        join x in ctx.MstWaterMeterType on a.WaterMeterTypeId equals x.WaterMeterTypeId
                        join b in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on a.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstZone on a.ZoneId equals d.ZoneId
                        join e in ctx.EnumOwnerType on a.OwnerTypeId equals e.OwnerTypeId
                        join f in ctx.EnumWorkLevel on a.WorkLevelId equals f.WorkLevelId
                        join g in ctx.TblTransactionDetail on a.TransactionId equals g.TransactionId

                        select new TrnWaterConnectionVM
                        {
                            TrnWaterConnectionId = (int)a.TrnWaterConnectionId,
                            LandDetailId = a.LandDetailId,
                            PlotNo = y.PlotNo,
                            WaterConnectionStatusId = a.WaterConnectionStatusId,
                            waterConnectionStatus = z.WaterConnectionStatus,
                            WaterMeterNo = a.WaterMeterNo,
                            WaterMeterTypeId = a.WaterMeterTypeId,
                            waterMeterType = x.WaterMeterType,
                            ConsumerNo = a.ConsumerNo,
                            ConnectionDate = a.ApplicationDate,
                            SewerageConnection = a.SewerageConnection,
                            WaterConnectionTypeId = a.WaterConnectionTypeId,
                            waterConnectionType = b.WaterConnectionType,
                            WaterLineTypeId = a.WaterLineTypeId,
                            waterLineType = c.WaterLineType,
                            StandardConsumption = a.StandardCosumption,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = (int)a.ModifiedBy,
                            ModifiedOn = (DateTime)a.ModifiedOn,
                            BillingAddress = a.BillingAddress,
                            ZoneId = a.ZoneId,
                            ZoneName = d.ZoneName,
                            FlatNo = a.FlatNo,
                            InitialReading = a.InitialReading,
                            OrganisationName = a.OrganisationName,
                            IsActive = a.IsActive,
                            Remarks = a.Remarks,
                            ReUse = (bool)a.ReUse,
                            DisconnectDate = (DateTime)a.DisconnectDate,
                            NoOfUnits = a.NoOfUnits,
                            OwnerTypeId = a.OwnerTypeId,
                            ownerType = e.OwnerType,
                            ChangeTypeId = a.ChangeTypeId,
                            ReconnectionDate = (DateTime)a.ReconnectionDate,
                            SewerageConnectionDate = (DateTime)a.SewarageConnectionDate,
                            SewerageConnectedBy = (int)a.SewarageConnectedBy,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            SecondaryMobileNo = a.SecondaryMobileNo,
                            WorkLevelId = a.WorkLevelId,
                            workLevel = f.WorkLevel,
                            TransactionId = (int)a.TransactionId,
                           // transaction = g.Transaction
                            

                        });

            return await data.FirstOrDefaultAsync();

        }
    }
}
