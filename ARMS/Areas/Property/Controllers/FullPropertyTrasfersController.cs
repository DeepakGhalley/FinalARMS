using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BOL;
using CORE_DLL;
using CORE_BLL;
using static CORE_BOL.APImodel;
using System.Net.Http;
using Newtonsoft.Json;
//using AutoMapper.Configuration;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Configuration;
using System.Data;
using Newtonsoft.Json.Linq;

using ARMS.Helpers.AppConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Transactions;
using Microsoft.AspNetCore.Routing;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    [Authorize]
    public class FullPropertyTrasfersController : Controller
    {
        private readonly tt_dbContext _context;
        //readonly IFullPropertyTransfer _repository = new FullPropertyTransferBLL();
        readonly IAPIService _APIRepo = new APIServiceBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IFullPropertyTransfer _repository = new FullPropertyTransferBLL();
        private readonly ITokenService tokenService;
        string _CitizenAPIBaseUrl = "";
        string _EsakorAPIBaseUrl = "";
        ILogger _logger;
        IConfiguration _Configure;
        public FullPropertyTrasfersController(tt_dbContext context, ILogger<FullPropertyTrasfersController> logger, IConfiguration configuration, ITokenService tokenService)
        {
            _logger = logger;
            _context = context;
            _Configure = configuration;
            _CitizenAPIBaseUrl = _Configure.GetValue<string>("CitizenAPIBaseUrl");
            _EsakorAPIBaseUrl = _Configure.GetValue<string>("EsakorAPIBaseUrl");
            this.tokenService = tokenService;
        }


        // GET: Property/FullPropertyTrasfers
        [Route("Property/FullPropertyTrasfers")]
        public async Task<IActionResult> Index()
        {
            _ = new List<FullPropertyTransferModel>();
            IList<FullPropertyTransferModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Property/FullPropertyTrasfers/Details/5
        [Route("Property/FullPropertyTrasfers/Details")]

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

        // GET: Property/FullPropertyTrasfers/Create
        [Route("Property/FullPropertyTrasfers/Create")]
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

        // POST: Property/FullPropertyTrasfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/FullPropertyTrasfers/Create")]
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

        // GET: Property/FullPropertyTrasfers/Edit/5
        [Route("Property/FullPropertyTrasfers/Edit")]
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

        // POST: Property/FullPropertyTrasfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/FullPropertyTrasfers/Edit")]
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

        // GET: Property/FullPropertyTrasfers/Delete/5
        [Route("Property/FullPropertyTrasfers/Delete")]
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

        // POST: Property/FullPropertyTrasfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Property/FullPropertyTrasfers/Delete")]
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

        //[Route("Property/FullPropertyTrasfers/GetTransactionDetailFromAPIByTransactionId")]
        //public async Task<List<LandTransactionDetail>> GetTransactionDetailFromAPIByTransactionId(string TransactionID)
        //{
        //    List<LandTransactionDetail> LandTransactionList = new List<LandTransactionDetail>();
        //    List<LandTransactionDetail> TransferrorList = new List<LandTransactionDetail>();
        //    try
        //    {
        //        TransactionID = "14170920";
        //        using (var httpClient = new HttpClient())
        //        {
        //            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "812c2d79-36f4-3610-937c-6363d8e18b2d".ToString());
        //            using (var response = await httpClient.GetAsync(_EsakorAPIBaseUrl + "/transactiondetails/" + TransactionID))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                // reservationList = JsonConvert.DeserializeObject<CitizenDetailr>(apiResponse);
        //                //CitizenDetailsResponse datalist = JsonConvert.DeserializeObject<CitizenDetailsResponse>(apiResponse);
        //                //var datalist1 = JsonConvert.DeserializeObject<List<CitizenDetailsResponse>>(apiResponse);
        //                // Root citizenDetailsResponse = JsonConvert.DeserializeObject(apiResponse);

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var json = response.Content.ReadAsStringAsync().Result;
        //                    dynamic json_result = JsonConvert.DeserializeObject(json);
        //                    if (json_result = true)
        //                    {
        //                        if (JObject.Parse(json)["transactions"].ToString() == "{}")
        //                        {
        //                            return LandTransactionList.ToList();
        //                            //citizenList.Add(new CitizenDetail
        //                            //{
        //                            //    apistatus = "NoData"
        //                            //}) ;
        //                        }
        //                        else
        //                        {
        //                            DataSet ds = JObject.Parse(json)["transactions"].ToObject<DataSet>();


        //                            DataView dvData = new DataView(ds.Tables[0]);
        //                            dvData.RowFilter = "party = " + "'Transferor'";
        //                            DataTable dt = dvData.ToTable();
        //                            foreach (DataRow dr in ds.Tables[0].Rows)
        //                            {
        //                                LandTransactionList.Add(new LandTransactionDetail
        //                                {
        //                                    thromde = Convert.ToString(dr["thromde"]),
        //                                    thromdeVillage = Convert.ToString(dr["thromdeVillage"]),
        //                                    transactionType = Convert.ToString(dr["transactionType"]),
        //                                    party = Convert.ToString(dr["party"]),
        //                                    thram = Convert.ToString(dr["thram"]),
        //                                    ownershipType = Convert.ToString(dr["ownershipType"]),
        //                                    ownerCID = Convert.ToString(dr["ownerCID"]),
        //                                    ownerName = Convert.ToString(dr["ownerName"]),
        //                                    plotID = Convert.ToString(dr["plotID"]),
        //                                    plotArea = Convert.ToString(dr["plotArea"]),
        //                                    transactionArea = Convert.ToString(dr["transactionArea"]),
        //                                    landValue = Convert.ToString(dr["landValue"]),
        //                                    buildingValue = Convert.ToString(dr["buildingValue"]),
        //                                    subdivisionFee = Convert.ToString(dr["subdivisionFee"]),
        //                                    demarcationFee = Convert.ToString(dr["demarcationFee"]),
        //                                    lagthramFee = Convert.ToString(dr["lagthramFee"]),
        //                                    totalPayable = Convert.ToString(dr["totalPayable"]),
        //                                });
        //                            }
        //                            //TRANSFERROR
        //                            foreach (DataRow dr1 in dt.Rows)
        //                            {
        //                                TransferrorList.Add(new LandTransactionDetail
        //                                {
        //                                    thromde = Convert.ToString(dr1["thromde"]),
        //                                    thromdeVillage = Convert.ToString(dr1["thromdeVillage"]),
        //                                    transactionType = Convert.ToString(dr1["transactionType"]),
        //                                    party = Convert.ToString(dr1["party"]),
        //                                    thram = Convert.ToString(dr1["thram"]),
        //                                    ownershipType = Convert.ToString(dr1["ownershipType"]),
        //                                    ownerCID = Convert.ToString(dr1["ownerCID"]),
        //                                    ownerName = Convert.ToString(dr1["ownerName"]),
        //                                    plotID = Convert.ToString(dr1["plotID"]),
        //                                    plotArea = Convert.ToString(dr1["plotArea"]),
        //                                    transactionArea = Convert.ToString(dr1["transactionArea"]),
        //                                    landValue = Convert.ToString(dr1["landValue"]),
        //                                    buildingValue = Convert.ToString(dr1["buildingValue"]),
        //                                    subdivisionFee = Convert.ToString(dr1["subdivisionFee"]),
        //                                    demarcationFee = Convert.ToString(dr1["demarcationFee"]),
        //                                    lagthramFee = Convert.ToString(dr1["lagthramFee"]),
        //                                    totalPayable = Convert.ToString(dr1["totalPayable"]),
        //                                });
        //                            }

        //                        }
        //                    }
        //                }
        //            }                    
        //        }
        //    }                
        //    catch (Exception EX)
        //    {
        //        return LandTransactionList.ToList();
        //    }
        //    return LandTransactionList.ToList();
        //}
       
        [Route("Property/FullPropertyTrasfers/getLap")]
        public List<CommonFunctionModel> SelectListLap()
        {
            return _CommonRepo.SelectListLap().ToList();
        }
        [HttpPost]
        [Route("Property/FullPropertyTrasfers/CreateDemand")]
        public JsonResult CreateDemand([FromBody] List<DemandVM> json_data)
        {           
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<DemandVM>();
            }
            //GENERATE TRN ID

            //GENERATE TRN ID END

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
                //obj.LandDetailId = item.LandDetailId;
                //obj.TaxPayerId = item.TaxPayerId;
                obj.PlotNo = item.PlotNo;
                //obj.Cid = item.Cid;    obj.l = item.Cid;
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
            //}
        }

        [HttpGet]
        [Route("Property/PartialPropertyTrasfers/GetTransferorProperty")]
        public List<LandDetailModel> GetTransferorProperty(string PlotNo, string Cid) 
        {
            List<LandDetailModel> _dList = null; 
            return _dList = _repository.GetLandDetailsByPlotNo(PlotNo, Cid) ;
        }

        [Route("Property/FullPropertyTrasfers/GetTransactionDetailFromAPIByTransactionId")]
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
                                }
                                else
                                {
                                    DataSet ds = JObject.Parse(json)["transactions"].ToObject<DataSet>();
                                    DataView dvData = new DataView(ds.Tables[0]);
                                    dvData.RowFilter = "party = " + "'Transferor'";
                                    DataTable dt = dvData.ToTable();
                                    foreach (DataRow dr in dt.Rows)
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


                                            // TaxPayerId = (_context.MstTaxPayerProfile.Where(p=>p.TaxPayerTypeId==1 && p.Cid== Convert.ToString(dr["ownerCID"])).Count()> 0 ? _context.MstTaxPayerProfile.Where(p => p.TaxPayerTypeId == 1 && p.Cid == Convert.ToString(dr["ownerCID"])).First().TaxPayerId : 0)
                                            LandOwnershipId = ((from x in _context.MstTaxPayerProfile.Where(p => p.TaxPayerId == 1 && p.Cid == Convert.ToString(dr["ownerCID"])) join b in _context.TblLandOwnershipDetail on x.TaxPayerId equals b.TaxPayerId join c in _context.MstLandDetail on b.LandDetailId equals c.LandDetailId where b.IsActive==true && c.PlotNo== Convert.ToString(dr["plotID"]) select new { LandOwnershipId = b.LandOwnershipId }).Count() > 0 ? (from x in _context.MstTaxPayerProfile.Where(p => p.TaxPayerId == 1 && p.Cid == Convert.ToString(dr["ownerCID"])) join b in _context.TblLandOwnershipDetail on x.TaxPayerId equals b.TaxPayerId join c in _context.MstLandDetail on b.LandDetailId equals c.LandDetailId where b.IsActive == true && c.PlotNo == Convert.ToString(dr["plotID"]) select new { LandOwnershipId = b.LandOwnershipId }).FirstOrDefault().LandOwnershipId : 0)//**

                                        }); ;
                                        //using (TransactionScope s = new TransactionScope())
                                        //{

                                        //    for (int i = 0; i <= dt.Rows.Count-1; i++)
                                        //    {
                                        //        var ttin = "";
                                        //        int ttid = (_context.MstTaxPayerProfile.Max(x => x.TaxPayerId));
                                        //        if (ttid == 0)
                                        //        {
                                        //            ttin = "000001";

                                        //        }
                                        //        else if (ttid >= 1 && ttid <= 9)
                                        //        {
                                        //            ttin = "00000" + (ttid + 1).ToString();

                                        //        }
                                        //        else if (ttid > 9 && ttid <= 99)
                                        //        {
                                        //            ttin = "0000" + (ttid + 1).ToString();

                                        //        }
                                        //        else if (ttid > 99 && ttid <= 999)
                                        //        {
                                        //            ttin = "000" + (ttid + 1).ToString();

                                        //        }
                                        //        else if (ttid > 999 && ttid <= 9999)
                                        //        {
                                        //            ttin = "00" + (ttid + 1).ToString();
                                        //        }
                                        //        else if (ttid > 9999 && ttid <= 99999)
                                        //        {
                                        //            ttin = "0" + (ttid + 1).ToString();
                                        //        }
                                        //        else
                                        //        {
                                        //            ttin = ttid.ToString();
                                        //        }
                                        //        var entity = new MstTaxPayerProfile
                                        //        {
                                        //            TaxPayerTypeId = 1,//ask
                                        //            Ttin = ttin,
                                        //            Cid = dt.Rows[i]["ownerCID"].ToString(),
                                        //            TitleId = 13,
                                        //            FirstName= dt.Rows[i]["ownerName"].ToString(),
                                        //            Dob=Convert.ToDateTime("1900-01-01"),//ask
                                        //            GenderId=1,//ask
                                        //            PVillageId=45,//ask
                                        //            OccupationId=9,//ask



                                        //            IsActive = true,
                                        //            CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                                        //            CreatedOn = DateTime.Now,
                                        //        };
                                        //        _context.MstTaxPayerProfile.Add(entity);
                                        //        _context.SaveChanges();

                                        //    }

                                           
                                        //    s.Complete();
                                        //    s.Dispose();
                                        //}
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

        [Route("Property/FullPropertyTrasfers/GetTransactionDetailToAPIByTransactionId")]
        public async Task<List<LandPostTransactionDetail>> GetTransactionDetailToAPIByTransactionId(string transactionId)
        {
            // GENERATE TOKEN START
            var token1 = await tokenService.GetToken();
            // GENERATE TOKEN END 
            //DATA PULL START
            List<LandPostTransactionDetail> LandTransactionList = new List<LandPostTransactionDetail>();
            //List<LandTransactionDetail> TransferrorList = new List<LandTransactionDetail>();
            try
            {
                //TransactionID = "14170920";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "812c2d79-36f4-3610-937c-6363d8e18b2d".ToString());
                    using (var response = await httpClient.GetAsync(_EsakorAPIBaseUrl + "/postapprovaltransaction/" + transactionId))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                       if (response.IsSuccessStatusCode)
                        {
                            var json = response.Content.ReadAsStringAsync().Result;
                            dynamic json_result = JsonConvert.DeserializeObject(json);
                            if (json_result = true)
                            {
                                if (JObject.Parse(json)["postapprovals"].ToString() == "{}")
                                {
                                    return LandTransactionList.ToList();
                                }
                                else
                                {
                                    DataSet ds = JObject.Parse(json)["postapprovals"].ToObject<DataSet>();
                                    DataView dvData = new DataView(ds.Tables[0]);
                                    dvData.RowFilter = "party = " + "'Transferee'";
                                    DataTable dt = dvData.ToTable();
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        LandTransactionList.Add(new LandPostTransactionDetail
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

        // [HttpPost]
        [Route("Property/FullPropertyTrasfers/RedirectToTaxPayer")]
        public ActionResult RedirectToTaxPayer()
        {
            return RedirectToAction("Index", "TaxPayerProfiles", new { area = "TaxPayer" });
           // return RedirectToAction("Index", "TaxPayer/TaxPayerProfiles");
            //  var routeValue = new RouteValueDictionary(new { controller = "TaxPayerProfiles", Areas = "TaxPayer" });

            //return RedirectToRoute(routeValue);
            //return new RedirectResult(url: "TaxPayer/TaxPayerProfiles", permanent: true,
            //                preserveMethod: true);
        }







    }
}
