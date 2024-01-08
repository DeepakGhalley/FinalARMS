using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using AutoMapper;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CORE_DLL;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CORE_BOL;

namespace ARMS.Areas.Water.Controllers
{
    [Area("Water")]
    public class DashboardsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        private readonly IG2CTokenService tokenService;

        string _G2CAPIBaseUrl = "";
        ILogger _logger;
        IConfiguration _Configure;
        readonly ItrnWaterConnection _repository = new trnWaterConnectionBLL();
        readonly ITranWaterConnection _repo = new TranWaterConnectionBLL();
        public DashboardsController(tt_dbContext context, IMapper mapper, ILogger<DashboardsController> logger, IConfiguration configuration, IG2CTokenService tokenService)
        {
            _context = context; _mapper = mapper;
            _logger = logger;
        
            _Configure = configuration;
            _G2CAPIBaseUrl = _Configure.GetValue<string>("G2CAPIBaseUrl");

            this.tokenService = tokenService;
        }
    
        [Route("Water/Dashboards")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Water/Dashboards/ReviewNewWaterConnection")]
        public IActionResult ReviewNewWaterConnection()
        {
                _ = new List<TrnWaterConnectionVM>();
                IList<TrnWaterConnectionVM> obj = _repository.GetAll();

                return View(obj);
            }
        [Route("Water/Dashboards/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<TrnWaterConnectionVM>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }
        [Route("Water/Dashboards/G2Services")]
        public async Task<IActionResult> G2Services()
        {
            //ViewData["TransactionType"] = _CommonRepo.SelectListTransactionTypeForG2CServices();
            return View();
        }

        [Route("Water/Dashboards/G2CApplicantDetail")]
        [HttpGet]
        public async Task<IActionResult> G2CApplicantDetail(string applicationNo)//G2CApplicantModel obj
        {
            try
            {

                G2CApplicantModel ApplicantList = new G2CApplicantModel();

                //G2CAPIToken token = await tokenService.GetG2CToken();
                string g2c_token;
                g2c_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJTdWJqZWN0IEhlcmUiLCJqdGkiOiJqdGkiLCJpYXQiOjE2MTY5NTYzNTEsImlkIjoiMSIsImFjY2Vzc19yb2xlIjoiQWRtaW4iLCJleHAiOjE2MTY5NjM1NTEsImlzcyI6ImV4YW1wbGUuY29tIiwiYXVkIjoiZXhhbXBsZS5jb20ifQ.0zRP0Bs31JnyEOMTLJwi5ay6wkn50ByxlmVV52FXgQ8";
                HttpResponseMessage res;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", g2c_token);
                res = await client.GetAsync(_G2CAPIBaseUrl + "GeNewWaterConnectionByApplicationNo?_id=" + applicationNo);
                // res = await client.GetAsync("http://103.80.110.239:3306/api/G2CService/GeNewWaterConnectionByApplicationNo?_id=WS%2F501%2F2019%2F1%2FChang%20Gumji%2F001");
                if (res.IsSuccessStatusCode)
                {
                    string apiResponse = await res.Content.ReadAsStringAsync();
                    try
                    {
                        ApplicantList = JsonConvert.DeserializeObject<G2CApplicantModel>(apiResponse);
                        ViewBag.ApplicantList = ApplicantList;
                    }
                    catch (Exception ex) { }
                }
                else if (res.StatusCode.ToString() == "500")
                {
                    return View();
                    //server not found
                }
                else if (res.StatusCode.ToString() == "404")
                {
                    return View();

                    //authenticationfailed
                }


                //else
                //{
                //    return View(obj);
                //}



                //var s1List = await _repo.getSection1IDByApaID(obj.Apa_id);
                //if (s1List.Count > 0)
                //{
                //    obj.PreambleSection1Id = s1List.FirstOrDefault().PreambleSection1Id;
                //    obj.Mission = s1List.FirstOrDefault().Mission;
                //    obj.Vision = s1List.FirstOrDefault().Vision;
                //    //obj.objective= s1List.FirstOrDefault().ApaObjective;
                //}
                return View();
            }
            catch (Exception ex) {
                return View();
            }
        }

        [Route("Water/Dashboards/DisconnectRequests")]
        public async Task<IActionResult> DisconnectRequests()
        {
            _ = new List<TranWaterConnectionModel>();
            IList<TranWaterConnectionModel> obj = _repo.GetDisconnectRequests();
            return View(obj);

        }

        [Route("Water/Dashboards/DisconnectRequestDetails")]
        public async Task<IActionResult> DisconnectRequestDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repo.DisconnectRequestsDetails(id);

            var objs = _mapper.Map<TranWaterConnectionModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        // UPDATE APPROVE DISCONNECTION REQUEST
        [HttpPost]
        [Route("Water/Dashboards/ApproveDisconnectionRequest")]
        public JsonResult ApproveDisconnectionRequest([FromBody] List<TranWaterConnectionModel> json_data)
        {

            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            TranWaterConnectionModel obj = new TranWaterConnectionModel();


            if (ModelState.IsValid)
            {
                try
                {
                    foreach (TranWaterConnectionModel item in json_data)
                    {
                        if (item.IsPermanentDisconnect == true)
                        {
                            obj.IsPermanentDisconnection = true;
                        } else
                        {
                            obj.IsPermanentDisconnection = false;
                        }

                        obj.TrnWaterConnectionId = item.TrnWaterConnectionId;
                        obj.WaterConnectionId = item.WaterConnectionId;
                        obj.ApprovalStatusId = true;
                        int returnvalue = _repo.ApproveDisconnectionRequest(obj);

                        if (returnvalue > 0)
                        {
                            TempData["msg"] = "Record updated successfully";

                        }
                        else
                        {
                            TempData["msg"] = "Error while updating";
                            // return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!TblEcdetailExists(obj.EcDetailId))
                    //{
                    //    return null;
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
            return Json(TempData["msg"]);

        }

        // UPDATE REJECT DISCONNECTION REQUEST
        [HttpPost]
        [Route("Water/Dashboards/RejectDisconnectionRequest")]
        public JsonResult RejectDisconnectionRequest([FromBody] List<TranWaterConnectionModel> json_data)
        {

            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            TranWaterConnectionModel obj = new TranWaterConnectionModel();


            if (ModelState.IsValid)
            {
                try
                {
                    foreach (TranWaterConnectionModel item in json_data)
                    {
                        obj.TrnWaterConnectionId = item.TrnWaterConnectionId;
                        obj.ApprovalStatusId = false;
                        //obj.WaterConnectionId = item.WaterConnectionId;
                        //obj.IsPermanentDisconnect = false;

                        int returnvalue = _repo.RejectDisconnectionRequest(obj);

                        if (returnvalue > 0)
                        {
                            TempData["msg"] = "Record updated successfully";

                        }
                        else
                        {
                            TempData["msg"] = "Error while updating";
                            // return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!TblEcdetailExists(obj.EcDetailId))
                    //{
                    //    return null;
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
            return Json(TempData["msg"]);

        }

        //Water Reconnection Dashboard
        [Route("Water/Dashboards/ReconnectionRequests")]
        public async Task<IActionResult> ReconnectionRequests(bool id)
        {
            _ = new List<TranWaterConnectionModel>();
            IList<TranWaterConnectionModel> obj = _repo.GetReconnectionRequests(id);
            return View(obj);

        }

        [Route("Water/Dashboards/GetReconnectionDetail")]
        public List<TranWaterConnectionModel> GetReconnectionDetail(int? id)
        {
            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repo.GetReconnectionDetail(id);
        }

        // UPDATE APPROVE RECONNECTION REQUEST
        [HttpPost]
        [Route("Water/Dashboards/ApproveReconnectionRequest")]
        public JsonResult ApproveReconnectionRequest([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }

            TranWaterConnectionModel obj = new TranWaterConnectionModel();
            foreach (TranWaterConnectionModel item in json_data)
            {
                obj.TrnWaterConnectionId = item.TrnWaterConnectionId;
                obj.WorkLevelId = 2;
                obj.ApprovalStatusId = true;
               
                _repo.ApproveReconnectionRequest(obj);
            }
            try
            {
                int returnvalue = 1; // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Record Approved Successfully!";

                }
                else
                {
                    TempData["msg"] = "Approved failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);

        }

        // UPDATE REJECT RECONNECTION REQUEST
        [HttpPost]
        [Route("Water/Dashboards/RejectReconnectionRequest")]
        public JsonResult RejectReconnectionRequest([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }

            TranWaterConnectionModel obj = new TranWaterConnectionModel();
            foreach (TranWaterConnectionModel item in json_data)
            {
                obj.TrnWaterConnectionId = item.TrnWaterConnectionId;
                obj.WorkLevelId = 2;
                obj.ApprovalStatusId = false;

                _repo.RejectReconnectionRequest(obj);
            }
            try
            {
                int returnvalue = 1; // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Record Rejected Successfully!";

                }
                else
                {
                    TempData["msg"] = "Rejected failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);

        }

        //SAVE REMARKS
        [HttpPost]
        [Route("Water/Dashboards/UpdateRejectedRemarks")]
        public JsonResult UpdateRejectedRemarks([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }

            TranWaterConnectionModel obj = new TranWaterConnectionModel();
            foreach (TranWaterConnectionModel item in json_data)
            {
                obj.TrnWaterConnectionId = item.TrnWaterConnectionId;
                obj.Remarks = item.Remarks;
                _repo.UpdateRejectedRemarks(obj);
            }
            try
            {
                int returnvalue = 1; // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Record Saved Successfully!";

                }
                else
                {
                    TempData["msg"] = "Saving failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);

        }

        //WATER RECEIPT
        [Route("Water/Dashboards/WaterDemandReceipt")]
        public List<LedgerDemandVM> WaterDemandReceipt(long TransactionId)
        {
            return _repo.WaterDemandReceipt(TransactionId).ToList();
        }


    }
}
