using ARMS.Functions;
using ARMS.Models;
using AspNetCore.Reporting;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Microsoft.Reporting;
//using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ARMS.Areas.Deposit.Controllers
{
    [Area("Deposit")]
    [Authorize]
    public class RevenueReportsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IDeposit _repository = new DepositBLL();
        //private object _IWebHostEnvironment;
        private readonly ILogger<RevenueReportsController> _logger;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        public RevenueReportsController(ILogger<RevenueReportsController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _IWebHostEnvironment = webHostEnvironment;
        }
        [Route("Deposit/Deposits")]
        public IActionResult Index()
        {
            _ = new List<IndividualDetails>();
            IList<IndividualDetails> obj = _repository.GetAll();
            return View();
        }

        [Route("Deposit/Deposits/GetDepositDetails")]
        public IEnumerable<DepositVM> GetDepositDetails(int StartDate, int EndDate)
        {
            HttpContext.Session.SetInt32("sdate", (int) StartDate);
            HttpContext.Session.SetInt32("edate", (int) EndDate);
            IEnumerable<DepositVM> _dList = null;

            return _dList = _repository.GetDepositDetails(StartDate, EndDate);
        }
        [HttpPost]
        [Route("Deposit/Deposits/GethouseDetails")]
        public JsonResult GethouseDetails([FromBody] List<DepositSaveVM> json_data)
        {

            //string sdate = Convert.ToString(HttpContext.Session.GetString("sdate"));
            //string edate = Convert.ToString(HttpContext.Session.GetString("edate"));

            //DateTime SDate = Convert.ToDateTime(sdate);
            //DateTime EDate = Convert.ToDateTime(edate);

            //bool checkDup = _repository.DateIfExists(SDate, EDate);
            
                
            if (json_data == null)
            {
                json_data = new List<DepositSaveVM>();
            }
            int returnvalue = 0;

            DepositSaveVM obj = new DepositSaveVM();

            foreach (DepositSaveVM item in json_data)
            {
                obj.PaymentFromDate = item.PaymentFromDate;
                obj.PaymentToDate = item.PaymentToDate;
            }

                DateTime sdate = obj.PaymentToDate;
                DateTime edate = obj.PaymentFromDate;

                DateTime SDate = sdate.Date;
                DateTime EDate = edate.Date;


                bool CheckDuplicate = _repository.DuplicateCheck(SDate, EDate);
                if (CheckDuplicate)
                {
                    TempData["msg"] = "Data Already Exist!!";
                }
                else
                {

                    foreach (DepositSaveVM item in json_data)
                    {

                        if (item.PaymentLedgerId == 0)
                        {
                            obj.PaymentLedgerId = null;

                        }
                        else
                        {
                            obj.PaymentLedgerId = item.PaymentLedgerId;

                        }
                        obj.DepositId = item.DepositId;
                        
                        obj.PaymentFromDate = item.PaymentFromDate;
                        obj.PaymentToDate = item.PaymentToDate;
                        obj.DepositAmount = item.DepositAmount;
                        obj.DepositDate = item.DepositDate;
                        obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                        obj.CreatedOn = DateTime.Now;
                        _repository.SaveDeposit(obj);
                    TempData["msg"] = "Record Saved!!";
                }

                }


            return Json(TempData["msg"]);

        }


        [Route("Deposit/Deposits/DepositUpdate")]
        public IActionResult DepositUpdate()
        {
            return View();
        }
        [Route("Deposit/Deposits/GetDepositupdatedisplay")]
        public List<DepositSaveVM> GetDepositupdatedisplay(string ChequeNo)
        {
            List<DepositSaveVM> _dList = null;

            return _dList = _repository.GetDepositupdatedisplay(ChequeNo);
        }
        [Route("Deposit/Deposits/GetDate")]
        public IList<DepositSaveVM> GetDate()
        {
            IList<DepositSaveVM> _dList = null;

            return _dList = _repository.GetDate();
        }
        //update
        [HttpPost]
        [Route("Deposit/Deposits/Update")]
        public JsonResult Update([FromBody] List<DepositSaveVM> json_data)
        {   

            if (json_data == null)
            {
                json_data = new List<DepositSaveVM>();
            }
            DepositSaveVM obj = new DepositSaveVM();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (DepositSaveVM item in json_data)
                    {

                        obj.DepositId = item.DepositId;
                        obj.PaymentStatusId = 2;

                        _repository.Update(obj);
                    }

                }
                catch(Exception ex)
                {
                    return null;
                }
               
            }
         
            return Json(TempData["msg"]);

        }

        [Route("Deposit/Deposits/PaymentDepositReport")]
        public IActionResult PaymentDepositReport()
        {

            return View();
        }
        [Route("Deposit/Deposits/PrintPaymentDepositReport")]
        public async Task<IActionResult> PrintPaymentDepositReport(int StartDate, int EndDate, DateTime sdate, DateTime edate)
        {
            //List<IndividualDetails> _dlist = null;
            //_dlist = (List<IndividualDetails>)_repository.GetAll();
            //if (_dlist.Count > 0)
            //{
            //    HttpContext.Session.SetString("name", _dlist.FirstOrDefault().CreatedBy);
            //}

            string mimetype = "";
            int extension = 1;
            DateTime date = sdate;
            DateTime date1 = edate;
            string SDate = sdate.ToString("dd-MM-yyyy").Replace('-', '/');
            string EDate = edate.ToString("dd-MM-yyyy").Replace('-', '/');
            string UserName = Convert.ToString(HttpContext.Session.GetString("name"));
            var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptPaymentDepositReport.rdlc";
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("rp1", SDate);
            parameter.Add("rp2", EDate);
           // parameter.Add("un", UserName);

            LocalReport lc = new LocalReport(ReportPath);
            try
            {
                var data = _repository.GetPaymentDepositReport(StartDate, EndDate);
                lc.AddDataSource("DataSet1", data);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;

            }


        }
    }
}
