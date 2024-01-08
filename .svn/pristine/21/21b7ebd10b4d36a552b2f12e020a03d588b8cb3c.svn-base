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

namespace ARMS.Areas.TaxMaster.Controllers
{
    [Area("TaxMaster")]
    public class RatesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IRate _repository = new RateBLL();

        public RatesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: TaxMaster/Rates
        [Route("TaxMaster/Rates")]
        public async Task<IActionResult> Index()
        {
            _ = new List<RateVM>();
            IList<RateVM> obj = _repository.GetAll();
            RateDropDown();
            return View(obj);
        }

        // GET: TaxMaster/Rates/Details/5
        [Route("TaxMaster/Rates/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstRate = await _context.MstRate
                .Include(m => m.Slab)
                .Include(m => m.Tax)
                .FirstOrDefaultAsync(m => m.RateId == id);
            if (mstRate == null)
            {
                return NotFound();
            }

            return View(mstRate);
        }

        // GET: TaxMaster/Rates/Create
        [Route("TaxMaster/Rates/Create")]
        public IActionResult Create()
        {
            RateDropDown();
            return View();
        }
        public void RateDropDown()
        {
            ViewData["SlabId"] = _CommonRepo.SelectListSlab();
            ViewData["TaxId"] = _CommonRepo.SelectListTaxMaster();
        }

        // POST: TaxMaster/Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/Rates/Create")]
        public async Task<IActionResult> Create(RateVM obj)
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
            RateDropDown();
            return View(obj);
        }

        // GET: TaxMaster/Rates/Edit/5
        [Route("TaxMaster/Rates/Edit")]
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
            RateDropDown();
            return View(Data);
        }

        // POST: TaxMaster/Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/Rates/Edit")]
        public async Task<IActionResult> Edit(RateVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.RateId);
            if (Data.RateId != obj.RateId)
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
                    if (!MstRateExists(obj.RateId))
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
            RateDropDown();
            return View(obj);
        }

        // GET: TaxMaster/Rates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstRate = await _context.MstRate
                .Include(m => m.Slab)
                .Include(m => m.Tax)
                .FirstOrDefaultAsync(m => m.RateId == id);
            if (mstRate == null)
            {
                return NotFound();
            }

            return View(mstRate);
        }

        // POST: TaxMaster/Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstRate = await _context.MstRate.FindAsync(id);
            _context.MstRate.Remove(mstRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstRateExists(int id)
        {
            return _context.MstRate.Any(e => e.RateId == id);
        }
    }
}
