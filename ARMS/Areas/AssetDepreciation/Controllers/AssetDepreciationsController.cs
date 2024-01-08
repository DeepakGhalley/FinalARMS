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

namespace ARMS.Areas.AssetDepreciation.Controllers
{
    [Area("AssetDepreciation")]
    public class AssetDepreciationsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IAssetDepreciation _repository = new AssetDepreciationBLL();
        readonly IAssetDepreciation _obj = new AssetDepreciationBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        public AssetDepreciationsController(tt_dbContext context)
        {
            _context = context;
        }

        private void PopulateDropDown()
        {
            ViewData["PrimaryHead"] = _CommonRepo.SelectListPrimaryHead();
            ViewData["SecondaryHead"] = _CommonRepo.SelectListSecondaryHead();
            ViewData["TertiaryHead"] = _CommonRepo.SelectListTertiaryHead();
            ViewData["Division"] = _CommonRepo.SelectListDivision();
            ViewData["Section"] = _CommonRepo.SelectListSection();
            ViewData["AssetStatus"] = _CommonRepo.SelectListAssetStatus();
            ViewData["Lap"] = _CommonRepo.SelectListLap();
            ViewData["Demkhong"] = _CommonRepo.SelectListDemkhong();
            ViewData["Depreciation"] = _CommonRepo.SelectListDepreciationType();
            ViewData["Financialyear"] = _CommonRepo.SelectListFinancialYear();

        }
       
        [Route("AssetDepreciation/Index")]
        public IActionResult Index()
        {
            PopulateDropDown();
            return View();
        }

        [HttpPost]
        [Route("AssetDepreciation/AssetDepreciations/PopulateSecondaryAccountHead")]
        public List<SecondaryAccountHeadModel> PopulateSecondaryAccountHead(int id)
        {
            List<SecondaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchSecondaryHead(id);
        }

        [HttpPost]
        [Route("AssetDepreciation/AssetDepreciations/PopulateTertiaryAccountHead")]
        public List<TertiaryAccountHeadModel> PopulateTertiaryAccountHead(int id)
        {
            List<TertiaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchTertiaryHead(id);
        }

        [HttpPost]
        [Route("AssetDepreciation/AssetDepreciations/PopulateDivision")]
        public List<SectionModel> PopulateDivision(int id)
        {
            List<SectionModel> _dataList = null;
            return _dataList = _repository.fetchDivision(id);
        }

        [Route("AssetDepreciation/AssetMaintenances/SearchAsset")]
        public List<AssetDepreciationVM> SearchAsset(int primaryhead, int secondaryhead, int tertiaryhead, int division, int section, string assetname, int assetstatus, int lap, int demkhong)
        {
            List<AssetDepreciationVM> _dList = null;
            return _dList = _repository.SearchAsset(primaryhead, secondaryhead, tertiaryhead, division, section, assetname, assetstatus, lap, demkhong);
        }

        [Route("AssetDepreciation/AssetDepreciations/GetAssetDepreciationDetails")]
        public List<AssetDepreciationVM> GetAssetDepreciationDetails(int id)
        {
            return _repository.GetAssetDepreciationDetails(id).ToList();

        }
        [Route("AssetDepreciation/AssetDepreciations/GetAssetDetails")]
        public List<AssetDepreciationVM> GetAssetDetails(int id)
        {
            return _repository.GetAssetDetails(id).ToList();

        }
        [HttpPost]
        [Route("AssetDepreciation/AssetDepreciations/SaveAssetDepreciation")]
        public JsonResult SaveAssetDepreciation([FromBody] List<AssetDepreciationVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<AssetDepreciationVM>();
            }

            AssetDepreciationVM obj = new AssetDepreciationVM();
            foreach (AssetDepreciationVM item in json_data)
            {
                obj.AssetId = item.AssetId;
                obj.FinancialYearId = item.FinancialYearId;
                obj.DepreciationTypeId = item.DepreciationTypeId;
                obj.DepreciationValue = item.DepreciationValue;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.ModifiedOn = DateTime.Now;
                _repository.SaveAssetDepreciation(obj);
            }
            try
            {
                int returnvalue = 1;

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Record Saved Successfully!";

                }
                else
                {
                    TempData["msg"] = "New Creation failed!";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);

        }
    }
}
