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

namespace ARMS.Areas.AssetAccountHead.Controllers
{
    [Area("AssetAccountHead")]
    public class TertiaryAccountHeadsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly ITertiaryAccountHead _repository = new TertiaryAccountHeadBLL();
        public TertiaryAccountHeadsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("AssetAccountHead/TertiaryAccountHeads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<TertiaryAccountHeadModel>();
            IList<TertiaryAccountHeadModel> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("AssetAccountHead/TertiaryAccountHeads/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<TertiaryAccountHeadModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        [Route("AssetAccountHead/TertiaryAccountHeads/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {

            ViewData["SecondaryAccountHeadId"] = _CommonRepo.SelectListSecondaryHead();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetAccountHead/TertiaryAccountHeads/Create")]
        public async Task<IActionResult> Create(TertiaryAccountHeadModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn =DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.TertiaryAccountHeadName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Tertiary Account name.";
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
                    return RedirectToAction(nameof(Create));
                }

            }
            PopulateDropDowns();

            return View(obj);
        }

        [HttpGet]
        [Route("AssetAccountHead/TertiaryAccountHeads/Edit")]
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
            ViewData["SecondaryAccountHeadId"] = _CommonRepo.SelectListSecondaryHead();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetAccountHead/TertiaryAccountHeads/Edit")]
        public async Task<IActionResult> Edit(TertiaryAccountHeadModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.TertiaryAccountHeadName, obj.SecondaryAccountHeadId, obj.TertiaryAccountHeadId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Tertiary Head name.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.TertiaryAccountHeadId);
            if (Data.TertiaryAccountHeadId != obj.TertiaryAccountHeadId)
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
                    if (!MstTertiaryExists(obj.TertiaryAccountHeadId))
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
            ViewData["SecondaryAccountHeadId"] = _CommonRepo.SelectListSecondaryHead();
            return View(obj);
        }

        [Route("AssetAccountHead/TertiaryAccountHeads/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTertiary = await _repository.Details(id);
            if (mstTertiary == null)
            {
                return NotFound();
            }

            return View(mstTertiary);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("AssetAccountHead/TertiaryAccountHeads/Delete")]

        public async Task<IActionResult> DeleteConfirmed(TertiaryAccountHeadModel obj)
        {
            await _repository.DeleteConfirmed(obj.TertiaryAccountHeadId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstTertiaryExists(int id)
        {
            return _context.MstTertiaryAccountHead.Any(e => e.TertiaryAccountHeadId == id);
        }
    }
}
