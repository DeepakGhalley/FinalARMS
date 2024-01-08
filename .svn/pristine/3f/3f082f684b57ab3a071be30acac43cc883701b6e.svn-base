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

namespace ARMS.Areas.TaxMaster.Controllers
{
    [Area("TaxMaster")]
    [Authorize]
    public class TaxPeriodsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ITaxPeriod _repository = new TaxPeriodBLL();

        public TaxPeriodsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: TaxMaster/TaxPeriods
        [Route("TaxMaster/TaxPeriods")]
        public async Task<IActionResult> Index()
        {
            _ = new List<TaxPeriodVM>();
            IList<TaxPeriodVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: TaxMaster/TaxPeriods/Details/5
        [Route("TaxMaster/TaxPeriods/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTaxPeriod = await _context.MstTaxPeriod
                //.Include(m => m.TaxTypeClassification)
                .FirstOrDefaultAsync(m => m.TaxPeriodId == id);
            if (mstTaxPeriod == null)
            {
                return NotFound();
            }

            return View(mstTaxPeriod);
        }

        // GET: TaxMaster/TaxPeriods/Create
        [Route("TaxMaster/TaxPeriods/Create")]
        public IActionResult Create()
        {
            TaxPeriodDropDown();
            return View();
        }
        private void TaxPeriodDropDown()
        {
            ViewData["TaxTypeClassification"] = _CommonRepo.SelectListTaxTypeClassification();
            ViewData["CalendarYear"] = _CommonRepo.SelectListCalendarYear();
            ViewData["TransactionType"] = _CommonRepo.SelectListTransactionType();
        }

        // POST: TaxMaster/TaxPeriods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TaxPeriods/Create")]
        public async Task<IActionResult> Create(TaxPeriodVM obj)
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
            TaxPeriodDropDown();
            return View(obj);
        }

        // GET: TaxMaster/TaxPeriods/Edit/5
        [Route("TaxMaster/TaxPeriods/Edit")]
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
            TaxPeriodDropDown();
            return View(Data);
        }

        // POST: TaxMaster/TaxPeriods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TaxPeriods/Edit")]
        public async Task<IActionResult> Edit(TaxPeriodVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            
            var Data = await _repository.Details(obj.TaxPeriodId);
            if (Data.TaxPeriodId != obj.TaxPeriodId)
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
                    if (!MstTaxPeriodExists(obj.TaxPeriodId))
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
            TaxPeriodDropDown();
            return View(obj);
        }

        // GET: TaxMaster/TaxPeriods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTaxPeriod = await _context.MstTaxPeriod
               // .Include(m => m.TaxTypeClassification)
                .FirstOrDefaultAsync(m => m.TaxPeriodId == id);
            if (mstTaxPeriod == null)
            {
                return NotFound();
            }

            return View(mstTaxPeriod);
        }

        // POST: TaxMaster/TaxPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTaxPeriod = await _context.MstTaxPeriod.FindAsync(id);
            _context.MstTaxPeriod.Remove(mstTaxPeriod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstTaxPeriodExists(int id)
        {
            return _context.MstTaxPeriod.Any(e => e.TaxPeriodId == id);
        }
    }
}
