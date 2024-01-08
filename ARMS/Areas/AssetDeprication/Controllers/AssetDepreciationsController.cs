using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;

namespace ARMS.Areas.AssetDeprication.Controllers
{
    [Area("AssetDeprication")]
    public class AssetDepreciationsController : Controller
    {
        private readonly tt_dbContext _context;

        public AssetDepreciationsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: AssetDeprication/AssetDepreciations
        public async Task<IActionResult> Index()
        {
            var tt_dbContext = _context.TblAssetDepreciation.Include(t => t.Asset).Include(t => t.DepreciationType).Include(t => t.FinancialYear);
            return View(await tt_dbContext.ToListAsync());
        }

        // GET: AssetDeprication/AssetDepreciations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAssetDepreciation = await _context.TblAssetDepreciation
                .Include(t => t.Asset)
                .Include(t => t.DepreciationType)
                .Include(t => t.FinancialYear)
                .FirstOrDefaultAsync(m => m.DepreciationId == id);
            if (tblAssetDepreciation == null)
            {
                return NotFound();
            }

            return View(tblAssetDepreciation);
        }

        // GET: AssetDeprication/AssetDepreciations/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.MstAsset, "AssetId", "AssetCode");
            ViewData["DepreciationTypeId"] = new SelectList(_context.EnumDepreciationType, "DepreciationTypeId", "DepreciationType");
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear");
            return View();
        }

        // POST: AssetDeprication/AssetDepreciations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepreciationId,AssetId,FinancialYearId,DepreciationTypeId,DepreciationValue,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] TblAssetDepreciation tblAssetDepreciation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAssetDepreciation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.MstAsset, "AssetId", "AssetCode", tblAssetDepreciation.AssetId);
            ViewData["DepreciationTypeId"] = new SelectList(_context.EnumDepreciationType, "DepreciationTypeId", "DepreciationType", tblAssetDepreciation.DepreciationTypeId);
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear", tblAssetDepreciation.FinancialYearId);
            return View(tblAssetDepreciation);
        }

        // GET: AssetDeprication/AssetDepreciations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAssetDepreciation = await _context.TblAssetDepreciation.FindAsync(id);
            if (tblAssetDepreciation == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.MstAsset, "AssetId", "AssetCode", tblAssetDepreciation.AssetId);
            ViewData["DepreciationTypeId"] = new SelectList(_context.EnumDepreciationType, "DepreciationTypeId", "DepreciationType", tblAssetDepreciation.DepreciationTypeId);
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear", tblAssetDepreciation.FinancialYearId);
            return View(tblAssetDepreciation);
        }

        // POST: AssetDeprication/AssetDepreciations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepreciationId,AssetId,FinancialYearId,DepreciationTypeId,DepreciationValue,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] TblAssetDepreciation tblAssetDepreciation)
        {
            if (id != tblAssetDepreciation.DepreciationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAssetDepreciation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAssetDepreciationExists(tblAssetDepreciation.DepreciationId))
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
            ViewData["AssetId"] = new SelectList(_context.MstAsset, "AssetId", "AssetCode", tblAssetDepreciation.AssetId);
            ViewData["DepreciationTypeId"] = new SelectList(_context.EnumDepreciationType, "DepreciationTypeId", "DepreciationType", tblAssetDepreciation.DepreciationTypeId);
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear", tblAssetDepreciation.FinancialYearId);
            return View(tblAssetDepreciation);
        }

        // GET: AssetDeprication/AssetDepreciations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAssetDepreciation = await _context.TblAssetDepreciation
                .Include(t => t.Asset)
                .Include(t => t.DepreciationType)
                .Include(t => t.FinancialYear)
                .FirstOrDefaultAsync(m => m.DepreciationId == id);
            if (tblAssetDepreciation == null)
            {
                return NotFound();
            }

            return View(tblAssetDepreciation);
        }

        // POST: AssetDeprication/AssetDepreciations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAssetDepreciation = await _context.TblAssetDepreciation.FindAsync(id);
            _context.TblAssetDepreciation.Remove(tblAssetDepreciation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAssetDepreciationExists(int id)
        {
            return _context.TblAssetDepreciation.Any(e => e.DepreciationId == id);
        }
    }
}
