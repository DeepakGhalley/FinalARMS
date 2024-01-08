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
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.LandType.Controllers
{
    [Area("LandType")]
    [Authorize]
    public class LandTypesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly ILandType _repository = new LandTypeBLL();


        public LandTypesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: LandType/LandTypes
        [Route("LandType/LandTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LandTypeVM>();
            IList<LandTypeVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: LandType/LandTypes/Details/5
        [Route("LandType/LandTypes/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLandType = await _context.MstLandType
               .FirstOrDefaultAsync(m => m.LandTypeId == id);
            if (mstLandType == null)
            {
                return NotFound();
            }

            return View(mstLandType);
        }

        // GET: LandType/LandTypes/Create
        [Route("LandType/LandTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LandType/LandTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LandType/LandTypes/Create")]
        public async Task<IActionResult> Create(LandTypeVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.LandTypeName);
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

        // GET: LandType/LandTypes/Edit/5
        [Route("LandType/LandTypes/Edit")]
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

        // POST: LandType/LandTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LandType/LandTypes/Edit")]
        public async Task<IActionResult> Edit(LandTypeVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.LandTypeName, obj.LandTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.LandTypeId);
           if (Data.LandTypeId != obj.LandTypeId)
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
                    if (!MstLandTypeExists(obj.LandTypeId))
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

        // GET: LandType/LandTypes/Delete/5
        [Route("MaintenanceType/MaintenanceTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLandType = await _context.MstLandType
                .FirstOrDefaultAsync(m => m.LandTypeId == id);
            if (mstLandType == null)
            {
                return NotFound();
            }

            return View(mstLandType);
        }

        // POST: LandType/LandTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstLandType = await _context.MstLandType.FindAsync(id);
            _context.MstLandType.Remove(mstLandType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstLandTypeExists(int id)
        {
            return _context.MstLandType.Any(e => e.LandTypeId == id);
        }
    }
}
