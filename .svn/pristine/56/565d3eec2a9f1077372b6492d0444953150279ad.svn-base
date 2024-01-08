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
using ARMS.Functions;
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.Rate.Controllers
{
    [Area("Rate")]
    public class PavaRatesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IPavaRate _repository = new PavaRateBLL();

        public PavaRatesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Rate/PavaRates
        [Route("Rate/PavaRates")]
        public async Task<IActionResult> Index()
        {
            _ = new List<PavaRateModel>();
            IList<PavaRateModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Rate/PavaRates/Details/5
        [Route("Rate/PavaRates/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstPavaRate = await _context.MstPavaRate
            //    .Include(m => m.LandUseSubCategory)
            //    .FirstOrDefaultAsync(m => m.PavaRateId == id);
            var data = await _repository.Details(id);
            var objs = _mapper.Map<PavaRateModel>(data);
            if (data == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        // GET: Rate/PavaRates/Create
        [Route("Rate/PavaRates/Create")]
        public IActionResult Create()
        {
            ViewData["LandUseSubCategoryId"] = _CommonRepo.SelectListLandUseSubCategory();
            return View();
        }

        // POST: Rate/PavaRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Rate/PavaRates/Create")]
        public async Task<IActionResult> Create(PavaRateModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

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
            ViewData["LandUseSubCategoryId"] = _CommonRepo.SelectListLandUseSubCategory();
            return View(obj);
        }

        // GET: Rate/PavaRates/Edit/5
        [Route("Rate/PavaRates/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Data = await _repository.Details(id);
            //var mstPavaRate = await _context.MstPavaRate.FindAsync(id);
            if (Data == null)
            {
                return NotFound();
            }
            ViewData["LandUseSubCategoryId"] = _CommonRepo.SelectListLandUseSubCategory();
            return View(Data);
        }

        // POST: Rate/PavaRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Rate/PavaRates/Edit")]
        public async Task<IActionResult> Edit(PavaRateModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            var Data = await _repository.Details(obj.PavaRateId);
            if (Data.PavaRateId != obj.PavaRateId)
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
                    if (!MstPavaRateExists(obj.PavaRateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandUseSubCategoryId"] = _CommonRepo.SelectListLandUseSubCategory();
            return View(obj);
        }

        // GET: Rate/PavaRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstPavaRate = await _context.MstPavaRate
                .Include(m => m.LandUseSubCategory)
                .FirstOrDefaultAsync(m => m.PavaRateId == id);
            if (mstPavaRate == null)
            {
                return NotFound();
            }

            return View(mstPavaRate);
        }

        // POST: Rate/PavaRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstPavaRate = await _context.MstPavaRate.FindAsync(id);
            _context.MstPavaRate.Remove(mstPavaRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstPavaRateExists(int id)
        {
            return _context.MstPavaRate.Any(e => e.PavaRateId == id);
        }
    }
}
