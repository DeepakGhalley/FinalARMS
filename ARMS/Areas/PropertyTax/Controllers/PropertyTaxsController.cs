using AutoMapper;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ARMS.Areas.PropertyTax.Controllers
{
    [Area("PropertyTax")]
    [Authorize]
    public class PropertyTaxsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IPropertyTax _repo = new PropertyTaxBLL();
        readonly IPropertyTaxGenerateAll _repository = new PropertyTaxGenerateAllBLL();

        public PropertyTaxsController(tt_dbContext context)
        {
            _context = context;
        }
        [Authorize]
        [Route("PropertyTax/PropertyTaxs")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route("PropertyTax/PropertyTaxs/GetLandOwnershipDetail")]
        public List<LandOwneshipModel> GetLandOwnershipDetail( int TaxPayerId)
        {
            return _repo.GetLandOwnershipDetail(TaxPayerId).ToList();
        }
        [Authorize]
        [Route("Property/PropertyTaxs/GetTaxPayerProfile")]
        public List<LandOwneshipModel> FetchTaxPayerByCID(string Cid, string Ttin, string PlotNo, string ThramNo)
        {
            return  _repo.FetchTaxPayerByCID(Cid, Ttin, PlotNo,ThramNo).ToList();
        }
        [Authorize]
        [Route("PropertyTax/PropertyTaxs/GetLandTaxDetail")]
        public async Task<List<LandOwneshipModel>> GetLandTaxDetail(int LandOwnershipId)
        {
            return (List<LandOwneshipModel>)await _repo.GetLandTaxDetail(LandOwnershipId);
        }


        [Authorize]
        [Route("PropertyTax/PropertyTaxs/GetBuildingTaxDetail")]
        public List<BuildingTaxVM> GetBuildingTaxDetail(int LandOwnershipId, int TaxYearId)
        {
            return _repo.GetBuildingTaxDetail(LandOwnershipId, TaxYearId).ToList();
        }
        [Authorize]
        [HttpPost]
        [Route("PropertyTax/PropertyTaxs/GeneratePropertyTax")]
        public JsonResult GenerateLandTax([FromBody] List<LedgerDemandVM> json_data)
        {
            
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<LedgerDemandVM>();
            }
            long returnvalue = 0;
            LedgerDemandVM obj = new LedgerDemandVM();
            //Loop and insert records. 
            foreach (LedgerDemandVM item in json_data)
            {
                obj.TaxId = item.TaxId;
                obj.TaxIdUD = item.TaxIdUD;
                obj.StructureAvailable = item.StructureAvailable;
                obj.TaxPayerId = item.TaxPayerId;
                obj.LandDetailId = item.LandDetailId;
                obj.LandOwnerShipId = item.LandOwnerShipId;
                //obj.FinancialYearId = item.FinancialYearId;
                obj.CalendarYearId = item.CalendarYearId;
                obj.TotalAmount = item.TotalAmount;
                obj.TotalAmountUD = item.TotalAmountUD;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repo.CreateLandTax(obj);
            }
          

            return Json(returnvalue);

        }
        [Authorize]
        [HttpPost]
        [Route("PropertyTax/PropertyTaxs/GenerateUnitTax")]
        public async Task<JsonResult> GenerateUnitTaxAsync([FromBody] List<LedgerDemandVM> json_data)
        {

            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<LedgerDemandVM>();
            }
            long transactionId =0;
            long dnid = 0;
            foreach (LedgerDemandVM tt in json_data.Take(1))
            {
                var entityTRn = new TblTransactionDetail
                {
                    TransactionTypeId = 20,
                    WorkLevelId = 1,
                    TransactionValue = tt.TotalAmount,// obj.TotalPayable,  calculated value here from interface                
                    CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                    CreatedOn = DateTime.Now,
                };
                _context.TblTransactionDetail.Add(entityTRn);
                await _context.SaveChangesAsync();
                transactionId = entityTRn.TransactionId;

                var fyr = _context.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                var cyrData = _context.MstCalendarYear.Where(x => x.CalendarYearId == tt.CalendarYearId);
                int cyr = Convert.ToInt32(cyrData.FirstOrDefault().CalendarYear);


                int sq = _context.TblDemandNo.Where(p => p.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;

                sq = sq + 1;
                
                var entityDN = new TblDemandNo
                {
                    DemandNo = ("TTDN/" + (DateTime.Now.Year) + "/" + sq),
                    Sl = (int)sq,
                    DemandYear = DateTime.Now.Year,
                    CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                    CreatedOn = DateTime.Now,
                };
                _context.TblDemandNo.Add(entityDN);
                await _context.SaveChangesAsync();
                dnid = entityDN.DemandNoId;
            }
            long returnvalue = 0;
            LedgerDemandVM obj = new LedgerDemandVM();
            //Loop and insert records. 
            foreach (LedgerDemandVM item in json_data)
            {
                
                obj.DemandNoId = dnid;
                obj.TransactionId = transactionId;
                //obj.TransactionId = item.TransactionId;
                //obj.TaxId = item.TaxId;
                //obj.FinancialYearId = item.FinancialYearId;
                //obj.CalendarYearId = item.CalendarYearId;
                obj.TaxId = item.TaxId;
                obj.TotalAmount = item.TotalAmount;

                obj.GarbageTaxId = item.GarbageTaxId;
                obj.GarbageTax = item.GarbageTax;

                obj.StreetLightTaxId = item.StreetLightTaxId;
                obj.StreetLightTax = item.StreetLightTax;
                obj.LandOwnerShipId = item.LandOwnerShipId;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;

                obj.LandDetailId = item.LandDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.CalendarYearId = item.CalendarYearId;
                returnvalue = _repo.GenerateUnitTax(obj);
            }

                return Json(returnvalue);
         

        }

        [Authorize]
        [HttpPost]
        [Route("PropertyTax/PropertyTaxs/GenerateUnitTax1")]
        public async Task<JsonResult> GenerateUnitTax1Async([FromBody] List<LedgerDemandVM> json_data)
        {

            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<LedgerDemandVM>();
            }
            
            long returnvalue = 0;

            LedgerDemandVM obj = new LedgerDemandVM();

             

           
            //Loop and insert records. 
            foreach (LedgerDemandVM item in json_data.Take(1))
            {

                obj.DemandNoId = item.DemandNoId;
                //obj.TransactionId = item.TransactionId;
                //obj.TaxId = item.TaxId;
                //obj.FinancialYearId = item.FinancialYearId;
                //obj.CalendarYearId = item.CalendarYearId;
                obj.TaxId = item.TaxId;
                obj.TotalAmount = item.TotalAmount;

                obj.GarbageTaxId = item.GarbageTaxId;
                obj.GarbageTax = item.GarbageTax;

                obj.StreetLightTaxId = item.StreetLightTaxId;
                obj.StreetLightTax = item.StreetLightTax;
                obj.LandOwnerShipId = item.LandOwnerShipId;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;

                obj.LandDetailId = item.LandDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.CalendarYearId = item.CalendarYearId;
                returnvalue = _repo.GenerateUnitTax(obj);
            }

            return Json(returnvalue);


        }

        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxs/GetGeneratedDemand")]
        public List<LedgerDemandVM> GetGeneratedDemand(long DemandNoId)
        {
            return _repo.GetGeneratedDemand(DemandNoId).ToList();
        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxs/PopulateCalendarYear")]
        public List<CommonFunctionModel> PopulateCalendarYear()
        {          
            return _CommonRepo.SelectListCalendarYear().ToList();

        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxs/CheckDuplicateTax")]
        public List<LedgerDemandVM> CheckDuplicateTax(int TaxPayerId, int LandDetailId, int CalendarYearId)
        {
            return _repo.CheckDuplicateTax(TaxPayerId, LandDetailId, CalendarYearId).ToList();
        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxs/lasttaxpaid")]
        public List<LedgerDemandVM> lasttaxpaid(int LandOwnershipId)
        {
            return _repo.lasttaxpaid(LandOwnershipId).ToList();
        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxs/GenerateAllPropertyTaxes")]
        public IActionResult GenerateAllPropertyTaxes()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxs/CheckStructureAvailable")]
        public List<LedgerDemandVM> CheckStructureAvailable(int LandOwnershipId)
        {
            return _repo.CheckStructureAvailable(LandOwnershipId).ToList();
        }

        [Route("PropertyTax/PropertyTaxs/GetOwnershipDetailByLandOwnershipId")]
        public IEnumerable<GenerateAllModel> GetOwnershipDetailByLandOwnershipId(string Ids, int TaxYearId)
        {

            IEnumerable<GenerateAllModel> _dList = null;
            return _dList = _repository.GetOwnershipDetailByLandOwnershipId(Ids, TaxYearId);
        }
    }
}
