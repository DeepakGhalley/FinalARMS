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
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.Location.Controllers
{
    
    [Area("RevenueHead")]
    [Authorize]
    public class DetailHeadsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IDetailHead _repository = new DetailHeadBLL();
        public DetailHeadsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("RevenueHead/DetailHeads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DetailHeadModel>();
            IList<DetailHeadModel> obj = _repository.GetAll();
            PopulateDropDowns();
            return View(obj);
        }
        [Route("RevenueHead/DetailHeads/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<DetailHeadModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        [Route("RevenueHead/DetailHeads/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {

            ViewData["MinorHeadId"] = _CommonRepo.SelectListMinorHead();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("RevenueHead/DetailHeads/Create")]
        public async Task<IActionResult> Create(DetailHeadModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;// DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.DetailHeadName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Detail Head name.";
                PopulateDropDowns();
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveDetailHead(obj);

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
            PopulateDropDowns();

            return View(obj);
        }

        [HttpGet]
        [Route("RevenueHead/DetailHeads/Edit")]
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
            ViewData["MinorHeadId"] = _CommonRepo.SelectListMinorHead();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("RevenueHead/DetailHeads/Edit")]
        public async Task<IActionResult> Edit(DetailHeadModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;// Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.DetailHeadName, obj.DetailHeadId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Detail Head name.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.DetailHeadId);
            if (Data.DetailHeadId != obj.DetailHeadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateDetailHead(obj);
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
                    if (!MstDetailHeadExists(obj.DetailHeadId))
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
            ViewData["MinorHeadId"] = _CommonRepo.SelectListMinorHead();
            return View(obj);
        }

        [Route("RevenueHead/DetailHeads/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDetailHead = await _repository.Details(id);
            if (mstDetailHead == null)
            {
                return NotFound();
            }

            return View(mstDetailHead);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("RevenueHead/DetailHeads/Delete")]

        public async Task<IActionResult> DeleteConfirmed(DetailHeadModel obj)
        {
            await _repository.DeleteConfirmed(obj.DetailHeadId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstDetailHeadExists(int id)
        {
            return _context.MstDetailHead.Any(e => e.DetailHeadId == id);
        }
    }
}
