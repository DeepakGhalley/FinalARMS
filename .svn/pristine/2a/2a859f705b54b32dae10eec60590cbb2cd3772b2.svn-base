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
    public class BfsFailedOnlineTransactionDetailBLL : IBfsFailedOnlineTransactionDetails
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public List<LedgerDemandVM> Search(string search)
        {
            var WaterReading = (
                  from x in ctx.MstWaterConnection.Where(x => x.ConsumerNo == search)
                  join y in ctx.TblWaterMeterReading on x.WaterConnectionId equals y.WaterConnectionId
                  select y.TransactionId).ToList();

            var data = (from x in ctx.TblDemand.Where(x => WaterReading.Contains(x.TransactionId))
                        .OrderBy(xx => xx.TransactionId)
                        .OrderBy(xx => xx.TaxPayerId)
                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                        where x.IsPaymentMade == false && x.IsCancelled == false
                        let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                        let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                        let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                        select new LedgerDemandVM
                        {
                            TotalAmount = cuc_sum,
                            DemandNoId = x.DemandNoId,
                            DemandAmount = cuc_sumd,
                            ExemptionAmount = cuc_sume,
                            ExemptionLetter = x.ExemptionLetter,
                            DemandNo = y.DemandNo,
                            CreatedOn = (ctx.TblDemand.Where(t => t.DemandNoId == x.DemandNoId).Max(m => m.CreatedOn))
                        }).Distinct();

            return (List<LedgerDemandVM>)data.ToList();
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public IList<LedgerDemandVM> GetDemandDetail(string id, DateTime paymentdate)
        {
            string[] ids = id.Split(',');
            int[] trntypeIds = {19};

            var data = (from x in ctx.TblDemand.Where(x => x.IsCancelled == false && ids.Contains(x.DemandNoId.ToString()))

                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join c in ctx.MstCalendarYear on x.CalendarYearId equals c.CalendarYearId
                         into c_temp
                        from c_value in c_temp.DefaultIfEmpty()
                        join p in ctx.MstTaxPeriod on new { t.TransactionTypeId, x.CalendarYearId } equals new { p.TransactionTypeId, p.CalendarYearId }
                        into p_temp
                        from p_value in p_temp.DefaultIfEmpty()
                        where trntypeIds.Contains(t.TransactionTypeId) ? x.CalendarYearId == p_value.CalendarYearId : 0 == 0 

                        let TotalAmt = ctx.TblDemand.Where(x => x.IsCancelled == false && ids.Contains(x.DemandNoId.ToString())).Sum(x => x.TotalAmount)

                        orderby x.TransactionId ascending, x.TaxPayerId ascending, x.DemandNoId ascending

                        select new LedgerDemandVM
                        {
                            MiscellaneousRecordId = x.MiscellaneousRecordId,
                            DemandId = x.DemandId,
                            TransactionId = x.TransactionId,
                            DemandNoId = x.DemandNoId,
                            TaxId = x.TaxId,
                            FinancialYearId = x.FinancialYearId,
                            CalendarYearId = x.CalendarYearId,
                            DemandAmount = x.DemandAmount,
                            TotalAmount = x.TotalAmount,
                            ExemptionAmount = x.ExemptionAmount,
                            ExemptionLetter = x.ExemptionLetter,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            DemandNo = y.DemandNo,
                            TaxName = z.TaxName,
                            GrandTotalAmount = TotalAmt,
                            LandLeaseDemandDetailId = x.LandLeaseDemandDetailId,
                            TransactionTypeId = (ctx.TblTransactionDetail.Where(t => t.TransactionId == x.TransactionId).Max(m => m.TransactionTypeId)),

                            Rate = p_value.PenaltyOrRate,
                            PenaltyDays = t.TransactionTypeId == 19 ? GetMonthDifference(x.BillingDate, paymentdate) :
                                        0,


                            TotalPenaltyAmount =
                                t.TransactionTypeId == 19 ? ((p_value.PenaltyOrRate * x.TotalAmount) * GetMonthDifference(x.BillingDate, paymentdate) / (12 * 100)) : 0

        }).Distinct();

            return (IList<LedgerDemandVM>)data.ToList();
        }

        public IList<LedgerDemandVM> CheckDuplicatePayment(string id)
        {
            ////Split the string to an array

            string[] ids = id.Split(',');

            var data = (from x in ctx.TblLedger.Where(x => ids.Contains(x.DemandId.ToString()))

                            //join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            //join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId

                            // orderby x.TransactionId ascending, x.TaxPayerId ascending, x.DemandNoId ascending

                        select new LedgerDemandVM
                        {
                            DemandId = x.DemandId,
                            //TransactionId = x.TransactionId,
                            //DemandNoId = x.DemandNoId,
                            //TaxId = x.TaxId,
                            //FinancialYearId = x.FinancialYearId,
                            //CalendarYearId = x.CalendarYearId,
                            //DemandAmount = x.DemandAmount,
                            //TotalAmount = x.TotalAmount,
                            //ExemptionAmount = x.ExemptionAmount,
                            //ExemptionLetter = x.ExemptionLetter,
                            //CreatedBy = x.CreatedBy,
                            //CreatedOn = x.CreatedOn,
                            //DemandNo = y.DemandNo,
                            //TaxName = z.TaxName
                        });

            return (IList<LedgerDemandVM>)data.ToList();
        }

        public long CreateLedger(LedgerDemandVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                string[] ids = obj.Ids.Split(',');
                var demand = (ctx.TblDemand.Where(x => ids.Contains(x.DemandId.ToString())));
                long pk, lpk;

                int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                sq = sq + 1;
                var entityR = new TblReceipt
                {
                    ReceiptNo = ("TT/" + (DateTime.Now.Year) + "/" + sq),
                    Sl = sq,
                    ReceiptYear = DateTime.Now.Year,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.PaymentDate,
                };
                ctx.TblReceipt.Add(entityR);
                ctx.SaveChanges();
                pk = entityR.ReceiptId;
                
                foreach (var item in demand.ToList())
                {
                    var dmd = ctx.TblDemand.Single(d => d.IsCancelled == false && d.DemandId == item.DemandId);
                    var trn = ctx.TblTransactionDetail.Single(t => t.TransactionId == item.TransactionId);

                    var cy = ctx.MstCalendarYear.Single(t => t.CalendarYearId == item.CalendarYearId);

                    var tp = ctx.MstTaxPeriod.Where(t => t.TransactionTypeId == trn.TransactionTypeId && t.CalendarYearId == cy.CalendarYearId);
                    var entity = new TblLedger
                    {
                        DemandId = item.DemandId,
                        TransactionId = item.TransactionId,
                        TaxId = item.TaxId,
                        FinancialYearId = item.FinancialYearId,
                        CalendarYearId = item.CalendarYearId,
                        LandDetailId = item.LandDetailId,
                        LandOwnershipId = item.LandOwnershipId,
                        TaxPayerId = item.TaxPayerId,
                        TotalAmount = item.TotalAmount,
                        PaymentDate = obj.PaymentDate,
                        ReceiptId = pk,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = obj.PaymentDate,
                        PenaltyPeriod = trn.TransactionTypeId == 19 ? GetMonthDifference(dmd.BillingDate,obj.PaymentDate) :0,
                        PenaltyAmount =
                        trn.TransactionTypeId == 19 ? ((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) * GetMonthDifference(dmd.BillingDate, obj.PaymentDate) / (12 * 100)) :
                        0,
                        ApplicantId = item.ApplicantId,
                        EcRenewalId = item.EcRenewalId,
                        LandLeaseDemandDetailId = item.LandLeaseDemandDetailId,
                        ParkingDemandDetailId = item.ParkingDemandDetailId,
                        StallDemandDetailId = item.StallDemandDetailId,
                        HouseRentDemandDetailId = item.HouseRentDemandDetailId,
                        MiscellaneousRecordId = item.MiscellaneousRecordId,
                        WaterMeterReadingId = item.WaterMeterReadingId,
                    };
                    ctx.TblLedger.Add(entity);
                    ctx.SaveChanges();
                    lpk = entity.LedgerId;

                }


                var Data = ctx.TblDemand.Where(u => u.IsCancelled == false && ids.Contains(u.DemandId.ToString()));

                foreach (var item in Data)
                {
                    var Data1 = ctx.TblDemand.Where(u => u.DemandId == item.DemandId);

                    Data1.FirstOrDefault().IsPaymentMade = true;
                    Data1.FirstOrDefault().PaymentDate = obj.PaymentDate;
                    ctx.SaveChanges();
                }

                var trnid = Data.FirstOrDefault().TransactionId;
                var trntypeid = ctx.TblTransactionDetail.Where(t => t.TransactionId == trnid).FirstOrDefault().TransactionTypeId;
                //*************************************************New Water Connection*****************************************************************************************************
                if (trntypeid == 2)
                {
                    int wcid;
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
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
                    var IsPermanentConnection = watertrnDetailData.FirstOrDefault().IsPermanent;
                    var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                    var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                    var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                    var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                    var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                    var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                    var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                    var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                    var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
                    var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;

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
                        InitialReading = InitialReading,
                        OrganisationName = OrganisationName,
                        IsActive = IsActive,
                        IsPermanentDisconnect = IsPermanentDisconnect,
                        IsPermanentConnection = IsPermanentConnection,
                        Remarks = Remarks,
                        DisconnectDate = DisconnectDate,
                        NoOfUnits = NoOfUnits,
                        ReconnectionDate = ReconnectionDate,
                        SewarageConnectionDate = SewarageConnectionDate,
                        SewarageConnectedBy = SewarageConnectedBy,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        TransactionId = TransactionId,
                        SolidWaste = false,
                        WaterLineTypeId = WaterLineTypeId

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
                        PreviousReadingDate = DateTime.Now,
                        NoOfUnit = NoOfUnits,
                        Consumption = 0,
                        IsPermanentConnection = true,
                        Sewerage = true,
                        SolidWaste = false,
                        Reading = 0,
                        ReadingDate = DateTime.Now,
                        ReadBy = ZoneId,
                        CreateTransactionId = TransactionId,
                        TransactionId = null
                    };
                    ctx.TblWaterMeterReading.Add(entitywmr);
                    ctx.SaveChanges();
                }
                //**************************************************Reconnection******************************************************************************************
                else if (trntypeid == 7)
                {
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
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
                    var IsPermanent = watertrnDetailData.FirstOrDefault().IsPermanent;
                    var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                    var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                    var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                    var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                    var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                    var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                    var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                    var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
                    var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;
                    var OldWaterConnectionId = watertrnDetailData.FirstOrDefault().OldWaterConnectionId;
                    var PreviousReading = watertrnDetailData.FirstOrDefault().PreviousReading;

                    var ReconnectData = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId);

                    ReconnectData.FirstOrDefault().IsActive = true;
                    ReconnectData.FirstOrDefault().IsPermanentDisconnect = false;
                    ctx.SaveChanges();
                    var entitywmr = new TblWaterMeterReading
                    {
                        WaterConnectionId = (int)OldWaterConnectionId,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        WaterMeterTypeId = WaterMeterTypeId,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = (int?)StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        IsActive = true,
                        Remarks = Remarks,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        WaterLineTypeId = WaterLineTypeId,
                        IsDisconnected = false,
                        IsRead = false,
                        PreviousReading = (int)PreviousReading,
                        PreviousReadingDate = DateTime.Now,
                        NoOfUnit = NoOfUnits,
                        Consumption = 0,
                        IsPermanentConnection = (bool)IsPermanent,
                        Sewerage = true,
                        SolidWaste = false,
                        Reading = (int)PreviousReading,
                        ReadingDate = DateTime.Now,
                        ReadBy = ZoneId,
                        CreateTransactionId = TransactionId,

                    };
                    ctx.TblWaterMeterReading.Add(entitywmr);
                    ctx.SaveChanges();


                }


                ////***********************************************Meter Replacement ***************************************************************************
                if (trntypeid == 8)
                {
                    int wcid;
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
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
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
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
                }
                var Delete = ctx.TrnWaterConnection.Where(u => u.TransactionId == trnid);
                if (Delete.Any())
                {
                    Delete.FirstOrDefault().WorkLevelId = 4;
                    ctx.SaveChanges();
                }
                //*******************************************************************shifting ***************************************************************************************************************
                //*******************************************************************disconnection ***************************************************************************************************************
                if (trntypeid == 21)
                {
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
                    var OldWaterConnectionId = watertrnDetailData.FirstOrDefault().OldWaterConnectionId;

                    var dwm = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId);
                    if (dwm.Any())
                    {
                        dwm.FirstOrDefault().IsActive = false;
                        dwm.FirstOrDefault().IsPermanentDisconnect = true;
                        ctx.SaveChanges();
                    }

                    var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == OldWaterConnectionId).Max(y => y.WaterMeterReadingId);

                    var entitywr = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
                    entitywr.FirstOrDefault().IsDisconnected = true;
                    entitywr.FirstOrDefault().IsActive = false;
                    entitywr.FirstOrDefault().IsRead = true;

                    ctx.SaveChanges();
                }
                //********************************************************************************upgrade/downgrade****************************************************************************************

                if (trntypeid == 43)
                {

                    int wcid;
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
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
                    var IsPermanent = watertrnDetailData.FirstOrDefault().IsPermanent;
                    var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                    var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                    var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                    var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                    var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                    var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                    var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                    var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                    var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
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
                        InitialReading = InitialReading,
                        OrganisationName = OrganisationName,
                        IsActive = IsActive,
                        IsPermanentDisconnect = IsPermanentDisconnect,
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
                        IsPermanentConnection = IsPermanent,
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
                        PreviousReading = (int)PreviousReading,
                        PreviousReadingDate = (DateTime)PreviousReadingDate,
                        NoOfUnit = NoOfUnits,
                        Consumption = 0,
                        IsPermanentConnection = (bool)IsPermanent,
                        Sewerage = true,
                        SolidWaste = false,
                        Reading = (int)InitialReading,
                        ReadingDate = (DateTime)CurrReadingDate,
                        ReadBy = ZoneId,
                        CreateTransactionId = TransactionId,

                    };
                    ctx.TblWaterMeterReading.Add(entitywmr);
                    ctx.SaveChanges();

                    var update = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId && IsActive == true);
                    if (update.Any())
                    {
                        update.FirstOrDefault().IsActive = false;
                        update.FirstOrDefault().IsPermanentDisconnect = true;
                        ctx.SaveChanges();
                    }

                    var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == OldWaterConnectionId && IsActive == true).Max(y => y.WaterMeterReadingId);

                    var entitywr = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
                    entitywr.FirstOrDefault().IsDisconnected = true;
                    entitywr.FirstOrDefault().IsActive = false;
                    ctx.SaveChanges();
                }
                var change = ctx.TrnWaterConnection.Where(u => u.TransactionId == trnid);
                if (change.Any())
                {
                    change.FirstOrDefault().WorkLevelId = 4;
                    ctx.SaveChanges();
                }

                var w = ctx.TblTransactionDetail.Where(u => u.TransactionId == trnid);
                if (w.Any())
                {
                    w.FirstOrDefault().WorkLevelId = 4;
                    ctx.SaveChanges();
                }
                s.Complete();
                s.Dispose();

                return pk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public long CreatePaymentLedger(LedgerPaymentLedgerModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                long pk;

                var entity = new TblPaymentLeger
                {

                    PaymentModeId = obj.PaymentModeId,
                    PaymentModeNo = obj.PaymentModeNo,
                    PaymentModeDate = obj.PaymentModeDate,
                    Amount = obj.Amount,
                    BankBranchId = obj.BankBranchId,
                    ReceiptId = obj.ReceiptId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblPaymentLeger.Add(entity);
                ctx.SaveChanges();
                pk = entity.ReceiptId;

                var DataL = ctx.TblLedger.Where(u => u.ReceiptId == pk).ToList();


                foreach (var itemL in DataL)
                {
                    long ldgid = itemL.LedgerId;
                    var Datau = ctx.TblLedger.Where(u => u.LedgerId == ldgid);

                    Datau.FirstOrDefault().CreatedBy = obj.CreatedBy;
                    ctx.SaveChanges();
                }               

                var DataPL = ctx.TblPaymentLeger.Where(u => u.ReceiptId == pk);

                DataPL.FirstOrDefault().CreatedBy = obj.CreatedBy;
                ctx.SaveChanges();

                var DataR = ctx.TblReceipt.Where(u => u.ReceiptId == pk);
                DataR.FirstOrDefault().CreatedBy = obj.CreatedBy;
                ctx.SaveChanges();

                s.Complete();
                s.Dispose();

                return pk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
