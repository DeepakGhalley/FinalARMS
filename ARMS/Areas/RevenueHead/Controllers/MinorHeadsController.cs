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
    public class MinorHeadsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IMinorHead _repository = new MinorHeadBLL();
        public MinorHeadsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("RevenueHead/MinorHeads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<MinorHeadModel>();
            IList<MinorHeadModel> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("RevenueHead/MinorHeads/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<MinorHeadModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        [Route("RevenueHead/MinorHeads/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {

            ViewData["MajorHeadId"] = _CommonRepo.SelectListMajorHead();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("RevenueHead/MinorHeads/Create")]
        public async Task<IActionResult> Create(MinorHeadModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.MinorHeadName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Minor Head name.";
                PopulateDropDowns();
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveMinorHead(obj);

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
        [Route("RevenueHead/MinorHeads/Edit")]
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
            ViewData["MajorHeadId"] = _CommonRepo.SelectListMajorHead();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("RevenueHead/MinorHeads/Edit")]
        public async Task<IActionResult> Edit(MinorHeadModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;// Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.MinorHeadName, obj.MinorHeadId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Minor Head name.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.MinorHeadId);
            if (Data.MinorHeadId != obj.MinorHeadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateMinorHead(obj);
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
                    if (!MstMinorHeadExists(obj.MinorHeadId))
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
            ViewData["MajorHeadId"] = _CommonRepo.SelectListMajorHead();
            return View(obj);
        }

        [Route("RevenueHead/MinorHeads/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstMinorHead = await _repository.Details(id);
            if (mstMinorHead == null)
            {
                return NotFound();
            }

            return View(mstMinorHead);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("RevenueHead/MinorHeads/Delete")]

        public async Task<IActionResult> DeleteConfirmed(MinorHeadModel obj)
        {
            await _repository.DeleteConfirmed(obj.MinorHeadId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstMinorHeadExists(int id)
        {
            return _context.MstMinorHead.Any(e => e.MinorHeadId == id);
        }
    }
}
