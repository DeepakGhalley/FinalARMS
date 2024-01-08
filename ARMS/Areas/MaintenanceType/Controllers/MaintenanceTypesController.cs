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
using ARMS.Functions;
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.MaintenanceType.Controllers
{
    [Area("MaintenanceType")]
    public class MaintenanceTypesController : Controller
    {
        private readonly tt_dbContext _context;

        readonly IMaintenanceType _repository = new MaintenanceTypeBLL();

        public MaintenanceTypesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: MaintenanceType/MaintenanceTypes
        [Route("MaintenanceType/MaintenanceTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<MaintenanceTypeVM>();
            IList<MaintenanceTypeVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: MaintenanceType/MaintenanceTypes/Details/5
        [Route("MaintenanceType/MaintenanceTypes/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstMaintenanceType = await _context.MstMaintenanceType
                .FirstOrDefaultAsync(m => m.MaintenanceTypeId == id);
            if (mstMaintenanceType == null)
            {
                return NotFound();
            }

            return View(mstMaintenanceType);
        }

        // GET: MaintenanceType/MaintenanceTypes/Create
        [Route("MaintenanceType/MaintenanceTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceType/MaintenanceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MaintenanceType/MaintenanceTypes/Create")]
        public async Task<IActionResult> Create(MaintenanceTypeVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.MaintenanceType);
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

        // GET: MaintenanceType/MaintenanceTypes/Edit/5
        [Route("MaintenanceType/MaintenanceTypes/Edit")]
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

        // POST: MaintenanceType/MaintenanceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MaintenanceType/MaintenanceTypes/Edit")]
        public async Task<IActionResult> Edit(MaintenanceTypeVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.MaintenanceType, obj.MaintenanceTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.MaintenanceTypeId);
            if (Data.MaintenanceTypeId != obj.MaintenanceTypeId)
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
                    if (!MstMaintenanceTypeExists(obj.MaintenanceTypeId))
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
            return View(obj);
        }

        // GET: MaintenanceType/MaintenanceTypes/Delete/5
        [Route("MaintenanceType/MaintenanceTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstMaintenanceType = await _context.MstMaintenanceType
                .FirstOrDefaultAsync(m => m.MaintenanceTypeId == id);
            if (mstMaintenanceType == null)
            {
                return NotFound();
            }

            return View(mstMaintenanceType);
        }

        // POST: MaintenanceType/MaintenanceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstMaintenanceType = await _context.MstMaintenanceType.FindAsync(id);
            _context.MstMaintenanceType.Remove(mstMaintenanceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstMaintenanceTypeExists(int id)
        {
            return _context.MstMaintenanceType.Any(e => e.MaintenanceTypeId == id);
        }
    }
}
