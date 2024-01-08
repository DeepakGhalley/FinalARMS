using ARMS.Functions;
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
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ARMS.Areas.Reports.Controllers
{
    [Area("Reports")]
    public class Report2sController : Controller
    {
        private readonly ILogger<Report2sController> _logger;
        readonly IReports _repository = new ReportBLL();
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly tt_dbContext _ctx = new tt_dbContext();
        public Report2sController(ILogger<Report2sController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _IWebHostEnvironment = webHostEnvironment;
        }

        private void PopulateDropDowns()
        {

            ViewData["MonthId"] = _CommonRepo.SelectListMonths();
            ViewData["YearId"] = _CommonRepo.SelectListCalYear();
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();

        }

        //*********************************************Monthly Meter Reader*****************************************
        [Route("Reports/Report2s/MonthlyMeterReader")]
        public IActionResult MonthlyMeterReader()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report2s/PrintMonthlyMeterReading")]
        public async Task<IActionResult> PrintMonthlyMeterReading(int ZoneId, int MonthId, int YearId, string Zone, string Month, string Year)
        {  
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptMonthlyMeterReader.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@ZoneId", Value = ZoneId },
                    new SqlParameter { ParameterName = "@MonthId", Value = MonthId },
                    new SqlParameter { ParameterName = "@YearId", Value = YearId },
                };
                var resultS = await _ctx.GetMonthlyMeterReading.FromSqlRaw("EXECUTE [dbo].[rptMonthlyMeterReader] @ZoneId, @MonthId, @YearId", parms.ToArray()).ToListAsync();
                List<Report2VM> data = resultS.Select(s => new Report2VM
                {
                    Sl = s.Sl,
                    ConsumerNo = s.ConsumerNo,
                    BillingAddress = s.BillingAddress,
                    MeterNo = s.MeterNo,
                    PrevReading = s.PrevReading,
                    PrevReadingDate = s.PrevReadingDate,
                    zoneName = s.zoneName,
                    ReadingYearMonth = s.ReadingYearMonth
                    
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

        //*********************************************ZONE WISE WATER COLLECTION*****************************************
        [Route("Reports/Report2s/ZoneWiseWaterCollection")]
        public IActionResult ZoneWiseWaterCollection()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report2s/PrintZoneWiseWaterCollection")]
        public async Task<IActionResult> PrintZoneWiseWaterCollection(int ZoneId, string Zone)
        {
            
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptZoneWiseWaterCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@ZoneId", Value = ZoneId },
                };
                var resultS = await _ctx.GetZoneWiseWaterCollection.FromSqlRaw("EXECUTE [dbo].[rptZoneWiseWaterCollection] @ZoneId", parms.ToArray()).ToListAsync();
                List<ZoneWiseWaterCollection> data = resultS.Select(s => new ZoneWiseWaterCollection
                {
                    Sl = s.Sl,
                    WaterConnectionType = s.WaterConnectionType,
                    TotalNo = s.TotalNo,
                    zonename = s.zonename
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

        //*****************************************************WATER ACCOUNT WISE REPORT**********************************************
        [Route("Reports/Report2s/WaterAccountWiseReport")]
        public IActionResult WaterAccountWiseReport()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report2s/PrintWaterAccountWiseReport")]
        public async Task<IActionResult> PrintWaterAccountWiseReport(int FromDate, int ToDate)
        {

            try
            {
                
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptWaterAccountWiseReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)
                    new SqlParameter { ParameterName = "@FromDate", Value = FromDate },
                    new SqlParameter { ParameterName = "@ToDate", Value = ToDate },
                };
                var resultS = await _ctx.GetWaterAccountWiseReport.FromSqlRaw("EXECUTE [dbo].[?] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
                List<WaterAccountWiseReport> data = resultS.Select(s => new WaterAccountWiseReport
                {
                    Sl = s.Sl,
                    Months = s.Months,
                    BillNo = s.BillNo,
                    PayStatus = s.PayStatus,
                    PaymentAmount = s.PaymentAmount,
                    TaxName = s.TaxName,
                    PrevReading = s.PrevReading,
                    CurrReading = s.CurrReading,
                    Consumption = s.Consumption,
                    ConnectionStatus = s.ConnectionStatus,
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

        //********************************************ZONE WISE WATER CONSUMPTION**********************************
        [Route("Reports/Report2s/ZoneWiseWaterConsumption")]
        public IActionResult ZoneWiseWaterConsumption()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report2s/PrintZoneWiseWaterConsumption")]
        public async Task<IActionResult> PrintZoneWiseWaterConsumption(int ZoneId, string YearId, string ZoneName)
        {
            
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptZoneWiseWaterConsumption.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("zn", ZoneName);
                //parameter.Add("yn", YearId);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@ZoneId", Value = ZoneId },
                    new SqlParameter { ParameterName = "@YearId", Value = YearId },
                };
                var resultS = await _ctx.GetZoneWiseWaterConsumption.FromSqlRaw("EXECUTE [dbo].[rptZoneWiseWaterConsumption] @ZoneId,@YearId", parms.ToArray()).ToListAsync();
                List<ZoneWiseWaterConsumption> data = resultS.Select(s => new ZoneWiseWaterConsumption
                {
                    Sl = s.Sl,
                    Yr = s.Yr,
                    ConsumerNo = s.ConsumerNo,
                    MeterNo = s.MeterNo,
                    Consumption = s.Consumption,
                    PaymentStatus = s.PaymentStatus,
                    TotalAmount = s.TotalAmount,
                    zonename = s.zonename
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

        //*******************************************MONTHLY ZONE WISE WATER CONSUMPTION************************
        [Route("Reports/Report2s/MonthlyZoneWiseWaterConsumption")]
        public IActionResult MonthlyZoneWiseWaterConsumption()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Reports/Report2s/PrintMonthlyZoneWiseWaterConsumption")]
        public async Task<IActionResult> PrintMonthlyZoneWiseWaterConsumption(int ZoneId, string YearId, string ZoneName, int MonthId, string MonthName)
        {
            
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptMonthlyZoneWiseWaterConsumption.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                //parameter.Add("zn", ZoneName);
                //parameter.Add("yn", YearId);
                //parameter.Add("mn", MonthName);

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@ZoneId", Value = ZoneId },
                    new SqlParameter { ParameterName = "@YearId", Value = YearId },
                    new SqlParameter { ParameterName = "@MonthId", Value = MonthId },
                };
                var resultS = await _ctx.GetMonthlyZoneWiseWaterConsumption.FromSqlRaw("EXECUTE [dbo].[rptMonthlyZoneWiseWaterConsumption] @ZoneId, @YearId, @MonthId", parms.ToArray()).ToListAsync();
                List<MonthlyZoneWiseWaterConsumption> data = resultS.Select(s => new MonthlyZoneWiseWaterConsumption
                {
                    Sl = s.Sl,
                    ConsumerNo = s.ConsumerNo,
                    Yr = s.Yr,
                    Mnths = s.Mnths,
                    MeterNo = s.MeterNo,
                    Consumption = s.Consumption,
                    PaymentStatus = s.PaymentStatus,
                    TotalAmount = s.TotalAmount,
                    zonename = s.zonename

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

        //*******************************DEMAND CANCEL REPORT**************************************

        [Route("Reports/Report2s/DemandCancel")]
        public IActionResult DemandCancel()
        {

            return View();
        }
        [Route("Reports/Report2s/PrintDemandCancelReport")]
        public async Task<IActionResult> PrintDemandCancelReport(string FromDate, string ToDate, string DemandNo)
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptDemandCancel.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                if (DemandNo == null)
                {
                    DemandNo = "";
                }
                if (FromDate == null && ToDate == null)
                {
                    FromDate = "";
                    ToDate = "";
                }

                if(DemandNo != null && FromDate != null && ToDate != null)
                {
                    DemandNo = DemandNo;
                    FromDate = FromDate;
                    ToDate = ToDate;

                }

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)
                   
                    new SqlParameter { ParameterName = "@FromDate", Value = FromDate },
                    new SqlParameter { ParameterName = "@ToDate", Value = ToDate },
                    new SqlParameter { ParameterName = "@DemandNo", Value = DemandNo }
                };
                var resultS = await _ctx.DemandCancel.FromSqlRaw("EXECUTE [dbo].[rptDemandCancelReport] @FromDate,@ToDate,@DemandNo", parms.ToArray()).ToListAsync();
                List<DemandCancelModel> data = resultS.Select(s => new DemandCancelModel
                {
                    Sl = s.Sl,
                    TotalCancelAmount = s.TotalCancelAmount,
                    TaxPayerName = s.TaxPayerName,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    DemandNo = s.DemandNo,
                    CID = s.CID,
                    TTIN = s.TTIN,
                    remarks = s.remarks

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
        //********************* END ***********************



        //***************  Online Payment Reconciliations Report   *******************
        [Route("Reports/Report2s/OnlinePaymentReconciliations")]
        public IActionResult OnlinePaymentReconciliations()
        {
            return View();
        }

        [Route("Reports/Report/PrintOnlinePaymentReconciliations")]
        public async Task<IActionResult> PrintOnlinePaymentReconciliations(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\OnlinePaymentReconciliationsReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@StartDate", Value = sdate },
                    new SqlParameter { ParameterName = "@EndDate", Value = edate }

                };
                var resultS = await _ctx.OnlinePaymentReconciliationsReport.FromSqlRaw("EXECUTE [dbo].[rptOnlinepaymentreconciliations] @StartDate,@EndDate", parms.ToArray()).ToListAsync();

                List<OnlinePaymentReconciliationsReport> data = resultS.Select(s => new OnlinePaymentReconciliationsReport
                {
                    sl = s.sl,
                    bfs_orderNo = s.bfs_orderNo,
                    transactionType = s.transactionType,
                    bfs_txnAmount = s.bfs_txnAmount,
                    createdOn = s.createdOn,
                    Names = s.Names,
                    ttin = s.ttin,
                    cid = s.cid,
                    PlotNo = s.PlotNo,
                    ThramNo = s.ThramNo,
                    WaterMeterNo = s.WaterMeterNo,
                    ConsumerNo = s.ConsumerNo

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
        //********************** End************************

        //***************  PAYMENT MODDE WISE COLLECTION REPORT  *******************
        [Route("Reports/Report2s/PaymentModeWiseCollection")]
        public IActionResult PaymentModeWiseCollection()
        {
            return View();
        }

        [Route("Reports/Report2s/pPaymentModeWiseCollection")]
        public async Task<IActionResult> pPaymentModeWiseCollection(DateTime sdate, DateTime edate)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\PaymentModeWiseCollection.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@FromDate", Value = sdate },
                    new SqlParameter { ParameterName = "@ToDate", Value = edate }

                };
                var resultS = await _ctx.PaymentModeWiseReport.FromSqlRaw("EXECUTE [dbo].[rptPaymentModeWiseCollection] @FromDate,@ToDate", parms.ToArray()).ToListAsync();

                List<PaymentModeWiseReport> data = resultS.Select(s => new PaymentModeWiseReport
                {
                    Sl = s.Sl,
                    ReceiptNo = s.ReceiptNo,
                    PaymentModeNo = s.PaymentModeNo,
                    PaymentModeDate = s.PaymentModeDate,
                    PaymentDate = s.PaymentDate,
                    grandTotal = s.grandTotal,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    UserName = s.UserName,
                    ExecutionDate = s.ExecutionDate,
                    Cash = s.Cash,
                    Cheque = s.Cheque,
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
                    ScanPay = s.ScanPay
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

        //********************** End************************


    }
}











