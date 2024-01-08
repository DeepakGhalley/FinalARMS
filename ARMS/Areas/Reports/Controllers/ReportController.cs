﻿using ARMS.Functions;
using ARMS.Models;
using AspNetCore.Reporting;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Reporting;
//using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ARMS.Areas.Reports.Controllers
{
    [Area("Reports")]
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        readonly IReports _repository = new ReportBLL();
        readonly IOnlinePayment _obj = new OnlinePaymentBLL();
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly tt_dbContext _ctx = new tt_dbContext();
        public ReportController(ILogger<ReportController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _IWebHostEnvironment = webHostEnvironment;
        }

        private void PopulateDropDowns()
        {
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListTransactionType();
            ViewData["FinancialYear"] = _CommonRepo.SelectListFinancialYear();
            ViewData["calenderYear"] = _CommonRepo.SelectListCalendarYear();
            ViewData["LeaseTypeId"] = _CommonRepo.SelectListLeaseType();
            ViewData["PrimaryHead"] = _CommonRepo.SelectListPrimaryHead();
            ViewData["SecondaryHead"] = _CommonRepo.SelectListSecondaryHead();
            ViewData["TertiaryHead"] = _CommonRepo.SelectListTertiaryHead();
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();
            ViewData["WaterConnectionTypeId"] = _CommonRepo.SelectListWaterConnectionType();
            ViewData["TaxPayerTypeId"] = _CommonRepo.SelectListTaxPayerType();
            ViewData["MonthId"] = _CommonRepo.SelectListMonths();


        }

        //*********************************************************************DAILY HEAD WISE DEMAND REPORT*************************************************************

        [Route("Reports/Report/DailyWiseReport")]
        public IActionResult DailyWiseReport()
        {

            return View();
        }
        [Route("Reports/Report/PrintDailyHeadWiseDemandCollection")]
        public async Task<IActionResult> PrintDailyHeadWiseDemandCollection(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                //string SDate = StartDate.ToString("dd-MM-yyyy").Replace('-', '/');
                //string EDate = EndDate.ToString("dd-MM-yyyy").Replace('-', '/');

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptGetDailyHeadWiseDemandCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("rp1", SDate);
                //parameter.Add("rp2", EDate);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@StartDate", Value = StartDate },
                    new SqlParameter { ParameterName = "@EndDate", Value = EndDate }
                };
                var resultS = await _ctx.DailyWiseReport.FromSqlRaw("EXECUTE [dbo].[rptGetDailyHeadWiseDemandCollection] @StartDate,@EndDate", parms.ToArray()).ToListAsync();
                List<ReportVM> data = resultS.Select(s => new ReportVM
                {
                    Sl = s.Sl,
                    PaymentDate = s.PaymentDate,
                    TaxName = s.TaxName,
                    TotalAmount = s.TotalAmount,
                    PenaltyAmount = s.PenaltyAmount

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        //*********************************************************************FINANCIAL YEAR WISE REPORT*************************************************************

        [Route("Reports/Report/FinancialYearWiseReport")]
        public IActionResult FinancialYearWiseReport()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report/PrintYearHeadWiseDemandCollection")]
        public async Task<IActionResult> PrintYearHeadWiseDemandCollection(int FinancialYearId, string cyear)
        {

            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptGetYearlyHeadWiseDemandCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("cy", cyear);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FinancialYearId", Value = FinancialYearId },
                };
                var resultS = await _ctx.FinancialYearWiseReport.FromSqlRaw("EXECUTE [dbo].[rptGetYearlyHeadWiseDemandCollection] @FinancialYearId", parms.ToArray()).ToListAsync();
                List<FinancialYearWiseReportVM> data = resultS.Select(s => new FinancialYearWiseReportVM
                {
                    sl = s.sl,
                    TaxName = s.TaxName,
                    TotalAmount = s.TotalAmount,
                    FinancialYear = s.FinancialYear

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //*********************************************************************DAILY PAYMENT MODE WISE DEMAND REPORT*************************************************************

        [Route("Reports/Report/DailyPaymentModeWiseDemandCollection")]
        public IActionResult DailyPaymentModeWiseDemandCollection()
        {

            return View();
        }
        [Route("Reports/Report/PrintDailyPaymentModeWiseDemandCollection")]
        public async Task<IActionResult> PrintDailyPaymentModeWiseDemandCollection(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                DateTime date = StartDate;
                DateTime date1 = EndDate;
                string SDate = StartDate.ToString("dd-MM-yyyy").Replace('-', '/');
                string EDate = EndDate.ToString("dd-MM-yyyy").Replace('-', '/');

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptDailyPaymentModeWiseDemandCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("rp1", SDate);
                //parameter.Add("rp2", EDate);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@StartDate", Value = StartDate },
                    new SqlParameter { ParameterName = "@EndDate", Value = EndDate }
                };
                var resultS = await _ctx.DailyPaymentModeWiseDemandCollection.FromSqlRaw("EXECUTE [dbo].[rptDailyPaymentWiseDemandCollection] @StartDate,@EndDate", parms.ToArray()).ToListAsync();
                List<DailyPaymentModeWisedemandCollectionVM> data = resultS.Select(s => new DailyPaymentModeWisedemandCollectionVM
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    PaymentDate = s.PaymentDate,
                    PaymentMode = s.PaymentMode,
                    SubTotal = s.SubTotal

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);

                var result2= await _ctx.DailyPaymentModeWiseDemandCollectionSUM.FromSqlRaw("EXECUTE [dbo].[rptDailyPaymentWiseDemandCollectionSum] @StartDate,@EndDate", parms.ToArray()).ToListAsync();
                List<DailyPaymentModeWisedemandCollectionSUMVM> data2 = resultS.Select(s => new DailyPaymentModeWisedemandCollectionSUMVM
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    //PaymentDate = s.PaymentDate,
                    PaymentMode = s.PaymentMode,
                    SubTotal = s.SubTotal

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet2", result2);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //*********************************************************************DAILY RECEIPT WISE COLLECTION REPORT*************************************************************

        [Route("Reports/Report/GetDailyRecepitWiseCollection")]
        public IActionResult GetDailyRecepitWiseCollection()
        {

            return View();
        }
        [HttpGet]
        [Route("Reports/Report/PrintGetDailyRecepitWiseCollection")]

        public async Task<IActionResult> PrintGetDailyRecepitWiseCollection(DateTime sdate, DateTime edate)
        {

            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptDailyRecepitWiseCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }
                };
                var resultS = await _ctx.GetDailyRecepitWiseCollection.FromSqlRaw("EXECUTE [dbo].[rptDailyReceiptWiseCollectionByFromDateToDate] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<DailyReceiptWiseCollection> data = resultS.Select(s => new DailyReceiptWiseCollection
                {
                    Sl = s.Sl,
                    receiptId = s.receiptId,
                    ReceiptNo = s.ReceiptNo,
                    PaymentModeNo = s.PaymentModeNo,
                    PaymentModeDate = s.PaymentModeDate,
                    PaymentDate = s.PaymentDate,
                    CashAmount = s.CashAmount,
                    ChecqueAmount = s.ChecqueAmount,
                    ThromdeApp = s.ThromdeApp,
                    OnlinePaymentAmount = s.OnlinePaymentAmount,
                    PIAmount = s.PIAmount,
                    MBOBAmount = s.MBOBAmount,
                    mPayAmount = s.mPayAmount,
                    DkAmount = s.DkAmount,
                    TPayAmount = s.TPayAmount,
                    DrukPNBAmount = s.DrukPNBAmount,
                    ePayAmount = s.ePayAmount,
                    eTeeruAmount = s.eTeeruAmount,
                    ScanPay = s.ScanPay,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end

        }

        //*********************************************************************TAX RATE REPORT*************************************************************

        [Route("Reports/Report/GetTaxRate")]
        public IActionResult GetTaxRate()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report/PrintTaxRate")]
        public async Task<IActionResult> PrintTaxRate(int TransactionTypeId)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = "";
                if (TransactionTypeId == 19)
                {
                    ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptGetTaxRates.rdlc";
                }

                else if (TransactionTypeId == 20)
                {
                    ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptGetTaxRatesProperty.rdlc";
                }

                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@TransactionTypeId", Value = TransactionTypeId },
                };
                var resultS = await _ctx.GetTaxRate.FromSqlRaw("EXECUTE [dbo].[rptGetTaxRates] @TransactionTypeId", parms.ToArray()).ToListAsync();
                List<TaxRateVM> data = resultS.Select(s => new TaxRateVM
                {
                    sl = s.sl,
                    taxName = s.taxName,
                    slabName = s.slabName,
                    slabStart = s.slabStart,
                    slabEnd = s.slabEnd,
                    rate = s.rate,
                    effectiveDate = s.effectiveDate

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //*********************************************************************RECONCIL REPORT*************************************************************

        [Route("Reports/Report/Reconcil")]
        public IActionResult Reconcil()
        {

            return View();
        }

        [Route("Reports/Report/PrintReconcilReport")]
        public async Task<IActionResult> PrintReconcilReport(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                string FDate = FromDate.ToString("dd-MM-yyyy").Replace('-', '/');
                string TDate = ToDate.ToString("dd-MM-yyyy").Replace('-', '/');
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptReconcilReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                parameter.Add("fd", FDate);
                parameter.Add("td", TDate);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@StartDate", Value = FromDate },
                    new SqlParameter { ParameterName = "@EndDate", Value = ToDate }
                };
                var resultS = await _ctx.GetReconcilingReport.FromSqlRaw("EXECUTE [dbo].[rptReconcilReport] @StartDate,@EndDate", parms.ToArray()).ToListAsync();
                List<ReconcilingReport> data = resultS.Select(s => new ReconcilingReport
                {
                    Sl = s.Sl,
                    Amount = s.Amount,
                    PaymentMode = s.PaymentMode,
                    PaymentModeNo = s.PaymentModeNo,
                    PaymentModeDate = s.PaymentModeDate,
                    BranchName = s.BranchName,
                    PaymentStatus = s.PaymentStatus,
                    DepositDate = s.DepositDate,
                    DepositedBy = s.DepositedBy

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //*********************************************************************INDIVIDUAL RECEIPT WISE COLLECTION REPORT*************************************************************

        [Route("Reports/Report/IndividualReceiptWiseCollection")]
        public IActionResult IndividualReceiptWiseCollection()
        {

            return View();
        }

        [Route("Reports/Report/PrintIndividualReceiptWiseCollection")]
        public async Task<IActionResult> PrintIndividualReceiptWiseCollection(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                
                int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                string mimetype = "";
                int extension = 1;

                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = FromDate },
                    new SqlParameter { ParameterName = "@ToDate", Value = ToDate },
                    new SqlParameter { ParameterName = "@UserId", Value = UserId }
                };
                var resultS = await _ctx.IndividaulReceiptWiseCollection.FromSqlRaw("EXECUTE [dbo].[rptIndividualReceiptWiseCollection] @FromDate,@ToDate,@UserId", parms.ToArray()).ToListAsync();
                List<IndividaulReceiptWiseDemandCollection> data = resultS.Select(s => new IndividaulReceiptWiseDemandCollection
                {
                    Sl = s.Sl,
                    ReceiptNo = s.ReceiptNo,
                    PaymentModeNo = s.PaymentModeNo,
                    PaymentModeDate = s.PaymentModeDate,
                    PaymentDate = s.PaymentDate,
                    Cash = s.Cash,
                    Cheque = s.Cheque,
                    ScanPay = s.ScanPay,
                    grandTotal = s.grandTotal,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    UserName = s.UserName, ExecutionDate = s.ExecutionDate

                }
                     ).ToList();
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptIndividualReceiptWiseCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //*********************************************************************DEFAULTER PROPERTY LIST REPORT*************************************************************

        [Route("Reports/Report/DefaulterPropertyList")]
        public IActionResult DefaulterPropertyList()
        {
            ViewData["CalendarYear"] = _CommonRepo.SelectListCalendarYear();
            ViewData["TaxPayerTypeId"] = _CommonRepo.SelectListTaxPayerType();
            return View();
        }


        [Route("Reports/Report/PrintDefaulterPropertyList")]
        public async Task<IActionResult> PrintDefaulterPropertyList(int CalendarYearId, int taxPayerTypeId)
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptDefaulterPropertyList.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("cy", cyear);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@CalendarYearId", Value = CalendarYearId },
                    new SqlParameter { ParameterName = "@taxPayerTypeId", Value = taxPayerTypeId }
                };
                var resultS = await _ctx.GetDefaulterPropertyList.FromSqlRaw("EXECUTE [dbo].[rptDefaulterPropertyList] @CalendarYearId,@taxPayerTypeId", parms.ToArray()).ToListAsync();
                List<DefaulterPropertyList> data = resultS.Select(s => new DefaulterPropertyList
                {
                    Sl = s.Sl,
                    TaxPayerName = s.TaxPayerName,
                    TaxPayerType = s.TaxPayerType,
                    CID = s.CID,
                    TTIN = s.TTIN,                   
                    PlotNo = s.PlotNo,
                    MobileNo = s.MobileNo,                    
                    CalendarYear = s.CalendarYear,
                    LastTaxPaidYear = s.LastTaxPaidYear,
                    TotalAmount = s.TotalAmount,
                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        //*********************************************************************DEFAULTER Water LIST REPORT*************************************************************
        [Route("Reports/Report/DefaulterWaterList")]
        public IActionResult DefaulterWaterList()
        {
            ViewData["CalendarYear"] = _CommonRepo.SelectListCalendarYear();
            ViewData["mId"] = _CommonRepo.SelectListMonths();
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();
            //PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report/PrintDefaulterWaterList")]
        public async Task<IActionResult> PrintDefaulterWaterList(int CalendarYearId, int MonthId, int ZoneId)
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptGetDefaulterwaterList.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("cy", cyear);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@CalendarYearId", Value = CalendarYearId },
                   // new SqlParameter { ParameterName = "@Month", Value = Month },
                    new SqlParameter { ParameterName = "@ZoneId", Value = ZoneId },
                };
                var resultS = await _ctx.GetDefaulterWaterList.FromSqlRaw("EXECUTE [dbo].[rptDefaulterWaterList] @CalendarYearId,@ZoneId", parms.ToArray()).ToListAsync();
                List<DefaulterWaterList> data = resultS.Select(s => new DefaulterWaterList
                {
                    Sl = s.Sl,
                    ConsumerNo = s.ConsumerNo,
                    WaterMeterNo = s.WaterMeterNo,
                    BillingAddress = s.BillingAddress,
                    NoOfPendingBills = s.NoOfPendingBills,
                    TotalAmount = s.TotalAmount,
                    contactNo = s.contactNo,
                    zoneName = s.zoneName,
                    CalendarYear = s.CalendarYear,
                    //months = s.months

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //******************************************** END *********************
        //*********************************************************************DAILY MINOR HEAD WISE DEMAND COLLECTION REPORT*************************************************************

        [Route("Reports/Report/DailyMinorHeadWiseCollection")]
        public IActionResult DailyMinorHeadWiseCollection()
        {

            return View();
        }
        [Route("Reports/Report/PrintDailyMinorHeadWiseCollection")]
        public async Task<IActionResult> PrintDailyMinorHeadWiseCollection(DateTime StartDate, DateTime EndDate)
        {
            try
            {

                //string FDate = StartDate.ToString("dd-MM-yyyy").Replace('-', '/');
                //string TDate = EndDate.ToString("dd-MM-yyyy").Replace('-', '/');
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptDailyMinorHeadWiseCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("rp1", FDate);
                //parameter.Add("rp2", TDate);
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@StartDate", Value = StartDate },
                    new SqlParameter { ParameterName = "@EndDate", Value = EndDate }
                };
                var resultS = await _ctx.DailyMinorHeadWise.FromSqlRaw("EXECUTE [dbo].[rptMinorHeadWiseCollectionbytofromdate] @StartDate,@EndDate", parms.ToArray()).ToListAsync();
                List<DailyMinorHeadWiseCollection> data = resultS.Select(s => new DailyMinorHeadWiseCollection
                {
                    Sl = s.Sl,
                    MinorHeadName = s.MinorHeadName,
                    TotalAmount = s.TotalAmount,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //*********************************************************************YEARLY MINOR HEAD WISE COLLECTION REPORT*************************************************************

        [Route("Reports/Report/YearlyMinorHeadWiseCollection")]
        public IActionResult YearlyMinorHeadWiseCollection()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report/PrintYearlyMinorHeadWiseCollectiont")]
        public async Task<IActionResult> PrintYearlyMinorHeadWiseCollection(string CalendarYear, string cyear)
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptYearlyMinorHeadWiseCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                parameter.Add("cy", cyear);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@CalendarYearId", Value = CalendarYear },
                };
                var resultS = await _ctx.YearlyMinorHeadWise.FromSqlRaw("EXECUTE [dbo].[rptMinorHeadWiseCollectionbycalyear] @CalendarYearId", parms.ToArray()).ToListAsync();
                List<YearlyMinorHeadWiseCollection> data = resultS.Select(s => new YearlyMinorHeadWiseCollection
                {
                    Sl = s.Sl,
                    MinorHeadName = s.MinorHeadName,
                    TotalAmount = s.TotalAmount

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //*********************************************************************MISSED OUT READING REPORT*************************************************************

        [Route("Reports/Report/MissedOutReading")]
        public IActionResult MissedOutReading()
        {

            return View();
        }
        [Route("Reports/Report/PrintMissOutReadingReport")]
        public async Task<IActionResult> PrintMissOutReadingReport()
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptMissedOutReadingReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    //new SqlParameter { ParameterName = "@ReadingMonth"},
                };
                var resultS = await _ctx.MissedOutReading.FromSqlRaw("EXECUTE [dbo].[rptMissedOutReadingReport]", parms.ToArray()).ToListAsync();
                List<MissedOutReadingReportVM> data = resultS.Select(s => new MissedOutReadingReportVM
                {
                    Sl = s.Sl,
                    ConsumerNo = s.ConsumerNo,
                    MeterNo = s.MeterNo,
                    connectionDate = s.connectionDate,
                    ActiveStatus = s.ActiveStatus,
                    LineType = s.LineType,
                    ConnectionType = s.ConnectionType,
                    ConnectionStatus = s.ConnectionStatus,
                    BillingAddress = s.BillingAddress,
                    FlatNo = s.FlatNo

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //*********************************************************************FLOOR WISE COUNT REPORT*************************************************************

        [Route("Reports/Report/FloorsWiseCountReport")]
        public IActionResult FloorsWiseCountReport()
        {

            return View();
        }
        [Route("Reports/Report/PrintFloorsWiseCountReport")]
        public async Task<IActionResult> PrintFloorsWiseCountReport()
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptFloorsWiseCountReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    //new SqlParameter { ParameterName = "@ReadingMonth"},
                };
                var resultS = await _ctx.FloorsWiseCount.FromSqlRaw("EXECUTE [dbo].[rptFloorWiseCountReport]", parms.ToArray()).ToListAsync();
                List<FloorsWiseCountReportVM> data = resultS.Select(s => new FloorsWiseCountReportVM
                {
                    Sl = s.Sl,
                    NumberOfFloors = s.NumberOfFloors,
                    BuildingCount = s.BuildingCount

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //*********************************************************************CONSOLIDATE ONLINE PAYMENT REPORT*************************************************************

        [Route("Reports/Report/ConsolidatedOnlinePaymentReport")]
        public IActionResult ConsolidatedOnlinePaymentReport()
        {
            PopulateDropDowns();
            return View();
        }
        [Route("Reports/Report/PrintReportc")]
        public async Task<IActionResult> PrintReportc(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptOnlinePaymentByFromDateToDate.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }


                };
                var resultS = await _ctx.OnlinePaymentByFromDateToDate.FromSqlRaw("EXECUTE [dbo].[rptOnlinePaymentByFromDateToDate] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<OnlinePaymentByFromDateToDateModel> data = resultS.Select(s => new OnlinePaymentByFromDateToDateModel
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    PaymentDate = s.PaymentDate,
                    ReceiptNo = s.ReceiptNo,
                    PaymentModeNo = s.PaymentModeNo,
                    PaymentModeDate = s.PaymentModeDate,
                    TotalAmount = s.TotalAmount
                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end

        }

        //*********************************************************************                                *************************************************************
        public async Task<IActionResult> PrintReport2()
        {

            string mimetype = "";
            int extension = 1;
            var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            LocalReport lc = new LocalReport(ReportPath);
            var data = await _obj.GetMenu();
            lc.AddDataSource("DataSet1", data);
            var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
            return File(result.MainStream, "application/pdf");

        }



        //*********************************************************************Proprty and Water Collection Report*************************************************************
        //**********************Property Related Collection************************

        [Route("Reports/Report/PropertyandWaterCollectionReport")]
        public IActionResult PropertyandWaterCollectionReport()
        {
            return View();
        }
        [Route("Reports/Report/PrintReportPandW")]
        public async Task<IActionResult> PrintReportPandW(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\PropertyandWaterCollectionReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }

                };
                var resultS = await _ctx.PropertyandWaterCollectionReport.FromSqlRaw("EXECUTE [dbo].[rptPropertyCollection] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                //var resultX = await _ctx.PropertyandWaterCollectionReport.FromSqlRaw("EXECUTE [dbo].[rptWatercollection] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<PropertyandWaterCollectionReport> data = resultS.Select(s => new PropertyandWaterCollectionReport
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    receiptNo = s.receiptNo,
                    PaymentDate = s.PaymentDate,
                    Penalty = s.Penalty,
                    //PaymentMode = s.PaymentMode,
                    //paymentModeNo = s.paymentModeNo,
                    //paymentModeDate = s.paymentModeDate,
                    Amount = s.Amount
                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                //lc.AddDataSource("DataSet2", resultX);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end
        }
        //**********************End of Property Related Collection************************

        //**********************Water Related Collection************************
        [Route("Reports/Report/PrintReportW")]
        public async Task<IActionResult> PrintReportW(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\WaterCollectionReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }


                };
                var resultS = await _ctx.PropertyandWaterCollectionReport.FromSqlRaw("EXECUTE [dbo].[rptWatercollection] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<PropertyandWaterCollectionReport> data = resultS.Select(s => new PropertyandWaterCollectionReport
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    receiptNo = s.receiptNo,
                    PaymentDate = s.PaymentDate,
                    Penalty = s.Penalty,
                    //PaymentMode = s.PaymentMode,
                    //paymentModeNo = s.paymentModeNo,
                    //paymentModeDate = s.paymentModeDate,
                    Amount = s.Amount
                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end

        }
        //**********************End of water Related Collection************************

        //*********************************************************************Proprty and Water Collection Report END*************************************************************



        //*********************************************************************Water Transaction Report*************************************************************
        [Route("Reports/Report/WaterTransactionReport")]
        public IActionResult WaterTransactionReport()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report/Printwtr")]
        public async Task<IActionResult> Printwtr(string consumerNo, string waterMeterNo, int transactionTypeId)
        {

            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptWaterTransactionReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp

                if (waterMeterNo == null && transactionTypeId == 0)
                {
                    waterMeterNo = "";
                    transactionTypeId = 0;
                }

                if (consumerNo == null && transactionTypeId == 0)
                {
                    consumerNo = "";
                    transactionTypeId = 0;
                }

                if (consumerNo == null && waterMeterNo == null)
                {
                    consumerNo = "";
                    waterMeterNo = "";
                }


                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)
                    new SqlParameter { ParameterName = "@consumerNo", Value = consumerNo },
                    new SqlParameter { ParameterName = "@waterMeterNo", Value = waterMeterNo },
                    new SqlParameter { ParameterName = "@transactionTypeId", Value = transactionTypeId },
                };
                var resultS = await _ctx.WaterTransactionReport.FromSqlRaw("EXECUTE [dbo].[rptWaterTransactionReport] @consumerNo, @waterMeterNo, @transactionTypeId", parms.ToArray()).ToListAsync();
                List<WaterTransactionReport> data = resultS.Select(s => new WaterTransactionReport
                {
                    Sl = s.Sl,
                    waterMeterNo = s.waterMeterNo,
                    consumerNo = s.consumerNo,
                    applicationDate = s.applicationDate,
                    plotNo = s.plotNo,
                    waterMeterType = s.waterMeterType,
                    SewerageConnection = s.SewerageConnection,
                    waterConnectionStatus = s.waterConnectionStatus,
                    waterConnectionType = s.waterConnectionType,
                    waterLineType = s.waterLineType,
                    standardCosumption = s.standardCosumption,
                    billingAddress = s.billingAddress,
                    //flatNo = s.flatNo,
                    zoneName = s.zoneName,
                    initialReading = s.initialReading,
                    //organisationName = s.organisationName,
                    isActive = s.isActive,
                    remarks = s.remarks,
                    disConnectionDate = s.disConnectionDate,
                    reUse = s.reUse,
                    noOfUnits = s.noOfUnits,
                    ownerType = s.ownerType,
                    reConnectionDate = s.reConnectionDate,
                    sewarageConnectionDate = s.sewarageConnectionDate,
                    primaryMobileNo = s.primaryMobileNo,
                    g2cApplicationNo = s.g2cApplicationNo,
                    PermanentDisconnect = s.PermanentDisconnect,
                    approvalStatus = s.approvalStatus,
                    readingDate = s.readingDate,
                    previousReadingDate = s.previousReadingDate,
                    previousReading = s.previousReading,
                    isPermanent = s.isPermanent,
                    OldWaterConnectionId = s.OldWaterConnectionId,
                    transactionValue = s.transactionValue,
                    //TransactionDate = s.TransactionDate,
                    transactionType = s.transactionType,
                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //*********************************************************************Water Transaction Repor END*************************************************************
        //*********************************************************************CONSOLIDATED PROPERTY COLLECTION*************************************************************

        [Route("Reports/Report/PrintConsolidatedPropertyCollection")]
        public async Task<IActionResult> PrintConsolidatedPropertyCollection(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\ConsolidatePropertyCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }

                };
                var resultS = await _ctx.ConsolidatePropertyCollection.FromSqlRaw("EXECUTE [dbo].[rptConsolidatedPropertyCollection] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                //var resultX = await _ctx.PropertyandWaterCollectionReport.FromSqlRaw("EXECUTE [dbo].[rptWatercollection] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<ConsolidatePropertyWaterCollection> data = resultS.Select(s => new ConsolidatePropertyWaterCollection
                {

                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    PaymentDate = s.PaymentDate,
                    Amount = s.Amount
                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                //lc.AddDataSource("DataSet2", resultX);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end
        }

        //*********************************************************************CONSOLIDATED WATER COLLECTION*************************************************************

        [Route("Reports/Report/PrintConsolidatedWaterCollection")]
        public async Task<IActionResult> PrintConsolidatedWaterCollection(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\ConsolidateWaterCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }


                };
                var resultS = await _ctx.ConsolidateWaterCollection.FromSqlRaw("EXECUTE [dbo].[rptConsolidateWatercollection] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<ConsolidateWaterCollection> data = resultS.Select(s => new ConsolidateWaterCollection
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    PaymentDate = s.PaymentDate,
                    Amount = s.Amount
                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end

        }

        //*****************end**************************


        //**********************Long and Short lease list Report*********
        //**********************Long lease list************************

        [Route("Reports/Report/ShortandLongTermLeaseList")]
        public IActionResult ShortandLongTermLeaseList()
        {
            return View();
        }
        [Route("Reports/Report/PrintReportLongTerm")]
        public async Task<IActionResult> PrintReportLongTerm(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\LongTermLeaseList.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }

                };
                var resultS = await _ctx.LongandShortLeaseList.FromSqlRaw("EXECUTE [dbo].[rptLongLeaseList] @FromDate,@ToDate", parms.ToArray()).ToListAsync();

                List<LongandShortLeaseList> data = resultS.Select(s => new LongandShortLeaseList
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    Area = s.Area,
                    plotNo = s.plotNo,
                    ttin = s.ttin,
                    leaseAmount = s.leaseAmount

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end
        }
        //**********************End of Long lease list************************
        //**********************Short lease list************************
        [Route("Reports/Report/PrintReportShortTerm")]
        public async Task<IActionResult> PrintReportShortTerm(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\ShortTermLeaseList.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }

                };
                var resultS = await _ctx.LongandShortLeaseList.FromSqlRaw("EXECUTE [dbo].[rptShortLeaseList] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<LongandShortLeaseList> data = resultS.Select(s => new LongandShortLeaseList
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    Area = s.Area,
                    plotNo = s.plotNo,
                    ttin = s.ttin,
                    leaseAmount = s.leaseAmount

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end

        }
        //**********************Short lease list************************

        //**********************long and lease list Report END************************


        //*************Long and Short Term collection**************************

        [Route("Reports/Report/LongAndShortTermCollectionReport")]
        public IActionResult LongAndShortTermCollectionReport()
        {
            PopulateDropDowns();
            return View();
        }
        [Route("Reports/Report/PrintReportLongAndShortTermCollection")]
        public async Task<IActionResult> PrintReportLongAndShortTermCollection(DateTime sdate, DateTime edate, int LeaseTypeId)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\LongAndShortTermCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate },
                    new SqlParameter { ParameterName = "@LeaseTypeId", Value = LeaseTypeId }

                };
                var resultS = await _ctx.LongandShortTermCollection.FromSqlRaw("EXECUTE [dbo].[rptShortAndLongTermCollectionReport] @FromDate,@ToDate,@LeaseTypeId", parms.ToArray()).ToListAsync();

                List<LongandShortTermCollection> data = resultS.Select(s => new LongandShortTermCollection
                {
                    Sl = s.Sl,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    plotNo = s.plotNo,
                    Acerage = s.Acerage,
                    totalAmount = s.totalAmount,
                    penaltyPeriod = s.penaltyPeriod,
                    penaltyAmount = s.penaltyAmount,
                    grandTotal = s.grandTotal,
                    periodMonth = s.periodMonth,
                    yearPeriod = s.yearPeriod

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end
        }
        //******************end***********************

        //*********************************************************************Asset Status Report*************************************************************

        [Route("Reports/Report/AssetStatusReport")]
        public IActionResult AssetStatusReport()
        {
            return View();
        }

        [Route("Reports/Report/PrintAssetStatusReport")]
        public async Task<IActionResult> PrintAssetStatusReport(int isActiveId)
        {

            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\AssetStatusReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@isActiveId", Value = isActiveId },
                };
                var resultS = await _ctx.AssetStatusReport.FromSqlRaw("EXECUTE [dbo].[rptStatusReportAsset] @isActiveId", parms.ToArray()).ToListAsync();
                List<AssetStatusReport> data = resultS.Select(s => new AssetStatusReport
                {
                    Sl = s.Sl,
                    assetName = s.assetName,
                    areaName = s.areaName,
                    lapName = s.lapName,
                    sectionName = s.sectionName,
                    assetFunctionName = s.assetFunctionName,
                    TertiaryAccountHeadName = s.TertiaryAccountHeadName,
                    secondaryAccountHeadName = s.secondaryAccountHeadName,
                    primaryAccountHeadName = s.primaryAccountHeadName,
                    responsiblePerson = s.responsiblePerson

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //******************end***********************
        //Cascading for Asset listing

        [HttpPost]
        [Route("Reports/Report/PopulateSecondaryAccountHead")]
        public List<SecondaryAccountHeadModel> PopulateSecondaryAccountHead(int id)
        {
            List<SecondaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchSecondaryHead(id);
        }

        [HttpPost]
        [Route("Reports/Report/PopulateTertiaryAccountHead")]
        public List<TertiaryAccountHeadModel> PopulateTertiaryAccountHead(int id)
        {
            List<TertiaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchTertiaryHead(id);
        }

        //****************** Asset Listing Report ***********************
        [Route("Reports/Report/AssetListingReport")]
        public IActionResult AssetListingReport()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report/PrintAssetListing")]
        public async Task<IActionResult> PrintAssetListing(int PrimaryAccountHeadId, int SecondaryAccountHeadId, int TertiaryAccountHeadId)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\AssetListing.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@PrimaryAccountHeadId", Value = PrimaryAccountHeadId },
                    new SqlParameter { ParameterName = "@SecondaryAccountHeadId", Value = SecondaryAccountHeadId },
                    new SqlParameter { ParameterName = "@TertiaryAccountHeadId", Value = TertiaryAccountHeadId }

                };
                var resultS = await _ctx.AssetListing.FromSqlRaw("EXECUTE [dbo].[rptAssetListing] @PrimaryAccountHeadId,@SecondaryAccountHeadId,@TertiaryAccountHeadId", parms.ToArray()).ToListAsync();

                List<AssetListing> data = resultS.Select(s => new AssetListing
                {
                    Sl = s.Sl,
                    assetName = s.assetName,
                    areaName = s.areaName,
                    lapName = s.lapName,
                    sectionName = s.sectionName,
                    assetFunctionName = s.assetFunctionName,
                    responsiblePerson = s.responsiblePerson,
                    remarks = s.remarks

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end
        }

        //***************end*******************

        //************** Asset List By Responsible Person Report ***********************
        [Route("Reports/Report/AssetListByResponsiblePerson")]
        public IActionResult AssetListByResponsiblePerson()
        {
            return View();
        }


        [Route("Reports/Report/PrintAssetListByResponsiblePerson")]
        public async Task<IActionResult> PrintAssetListByResponsiblePerson(string responsiblePerson)
        {

            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\AssetListByResponsiblePerson.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@responsiblePerson", Value = responsiblePerson },
                };
                var resultS = await _ctx.AssetListByResponsiblePerson.FromSqlRaw("EXECUTE [dbo].[rptAssetListByResponsiblePerson] @responsiblePerson", parms.ToArray()).ToListAsync();
                List<AssetListByResponsiblePerson> data = resultS.Select(s => new AssetListByResponsiblePerson
                {
                    Sl = s.Sl,
                    assetName = s.assetName,
                    areaName = s.areaName,
                    lapName = s.lapName,
                    sectionName = s.sectionName,
                    assetFunctionName = s.assetFunctionName,
                    TertiaryAccountHeadName = s.TertiaryAccountHeadName,
                    secondaryAccountHeadName = s.secondaryAccountHeadName,
                    primaryAccountHeadName = s.primaryAccountHeadName,
                    responsiblePerson = s.responsiblePerson

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //***************end*******************

        //***************  Asset Transfer Report   *******************
        [Route("Reports/Report/AssetTransferReport")]
        public IActionResult AssetTransferReport()
        {
            return View();
        }

        [Route("Reports/Report/PrintReportAssetTransfer")]
        public async Task<IActionResult> PrintReportAssetTransfer(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\AssetTransferReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }

                };
                var resultS = await _ctx.AssetTransferReport.FromSqlRaw("EXECUTE [dbo].[rptAssetTransferReport] @FromDate,@ToDate", parms.ToArray()).ToListAsync();

                List<AssetTransferReport> data = resultS.Select(s => new AssetTransferReport
                {
                    Sl = s.Sl,
                    AssetNumber = s.AssetNumber,
                    assetCode = s.assetCode,
                    assetName = s.assetName,
                    transferfrom = s.transferfrom,
                    transferto = s.transferto,
                    transferDate = s.transferDate

                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end
        }
        //********************** End ************************

        //***************  Asset Maintenance Report   *******************
        [Route("Reports/Report/AssetMaintenanceReport")]
        public IActionResult AssetMaintenanceReport()
        {
            return View();
        }

        [Route("Reports/Report/PrintReportAssetMaintenance")]
        public async Task<IActionResult> PrintReportAssetMaintenance(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\AssetMaintenanceReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }

                };
                var resultS = await _ctx.AssetMaintenanceReport.FromSqlRaw("EXECUTE [dbo].[rptAssetMaintenanceReport] @FromDate,@ToDate", parms.ToArray()).ToListAsync();

                List<AssetMaintenanceReport> data = resultS.Select(s => new AssetMaintenanceReport
                {
                    Sl = s.Sl,
                    AssetNumber = s.AssetNumber,
                    assetCode = s.assetCode,
                    assetName = s.assetName,
                    maintenanceDate = s.maintenanceDate
                }
                     ).ToList();
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
            //sp end
        }
        //********************** End ************************


        //***************  Asset Depreciation Report   *******************
        //[Route("Reports/Report/AssetDepreciationReport")]
        //public IActionResult AssetDepreciationReport()
        //{
        //    return View();
        //}

        //[Route("Reports/Report/PrintAssetDepreciationReport")]
        //public async Task<IActionResult> PrintAssetDepreciationReport(DateTime sdate, DateTime edate)
        //{
        //    try
        //    {
        //        string mimetype = "";
        //        int extension = 1;
        //        var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\AssetDepreciationReport.rdlc";
        //        Dictionary<string, string> parameter = new Dictionary<string, string>();
        //        LocalReport lc = new LocalReport(ReportPath);
        //        //sp
        //        List<SqlParameter> parms = new List<SqlParameter>
        //        {
        //            // Create parameter(s)    
        //            new SqlParameter { ParameterName = "@FromDate", Value = sdate },
        //            new SqlParameter { ParameterName = "@ToDate", Value = edate }

        //        };
        //        var resultS = await _ctx.AssetDepreciationReportVM.FromSqlRaw("EXECUTE [dbo].[rptAssetDepreciationReport] @FromDate,@ToDate", parms.ToArray()).ToListAsync();

        //        List<AssetDepreciationReportVM> data = resultS.Select(s => new AssetDepreciationReportVM
        //        {
        //            Sl = s.Sl,
        //            AssetNumber = s.AssetNumber,
        //            assetCode = s.assetCode,
        //            assetName = s.assetName,
        //            depreciationValue = s.depreciationValue
        //        }
        //             ).ToList();
        //        lc.AddDataSource("DataSet1", resultS);
        //        var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
        //        return File(result.MainStream, "application/pdf");
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    //sp end
        //}

        //********************** End ************************


        //*************************************************************************************
        //********************** REPORTS FOR METER CONNECTION ************************

        //***************  No of Meters of Different Sizes   *******************
        [Route("Reports/Report/DifferentSizesMeterNo")]
        public IActionResult DifferentSizesMeterNo()
        {
            return View();
        }

        [Route("Reports/Report/PrintDifferentSizesMeterNo")]
        public async Task<IActionResult> PrintDifferentSizesMeterNo()
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\DifferentSizesMeterNo.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    
                };
                var resultS = await _ctx.DifferentSizesMeterNoReport.FromSqlRaw("EXECUTE [dbo].[rptDifferentSizesMeterNo]", parms.ToArray()).ToListAsync();
                List<DifferentSizesMeterNoReport> data = resultS.Select(s => new DifferentSizesMeterNoReport
                {
                    Sl = s.Sl,
                    MeterSizes = s.MeterSizes,
                    NumberOfMeter = s.NumberOfMeter

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //********************** End ************************

        //***************  No of Connection Category Wise   *******************
        [Route("Reports/Report/NoOfConnectionCategoryWise")]
        public IActionResult NoOfConnectionCategoryWise()
        {
            return View();
        }

        [Route("Reports/Report/PrintNoOfConnectionCategoryWise")]
        public async Task<IActionResult> PrintNoOfConnectionCategoryWise()
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\NoOfConnectionCategoryWise.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {

                };
                var resultS = await _ctx.NoOfConnectionCategoryWiseReport.FromSqlRaw("EXECUTE [dbo].[rptNoOfConnectionCategoryWise]", parms.ToArray()).ToListAsync();
                List<NoOfConnectionCategoryWiseReport> data = resultS.Select(s => new NoOfConnectionCategoryWiseReport
                {
                    Sl = s.Sl,
                    ConnectionType = s.ConnectionType,
                    NumberOfConnection = s.NumberOfConnection

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //********************** End ************************

        //***************  No of Connection Zone Wise   *******************
        [Route("Reports/Report/NoOfConnectionZoneWise")]
        public IActionResult NoOfConnectionZoneWise()
        {
            return View();
        }

        [Route("Reports/Report/PrintNoOfConnectionZoneWise")]
        public async Task<IActionResult> PrintNoOfConnectionZoneWise()
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\NoOfConnectionZoneWise.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {

                };
                var resultS = await _ctx.NoOfConnectionZoneWiseReport.FromSqlRaw("EXECUTE [dbo].[rptNoOfConnectionZoneWise]", parms.ToArray()).ToListAsync();
                List<NoOfConnectionZoneWiseReport> data = resultS.Select(s => new NoOfConnectionZoneWiseReport
                {
                    Sl = s.Sl,
                    zoneName = s.zoneName,
                    ConnectionType = s.ConnectionType,
                    NumberOfConnection = s.NumberOfConnection

                }
                     ).ToList();
                //sp end
                lc.AddDataSource("DataSet1", resultS);
                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //********************** End ************************


        //********************** Zone Wise Water Consumption FromDate to ToDate ************************
        [Route("Reports/Report/rptZoneWiseWaterConsumptionFromToDate")]
        public IActionResult rptZoneWiseWaterConsumptionFromToDate()
        {
            PopulateDropDowns();
            return View();
        }


        [Route("Reports/Report/PrintZoneWaterConsumption")]
        public async Task<IActionResult> PrintZoneWaterConsumption(DateTime FromDate, DateTime ToDate, int ZoneId)
        {
            try
            {

                //int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                string mimetype = "";
                int extension = 1;

                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = FromDate },
                    new SqlParameter { ParameterName = "@ToDate", Value = ToDate },
                    new SqlParameter { ParameterName = "@ZoneId", Value = ZoneId }
                };
                var resultS = await _ctx.ZoneWiseWaterConsumptionFromToDate.FromSqlRaw("EXECUTE [dbo].[rptZoneWiseWaterConsumptionFromToDate] @FromDate,@ToDate,@ZoneId", parms.ToArray()).ToListAsync();
                List<ZoneWiseWaterConsumptionFromToDate> data = resultS.Select(s => new ZoneWiseWaterConsumptionFromToDate
                {
                    Sl = s.Sl,
                    ConsumerNo = s.ConsumerNo,
                    MeterNo = s.MeterNo,
                    Consumption = s.Consumption,
                    TotalAmount = s.TotalAmount,
                    zonename = s.zonename

                }
                     ).ToList();
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\ZoneWiseWaterConsumptionFromToDate.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //********************** End ************************


        //********************** Connection Type Wise Consumption ************************
        [Route("Reports/Report/rptConnectionTypewiseConsumption")]
        public IActionResult rptConnectionTypewiseConsumption()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report/PrintConnectionTypewiseConsumption")]
        public async Task<IActionResult> PrintConnectionTypewiseConsumption(DateTime FromDate, DateTime ToDate, int WaterConnectionTypeId)
        {
            try
            {

                //int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                string mimetype = "";
                int extension = 1;

                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = FromDate },
                    new SqlParameter { ParameterName = "@ToDate", Value = ToDate },
                    new SqlParameter { ParameterName = "@WaterConnectionTypeId", Value = WaterConnectionTypeId }
                };
                var resultS = await _ctx.ConnectionTypeWiseConsumption.FromSqlRaw("EXECUTE [dbo].[rptConnectionTypewiseConsumption] @FromDate,@ToDate,@WaterConnectionTypeId", parms.ToArray()).ToListAsync();
                List<ConnectionTypeWiseConsumption> data = resultS.Select(s => new ConnectionTypeWiseConsumption
                {
                    Sl = s.Sl,
                    ConsumerNo = s.ConsumerNo,
                    MeterNo = s.MeterNo,
                    Consumption = s.Consumption,
                    TotalAmount = s.TotalAmount,
                    zonename = s.zonename,
                    waterConnectionType = s.waterConnectionType

                }
                     ).ToList();
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\ConnectionTypeWiseConsumption.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //********************** End ************************

        //********************** Connection Type Wise Revenue ************************
        [Route("Reports/Report/ConnetionTypeWiseWaterRevenue")]
        public IActionResult ConnetionTypeWiseWaterRevenue()
        {
            PopulateDropDowns();
            return View();
        }


        [Route("Reports/Report/PrintConnetionTypeWiseWaterRevenue")]
        public async Task<IActionResult> PrintConnetionTypeWiseWaterRevenue(DateTime FromDate, DateTime ToDate, int WaterConnectionTypeId)
        {
            try
            {

                //int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                string mimetype = "";
                int extension = 1;

                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = FromDate },
                    new SqlParameter { ParameterName = "@ToDate", Value = ToDate },
                    new SqlParameter { ParameterName = "@WaterConnectionTypeId", Value = WaterConnectionTypeId }
                };
                var resultS = await _ctx.ConnectionTypeWiseRevenue.FromSqlRaw("EXECUTE [dbo].[rptConnetionTypeWiseWaterRevenue] @FromDate,@ToDate,@WaterConnectionTypeId", parms.ToArray()).ToListAsync();
                List<ConnectionTypeWiseRevenue> data = resultS.Select(s => new ConnectionTypeWiseRevenue
                {
                    Sl = s.Sl,
                    ConsumerNo = s.ConsumerNo,
                    MeterNo = s.MeterNo,
                    TotalAmount = s.TotalAmount,
                    waterConnectionType = s.waterConnectionType,
                    billingAddress = s.billingAddress

                }
                     ).ToList();
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\ConnetionTypeWiseWaterRevenue.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //****************** END *********************


    }

}
