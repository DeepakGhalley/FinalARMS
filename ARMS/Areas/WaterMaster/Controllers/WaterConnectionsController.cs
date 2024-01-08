﻿using System;
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
//using QRCoder;
//using System.Drawing;
//using System.IO;

namespace ARMS.Areas.WaterMaster.Controllers
{
    [Area("WaterMaster")]
    public class WaterConnectionsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IWaterConnection _repository = new WaterConnectionBLL();
        public WaterConnectionsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("WaterMaster/WaterConnections")]
        public async Task<IActionResult> Index()
        {
            _ = new List<WaterConnectionModel>();
            IList<WaterConnectionModel> obj = _repository.GetAll();
            PopulateDropDowns();
            return View(obj);
        }

        [Route("WaterMaster/WaterConnections/MeterReplacement")]
        public async Task<IActionResult> MeterReplacement()
        {
            _ = new List<WaterConnectionModel>();
            IList<WaterConnectionModel> obj = _repository.GetAll();
            PopulateDropDowns();
            return View(obj);
        }

        [HttpGet]
        [Route("WaterMaster/WaterConnections/GetWaterConnectionDetails")]
        public List<WaterConnectionModel> GetWaterConnectionDetails(string consumerno, string Plotno)
        {

            List<WaterConnectionModel> _dList = null;
            PopulateDropDowns();
            return _dList = _repository.GetWaterConnectionDetails(consumerno, Plotno);
        }
        [Route("WaterMaster/WaterConnections/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [Route("WaterMaster/WaterConnections/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {
            ViewData["WorkLevelId"] = _CommonRepo.SelectListWorkLevel();
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["WaterMeterTypeId"] = _CommonRepo.SelectListWaterMeterType();
            ViewData["WaterConnectionStatusId"] = _CommonRepo.SelectListWaterConnectionStatus();
            ViewData["WaterConnectionTypeId"] = _CommonRepo.SelectListWaterConnectionType();
            ViewData["WaterLineTypeId"] = _CommonRepo.SelectListWaterLineType();
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();
            ViewData["OwnerTypeId"] = _CommonRepo.SelectListOwnerType();
            ViewData["TaxPayerProfileId"] = _CommonRepo.SelectListTaxPayerProfile();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("WaterMaster/WaterConnections/Create")]
        public async Task<IActionResult> Create(WaterConnectionModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConsumerNo);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
                PopulateDropDowns();
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
                    return RedirectToAction(nameof(Index));
                }

            }
            PopulateDropDowns();

            return View(obj);
        }

        [HttpGet]
        [Route("WaterMaster/WaterConnections/Edit")]
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
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["WaterMeterTypeId"] = _CommonRepo.SelectListWaterMeterType();
            ViewData["WaterConnectionStatusId"] = _CommonRepo.SelectListWaterConnectionStatus();
            ViewData["WaterConnectionTypeId"] = _CommonRepo.SelectListWaterConnectionType();
            ViewData["WaterLineTypeId"] = _CommonRepo.SelectListWaterLineType();
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();
            ViewData["OwnerTypeId"] = _CommonRepo.SelectListOwnerType();

            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("WaterMaster/WaterConnections/Edit")]
        public async Task<IActionResult> Edit(WaterConnectionModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            //bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.ConsumerNo, obj.WaterConnectionId, obj.LandDetailId, obj.WaterMeterTypeId, obj.WaterConnectionTypeId, obj.WaterLineTypeId, obj.ZoneId, obj.OwnerTypeId);
            //if (CheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
            //    PopulateDropDowns();
            //    return View(obj);
            //}
            var Data = await _repository.Details(obj.WaterConnectionId);
            if (Data.WaterConnectionId != obj.WaterConnectionId)
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
                    if (!MstWaterConnectionExists(obj.WaterConnectionId))
                    {
                        TempData["msg"] = "No record found.";
                        return RedirectToAction(nameof(Edit));
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["WaterMeterTypeId"] = _CommonRepo.SelectListWaterMeterType();
            ViewData["WaterConnectionStatusId"] = _CommonRepo.SelectListWaterConnectionStatus();
            ViewData["WaterConnectionTypeId"] = _CommonRepo.SelectListWaterConnectionType();
            ViewData["WaterLineTypeId"] = _CommonRepo.SelectListWaterLineType();
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();
            ViewData["OwnerTypeId"] = _CommonRepo.SelectListOwnerType();
            return View(obj);
        }

        [Route("WaterMaster/WaterConnections/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstWaterConnection = await _repository.Details(id);
            if (mstWaterConnection == null)
            {
                return NotFound();
            }

            return View(mstWaterConnection);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("WaterMaster/WaterConnections/Delete")]

        public async Task<IActionResult> DeleteConfirmed(WaterConnectionModel obj)
        {
            await _repository.DeleteConfirmed(obj.WaterConnectionId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstWaterConnectionExists(int id)
        {
            return _context.MstWaterConnection.Any(e => e.WaterConnectionId == id);
        }

        [Route("WaterMaster/WaterConnections/GetWaterConnectionDetails")]
        public List<WaterConnectionModel> GetWaterConnectionDetails(int id, int LandOwnershipId)
        {
            List<WaterConnectionModel> _dList = null;
            return _dList = _repository.GetWaterConnectionDetails(id, LandOwnershipId);
        }

        [Route("WaterMaster/WaterConnections/fetchLandOwnershipDetails")]
        public List<GetLandOwnershipDetails> fetchLandOwnershipDetails(string cid, string ttin, string name)
        {
            List<GetLandOwnershipDetails> _dList = null;
            return _dList = _repository.fetchLandOwnershipDetails(cid, ttin, name);
        }

        //for Update/edit page(plot no search)
        [Route("WaterMaster/WaterConnections/SearchDetails")]
        public List<WaterConnectionModel> SearchDetails(string plotno)
        {
            List<WaterConnectionModel> _dList = null;
            return _dList = _repository.SearchDetails(plotno);
        }

        [Route("WaterMaster/WaterConnections/UpdateOwnership")]
        public async Task<IActionResult> UpdateOwnership()
        {
            return View();
        }

        [HttpGet]
        [Route("WaterMaster/WaterConnections/SearchPlotNo")]
        public List<WaterConnectionModel> SearchPlotNo(string PlotNo)
        {

            List<WaterConnectionModel> _dList = null;
            return _dList = _repository.SearchPlotNo(PlotNo);
        }

        [HttpPost]
        [Route("WaterMaster/WaterConnections/UpdateLandOwnership")]
        public JsonResult UpdateLandOwnership([FromBody] List<WaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<WaterConnectionModel>();
            }
            int returnvalue = 0; // 
            WaterConnectionModel obj = new WaterConnectionModel();
            foreach (WaterConnectionModel item in json_data)
            {
                obj.LandOwnershipId = item.LandOwnershipId;
                //obj.LandDetailId = item.LandDetailId;
                obj.WaterConnectionId = item.WaterConnectionId;             
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;

                returnvalue = _repository.UpdateLandOwnership(obj);
            }

            return Json(returnvalue);

        }

        [Route("WaterMaster/WaterConnections/DisplayLandOwnership")]
        public List<WaterConnectionModel> DisplayLandOwnership(int id)
        {

            List<WaterConnectionModel> _dList = null;

            return _dList = _repository.DisplayLandOwnership(id);
        }

        [Route("WaterMaster/WaterConnections/GetWaterConnectionForUpdate")]
        public List<WaterConnectionModel> GetWaterConnectionForUpdate(int WaterConnectionId)
        {
            PopulateDropDowns();
            return _repository.GetWaterConnectionForUpdate(WaterConnectionId).ToList();

        }

        [HttpPost]
        [Route("WaterMaster/WaterConnections/UpdateWaterConnection")]
        public JsonResult UpdateWaterConnection([FromBody] List<WaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<WaterConnectionModel>();
            }
            int returnvalue = 0; // 
            WaterConnectionModel obj = new WaterConnectionModel();
            foreach (WaterConnectionModel item in json_data)
            {                           
                obj.WaterConnectionId = item.WaterConnectionId;
                obj.ZoneId = item.ZoneId;
                obj.BillingAddress = item.BillingAddress;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.Remarks = item.Remarks;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;

                returnvalue = _repository.UpdateWaterConnection(obj);
            }
            PopulateDropDowns();
            return Json(returnvalue);

        }

        [HttpPost]
        [Route("WaterMaster/WaterConnections/WaterMeterReplacemnt")]
        public JsonResult WaterMeterReplacemnt([FromBody] List<WaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<WaterConnectionModel>();
            }
            int returnvalue = 0; // 
            WaterConnectionModel obj = new WaterConnectionModel();
            foreach (WaterConnectionModel item in json_data)
            {
                obj.WaterConnectionId = item.WaterConnectionId;
                obj.WaterMeterNo = item.WaterMeterNo;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.Remarks = item.Remarks;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;

                returnvalue = _repository.MeterReplacement(obj);
            }
            PopulateDropDowns();
            return Json(returnvalue);

        }

    }
}