﻿using ARMS.Functions;
using ARMS.Models;
using AspNetCore.Reporting;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Reporting;
//using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static CORE_BOL.APImodel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
namespace ARMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IOnlinePayment _repository = new OnlinePaymentBLL();
        readonly ILedger _repository1 = new LedgerBLL();
        readonly IReports _repo = new ReportBLL();
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        readonly tt_dbContext _ctx = new tt_dbContext();
        readonly IBfsTranaction _repository2 = new BfsTranactionBLL();
        //IConfiguration _Configure; 
        string BFSurl = "";
        string BenificiaryId = "";
        string PrivateKeyPath = "";
        string BFSEmail = "";
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment,IConfiguration _Conf)
        {
            _logger = logger;
            _IWebHostEnvironment = webHostEnvironment;
            BFSurl = _Conf.GetSection("PaymentGatewaySettings").GetSection("PaymentGateWay").Value;
            BenificiaryId = _Conf.GetSection("PaymentGatewaySettings").GetSection("BenificiaryId").Value;
            PrivateKeyPath = _Conf.GetSection("PaymentGatewaySettings").GetSection("PrivateKeyPath").Value;
            BFSEmail = _Conf.GetSection("SmtpSettings").GetSection("BFSEmail").Value;
        }

        public IActionResult Index()
        {
            //int sqO = _ctx.TblReceipt.Where(p => p.ReceiptYear == DateTime.Now.Year).Max(p => p.Sl);
            //int sqWEB = _ctx.TblReceipt.Where(p => p.ReceiptYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;

            //String DateString = Convert.ToString("20/12/1993");
            //DateTime dt = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateString));
            return View();
        }
        public IActionResult CitizenServices()
        {
            return View();
        }
        //[HttpGet]
        [Route("Home/OnlineWaterBillPayment")]
        public IActionResult OnlineWaterBillPayment()
        {
            return View();
        }
        //[HttpPost]
        //[Route("Home/OnlineWaterBillPayment")]
        //public IActionResult OnlineWaterBillPayment(BfsModel obj)//string id, decimal totalamount)
        //{
        //    obj.BfsTxnAmount = Convert.ToDecimal("1");
        //    //PayOnline(Convert.ToDecimal("0.01"));
        //    string _message = "";
        //    string _status = "";

        //    string bfs_msgType = "AR".Trim();
        //    string bfsBankCode = "01".Trim();
        //    String bfs_txnCurrency = "BTN".Trim();
        //    string bfs_paymentDesc = "Thromde Payment".Trim();
        //    string BFSVersion = "1.0".Trim();
        //    string sourceString = "";
        //    string trnTime = "";
        //    DateTime dt = DateTime.Now;
        //    trnTime = String.Format("{0:yyyyMMddHHmmss}", dt);
        //    ////order no generation
        //    Random rnd = new Random();
        //    string myRandomNo = Convert.ToString(rnd.Next(10000, 99999));
        //    string orderNo = Convert.ToString(trnTime + myRandomNo.ToString()).Trim();
        //    string amount = string.Format("{0:0.00}", ((Convert.ToDecimal(obj.BfsTxnAmount)))).Trim();
        //    sourceString = ((bfsBankCode + "|").Trim() + (BenificiaryId + "|").Trim() + (trnTime + "|").Trim() + (bfs_msgType + "|").Trim() + (orderNo + "|").Trim() + (bfs_paymentDesc + "|").Trim() + (BFSEmail + "|").Trim() + amount + ("|BTN|1.0").Trim()).ToString();


        //    string SignedString = "";
        //    Safe.SafeUtil ssl = new Safe.SafeUtil();
        //    SignedString = ssl.Sign(sourceString, PrivateKeyPath);

        //    ViewBag.PaymentGateway = BFSurl;

        //    ViewBag.bfs_benfBankCode = bfsBankCode;
        //    ViewBag.BenificiaryID = BenificiaryId;
        //    ViewBag.bfs_benfTxnTime = trnTime;
        //    ViewBag.bfs_msgType = bfs_msgType;
        //    ViewBag.bfs_orderNo = orderNo;
        //    ViewBag.bfs_paymentDesc = bfs_paymentDesc;
        //    ViewBag.bfs_remitterEmail = BFSEmail;
        //    ViewBag.bfs_txnAmount = amount;
        //    ViewBag.bfs_txnCurrency = bfs_txnCurrency;
        //    ViewBag.bfs_version = BFSVersion;
        //    ViewBag.bfs_checkSum = SignedString;


        //    BfsModel objBfs = new BfsModel();
        //    objBfs.BfsBenfBankCode = bfsBankCode;
        //    objBfs.BfsPaymentDesc = bfs_paymentDesc;
        //    objBfs.BfsRemitterEmail = BFSEmail;
        //    objBfs.BfsVersion = BFSVersion;
        //    objBfs.BfsChecksum = SignedString;
        //    objBfs.BfsTxnCurrency = bfs_txnCurrency;
        //    objBfs.BfsBenfId = BenificiaryId;
        //    objBfs.BfsOrderNo = orderNo;
        //    objBfs.BfsTxnAmount = Convert.ToDecimal(amount);
        //    objBfs.BfsBenfTxnTime = trnTime;
        //    objBfs.BfsMsgType = bfs_msgType;
        //    objBfs.PaymentDate = DateTime.Now;
        //    objBfs.DemandIds = obj.DemandIds;

        //    long pk = _repository2.SaveBFS(objBfs);
        //    return RedirectToAction("PaymentGateWayRedirect");
        //    //return View();
        //}
        public IActionResult OnlinePropertyTaxPayment()
        {
            return View();
        }
        public IActionResult ConstructionApproval()
        {
            return View();
        }

        public IActionResult Miscellaneous()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        [HttpPost]
        [Route("Home/PaymentGateWayRedirect")]
        public async Task<IActionResult> PaymentGateWayRedirect(BfsModel obj)//string id, decimal totalamount)
        {
            //obj.BfsTxnAmount = Convert.ToDecimal("10.00");

            string bfs_msgType = "AR".Trim();
            string bfsBankCode = "01".Trim();
            String bfs_txnCurrency = "BTN".Trim();
            string bfs_paymentDesc = "Thromde Payment".Trim();
            string BFSVersion = "1.0".Trim();
          
            DateTime dt = DateTime.Now;
          string  trnTime = String.Format("{0:yyyyMMddHHmmss}", dt);
            ////order no generation
            Random rnd = new Random();
            string myRandomNo = Convert.ToString(rnd.Next(10000, 99999));
            string orderNo = Convert.ToString(trnTime + myRandomNo.ToString()).Trim();
            string amount = string.Format("{0:0.00}", ((Convert.ToDecimal(obj.BfsTxnAmount)))).Trim();
           string  sourceString = ((bfsBankCode + "|").Trim() + (BenificiaryId + "|").Trim() + (trnTime + "|").Trim() + (bfs_msgType + "|").Trim() + (orderNo + "|").Trim() + (bfs_paymentDesc + "|").Trim() + (BFSEmail + "|").Trim() + amount + ("|BTN|1.0").Trim()).ToString();


            string SignedString = "";
            Safe.SafeUtil ssl = new Safe.SafeUtil();
            SignedString = ssl.Sign(sourceString, PrivateKeyPath);
            ViewBag.PaymentGateway = BFSurl;
            ViewBag.bfs_benfBankCode = bfsBankCode;
            ViewBag.BenificiaryID = BenificiaryId;
            ViewBag.bfs_benfTxnTime = trnTime;
            ViewBag.bfs_msgType = bfs_msgType;
            ViewBag.bfs_orderNo = orderNo;
            ViewBag.bfs_paymentDesc = bfs_paymentDesc;
            ViewBag.bfs_remitterEmail = BFSEmail;
            ViewBag.bfs_txnAmount = amount;
            ViewBag.bfs_txnCurrency = bfs_txnCurrency;
            ViewBag.bfs_version = BFSVersion;
            ViewBag.bfs_checkSum = SignedString;

            BfsModel objBfs = new BfsModel();
            objBfs.BfsBenfBankCode = bfsBankCode;
            objBfs.BfsPaymentDesc = bfs_paymentDesc;
            objBfs.BfsRemitterEmail = BFSEmail;
            objBfs.BfsVersion = BFSVersion;
            objBfs.BfsChecksum = SignedString;
            objBfs.BfsTxnCurrency = bfs_txnCurrency;
            objBfs.BfsBenfId = BenificiaryId;
            objBfs.BfsOrderNo = orderNo;
            objBfs.BfsTxnAmount = Convert.ToDecimal(amount);
            objBfs.BfsBenfTxnTime = trnTime;
            objBfs.BfsMsgType = bfs_msgType;
            objBfs.PaymentDate = DateTime.Now;
            objBfs.DemandIds = obj.DemandIds;
            objBfs.BfsStatusState = "PG Redirect";
            long pk = _repository2.SaveBFS(objBfs);
            return View();
        }


        [Route("Home/PayOnline")]
        public async void PayOnline(decimal totalamount)
        {
            string _message = "";
            string _status = "";

            //string PaymentGateway = Convert.ToString(_configuration.GetSection("PaymentGatewaySettings").GetSection("GateWay").Value).Trim();
            string bfs_msgType = "AR".ToString().Trim();
            ////string trid = (((DateTime.Now.Year).ToString() + DateTime.Now.Month.ToString("MM") + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString())).ToString().Trim();
            ////string orderNo = Convert.ToString(trid);//chk
            string BenificiaryID = "BE10000061";//WEB
            //Convert.ToString((_configuration.GetSection("PaymentGatewaySettings").GetSection("BenificiaryId").Value)).Trim();
            string bfsBankCode = "01";
            //Convert.ToString((_configuration.GetSection("PaymentGatewaySettings").GetSection("bankCodeBankCode").Value).Trim());
            String bfs_txnCurrency = "BTN".ToString().Trim();
            string email = "narayan@itechnologies.bt".ToString().Trim();
            string bfs_paymentDesc = "Thromde Payment".ToString().Trim();
            string BFSVersion = "1.0";
            //Convert.ToString(_configuration.GetSection("PaymentGatewaySettings").GetSection("BFSVersion").Value);
            //string privatekeyPath = Convert.ToString(_configuration.GetSection("PaymentGatewaySettings").GetSection("PrivateKeyPath").Value).Trim();
            string sourceString = "";
            string trnTime = "";
            DateTime dt = DateTime.Now;
            trnTime = String.Format("{0:yyyyMMddHHmmss}", dt);
            ////order no generation
            Random rnd = new Random();
            string myRandomNo = Convert.ToString(rnd.Next(10000, 99999));
            string orderNo = Convert.ToString(trnTime + myRandomNo.ToString()).Trim();
            //string amount = string.Format("{0:0.00}", ((Convert.ToDecimal("0.01"))));
            string amount = string.Format("{0:0.00}", ((Convert.ToDecimal(totalamount))));
            //// + Convert.ToDecimal(CurrentPenalty)).ToString()).Trim();
            sourceString = (bfsBankCode + "|" + BenificiaryID + "|" + trnTime + "|" + bfs_msgType + "|" + orderNo + "|" + bfs_paymentDesc + "|" + email + "|" + amount + "|" + bfs_txnCurrency + "|" + BFSVersion).ToString();


            string SignedString = "";
            Safe.SafeUtil ssl = new Safe.SafeUtil();
            SignedString = ssl.Sign(sourceString, "C:\\thromde_BFS_key\\BE10000061.key");

            ViewBag.PaymentGateway = "https://bfssecure.rma.org.bt/BFSSecure/makePayment";

            ViewBag.bfs_benfBankCode = bfsBankCode;
            ViewBag.BenificiaryID = BenificiaryID;
            ViewBag.bfs_benfTxnTime = trnTime;
            ViewBag.bfs_msgType = bfs_msgType;
            ViewBag.bfs_orderNo = orderNo;
            ViewBag.bfs_paymentDesc = bfs_paymentDesc;
            ViewBag.bfs_remitterEmail = email;
            ViewBag.bfs_txnAmount = amount;
            ViewBag.bfs_txnCurrency = bfs_txnCurrency;
            ViewBag.bfs_version = BFSVersion;
            ViewBag.bfs_checkSum = SignedString;
        }

        [Route("Home/pgRedirect")]
        public IActionResult pgRedirect()
        {

            return View();
        }

        //for Online Property Tax Payment
        [Route("Home/GetDemandDetail")]
        public List<LedgerDemandVM> GetDemandDetail(string id)
        {
            List<LedgerDemandVM> _dList = null;

            return _dList = _repository.GetDemandDetail(id);
        }

        [Route("Home/GetDemandWithSearch")]
        public List<OnlinePropertyTaxPaymentVM> GetDemandWithSearch(string ttin,string cid)
        {
            List<OnlinePropertyTaxPaymentVM> _dList = null;

            return _dList = _repository.GetDemandWithSearch(ttin, cid).ToList();
        }


        //for Online Water Bill Payment

        [Route("Home/GetWaterDemandDetail")]
        public List<LedgerDemandVM> GetWaterDemandDetail(string id)
        {
            return _repository1.GetDemandDetail(id).ToList();
        }



        [Route("Home/GetDemandWithSearchWaterBill")]
        public List<OnlineWaterBillPaymentVM> GetDemandWithSearchWaterBill(string ConsumerNo)
        {
            List<OnlineWaterBillPaymentVM> _dList = null;

            return _dList = _repository.GetDemandWithSearchWaterBill(ConsumerNo).ToList();
        }

        //public async Task< IActionResult> PrintReport()
        //{
        //    DateTime fd = Convert.ToDateTime(DateTime.Today.AddDays(-1));
        //    DateTime td = Convert.ToDateTime(DateTime.Now);

        //    //// 1st type
        //    //List<OnlinePaymentByFromDateToDateModel> resultS;
        //    //string sql = "EXEC [dbo].[rptOnlinePaymentByFromDateToDate] @FromDate, @ToDate";

        //    //List<SqlParameter> parms = new List<SqlParameter>
        //    //{
        //    //    // Create parameter(s)    
        //    //    new SqlParameter { ParameterName = "@FromDate", Value = fd },
        //    //    new SqlParameter { ParameterName = "@ToDate", Value = td }
        //    //};

        //    ////resultS = _ctx.OnlinePaymentByFromDateToDate.FromSqlRaw<OnlinePaymentByFromDateToDateModel>(sql, parms.ToArray()).ToList();
        //    //resultS = _ctx.OnlinePaymentByFromDateToDate.FromSqlRaw(sql, parms.ToArray()).ToList();
        //    //// 1st type end
        //    string mimetype = "";
        //    int extension = 1;
        //    var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptOnlinePaymentByFromDateToDate.rdlc";
        //    Dictionary<string, string> parameter = new Dictionary<string, string>();
        //    LocalReport lc = new LocalReport(ReportPath);
        //    //sp
        //    List<SqlParameter> parms = new List<SqlParameter>
        //        {
        //            // Create parameter(s)    
        //            new SqlParameter { ParameterName = "@FromDate", Value = fd },
        //            new SqlParameter { ParameterName = "@ToDate", Value = td }
        //        };
        //    var resultS = await _ctx.OnlinePaymentByFromDateToDate.FromSqlRaw("EXECUTE [dbo].[rptOnlinePaymentByFromDateToDate] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
        //    List<OnlinePaymentByFromDateToDateModel> data = resultS.Select(s => new OnlinePaymentByFromDateToDateModel
        //    {
        //        Sl = s.Sl,
        //        PaymentDate = s.PaymentDate,
        //        ReceiptNo = s.ReceiptNo,
        //        PaymentModeNo = s.PaymentModeNo,
        //        PaymentModeDate = s.PaymentModeDate,
        //        TotalAmount = s.TotalAmount
        //    }
        //         ).ToList();
        //    //sp end
        //    lc.AddDataSource("DataSet1", resultS);
        //    var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}
        //public async Task<IActionResult> PrintReport2()
        //{

        //    string mimetype = "";
        //    int extension = 1;
        //    var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
        //    Dictionary<string, string> parameter = new Dictionary<string, string>();
        //    LocalReport lc = new LocalReport(ReportPath);
        //    var data = await _repository.GetMenu();
        //    lc.AddDataSource("DataSet1", data);
        //    var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}
        //public DataTable GetEmployeeList()
        //    {

        //    var dt = new DataTable();

        //    var data = _ctx.TblMenu.Where(r => r.Isactive == 1);

        //   dt = LINQResultToDataTable(data);
        //    return dt;


        //    }

        //public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        //{
        //    DataTable dt = new DataTable();
        //    PropertyInfo[] columns = null;

        //    if (Linqlist == null) return dt;

        //    foreach (T Record in Linqlist)
        //    {

        //        if (columns == null)
        //        {
        //            columns = ((Type)Record.GetType()).GetProperties();
        //            foreach (PropertyInfo GetProperty in columns)
        //            {
        //                Type colType = GetProperty.PropertyType;

        //                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
        //                == typeof(Nullable<>)))
        //                {
        //                    colType = colType.GetGenericArguments()[0];
        //                }

        //                dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
        //            }
        //        }

        //        DataRow dr = dt.NewRow();

        //        foreach (PropertyInfo pinfo in columns)
        //        {
        //            dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
        //            (Record, null);
        //        }

        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
        [Route("Home/PaymentSuccess")]
        public IActionResult PaymentSuccess()
        {
            string bfs_bfsTxnId = Request.Form["bfs_bfsTxnId"];
            string bfs_debitAuthNo = Request.Form["bfs_debitAuthNo"];
            string bfs_remitterName = Request.Form["bfs_remitterName"];
            string bfs_txnCurrency = Request.Form["bfs_txnCurrency"];
            string bfs_checkSum = Request.Form["bfs_checkSum"];
            string bfs_bfsTxnTime = Request.Form["bfs_bfsTxnTime"];
            string bfs_benfId = Request.Form["bfs_benfId"];
            string bfs_remitterBankId = Request.Form["bfs_remitterBankId"];
            string bfs_orderNo = Request.Form["bfs_orderNo"];
            string bfs_debitAuthCode = Request.Form["bfs_debitAuthCode"];
            string bfs_txnAmount = Request.Form["bfs_txnAmount"];
            string bfs_benfTxnTime = Request.Form["bfs_benfTxnTime"];
            string bfs_msgType = Request.Form["bfs_msgType"];
           
            BfsModel objBfs = new BfsModel();
            //objBfs.BfsResponseDesc = "Thromde ";
            objBfs.BfsBfsTxnId = bfs_bfsTxnId;
            objBfs.BfsDebitAuthNo = bfs_debitAuthNo;
            objBfs.BfsRemitterName = bfs_remitterName;
            objBfs.BfsTxnCurrency = bfs_txnCurrency;
            objBfs.BfsChecksum = bfs_checkSum;
            objBfs.BfsTxnTime = bfs_bfsTxnTime;
            objBfs.BfsBenfId = bfs_benfId;
            objBfs.BfsRemitterBankId = bfs_remitterBankId;
            objBfs.BfsOrderNo = bfs_orderNo;
            objBfs.BfsDebitAuthCode = bfs_debitAuthCode;
            objBfs.BfsTxnAmount = Convert.ToDecimal(bfs_txnAmount);
            objBfs.BfsBenfTxnTime = bfs_benfTxnTime;
            objBfs.BfsMsgType = bfs_msgType;
            //objBfs.PaymentDate = DateTime.Now;
            objBfs.BfsStatusState = "Success";
            long pk = _repository2.SavePaymentSuccess(objBfs);

            return View(objBfs);
        }
        [Route("Home/PaymentFailure")]
        public IActionResult PaymentFailure()
        {
            //BfsModel objBfs = new BfsModel();
            //try
            //{
            //    string bfs_bfsTxnId = Request.Form["bfs_bfsTxnId"];
            //    string bfs_debitAuthNo = Request.Form["bfs_debitAuthNo"];
            //    string bfs_remitterName = Request.Form["bfs_remitterName"];
            //    string bfs_txnCurrency = Request.Form["bfs_txnCurrency"];
            //    string bfs_checkSum = Request.Form["bfs_checkSum"];
            //    string bfs_bfsTxnTime = Request.Form["bfs_bfsTxnTime"];
            //    string bfs_benfId = Request.Form["bfs_benfId"];
            //    string bfs_remitterBankId = Request.Form["bfs_remitterBankId"];
            //    string bfs_orderNo = Request.Form["bfs_orderNo"];
            //    string bfs_debitAuthCode = Request.Form["bfs_debitAuthCode"];
            //    string bfs_txnAmount = Request.Form["bfs_txnAmount"];
            //    string bfs_benfTxnTime = Request.Form["bfs_benfTxnTime"];
            //    string bfs_msgType = Request.Form["bfs_msgType"];

              
            //    objBfs.BfsBfsTxnId = bfs_bfsTxnId;
            //    objBfs.BfsDebitAuthNo = bfs_debitAuthNo;
            //    objBfs.BfsRemitterName = bfs_remitterName;
            //    objBfs.BfsTxnCurrency = bfs_txnCurrency;
            //    objBfs.BfsChecksum = bfs_checkSum;
            //    objBfs.BfsTxnTime = bfs_bfsTxnTime;
            //    objBfs.BfsBenfId = bfs_benfId;
            //    objBfs.BfsRemitterBankId = bfs_remitterBankId;
            //    objBfs.BfsOrderNo = bfs_orderNo;
            //    objBfs.BfsDebitAuthCode = bfs_debitAuthCode;
            //    objBfs.BfsTxnAmount = Convert.ToDecimal(bfs_txnAmount);
            //    objBfs.BfsBenfTxnTime = bfs_benfTxnTime;
            //    objBfs.BfsMsgType = bfs_msgType;
            //    objBfs.PaymentDate = DateTime.Now;
            //    objBfs.BfsStatusState = "bfsFailure";
            //    _repository2.SavePaymentFailure(objBfs);

            //}
            //catch ( Exception ex ) 
            //{
            //    //string bfs_bfsTxnId = Request.Form["bfs_bfsTxnId"];
            //    //string bfs_debitAuthNo = Request.Form["bfs_debitAuthNo"];
            //    //string bfs_remitterName = Request.Form["bfs_remitterName"];
            //    //string bfs_txnCurrency = Request.Form["bfs_txnCurrency"];
            //    //string bfs_checkSum = Request.Form["bfs_checkSum"];
            //    //string bfs_bfsTxnTime = Request.Form["bfs_bfsTxnTime"];
            //    //string bfs_benfId = Request.Form["bfs_benfId"];
            //    //string bfs_remitterBankId = Request.Form["bfs_remitterBankId"];
            //    //string bfs_orderNo = Request.Form["bfs_orderNo"];
            //    //string bfs_debitAuthCode = Request.Form["bfs_debitAuthCode"];
            //    //string bfs_txnAmount = Request.Form["bfs_txnAmount"];
            //    //string bfs_benfTxnTime = Request.Form["bfs_benfTxnTime"];
            //    //string bfs_msgType = Request.Form["bfs_msgType"];

            //    //BfsModel objBfs = new BfsModel();
            //    //objBfs.BfsBfsTxnId = bfs_bfsTxnId;
            //    //objBfs.BfsDebitAuthNo = bfs_debitAuthNo;
            //    //objBfs.BfsRemitterName = bfs_remitterName;
            //    //objBfs.BfsTxnCurrency = bfs_txnCurrency;
            //    //objBfs.BfsChecksum = bfs_checkSum;
            //    //objBfs.BfsTxnTime = bfs_bfsTxnTime;
            //    //objBfs.BfsBenfId = bfs_benfId;
            //    //objBfs.BfsRemitterBankId = bfs_remitterBankId;
            //    //objBfs.BfsOrderNo = bfs_orderNo;
            //    //objBfs.BfsDebitAuthCode = bfs_debitAuthCode;
            //    //objBfs.BfsTxnAmount = Convert.ToDecimal(bfs_txnAmount);
            //    //objBfs.BfsBenfTxnTime = bfs_benfTxnTime;
            //    //objBfs.BfsMsgType = bfs_msgType;
            //    //objBfs.PaymentDate = DateTime.Now;
            //    //objBfs.BfsStatusState = "bfsFailure";



            //    //_repository2.SavePaymentFailure(objBfs);
            //}
           

            //return View(objBfs);
            return View();
        }
        [Route("Home/PaymentCancel")]
        public IActionResult PaymentCancel()
        {
            string bfs_bfsTxnId = Request.Form["bfs_bfsTxnId"];
            string bfs_debitAuthNo = Request.Form["bfs_debitAuthNo"];
            string bfs_remitterName = Request.Form["bfs_remitterName"];
            string bfs_txnCurrency = Request.Form["bfs_txnCurrency"];
            string bfs_checkSum = Request.Form["bfs_checkSum"];
            string bfs_bfsTxnTime = Request.Form["bfs_bfsTxnTime"];
            string bfs_benfId = Request.Form["bfs_benfId"];
            string bfs_remitterBankId = Request.Form["bfs_remitterBankId"];
            string bfs_orderNo = Request.Form["bfs_orderNo"];
            string bfs_debitAuthCode = Request.Form["bfs_debitAuthCode"];
            string bfs_txnAmount = Request.Form["bfs_txnAmount"];
            string bfs_benfTxnTime = Request.Form["bfs_benfTxnTime"];
            string bfs_msgType = Request.Form["bfs_msgType"];
            BfsModel objBfs = new BfsModel();
            objBfs.BfsBfsTxnId = bfs_bfsTxnId;
            objBfs.BfsDebitAuthNo = bfs_debitAuthNo;
            objBfs.BfsRemitterName = bfs_remitterName;
            objBfs.BfsTxnCurrency = bfs_txnCurrency;
            objBfs.BfsChecksum = bfs_checkSum;
            objBfs.BfsTxnTime = bfs_bfsTxnTime;
            objBfs.BfsBenfId = bfs_benfId;
            objBfs.BfsRemitterBankId = bfs_remitterBankId;
            objBfs.BfsOrderNo = bfs_orderNo;
            objBfs.BfsDebitAuthCode = bfs_debitAuthCode;
            objBfs.BfsTxnAmount =Convert.ToDecimal(bfs_txnAmount);
            objBfs.BfsBenfTxnTime = bfs_benfTxnTime;
            objBfs.BfsMsgType = bfs_msgType;
            objBfs.PaymentDate = DateTime.Now;
            objBfs.BfsStatusState = "cancel";
            _repository2.SavePaymentCancel(objBfs);

            return View(objBfs);
        }

        [Route("Home/FetOnlinePaymentStatus")]
        public IList <OnlinePaymentCheckModel> FetOnlinePaymentStatus(string DemandNoIds)
        {
            IList<OnlinePaymentCheckModel> _dList = null;

            return _dList = _repository2.FetOnlinePaymentStatus(DemandNoIds);
        }

    }
}