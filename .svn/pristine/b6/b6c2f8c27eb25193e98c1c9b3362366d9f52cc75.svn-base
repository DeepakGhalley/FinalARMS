using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.Year.Controllers
{
    [Area("Year")]
    [Authorize]
    public class CalendarYearsController : Controller
    {
        private readonly tt_dbContext _context;

        public CalendarYearsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Year/CalendarYears
        [Route("Year/CalendarYears")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MstCalendarYear.ToListAsync());
        }

        // GET: Year/CalendarYears/Details/5
        [Route("Year/CalendarYears/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstCalendarYear = await _context.MstCalendarYear
                .FirstOrDefaultAsync(m => m.CalendarYearId == id);
            if (mstCalendarYear == null)
            {
                return NotFound();
            }

            return View(mstCalendarYear);
        }

        // GET: Year/CalendarYears/Create
        [Route("Year/CalendarYears/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Year/CalendarYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Year/CalendarYears/Create")]
        public async Task<IActionResult> Create([Bind("CalendarYearId,CalendarYear,StartDate,EndDate,IsActive,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] MstCalendarYear mstCalendarYear)
        {
            mstCalendarYear.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            mstCalendarYear.CreatedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(mstCalendarYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mstCalendarYear);
        }

        // GET: Year/CalendarYears/Edit/5
        [Route("Year/CalendarYears/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstCalendarYear = await _context.MstCalendarYear.FindAsync(id);
            if (mstCalendarYear == null)
            {
                return NotFound();
            }
            return View(mstCalendarYear);
        }

        // POST: Year/CalendarYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Year/CalendarYears/Edit")]
        public async Task<IActionResult> Edit(int CalendarYearId, [Bind("CalendarYearId,CalendarYear,StartDate,EndDate,IsActive,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] MstCalendarYear mstCalendarYear)
        {
            mstCalendarYear.CalendarYearId = mstCalendarYear.CalendarYearId;
            mstCalendarYear.CalendarYear = mstCalendarYear.CalendarYear;
            mstCalendarYear.StartDate = mstCalendarYear.StartDate;
            mstCalendarYear.EndDate = mstCalendarYear.EndDate;
            mstCalendarYear.CreatedOn = mstCalendarYear.CreatedOn;
            mstCalendarYear.CreatedBy = mstCalendarYear.CreatedBy;
            mstCalendarYear.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            mstCalendarYear.ModifiedOn = DateTime.Now;

            if (CalendarYearId != mstCalendarYear.CalendarYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstCalendarYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstCalendarYearExists(mstCalendarYear.CalendarYearId))
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
            return View(mstCalendarYear);
        }

        // GET: Year/CalendarYears/Delete/5
        [Route("Year/CalendarYears/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstCalendarYear = await _context.MstCalendarYear
                .FirstOrDefaultAsync(m => m.CalendarYearId == id);
            if (mstCalendarYear == null)
            {
                return NotFound();
            }

            return View(mstCalendarYear);
        }

        // POST: Year/CalendarYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Year/CalendarYears/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstCalendarYear = await _context.MstCalendarYear.FindAsync(id);
            _context.MstCalendarYear.Remove(mstCalendarYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstCalendarYearExists(int id)
        {
            return _context.MstCalendarYear.Any(e => e.CalendarYearId == id);
        }
    }
}
