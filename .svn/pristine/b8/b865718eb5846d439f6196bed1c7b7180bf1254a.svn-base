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

namespace ARMS.Areas.Location.Controllers
{
    [Area("Location")]
    public class VillagesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IVillage _repository = new VillageBLL();
        public VillagesController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("Location/Villages")]
        public async Task<IActionResult> Index()
        {
            _ = new List<VillageModel>();
            IList<VillageModel> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("Location/Villages/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<VillageModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        [Route("Location/Villages/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {

            ViewData["GewogId"] = _CommonRepo.SelectListGewog();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Location/Villages/Create")]
        public async Task<IActionResult> Create(VillageModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.VillageName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Village name.";
                PopulateDropDowns();
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveVillage(obj);

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
        [Route("Location/Villages/Edit")]
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
            ViewData["GewogId"] = _CommonRepo.SelectListGewog();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Location/Villages/Edit")]
        public async Task<IActionResult> Edit(VillageModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.VillageName, obj.GewogId, obj.VillageId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Gewog name.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.VillageId);
            if (Data.VillageId != obj.VillageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateVillage(obj);
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
                    if (!MstVillageExists(obj.VillageId))
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
            ViewData["GewogId"] = _CommonRepo.SelectListGewog();
            return View(obj);
        }

        [Route("Location/Villages/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstVillage = await _repository.Details(id);
            if (mstVillage == null)
            {
                return NotFound();
            }

            return View(mstVillage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Location/Villages/Delete")]

        public async Task<IActionResult> DeleteConfirmed(VillageModel obj)
        {
            await _repository.DeleteConfirmed(obj.VillageId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstVillageExists(int id)
        {
            return _context.MstVillage.Any(e => e.VillageId == id);
        }
    }
}
