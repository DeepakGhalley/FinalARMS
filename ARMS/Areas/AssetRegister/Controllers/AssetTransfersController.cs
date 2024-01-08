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

namespace ARMS.Areas.AssetTransfers.Controllers
{
    [Area("AssetRegister")]
    public class AssetTransfersController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IAssetTransfer _repository = new AssetTransfer();
        readonly IAssetTransfer _obj = new AssetTransfer();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        public AssetTransfersController(tt_dbContext context)
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
            ViewData["AssetTransfer"] = _CommonRepo.SelectListAssetTransferType();
        }
        [Route("AssetRegister/AssetTransfers/Index")]
        public IActionResult Index()
        {
            PopulateDropDown();
            return View();
        }

        [HttpPost]
        [Route("AssetRegister/AssetTransfers/PopulateSecondaryAccountHead")]
        public List<SecondaryAccountHeadModel> PopulateSecondaryAccountHead(int id)
        {
            List<SecondaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchSecondaryHead(id);
        }

        [HttpPost]
        [Route("AssetRegister/AssetTransfers/PopulateTertiaryAccountHead")]
        public List<TertiaryAccountHeadModel> PopulateTertiaryAccountHead(int id)
        {
            List<TertiaryAccountHeadModel> _dataList = null;
            return _dataList = _repository.fetchTertiaryHead(id);
        }

        [HttpPost]
        [Route("AssetRegister/AssetTransfers/PopulateDivision")]
        public List<SectionModel> PopulateDivision(int id)
        {
            List<SectionModel> _dataList = null;
            return _dataList = _repository.fetchDivision(id);
        }

        [Route("AssetRegister/AssetTransfers/SearchAsset")]
        public List<AssetTransferVM> SearchAsset(int primaryhead, int secondaryhead, int tertiaryhead, int division, int section, string assetname, int assetstatus, int lap, int demkhong)
        {
            List<AssetTransferVM> _dList = null;
            return _dList = _repository.SearchAsset(primaryhead, secondaryhead, tertiaryhead, division, section, assetname, assetstatus, lap, demkhong);
        }

        [Route("AssetRegister/AssetTransfers/GetAssetDetails")]
        public List<AssetTransferVM> GetAssetDetails(int id)
        {
            return _repository.GetAssetDetails(id).ToList();

        }

        [HttpPost]
        [Route("AssetRegister/AssetTransfers/SaveAssetTransfer")]
        public JsonResult SaveAssetTransfer([FromBody] List<AssetTransferVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<AssetTransferVM>();
            }

            AssetTransferVM obj = new AssetTransferVM();
            foreach (AssetTransferVM item in json_data)
            {
                obj.AssetId = item.AssetId;
                obj.TransferFromDivisionId = item.TransferFromDivisionId;
                obj.TransferFromSectionId = item.TransferFromSectionId;
                obj.TransferToDivisionId = item.TransferToDivisionId;
                obj.TransferToSectionId = item.TransferToSectionId;
                obj.TransferDate = item.TransferDate;
                obj.Remarks = item.Remarks;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.ModifiedOn = DateTime.Now;
                obj.ResponsiblePersonTo = item.ResponsiblePersonTo;
                obj.ResponsiblePersonFrom = item.ResponsiblePersonFrom;
                obj.AssetTransferTypeId = item.AssetTransferTypeId;
                _repository.SaveAssetTransfer(obj);
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

