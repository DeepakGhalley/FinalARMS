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

namespace ARMS.Areas.AssetDetails.Controllers
{
    [Area("AssetDetails")]
    public class MeasurementUnitsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IMeasurmentUnit _repository = new MeasurmentUnitBLL();

        public MeasurementUnitsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: AssetDetails/MeasurementUnits
        [Route("AssetDetails/MeasurementUnits")]
        public async Task<IActionResult> Index()
        {
            _ = new List<MeasurementUnitModel>();
            IList<MeasurementUnitModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: AssetDetails/MeasurementUnits/Details/5
        [Route("AssetDetails/MeasurementUnits/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstMeasurementUnit = await _context.MstMeasurementUnit
                .FirstOrDefaultAsync(m => m.MeasurementUnitId == id);
            if (mstMeasurementUnit == null)
            {
                return NotFound();
            }

            return View(mstMeasurementUnit);
        }

        // GET: AssetDetails/MeasurementUnits/Create
        [Route("AssetDetails/MeasurementUnits/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetDetails/MeasurementUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetDetails/MeasurementUnits/Create")]
        public async Task<IActionResult> Create(MeasurementUnitModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            //bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.MeasurementUnitSymbol);
            //if (CreateCheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please enter a different unit symbol";
            //    return View(obj);
            //}
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveMeasurmentUnit(obj);

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
            return View(obj);
        }

        // GET: AssetDetails/MeasurementUnits/Edit/5
        [Route("AssetDetails/MeasurementUnits/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstMeasurementUnit = await _context.MstMeasurementUnit.FindAsync(id);
            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // POST: AssetDetails/MeasurementUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetDetails/MeasurementUnits/Edit")]
        public async Task<IActionResult> Edit(MeasurementUnitModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            //bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.MeasurementUnitSymbol, obj.MeasurementUnitId);//checks duplicate user name
            //if (CheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please enter a different unit symbol";
            //    return View(obj);
            //}
            var Data = await _repository.Details(obj.MeasurementUnitId);
            if (Data.MeasurementUnitId != obj.MeasurementUnitId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateMeasurmentUnit(obj);
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
                    if (!MstMeasurementUnitExists(obj.MeasurementUnitId))
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
            return View(obj);
        }

        // GET: AssetDetails/MeasurementUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstMeasurementUnit = await _context.MstMeasurementUnit
                .FirstOrDefaultAsync(m => m.MeasurementUnitId == id);
            if (mstMeasurementUnit == null)
            {
                return NotFound();
            }

            return View(mstMeasurementUnit);
        }

        // POST: AssetDetails/MeasurementUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstMeasurementUnit = await _context.MstMeasurementUnit.FindAsync(id);
            _context.MstMeasurementUnit.Remove(mstMeasurementUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstMeasurementUnitExists(int id)
        {
            return _context.MstMeasurementUnit.Any(e => e.MeasurementUnitId == id);
        }
    }
}
