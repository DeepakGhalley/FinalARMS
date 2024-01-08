using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CORE_BLL;
using CORE_DLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
//using ARMS.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CORE_BOL.Entities;
using AutoMapper;

namespace ARMS.Areas.TaxMaster.Controllers
{
    [Area("TaxMaster")]
    public class TransactionTypesController : Controller
    {
        ////private readonly IConfiguration _configuration;
        private readonly tt_dbContext _context;
        //// private readonly APIServiceBLL _apiService;
        //string apiBaseUrl = "";
        //ILogger _logger ;
        //IConfiguration _Configure;
        //readonly ITransactionType _repository = new TransactionTypeBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        //public TransactionTypesController(tt_dbContext context, ILogger<TransactionTypesController> logger, IConfiguration configuration, IAPIService apiService)
        //{
        //    _context = context;
        //    _logger = logger;
        //    _Configure = configuration;
        //  //  _apiService = apiService;
        //    apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        //}
        readonly ITransactionType _repository = new TransactionTypeBLL();

        public TransactionTypesController(tt_dbContext context, IConfiguration iconfig)
        {
            _context = context; 
            //this.apiService = apiService; apiBaseUrl = iconfig.GetValue<string>("DataHubSettings");
        }
        //private readonly tt_dbContext _context;
        //private readonly IMapper _mapper;
        //ICommonFunction _CommonRepo = new CommonFunctionBLL();
        //readonly ITransactionType _repository TransactionTypeBLL();
        //public TransactionTypesController(tt_dbContext context) 
        //{
        //    _context = context;
        //}

        // GET: TaxMaster/TransactionTypes
        [Route("TaxMaster/TransactionTypes")]
        public async Task<IActionResult> Index()
        {
            //var citizenlst = await apiService.GetCitizenByCID("113030030967");// if 0 api is down or data not found
            //var LandPrePostList = await _apiService.GetPreTransactionByTransactionID("14170920");// if 0 api is down or data not found
            //var LandList = await _apiService.GetPostTransactionByTransactionID("14170920");// if 0 api is down or data not found

            //List<CitizenDetail> reservationList = new List<CitizenDetail>();
            //using (var httpClient = new HttpClient())
            //{
            //    var token = "a640386b-eea3-39b0-b6ce-42bf1b25d233";//

            //    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.ToString());

            //    using (var response = await httpClient.GetAsync(apiBaseUrl))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        var json = response.Content.ReadAsStringAsync().Result;
            //        dynamic json_result = JsonConvert.DeserializeObject(json);

            //        CitizenDetail account = JsonConvert.DeserializeObject<CitizenDetail>(apiResponse);


            //        //var valueSet = JsonConvert.DeserializeObject<Wrapper>(apiResponse).ValueSet;

            //       // reservationList = JsonConvert.DeserializeObject<CitizenDetailsResponse>(apiResponse);

            //        var myDeserializedClass =(Root) JsonConvert.DeserializeObject(apiResponse);
            //    }
            //}
            //var citizenlst = await apiService.GetCitizenByCID("11303003096");
            _ = new List<TransactionTypeVM>();
            IList<TransactionTypeVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: TaxMaster/TransactionTypes/Details/5
        [Route("TaxMaster/TransactionTypes/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTransactionType = await _context.MstTransactionType
                .FirstOrDefaultAsync(m => m.TransactionTypeId == id);
            if (mstTransactionType == null)
            {
                return NotFound();
            }

            return View(mstTransactionType);
        }

        // GET: TaxMaster/TransactionTypes/Create
        [Route("TaxMaster/TransactionTypes/Create")]
        public IActionResult Create()
        {
            ViewData["SectionId"] = _CommonRepo.SelectListSection();
            return View();
        }

        // POST: TaxMaster/TransactionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TransactionTypes/Create")]
        public async Task<IActionResult> Create(TransactionTypeVM obj)
        {
           
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;// Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            ViewData["SectionId"] = _CommonRepo.SelectListSection();
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.TransactionType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Create));
                }
            }
            ViewData["SectionId"] = _CommonRepo.SelectListSection();

            return View(obj);
        }

        // GET: TaxMaster/TransactionTypes/Edit/5
        [Route("TaxMaster/TransactionTypes/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            ViewData["SectionId"] = _CommonRepo.SelectListSection();

            return View(Data);
        }

        // POST: TaxMaster/TransactionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TransactionTypes/Edit")]
        public async Task<IActionResult> Edit(TransactionTypeVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;// Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.TransactionType, obj.TransactionTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.TransactionTypeId);
            if (Data.TransactionTypeId != obj.TransactionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.Update(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Record updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while updating";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstTransactionTypeExists(obj.TransactionTypeId))
                    {
                        TempData["msg"] = "No record found.";
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["SectionId"] = _CommonRepo.SelectListSection();

            return View(obj);
        }

        // GET: TaxMaster/TransactionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTransactionType = await _context.MstTransactionType
                .FirstOrDefaultAsync(m => m.TransactionTypeId == id);
            if (mstTransactionType == null)
            {
                return NotFound();
            }

            return View(mstTransactionType);
        }

        // POST: TaxMaster/TransactionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTransactionType = await _context.MstTransactionType.FindAsync(id);
            _context.MstTransactionType.Remove(mstTransactionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstTransactionTypeExists(int id)
        {
            return _context.MstTransactionType.Any(e => e.TransactionTypeId == id);
        }
    }
}
