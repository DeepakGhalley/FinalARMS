using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_BLL
{
    public class OnlinePaymentBLL : IOnlinePayment
    {
        readonly tt_dbContext ctx = new tt_dbContext();


        //***** Online PropertyTax Payment *****
        public IList<OnlinePropertyTaxPaymentVM> GetDemandWithSearch(string ttin,string cid)
        {
            var land = (
                  from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == ttin || x.Cid == cid)
                  join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                  select y.TransactionId).ToList();

            var data = (from x in ctx.TblDemand.Where(x =>x.IsCancelled == false && land.Contains(x.TransactionId))
                        .OrderBy(xx => xx.TransactionId)
                        .OrderBy(xx => xx.TaxPayerId)
                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                        join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                        let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                        let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                        where z.TransactionTypeId == 20 && x.IsPaymentMade == false

                        select new OnlinePropertyTaxPaymentVM
                        {
                            TotalAmount = cuc_sum,
                            DemandNoId = x.DemandNoId,
                            DemandAmount = cuc_sumd,
                            ExemptionAmount = cuc_sume,
                            ExemptionLetter = x.ExemptionLetter,
                            DemandNo = y.DemandNo,
                            Name = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            Email = tp.Email

                        }).Distinct();

            return (IList<OnlinePropertyTaxPaymentVM>)data.ToList();
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
        public List<LedgerDemandVM> GetDemandDetail(string id)
        {
            //var dt = DateTime.Today.Day;
            //string idChecked = "1,2,3,4,5";
            ////Split the string to an array
            string[] ids = id.Split(',');
            //var blog = context.Blogs.Where(x => ids.Contains(x.Id.ToString()));
            // var trntypeIds = "15,16,17,18,19,20";
            int[] trntypeIds = { 15, 16, 17, 18, 19, 20 };

            var data = (from x in ctx.TblDemand.Where(x => x.IsCancelled == false && ids.Contains(x.DemandNoId.ToString()))
                            //.OrderBy(xx => xx.TransactionId)
                            //.OrderBy(xx => xx.TaxPayerId)

                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join c in ctx.MstCalendarYear on x.CalendarYearId equals c.CalendarYearId
                         into c_temp
                        from c_value in c_temp.DefaultIfEmpty()
                        join p in ctx.MstTaxPeriod on t.TransactionTypeId equals p.TransactionTypeId
                        into p_temp
                        from p_value in p_temp.DefaultIfEmpty()
                        where trntypeIds.Contains(t.TransactionTypeId) ? x.CalendarYearId == p_value.CalendarYearId : 0 == 0 //     where x.MiscellaneousRecordId == null ?  x.CalendarYearId == p_value.CalendarYearId : 0 == 0

                        //join h in ctx.TblHouseRentDemandDetail on x.HouseRentDemandDetailId equals h.HouseRentDemandDetailId
                        // into h_temp
                        //from h_value in h_temp.DefaultIfEmpty()
                        //join hp in  ctx.TblHouseRentPeriod on h_value.HouseAllocationId equals hp.HouseAllocationId
                        //into hp_temp
                        //from hp_value in hp_temp.DefaultIfEmpty()

                        let TotalAmt = ctx.TblDemand.Where(x => x.IsCancelled == false && ids.Contains(x.DemandNoId.ToString())).Sum(x => x.TotalAmount)
                        //let pdays = t.TransactionTypeId == 19 ? (DateTime.Today - x.BillingDate).Days :
                        //            t.TransactionTypeId == 20 ? (DateTime.Today - c_value.EndDate).Days
                        //            : ((DateTime.Today - x.BillingDate).Days)

                        //let pam = t.TransactionTypeId == 19 ? ((p_value.PenaltyOrRate * TotalAmt) * ((DateTime.Today.Month - x.BillingDate.Month)) / (100)) :
                        //             t.TransactionTypeId == 20 ? ((p_value.PenaltyOrRate * TotalAmt) * ((DateTime.Today - c_value.EndDate).Days) / (365 * 100)) :
                        //            t.TransactionTypeId == 21 ? ((p_value.PenaltyOrRate * TotalAmt) * ((DateTime.Today - x.BillingDate.AddMonths(1)).Days) / (365 * 100)) : 0

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
                            TransactionTypeId = (ctx.TblTransactionDetail.Where(t => t.TransactionId == x.TransactionId).Max(m => m.TransactionTypeId)),

                            tdays = (DateTime.Today - ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate).Days,
                            instmentdate = (ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate),
                            md = GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today),
                            // md = GetMonthDifference(x.BillingDate, DateTime.Today),

                            Rate = p_value.PenaltyOrRate,
                            PenaltyDays = t.TransactionTypeId == 19 ? GetMonthDifference(x.BillingDate, DateTime.Today) :
                                         t.TransactionTypeId == 20 ? ((DateTime.Today - c_value.EndDate).Days) :

                                         //t.TransactionTypeId == 15 ? (DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                         //(GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1) ? 
                                         //GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                         //(GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                         //(DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                         //GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0 :

                                         t.TransactionTypeId == 15 ? (DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0 :


                                        t.TransactionTypeId == 17 ? (DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) : 0 :


                                         t.TransactionTypeId == 18 ? ((DateTime.Today.AddMonths(-1) - (ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == x.ParkingDemandDetailId).InstallmentDate)).Days) ://daily 24%

                                          x.TaxId == 20 ? ((DateTime.Today.AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days) :
                                           x.TaxId == 21 ? 0 :
                                            0,


                            TotalPenaltyAmount =
                                t.TransactionTypeId == 19 ? ((p_value.PenaltyOrRate * x.TotalAmount) * GetMonthDifference(x.BillingDate, DateTime.Today) / (12 * 100)) :
                                t.TransactionTypeId == 20 ? ((p_value.PenaltyOrRate * x.TotalAmount) * (((DateTime.Today - c_value.EndDate).Days) < 0 ? 0 : ((DateTime.Today - c_value.EndDate).Days)) / (365 * 100)) :

                                 // t.TransactionTypeId == 15 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) *( (DateTime.Today< ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate)? 0 : (DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today):0)) :
                                 //t.TransactionTypeId == 15 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) *((DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                 //          (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1) ?
                                 //          GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                 //          (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                 //          (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                 //          GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :

                                 t.TransactionTypeId == 15 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) * ((DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :


                                //  t.TransactionTypeId == 17 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) *( (DateTime.Today< ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate)? 0 :DateTime.Today.Day>10?  GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today):0)) :
                                t.TransactionTypeId == 17 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) * ((DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :


                                t.TransactionTypeId == 18 ? (((p_value.PenaltyOrRate * x.TotalAmount) / (100 * 365)) * ((DateTime.Today.AddMonths(-1) - (ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == x.ParkingDemandDetailId).InstallmentDate)).Days)) :
                                 x.TaxId == 20 ? (((p_value.PenaltyOrRate * x.TotalAmount) / (100 * 365)) * ((DateTime.Today.AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days)) :
                                 x.TaxId == 21 ? Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().Remarks)) :
                                 0
                            //t.TransactionTypeId == 18 ? (((p_value.PenaltyOrRate * x.TotalAmount)/100) * ((GetMonthDifference(ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == x.ParkingDemandDetailId).InstallmentDate, DateTime.Today.AddMonths(-1))) )) : 0                                                                             

                        });

            return (List<LedgerDemandVM>)data.ToList();
        }

        //***** Online Water Bill Payment *****
        public List<OnlineWaterBillPaymentVM> GetDemandWithSearchWaterBill(string ConsumerNo)
        {
            var water = (
                  from x in ctx.MstWaterConnection.Where(x => x.ConsumerNo == ConsumerNo)
                  //join y in ctx.TblDemand on x.LandDetailId equals y.LandDetailId
                  join y in ctx.TblWaterMeterReading on x.WaterConnectionId equals y.WaterConnectionId
                  select y.TransactionId).ToList();

            var data = (from x in ctx.TblDemand.Where(x =>x.IsCancelled == false  && water.Contains(x.TransactionId))
                        .OrderBy(xx => xx.TransactionId)
                        //.OrderBy(xx => xx.TaxPayerId)
                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                        join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                        let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                        let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                        let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                        where z.TransactionTypeId == 19 && x.IsPaymentMade == false

                        select new OnlineWaterBillPaymentVM
                        {
                            TotalAmount = cuc_sum,
                            DemandNoId = x.DemandNoId,
                            DemandAmount = cuc_sumd,
                            ExemptionAmount = cuc_sume,
                            ExemptionLetter = x.ExemptionLetter,
                            DemandNo = y.DemandNo,

                        }).Distinct();

            return (List<OnlineWaterBillPaymentVM>)data.ToList();
        }

        public List<OnlineWaterBillPaymentVM> GetDemandDetailWaterBill(string id)
        {
            //string idChecked = "1,2,3,4,5";
            ////Split the string to an arra
            string[] ids = id.Split(',');
            //var blog = context.Blogs.Where(x => ids.Contains(x.Id.ToString()));

            var data = (from x in ctx.TblDemand.Where(x => ids.Contains(x.DemandNoId.ToString()))
                        join d in ctx.MstTaxMaster on x.TaxId equals d.TaxId
                        join f in ctx.MstCalendarYear on x.CalendarYearId equals f.CalendarYearId
                        join c in ctx.TblTransactionDetail on x.TransactionId equals c.TransactionId
                        join p in ctx.MstLandDetail on x.LandDetailId equals p.LandDetailId
                        join a in ctx.MstWaterConnection on x.LandDetailId equals a.LandDetailId
                        where c.TransactionTypeId == 19 && x.IsPaymentMade == false



                        orderby x.TransactionId ascending, x.TaxPayerId ascending, x.DemandNoId ascending

                        select new OnlineWaterBillPaymentVM
                        {
                            DemandId = x.DemandId,
                            TransactionId = x.TransactionId,
                            DemandNoId = x.DemandNoId,
                            CalendarYear = f.CalendarYear,
                            DemandAmount = x.DemandAmount,
                            TotalAmount = x.TotalAmount,
                            TaxName = d.TaxName,
                            PlotAddress = p.PlotAddress,
                            PlotNo = p.PlotNo,
                            ConsumerNo = a.ConsumerNo,
                            MeterNo = a.WaterMeterNo
                        });

            return data.ToList();
        }  
        public async  Task< IEnumerable<menuvm>> GetMenu()
        {
            ////using tt_dbContext 
            //return ctx.Queryasync<menuvm>("");

            var data = (from x in ctx.TblMenu.Where(x => x.Isactive == 1)

                        select new menuvm
                        {
                            menu_id = x.MenuId,
                            menu_name = x.MenuName,
                            area_name = x.AreaName,
                            controller_name = x.ControllerName,
                            action_name = x.ActionName,
                            //MenuParentId = x.MenuParentId,
                            orderFor = x.OrderFor,

                        });

            return  data;
        }

        //public IEnumerable<menuvm> GetMenu2(int Id, int yr, string StartDate, string EndDate)
        //{
        //    try
        //    {
        //        var result = ctx.StallRentDemandSchedule.FromSqlRaw($"GetStallDemandScheduleMonthly {Id}, {yr},{StartDate},{EndDate}");

        //        return result.ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;

        //    }
        //}



    }
}
