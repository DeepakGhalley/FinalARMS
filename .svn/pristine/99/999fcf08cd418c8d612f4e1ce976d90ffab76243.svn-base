using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CORE_BLL
{
    public class ReportBLL : IReports
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public IEnumerable<ReportVM> GetDailyHeadWiseDemandCollection(int StartDate, int EndDate)
        {
            try
            {

                // StartDate = Convert.ToDateTime("20/01/2021"); EndDate = Convert.ToDateTime("20/06/2021");
                var result = ctx.DailyWiseReport.FromSqlRaw($"rptGetDailyHeadWiseDemandCollection {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<FinancialYearWiseReportVM> GetYearlyHeadWiseDemandCollection(int FinancialYearId)
        {
            try
            {
                var result = ctx.FinancialYearWiseReport.FromSqlRaw($"rptGetYearlyHeadWiseDemandCollection {FinancialYearId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<DailyPaymentModeWisedemandCollectionVM> GetDailyPaymentModeWiseDemandCollection(int StartDate, int EndDate)
        {
            try
            {
                var result = ctx.DailyPaymentModeWiseDemandCollection.FromSqlRaw($"[dbo].[rptDailyPaymentWiseDemandCollection] {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }

        //public IEnumerable<DailyReceiptWiseCollection>GetDailyRecepitWiseCollection(int FromDate, int ToDate)
        //{
        //    try
        //    {

        //        // StartDate = Convert.ToDateTime("20/01/2021"); EndDate = Convert.ToDateTime("20/06/2021");
        //        var result = ctx.GetDailyRecepitWiseCollection.FromSqlRaw($"[dbo].[rptDailyReceiptWiseCollectionByFromDateToDate] {FromDate},{ToDate}");

        //        return result.ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;

        //    }
        //}


        //Reconcil Report
        public IEnumerable<ReconcilingReport> GetReconcilingReport(int FromDate, int ToDate)
        {
            try
            {

                var result = ctx.GetReconcilingReport.FromSqlRaw($"[dbo].[rptReconcilReport] {FromDate},{ToDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public IEnumerable<TaxRateVM> GetTaxRate(int TransactionTypeId)
        {
            try
            {
                var result = ctx.GetTaxRate.FromSqlRaw($"rptGetTaxRates {TransactionTypeId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //Individual Report
        public IEnumerable<IndividaulReceiptWiseDemandCollection> GetIndividualReceiptWiseCollection(int FromDate, int ToDate)
        {
            try
            {
                var result = ctx.IndividaulReceiptWiseCollection.FromSqlRaw($"[dbo].[rptIndividualReceiptWiseCollection] {FromDate},{ToDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }
        public IList<IndividualDetails> GetAll()
        {
            var data = (from x in ctx.TblPaymentLeger
                        join un in ctx.AspNetUsers on x.CreatedBy equals un.UserId
                        select new IndividualDetails
                        {
                            CreatedBy = un.FirstName + " " + ((un.MiddleName == null || un.MiddleName.Trim() == string.Empty) ? string.Empty : (un.MiddleName + " ")) + ((un.LastName == null || un.LastName.Trim() == string.Empty) ? string.Empty : (un.LastName + " ")),

                        });
            return data.ToList();
        }

        //Defaulter Property List
        public IEnumerable<DefaulterPropertyList> GetDefaulterPropertyList(string CalendarYear)
        {
            try
            {
                var result = ctx.GetDefaulterPropertyList.FromSqlRaw($"[dbo].[rptDefaulterPropertyList] {CalendarYear}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }

        //Defaulter Property List
        public IEnumerable<DefaulterWaterList> GetDefaulterWaterList()
        {
            try
            {
                var result = ctx.GetDefaulterWaterList.FromSqlRaw($"[dbo].[rptDefaulterWaterList]");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }

        public IEnumerable<DailyMinorHeadWiseCollection> GetDailyMinorHeadWiseCollection(int FromDate, int ToDate)
        {
            try
            {

                // StartDate = Convert.ToDateTime("20/01/2021"); EndDate = Convert.ToDateTime("20/06/2021");
                var result = ctx.DailyMinorHeadWise.FromSqlRaw($"rptMinorHeadWiseCollectionbytofromdate {FromDate},{ToDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<YearlyMinorHeadWiseCollection> GetYearlyMinorHeadWiseCollection(int CalendarYearId)
        {
            try
            {
                var result = ctx.YearlyMinorHeadWise.FromSqlRaw($"rptMinorHeadWiseCollectionbycalyear {CalendarYearId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }



        //Missed OutReading Report Jigme
        public IEnumerable<MissedOutReadingReportVM> GetMissedOutReadingReport()
        {
            try
            {

                // StartDate = Convert.ToDateTime("20/01/2021"); EndDate = Convert.ToDateTime("20/06/2021");
                var result = ctx.MissedOutReading.FromSqlRaw($"rptMissedOutReadingReport");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        //end

        //Floors Wise Count Report Jigme
        public IEnumerable<FloorsWiseCountReportVM> GetFloorsWiseCountReport()
        {
            try
            {

                // StartDate = Convert.ToDateTime("20/01/2021"); EndDate = Convert.ToDateTime("20/06/2021");
                var result = ctx.FloorsWiseCount.FromSqlRaw($"rptFloorWiseCountReport");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        //end


        //UGYEN
        public IEnumerable<rptGetWaterConsumptionVM> GetWaterConsumption(int zoneId)
        {
            try
            {
                var result = ctx.GetWaterConsumption.FromSqlRaw($"rptGetWaterConsumption {zoneId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //MONTHLY METER READING SHEET
        public IEnumerable<Report2VM> GetMonthlyMeterReading(int ZoneId, int MonthId, int YearId)
        {
            try
            {
                var result = ctx.GetMonthlyMeterReading.FromSqlRaw($"[dbo].[rptMonthlyMeterReader] {ZoneId}, {MonthId}, {YearId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }

        //ZONE WISE WATER COLLECTION
        public IEnumerable<ZoneWiseWaterCollection> GetZoneWiseWaterCollection(int ZoneId)
        {
            try
            {

                var result = ctx.GetZoneWiseWaterCollection.FromSqlRaw($"[dbo].[rptZoneWiseWaterCollection] {ZoneId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        //WATER ACCOUNT WISE REPORT
        public IEnumerable<WaterAccountWiseReport> GetWaterAccountWiseReport(string ConsumerNo, int FromDate, int ToDate/*, int PaymentStatusId*/)
        {
            try
            {
                var result = ctx.GetWaterAccountWiseReport.FromSqlRaw($"[dbo].[rptWaterAccountWiseReport] {ConsumerNo},{FromDate},{ToDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }

        public IList<WaterConnectionModel> GetWaterDetails()
        {
            var data = (from x in ctx.MstWaterConnection
                        select new WaterConnectionModel
                        {
                            WaterMeterNo = x.WaterMeterNo,
                            BillingAddress = x.BillingAddress
                        });
            return data.ToList();
        }

        //ZONE WISE WATER CONSUMPTION
        public IEnumerable<ZoneWiseWaterConsumption> GetZoneWiseWaterConsumption(int ZoneId, string YearId)
        {
            try
            {
                var result = ctx.GetZoneWiseWaterConsumption.FromSqlRaw($"[dbo].[rptZoneWiseWaterConsumption] {ZoneId}, {YearId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }

        }
         
        //*************Cascading for Asset
        public List<SecondaryAccountHeadModel> fetchSecondaryHead(int id)
        {
            var data = (from a in ctx.MstSecondaryAccountHead.Where(x => x.PrimaryAccountHeadId == id)
                        select new SecondaryAccountHeadModel
                        {
                            SecondaryAccountHeadId = a.SecondaryAccountHeadId,
                            SecondaryAccountHeadName = a.SecondaryAccountHeadName
                        });
            return data.ToList();
        }

        public List<TertiaryAccountHeadModel> fetchTertiaryHead(int id)
        {
            var data = (from a in ctx.MstTertiaryAccountHead.Where(x => x.SecondaryAccountHeadId == id)
                        select new TertiaryAccountHeadModel
                        {
                            TertiaryAccountHeadId = a.TertiaryAccountHeadId,
                            TertiaryAccountHeadName = a.TertiaryAccountHeadName
                        });
            return data.ToList();
        }

        //MONTHLY ZONE WISE WATER CONSUMPTION
        //public IEnumerable<MonthlyZoneWiseWaterConsumption> GetMonthlyZoneWiseWaterConsumption(int ZoneId, string YearId, int MonthId)
        //{
        //    try
        //    {
        //        var result = ctx.GetMonthlyZoneWiseWaterConsumption.FromSqlRaw($"[dbo].[rptMonthlyZoneWiseWaterConsumption] {ZoneId}, {YearId},{MonthId}");

        //        return result.ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;

        //    }

        //}

    }
}

