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
    public class GewogsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IGewog _repository = new GewogBLL();
        public GewogsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("Location/Gewogs")]
        public async Task<IActionResult> Index()
        {
            _ = new List<GewogModel>();
            IList<GewogModel> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("Location/Gewogs/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<GewogModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        [Route("Location/Gewogs/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {
            
            ViewData["DzongkhagId"] = _CommonRepo.SelectListDzongkhag();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Location/Gewogs/Create")]
        public async Task<IActionResult> Create(GewogModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.GewogName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Gewog name.";
                PopulateDropDowns();
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveGewog(obj);

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
        [Route("Location/Gewogs/Edit")]
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
            ViewData["DzongkhagId"] = _CommonRepo.SelectListDzongkhag();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Location/Gewogs/Edit")]
        public async Task<IActionResult> Edit(GewogModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.GewogName,obj.DzongkhagId, obj.GewogId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Gewog name.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.GewogId);
            if (Data.GewogId != obj.GewogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateGewog(obj);
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
                    if (!MstGewogExists(obj.GewogId))
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
            ViewData["DzongkhagId"] = _CommonRepo.SelectListDzongkhag();
            return View(obj);
        }

        [Route("Location/Gewogs/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstGewog = await _repository.Details(id);
            if (mstGewog == null)
            {
                return NotFound();
            }

            return View(mstGewog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Location/Gewogs/Delete")]

        public async Task<IActionResult> DeleteConfirmed(GewogModel obj)
        {
            await _repository.DeleteConfirmed(obj.GewogId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstGewogExists(int id)
        {
            return _context.MstGewog.Any(e => e.GewogId == id);
        }
    }
}
