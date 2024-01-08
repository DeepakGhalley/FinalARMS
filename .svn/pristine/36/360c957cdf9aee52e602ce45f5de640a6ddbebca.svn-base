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

namespace ARMS.Areas.AssetMaintenance.Controllers
{
    [Area("AssetMaintenance")]
    public class AssetMaintenancesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IAssetMaintenance _repository = new AssetMaintenanceBLL();
        readonly IAssetMaintenance _obj = new AssetMaintenanceBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        public AssetMaintenancesController(tt_dbContext context)
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
            ViewData["Maintenance"] = _CommonRepo.SelectListMaintenanceType();
        }
        [Route("AssetMaintenance/Index")]
        public IActionResult Index()
        {
            PopulateDropDown();
            return View();
        }

        [HttpPost]
        [Route("AssetMaintenance/AssetMaintenances/PopulateSecondaryAccountHead")]
        public List<SecondaryAccountHeadModel> PopulateSecondaryAccountHead(int id)
        {
            List<SecondaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchSecondaryHead(id);
        }

        [HttpPost]
        [Route("AssetMaintenance/AssetMaintenances/PopulateTertiaryAccountHead")]
        public List<TertiaryAccountHeadModel> PopulateTertiaryAccountHead(int id)
        {
            List<TertiaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchTertiaryHead(id);
        }

        [HttpPost]
        [Route("AssetMaintenance/AssetMaintenances/PopulateDivision")]
        public List<SectionModel> PopulateDivision(int id)
        {
            List<SectionModel> _dataList = null;
            return _dataList = _repository.fetchDivision(id);
        }

        [Route("AssetMaintenance/AssetMaintenances/SearchAsset")]
        public List<AssetMaintenanceVM> SearchAsset(int primaryhead, int secondaryhead, int tertiaryhead, int division, int section, string assetname, int assetstatus, int lap, int demkhong)
        {
            List<AssetMaintenanceVM> _dList = null;
            return _dList = _repository.SearchAsset(primaryhead, secondaryhead, tertiaryhead, division, section, assetname, assetstatus, lap, demkhong);
        }

        [Route("AssetMaintenance/AssetMaintenances/GetAssetDetails")]
        public List<AssetMaintenanceVM> GetAssetDetails(int id)
        {
            return _repository.GetAssetDetails(id).ToList();

        }

        [HttpPost]
        [Route("AssetMaintenance/AssetMaintenances/SaveAssetMaintenance")]
        public JsonResult SaveAssetMaintenance([FromBody] List<AssetMaintenanceVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<AssetMaintenanceVM>();
            }

            AssetMaintenanceVM obj = new AssetMaintenanceVM();
            foreach (AssetMaintenanceVM item in json_data)
            {
                obj.AssetId = item.AssetId;
                obj.MaintenanceTypeId = item.MaintenanceTypeId;
                obj.MaintenanceDate = item.MaintenanceDate;
                obj.MaintenanceCost = item.MaintenanceCost;
                obj.Reason = item.Reason;
                obj.DateofNextMaintenance = item.DateofNextMaintenance;
                obj.SparePartUsed = item.SparePartUsed;
                obj.ServiceOrderNo = item.ServiceOrderNo;
                obj.ServiceOrderDate = item.ServiceOrderDate;
                obj.Remarks = item.Remarks;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.ModifiedOn = DateTime.Now;
                _repository.SaveAssetMaintenance(obj);
            }
            try
            {
                int returnvalue = 1; 

                if (returnvalue >= 1)
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

