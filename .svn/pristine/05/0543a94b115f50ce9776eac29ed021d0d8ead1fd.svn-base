using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IReports
    {
        IEnumerable<ReportVM> GetDailyHeadWiseDemandCollection(int StartDate, int EndDate);
        IEnumerable<DailyMinorHeadWiseCollection> GetDailyMinorHeadWiseCollection(int StartDate, int EndDate);
        IEnumerable<FinancialYearWiseReportVM> GetYearlyHeadWiseDemandCollection(int FinancialYearId);

        IEnumerable<DailyPaymentModeWisedemandCollectionVM> GetDailyPaymentModeWiseDemandCollection(int StartDate, int EndDate);

        //IEnumerable<DailyReceiptWiseCollection> GetDailyRecepitWiseCollection(int FromDate, int ToDate);

        //Reconcil Report
        IEnumerable<ReconcilingReport> GetReconcilingReport(int FromDate, int ToDate);
        IEnumerable<TaxRateVM> GetTaxRate(int TransactionTypeId);

        //Individual Receipt Wise Collection
        IEnumerable<IndividaulReceiptWiseDemandCollection> GetIndividualReceiptWiseCollection(int FromDate, int ToDate);
        IList<IndividualDetails> GetAll();
        IList<WaterConnectionModel> GetWaterDetails();

        //Defaulter Property List
        IEnumerable<DefaulterPropertyList> GetDefaulterPropertyList(string CalendarYear);
       //Defaulter Property List
        //IEnumerable<DefaulterWaterList> GetDefaulterWaterList();
        //IEnumerable<DailyMinorHeadWiseCollection> GetDailyMinorHeadWiseCollection(int FromDate, int ToDate);
        IEnumerable<YearlyMinorHeadWiseCollection> GetYearlyMinorHeadWiseCollection(int CalendarYearId);
        IEnumerable<rptGetWaterConsumptionVM> GetWaterConsumption(int zoneId);
        IEnumerable<Report2VM> GetMonthlyMeterReading(int ZoneId, int MonthId, int YearId);
        IEnumerable<ZoneWiseWaterCollection> GetZoneWiseWaterCollection(int ZoneId);
        IEnumerable<WaterAccountWiseReport> GetWaterAccountWiseReport(string ConsumerNo, int FromDate, int ToDate/*, int PaymentStatusId*/);

        //GetMissedOutReadingReport Jigme
        IEnumerable<MissedOutReadingReportVM> GetMissedOutReadingReport();
        //Floors WiseCount Report Jigme
        IEnumerable<FloorsWiseCountReportVM> GetFloorsWiseCountReport();
        IEnumerable<ZoneWiseWaterConsumption> GetZoneWiseWaterConsumption(int ZoneId, string YearId);
        //IEnumerable<MonthlyZoneWiseWaterConsumption> GetMonthlyZoneWiseWaterConsumption(int ZoneId, string YearId, int MonthId);
        //Cascading for Asset
        List<SecondaryAccountHeadModel> fetchSecondaryHead(int id);
        List<TertiaryAccountHeadModel> fetchTertiaryHead(int id);
    }

}
