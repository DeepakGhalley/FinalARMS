using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using static CORE_BOL.PartialAPImodel;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Configuration;
using System.Data;
using Newtonsoft.Json.Linq;

using ARMS.Helpers.AppConfig;
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class PartialPropertyTrasfersController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IPartialTransfer _repository = new PartialTransferBLL();
        private readonly ITokenService tokenService;
        string _CitizenAPIBaseUrl = "";
        string _EsakorAPIBaseUrl = "";
        ILogger _logger;
        IConfiguration _Configure;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        public PartialPropertyTrasfersController(tt_dbContext context, ILogger<PartialPropertyTrasfersController> logger, IConfiguration configuration, ITokenService tokenService)
        {
            _logger = logger;
            _context = context;
            _Configure = configuration;
            _CitizenAPIBaseUrl = _Configure.GetValue<string>("CitizenAPIBaseUrl");
            _EsakorAPIBaseUrl = _Configure.GetValue<string>("EsakorAPIBaseUrl");
            this.tokenService = tokenService;
        }

        // GET: Property/PartialPropertyTrasfers
        [Route("Property/PartialPropertyTrasfers")]
        public async Task<IActionResult> Index()
        {
            _ = new List<PartialTransferModel>();
            IList<PartialTransferModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Property/PartialPropertyTrasfers/Details/5
        [Route("Property/PartialPropertyTrasfers/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trnLandDetail = await _context.TrnLandDetail
                .Include(t => t.Demkhong)
                .Include(t => t.LandTransferType)
                .Include(t => t.LandType)
                .Include(t => t.LandUseSubCategory)
                .Include(t => t.Lap)
                .Include(t => t.StreetName)
                .Include(t => t.TransactorType)
                .FirstOrDefaultAsync(m => m.TrnFtlandDetailId == id);
            if (trnLandDetail == null)
            {
                return NotFound();
            }

            return View(trnLandDetail);
        }

        // GET: Property/PartialPropertyTrasfers/Create
        [Route("Property/PartialPropertyTrasfers/Create")]
        public IActionResult Create()
        {
            ViewData["DemkhongId"] = new SelectList(_context.MstDemkhong, "DemkhongId", "DemkhongName");
            ViewData["LandTransferTypeId"] = new SelectList(_context.EnumLandTransferType, "LandTransferTypeId", "LandTransferType");
            ViewData["LandTypeId"] = new SelectList(_context.MstLandType, "LandTypeId", "LandTypeName");
            ViewData["LandUseSubCategoryId"] = new SelectList(_context.MstLandUseSubCategory, "LandUseSubCategoryId", "LandUseSubCategory");
            ViewData["LapId"] = new SelectList(_context.MstLap, "LapId", "LapDescription");
            ViewData["StreetNameId"] = new SelectList(_context.MstStreetName, "StreetNameId", "StreetName");
            ViewData["TransactorTypeId"] = new SelectList(_context.EnumTransactorType, "TransactorTypeId", "TransactorType");
            return View();
        }

        // POST: Property/PartialPropertyTrasfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/PartialPropertyTrasfers/Create")]
        public async Task<IActionResult> Create([Bind("TrnFtlandDetailId,TransactorTypeId,LandTransferTypeId,LapId,DemkhongId,StreetNameId,LandTypeId,LandUseSubCategoryId,PlotNo,LandAcerage,LandValue,LandPoolingRate,StructureAvailable,PlotAddress,Location,IsApproved,CreatedBy,CreationOn,ModifiedBy,ModifiedOn,VacantLandTaxApplicable,GarbageApplicable,StreetLightApplicable,ESakorTransactionId")] TrnLandDetail trnLandDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trnLandDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DemkhongId"] = new SelectList(_context.MstDemkhong, "DemkhongId", "DemkhongName", trnLandDetail.DemkhongId);
            ViewData["LandTransferTypeId"] = new SelectList(_context.EnumLandTransferType, "LandTransferTypeId", "LandTransferType", trnLandDetail.LandTransferTypeId);
            ViewData["LandTypeId"] = new SelectList(_context.MstLandType, "LandTypeId", "LandTypeName", trnLandDetail.LandTypeId);
            ViewData["LandUseSubCategoryId"] = new SelectList(_context.MstLandUseSubCategory, "LandUseSubCategoryId", "LandUseSubCategory", trnLandDetail.LandUseSubCategoryId);
            ViewData["LapId"] = new SelectList(_context.MstLap, "LapId", "LapDescription", trnLandDetail.LapId);
            ViewData["StreetNameId"] = new SelectList(_context.MstStreetName, "StreetNameId", "StreetName", trnLandDetail.StreetNameId);
            ViewData["TransactorTypeId"] = new SelectList(_context.EnumTransactorType, "TransactorTypeId", "TransactorType", trnLandDetail.TransactorTypeId);
            return View(trnLandDetail);
        }

        // GET: Property/PartialPropertyTrasfers/Edit/5
        [Route("Property/PartialPropertyTrasfers/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trnLandDetail = await _context.TrnLandDetail.FindAsync(id);
            if (trnLandDetail == null)
            {
                return NotFound();
            }
            ViewData["DemkhongId"] = new SelectList(_context.MstDemkhong, "DemkhongId", "DemkhongName", trnLandDetail.DemkhongId);
            ViewData["LandTransferTypeId"] = new SelectList(_context.EnumLandTransferType, "LandTransferTypeId", "LandTransferType", trnLandDetail.LandTransferTypeId);
            ViewData["LandTypeId"] = new SelectList(_context.MstLandType, "LandTypeId", "LandTypeName", trnLandDetail.LandTypeId);
            ViewData["LandUseSubCategoryId"] = new SelectList(_context.MstLandUseSubCategory, "LandUseSubCategoryId", "LandUseSubCategory", trnLandDetail.LandUseSubCategoryId);
            ViewData["LapId"] = new SelectList(_context.MstLap, "LapId", "LapDescription", trnLandDetail.LapId);
            ViewData["StreetNameId"] = new SelectList(_context.MstStreetName, "StreetNameId", "StreetName", trnLandDetail.StreetNameId);
            ViewData["TransactorTypeId"] = new SelectList(_context.EnumTransactorType, "TransactorTypeId", "TransactorType", trnLandDetail.TransactorTypeId);
            return View(trnLandDetail);
        }

        // POST: Property/PartialPropertyTrasfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/PartialPropertyTrasfers/Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("TrnFtlandDetailId,TransactorTypeId,LandTransferTypeId,LapId,DemkhongId,StreetNameId,LandTypeId,LandUseSubCategoryId,PlotNo,LandAcerage,LandValue,LandPoolingRate,StructureAvailable,PlotAddress,Location,IsApproved,CreatedBy,CreationOn,ModifiedBy,ModifiedOn,VacantLandTaxApplicable,GarbageApplicable,StreetLightApplicable,ESakorTransactionId")] TrnLandDetail trnLandDetail)
        {
            if (id != trnLandDetail.TrnFtlandDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trnLandDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrnLandDetailExists(trnLandDetail.TrnFtlandDetailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DemkhongId"] = new SelectList(_context.MstDemkhong, "DemkhongId", "DemkhongName", trnLandDetail.DemkhongId);
            ViewData["LandTransferTypeId"] = new SelectList(_context.EnumLandTransferType, "LandTransferTypeId", "LandTransferType", trnLandDetail.LandTransferTypeId);
            ViewData["LandTypeId"] = new SelectList(_context.MstLandType, "LandTypeId", "LandTypeName", trnLandDetail.LandTypeId);
            ViewData["LandUseSubCategoryId"] = new SelectList(_context.MstLandUseSubCategory, "LandUseSubCategoryId", "LandUseSubCategory", trnLandDetail.LandUseSubCategoryId);
            ViewData["LapId"] = new SelectList(_context.MstLap, "LapId", "LapDescription", trnLandDetail.LapId);
            ViewData["StreetNameId"] = new SelectList(_context.MstStreetName, "StreetNameId", "StreetName", trnLandDetail.StreetNameId);
            ViewData["TransactorTypeId"] = new SelectList(_context.EnumTransactorType, "TransactorTypeId", "TransactorType", trnLandDetail.TransactorTypeId);
            return View(trnLandDetail);
        }

        // GET: Property/PartialPropertyTrasfers/Delete/5
        [Route("Property/PartialPropertyTrasfers/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trnLandDetail = await _context.TrnLandDetail
                .Include(t => t.Demkhong)
                .Include(t => t.LandTransferType)
                .Include(t => t.LandType)
                .Include(t => t.LandUseSubCategory)
                .Include(t => t.Lap)
                .Include(t => t.StreetName)
                .Include(t => t.TransactorType)
                .FirstOrDefaultAsync(m => m.TrnFtlandDetailId == id);
            if (trnLandDetail == null)
            {
                return NotFound();
            }

            return View(trnLandDetail);
        }

        // POST: Property/PartialPropertyTrasfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Property/PartialPropertyTrasfers/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trnLandDetail = await _context.TrnLandDetail.FindAsync(id);
            _context.TrnLandDetail.Remove(trnLandDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrnLandDetailExists(int id)
        {
            return _context.TrnLandDetail.Any(e => e.TrnFtlandDetailId == id);
        }

        //GET PartialProperty Details Using API
        [Route("Property/PartialPropertyTrasfers/GetTransactionDetailFromAPIByTransactionId")]
        public async Task<List<LandTransactionDetail>> GetTransactionDetailFromAPIByTransactionId(string transactionId)
        {
            // GENERATE TOKEN START
            var token1 = await tokenService.GetToken();
            // GENERATE TOKEN END 
            //DATA PULL START
            List<LandTransactionDetail> LandTransactionList = new List<LandTransactionDetail>();
            //List<LandTransactionDetail> TransferrorList = new List<LandTransactionDetail>();
                        try
            {
                //TransactionID = "14170920";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "812c2d79-36f4-3610-937c-6363d8e18b2d".ToString());
                    using (var response = await httpClient.GetAsync(_EsakorAPIBaseUrl + "/transactiondetails/" + transactionId))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        // reservationList = JsonConvert.DeserializeObject<CitizenDetailr>(apiResponse);
                        //CitizenDetailsResponse datalist = JsonConvert.DeserializeObject<CitizenDetailsResponse>(apiResponse);
                        //var datalist1 = JsonConvert.DeserializeObject<List<CitizenDetailsResponse>>(apiResponse);
                        // Root citizenDetailsResponse = JsonConvert.DeserializeObject(apiResponse);

                        if (response.IsSuccessStatusCode)
                        {
                            var json = response.Content.ReadAsStringAsync().Result;
                            dynamic json_result = JsonConvert.DeserializeObject(json);
                            if (json_result = true)
                            {
                                if (JObject.Parse(json)["transactions"].ToString() == "{}")
                                {
                                    return LandTransactionList.ToList();
                                    //citizenList.Add(new CitizenDetail
                                    //{
                                    //    apistatus = "NoData"
                                    //}) ;
                                }
                                else
                                {
                                    DataSet ds = JObject.Parse(json)["transactions"].ToObject<DataSet>();


                                    DataView dvData = new DataView(ds.Tables[0]);
                                    dvData.RowFilter = "party = " + "'Transferor'";
                                    DataTable dt = dvData.ToTable();
                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        LandTransactionList.Add(new LandTransactionDetail
                                        {
                                            thromde = Convert.ToString(dr["thromde"]),
                                            thromdeVillage = Convert.ToString(dr["thromdeVillage"]),
                                            transactionType = Convert.ToString(dr["transactionType"]),
                                            party = Convert.ToString(dr["party"]),
                                            thram = Convert.ToString(dr["thram"]),
                                            ownershipType = Convert.ToString(dr["ownershipType"]),
                                            ownerCID = Convert.ToString(dr["ownerCID"]),
                                            ownerName = Convert.ToString(dr["ownerName"]),
                                            plotID = Convert.ToString(dr["plotID"]),
                                            plotArea = Convert.ToString(dr["plotArea"]),
                                            transactionArea = Convert.ToString(dr["transactionArea"]),
                                            landValue = Convert.ToString(dr["landValue"]),
                                            buildingValue = Convert.ToString(dr["buildingValue"]),
                                            subdivisionFee = Convert.ToString(dr["subdivisionFee"]),
                                            demarcationFee = Convert.ToString(dr["demarcationFee"]),
                                            lagthramFee = Convert.ToString(dr["lagthramFee"]),
                                            totalPayable = Convert.ToString(dr["totalPayable"]),
                                        });
                                    }
                                }
                            }
                        }
                        if (Convert.ToInt32(response.StatusCode) == 400)
                        {
                            return LandTransactionList.ToList();
                        }
                    }

                }
            }
            catch (Exception EX)
            {
                return LandTransactionList.ToList();
            }
            return LandTransactionList.ToList();
        }

        [Route("Property/PartialPropertyTrasfers/getLap")]
        public List<CommonFunctionModel> SelectListLap()
        {
            return _CommonRepo.SelectListLap().ToList();
        }

        [HttpPost]
        [Route("Property/PartialPropertyTrasfers/CreateDemand")]
        public JsonResult CreateDemand([FromBody] List<DemandVM> json_data)
        {
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<DemandVM>();
            }

            long returnvalue = 0;
            DemandVM obj = new DemandVM();
            //Loop and insert records. 
            foreach (DemandVM item in json_data)
            {
                obj.TransactionId = item.TransactionId;
                obj.DemandNoId = item.DemandNoId;
                obj.TaxId = item.TaxId;
                obj.FinancialYearId = item.FinancialYearId;
                obj.CalendarYearId = item.CalendarYearId;
                obj.DemandAmount = item.DemandAmount;
                obj.TotalAmount = item.TotalAmount;
                obj.PlotNo = item.PlotNo;
                obj.Cid = item.Cid;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SaveDemand(obj);
            }
            try
            {

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Data Saved Successfully.!";

                }
                else
                {
                    TempData["msg"] = "Data saving failed.!";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);
        }

        [Route("Property/PartialPropertyTrasfers/GetBuildingDetails")]
        public List<BuildingDetailVM> GetBuildingDetails(int? id)
        {
            List<BuildingDetailVM> _dList = null;

            return _dList = _repository.GetBuildingDetails(id);

        }

        [Route("Property/PartialPropertyTrasfers/GetBuildingUnitDetails")]
        public List<BuildingUnitDetailsVM> GetBuildingUnitDetails(int id)
        {
            List<BuildingUnitDetailsVM> _dList = null;

            return _dList = _repository.GetBuildingUnitDetails(id);

        }
    }
}
