using System;
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
using ARMS.Functions;
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.Precinct.Controllers
{
    [Area("Precinct")]
    [Authorize]
    public class LandUseCategoriesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly ILandUseCategory _repository = new LandUseCategoryBLL();

        public LandUseCategoriesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Precinct/LandUseCategories
        [Route("Precinct/LandUseCategories")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LandUseCategoryModel>();
            IList<LandUseCategoryModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Precinct/LandUseCategories/Details/5
        [Route("Precinct/LandUseCategories/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLandUseCategory = await _context.MstLandUseCategory
                .FirstOrDefaultAsync(m => m.LandUseCategoryId == id);
            if (mstLandUseCategory == null)
            {
                return NotFound();
            }

            return View(mstLandUseCategory);
        }

        // GET: Precinct/LandUseCategories/Create
        [Route("Precinct/LandUseCategories/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Precinct/LandUseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Precinct/LandUseCategories/Create")]
        public async Task<IActionResult> Create(LandUseCategoryModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.LandUseCategory);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Create));
                }
            }
            return View(obj);
        }

        // GET: Precinct/LandUseCategories/Edit/5
        [HttpGet]
        [Route("Precinct/LandUseCategories/Edit")]
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
            return View(Data);
        }

        // POST: Precinct/LandUseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Precinct/LandUseCategories/Edit")]
        public async Task<IActionResult> Edit(LandUseCategoryModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.LandUseCategory, obj.LandUseCategoryId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.LandUseCategoryId);
            
            if (Data.LandUseCategoryId != obj.LandUseCategoryId)
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
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstLandUseCategoryExists(obj.LandUseCategoryId))
                    {
                        TempData["msg"] = "No record found";
                        return RedirectToAction(nameof(Edit));
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(obj);
        }

        // GET: Precinct/LandUseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLandUseCategory = await _context.MstLandUseCategory
                .FirstOrDefaultAsync(m => m.LandUseCategoryId == id);
            if (mstLandUseCategory == null)
            {
                return NotFound();
            }

            return View(mstLandUseCategory);
        }

        // POST: Precinct/LandUseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstLandUseCategory = await _context.MstLandUseCategory.FindAsync(id);
            _context.MstLandUseCategory.Remove(mstLandUseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstLandUseCategoryExists(int id)
        {
            return _context.MstLandUseCategory.Any(e => e.LandUseCategoryId == id);
        }
    }
}
