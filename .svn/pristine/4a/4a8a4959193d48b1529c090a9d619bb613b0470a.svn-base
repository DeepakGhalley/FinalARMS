using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;

namespace ARMS.Areas.WaterMaster.Controllers
{
    [Area("WaterMaster")]
    public class WaterMeterReadingsController : Controller
    {
        private readonly tt_dbContext _context;

        public WaterMeterReadingsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: WaterMaster/WaterMeterReadings
        public async Task<IActionResult> Index()
        {
            var tt_dbContext = _context.TrnWaterMeterReading.Include(t => t.TrnWaterConnection).Include(t => t.WaterConnectionStatus).Include(t => t.WaterConnectionType).Include(t => t.WaterLineType).Include(t => t.WaterMeterType);
            return View(await tt_dbContext.ToListAsync());
        }

        // GET: WaterMaster/WaterMeterReadings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trnWaterMeterReading = await _context.TrnWaterMeterReading
                .Include(t => t.TrnWaterConnection)
                .Include(t => t.WaterConnectionStatus)
                .Include(t => t.WaterConnectionType)
                .Include(t => t.WaterLineType)
                .Include(t => t.WaterMeterType)
                .FirstOrDefaultAsync(m => m.TrnWaterMeterReadingId == id);
            if (trnWaterMeterReading == null)
            {
                return NotFound();
            }

            return View(trnWaterMeterReading);
        }

        // GET: WaterMaster/WaterMeterReadings/Create
        public IActionResult Create()
        {
            ViewData["WaterConnectionId"] = new SelectList(_context.MstWaterConnection, "WaterConnectionId", "BillingAddress");
            ViewData["WaterConnectionStatusId"] = new SelectList(_context.EnumWaterConnectionStatus, "WaterConnectionStatusId", "WaterConnectionStatus");
            ViewData["WaterConnectionTypeId"] = new SelectList(_context.MstWaterConnectionType, "WaterConnectionTypeId", "WaterConnectionType");
            ViewData["WaterLineTypeId"] = new SelectList(_context.MstWaterLineType, "WaterLineTypeId", "WaterLineType");
            ViewData["WaterMeterTypeId"] = new SelectList(_context.MstWaterMeterType, "WaterMeterTypeId", "WaterMeterType");
            return View();
        }

        // POST: WaterMaster/WaterMeterReadings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WaterMeterReadingId,WaterConnectionId,WaterConnectionTypeId,WaterMeterTypeId,WaterLineTypeId,WaterConnectionStatusId,Bucid,Reading,PreviousReading,PreviousReadingDate,ReadBy,ReadingDate,NoOfUnit,Consumption,StandardConsumption,IsPermanentConnection,Sewerage,SolidWaste,Remarks,BillingAddress,TransactionId,PrimaryMobileNo,SecondaryMobileNo")] TrnWaterMeterReading trnWaterMeterReading)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trnWaterMeterReading);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WaterConnectionId"] = new SelectList(_context.MstWaterConnection, "WaterConnectionId", "BillingAddress", trnWaterMeterReading.TrnWaterConnectionId);
            ViewData["WaterConnectionStatusId"] = new SelectList(_context.EnumWaterConnectionStatus, "WaterConnectionStatusId", "WaterConnectionStatus", trnWaterMeterReading.WaterConnectionStatusId);
            ViewData["WaterConnectionTypeId"] = new SelectList(_context.MstWaterConnectionType, "WaterConnectionTypeId", "WaterConnectionType", trnWaterMeterReading.WaterConnectionTypeId);
            ViewData["WaterLineTypeId"] = new SelectList(_context.MstWaterLineType, "WaterLineTypeId", "WaterLineType", trnWaterMeterReading.WaterLineTypeId);
            ViewData["WaterMeterTypeId"] = new SelectList(_context.MstWaterMeterType, "WaterMeterTypeId", "WaterMeterType", trnWaterMeterReading.WaterMeterTypeId);
            return View(trnWaterMeterReading);
        }

        // GET: WaterMaster/WaterMeterReadings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trnWaterMeterReading = await _context.TrnWaterMeterReading.FindAsync(id);
            if (trnWaterMeterReading == null)
            {
                return NotFound();
            }
            ViewData["WaterConnectionId"] = new SelectList(_context.MstWaterConnection, "WaterConnectionId", "BillingAddress", trnWaterMeterReading.TrnWaterConnectionId);
            ViewData["WaterConnectionStatusId"] = new SelectList(_context.EnumWaterConnectionStatus, "WaterConnectionStatusId", "WaterConnectionStatus", trnWaterMeterReading.WaterConnectionStatusId);
            ViewData["WaterConnectionTypeId"] = new SelectList(_context.MstWaterConnectionType, "WaterConnectionTypeId", "WaterConnectionType", trnWaterMeterReading.WaterConnectionTypeId);
            ViewData["WaterLineTypeId"] = new SelectList(_context.MstWaterLineType, "WaterLineTypeId", "WaterLineType", trnWaterMeterReading.WaterLineTypeId);
            ViewData["WaterMeterTypeId"] = new SelectList(_context.MstWaterMeterType, "WaterMeterTypeId", "WaterMeterType", trnWaterMeterReading.WaterMeterTypeId);
            return View(trnWaterMeterReading);
        }

        // POST: WaterMaster/WaterMeterReadings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WaterMeterReadingId,WaterConnectionId,WaterConnectionTypeId,WaterMeterTypeId,WaterLineTypeId,WaterConnectionStatusId,Bucid,Reading,PreviousReading,PreviousReadingDate,ReadBy,ReadingDate,NoOfUnit,Consumption,StandardConsumption,IsPermanentConnection,Sewerage,SolidWaste,Remarks,BillingAddress,TransactionId,PrimaryMobileNo,SecondaryMobileNo")] TrnWaterMeterReading trnWaterMeterReading)
        {
            if (id != trnWaterMeterReading.TrnWaterMeterReadingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trnWaterMeterReading);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrnWaterMeterReadingExists(trnWaterMeterReading.TrnWaterMeterReadingId))
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
            ViewData["WaterConnectionId"] = new SelectList(_context.MstWaterConnection, "WaterConnectionId", "BillingAddress", trnWaterMeterReading.TrnWaterConnectionId);
            ViewData["WaterConnectionStatusId"] = new SelectList(_context.EnumWaterConnectionStatus, "WaterConnectionStatusId", "WaterConnectionStatus", trnWaterMeterReading.WaterConnectionStatusId);
            ViewData["WaterConnectionTypeId"] = new SelectList(_context.MstWaterConnectionType, "WaterConnectionTypeId", "WaterConnectionType", trnWaterMeterReading.WaterConnectionTypeId);
            ViewData["WaterLineTypeId"] = new SelectList(_context.MstWaterLineType, "WaterLineTypeId", "WaterLineType", trnWaterMeterReading.WaterLineTypeId);
            ViewData["WaterMeterTypeId"] = new SelectList(_context.MstWaterMeterType, "WaterMeterTypeId", "WaterMeterType", trnWaterMeterReading.WaterMeterTypeId);
            return View(trnWaterMeterReading);
        }

        // GET: WaterMaster/WaterMeterReadings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trnWaterMeterReading = await _context.TrnWaterMeterReading
                .Include(t => t.TrnWaterConnection)
                .Include(t => t.WaterConnectionStatus)
                .Include(t => t.WaterConnectionType)
                .Include(t => t.WaterLineType)
                .Include(t => t.WaterMeterType)
                .FirstOrDefaultAsync(m => m.TrnWaterMeterReadingId == id);
            if (trnWaterMeterReading == null)
            {
                return NotFound();
            }

            return View(trnWaterMeterReading);
        }

        // POST: WaterMaster/WaterMeterReadings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trnWaterMeterReading = await _context.TrnWaterMeterReading.FindAsync(id);
            _context.TrnWaterMeterReading.Remove(trnWaterMeterReading);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrnWaterMeterReadingExists(int id)
        {
            return _context.TrnWaterMeterReading.Any(e => e.TrnWaterMeterReadingId == id);
        }
    }
}
