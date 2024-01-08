using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BLL;
using CORE_DLL;
using CORE_BOL;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.Precinct.Controllers
{
    [Area("Precinct")]
    [Authorize]
    public class LandUseSubCategoriesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly ILandUseSubCategory _repository = new LandUseSubCategoryBLL();

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        public LandUseSubCategoriesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Precinct/LandUseSubCategories
        [Route("Precinct/LandUseSubCategories")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LandUseSubCategoryModel>();
            IList<LandUseSubCategoryModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Precinct/LandUseSubCategories/Details/5
        [Route("Precinct/LandUseSubCategories/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLandUseSubCategory = await _context.MstLandUseSubCategory
                 .Include(m => m.LandUseCategory)
                 .FirstOrDefaultAsync(m => m.LandUseSubCategoryId == id);
            if (mstLandUseSubCategory == null)
            {
                return NotFound();
            }

            return View(mstLandUseSubCategory);
        }

        // GET: Precinct/LandUseSubCategories/Create
        [Route("Precinct/LandUseSubCategories/Create")]
        public IActionResult Create()
        {
            ViewData["LandUseCategoryId"] = _CommonRepo.SelectListLandUseCategory();
            return View();
        }

        // POST: Precinct/LandUseSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Precinct/LandUseSubCategories/Create")]
        public async Task<IActionResult> Create(LandUseSubCategoryModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.LandUseSubCategory);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                ViewData["LandUseCategoryId"] = _CommonRepo.SelectListLandUseCategory();
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
            ViewData["LandUseCategoryId"] = _CommonRepo.SelectListLandUseCategory();
            return View(obj);
        }

        // GET: Precinct/LandUseSubCategories/Edit/5
        [HttpGet]
        [Route("Precinct/LandUseSubCategories/Edit")]
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
            ViewData["LandUseCategoryId"] = _CommonRepo.SelectListLandUseCategory();
            return View(Data);
        }

        // POST: Precinct/LandUseSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Precinct/LandUseSubCategories/Edit")]
        public async Task<IActionResult> Edit(LandUseSubCategoryModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            var Data = await _repository.Details(obj.LandUseSubCategoryId);
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.LandUseSubCategory, obj.LandUseSubCategoryId);
            ViewData["LandUseCategoryId"] = _CommonRepo.SelectListLandUseCategory();

            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                ViewData["LandUseCategoryId"] = _CommonRepo.SelectListLandUseCategory();
                return View(obj);
            }

            if (Data.LandUseSubCategoryId != obj.LandUseSubCategoryId)
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
                    if (!MstLandUseSubCategoryExists(obj.LandUseSubCategoryId))
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
            ViewData["LandUseCategoryId"] = _CommonRepo.SelectListLandUseCategory();
            return View(obj);
        }

        // GET: Precinct/LandUseSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLandUseSubCategory = await _context.MstLandUseSubCategory
                .Include(m => m.LandUseCategory)
                .FirstOrDefaultAsync(m => m.LandUseSubCategoryId == id);
            if (mstLandUseSubCategory == null)
            {
                return NotFound();
            }

            return View(mstLandUseSubCategory);
        }

        // POST: Precinct/LandUseSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstLandUseSubCategory = await _context.MstLandUseSubCategory.FindAsync(id);
            _context.MstLandUseSubCategory.Remove(mstLandUseSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstLandUseSubCategoryExists(int id)
        {
            return _context.MstLandUseSubCategory.Any(e => e.LandUseSubCategoryId == id);
        }
    }
}
