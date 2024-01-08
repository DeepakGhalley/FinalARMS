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
    public class Report1sController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        readonly IReports _repository = new ReportBLL();

        private readonly IWebHostEnvironment _IWebHostEnvironment;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly tt_dbContext _ctx = new tt_dbContext();
        public Report1sController(ILogger<ReportController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _IWebHostEnvironment = webHostEnvironment;
        }
        private void PopulateDropDowns()
        {

            ViewData["zone"] = _CommonRepo.SelectListZone();
            

        }
        
        [Route("Reports/rptGetWaterConsumptions/Index")]
        public IActionResult Index()
        {
            PopulateDropDowns();
            return View();
        }

        //[Route("Reports/rptGetWaterConsumptions/GetWaterConsumption")]
        //public IActionResult GetWaterConsumption()
        //{
        //    PopulateDropDowns();
        //    return View();
        //}

        //[Route("Reports/rptGetWaterConsumptions/PrintWaterConsumption")]
        //public async Task<IActionResult> PrintWaterConsumption(int zoneId)
        //{

        //    string mimetype = "";
        //    int extension = 1;
        //    int ZoneId = zoneId;
        //    var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptGetWaterConsumption.rdlc";
        //    Dictionary<string, string> parameter = new Dictionary<string, string>();
        //   // parameter.Add("cy", ZoneId);
        //    LocalReport lc = new LocalReport(ReportPath);
        //    try
        //    {
        //        ReportBLL objrpt = new ReportBLL();

        //        var data = objrpt.getSuccessIndicators(ZoneId);
        //        lc.AddDataSource("DataSet1", data); 
        //        var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
        //        return File(result.MainStream, "application/pdf");
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;

        //    }

        //}
        

        [Route("Reports/rptGetWaterConsumptions/PrintWaterConsumption")]
        public async Task<IActionResult> PrintWaterConsumption(int zoneId)
        {

            string mimetype = "";
            int extension = 1;
            var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptGetWaterConsumption.rdlc";
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            LocalReport lc = new LocalReport(ReportPath);
            var data = _repository.GetWaterConsumption(zoneId);
            lc.AddDataSource("DataSet1", data);
            var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
            return File(result.MainStream, "application/pdf");

        }

        //********************** Connection Type Wise Revenue ************************
        [Route("Reports/Report1s/PrecinctWiseCountReport")]
        public IActionResult PrecinctWiseCountReport()
        {
            return View();
        }

        [Route("Reports/Report/PrintPrecinctWiseCountReport")]
        public async Task<IActionResult> PrintPrecinctWiseCountReport()
        {
            try
            {

                string mimetype = "";
                int extension = 1;
                var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\PrecinctWiseCountReport.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();

                LocalReport lc = new LocalReport(ReportPath);
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    //new SqlParameter { ParameterName = "@ReadingMonth"},
                };
                var resultS = await _ctx.PrecinctWiseCountReport.FromSqlRaw("EXECUTE [dbo].[rptPrescinctWiseCunt]", parms.ToArray()).ToListAsync();
                List<PrecinctWiseCountReportVM> data = resultS.Select(s => new PrecinctWiseCountReportVM
                {
                    Sl = s.Sl,
                    LandUseCategory = s.LandUseCategory,
                    LandUseSubCategory = s.LandUseSubCategory,
                    LandCount = s.LandCount,
                    TotalLandAcerage = s.TotalLandAcerage,
                    BuildingCount = s.BuildingCount,

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
        //********************** Connection Type Wise Revenue ************************


    }
}
