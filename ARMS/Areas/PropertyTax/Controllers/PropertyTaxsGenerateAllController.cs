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
    public class PropertyTaxsGenerateAllController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IPropertyTaxGenerateAll _repo = new PropertyTaxGenerateAllBLL();

        public PropertyTaxsGenerateAllController(tt_dbContext context)
        {
            _context = context;
        }
        [Authorize]
        [Route("PropertyTaxsGenerateAll/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route("PropertyTax/PropertyTaxsGenerateAll/GetLandOwnershipDetail")]
        public List<LandOwneshipModel> GetLandOwnershipDetail( int TaxPayerId)
        {
            return _repo.GetLandOwnershipDetail(TaxPayerId).ToList();
        }
        [Authorize]
        [Route("Property/PropertyTaxsGenerateAll/GetTaxPayerProfile")]
        public List<LandOwneshipModel> FetchTaxPayerByCID(string Cid, string Ttin, string PlotNo, string ThramNo)
        {
            if(PlotNo == " " && ThramNo == " ")
            {
                return _repo.FetchTaxPayerByPlotNo(Cid, Ttin, PlotNo, ThramNo).ToList();
            }
            else
            {
                return _repo.FetchTaxPayerByCID(Cid, Ttin, PlotNo, ThramNo).ToList();

            }
        }
        [Authorize]
        [Route("PropertyTax/PropertyTaxsGenerateAll/GetLandTaxDetail")]
        public async Task<List<LandOwneshipModel>> GetLandTaxDetail(int LandOwnershipId)
        {
            return (List<LandOwneshipModel>)await _repo.GetLandTaxDetail(LandOwnershipId);
        }


        [Authorize]
        [Route("PropertyTax/PropertyTaxsGenerateAll/GetBuildingTaxDetail")]
        public List<BuildingTaxVM> GetBuildingTaxDetail(int LandOwnershipId)
        {
            return _repo.GetBuildingTaxDetail(LandOwnershipId).ToList();
        }
        [Authorize]
        [HttpPost]
        [Route("PropertyTax/PropertyTaxsGenerateAll/GenerateLandTax")]
        public JsonResult GenerateLandTax([FromBody] List<GenerateAllPropertyTaxModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<GenerateAllPropertyTaxModel>();
            }

            string  returnvalue = "";
            returnvalue = _repo.CreateLandTax(json_data);


            return Json(returnvalue);

        }
        
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxsGenerateAll/GetGeneratedDemand")]
        public List<LedgerDemandVM> GetGeneratedDemand(long DemandNoId)
        {
            return _repo.GetGeneratedDemand(DemandNoId).ToList();
        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxsGenerateAll/PopulateCalendarYear")]
        public List<CommonFunctionModel> PopulateCalendarYear()
        {          
            return _CommonRepo.SelectListCalendarYear().ToList();

        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxsGenerateAll/CheckDuplicateTax")]
        public List<LedgerDemandVM> CheckDuplicateTax(int OwnershipId, int CalendarYearId)
        {
            return _repo.CheckDuplicateTax(OwnershipId, CalendarYearId).ToList();
        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxsGenerateAll/lasttaxpaid")]
        public List<LedgerDemandVM> lasttaxpaid(int LandOwnershipId)
        {
            return _repo.lasttaxpaid(LandOwnershipId).ToList();
        }
        [Authorize]
        [HttpGet]
        [Route("PropertyTax/PropertyTaxsGenerateAll/GenerateAllPropertyTaxes")]
        public IActionResult GenerateAllPropertyTaxes()
        {
            return View();
        }

        [Route("PropertyTax/PropertyTaxsGenerateAll/GetOwnershipDetailByTaxPayerId")]
        public IEnumerable<GenerateAllDisplayModel> GetOwnershipDetailByTaxPayerId(int LandOwnershipId, int TaxYearId)
        {

            IEnumerable<GenerateAllDisplayModel> _dList = null;
            return _dList = _repo.GetOwnershipDetailByTaxPayerId(LandOwnershipId, TaxYearId);
        }
        [Route("PropertyTax/PropertyTaxsGenerateAll/GetOwnershipDetailByLandOwnershipId")]
        public IEnumerable<GenerateAllModel> GetOwnershipDetailByLandOwnershipId(string Ids, int TaxYearId)
        {

            IEnumerable<GenerateAllModel> _dList = null;
            return _dList = _repo.GetOwnershipDetailByLandOwnershipId(Ids, TaxYearId);
        }
        //[Authorize]
        //[HttpPost]
        //[Route("PropertyTax/PropertyTaxsGenerateAll/GenerateAllPropertyTax")]
        //public JsonResult GenerateAllPropertyTax([FromBody] List<LedgerDemandVM> json_data)
        //{

        //    //Check for NULL.  
        //    if (json_data == null)
        //    {
        //        json_data = new List<LedgerDemandVM>();
        //    }
        //    long returnvalue = 0;
        //    LedgerDemandVM obj = new LedgerDemandVM();
        //    //Loop and insert records. 
        //    foreach (LedgerDemandVM item in json_data)
        //    {
        //        obj.TaxId = item.TaxId;
        //        obj.TaxIdUD = item.TaxIdUD;
        //        obj.StructureAvailable = item.StructureAvailable;
        //        obj.TaxPayerId = item.TaxPayerId;
        //        obj.LandDetailId = item.LandDetailId;
        //        obj.LandOwnerShipId = item.LandOwnerShipId;
        //        //obj.FinancialYearId = item.FinancialYearId;
        //        obj.CalendarYearId = item.CalendarYearId;
        //        obj.TotalAmount = item.TotalAmount;
        //        obj.TotalAmountUD = item.TotalAmountUD;
        //        obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        //        obj.CreatedOn = DateTime.Now;
        //        returnvalue = _repo.CreateLandTax(obj);
        //    }


        //    return Json(returnvalue);

        //}

       



    }
}
