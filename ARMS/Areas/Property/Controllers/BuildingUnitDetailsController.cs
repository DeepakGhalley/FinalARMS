﻿using System;
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
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class BuildingUnitDetailsController : Controller
    {
        private readonly tt_dbContext _context;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IBuildingUnitDetails _obj = new BuildingUnitDetailsBLL(); 
        public BuildingUnitDetailsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Property/BuildingUnitDetails
        [Route("Property/BuildingUnitDetails")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BuildingUnitDetailModel>();
            IList<BuildingUnitDetailModel> obj = _obj.GetAll();
            return View(obj);
        }

        // GET: Property/BuildingUnitDetails/Details/5
        [Route("Property/BuildingUnitDetails/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _obj.Details(id);

            if (data == null)
            {
                return NotFound();
            }
            PopulateDropdown();
            return View(data);
        }

        // GET: Property/BuildingUnitDetails/Create
        [Route("Property/BuildingUnitDetails/Create")]
        public IActionResult Create()
        {
            PopulateDropdown();
            return View();
        }

        private void PopulateDropdown()
        {
            ViewData["BuildingDetailId"] = _CommonRepo.SelectListBuildingDetail();
            ViewData["BuildingUnitClassId"] = _CommonRepo.SelectListBuildingUnitClass();
            ViewData["FloorNameId"] = _CommonRepo.SelectListFloorName();
            ViewData["BuildingUnitUseTypeId"] = _CommonRepo.SelectListBuildingUnitUseType();
            ViewData["OwnerTypeId"] = _CommonRepo.SelectListUnitOwnerType();

        }

        // POST: Property/BuildingUnitDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/BuildingUnitDetails/Create")]
        public async Task<IActionResult> Create(BuildingUnitDetailModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    int returnvalue = _obj.Save(obj);

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            PopulateDropdown();
            return View(obj);
        }
        // GET: Property/BuildingUnitDetails/Edit/5
        [Route("Property/BuildingUnitDetails/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Data = await _obj.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            PopulateDropdown();
            return View(Data);
        }
        // POST: Property/BuildingUnitDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/BuildingUnitDetails/Edit")]
        public async Task<IActionResult> Edit(BuildingUnitDetailModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn =DateTime.Now;

            var Data = await _obj.Details(obj.BuildingUnitDetailId);
            if (Data.BuildingUnitDetailId != obj.BuildingUnitDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _obj.Update(obj);
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
                    if (!MstBuildingUnitDetailExists(obj.BuildingUnitDetailId))
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
            PopulateDropdown();
            return View(obj);
        }

        // GET: Property/BuildingUnitDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingUnitDetail = await _context.MstBuildingUnitDetail
                .Include(m => m.BuildingDetail)
                .FirstOrDefaultAsync(m => m.BuildingUnitDetailId == id);
            if (mstBuildingUnitDetail == null)
            {
                return NotFound();
            }

            return View(mstBuildingUnitDetail);
        }

        // POST: Property/BuildingUnitDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstBuildingUnitDetail = await _context.MstBuildingUnitDetail.FindAsync(id);
            _context.MstBuildingUnitDetail.Remove(mstBuildingUnitDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingUnitDetailExists(int id)
        {
            return _context.MstBuildingUnitDetail.Any(e => e.BuildingUnitDetailId == id);
        }

        [Route("Property/BuildingUnitDetails/SearchBuildingDetailsPlotNo")]
        public List<BuildingUnitDetailModel> SearchBuildingDetailsPlotNo(string plotno)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _obj.SearchBuildingDetailsPlotNo(plotno);
        }

        [Route("Property/BuildingUnitDetails/SearchDetailsByCid")]
        public List<BuildingUnitDetailModel> SearchDetailsByCid(string cid, string ttin)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _obj.SearchDetailsByCid(cid, ttin);
        }

        [Route("Property/BuildingUnitDetails/getExisitingBuildingUnitDetails")]
        public List<BuildingUnitDetailModel> getExisitingBuildingUnitDetails(int id)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _obj.getExisitingBuildingUnitDetails(id);
        }

        //UNMAPPED BUILDING UNIT DETAILS
        [Route("Property/BuildingUnitDetails/getUnMappedBuildingUnitDetails")]
        public List<BuildingUnitDetailModel> getUnMappedBuildingUnitDetails(int id)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _obj.getUnMappedBuildingUnitDetails(id);
        }

        //UPDATE BUILDING UNIT DETAILS
        [HttpPost]
        [Route("Property/BuildingUnitDetails/UpdateBuildingUnitDetails")]
        public JsonResult UpdateBuildingUnitDetails([FromBody] List<BuildingUnitDetailModel> json_data)
        {
            long returnvalue = 0;

            if (json_data == null)
            {
                json_data = new List<BuildingUnitDetailModel>();
            }
            BuildingUnitDetailModel obj = new BuildingUnitDetailModel();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (BuildingUnitDetailModel item in json_data)
                    { 
                        obj.TaxPayerId= item.TaxPayerId;
                        obj.BuildingUnitDetailId = item.BuildingUnitDetailId;
                        obj.Plr = item.Plr;
                        obj.CreatedBy= Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                        returnvalue = _obj.UpdateBuildingUnitDetails(obj);
                        }

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
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingUnitDetailExists(obj.BuildingUnitDetailId))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json(TempData["msg"]);

        }
        private bool BuildingUnitDetailExists(int id)
        {
            return _context.MstBuildingUnitDetail.Any(e => e.BuildingUnitDetailId== id);
        }

        [Route("Property/BuildingUnitDetails/SearchByPlot")]
        public List<BuildingUnitDetailModel> SearchByPlot(string PlotNo)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _obj.SearchByPlot(PlotNo);
        }

        [Route("Property/BuildingUnitDetails/GetBuildingUnitDetail")]
        public List<BuildingUnitDetailModel> GetBuildingUnitDetail(int id)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _obj.GetBuildingUnitDetail(id);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("Property/BuildingUnitDetails/RemoveBuildingUnitDetail")]
        public async Task<Int32> RemoveBuildingUnitDetail(int id)
        {

            try
            {
                var DataBuildingUnitDetail = _context.MstBuildingUnitDetail.Single(x => x.BuildingUnitDetailId == id);
                DataBuildingUnitDetail.IsActive = false;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [HttpGet]
        [Route("Property/BuildingUnitDetails/CheckUnpaidPropertyDemand")]
        public async Task<Int32> CheckUnpaidPropertyDemand(string plotNo)
        {

            try
            {
                var data = (from a in _context.TblDemand
                            join b in _context.MstLandDetail on a.LandDetailId equals b.LandDetailId
                            join c in _context.TblTransactionDetail on a.TransactionId equals c.TransactionId
                            where a.IsCancelled==false && a.IsPaymentMade==false && c.TransactionTypeId==20 && b.PlotNo==plotNo 
                            select new 
                            {
                                DemandId = a.DemandId,
                                DemandNoId = a.DemandNoId,
                                TaxPayerId = a.TaxPayerId,
                               
                            });

                return data.Count();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
